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
        public static List<Perfomance> perfomances { get; set; }

        //Worker loggedWorker;

        public TimetablePage()
        {
            InitializeComponent();
            //loggedWorker = DBConnection.loginedWorker;
            timetables = DBConnection.circusDB.Timetable.Where(i => i.ID_Artist == DBConnection.loginedWorker.ID).ToList();
            perfomances = DBConnection.circusDB.Perfomance.ToList();

            this.DataContext = this;
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
