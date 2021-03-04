using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankapp3
{
    class Program
    {
       
            public static void Add()
            {
                Account a = new Account();
                AccountCrud ac = new AccountCrud();
                a.acno = ac.Generate();

                Console.WriteLine("Enter First Name ");
                a.fname = Console.ReadLine();
                Console.WriteLine("Enter Last Name ");
                a.lname = Console.ReadLine();
                Console.WriteLine("Enter City ");
                a.city = Console.ReadLine();
                Console.WriteLine("Enter state ");
                a.state = Console.ReadLine();
                
                a.date = "";
                Console.WriteLine("Enter Amount");
                a.amount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Cheque Facility ");
                a.cheq = Console.ReadLine();
                Console.WriteLine("Enter Account type ");
                a.actype = Console.ReadLine();

                
                a.status = "true";

                Console.WriteLine(ac.AddAccount(a));
            }
            public static void Show()
            {
                AccountCrud ac = new AccountCrud();
                Account[] ar = ac.ShowAccount();
                foreach (Account a in ar)
                {
                    Console.WriteLine(a);
                    Console.WriteLine("--------------------------------");
                }
            }
            public static void Search()
            {
                Console.WriteLine("Enter accountno");
                int n = Convert.ToInt32(Console.ReadLine());
                string firstname, lastname, city, state, cheqfacil, accounttype;
                int amount;
                AccountCrud ac = new AccountCrud();
                ac.SearchAccount(n, out firstname, out lastname, out city, out state, out amount, out cheqfacil, out accounttype);
                Console.WriteLine("Firstname : " + firstname);
                Console.WriteLine("Lastname : " + lastname);
                Console.WriteLine("City : " + city);
                Console.WriteLine("State : " + state);
                Console.WriteLine("Amount : " + amount);
                Console.WriteLine("Ceqfacil : " + cheqfacil);
                Console.WriteLine("Accounttype : " + accounttype);

            }
            

            public static void CloseAccount()
            {
            int acno;
            Console.WriteLine("enter account number");
            acno = Convert.ToInt32(Console.ReadLine());
            AccountCrud obj = new AccountCrud();
            Console.WriteLine(obj.Close(acno));
            }

            public static void DepositAccount()
            {
                AccountCrud ac = new AccountCrud();
                int n, amount;
                Console.WriteLine("Enter accountno");
                n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter deposit ammount");
                   amount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(ac.depositaccount(n, amount));
            }


        public static void Withdraw()
            {
                AccountCrud ac = new AccountCrud();
                int n, amount;
                Console.WriteLine("Enter accountno");
                n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter withdrawAMount");
                amount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(ac.WithdrawAccount(n, amount));
            }
            static void Main(string[] args)
            {
                int ch;
                do
                {
                    Console.WriteLine("-------------------------------\nOptions");
                    Console.WriteLine("1. insert account details\n2. Show Account details\n3. Search Account");
                    Console.WriteLine("4. deposit amount \n5. withdraw\n6. delete account\n7. Exit");
                    Console.WriteLine("--------------------\nEnter your Choice");
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            Add();
                            break;
                        case 2:
                            Show();
                            break;
                        case 3:
                            Search();
                            break;
                  
                        case 6:
                            CloseAccount();
                            break;
                        case 4:
                            DepositAccount();
                            break;
                        case 5:
                            Withdraw();
                            break;
                        case 7: return;
                        default:
                            Console.WriteLine("Invalid Choice!!");
                            break;
                    }
                } while (ch != 7);
            }
        
    }
}
