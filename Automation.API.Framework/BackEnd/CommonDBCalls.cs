using Automation.Framework.Core;
using System;
using System.Collections;
using System.Data.SqlClient;
using System.Text;

namespace Automation.API.Framework.BackEnd
{
    public class CommonDBCalls
    {
        /// <summary>
        /// Retrieves a long string which has result of each record
        /// </summary>
        /// <param name="SQLCommandLine">request query</param>
        /// <returns>Returns a list of all row data </returns>
        public static ArrayList SQLGetSeperatedList(string SQLCommandLine)
        {
            ArrayList List = new ArrayList();
            using (SqlConnection conn = new SqlConnection(DBConnectionStrings.DBConnectionStr))
            {
                conn.Open();
                SqlCommand insertcommand = new SqlCommand(SQLCommandLine, conn);
                SqlDataReader returnValue = insertcommand.ExecuteReader();

                while (returnValue.Read())
                {
                    List.Add(returnValue.GetValue(0));
                }
            }
            return List;
        }

        /// <summary>
        /// Retrieves a list of all records returned by the query supplied
        /// </summary>
        /// <param name="SQLCommandLine">request query</param>
        /// <returns>Returns a list of all records returned by query 
        /// </returns>
        public static ArrayList SQLGetCompleteRecord(string SQLCommandLine)
        {
            ArrayList List = new ArrayList();

            using (SqlConnection conn = new SqlConnection(DBConnectionStrings.DBConnectionStr))
            {
                conn.Open();
                SqlCommand insertcommand = new SqlCommand(SQLCommandLine, conn);
                SqlDataReader returnValue = insertcommand.ExecuteReader();

                while (returnValue.Read())
                {
                    for (int i = 0; i < returnValue.FieldCount; i++)
                    {
                        List.Add(returnValue.GetValue(i));
                    }
                }
            }
            return List;
        }

        /// <summary>
        /// Retrieves a GUID 
        /// </summary>
        /// <param name="SQLCommandLine">Requested query</param>
        /// <returns>Returns GUID returned by query</returns>
        public static string SQLGetSingleResult(string SQLCommandLine)
        {
            string singleResult;

            using (SqlConnection conn = new SqlConnection(DBConnectionStrings.DBConnectionStr))
            {
                conn.Open();
                SqlCommand insertcommand = new SqlCommand(SQLCommandLine, conn);
                try
                {
                    singleResult = insertcommand.ExecuteScalar().ToString();
                }
                catch
                { singleResult = ""; }
            }
            return singleResult;
        }

        /// <summary>
        /// Execute a sql query 
        /// </summary>
        /// <param name="SQLCommandLine">Scalar query</param>
        public static void ExecuteSQLCommand(string SQLCommandLine)
        {
             ;

            using (SqlConnection conn = new SqlConnection(DBConnectionStrings.DBConnectionStr))
            {
                conn.Open();
                SqlCommand insertcommand = new SqlCommand(SQLCommandLine, conn);
                insertcommand.ExecuteScalar();
            }
        }
    }
}

