using AutumnStore.Data.Model;
using System.Collections.Generic;

namespace AutumnStore.Data.Helpers.Seed
{
    internal static class CategorySeed
    {
        internal static IEnumerable<Category> PopulateCategoryList()
        {
            return new List<Category>()
            {
                 AddNewCategory(1,"Category1"),
                 AddNewCategory(2,"Category2")
            };
        }

        public static Category AddNewCategory(int categoryId, string categoryName)
        {
            return new Category()
            {
                CategoryId = categoryId,
                CategoryName = categoryName
            };
        }
    }
}
