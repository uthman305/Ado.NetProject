using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Repository.Implementations;
using AdoProject.Repository.Interface;
using AdoProject.Services.Implementations;
using AdoProject.Services.Interface;

namespace AdoProject.Menu
{
    public class MainMenu
    {
        CustomerMenu customerMenu = new CustomerMenu();
        AgentMenu agentMenu = new AgentMenu();
        CompanyMenu companyMenu = new CompanyMenu();
        SuperMenu superMenu = new SuperMenu();
        public static IUserService _userService = new UserService();
        public static ICustomerService _customerService = new CustomerService();
        public void Main()
        {

            Console.WriteLine("welcome to SalTech\nEnter 1 to Register\nEnter 2 to login");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                AccountForm();
            }
            else if (option == 2)
            {
                LoginForm();
            }
            else
            {
                System.Console.WriteLine("wrong input");
                Main();
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

                var customer = _customerService.Create(name, email, password, phoneNumber, gend, pin);
                if (customer == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine("not succesful");
                    Console.ResetColor();
                }
                else
                {
                    System.Console.WriteLine($"congratulations  your account number is {phoneNumber.Substring(1, 10)}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                Main();
            }
            Main();

        }

        public void LoginForm()
        {
            try
            {
                Console.Write("enter your email address: ");
                string email = Console.ReadLine();
                Console.Write("enter your password: ");
                string password = Console.ReadLine();
                var emails = _userService.Get(email);
                var user = _userService.Login(email, password);
                if (user == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("wrong cridentials");
                    Console.ResetColor();

                    LoginForm();
                }
                else
                {

                    if (emails.Role == "Customer")
                    {
                        customerMenu.CustomerMain();
                    }
                    else if (user.Role == "Agent")
                    {
                        agentMenu.AgentMain();
                    }
                    else if (user.Role == "Manager")
                    {
                        companyMenu.CompanyMain();
                    }
                    else if (user.Role == "SuperAdmin")
                    {
                        superMenu.SuperMain();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                Main();
            }
             Main();
        }
    }
}