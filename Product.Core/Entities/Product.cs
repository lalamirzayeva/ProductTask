using Product.Core.Interfaces;

namespace Product.Core.Entities;

public class Product:IEntity
{
    public int Id { get; }
    private static int _id;
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Product(string name, decimal price)
    {
        Id = _id++;
        Name = name;
        Price = price;
        Directory.CreateDirectory(@".\DataBase");
        if (!File.Exists(@".\DataBase\database.txt"))
        {
            var myFile = File.Create(@".\DataBase\database.txt");
            myFile.Close();
            //File.Create(@".\DataBase\database.txt");
        }
    }
}
