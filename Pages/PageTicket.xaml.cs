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
    /// Логика взаимодействия для PageTicket.xaml
    /// </summary>
    public partial class PageTicket : Page
    {
        public PageTicket()
        {
            InitializeComponent();
            //привязка таблицы            
            DgridTicket.ItemsSource = Train_scheduleEntities.GetTrain().Ticket.ToList();
        }

        private void BtnWord1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExcel1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPDF1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd1_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageEditTicket(null));
        }

        private void BtnDelete1_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving1 = DgridTicket.SelectedItems.Cast<Ticket>().ToList();
            if (MessageBox.Show($"Удалить {usersForRemoving1.Count()} пассажиров?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {
                    Train_scheduleEntities.GetTrain().Ticket.RemoveRange(usersForRemoving1);
                    Train_scheduleEntities.GetTrain().SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            DgridTicket.ItemsSource = Train_scheduleEntities.GetTrain().Ticket.ToList();
        }

        private void BtnEdit1_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageEditTicket((sender as Button).DataContext as Ticket));
        }
    }
}
