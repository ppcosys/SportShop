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
                    new Product { Name="Buty do biegania", Description="Buty trenigowe do biegania", Category="Bieganie", Price=300 },
                    new Product { Name="Koszulka", Description="Koszulka do biegania", Category="Bieganie", Price=67000 },
                    new Product { Name="Spodenki", Description="Spodenki do biegania", Category="Bieganie", Price=300 },
                    new Product { Name="Narty", Description="Narty zjazdowe", Category="Narciarstwo", Price=840 },
                    new Product { Name="Kije narciarskie", Description= "Kije do narciarstwa zjazdowego", Category="Narciarstwo", Price=150 },
                    new Product { Name="Rower szosowy", Description= "Rower do jazdy na twardej drodze", Category="Kolarstwo", Price=8300 },
                    new Product { Name="Rower górski", Description="Rower przeznaczony do jazdy w terenie", Category="Kolarstwo", Price=6200 },
                    new Product { Name="Lampka rowerowa", Description="Lampka rowerowa oświetlająca drogę", Category="Kolarstwo", Price=120 }
                    );
            }
            context.SaveChanges();
        }
    }
}
