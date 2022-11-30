﻿using System;
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

        private void BtnWord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPDF_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
