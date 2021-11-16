using System;
using System.Collections.Generic;
using CryptoPanopticon.Logic;
using CryptoPanopticon.Logic.Classes;
using CryptoPanopticon.Logic.Interfaces;

namespace CryptoPanopticon.Data.Emulation
{
    public class EmulatedCryptoProvider:ICryptoProvider
    {
        private readonly Random _random;

        public EmulatedCryptoProvider()
        {
            Name = "Emulation Crypto";
            ShortName = "EMU";
            _random = new Random();
        }

        public string Name { get; }
        public string ShortName { get; }
        public List<CryptoData> GetHistoricalData(DateTime start, DateTime end)
        {
            var res = new List<CryptoData>();
            var date = start.Date;

            while (date.Date-end.Date!=TimeSpan.Zero)
            {
                res.Add(new CryptoData() {Date = date, Value = (decimal) _random.NextDouble() * 100});
                date = date.AddDays(1);
            }

            return res;
        }

        public CryptoData GetCurrentPrice()
        {
            return new CryptoData() {Date = DateTime.Today, Value = (decimal) _random.NextDouble() * 100};
        }
    }
}