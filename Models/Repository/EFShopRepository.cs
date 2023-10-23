namespace Shop.Models
{
    public class EFShopRepository : IShopRepository
    {
        private ShopDbContext context;

        public EFShopRepository(ShopDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Product> Products => context.Products;
    }
}
