using Riode.Models;

namespace Riode.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders{ get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
