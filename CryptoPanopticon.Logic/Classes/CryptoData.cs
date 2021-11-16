using System;

namespace CryptoPanopticon.Logic.Classes
{
	public class CryptoData
	{
		public CryptoData() { }

		public CryptoData(DateTime date, decimal value) {
			this.Date = date;
			this.Value = value;
		}

		public DateTime Date { get; set; }
		public decimal Value { get; set; }
	}
}