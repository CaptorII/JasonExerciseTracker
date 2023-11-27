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
    public partial class ProgressPage : ContentPage
    {
        public ProgressPage()
        {
            InitializeComponent();
            UpdateProgress();
        }

        public void UpdateProgress()
        {
            TimeSpan daysSinceStartOfYear = DateTime.Today - new DateTime(DateTime.Today.Year, 1, 1);
            DateField.Text = DateTime.Today.ToString("dd/MM/yyyy") + " - Day " + (daysSinceStartOfYear.Days + 1);
            AverageMinsField.Text = Exercise.GetAverageMinutesPerDay().ToString("00");
            TimeSpan totalMins = TimeSpan.FromMinutes(Exercise.minutesOfExerciseDone);
            TotalMinsField.Text = $"{(int)totalMins.TotalHours}:{totalMins.Minutes:00}";
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
            TimeSpan targetMins = TimeSpan.FromMinutes(Exercise.GetTargetMinutes());
            TargetMinsField.Text = $"{(int)targetMins.TotalHours}:{targetMins.Minutes:00}";
            TimeSpan goalMins = TimeSpan.FromMinutes(Exercise.GetDifferenceFromTarget());
            MinsToTargetField.Text = $"{(int)goalMins.TotalHours}:{goalMins.Minutes:00}";
        }

        protected override void OnAppearing()
        {
            UpdateProgress();
        }
    }
}