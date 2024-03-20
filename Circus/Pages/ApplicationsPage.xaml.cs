using Circus.DB;
using Circus.Windowsss;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Circus.Pages
{
    /// <summary>
    /// Логика взаимодействия для ApplicationsPage.xaml
    /// </summary>
    public partial class ApplicationsPage : Page
    {
        public static List<Applicationn> applicationns { get; set; }
        public static List<Status> statuses { get; set; }

        Worker loggedWorker;

        public ApplicationsPage()
        {
            InitializeComponent();
            loggedWorker = DBConnection.loginedWorker;
            applicationns = DBConnection.circusDB.Applicationn.Where(i => i.ID_Artist == loggedWorker.ID).ToList();
            statuses = DBConnection.circusDB.Status.ToList();

            Refresh();
        }

        private void Refresh()
        {
            ApplicationsLV.ItemsSource = DBConnection.circusDB.Applicationn.Where(i => i.ID_Artist == loggedWorker.ID).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            AddApplicationWindow addApplicationWindow = new AddApplicationWindow();
            addApplicationWindow.ShowDialog();
            Refresh();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TimetablePage());
        }
    }
}
