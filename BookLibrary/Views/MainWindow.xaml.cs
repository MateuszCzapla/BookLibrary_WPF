﻿using System.Windows;
using BookLibrary.DataAccessLayer;
namespace BookLibrary.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DatabaseOperations.CheckDatabase();
        }
    }
}
