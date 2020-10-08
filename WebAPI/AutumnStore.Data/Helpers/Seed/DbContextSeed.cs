using AutumnStore.Data.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace AutumnStore.Data.Helpers.Seed
{
    public static class DbContextSeed
    {
            public static async Task SeedAsync(DataContext context)
            {
                await SeedCategories(context).ConfigureAwait(false);
                await SeedProducts(context).ConfigureAwait(false);
                await SeedBillingUser(context).ConfigureAwait(false);
            }

            private static async Task SeedCategories(DataContext context)
            {
                if (!context.Category.Any())
                {
                    context.AddRange(CategorySeed.PopulateCategoryList());
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            private static async Task SeedProducts(DataContext context)
            {
                if (!context.Products.Any())
                {
                    context.AddRange(ProductSeed.PopulateProductList());
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            private static async Task SeedBillingUser(DataContext context)
            {
                if (!context.User.Any())
                {
                    context.AddRange(BillingUserSeed.PopulateUser());
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
    }
}
