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
        public static List<TimetableForAnimal> timetableForAnimals { get; set; }
        public static List<Animal> animals { get; set; }
        public static List<AnimalType> animalTypes { get; set; }
        public static List<Status> statuses { get; set; }
        public static Animal animal { get; set; }

        Worker loggedWorker;

        public TimetableForAnimalsPage()
        {
            InitializeComponent();
            loggedWorker = DBConnection.loginedWorker;
            animals = DBConnection.circusDB.Animal.ToList();
            statuses = DBConnection.circusDB.Status.ToList();
            timetableForAnimals = DBConnection.circusDB.TimetableForAnimal.Where(i => i.Animal.ID_Trainer == loggedWorker.ID).ToList();
            animalTypes = DBConnection.circusDB.AnimalType.ToList();
            this.DataContext = this;

            Refresh();
        }

        private void Refresh()
        {
            TimetablesLV.ItemsSource = DBConnection.circusDB.TimetableForAnimal.Where(i => i.Animal.ID_Trainer == loggedWorker.ID).ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            if (TimetablesLV.SelectedItem is TimetableForAnimal timetableForAnimals)
            {
                DBConnection.selectedForEditTimetableForAnimal = TimetablesLV.SelectedItem as TimetableForAnimal;
                EditTimetableForAnimalWindow editTimetableForAnimalWindow = new EditTimetableForAnimalWindow(timetableForAnimals);
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
            if (TimetablesLV.SelectedItem is TimetableForAnimal timetableForAnimals)
            {
                DBConnection.circusDB.TimetableForAnimal.Remove(timetableForAnimals);
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
