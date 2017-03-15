using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Windows.Input;
using Newtonsoft.Json;
using Realms;
using Xamarin.Forms;

namespace AvaliacaoIntegra
{
	public class LoginViewModel : ViewModelBase
	{


		public LoginViewModel()
		{
	

			BtnEntrar = true;

			this.LoginCommand = new Command(this.Login);


		}

		private string email;
		public string Email
		{
			get { return email; }
			set
			{
				email = value;
				this.Notify(nameof(Email));
			}
		}

		private string senha;
		public string Senha
		{
			get { return senha; }
			set
			{
				senha = value;
				this.Notify(nameof(Senha));
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

		private bool btnEntrar;
		public bool BtnEntrar
		{

			get { return btnEntrar; }
			set
			{
				btnEntrar = value;
				this.Notify(nameof(BtnEntrar));
			}
		}

		public ICommand LoginCommand
		{
			get;
			set;
		}

		private async void Login()
		{
			// varivel de autenticaçao
			Authenticated authenticated = null;

			email = "avaliacao@integracnt.com";
			senha = "integra2016";

			try
			{
				BtnEntrar = false;

				Load = true;

				email = string.IsNullOrEmpty(email) ? "" : email;
				senha = string.IsNullOrEmpty(senha) ? "" : senha;

				//verifica se preencheu os campos corretamente
				if (email.Length < 5 && senha.Length < 3)
				{
					await App._alertService.ShowAsync("Erro!", "Email ou Senha incorretos!", "Ok");
					Load = false;
					BtnEntrar = true;
					return;
				}

				// monto o objeto a ser eviado
				Usuario user = new Usuario();
				user.email = email;
				user.senha = senha;

				// vamos verificar
				HttpResponseMessage response = await HttpService.Logar(user);


				switch ((int)response.StatusCode)
				{
					case 200:
						authenticated = JsonConvert.DeserializeObject<Authenticated>(response.Content.ReadAsStringAsync().Result);
						break;
					case 500:
						await App._alertService.ShowAsync("Erro de conexão", "Ocorreu um erro ao se conectar com o servidor, tente novamente!", "Ok");
						break;
					case 400:
						await App._alertService.ShowAsync("CPF ou Placa incorretos!", "Verifique o Email e Senha digitados e tente novamente.", "Ok");
						break;
					case 401:
						await App._alertService.ShowAsync("Usuário não autorizado", "Verifique o Email e Senha digitados e tente novamente.", "Ok");
						break;
					default:
						await App._alertService.ShowAsync("Opss...", "Erro ao se comunicar com o servidor, tente novamente.", "Ok");
						break;
				}

				// autenticando 
				if (authenticated != null)
				{


					// instancio o realm
					var realm = Realm.GetInstance();

					var myAuths = realm.All<AuthenticatedDAO>();

					if (myAuths.Count() > 0)
					{ // vamos atualizar

						var myAuth = realm.All<AuthenticatedDAO>().First();
						realm.Write(() =>
						{
							myAuth.idUsuario = authenticated.IdUsuario.ToString();
							myAuth.login = authenticated.Login;
							myAuth.AuthorizationToken = authenticated.AuthorizationToken;
						});

						Debug.WriteLine("Token Atualizado: " + myAuth.AuthorizationToken);
					}
					else
					{
						realm.Write(() =>
						{
							realm.Add(new AuthenticatedDAO { idUsuario = authenticated.IdUsuario.ToString(), login = authenticated.Login, AuthorizationToken = authenticated.AuthorizationToken });
						});

						Debug.WriteLine("Adicionado um novo token: " + authenticated.AuthorizationToken);

					}

					await App._navigationService.NavigateToMenuSlider();

				}
			}
			catch (Exception ex)
			{

				Debug.WriteLine("Erro ao logar: " + ex.Message);

			}
			finally { 
				Load = true;
				BtnEntrar = true;
			}

		}

	}
}
