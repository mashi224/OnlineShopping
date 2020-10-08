using AutumnStore.Data.Model;
using System.Collections.Generic;

namespace AutumnStore.Data.Helpers.Seed
{
    internal static class ProductSeed
    {
        internal static IEnumerable<Products> PopulateProductList()
        {
            return new List<Products>()
            {
                 AddNewProducts(1,1,"Product1"),
                 AddNewProducts(1,2,"Product2"),
                 AddNewProducts(2,3,"Product3")
            };
        }

        public static Products AddNewProducts(int categoryId, int productId, string productName)
        {
            return new Products()
            {
                CategoryId = categoryId,
                ProductId = productId,
                ProductName = productName
            };
        }

    }
}
