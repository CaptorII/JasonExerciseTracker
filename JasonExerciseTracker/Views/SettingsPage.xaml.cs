using JasonExerciseTracker.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JasonExerciseTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (double.TryParse(targetEntry.Text, out double mins))
            {
                if (mins < 5) // set bounds of target - 5-60 mins
                {
                    mins = 5;
                }
                else if (mins > 60)
                {
                    mins = 60;
                }
                Exercise.dailyTarget = (int)mins; // update target
                AppSettings.DailyTarget = (int)mins; // save new target
                targetEntry.Text = "";
            }
        }

        private void ThemePicker_Selected(object sender, EventArgs e)
        {
            if (themePicker.SelectedIndex == 0)
            {
                ((MainPage)Application.Current.MainPage).ApplyTheme("light");
            }
            else if (themePicker.SelectedIndex == 1)
            {
                ((MainPage)Application.Current.MainPage).ApplyTheme("dark");
            }
            themePicker.SelectedIndex = -1;
        }

        private async void ResetData_Clicked(object sender, EventArgs e)
        {
            bool confirmed = await DisplayAlert("Confirmation", "This will reset all data in the app, including exercise completed, goals and settings. Continue?",
                "Confirm", "Cancel");
            if (confirmed)
            {
                AppSettings.ResetData();
                await DisplayAlert("Reset Data", "App data has been reset.", "OK");
            }
        }
    }
}