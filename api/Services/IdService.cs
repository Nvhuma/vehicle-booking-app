using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using System.Text.RegularExpressions;

namespace api.Services
{
    public class IdService : IIdService
    {
        public async Task<AppUser> ExtractIdDetailsAsync(string idNumber)
        {
            // Define the regex pattern to match the RSA ID number structure
            string pattern = @"^(?<dob>\d{6})(?<gender>\d{4})(?<citizenship>\d{1})\d{2}$";

            // Match the ID number against the regex pattern
            Match match = Regex.Match(idNumber, pattern);

            if (match.Success)
            {
                // Extract date of birth, gender, and citizenship status from the ID number
                string dob = match.Groups["dob"].Value;
                string genderCode = match.Groups["gender"].Value;
                string citizenship = match.Groups["citizenship"].Value;

                // Determine the correct year prefix based on the century
                string yearPrefix = dob.StartsWith("00") ? "20" : "19";
                string year = yearPrefix + dob.Substring(0, 2);
                string month = dob.Substring(2, 2);
                string day = dob.Substring(4, 2);

                // Parse the date of birth into a DateTime object
                DateTime dateOfBirth = DateTime.ParseExact($"{year}-{month}-{day}", "yyyy-MM-dd", null);

                // Determine gender based on the first digit of the gender code
                string gender = int.Parse(genderCode.Substring(0, 1)) >= 5 ? "Male" : "Female";

                // Determine citizenship status based on the citizenship code
                string citizenshipStatus = citizenship == "0" ? "South African Citizen" : "Permanent Resident";

                // Return a new User instance with the extracted details
                return new AppUser
                {
                    DateOfBirth = dateOfBirth,
                    Gender = gender,
                    CitizenshipStatus = citizenshipStatus
                };
            }
            else
            {
                throw new ArgumentException("Invalid RSA ID number format.");
            }
        }
    }
}