using System.Windows;
using BookLibrary.Other;
using BookLibrary.ViewModels;

namespace BookLibrary.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            InitializeComponent();
            DatabaseOperations.CheckDatabase();
        }
    }
}
