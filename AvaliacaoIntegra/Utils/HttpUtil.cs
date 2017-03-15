using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Realms;

namespace AvaliacaoIntegra
{
	public abstract class HttpUtil
	{

		public static HttpResponseMessage Get(string url)
		{
			using (HttpClient client = new HttpClient())
			{
				return client.GetAsync(url).Result;
			}
		}

		/*
		public static async Task<HttpResponseMessage> GetAsync(string url)
		{
			using (HttpClient client = new HttpClient())
			{
				return await client.GetAsync(url);
			}
		}
		*/


		public static async Task<HttpResponseMessage> GetAsync(string url, bool token = false)
		{
			using (HttpClient client = new HttpClient())
			{

				if (token)
				{
					// instancio o realm
					var realm = Realm.GetInstance();
					var myAuths = realm.All<AuthenticatedDAO>();
					var myAuth = realm.All<AuthenticatedDAO>().First();
					Debug.WriteLine("Token" + myAuth.AuthorizationToken);
					client.DefaultRequestHeaders.Clear();
					client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", myAuth.AuthorizationToken);

				}
				return await client.GetAsync(url);
			}
		}

		public static HttpResponseMessage Post(string url, object content = null)
		{
			using (HttpClient client = new HttpClient())
			{
				string jsonString = JsonConvert.SerializeObject(content);

				using (HttpContent httpContent = new StringContent(jsonString))
				{
					httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

					return client.PostAsync(url, httpContent).Result;
				}
			}
		}

		public static async Task<HttpResponseMessage> PostAsync(string url, object content = null)
		{
			using (HttpClient client = new HttpClient())
			{
				string jsonString = JsonConvert.SerializeObject(content);

				using (HttpContent httpContent = new StringContent(jsonString))
				{
					httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

					return await client.PostAsync(url, httpContent);
				}
			}
		}

		public static async Task<HttpResponseMessage> PostAsyncToken(string url, object content = null, string contentString = null, bool json = true, bool token = false)
		{
			using (HttpClient client = new HttpClient())
			{
				if (json)
				{
					string jsonString = JsonConvert.SerializeObject(content);

					using (HttpContent httpContent = new StringContent(jsonString))
					{
						if (token)
						{
							var realm = Realm.GetInstance();
							var myAuths = realm.All<AuthenticatedDAO>();
							var myAuth = realm.All<AuthenticatedDAO>().First();
							Debug.WriteLine("Token" + myAuth.AuthorizationToken);
							client.DefaultRequestHeaders.Clear();
							client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", myAuth.AuthorizationToken);
						}

						httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

						return client.PostAsync(url, httpContent).Result;
					}
				}
				else
				{
					using (HttpContent httpContent = new StringContent(contentString))
					{
						//client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");

						httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

						return client.PostAsync(url, httpContent).Result;
					}
				}
			}
		}

		public static HttpResponseMessage Put(string url, object content = null)
		{
			using (HttpClient client = new HttpClient())
			{
				string jsonString = JsonConvert.SerializeObject(content);

				using (HttpContent httpContent = new StringContent(jsonString))
				{
					httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

					return client.PutAsync(url, httpContent).Result;
				}
			}
		}

		public static async Task<HttpResponseMessage> PutAsync(string url, object content = null)
		{
			using (HttpClient client = new HttpClient())
			{
				string jsonString = JsonConvert.SerializeObject(content);

				using (HttpContent httpContent = new StringContent(jsonString))
				{
					httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

					return await client.PutAsync(url, httpContent);
				}
			}
		}


		public static HttpResponseMessage Delete(string url)
		{
			using (HttpClient client = new HttpClient())
			{
				return client.DeleteAsync(url).Result;
			}
		}

		public static async Task<HttpResponseMessage> DeleteAsync(string url)
		{
			using (HttpClient client = new HttpClient())
			{
				return await client.DeleteAsync(url);
			}
		}

	}
}
