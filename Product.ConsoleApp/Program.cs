using Product.Business.Services;
using Product.Business.Utilities.Helper;

Console.WriteLine("Product Console App:\n");
ProductService productService = new();
bool runApp = true;
while (runApp)
{
Start:
    Console.WriteLine($"1 - Add product\n" +
                      $"2 - Show all products\n" +
                      $"3 - Exit");
    string? option = Console.ReadLine();
    int optionNumber;
    bool isInt = int.TryParse(option, out optionNumber);
    if (isInt)
    {
        if (optionNumber >= 1 && optionNumber <= 3)
        {
            switch (optionNumber)
            {
                case (int)OptionEnum.CreateProduct:
                    try
                    {
                        Console.WriteLine("Enter ID of the product:");
                        int productId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter product name:");
                        string? productName = Console.ReadLine();
                        Console.WriteLine("Enter product price:");
                        decimal productPrice = Convert.ToDecimal(Console.ReadLine());
                        productService.CreateProduct(productId, productName, productPrice);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Product has been added.");
                        Console.ResetColor();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        goto Start;
                    }
                    break;
                case (int)OptionEnum.ShowAll:
                    try
                    {
                        productService.ShowAll();
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Np product exist to show");
                        Console.ResetColor();
                        goto Start;
                    }
                    break;
                default:
                    runApp = false;
                    break;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Please, enter correct option number.");
            Console.ResetColor();
        }

    }
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Please, enter correct format to choose an option.");
        Console.ResetColor();
    }
    
}





