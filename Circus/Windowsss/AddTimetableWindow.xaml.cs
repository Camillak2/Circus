﻿using Circus.DB;
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
        public static List<Timetable> timetables { get; set; }
        public static Timetable timetable = new Timetable();

        public static Perfomance contextPerfomance;

        public AddTimetableWindow()
        {
            InitializeComponent();

            perfomances = DBConnection.circusDB.Perfomance.ToList();
            artists = DBConnection.circusDB.Worker.Where(i => i.ID_Position == 2).ToList();

            contextPerfomance = DBConnection.currentPerfomance;

            timetables = DBConnection.circusDB.Timetable.ToList();
            StartDateDP.SelectedDate = contextPerfomance.StartDate;
            EndDateDP.SelectedDate = contextPerfomance.EndDate;

            this.DataContext = this;
        }

        private void AddTimetableBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrWhiteSpace(ArtistCB.Text) || string.IsNullOrWhiteSpace(PerfomanceCB.Text) || string.IsNullOrWhiteSpace(TimeTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    var a = ArtistCB.SelectedItem as Worker;
                    timetable.ID_Artist = a.ID;

                    var b = PerfomanceCB.SelectedItem as Perfomance;
                    timetable.ID_Perfomance = a.ID;

                    timetable.Time = TimeTB.Text.Trim();

                    if (DateDP.SelectedDate > StartDateDP.SelectedDate && DateDP.SelectedDate < EndDateDP.SelectedDate)
                    {
                        timetable.Date = DateDP.SelectedDate;
                    }
                    else
                    {
                        MessageBox.Show("Выберите правильную дату!");
                    }

                    DBConnection.circusDB.Timetable.Add(timetable);
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
