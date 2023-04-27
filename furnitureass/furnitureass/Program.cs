using System.Diagnostics;
using System.Drawing;
using System.Timers;

namespace furnitureass
{
    class Furniture
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public virtual void Accept()
        {
            Console.WriteLine("Enter furniture details:");
            Console.WriteLine("Enter Height: ");
            Height = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Width: ");
            Width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter color");
            Color = Console.ReadLine();
            Console.WriteLine(" Enter Quantity: ");
            Quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Price: ");
            Price = Convert.ToDouble(Console.ReadLine());
        }

        public virtual void Display()
        {
            Console.WriteLine($"Height: {Height}");
            Console.WriteLine($"Width: {Width}");
            Console.WriteLine($"Colour: {Color}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Price: {Price}");
        }
    }

    class Bookshelf : Furniture
    {
        public int NoofShelves { get; set; }

        public override void Accept()
        {
            base.Accept();
            Console.Write("Number of shelves: ");
            NoofShelves = Convert.ToInt32(Console.ReadLine());
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Number of shelves: {NoofShelves}");
        }
    }

    class DiningTable : Furniture
    {
        public int NoofLegs { get; set; }

        public override void Accept()
        {
            base.Accept();
            Console.Write("Number of legs: ");
            NoofLegs = Convert.ToInt32(Console.ReadLine());
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Number of legs: {NoofLegs}");
        }
    }

    class Program
    {
        static int AddToStock(Furniture[] stock)
        {
            Console.WriteLine("Adding furniture to stock:");
            int count = 0;
            while (count < stock.Length)
            {
                Console.Write($"Enter item {count + 1} (1 for Bookshelf, 2 for Dining Table): ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        stock[count] = new Bookshelf();
                        break;
                    case 2:
                        stock[count] = new DiningTable();
                        break;
                    default:
                        Console.WriteLine("Invalid choice .please enter correct choice");
                        continue;
                }
                stock[count].Accept();
                count++;
            }
            Console.WriteLine("Stock added successfully.");
            return count;
        }

        static double TotalStockValue(Furniture[] stock)
        {
            double totalValue = 0;
            foreach (Furniture fun in stock)
            {
                totalValue += fun.Quantity * fun.Price;
            }
            return totalValue;
        }

        static void ShowStockDetails(Furniture[] stock)
        {
            Console.WriteLine("Showing furniture stock details:");
            foreach (Furniture item in stock)
            {
                item.Display();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter how many furniture do you want");
            int n=Convert.ToInt32(Console.ReadLine());
            Furniture[] stock = new Furniture[n];
            int numItems = AddToStock(stock);
            ShowStockDetails(stock);
            double totalValue = TotalStockValue(stock);
            Console.WriteLine($"Total stock value {totalValue}");
        }
    }
}