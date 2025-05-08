using OnlineCourseUIDesigns.MVVM.ViewModels;

namespace OnlineCourseUIDesigns.MVVM.Views;

public partial class DetailView : ContentPage
{
    public DetailView()
    {
        InitializeComponent();
        BindingContext = new DetailViewModel();
    }
}