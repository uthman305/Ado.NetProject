using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdoProject.Services.Implementations
{
    public class ValidationService
    {
        static bool IsValidEmailAddress(string email)
        {
            // Regular expression pattern for basic email validation.
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Use the Regex class to check if the email matches the pattern.
            return Regex.IsMatch(email, pattern);
        }
    }
}