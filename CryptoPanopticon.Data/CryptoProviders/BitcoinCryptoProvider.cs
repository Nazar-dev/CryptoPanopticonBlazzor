using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using CryptoPanopticon.Logic.Classes;
using CryptoPanopticon.Logic.Interfaces;

namespace CryptoPanopticon.Data.CryptoProviders {
	
	
	public class BitcoinCryptoProvider:ICryptoProvider {
		public class Root
		{
			public List<List<double>> prices { get; set; }
		}
		public string Name { get; } = "Bitcoin";
		public string ShortName { get; } = "BTC";
		public List<CryptoData> GetHistoricalData(DateTime start, DateTime end) {
			HttpClient client = new HttpClient();
			var fromUX = ((DateTimeOffset)start).ToUnixTimeMilliseconds();
			var endUX = ((DateTimeOffset)end).ToUnixTimeMilliseconds();
			var requestURL = @$"https://api.blockchain.com/nabu-gateway/markets/exchange/prices?symbol=BTC-USD&start={fromUX}&end={endUX}&granularity=86400";
			
			var data=client.GetFromJsonAsync<Root>(requestURL).Result;
			return data.prices.Select((x, i) => new CryptoData() { Date = end.AddDays(-i), Value = (decimal)x[1] }).OrderBy(x=>x.Date).ToList();
		}
		public CryptoData GetCurrentPrice() {
			throw new NotImplementedException();
		}
	}
}