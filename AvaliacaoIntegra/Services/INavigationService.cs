using System;
using System.Threading.Tasks;

namespace AvaliacaoIntegra
{
	public interface INavigationService 
	{
		Task NavigateToMenuSlider();

		Task NavigateToListaClientes();

		Task NavigateToCadastroCliente();

		Task NavigateToLogin();
	}
}
