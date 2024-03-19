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
    /// Логика взаимодействия для TasksPage.xaml
    /// </summary>
    public partial class TasksPage : Page
    {
        public static Taskk taskk { get; set; }
        public static List<Taskk> tasks { get; set; }
        public static List<Status> statuses { get; set; }

        //Worker loggedWorker;

        public TasksPage()
        {
            InitializeComponent();
            //loggedWorker = DBConnection.loginedWorker;
            tasks = DBConnection.circusDB.Taskk.Where(i => i.ID_ServiceStaff == DBConnection.loginedWorker.ID).ToList();
            this.DataContext = this;
        }

        private void Refresh()
        {
            TasksLV.ItemsSource = DBConnection.circusDB.Taskk.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (TasksLV.SelectedItem is Taskk task)
            {
                DBConnection.selectedForEditTask = TasksLV.SelectedItem as Taskk;
                EditTaskStatusWindow editTaskStatusWindow = new EditTaskStatusWindow(task);
                editTaskStatusWindow.ShowDialog();
            }
            else if (TasksLV.SelectedItem is null)
            {
                MessageBox.Show("Выберите задачу!");
            }
            Refresh();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPageForArtist());
        }
    }
}
