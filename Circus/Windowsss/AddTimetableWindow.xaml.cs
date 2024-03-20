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
    /// Логика взаимодействия для AddTimetableWindow.xaml
    /// </summary>
    public partial class AddTimetableWindow : Window
    {
        public static List<Worker> artists { get; set; }
        public static List<Perfomance> perfomances { get; set; }
        public static Perfomance perfomance { get; set; }
        public static List<Timetable> timetables { get; set; }

        public static Timetable timetable = new Timetable();

        public AddTimetableWindow()
        {
            InitializeComponent();

            perfomances = DBConnection.circusDB.Perfomance.ToList();
            artists = DBConnection.circusDB.Worker.Where(i => i.ID_Position == 2).ToList();

            timetables = DBConnection.circusDB.Timetable.ToList();

            this.DataContext = this;
        }

        private void PerfomanceCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PerfomanceCB.SelectedItem != null)
            {
                Perfomance selectedPerformance = PerfomanceCB.SelectedItem as Perfomance;
                StartDateDP.SelectedDate = selectedPerformance.StartDate;

                EndDateDP.SelectedDate = selectedPerformance.EndDate;
            }
        }

        private void AddTimetableBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (ArtistCB.SelectedItem == null || string.IsNullOrWhiteSpace(PerfomanceCB.Text) || string.IsNullOrWhiteSpace(TimeTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                else if (DateDP.SelectedDate < StartDateDP.SelectedDate || DateDP.SelectedDate > EndDateDP.SelectedDate)
                {
                    MessageBox.Show("Выберите правильную дату!");
                }
                else
                {
                    var a = ArtistCB.SelectedItem as Worker;
                    timetable.ID_Artist = a.ID;

                    var b = PerfomanceCB.SelectedItem as Perfomance;
                    timetable.ID_Perfomance = b.ID;

                    timetable.Time = TimeTB.Text.Trim();

                    timetable.Date = DateDP.SelectedDate;

                    DBConnection.circusDB.Timetable.Add(timetable);
                    DBConnection.circusDB.SaveChanges();
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
