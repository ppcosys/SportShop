namespace Shop.Models
{
    public interface IShopRepository
    {
        IQueryable<Product> Products { get; }
    }
}
