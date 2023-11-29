using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JasonExerciseTracker
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void ChangeToDarkTheme()
        {
            Application.Current.Resources["ThemeBackgroundColour"] = Color.DarkGray;
            Application.Current.Resources["ThemeTextColour"] = Color.White;
        }

        public void ChangeToLightTheme()
        {
            Application.Current.Resources["ThemeBackgroundColour"] = Color.White;
            Application.Current.Resources["ThemeTextColour"] = Color.Black;
        }
    }
}
