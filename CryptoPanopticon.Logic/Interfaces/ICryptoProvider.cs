using System;
using System.Collections.Generic;
using CryptoPanopticon.Logic.Classes;

namespace CryptoPanopticon.Logic.Interfaces
{
	public interface ICryptoProvider
	{
		string Name { get; }
		string ShortName { get; }
		List<CryptoData> GetHistoricalData(DateTime start, DateTime end);
		CryptoData GetCurrentPrice();
	}
}