using Automation.API.Framework.BackEnd;
using Automation.Framework.Base;
using Automation.Framework.Core;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;
using Unity;
using Unity.Lifetime;

namespace Automation.API.Framework
{
    [Binding]
    public sealed class Hooks
    {
        private static CommonPage _commonPage;
        private ScenarioContext scenarioContext;
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static AventStack.ExtentReports.ExtentReports extent;

        public Hooks()
        {
            this.scenarioContext = ScenarioContext.Current;
        }

        //clears screen shot folder before the test run 
        private static void clearScreenShots()
        {
            string rootpath = Directory.GetCurrentDirectory();
            string pathString = System.IO.Path.Combine(rootpath, "ScreenShots");
            System.IO.DirectoryInfo ScreenShotdir = new System.IO.DirectoryInfo(pathString);
            if (ScreenShotdir.Exists) ScreenShotdir.Delete(true);
        }

        
        private static void reportInitalise()
        {
            string rootpath = Directory.GetCurrentDirectory();
            string pathString = System.IO.Path.Combine(rootpath, @"Reports\Reports " + DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss"));
            System.IO.DirectoryInfo ScreenShotdir = new System.IO.DirectoryInfo(pathString);

            if (!ScreenShotdir.Exists)
                System.IO.Directory.CreateDirectory(pathString);

            var htmlReporter = new ExtentHtmlReporter(pathString + "\\TestReport " + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);
        }


        public static void SetUp()
        {
            var config = new ConfigurationBuilder()
                            .AddJsonFile("AppConfig.json")
                                .Build();

            string environment = config["Environment"]; 

            //clearing screen shots 
            clearScreenShots();

            //Setting test environment
            if (environment.Equals("Dev"))
                EnvirnomentConfig.setTestEnvirnoment(Envirnoment.Dev);
            else if (environment.Equals("SysTest"))
                EnvirnomentConfig.setTestEnvirnoment(Envirnoment.SysTest);
            else if (environment.Equals("UAT"))
                EnvirnomentConfig.setTestEnvirnoment(Envirnoment.UAT);
            else if (environment.Equals("Staging"))
                EnvirnomentConfig.setTestEnvirnoment(Envirnoment.Staging);

            //Set Base URL for the APP
            BaseURLs.SetBaseUrl(EnvirnomentConfig.TestEnvirnoment);

            //Set DB Connection strings
            DBConnectionStrings.SetDBConnectionString(EnvirnomentConfig.TestEnvirnoment);

            //Initialize Log File
            Driver.CreateLog("Logs ");

            //Initialize Reports
            reportInitalise();

        }


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            SetUp();

            //register pages
            UnityContainerFactory.GetContainer().RegisterType<CommonPage>(new ContainerControlledLifetimeManager());

            Log.Information("******************************************");
            Log.Information("\nNew Test Cycle :");
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            Log.Information("[Feature] : {0}", FeatureContext.Current.FeatureInfo.Title);
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Log.Information("[Scenario Start] : {0}", scenarioContext.ScenarioInfo.Title);
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            Log.Information("[Step] : {0}", scenarioContext.StepContext.StepInfo.Text);
        }

        [AfterStep]
        public void AfterStep()
        {
            if (scenarioContext.TestError != null)
            {
                Log.Error(scenarioContext.TestError.ToString());
                Log.Debug(scenarioContext.TestError.StackTrace);
                Log.Error(scenarioContext.TestError.Source);
            }

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(scenarioContext, null);

            if (scenarioContext.TestError == null)
            {
                if (!scenarioContext.ScenarioInfo.Tags[0].Contains("manual"))
                {
                    if (stepType == "Given")
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "When")
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "Then")
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                    else if (stepType == "And")
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else
                {
                    if (stepType == "Given")
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Manual Test");
                    else if (stepType == "When")
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Manual Test");
                    else if (stepType == "Then")
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Manual Test");
                }
            }
            else if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail("\n\n Message : " + scenarioContext.TestError.Message + "\n\nStack Trace :\n\n" + scenarioContext.TestError.StackTrace);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail("\n\n Message : " + scenarioContext.TestError.Message + "\n\nStack Trace :\n\n" + scenarioContext.TestError.StackTrace);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail("\n\n Message : " + scenarioContext.TestError.Message + "\n\nStack Trace :\n\n" + scenarioContext.TestError.StackTrace);
                }
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Log.Information("[scenario completed]");
            Log.Information("------------------------------------------------------------");
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Log.Information("[Feature completed] ");
            Log.Information("==============================================================");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Log.Information("\n******************************************");
            Log.Information("\nEnd of Test Cycle :");

            Log.CloseAndFlush();
            extent.Flush();
        }
    }
}