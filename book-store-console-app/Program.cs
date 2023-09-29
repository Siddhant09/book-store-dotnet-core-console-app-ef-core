// See https://aka.ms/new-console-template for more information
using book_store_console_app;

Methods.Welcome();

string? option = null;

while (true)
{
    Methods.ShowMenu();
    option = Console.ReadLine();
    if (option == "1")
        Methods.GetBooks(null);
    else if (option == "2")
    {
        Console.WriteLine("Please enter ISBN or Title");
        string? keyword = Console.ReadLine();

        while (string.IsNullOrEmpty(keyword))
        {
            Console.WriteLine("Please enter ISBN or Title"); 
            keyword = Console.ReadLine();
        }

        Methods.GetBooks(keyword);
    }
    else if (option == "3")
    {
        Console.WriteLine("**********");
        Console.WriteLine("Thank you!");
        Console.WriteLine("**********");
        Environment.Exit(0);
    }
    else
        Console.WriteLine("Please select a valid option");
}