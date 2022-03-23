using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SkSampleLibrary.Validators
{
    public class PasswordValidator
    {
        public bool IsValid(string password)
        {
            Regex passwordPolicyExpression = new Regex(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#!$%]).{8,20})");
            return passwordPolicyExpression.IsMatch(password);
        }
    }
}