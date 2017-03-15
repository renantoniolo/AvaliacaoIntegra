using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AvaliacaoIntegra
{
	public abstract class HttpService
	{
		
		public async static Task<HttpResponseMessage> Logar(Usuario user)
		{

			// conecto na API 
			HttpResponseMessage response = await HttpUtil.PostAsync(PathUtil.SRV_ATIVO + "/api/account/login",user);

			return response;
		}


		public async static Task<HttpResponseMessage> CadastrarCliente(Cliente cliente)
		{

			// conecto na API 
			HttpResponseMessage response = await HttpUtil.PostAsyncToken(PathUtil.SRV_ATIVO + "/api/Clientes/Add", cliente,null,true,true);

			return response;
		}


		public async static Task<List<ClienteFoto>> GetListaClientes()
		{

			// conecto na API 
			HttpResponseMessage response = await HttpUtil.GetAsync(PathUtil.SRV_ATIVO + "/api/Clientes/GetAll",true);

			// recebo uma lista de clientes
			List<ClienteFoto> clientes = JsonConvert.DeserializeObject<List<ClienteFoto>>(response.Content.ReadAsStringAsync().Result);

			return clientes;
		}


	}
}
