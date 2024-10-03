using System.Windows;
using System.Windows.Controls;

namespace szepsegek
{
    public partial class LoginPopup : UserControl
    {
        public LoginPopup()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

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
            }

         


            else
            {
                MessageBox.Show("Invalid credentials.");
            }
        }
    }
}
