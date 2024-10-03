using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace szepsegek
{
    
    /// <summary>
    /// Interaction logic for RegisterPopup.xaml
    /// </summary>
    public partial class RegisterPopup : UserControl
    {
        public List<User> felhasznalok = new List<User>();
        public RegisterPopup()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            User felhasznalo = new User();



            if (felhasznalok.FindAll(x => x.UserName == felhasznalo.UserName).Count > 0)
            {
                felhasznalo.UserName = username;
            }

            if (felhasznalok.FindAll(x => x.UserPassword == felhasznalo.UserPassword).Count > 0)
            {
                felhasznalo.UserPassword = password;
            }

            Window parentWindow = Window.GetWindow(this);
            

            // Simple validation example
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return; // Exit if either field is empty
            }


            if (felhasznalok.Count() == 0)
            {
                felhasznalo.UserID = 0;
                MessageBox.Show($"Sikeres regisztráció! {felhasznalo.UserID}");

            }
            else
            {
                int lastid = felhasznalok.Select(x => x.UserID).Last();
                felhasznalo.UserID = lastid + 1;
                MessageBox.Show("Sikeres regisztráció!");
            }

            felhasznalok.Add(felhasznalo);

            if (parentWindow != null)
            {
                parentWindow.DialogResult = true;
                parentWindow.Close();
            }


        }
    }   
}
