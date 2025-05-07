using OnlineCourseUIDesigns.MVVM.ViewModels;

namespace OnlineCourseUIDesigns.MVVM.Views;

public partial class HomeView : ContentPage
{
    public HomeView(WelcomeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}