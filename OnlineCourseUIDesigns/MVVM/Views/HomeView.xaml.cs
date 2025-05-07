
using OnlineCourseUIDesigns.MVVM.ViewModels;

namespace OnlineCourseUIDesigns.MVVM.Views;

public partial class HomeView : ContentPage
{
    public HomeView()
    {
        InitializeComponent();
        BindingContext = new HomeViewModel();
    }
}