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
    /// Логика взаимодействия для TimetableForAnimalsPage.xaml
    /// </summary>
    public partial class TimetableForAnimalsPage : Page
    {
        public static List<Worker> workers { get; set; }
        public static Worker loggedWorker;

        public TimetableForAnimalsPage()
        {
            InitializeComponent();
            loggedWorker = DBConnection.loginedWorker;
            workers = DBConnection.circusDB.Worker.ToList();
            this.DataContext = this;
            Refresh();
        }

        private void Refresh()
        {
            TimetablesLV.ItemsSource = DBConnection.circusDB.Worker.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (TimetablesLV.SelectedItem is Worker worker)
            {
                DBConnection.selectedForEditWorker = TimetablesLV.SelectedItem as Worker;
                EditTimetableForAnimalWindow editTimetableForAnimalWindow = new EditTimetableForAnimalWindow();
                editTimetableForAnimalWindow.ShowDialog();
            }
            else if (TimetablesLV.SelectedItem is null)
            {
                MessageBox.Show("Выберите расписание!");
            }
            Refresh();
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            AddTimetableForAnimalWindow addTimetableForAnimalWindow = new AddTimetableForAnimalWindow();
            addTimetableForAnimalWindow.ShowDialog();
        }

        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            if (TimetablesLV.SelectedItem is Worker work)
            {
                DBConnection.circusDB.Worker.Remove(work);
                DBConnection.circusDB.SaveChanges();
            }
            else if (TimetablesLV.SelectedItem is null)
            {
                MessageBox.Show("Выберите расписание!");
            }
            Refresh();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPageForTrainer());
        }
    }
}
