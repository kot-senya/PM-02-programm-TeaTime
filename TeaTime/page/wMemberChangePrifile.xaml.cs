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

namespace teaTime
{
    /// <summary>
    /// Логика взаимодействия для wMemberChangePrifile.xaml
    /// </summary>
    public partial class wMemberChangePrifile : Page
    {
        public wMemberChangePrifile()
        {
            InitializeComponent();
        }

        private void bChange_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new wMemberUserPrifile());
        }
    }
}