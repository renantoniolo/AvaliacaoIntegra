using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AvaliacaoIntegra
{
	public partial class CadastroClienteView : ContentPage
	{
		public CadastroClienteView()
		{
			InitializeComponent();

			this.BindingContext = new CadastroClienteViewModel();

			// Alimenta o comboBox
			this.pckSexo.Items.Clear();
			pckSexo.Items.Add("Masculino");
			pckSexo.Items.Add("Feminino");


		}
	}
}
