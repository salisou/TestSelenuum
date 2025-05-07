using OnlineCourseUIDesigns.MVVM.Views;

namespace OnlineCourseUIDesigns
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DetailView), typeof(DetailView));
        }
    }
}
