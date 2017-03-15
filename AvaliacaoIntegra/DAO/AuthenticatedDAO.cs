using System;
using System.Collections.Generic;
using Realms;

namespace AvaliacaoIntegra
{
	
	public class AuthenticatedDAO : RealmObject
	{
		public string idUsuario { get; set; }
		public string login { get; set; }
		public string AuthorizationToken { get; set; }
		public Auth Owner { get; set; }
	}

	public class Auth : RealmObject
	{
		public string Name { get; set; }
		public IList<AuthenticatedDAO> Usuarios { get; }
	}

}
