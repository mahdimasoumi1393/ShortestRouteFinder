using System.Windows;
using System.Windows.Controls;
using ShortestRouteFinder.ViewModel;
using ShortestRouteFinder.ViewModel;

namespace ShortestRouteFinder
{
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            this.DataContext = viewModel;
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            // Setting algorithm based on ComboBox
            viewModel.SelectedAlgorithm = ((ComboBoxItem)AlgorithmSelector.SelectedItem).Content.ToString();
            viewModel.SortRoutes();
            RoutesList.ItemsSource = viewModel.Routes;  // Refresh the ListView
        }
    }
}

