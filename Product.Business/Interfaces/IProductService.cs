namespace Product.Business.Interfaces;

public interface IProductService
{
    public void CreateProduct(string productName, decimal productPrice);
    public void ShowAll();
}
