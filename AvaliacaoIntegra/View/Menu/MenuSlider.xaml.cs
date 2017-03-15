using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AvaliacaoIntegra
{
	public partial class MenuSlider : ContentPage
	{
		public MenuSlider()
		{
			InitializeComponent();

			Title = "Menu";

			//Fundo do Menu
			BackgroundColor = Color.FromHex("#2d93ba");

			// espaçamento para nao grudar nas boras
			Padding = 10;

			// para iOS coocamos uma imgem de sanduiche
			Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : null;

			// viewModel
			this.BindingContext = new MenuSliderViewModel();
		}
	}
}
