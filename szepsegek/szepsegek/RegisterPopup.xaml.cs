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
        List<User> felhasznalok = new List<User>();
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

            int lastid = felhasznalok.Select(x => x.UserID).Last();
            felhasznalo.UserID = lastid + 1;

            // Simple validation example
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return; // Exit if either field is empty
            }

            if (username == "admin" && password == "password")
            {
                MessageBox.Show("Login successful!");

                // Find the parent window and set the dialog result
                Window parentWindow = Window.GetWindow(this);
                if (parentWindow != null)
                {
                    parentWindow.DialogResult = true; // Set dialog result to true
                    parentWindow.Close(); // Close the popup window
                }
                else
                {
                    // Handle the case where no parent window is found
                    MessageBox.Show("No parent window found.");
                }
            }
        }
    }   
}
