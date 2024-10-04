using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for foglalasPopup.xaml
    /// </summary>
    public partial class foglalasPopup : Window
    {
        Foglalas ujFoglalas = new Foglalas();
        s

        public foglalasPopup()
        {
            InitializeComponent();
            string connectionString = "Server=localhost; Database=szepsegek; UserID=root; Password=; Allow User Variables=true;";

            // Execute the SQL query and bind the results to the ComboBox
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM szolgaltatas", connection);
                MySqlDataReader reader = command.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);

                cbxSzolgaltatas.ItemsSource = table.DefaultView;
                cbxSzolgaltatas.DisplayMemberPath = "SzolgaltatasKategoria";

                reader.Close();
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM dolgozo", connection);
                MySqlDataReader reader = command.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);

                cbxSzolgaltatas.ItemsSource = table.DefaultView;
                cbxSzolgaltatas.DisplayMemberPath = "DolgozoKeresztNev";

                reader.Close();
            }
        }

        private void cbxSzolgaltatas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbxSzolgaltatas.SelectedItem;
            string value = (string)selectedItem.Tag;
            string text = (string)selectedItem.Content;

            
        }

        private void cbxDolgozo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbxSzolgaltatas.SelectedItem;
            string value = (string)selectedItem.Tag;
            string text = (string)selectedItem.Content;

            // Do something with the selected value and text
        }
    }
}
