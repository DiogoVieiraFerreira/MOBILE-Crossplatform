﻿using mobile.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        string server;
        public string Url { get; protected set; }
        Uri uri;
        User user;
        public ProductsPage()
        {
            InitializeComponent();

            server = "192.168.1.103";
            Url = string.Format(@"http://{0}/", server);
            uri = new Uri(Url);

            Title = "Liste d'articles";
            user = (User)Application.Current.Properties["user"];            
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            List<Product> p = await GetProductsAsync(user.Token);
            
            Products.ItemsSource = p;
        }

        private async Task<List<Product>> GetProductsAsync(string token)
        {
            var client = new HttpClient();
            List<Product> products = null;

            client.BaseAddress = uri;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync("/api/products");

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                JObject jsonResponse = JObject.Parse(content);
                string data = jsonResponse["data"].ToString();//get json on data, because api is very good
                products = JsonConvert.DeserializeObject<List<Product>>(data);
            }

            return products;
        }
    }
}