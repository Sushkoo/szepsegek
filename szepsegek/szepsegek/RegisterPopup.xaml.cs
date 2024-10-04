using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Security.Cryptography;

namespace szepsegek
{

    /// <summary>
    /// Interaction logic for RegisterPopup.xaml
    /// </summary>
    public partial class RegisterPopup : UserControl
    {
        private string connectionString = "Server=localhost; Database=szepsegek; UserID=root; Password=;";

        public RegisterPopup()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;

            string password = PasswordBox.Password;
            

            byte[] salt = GenerateSalt();
            string hashedPassword = HashPassword(password, salt);

            // Step 2: Generate a Salt
            byte[] GenerateSalt()
            {
                using (var rng = new RNGCryptoServiceProvider())
                {
                    var salt = new byte[16];
                    rng.GetBytes(salt);
                    return salt;
                }
            }

            // Step 3: Hash the Password
            // Combine password bytes and salt
            byte[] Combine(byte[] first, byte[] second)
            {
                byte[] result = new byte[first.Length + second.Length];
                Buffer.BlockCopy(first, 0, result, 0, first.Length);
                Buffer.BlockCopy(second, 0, result, first.Length, second.Length);
                return result;
            }

            string HashPassword(string password, byte[] salt)
            {
                using (var sha256 = SHA256.Create())
                {
                    var passwordBytes = Encoding.UTF8.GetBytes(password);
                    var saltedPasswordBytes = Combine(passwordBytes, salt);
                    var hashBytes = sha256.ComputeHash(saltedPasswordBytes);
                    return Convert.ToBase64String(hashBytes);
                }
            }

            // Step 4: Verify the Password
            bool VerifyPassword(string providedPassword, string storedHash, byte[] storedSalt)
            {
                string hashedProvidedPassword = HashPassword(providedPassword, storedSalt);
                return hashedProvidedPassword == storedHash;
            }

            // Simple validation example
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return; // Exit if either field is empty
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE username = @username", connection);
                command.Parameters.AddWithValue("@username", username);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show("Username already exists.");
                    return;
                }

                reader.Close();

                command = new MySqlCommand("INSERT INTO users (username, password, UserJogkor) VALUES (@username, @password, @UserJogkor)", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", hashedPassword);
                command.Parameters.AddWithValue("@UserJogkor", "ugyfel");

                command.ExecuteNonQuery();

                MessageBox.Show("Sikeres regisztráció!");
            }

            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.DialogResult = true;
                parentWindow.Close();
            }
        }
    }
}