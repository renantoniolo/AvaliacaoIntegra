using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace AvaliacaoIntegra
{
	public class MasterPage : MasterDetailPage
	{
		public MasterPage()
		{
			try
			{
				NavigationPage.SetHasNavigationBar(this, false);
				Master = new MenuSlider();

				Detail = new NavigationPage(new ListarClientesView())
				{

				};

			}
			catch (Exception ex)
			{
				Debug.WriteLine("Falha ao abrir o menu slider. Error: " + ex.Message);
			}
		}

	}
}
