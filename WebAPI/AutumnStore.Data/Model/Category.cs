using System.ComponentModel.DataAnnotations;

namespace AutumnStore.Data.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
    }
}
