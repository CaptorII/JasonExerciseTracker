using JasonExerciseTracker.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JasonExerciseTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private void IncrementCounter_Clicked(object sender, EventArgs e)
        {
            if (double.TryParse(counterEntry.Text, out double mins))
            {
                mins++;
                counterEntry.Text = mins.ToString();
            }
        }

        private void DecrementCounter_Clicked(Object sender, EventArgs e)
        {
            if (double.TryParse(counterEntry.Text, out double mins))
            {
                mins--;
                counterEntry.Text = mins.ToString();
            }
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(counterEntry.Text, out int mins)) // when a number is passed
            {
                Exercise.minutesOfExerciseDone += mins; // add number to total minutes done
            }
            else if (double.TryParse(counterEntry.Text, out double minsDouble)) // if a double is passed
            {
                Exercise.minutesOfExerciseDone += (int)minsDouble; // truncate anything after decimal point
            }
            AppSettings.TotalMinutes = Exercise.minutesOfExerciseDone;
            counterEntry.Text = "";
        }
    }
}