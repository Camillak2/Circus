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
        public ApplicationsPage()
        {
            InitializeComponent();
        }

        private void ApplicationBTN_Click(object sender, RoutedEventArgs e)
        {
            AddApplicationWindow addApplicationWindow = new AddApplicationWindow();
            addApplicationWindow.ShowDialog();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TimetablePage());
        }
    }
}
