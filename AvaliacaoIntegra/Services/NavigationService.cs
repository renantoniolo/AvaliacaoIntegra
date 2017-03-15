using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AvaliacaoIntegra
{
	public class NavigationService : INavigationService
	{
		public NavigationService()
		{
		}

		public async Task NavigateToMenuSlider()
		{
			try
			{

				MasterPage master = new MasterPage();

				//digo que esta pagina é a minha master
				App.MasterDetailPage = master;

				// abre a view
				Application.Current.MainPage = master;


			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
				return;
			}
		}


		public async Task NavigateToCadastroCliente()
		{
			
			try
			{
				App.MasterDetailPage.Detail = new NavigationPage(new CadastroClienteView());
				App.MasterDetailPage.IsPresented = false;
				//await App.MasterDetailPage.Detail.Navigation.PushAsync(new CadastroClienteView());

			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
				return;
			}

		}

		public async Task NavigateToLogin()
		{
			try
			{
				// volto a navegaçao para cá
				Application.Current.MainPage = new NavigationPage(new LoginView());

			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
				return;
			}
		}

		public async Task NavigateToListaClientes()
		{
			try
			{
				//await App.MasterDetailPage.Detail.Navigation.PushAsync(new ListarClientesView());
				App.MasterDetailPage.Detail = new NavigationPage(new ListarClientesView());
				App.MasterDetailPage.IsPresented = false;
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
				return;
			}

		}
	}
}
