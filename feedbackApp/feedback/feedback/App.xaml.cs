using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using feedback.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace feedback
{
    public partial class App : Application
    {
        static feedbackDataBase database;

        public static feedbackDataBase Database
        {
            
            get
            {
                if (database == null)
                {
                    database = new feedbackDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Comments.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
