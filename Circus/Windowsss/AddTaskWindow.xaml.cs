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
    /// Логика взаимодействия для AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        public static Worker workers { get; set; }
        public static Task tasks { get; set; }

        public AddTaskWindow()
        {
            InitializeComponent();
            workers = DBConnection.circusDB.Worker.ToList();
            tasks = DBConnection.circusDB.Taskk.ToList();
            this.DataContext = this;
        }

        private void AddAnimalBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
