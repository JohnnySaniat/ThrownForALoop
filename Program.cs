using static System.Runtime.InteropServices.JavaScript.JSType;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Football",
        Price = 15.00M,
        Sold = false,
        StockDate = new DateTime(2022, 11, 20),
        ManufactureYear = 2010,
        Condition = 4.2
    },
    new Product()
    {
        Name = "Hockey Stick",
        Price = 12.00M,
        Sold = false,
        StockDate = new DateTime(2021, 10, 21),
        ManufactureYear = 2011,
        Condition = 5.6
    },
    new Product()
    {
        Name = "Frisbee",
        Price = 8.00M,
        Sold = false,
        StockDate = new DateTime(2020, 1, 24),
        ManufactureYear = 2012,
        Condition = 8.8
    },
    new Product()
    {
        Name = "Quench Gum",
        Price = 1.50M,
        Sold = false,
        StockDate = new DateTime(2019, 2, 25),
        ManufactureYear = 2013,
        Condition = 2.3
    },
    new Product()
    {
        Name = "Jock Strap",
        Price = 5.15M,
        Sold = false,
        StockDate = new DateTime(2024, 7, 4),
        ManufactureYear = 2014,
        Condition = 10.0
    }
};

string greeting = @"Welcome to Thrown for a Loop
Your one-stop shop for used sporting equipment" + Environment.NewLine;

Console.WriteLine(greeting);

ViewProductDetails();

void ViewLatestProducts()
{
    // create a new empty List to store the latest products
    List<Product> latestProducts = new List<Product>();
    // Calculate a DateTime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    //loop through the products
    foreach (Product product in products)
    {
        //Add a product to latestProducts if it fits the criteria
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    // print out the latest products to the console 
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine(Environment.NewLine + $"The {latestProducts[i].Name} was recently added to the shop!");
    }
}


void ViewProductDetails()
{
    string choice = null;
    while (choice != "0")
    {
        Console.WriteLine
        (Environment.NewLine + "Choose an option:\n\n" +
                  "0. Exit\n" +
                  "1. View All Products\n" +
                  "2. View Product Details\n" +
                  "3. View Latest Products" + Environment.NewLine);
        choice = Console.ReadLine();
        if (choice == "0")
        {
            Console.WriteLine("Goodbye!");
        }
        else if (choice == "1")
        {
            ListProducts();
        }
        else if (choice == "2")
        {
            ListProducts();
        }
        else if (choice == "3")
        {
            ViewLatestProducts();
        }
    }

}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine(Environment.NewLine + $"Total inventory value: ${totalValue}" + Environment.NewLine);

    Console.WriteLine("Products:");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name} ");
    }

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: " + Environment.NewLine);
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }

    DateTime now = DateTime.Now;
    TimeSpan timeInStock = now - chosenProduct.StockDate;

    Console.WriteLine(Environment.NewLine + @$"You selected: 
{chosenProduct.Name}, which costs ${chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old. 
It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}
Its condition has been rated {chosenProduct.Condition} out of 10.0");
}