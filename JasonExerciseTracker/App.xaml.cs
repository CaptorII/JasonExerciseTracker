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
        }

        private void LoadPreferences()
        {
            int dailyTarget = AppSettings.DailyTarget;
            int totalMinutes = AppSettings.TotalMinutes;
            string theme = AppSettings.Theme;
            Exercise.dailyTarget = dailyTarget;
            Exercise.minutesOfExerciseDone = totalMinutes;
            ((MainPage)Current.MainPage).ApplyTheme(theme);
            if (AppSettings.CurrentYear != DateTime.Today.Year) // if year is not the same as when app was last launched, reset data
            {
                AppSettings.ResetData();
            }
            AppSettings.CurrentYear = DateTime.Today.Year;
        }
    }
}
