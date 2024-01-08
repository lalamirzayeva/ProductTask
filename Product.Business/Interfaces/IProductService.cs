namespace Product.Business.Interfaces;

public interface IProductService
{
    public void CreateProduct(int productId, string productName, decimal productPrice);
    public void ShowAll();
}
