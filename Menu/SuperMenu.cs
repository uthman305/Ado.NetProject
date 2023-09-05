using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Services.Implementations;
using AdoProject.Services.Interface;

namespace AdoProject.Menu
{
    public class SuperMenu
    {

         public static IUserService _userService = new UserService();
        public static ICustomerService _customerService = new CustomerService();
        public static ICompanyDirectorService _companyDirectorService = new CompanyDirectorService();
        public void SuperMain()
        {
            try
            {
            Console.WriteLine("welcome to SalTech\nEnter 1 to Register A company \nEnter 2 to go to Main menu");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                AccountForm();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                System.Console.WriteLine("wrong input");
                Console.ResetColor();

                SuperMain();
            }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();

                SuperMain();
            }
        }
        public void AccountForm()
        {
            try
            {
            Console.Write("enter your first name: ");
            string name = Console.ReadLine();
            Console.Write("enter your email address: ");
            string email = Console.ReadLine();
            Console.Write("enter your password: ");
            string password = Console.ReadLine();
            Console.Write("enter your phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("enter your date of birth: ");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            Console.Write("enter 1 for male and 2 for female: ");
            int gend = int.Parse(Console.ReadLine());
            Console.Write("enter your pin: ");
            int pin = int.Parse(Console.ReadLine());
            Console.Write("enter your company name: ");
            string companyName = Console.ReadLine();

             var company =  _companyDirectorService.Create(name, email, password, phoneNumber, gend, pin, companyName);
            if (company == null)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                System.Console.WriteLine("not succesful");
                Console.ResetColor();

            }
            else
            {
                System.Console.WriteLine($"congratulations  your company has been created succesfully");
                Console.WriteLine(" Do you want to continue if yes press 1 \nIf you want to log out press 2");
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    SuperMain();

                }
                else if (input == 2)
                {
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Main();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("wrong input");
                    Console.ResetColor();

                    SuperMain();
                }
            }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();

                SuperMain();
            }

        }
    }
}