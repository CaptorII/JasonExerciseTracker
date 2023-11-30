using Xamarin.Forms;

namespace JasonExerciseTracker.Models
{
    public static class AppSettings
    {
        public static int DailyTarget
        {
            get => GetValueOrDefault("DailyTarget", 30);
            set => SetValue("DailyTarget", value);
        }

        public static int TotalMinutes
        {
            get => GetValueOrDefault("TotalMinutes", 0);
            set => SetValue("TotalMinutes", value);
        }

        public static int CurrentYear
        {
            get => GetValueOrDefault<int>("CurrentYear", 0);
            set
            {
                Application.Current.Properties["CurrentYear"] = value;
                Application.Current.SavePropertiesAsync();
            }
        }

        public static string Theme
        {
            get => GetValueOrDefault("Theme", "light");
            set => SetValue("Theme", value);
        }

        private static T GetValueOrDefault<T>(string key, T defaultValue)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                return (T)Application.Current.Properties[key];
            }
            return defaultValue;
        }

        private static void SetValue<T>(string key, T value)
        {
            Application.Current.Properties[key] = value;
            Application.Current.SavePropertiesAsync();
        }

        public static void ResetData()
        {
            Exercise.minutesOfExerciseDone = 0;
            Exercise.dailyTarget = 30;
            ((MainPage)Application.Current.MainPage).ApplyTheme("light");
        }
    }
}
