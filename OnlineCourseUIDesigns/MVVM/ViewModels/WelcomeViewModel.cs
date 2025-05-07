using CommunityToolkit.Mvvm.ComponentModel;
using OnlineCourseUIDesigns.MVVM.Models;
using OnlineCourseUIDesigns.Services;
using System.Collections.ObjectModel;

namespace OnlineCourseUIDesigns.MVVM.ViewModels
{
    public class WelcomeViewModel : ObservableObject
    {
        public ClothFashionService _clothFashionService;
        ObservableCollection<Item> _item;
        public ObservableCollection<Item> Items
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged(nameof(Item));
            }
        }

        public WelcomeViewModel(ClothFashionService clothFashionService)
        {
            _clothFashionService = clothFashionService;
            LoadData();
        }

        private void LoadData()
        {
            Items = new ObservableCollection<Item>(_clothFashionService.GetPromoItems());
        }
    }
}
