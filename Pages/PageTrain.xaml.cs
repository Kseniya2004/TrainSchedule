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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrainSchedule.Classes;

namespace TrainSchedule.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTrain.xaml
    /// </summary>
    public partial class PageTrain : Page
    {
        public PageTrain()
        {
            InitializeComponent();
            //привязка таблицы            
            DgridTrain.ItemsSource = Train_scheduleEntities.GetTrain().Train.ToList();
            
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Train_scheduleEntities.GetTrain().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DgridTrain.ItemsSource = Train_scheduleEntities.GetTrain().Train.ToList();
            }
        }
    }
}
