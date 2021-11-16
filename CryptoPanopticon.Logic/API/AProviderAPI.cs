using System;
using CryptoPanopticon.Logic.Classes;

namespace CryptoPanopticon.Logic.API {
	public abstract class AProviderApi : ApiDataMessariIo {
		
		protected ContainerCryptoDataMessarioIo _data;

		protected AProviderApi() {SetCryptoDate(); }
		protected abstract void SetCryptoDate();

		public CryptoData GetHistoricalData(EPastDatePeriods period) {

			return period switch {
				EPastDatePeriods.Past1Week => new CryptoData(
					date: this._data.GetTime().AddDays(-7),
					value: Convert.ToDecimal(this._data.GetPriceLast1Week())),
				EPastDatePeriods.Past1Month => new CryptoData(
					date: this._data.GetTime().AddMonths(-1),
					value: Convert.ToDecimal(this._data.GetPriceLast1Month())),
				EPastDatePeriods.Past3Months => new CryptoData(
					date: this._data.GetTime().AddMonths(-3),
					value: Convert.ToDecimal(this._data.GetPriceLast3Months())),
				EPastDatePeriods.Past1Year => new CryptoData(
					date: this._data.GetTime().AddYears(-1),
					value: Convert.ToDecimal(this._data.GetPriceLast1Year())),
				_ => throw new ArgumentOutOfRangeException(nameof(period), period, null)
			};
		}

		public CryptoData GetCurrentPrice() {
			return new CryptoData(
				date: this._data.GetTime(),
				value: Convert.ToDecimal(this._data.GetPriceToday()));
		}
	}
}