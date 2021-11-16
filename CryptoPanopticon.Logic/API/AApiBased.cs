using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoPanopticon.Logic.API {
	public abstract class AApiBased {
		protected string GetDataFrom(string apiUrl) {
			HttpClient client = new HttpClient();
			Task<string> stringAsync = client.GetStringAsync(apiUrl);
			return stringAsync.Result;
		}
	}
}