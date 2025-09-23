using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_BrandonArgenalAlmanza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestOPP();
        }

        static void TestOPP()
        {
            Dictionary<string, Item> itemDictionary = new Dictionary<string, Item> {
                { "M101", new Movie("M101", "Spongbob", 4.99f, 98) },
                { "M102", new Movie("M102", "Tom and Jerry", 6.99f, 102) },
                { "G101", new Game("G101", "Minecraft", 3.99f, "Energetic Inc", true) },
                { "G102", new Game("G102", "Mario", 7.99f, "Super Inc", false) }};
            
            Console.WriteLine("Student ID - 301467830");
            Console.WriteLine("Name - Brandon Argenal Almanza\n");

            Customer customer1 = new Customer("Brandon");

            Console.WriteLine(customer1.ToString());

            foreach (var item in itemDictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            string input = "";
            while (true)
            {
                Console.Write("\nEnter the ID of the item you want to buy or enter 'none' to stop loop: ");
                input = Console.ReadLine().ToUpper();

                if (input == "NONE")
                    break;

                if (itemDictionary.ContainsKey(input))
                {
                    customer1.Buy(itemDictionary[input]);
                }
                else
                {
                    Console.WriteLine("ID you entered is not available at the store. Please try again.");
                }
            }

            Console.WriteLine($"\n{customer1.Name}'s Purchase List:");
            customer1.ShowItems();

            Console.WriteLine($"\n{customer1.ToString()}");
        }

    }

    class Item
    {
        public string ID { get; }
        public string Title { get; }
        public float Price { get; }

        public Item(string id, string title, float price)
        {
            this.ID = id;
            this.Title = title;
            this.Price = price;
        }
        public override string ToString()
        {
            return $"ID: {ID}, Title {Title}, Price {Price}";
        }
    }

    class Game : Item
    {
        public string Publisher { get; }
        public bool IsMultiplayer { get; }

        public Game(string id, string title, float price, string publisher, bool multiplayer = false) : base(id, title, price)
        {
            this.Publisher = publisher;
            this.IsMultiplayer = multiplayer;
        }

        public override string ToString()
        {
            return base.ToString() + $" Publisher: {Publisher}, IsMultiplayer {IsMultiplayer}";
        }
    }

    class Movie : Item
    {
        public int RunningTime { get; }

        public Movie(string id, string title, float price, int runningtime) : base(id, title, price)
        {
            this.RunningTime = runningtime;
        }

        public override string ToString()
        {
            return base.ToString() + $" Running Time: {RunningTime} minutes";
        }
    }

    class Customer
    {
        public string Name { get; }
        public float Balance { get; set; }
        public List<Item> PurchaseList { get; }

        public Customer(string name, float balance = 15)
        {
            this.Name = name;
            this.Balance = balance;
            PurchaseList = new List<Item>();
        }

        public void Buy(Item item)
        {
            if (Balance > item.Price)
            {
                PurchaseList.Add(item);
                Balance -= item.Price;
                Console.WriteLine($"{item.Title} added to cart. Your remaining balance is {Balance:c}");
            }
            else
            {
                Console.WriteLine($"You do not have sufficient funds in your balance. Current balance is {Balance:c}");
            }
        }

        public void ShowItems()
        {
            if (PurchaseList.Count == 0)
            {
                Console.WriteLine("Your purchase list is empty");
            }
            else
            {
                foreach (Item item in PurchaseList)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Balance: {Balance:c}";
        }   
    }
}
