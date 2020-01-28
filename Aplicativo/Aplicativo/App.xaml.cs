using Aplicativo.Views;
using Xamarin.Forms;

namespace Aplicativo
{
    public partial class App : Application
    {
        public static string DbName;
        public static string DbPath;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }
        public App(string dbPath, string dbName)
        {

            InitializeComponent();
            App.DbName = dbName;
            App.DbPath = dbPath;
            MainPage = new NavigationPage(new Login());
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
