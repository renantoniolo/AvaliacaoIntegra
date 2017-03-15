using System;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

namespace AvaliacaoIntegra
{
	public class CadastroClienteViewModel : ViewModelBase
	{

		private IAlertService _alertService;
		private INavigationService _navigationService;

		public CadastroClienteViewModel()
		{
			
			this._alertService = DependencyService.Get<IAlertService>();
			this._navigationService = DependencyService.Get<INavigationService>();

			this.CadastrarCommand = new Command(this.Cadastrar);

		}


		private string nome;
		public string Nome
		{
			get { return nome; }
			set
			{
				nome = value;
				this.Notify(nameof(Nome));
			}
		}

		private string sexo;
		public string Sexo
		{
			get { return sexo; }
			set
			{
				sexo = value;
				this.Notify(nameof(Sexo));
			}
		}


		private string cpf;
		public string CPF
		{
			get { return cpf; }
			set
			{
				cpf = value;
				this.Notify(nameof(CPF));
			}
		}

		private string telefone;
		public string Telefone
		{
			get { return telefone; }
			set
			{
				telefone = value;
				this.Notify(nameof(Telefone));
			}
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

		public ICommand CadastrarCommand
		{
			get;
			set;
		}

		private async void Cadastrar()
		{
			try
			{
				Load = true;

				//verifica se preencheu os campos corretamente
				if (string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(cpf) || string.IsNullOrEmpty(Telefone))
				{
					await this._alertService.ShowAsync("Atenção", "Preencha todos os campos do formulário.", "Ok");
					return;
				}

				// Instanciamos o objeto a ser enviado
				Cliente cliente = new Cliente();
				cliente.Nome = Nome;
				cliente.Sexo = "Masculino";
				cliente.CPF = CPF;
				cliente.Telefone = Telefone;

				HttpResponseMessage response = await HttpService.CadastrarCliente(cliente);

				switch ((int)response.StatusCode)
				{
					case 200:
						Debug.WriteLine("Enviado para a API com sucesso!");
						await this._alertService.ShowAsync("Informativo", "Cliente incluido com sucesso.", "Ok");
						await this._navigationService.NavigateToListaClientes();
						break;

					default:
						await this._alertService.ShowAsync("Opss...", "Falha ao enviar para a API.", "Ok");
						break;
				}


			}
			catch (Exception ex)
			{

				Debug.WriteLine("Erro ao cadastar : " + ex.Message);
			}
			finally { 

				Load = false;
			}

		}



	}
}
