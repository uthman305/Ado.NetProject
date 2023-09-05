using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Services.Implementations;
using AdoProject.Services.Interface;

namespace AdoProject.Menu
{
    public class CustomerMenu
    {
        public static IUserService _userService = new UserService();
        public static ICustomerService _customerService = new CustomerService();
        public static IWalletService _walletService = new WalletService();
        public static IDepositService _depositService = new DepositService();
        public static IPurchaseService _purchaseService = new PurchaseService();

        public void CustomerMain()
        {
            try
            {
                System.Console.WriteLine("enter 1 to deposit Money \nEnter 2 to make purchase\nEnter 3 to check balance\nEnter 4 to log out");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    DepositMenu();
                }
                else if (opt == 2)
                {
                    PurchaseMenu();
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

                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine("wrong input");
                    Console.ResetColor();

                    CustomerMain();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                CustomerMain();
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
                _walletService.UpdateMoneyBalance(accountNumber, amount);
                var balance = _walletService.Get(accountNumber);
                if (deposit == null)
                {
                    Console.WriteLine("Transaction not successful");
                    CustomerMain();
                }
                else
                {
                    Console.WriteLine("Transaction successful");

                    Console.WriteLine(" Do you want to continue if yes press 1 if no press any number\nIf no press 2 ");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        CustomerMain();
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

                        CustomerMain();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                CustomerMain();
            }

        }

        public void PurchaseMenu()
        {
            try
            {
                Console.Write("enter your account number: ");
                string accountNumber = Console.ReadLine();
                Console.Write("enter Seller account number: ");
                string selleracc = Console.ReadLine();
                Console.Write("enter the amount: ");
                double amount = double.Parse(Console.ReadLine());
                Console.Write("enter your pin: ");
                int pin = int.Parse(Console.ReadLine());
                var purchase = _purchaseService.Create(amount, accountNumber, selleracc, pin);
                var balance = _walletService.Get(accountNumber);
                if (purchase == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Transaction not successful");
                    Console.ResetColor();

                    CustomerMain();
                }
                else
                {
                    Console.WriteLine($"transaction succesful");
                    Console.WriteLine(" Do you want to continue if yes press 1 if no press any number\nIf no press 2 ");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        CustomerMain();
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

                        CustomerMain();
                    }
                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                CustomerMain();
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
                CustomerMain();
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

                CustomerMain();
            }
        }
    }
}