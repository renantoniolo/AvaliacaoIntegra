using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AvaliacaoIntegra
{
	public class ListarClientesViewModel : ViewModelBase 
	{

		private IAlertService _alertService;
		private INavigationService _navigationService;
		private List<ClienteFoto> lista;

		public ListarClientesViewModel()
		{

			this._alertService = DependencyService.Get<IAlertService>();
			this._navigationService = DependencyService.Get<INavigationService>();

			this.AdicionarClientesCommand = new Command(this.AdicionarClientes);

			ListaClientes = new ObservableCollection<ClienteFoto>();

			Load = true;

			// atualiza a lista
			MessagingCenter.Subscribe<ListarClientesViewModel>(this, "LoadLista", (sender) =>
			{
				Debug.WriteLine("Atualizar Lista de Clientes");

				foreach (ClienteFoto cliente in lista)
				{
					// adiciona o cliente
					this.ListaClientes.Add(cliente);
				}

				Load = false;

			});

			// carrega a lista da api
			carregarLista();

		}

		private async void carregarLista() {


			lista = await HttpService.GetListaClientes();

			// Atualiza a lista
			MessagingCenter.Send((ListarClientesViewModel)this, "LoadLista");
		
		}

		private bool load;
		public bool Load
		{

			get { return load; }
			set
			{
				load = value;
				this.Notify(nameof(Load));
			}
		}


		private ObservableCollection<ClienteFoto> listaClientes;
		public ObservableCollection<ClienteFoto> ListaClientes
		{
			get { return listaClientes; }
			set
			{
				listaClientes = value;
				this.Notify(nameof(ListaClientes));
			}
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
	}
}
