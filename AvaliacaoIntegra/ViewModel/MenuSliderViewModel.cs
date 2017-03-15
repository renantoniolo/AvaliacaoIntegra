using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AvaliacaoIntegra
{
	public class MenuSliderViewModel : ViewModelBase
	{

		private IAlertService _alertService;
		private INavigationService _navigationService;

		public MenuSliderViewModel()
		{

			this._alertService = DependencyService.Get<IAlertService>();
			this._navigationService = DependencyService.Get<INavigationService>();

			this.AdicionarClientesCommand = new Command(this.AdicionarClientes);
			this.ListarClientesCommand = new Command(this.ListarClientes);
			this.LogoutCommand = new Command(this.Logout);

		}

		public ICommand AdicionarClientesCommand
		{
			get;
			set;
		}

		private async void AdicionarClientes()
		{

			await this._navigationService.NavigateToCadastroCliente();


		}

		public ICommand ListarClientesCommand
		{
			get;
			set;
		}

		private async void ListarClientes()
		{

			await this._navigationService.NavigateToListaClientes();


		}

		public ICommand LogoutCommand
		{
			get;
			set;
		}

		private async void Logout()
		{

			await this._navigationService.NavigateToLogin();

		}



	}
}
