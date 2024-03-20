using Circus.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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
using static MaterialDesignThemes.Wpf.Theme;

namespace Circus.Windowsss
{
    /// <summary>
    /// Логика взаимодействия для EditTimetableWindow.xaml
    /// </summary>
    public partial class EditTimetableWindow : Window
    {
        public static List<Worker> artists { get; set; }
        public static List<Perfomance> perfomances { get; set; }
        public static List<Timetable> timetables { get; set; }

        Timetable contextTimetable;

        public EditTimetableWindow(Timetable timetable)
        {
            InitializeComponent();
            contextTimetable = timetable;
            InitializeDataInPage();
            this.DataContext = this;
        }

        private void InitializeDataInPage()
        {
            timetables = DBConnection.circusDB.Timetable.ToList();
            perfomances = DBConnection.circusDB.Perfomance.ToList();
            artists = DBConnection.circusDB.Worker.Where(i => i.ID_Position == 2).ToList();
            this.DataContext = this;
            ArtistCB.SelectedIndex = (int)contextTimetable.ID_Artist - 1;
            PerfomanceCB.SelectedIndex = (int)contextTimetable.ID_Perfomance - 1;

            TimeTB.Text = contextTimetable.Time;
            DateDP.SelectedDate = contextTimetable.Date;

            //Perfomance selectedPerformance = PerfomanceCB.SelectedItem as Perfomance;
            //StartDateDP.SelectedDate = selectedPerformance.StartDate;

            //EndDateDP.SelectedDate = selectedPerformance.EndDate;
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                Timetable timetable = contextTimetable;
                if (string.IsNullOrWhiteSpace(ArtistCB.Text) ||
                    string.IsNullOrWhiteSpace(PerfomanceCB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    timetable.Time = TimeTB.Text;
                    timetable.Date = DateDP.SelectedDate;
                    timetable.ID_Artist = (ArtistCB.SelectedItem as Worker).ID;
                    timetable.ID_Perfomance = (PerfomanceCB.SelectedItem as Perfomance).ID;
                    DBConnection.circusDB.SaveChanges();

                    ArtistCB.Text = String.Empty;
                    PerfomanceCB.Text = String.Empty;
                    TimeTB.Text = String.Empty;
                    DateDP.Text = String.Empty;

                    DBConnection.circusDB.SaveChanges();
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка!");
            }
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

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
