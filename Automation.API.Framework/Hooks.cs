using Automation.API.Framework.BackEnd;
using Automation.Framework.Base;
using Automation.Framework.Core;
using TechTalk.SpecFlow;
using Unity;
using Unity.Lifetime;

namespace Automation.API.Framework
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public static void BeforeTestRun()
        {
            UnityContainerFactory.GetContainer().RegisterType<CommonPage>(new ContainerControlledLifetimeManager());
            Driver.CreateLog("InE_Log ");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
