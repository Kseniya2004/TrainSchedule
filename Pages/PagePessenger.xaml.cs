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
    /// Логика взаимодействия для PagePessenger.xaml
    /// </summary>
    public partial class PagePessenger : Page
    {
        public PagePessenger()
        {
            InitializeComponent();
            DgridPes.ItemsSource = Train_scheduleEntities.GetTrain().Pessenger.ToList();
        }       

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PagePesEdit(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = DgridPes.SelectedItems.Cast<Pessenger>().ToList();
            if (MessageBox.Show($"Удалить {usersForRemoving.Count()} пассажиров?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {
                    Train_scheduleEntities.GetTrain().Pessenger.RemoveRange(usersForRemoving);
                    Train_scheduleEntities.GetTrain().SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            DgridPes.ItemsSource = Train_scheduleEntities.GetTrain().Pessenger.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PagePesEdit((sender as Button).DataContext as Pessenger));
        }

        private void BtnTicket_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageTicket());
        }

        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageTrain());
        }
    }
}
