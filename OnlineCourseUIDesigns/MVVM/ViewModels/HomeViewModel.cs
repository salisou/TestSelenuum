using CommunityToolkit.Mvvm.ComponentModel;
using OnlineCourseUIDesigns.MVVM.Models;
using OnlineCourseUIDesigns.Services;
using System.Collections.ObjectModel;

namespace OnlineCourseUIDesigns.MVVM.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        readonly ClothFashionService _clothFashionService;

        Promotion _promotion;
        ObservableCollection<string> _categories;
        ObservableCollection<Product> _products;

        public HomeViewModel()
        {
            _clothFashionService = new ClothFashionService();
            LoadData();
        }

        public Promotion Promotion
        {
            get => _promotion;
            set
            {
                _promotion = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        [ObservableProperty]
        private string selectedCategory;


        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        private void LoadData()
        {
            Promotion = _clothFashionService.GetPromotion();
            Categories = new ObservableCollection<string>(_clothFashionService.GetCategories());

            // Debug: Verifica il contenuto di Categories
            System.Diagnostics.Debug.WriteLine($"Categories: {string.Join(", ", Categories)}");

            // Imposta la categoria selezionata
            SelectedCategory = Categories.FirstOrDefault() ?? "No Categories";

            // Debug: Verifica la categoria selezionata
            System.Diagnostics.Debug.WriteLine(message: $"SelectedCategory: {SelectedCategory}");

            Products = new ObservableCollection<Product>(_clothFashionService.GetPopularProducts());
        }
    }
}
