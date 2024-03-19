using Circus.DB;
using Circus.Pages;
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
    /// Логика взаимодействия для EditTimetableForAnimalWindow.xaml
    /// </summary>
    public partial class EditTimetableForAnimalWindow : Window
    {
        public static List <TimetableForAnimal> timetableForAnimals {  get; set; }
        public static List<Animal> animals { get; set; }
        public static List<Status> statuses { get; set; }
        public static List<AnimalType> animalTypes { get; set; }

        TimetableForAnimal contextTimetableForAnimal;

        public EditTimetableForAnimalWindow(TimetableForAnimal forAnimal)
        {
            InitializeComponent();
            contextTimetableForAnimal = forAnimal;
            InitializeDataInPage();
            this.DataContext = this;
        }

        private void InitializeDataInPage()
        {
            animals = DBConnection.circusDB.Animal.ToList();
            statuses = DBConnection.circusDB.Status.ToList();
            timetableForAnimals = DBConnection.circusDB.TimetableForAnimal.ToList();
            this.DataContext = this;
            DescriptionTB.Text = contextTimetableForAnimal.Description;
            TimeTB.Text = contextTimetableForAnimal.Time;
            DateDP.SelectedDate = contextTimetableForAnimal.Date;
            AnimalCB.SelectedIndex = (int)contextTimetableForAnimal.ID_Animal - 1;
            StatusCB.SelectedIndex = (int)contextTimetableForAnimal.ID_Status - 1;
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                TimetableForAnimal timetableForAnimal = contextTimetableForAnimal;
                if (string.IsNullOrWhiteSpace(DescriptionTB.Text) || string.IsNullOrWhiteSpace(TimeTB.Text) ||
                        DateDP.SelectedDate == null || string.IsNullOrWhiteSpace(AnimalCB.Text) ||
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
                    timetableForAnimal.Description = DescriptionTB.Text;
                    timetableForAnimal.Time = TimeTB.Text;
                    timetableForAnimal.Date = DateDP.SelectedDate;
                    timetableForAnimal.ID_Animal = (AnimalCB.SelectedItem as Animal).ID;
                    timetableForAnimal.ID_Status = (StatusCB.SelectedItem as Status).ID;
                    DBConnection.circusDB.SaveChanges();

                    DescriptionTB.Text = String.Empty;
                    DescriptionTB.Text = String.Empty;
                    DateDP = null;
                    AnimalCB.Text = String.Empty;
                    StatusCB.Text = String.Empty;

                    DBConnection.circusDB.SaveChanges();
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
