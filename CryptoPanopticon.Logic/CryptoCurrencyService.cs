using System;
using System.Collections.Generic;
using System.Linq;
using CryptoPanopticon.Logic.Classes;
using CryptoPanopticon.Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoPanopticon.Logic
{
    public class CryptoCurrencyService
    {
        private readonly IServiceProvider _serviceProvider;
        

        public CryptoCurrencyService(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        
        }

        public List<CryptoSet> GetCurrencyChartData() {
            var all = _serviceProvider.GetServices(typeof(ICryptoProvider)) as IEnumerable<ICryptoProvider>;
            List<CryptoSet> res = new List<CryptoSet>();
            var start = DateTime.Today.AddMonths(-1);
            var end = DateTime.Today;
            foreach (var provider in all) 
            {
                res.Add(new CryptoSet()
                {
                    Data = provider.GetHistoricalData(start,end),
                    Name = provider.Name
                });
            }

            return res;
        }
    }
}