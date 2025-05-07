using OnlineCourseUIDesigns.MVVM.ViewModels;

namespace OnlineCourseUIDesigns.MVVM.Views;

public partial class WelcomeView : ContentPage
{
    public WelcomeView(WelcomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
