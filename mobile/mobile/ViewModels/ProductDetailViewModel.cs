using mobile.Models;

namespace mobile.ViewModels
{
    public class ProductDetailViewModel : BaseViewModel
    {
        public Product Product { get; set; }
        public ProductDetailViewModel(Product product = null)
        {
            Title = product?.Name;
            this.Product = product;
        }
    }
}
