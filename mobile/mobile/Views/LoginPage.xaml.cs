using mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace mobile.Views
{
    public partial class LoginPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "token");
        public LoginPage()
        {
            InitializeComponent();
            if (File.Exists(_fileName))
            {
                string token = File.ReadAllText(_fileName);
            }
        }

        private void Button_Register(object sender, EventArgs e)
        {
            bool isValid = User.CheckInformations(FirstName.Text, LastName.Text, PhoneNumber.Text);

            if(!isValid)
            {
                DisplayAlert("Incomplet form", "Please complete all fields", "OK...");
                return;
            }
            User user = new User(FirstName.Text, LastName.Text, PhoneNumber.Text);
            DisplayAlert("Your user is:", $"Firstname : {user.Firstname}\nLastname : {user.Lastname}\nPhone number : {user.PhoneNumber}", "I confirm", "I cancel...");
            httpTest();
        }

        private void Button_Login(object sender, EventArgs e)
        {

        }

        private async void httpTest()
        {
            string server = "localhost:8000";
            var request = HttpWebRequest.Create(string.Format(@"https://{0}/user/apply", server));
            request.ContentType = "application/json";
            request.Method = "POST";

            var client = new System.Net.Http.HttpClient();
            var jsonRequest = new { firstname = "diogo", lastname = "vieira", phonenumber = "0123456789" };
            var json = JsonConvert.SerializeObject(jsonRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            var response = await client.PostAsync(new Uri("http://localhost:8000/api/user/apply"), content);
            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("success form", "yet", "OK...");
            }
            else
                await DisplayAlert("nul form", "nul!", "OK...");
        }
    }
}