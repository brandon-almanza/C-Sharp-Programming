using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace A3_BrandonArgenalAlmanza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestApp();
        }
        static void TestApp()
        {
            Console.WriteLine("Student ID - 301467830");
            Console.WriteLine("Name - Brandon Argenal Almanza");

            Bank.AccountList.Add(new SavingsAccount("S647", "Alex Du", 222290192, 4783.98));
            Bank.AccountList.Add(new ChequingAccount("C576", "Dale Stayne", 333312312, 12894.56));

            Bank.ShowAll();

            Console.WriteLine($"{new string('-', 90)}");
            Console.WriteLine("Trying to withdraw $500.00 from the following account");
            Console.WriteLine(Bank.AccountList[0].ToString());

            try
            {
                Bank.AccountList[0].Withdraw(500.00);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"{new string('-', 90)}");

            Console.WriteLine($"{new string('-', 90)}");
            Console.WriteLine("Trying to deposit $-250.00 to the following account");
            Console.WriteLine(Bank.AccountList[1].ToString());

            try
            {
                Bank.AccountList[1].Deposit(-250.00);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"{new string('-', 90)}");

            Console.WriteLine($"{new string('-', 90)}");
            Console.WriteLine("Trying to withdraw $10000.00 to the following account");
            Console.WriteLine(Bank.AccountList[2].ToString());

            try
            {
                Bank.AccountList[2].Withdraw(10000.00);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"{new string('-', 90)}");

            Console.WriteLine($"{new string('-', 90)}");
            Console.WriteLine("Trying to deposit $5000.00 to the following account");
            Console.WriteLine(Bank.AccountList[2].ToString());

            try
            {
                Bank.AccountList[2].Deposit(5000.00);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"{new string('-', 90)}");

            Console.WriteLine($"{new string('-', 90)}");
            Console.WriteLine("Trying to deposit $7300.00 to the following account");
            Console.WriteLine(Bank.AccountList[3].ToString());

            
            
                Bank.AccountList[3].Deposit(7300.90);
            
          
            
                
            

            Console.WriteLine($"{new string('-', 90)}");

            Console.WriteLine($"{new string('-', 90)}");
            Console.WriteLine("Trying to withdraw $45000.40 from the following account");
            Console.WriteLine(Bank.AccountList[4].ToString());

            try
            {
                Bank.AccountList[4].Withdraw(45000.40);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"{new string('-', 90)}");

            Console.WriteLine($"{new string('-', 90)}");
            Console.WriteLine("Trying to withdraw $37000.00 from the following account");
            Console.WriteLine(Bank.AccountList[5].ToString());
            try
            {
                Bank.AccountList[5].Withdraw(37000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"{new string('-', 90)}");

            Console.WriteLine($"{new string('-', 90)}");
            try
            {
                Bank.ShowAll(67676767);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"{new string('-', 90)}");

            Bank.ShowAll();

        }

    }
    class Consumer
    {
        public string ID { get; }
        public string Name { get; }

        public Consumer(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"Consumer ID: {ID}, Name: {Name}    ";
        }
    }
    abstract class Account : Consumer
    {
        public int AccountNum { get; }

        public Account(string id, string name, int accountnum) : base(id, name)
        {
            this.AccountNum = accountnum;
        }

        public abstract void Withdraw(double amount);
        public abstract void Deposit(double amount);

        public override string ToString()
        {
            return base.ToString() + $"Account Number: {AccountNum} ";
        }
    }

    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException() : base() { }
        public override string Message
        {
            get
            {
                return "Account not having enough balance to withdraw.";

            }
        }
    }

    class MinimumBalanceException : Exception
    {
        public MinimumBalanceException() : base() { }

        public override string Message
        {
            get
            {
                return "You must maintain a minimum $3000 balance in Saving account.";
            }
        }

    }

    class IncorrectAmountException : Exception
    {
        public IncorrectAmountException() : base() { }

        public override string Message
        {
            get
            {
                return "You must provide positive number for amount to be deposited.";
            }
        }
    }

    class OverdraftLimitException : Exception
    {
        public OverdraftLimitException() : base() { }

        public override string Message
        {
            get
            {
                return "Overdraft Limit exceeded. You can only use $2000 from overdraft.";
            }
        }
    }

    class AccountNotFoundException : Exception
    {
        public AccountNotFoundException() : base() { }

        public override string Message
        {
            get
            {
                return "Account with given number does not exist.";
            }
        }
    }

    class SavingsAccount : Account
    {
        public double Balance { get; set; }

        public SavingsAccount(string id, string name, int accountnum, double balance) : base(id, name, accountnum)
        {
            this.Balance = balance;
        }

        public override void Withdraw(double amount)
        {
            if (amount < Balance)
            {
                if (Balance - amount >= 3000)
                {
                    Balance -= amount;
                    Console.WriteLine($"Withdraw of {amount:c} to {AccountNum} Successful!");
                    Console.WriteLine($"Your new balance is: {Balance:c}");
                }
                else
                {
                    throw new MinimumBalanceException();
                }
            }
            else
            {
                throw new InsufficientBalanceException();
            }
        }
        public override void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposit of {amount:c} to {AccountNum} Successful!");
                Console.WriteLine($"Your new balance is: {Balance:c}");
            }
            else
            {
                throw new IncorrectAmountException();
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Balance: {Balance:c}";
        }
    }

    class ChequingAccount : Account
    {
        public double Balance { get; set; }

        public ChequingAccount(string id, string name, int accountnum, double balance) : base(id, name, accountnum)
        {
            this.Balance = balance;
        }

         public override void Withdraw(double amount)
        {
            if (amount <= Balance + 2000)
            {
                Balance -= amount;
                Console.WriteLine($"Withdraw of {amount:c} to {AccountNum} Successful!");
                Console.WriteLine($"Your new balance is: {Balance:c}");
            }
            else
            {
                throw new OverdraftLimitException();
            }
        }
        public override void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposit of {amount:c} to {AccountNum} Succsessful!");
                Console.WriteLine($"Your new balance is: {Balance:c}");
            }
            else
            {
                throw new IncorrectAmountException();
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Balance: {Balance:c}";
        }
    }

    class Bank
    {
        public static List<Account> AccountList = new List<Account>();

        static Bank()
        {
            AccountList.Add(new SavingsAccount("S101", "James Finch",
            222210212, 3400.90));
            AccountList.Add(new SavingsAccount("S102", "Kell Forest",
            222214500, 42520.32));
            AccountList.Add(new SavingsAccount("S103", "Amy Stone",
            222212000, 8273.45));
            AccountList.Add(new ChequingAccount("C104", "Kaitlin Ross",
            333315002, 91230.45));
            AccountList.Add(new ChequingAccount("C105", "Adem First",
            333303019, 43987.67));
            AccountList.Add(new ChequingAccount("C106", "John Doe",
            333358927, 34829.76));
        }

        public static void ShowAll()
        {
            foreach (Account account in AccountList)
            {
                Console.WriteLine(account.ToString());
            }
        }

        public static void ShowAll(int accountNum)
        {
            bool accountFound = false;
            Console.WriteLine($"Details of Account number: {accountNum}");
            foreach (Account account in AccountList)
            {
                if (accountNum == account.AccountNum)
                {
                    Console.WriteLine(account.ToString());
                    accountFound = true;
                    break;
                }
            }

            if (!accountFound)
            {
                throw new AccountNotFoundException();
            }
        }
    }
}
    