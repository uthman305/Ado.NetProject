using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Services.Implementations;
using AdoProject.Services.Interface;

namespace AdoProject.Menu
{
    public class CompanyMenu
    {

        public static IUserService _userService = new UserService();
        public static IAgentService _agentService = new AgentService();
        public static IWalletService _walletService = new WalletService();
        public static IDepositService _depositService = new DepositService();
        public void CompanyMain()
        {
            try
            {
                System.Console.WriteLine("enter 1 to deposit Card \nEnter 2 to register an agent\nEnter 3 to check balance\nEnter 4 to log out");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    DepositMenu();
                }
                else if (opt == 2)
                {
                    AccountForm();
                }
                else if (opt == 3)
                {
                    GetBalance();
                }
                else if (opt == 4)
                {
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Main();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                CompanyMain();
            }
        }

        public void DepositMenu()
        {
            try
            {
                Console.Write("enter your account number: ");
                string accountNumber = Console.ReadLine();
                Console.Write("enter the amount: ");
                double amount = double.Parse(Console.ReadLine());
                Console.Write("enter your pin: ");
                int pin = int.Parse(Console.ReadLine());

                var deposit = _depositService.Create(amount, accountNumber, pin);
                _walletService.UpdateCardBalance(accountNumber,amount);

                var balance = _walletService.Get(accountNumber);
                if (deposit == null)
                {
                     Console.WriteLine("Transaction not successful");
                    CompanyMain();
                }
                else
                {
                    Console.WriteLine($"transaction succesful");
                    Console.WriteLine(" Do you want to continue if yes press 1 if no press any number\nIf no press 2 ");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        CompanyMain();
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

                        CompanyMain();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                CompanyMain();
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

                var agent = _agentService.Create(name, email, password, phoneNumber, gend, pin);
                if (agent == null)
                {
                    System.Console.WriteLine("not succesful");
                }
                else
                {
                    System.Console.WriteLine($"congratulations  your account number is {phoneNumber.Substring(1, 10)}");
                    Console.WriteLine(" Do you want to continue if yes press 1 if no press any number\nIf no press 2 ");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        CompanyMain();
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

                        CompanyMain();
                    }

                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                CompanyMain();
            }
        }
        public void GetBalance()
        {
            Console.Write("enter your account number: ");
            string accountNumber = Console.ReadLine();
            Console.Write("enter your pin ");
            int pin = int.Parse(Console.ReadLine());

            _walletService.GetBalance(accountNumber, pin);
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                CompanyMain();
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

                CompanyMain();
            }
        }
    }
}