using JasonExerciseTracker.Models;
using System;
using Xamarin.Forms;

namespace JasonExerciseTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            base.OnStart();
            LoadPreferences();
            CheckYear();
        }
        private void LoadPreferences()
        {
            int dailyTarget = AppSettings.DailyTarget;
            int totalMinutes = AppSettings.TotalMinutes;
            int currentYear = AppSettings.CurrentYear;
            string theme = AppSettings.Theme;
            Exercise.dailyTarget = dailyTarget;
            Exercise.minutesOfExerciseDone = totalMinutes;
            ((MainPage)Current.MainPage).ApplyTheme(theme);

        }

        private void CheckYear()
        {
            int currentYear = AppSettings.CurrentYear;
            if (currentYear != DateTime.Today.Year) // if year is not the same as when app was last launched, reset data
            {
                //AppSettings.ResetData();
                Page page = new Page();
                page.DisplayAlert("Alert", "Year changed", "OK");
            }
            AppSettings.CurrentYear = DateTime.Today.Year;
        }
    }
}
