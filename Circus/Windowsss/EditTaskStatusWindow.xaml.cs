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
    /// Логика взаимодействия для EditTaskStatusWindow.xaml
    /// </summary>
    public partial class EditTaskStatusWindow : Window
    {
        public static Taskk taskk { get; set; }
        public static List<Taskk> tasks { get; set; }
        public static List<Status> statuses { get; set; }
        public EditTaskStatusWindow()
        {
            InitializeComponent();
            tasks = DBConnection.circusDB.Taskk.ToList();
            statuses = DBConnection.circusDB.Status.ToList();
            DescriptionTB.Text = taskk.Description;
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrWhiteSpace(StatusCB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                else
                {
                    taskk.ID_Done = (StatusCB.SelectedItem as Status).ID;
                    DBConnection.circusDB.SaveChanges();

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
