using System;
using Autofac;
using SunnyWeatherApp.Infrastructure;
using Xamarin.Forms;
using SunnyWeatherApp.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace SunnyWeatherApp
{
	public partial class App : Application
	{
	    public static IContainer Container { get; }
        static App()
	    {
	        var builder = new ContainerBuilder();
	        AutofacRegistrator.Register(builder);
	        Container = builder.Build();
        }
		
		public App ()
		{
			InitializeComponent();
			MainPage = new MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
