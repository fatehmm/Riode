using Riode.Models;

namespace Riode.ViewModels
{
    public class ShopIndexVM
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
