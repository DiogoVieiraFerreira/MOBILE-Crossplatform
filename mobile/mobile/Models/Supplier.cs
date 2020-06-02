using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace mobile.Models
{
    public class Supplier
    {
        public string CompanyName { get; protected set; }
        public string City { get; protected set; }
        public int Id { get; protected set; }

        public static List<Supplier> Suppliers(JArray jsonArray)
        {
            List<Supplier> suppliers = new List<Supplier>();

            foreach(JObject data in jsonArray)
            {
                suppliers.Add(new Supplier() { 
                    CompanyName = data["company_name"].ToString(),
                    City = data["city"].ToString(),
                    Id = int.Parse(data["pivot"]["supplier_id"].ToString())
                });
            }
           
            return suppliers;
        }
    }
}
