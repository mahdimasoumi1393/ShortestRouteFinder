using ShortestRouteFinder.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows;


namespace ShortestRouteFinder.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Route> Routes { get; set; }
        public string SelectedAlgorithm { get; set; }

        public MainViewModel()
        {
            
            Routes = new ObservableCollection<Route>();
            LoadRoutes();
        }
        private void LoadRoutes()
        {
            try
            {
                // Sökväg till JSON-filen
                string filePath = "C:\\Users\\mahdi\\Desktop\\Csharp\\Uppgift3\\ShortestRouteFinder-master\\ShortestRouteFinder\\routes.json";

                if (File.Exists(filePath))
                {
                    // Läser in hela JSON-filen som en sträng
                    string jsonContent = File.ReadAllText(filePath);

                    // Konverterar JSON-strängen till en lista av Route-objekt
                    var routes = JsonConvert.DeserializeObject<ObservableCollection<Route>>(jsonContent);

                    if (routes != null)  // Kontrollera att värdet ska inte vara null
                    {
                        // Lägger till varje rutt i Routes
                        foreach (var route in routes)
                        {
                            Routes.Add(route);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("routes.json not found at specified path.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading routes: {ex.Message}");
            }
        }


        // Adding Bubble Sort
        private void BubbleSort()
        {
            for (int i = 0; i < Routes.Count - 1; i++)
            {
                for (int j = 0; j < Routes.Count - i - 1; j++)
                {
                    if (Routes[j].Distance > Routes[j + 1].Distance)
                    {
                        var temp = Routes[j];
                        Routes[j] = Routes[j + 1];
                        Routes[j + 1] = temp;
                    }
                }
            }
        }

        // Adding Quick Sort
        private void QuickSort(int left, int right)
        {
            if (left >= right) return;
            int pivot = (int)Routes[(left + right) / 2].Distance;
            int index = Partition(left, right, pivot);
            QuickSort(left, index - 1);
            QuickSort(index, right);
        }

        private int Partition(int left, int right, int pivot)
        {
            while (left <= right)
            {
                while (Routes[left].Distance < pivot) left++;
                while (Routes[right].Distance > pivot) right--;
                if (left <= right)
                {
                    var temp = Routes[left];
                    Routes[left] = Routes[right];
                    Routes[right] = temp;
                    left++;
                    right--;
                }
            }
            return left;
        }

        // Sorting method  based on user selection
        public void SortRoutes()
        {
            if (SelectedAlgorithm == "Bubble Sort")
            {
                BubbleSort();
            }
            else if (SelectedAlgorithm == "Quick Sort")
            {
                QuickSort(0, Routes.Count - 1);
            }
            // Notify view of updated list
            OnPropertyChanged(nameof(Routes));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
} 

    
