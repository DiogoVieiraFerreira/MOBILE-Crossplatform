using mobile.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobile.Views
{
    public partial class LoginPage : ContentPage
    {
        private string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "token");
        string server;
        string url;
        Uri uri;
        public LoginPage()
        {
            InitializeComponent();
            if (File.Exists(_fileName))
            {
                string token = File.ReadAllText(_fileName);
                Token.Text = token;
            }

            server = "192.168.1.103";
            url = string.Format(@"http://{0}/", server);
            uri = new Uri(url);
        }

        private void Button_Register(object sender, EventArgs e)
        {
            bool isValid = User.CheckInformations(FirstName.Text, LastName.Text, PhoneNumber.Text);

            if (!isValid)
            {
                DisplayAlert("Incomplet form", "Please complete all fields", "OK...");
                return;
            }
            User user = new User(FirstName.Text, LastName.Text)
            {
                PhoneNumber = PhoneNumber.Text
            };

            _ = SignUp(user); //to put the result to trash 
        }

        private async void Button_LoginAsync(object sender, EventArgs e)
        {
            User user = await SignIn(Token.Text);
            if(user == null)
            {
                await DisplayAlert("Connexion échounée", "Veuillez re-saisir votre token.\nSi le problème persiste, merci de contacter le support.", "OK...");
                return;
            }
            File.WriteAllText(_fileName, Token.Text);
        }

        private async Task SignUp(User user)
        {
            var client = new HttpClient();
            var jsonRequest = new { firstname = user.Firstname, lastname = user.Lastname, phonenumber = user.PhoneNumber };
            var json = JsonConvert.SerializeObject(jsonRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            client.BaseAddress = uri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = await client.PostAsync("/api/user/apply", content);
            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Inscription complète", "Un opérateur du système vous enverra votre code d'accès par l'intermédiare d'un SMS", "Cool Merci", "Ah ok...");
                return;
            }
            await DisplayAlert("Inscription échouée", "Veuillez ressayer plus tard...\nSi le problème persiste, cela signifie que votre numéro de téléphone a déjà été utilisé.\nVeuillez contacter le support.", "OK");
        }

        private async Task<User> SignIn(string token)
        {
            var client = new HttpClient();
            User user = null;

            client.BaseAddress = uri;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await client.GetAsync("/api/me");
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                JObject jsonResponse = JObject.Parse(content);

                var userJson = jsonResponse["data"];//get json on data, because api is very good

                user = new User(userJson["firstname"].ToString(), userJson["lastname"].ToString())
                {
                    ID = int.Parse(userJson["id"].ToString())
                };

            }

            return user;
        }
    }
}