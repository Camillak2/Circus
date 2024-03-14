using Circus.DB;
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
    /// Логика взаимодействия для TimetablePage.xaml
    /// </summary>
    public partial class TimetablePage : Page
    {
        public static List<Timetable> timetables { get; set; }
        public static Worker loggedWorker;

        public TimetablePage()
        {
            InitializeComponent();
            timetables = DBConnection.circusDB.Timetable.Where(i => i.ID == loggedWorker.ID).ToList();
            this.DataContext = this;
            Refresh();
        }

        private void Refresh()
        {
            TimetablesLV.ItemsSource = DBConnection.circusDB.Timetable.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void ChangeBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ApplicationsPage());
        }
        
        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPageForArtist());
        }
    }
}
