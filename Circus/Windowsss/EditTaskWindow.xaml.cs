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
    /// Логика взаимодействия для EditTaskWindow.xaml
    /// </summary>
    public partial class EditTaskWindow : Window
    {
        public static Taskk taskk { get; set; }
        public static List<Worker> staffs { get; set; }
        public static List<Taskk> tasks { get; set; }
        public EditTaskWindow(Taskk task)
        {
            InitializeComponent();
            InitializeDataInPage();
            this.DataContext = this;
        }

        private void InitializeDataInPage()
        {
            tasks = DBConnection.circusDB.Taskk.ToList();
            staffs = DBConnection.circusDB.Worker.ToList();
            this.DataContext = this;
            DateTimeDP.Text = taskk.DateTime.ToString();
            StaffCB.SelectedIndex = (int)taskk.ID_ServiceStaff - 1;
            StatusCB.SelectedIndex = (int)taskk.ID_Done - 1;
            DescriptionTB.Text = taskk.Description;
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrWhiteSpace(StaffCB.Text) ||
                    string.IsNullOrWhiteSpace(DescriptionTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    taskk.Description = DescriptionTB.Text;
                    taskk.ID_ServiceStaff = (StaffCB.SelectedItem as Worker).ID;
                    taskk.DateTime = DateTime.Now;
                    taskk.DateTime = DateTimeDP.SelectedDate;
                    DBConnection.circusDB.SaveChanges();

                    DescriptionTB.Text = String.Empty;
                    StaffCB.Text = String.Empty;
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
