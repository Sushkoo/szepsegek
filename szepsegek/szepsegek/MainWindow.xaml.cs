using System.Collections.ObjectModel;
using System.Windows;

namespace szepsegek
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Ugyfel> Ugyfelek { get; set; }
        private int IDindex = 0;

        public MainWindow()
        {
            Ugyfelek = new ObservableCollection<Ugyfel>();
            DataContext = this;
            InitializeComponent();
        }

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
                btnUgyfelFelvetel.Visibility = Visibility.Visible;
                ActionButtons.Visibility = Visibility.Visible;
            }
        }

        private void btnUgyfelFelvetel_Click(object sender, RoutedEventArgs e)
        {
            popupAddElement.IsOpen = true;
        }

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

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            // Show the add customer popup
            popupAddElement.IsOpen = true;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Edit clicked!");
            // Add logic for editing items
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Remove clicked!");
            // Add logic for removing items
        }
    }
}
