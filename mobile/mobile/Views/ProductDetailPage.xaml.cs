using mobile.Models;
using mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        ProductDetailViewModel viewModel;
        public ProductDetailPage(ProductDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext  = this.viewModel = viewModel;
        }
        public ProductDetailPage()
        {
            InitializeComponent();

            var product = new Product
            {
                Name = "Item 1",
                Details = "This is an item description."
            };

            viewModel = new ProductDetailViewModel(product);
            BindingContext = viewModel;
        }
    }
}