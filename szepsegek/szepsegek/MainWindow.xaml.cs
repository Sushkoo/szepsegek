using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace szepsegek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnUgyfelFelvetel_Click(object sender, RoutedEventArgs e)
        {
            popupAddElement.IsOpen = true;
        }

        private void btnAddElement_Click(object sender, RoutedEventArgs e)
        {
            // Create a new element with the values entered in the popup
            int IDindex = 0;
            Vendeg ujVendeg = new Vendeg(IDindex,txtNev.Text,txtTelefon.Text);
            

            // Add the new element to the DataGrid
            dtgVendegek.Items.Add(ujVendeg);

            // Close the popup
            popupAddElement.IsOpen = false;
        }
    }
}