﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class Product
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "details")]
        public string Details { get; set; }
        [JsonProperty(PropertyName = "unit")]
        public string Unit { get; set; }
        [JsonProperty(PropertyName = "stock")]
        public double Stock { get; set; }
        [JsonProperty(PropertyName = "picture")]
        public string Picture { get; set; }
        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }
        [JsonProperty(PropertyName = "current")]
        public bool Current { get; set; } // Tells if the product is currently on sale
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty(PropertyName = "suppliers")]
        public object Suppliers { get; set; }// TODO : method to deserialize json array and get informations with api

    }
}