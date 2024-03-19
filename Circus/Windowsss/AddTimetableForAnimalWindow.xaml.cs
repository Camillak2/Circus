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
using System.Windows.Shapes;

namespace Circus.Windowsss
{
    /// <summary>
    /// Логика взаимодействия для AddTimetableForAnimalWindow.xaml
    /// </summary>
    public partial class AddTimetableForAnimalWindow : Window
    {
        public static List<TimetableForAnimal> timetableForAnimals { get; set; }
        public static List<Animal> animals { get; set; }
        public static List<Status> statuses { get; set; }
        public static List<AnimalType> animalTypes { get; set; }

        public static TimetableForAnimal timetableForAnimal = new TimetableForAnimal();

        public AddTimetableForAnimalWindow()
        {
            InitializeComponent();
            timetableForAnimals = DBConnection.circusDB.TimetableForAnimal.ToList();
            animals = DBConnection.circusDB.Animal.ToList();
            statuses = DBConnection.circusDB.Status.ToList();
            animalTypes = DBConnection.circusDB.AnimalType.ToList();

            this.DataContext = this;
        }

        private void AddBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrWhiteSpace(DescriptionTB.Text) || string.IsNullOrWhiteSpace(TimeTB.Text) ||
                    string.IsNullOrWhiteSpace(AnimalCB.Text) || DateDP.SelectedDate == null ||
                    string.IsNullOrWhiteSpace(StatusCB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                if (DateDP.SelectedDate != null && (DateTime.Now - (DateTime)DateDP.SelectedDate).TotalDays > 0)
                {
                    error.AppendLine("Выберите корректную дату.");
                }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    timetableForAnimal.Description = DescriptionTB.Text.Trim();
                    timetableForAnimal.Time = TimeTB.Text.Trim();
                    timetableForAnimal.Date = DateDP.SelectedDate;
                    var a = AnimalCB.SelectedItem as Animal;
                    timetableForAnimal.ID_Animal = a.ID;

                    var b = StatusCB.SelectedItem as Status;
                    timetableForAnimal.ID_Status = b.ID;

                    DBConnection.circusDB.TimetableForAnimal.Add(timetableForAnimal);
                    DBConnection.circusDB.SaveChanges();
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
