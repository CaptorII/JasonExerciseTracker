using System;
using System.Collections.Generic;
using System.Text;

namespace JasonExerciseTracker.Models
{
    public static class Exercise
    {
        public static int minutesOfExerciseDone = 0;
        public static int dailyTarget = 30;

        public static void LogExercise(int minutes)
        {
            minutesOfExerciseDone += minutes;
        }

        public static double GetAverageMinutesPerDay()
        {
            DateTime startOfYear = new DateTime(DateTime.Today.Year, 1, 1);
            TimeSpan daysSinceStartOfYear = DateTime.Today - startOfYear;
            return minutesOfExerciseDone / (double)(daysSinceStartOfYear.Days + 1);
        }

        public static int GetTargetMinutes()
        {
            DateTime startOfYear = new DateTime(DateTime.Today.Year, 1, 1);
            TimeSpan daysSinceStartOfYear = DateTime.Today - startOfYear;
            return dailyTarget * (daysSinceStartOfYear.Days + 1);
        }

        public static int GetDifferenceFromTarget()
        {
            return GetTargetMinutes() - minutesOfExerciseDone;
        }

        public static bool IsGoalAchieved()
        {
            return minutesOfExerciseDone >= GetTargetMinutes();
        }
    }
}
