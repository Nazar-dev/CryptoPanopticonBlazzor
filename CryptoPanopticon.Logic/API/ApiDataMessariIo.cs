using Newtonsoft.Json;

namespace CryptoPanopticon.Logic.API {
	public class ApiDataMessariIo : AApiBased {
		private string GenApiUrl(string cryptoShortName) {
			return $"https://data.messari.io/api/v1/assets/{cryptoShortName}/metrics";
		}

		protected ContainerCryptoDataMessarioIo GetBitcoinData() {
			string apiUrl = GenApiUrl("btc");
			string dataFrom = base.GetDataFrom(apiUrl);

			var container = JsonConvert.DeserializeObject<ContainerCryptoDataMessarioIo>(dataFrom);
			return container;
		}

		protected ContainerCryptoDataMessarioIo GetEthereumData() {
			string apiUrl = GenApiUrl("eth");
			string dataFrom = base.GetDataFrom(apiUrl);

			var container = JsonConvert.DeserializeObject<ContainerCryptoDataMessarioIo>(dataFrom);
			return container;
		}

		protected ContainerCryptoDataMessarioIo GetBinanceData() {
			string apiUrl = GenApiUrl("bnb");
			string dataFrom = base.GetDataFrom(apiUrl);

			var container = JsonConvert.DeserializeObject<ContainerCryptoDataMessarioIo>(dataFrom);
			return container;
		}
	}
}