using System;

namespace Automation.API.Framework.Models.ResponseModel
{
    internal class CustomerResponse
    {
        public int cusId, dob;
        public string fname, lname;
        public skills Skill;
    }
}

public class skills
{
    public string name;
    public DateTime dateAcquired;
    public string BodyAwardingQualification;
}