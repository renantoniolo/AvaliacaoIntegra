using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AvaliacaoIntegra
{
	public partial class LoginView : ContentPage
	{
		public LoginView()
		{
			InitializeComponent();

			NavigationPage.SetHasNavigationBar(this, false);

			this.BindingContext = new LoginViewModel();

		}
	}
}
