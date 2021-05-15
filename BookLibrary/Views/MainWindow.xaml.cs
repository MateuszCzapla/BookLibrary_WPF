using System.Windows;
using BookLibrary.Other;
using BookLibrary.ViewModels;

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
            this.DataContext = new MainMenuViewModel();
        }
    }
}
