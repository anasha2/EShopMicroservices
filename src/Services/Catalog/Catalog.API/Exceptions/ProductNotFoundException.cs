


public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(Guid Id) : base("Product not found")
    {
    }
}