
//namespace DMApuntes.DMViews;
namespace DMApuntes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DMViews.DMNotePage), typeof(DMViews.DMNotePage));
        }
    }
}
