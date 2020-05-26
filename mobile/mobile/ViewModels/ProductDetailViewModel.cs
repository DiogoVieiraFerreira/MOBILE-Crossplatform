using Android.Icu.Lang;
using mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
