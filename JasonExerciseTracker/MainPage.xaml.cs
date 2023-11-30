using JasonExerciseTracker.Models;
using Xamarin.Forms;

namespace JasonExerciseTracker
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void ApplyTheme(string theme)
        {
            AppSettings.Theme = theme; // save theme to preferences      
            if (theme == "light")
            {
                Application.Current.Resources["ThemeBackgroundColour"] = Color.White;
                Application.Current.Resources["ThemeTextColour"] = Color.Black;
            }
            else
            {
                Application.Current.Resources["ThemeBackgroundColour"] = Color.DimGray;
                Application.Current.Resources["ThemeTextColour"] = Color.White;
            }
            Application.Current.MainPage = new MainPage(); // force refresh UI to apply theme changes
        }
    }
}
