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
    /// Логика взаимодействия для MainMenuPageForServiceStaff.xaml
    /// </summary>
    public partial class MainMenuPageForServiceStaff : Page
    {
        public static List<Worker> workers { get; set; }
        public static Worker loggedWorker;

        public MainMenuPageForServiceStaff()
        {
            InitializeComponent();
            loggedWorker = DBConnection.loginedWorker;
            UserTB.Text = DBConnection.loginedWorker.Surname.ToString() + " " + DBConnection.loginedWorker.Name.ToString() + " " + DBConnection.loginedWorker.Patronymic.ToString();
            LoginTB.Text = DBConnection.loginedWorker.Login;
        }

        private void TasksBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TasksPage());
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
