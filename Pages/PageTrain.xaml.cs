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

        private void BtnWord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPDF_Click(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// Добавление
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageEdit(null));
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = DgridTrain.SelectedItems.Cast<Train>().ToList();
            if (MessageBox.Show($"Удалить {usersForRemoving.Count()} пользователей?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {
                    Train_scheduleEntities.GetTrain().Train.RemoveRange(usersForRemoving);
                    Train_scheduleEntities.GetTrain().SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            DgridTrain.ItemsSource = Train_scheduleEntities.GetTrain().Train.ToList();
        }
        /// <summary>
        /// Переход на билеты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTicket_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageTicket());
        }
        /// <summary>
        /// Редактирование
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageEdit((sender as Button).DataContext as Train));
        }

        private void BtnPas_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PagePessenger());
        }
    }
}
