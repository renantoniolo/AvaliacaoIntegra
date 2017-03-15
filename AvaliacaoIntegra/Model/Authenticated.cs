using System;
using Newtonsoft.Json;

namespace AvaliacaoIntegra
{
	public class Authenticated
	{
		[JsonIgnore]
		//[PrimaryKey, NotNull]
		public int IdUsuario { get; set; }

		//[NotNull]
		public string Login { get; set; }

		//[NotNull]
		public string AuthorizationToken { get; set; }

	}
}
