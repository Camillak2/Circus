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
using Circus.DB;
using Circus.Pages;

namespace Circus.Windowsss
{
    /// <summary>
    /// Логика взаимодействия для AddApplicationWindow.xaml
    /// </summary>
    public partial class AddApplicationWindow : Window
    {
        public static Status status { get; set; }
        public static Applicationn applicationn = new Applicationn();

        Worker loggedWorker;

        public AddApplicationWindow()
        {
            InitializeComponent();
            loggedWorker = DBConnection.loginedWorker;

            this.DataContext = this;
        }

        private void AddTaskBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = new StringBuilder();
                if (string.IsNullOrWhiteSpace(DescriptionTB.Text))
                {
                    error.AppendLine("Заполните все поля!");
                }
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                }
                else
                {
                    applicationn.Comment = DescriptionTB.Text.Trim();
                    applicationn.ID_Artist = loggedWorker.ID;
                    applicationn.ID_Done = 3;

                    DBConnection.circusDB.Applicationn.Add(applicationn);
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
