using JasonExerciseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Exercise.dailyTarget += (int)mins;
            }
        }

        private async void ResetData_Clicked(object sender, EventArgs e)
        {
            bool confirmed = await DisplayAlert("Confirmation", "This will reset all data in the app, including exercise completed, goals and settings. Continue?", 
                "Confirm", "Cancel");
            if (confirmed)
            {
                Exercise.minutesOfExerciseDone = 0;
                Exercise.dailyTarget = 30;
                await DisplayAlert("Reset Data", "App data has been reset.", "OK");
            }
        }
    }
}