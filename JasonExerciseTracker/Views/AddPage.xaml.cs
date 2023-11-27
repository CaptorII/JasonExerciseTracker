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
            if (int.TryParse(counterEntry.Text, out int mins))
            {
                mins++;
                counterEntry.Text = mins.ToString();
            }
        }

        private void DecrementCounter_Clicked(Object sender, EventArgs e)
        {
            if (int.TryParse(counterEntry.Text,out int mins))
            {
                mins--;
                counterEntry.Text = mins.ToString();
            }
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(counterEntry.Text, out int mins))
            {
                Exercise.minutesOfExerciseDone += mins;
            }
        }
    }
}