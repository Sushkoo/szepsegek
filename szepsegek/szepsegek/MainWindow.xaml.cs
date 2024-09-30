using System.Collections.ObjectModel;
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
        public ObservableCollection<Ugyfel> Ugyfelek { get; set; }
        public MainWindow()
        {
            Ugyfelek = new ObservableCollection<Ugyfel>();
            DataContext = this;
            InitializeComponent();
        }

        private void btnUgyfelFelvetel_Click(object sender, RoutedEventArgs e)
        {
            popupAddElement.IsOpen = true;
        }

        int IDindex = 0;
        private void btnAddElement_Click(object sender, RoutedEventArgs e)
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
}