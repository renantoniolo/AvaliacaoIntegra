using Xamarin.Forms;

namespace AvaliacaoIntegra
{
	public partial class App : Application
	{
		public static MasterDetailPage MasterDetailPage;
		public static IAlertService _alertService;
		public static INavigationService _navigationService;
	

		public App()
		{
			InitializeComponent();

			DependencyService.Register<INavigationService, NavigationService>();
			DependencyService.Register<IAlertService, AlertService>();

			_alertService = DependencyService.Get<IAlertService>();
			_navigationService = DependencyService.Get<INavigationService>();

			// inicia a navegacao
			MainPage = new NavigationPage( new LoginView());

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
