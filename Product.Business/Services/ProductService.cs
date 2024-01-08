using Product.Business.Interfaces;
using Product.Business.Utilities.Exceptions;
using Product.Core.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Product.Business.Services;

public class ProductService : IProductService
{
    public void CreateProduct(int productId, string productName, decimal productPrice)
    {
        if (productId < 0) throw new InvalidIdException("Invalid ID has been entered for product.");
        if (string.IsNullOrEmpty(productName)) throw new ArgumentNullException();
        if (productPrice < 0) throw new InvalidPriceException("Invalid price has been entered for product.");
        Core.Entities.Product product = new Core.Entities.Product(productId,productName,productPrice);
        Directory.CreateDirectory(@".\DataBase");
        if (!File.Exists(@".\DataBase\database.txt"))
        {
            File.Create(@".\DataBase\database.txt");
        }
        StreamWriter sw = new StreamWriter(@".\DataBase\database.txt",true);
        sw.WriteLine($"Id: {product.Id}; Name: {product.Name}; Price: {product.Price}");
        sw.Close();
    }

    public void ShowAll()
    {
        StreamReader sr = new StreamReader(@".\DataBase\database.txt");
        while (!sr.EndOfStream) 
        {
            Console.WriteLine(sr.ReadLine());
        }
        sr.Close();
    }
}
