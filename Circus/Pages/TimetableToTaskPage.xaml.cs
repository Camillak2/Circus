using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Circus.DB;

namespace Circus.Pages
{
    /// <summary>
    /// Логика взаимодействия для TimetableToTaskPage.xaml
    /// </summary>
    public partial class TimetableToTaskPage : Page
    {
        public static List<Applicationn> applicationns { get; set; }
        public static List<Status> statuses { get; set; }
        public static List<Worker> artists { get; set; }

        public TimetableToTaskPage()
        {
            InitializeComponent();

            InitializeComponent();
            applicationns = DBConnection.circusDB.Applicationn.ToList();
            statuses = DBConnection.circusDB.Status.ToList();
            artists = DBConnection.circusDB.Worker.ToList();

            this.DataContext = this;

            Refresh();
        }

        private void Refresh()
        {
            ApplicationsLV.ItemsSource = DBConnection.circusDB.Applicationn.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            if (ApplicationsLV.SelectedItem is Applicationn applicationn)
            {
                DBConnection.circusDB.Applicationn.Remove(applicationn);
                DBConnection.circusDB.SaveChanges();
            }
            else if (ApplicationsLV.SelectedItem is null)
            {
                MessageBox.Show("Выберите заявку!");
            }
            Refresh();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminToArtistPage());
        }
    }
}
