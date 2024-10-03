using System.Collections.ObjectModel;
using System.Windows;
using System.Data.SqlClient;
using MySqlConnector;

namespace szepsegek
{
    public partial class MainWindow : Window
    {


        public ObservableCollection<Ugyfel> Ugyfelek;
        private int IDindex = 0;

        public MainWindow()
        {
            Ugyfelek = new ObservableCollection<Ugyfel>();
            DataContext = this;
            string connectionString = "Server=localhost; Database=szepsegek; UserID=root; Password=;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            InitializeComponent();
        }//Nagy kristóf buzi

    private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var loginPopup = new LoginPopup();
            var popupWindow = new Window
            {
                Title = "Login",
                Content = loginPopup,
                SizeToContent = SizeToContent.WidthAndHeight,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            // Show the login window and wait for the dialog result
            if (popupWindow.ShowDialog() == true) // We will set this true on successful login
            {
                // Show action buttons and hide login button
                btnLogin.Visibility = Visibility.Collapsed;
                dtgUgyfelek.Visibility = Visibility.Visible;
                btnUgyfelFelvetel.Visibility = Visibility.Visible;
                btnEdit.Visibility = Visibility.Visible;
                btnRemove.Visibility = Visibility.Visible;
            }
        }

        private void btnUgyfelFelvetel_Click(object sender, RoutedEventArgs e)
        {
            popupAddElement.IsOpen = true;
        }

        private void btnAddElement_Click(object sender, RoutedEventArgs e)
        {
            if (txtNev.Text.Length == 0 || txtTelefon.Text.Length == 0 || txtEmail.Text.Length == 0)
            {
                MessageBox.Show("Hibás adat(ok)!");
            }
            else
            {
                Ugyfel ujUgyfel = new Ugyfel
                {
                    UgyfelID = IDindex,
                    UgyfelNev = txtNev.Text,
                    UgyfelTelefon = txtTelefon.Text,
                    UgyfelEmail = txtEmail.Text
                };
                Ugyfelek.Add(ujUgyfel);
                IDindex++;

                popupAddElement.IsOpen = false;
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (dtgUgyfelek.IsReadOnly == true)
            {
                dtgUgyfelek.IsReadOnly = false;
                btnEdit.Content = "Szerkesztés vége";
                MessageBox.Show("Mostmár szerkeszthetőek az adatok!");
            }
            else
            {
                dtgUgyfelek.IsReadOnly = true;
                btnEdit.Content = "Szerkesztés";
                MessageBox.Show("Szerkesztés befejezve!");
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (dtgUgyfelek.SelectedItem is Ugyfel selectedUgyfel)
            {
                Ugyfelek.Remove(selectedUgyfel);
            }
            else
            {
                MessageBox.Show("Válassza ki a törölni kívánt ügyfelet!");
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var registerPopup = new RegisterPopup();
            var popupWindow = new Window
            {
                Title = "Login",
                Content = registerPopup,
                SizeToContent = SizeToContent.WidthAndHeight,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            // Show the login window and wait for the dialog result
            if (popupWindow.ShowDialog() == true) // We will set this true on successful login
            {
                // Show action buttons and hide login button
                btnLogin.Visibility = Visibility.Collapsed;
                btnRegister.Visibility = Visibility.Collapsed;
                dtgUgyfelek.Visibility = Visibility.Visible;
                btnUgyfelFelvetel.Visibility = Visibility.Visible;
                btnEdit.Visibility = Visibility.Visible;
                btnRemove.Visibility = Visibility.Visible;
            }

            string connectionString = "Server=localhost;Database=mydatabase;UserID=myusername;Password=mypassword;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                foreach (Ugyfel item in Ugyfelek)
                {
                    string query = "INSERT INTO Ugyfelek (UgyfelNev, UgyfelTelefon, UgyfelEmail) VALUES (@UgyfelNev, @UgyfelTelefon, @UgyfelEmail)";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    command.Parameters.AddWithValue("@column2", item.UgyfelNev);
                    command.Parameters.AddWithValue("@column3", item.UgyfelTelefon);
                    command.Parameters.AddWithValue("@column3", item.UgyfelEmail);

                    int affectedRows = command.ExecuteNonQuery();

                    Console.WriteLine("Inserted " + affectedRows + " row(s)");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
