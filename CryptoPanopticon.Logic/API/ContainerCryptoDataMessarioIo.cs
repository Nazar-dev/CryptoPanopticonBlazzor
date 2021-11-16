using System;
using System.Collections.Generic;

namespace CryptoPanopticon.Logic.API {
	public class ContainerCryptoDataMessarioIo {
		public Dictionary<string, string> status { get; set; }
		public Dictionary<string, dynamic> data { get; set; }

		public string GetPriceToday() => this.data["market_data"]["price_usd"];

		public DateTime GetTime() => DateTime.Parse(this.status["timestamp"]);

		public string GetPriceLast1Week() {
			return Count(GetPriceToday(), GetPastPriceData("percent_change_last_1_week")).ToString();
		}

		public string GetPriceLast1Month() {
			return Count(GetPriceToday(), GetPastPriceData("percent_change_last_1_month")).ToString();
		}

		public string GetPriceLast3Months() {
			return Count(GetPriceToday(), GetPastPriceData("percent_change_last_3_months")).ToString();
		}

		public string GetPriceLast1Year() {
			return Count(GetPriceToday(), GetPastPriceData("percent_change_last_1_year")).ToString();
		}

		private string GetPastPriceData(string pastTime) => this.data["roi_data"][pastTime];

		private double Count(string number1, string number2) {
			//TODO it`s not working, need to count persent, not to sum
			return double.Parse(number1) + double.Parse(number2);
		}
	}
}