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
    /// Логика взаимодействия для EditTaskWindow.xaml
    /// </summary>
    public partial class EditTaskWindow : Window
    {
        public static List<Taskk> tasks { get; set; }
        public static List<Worker> staffs { get; set; }
        public static List<Status> statuses { get; set; }

        Taskk contextTask;

        public EditTaskWindow(Taskk taskk)
        {
            InitializeComponent();
            contextTask = taskk;
            InitializeDataInPage();
            this.DataContext = this;
        }

        private void InitializeDataInPage()
        {
            tasks = DBConnection.circusDB.Taskk.ToList();
            staffs = DBConnection.circusDB.Worker.ToList();
            statuses = DBConnection.circusDB.Status.ToList();
            this.DataContext = this;
            DateDP.Text = contextTask.Date.ToString();
            StaffCB.SelectedIndex = (int)contextTask.ID_ServiceStaff - 1;
            StatusCB.SelectedIndex = (int)contextTask.ID_Done - 1;
            DescriptionTB.Text = contextTask.Description;
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                Taskk taskk = contextTask;
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
                    taskk.ID_Done = (StatusCB.SelectedItem as Status).ID;
                    taskk.Date = DateDP.SelectedDate;
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
