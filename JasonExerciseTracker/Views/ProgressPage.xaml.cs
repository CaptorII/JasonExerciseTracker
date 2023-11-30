using JasonExerciseTracker.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JasonExerciseTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressPage : ContentPage
    {
        public ProgressPage()
        {
            InitializeComponent();
            UpdateProgress();
        }

        public void UpdateProgress()
        {
            // display date and number of days passed so far
            TimeSpan daysSinceStartOfYear = DateTime.Today - new DateTime(DateTime.Today.Year, 1, 1);
            DateField.Text = DateTime.Today.ToString("dd/MM/yyyy") + " - Day " + (daysSinceStartOfYear.Days + 1);
            // display average minutes of exercise per day
            AverageMinsField.Text = Exercise.GetAverageMinutesPerDay().ToString("00");
            TimeSpan totalMins = TimeSpan.FromMinutes(Exercise.minutesOfExerciseDone);
            // display total minutes of exercise
            TotalMinsField.Text = $"{(int)totalMins.TotalHours}:{totalMins.Minutes:00}";
            // change text colour depending on if goal has been met or not
            if (Exercise.IsGoalAchieved())
            {
                AverageMinsField.TextColor = Color.Green;
                TotalMinsField.TextColor = Color.Green;
            }
            else
            {
                AverageMinsField.TextColor = Color.Red;
                TotalMinsField.TextColor = Color.Red;
            }
            // display target minutes of exercise 
            TimeSpan targetMins = TimeSpan.FromMinutes(Exercise.GetTargetMinutes());
            TargetMinsField.Text = $"{(int)targetMins.TotalHours}:{targetMins.Minutes:00}";
            // display time between goal and actual, can be negative if you're ahead of target
            TimeSpan goalMins = TimeSpan.FromMinutes(Exercise.GetDifferenceFromTarget());
            MinsToTargetField.Text = $"{(int)goalMins.TotalHours}:{goalMins.Minutes:00}";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateProgress(); // update progress every time page is navigated to, useful for after you log more time
        }
    }
}