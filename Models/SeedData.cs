using Microsoft.EntityFrameworkCore;

namespace Shop.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ShopDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ShopDbContext>();

            if (context.Database.GetMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name="Kajak", Description="Rodzaj obiektu do pływania", Category="Woda", Price=1300 },
                    new Product { Name="Łódź", Description="Rodzaj obiektu do pływania", Category="Woda", Price=67000 },
                    new Product { Name="Wiosła", Description="Rodzaj obiektu do pływania", Category="Woda", Price=300 },
                    new Product { Name="Szybowiec", Description="Rodzaj obiektu do latania", Category="Powietrze", Price=21300 },
                    new Product { Name="Spadochron", Description="Rodzaj obiektu do latania", Category="Powietrze", Price=1300 },
                    new Product { Name="Motocykl", Description="Rodzaj obiektu do jeżdżenia", Category="Ziemia", Price=22300 },
                    new Product { Name="Rower górski", Description="Rodzaj obiektu do jeżdżenia", Category="Ziemia", Price=7300 },
                    new Product { Name="Rwoer szosowy", Description="Rodzaj obiektu do jeżdżenia", Category="Ziemia", Price=9200 }
                    );
            }
            context.SaveChanges();
        }
    }
}
