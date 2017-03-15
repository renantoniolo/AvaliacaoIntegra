using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace AvaliacaoIntegra
{
	public partial class ListarClientesView : ContentPage
	{
		public ListarClientesView()
		{
			InitializeComponent();

			BindingContext = new ListarClientesViewModel();


		}
	}
}
