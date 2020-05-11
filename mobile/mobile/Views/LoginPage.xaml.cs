using mobile.Models;
using System;
using System.IO;
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
        }

        private void Button_Login(object sender, EventArgs e)
        {

        }
    }
}