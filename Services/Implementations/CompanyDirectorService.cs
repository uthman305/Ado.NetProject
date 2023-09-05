using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdoProject.Model.Entities;
using AdoProject.Model.Enum;
using AdoProject.Repository.Implementations;
using AdoProject.Repository.Interface;
using AdoProject.Services.Interface;

namespace AdoProject.Services.Implementations
{

    public class CompanyDirectorService : ICompanyDirectorService
    {
        public static IUserRepository _userRepository = new UserRepository();
        public static ICompanyDirectorRepository _companyDirectorRepository = new CompanyDirectorRepository();
        public static ICompanyRepository _companyRepository = new CompanyRepository();
        public static IWalletRepository _walletRepository = new WalletRepository();


        public CompanyDirector Create(string name, string email, string password, string phoneNumber, int gend, int pin, string companyName)
        {
             if (!IsValidEmailAddress(email))
            {
                throw new ArgumentException("Invalid email address.");
            }
             if (!IsValidEmailAddress(phoneNumber))
            {
                throw new ArgumentException("Invalid Phone Number.");
            }
            
              User user = new User
            {
                UserId = Guid.NewGuid().ToString().Substring(0, 3),
                Name = name,
                Email = email,
                Password = password,
                PhoneNumber = phoneNumber,
                Role = "Manager",
                Gender = (Gender)gend,

            };
            _userRepository.Create(user);

            Wallet wallet = new Wallet
            {
                UserId = user.UserId,
                Pin = pin,
                MoneyBalance = 0,
                CardBalance = 0,
                AccountNumber = phoneNumber.Substring(1, 10),

            };
           
                _walletRepository.Create(wallet);

            Company company = new Company
            {
                CompanyName = companyName,
                WalletId = wallet.Id
            };
            _companyRepository.Create(company);
            
            CompanyDirector companyDirector = new CompanyDirector
            {
                UserId = user.UserId,
                WalletId = wallet.Id,
                CompanyId = company.Id

            };
           
                _companyDirectorRepository.Create(companyDirector);
                
           
            return companyDirector;
        }
         static bool IsValidEmailAddress(string email)
        {
            // Regular expression pattern for basic email validation.
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Use the Regex class to check if the email matches the pattern.
            return Regex.IsMatch(email, pattern);
        }
        static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // Remove any non-digit characters from the phone number
            string digitsOnly = new string(phoneNumber.Where(char.IsDigit).ToArray());

            // Check if the resulting string has exactly 11 digits
            return digitsOnly.Length == 11;
        }
    }
}