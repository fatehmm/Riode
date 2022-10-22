using Riode.Models;

namespace Riode.ViewModels
{
    public class ShopAndFilterVM
    {
        public List<int> CategoryIds { get; set; }
        public List<int> VendorIds { get; set; }
        public int MaxPrice { get; set; }
        public int MinPrice { get; set; }


    }
}
