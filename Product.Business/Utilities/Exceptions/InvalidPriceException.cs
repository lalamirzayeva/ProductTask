namespace Product.Business.Utilities.Exceptions;

public class InvalidPriceException:Exception
{
    public InvalidPriceException(string message) : base(message) { }
}
