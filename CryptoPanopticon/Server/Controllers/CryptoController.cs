using System.Collections.Generic;
using System.Linq;
using CryptoPanopticon.Logic;
using CryptoPanopticon.Logic.Classes;
using CryptoPanopticon.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CryptoPanopticon.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoController : ControllerBase
    {
        private readonly CryptoCurrencyService _service;

        public CryptoController(CryptoCurrencyService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<SharedCryptoData> GetData()
        {
            var data = _service.GetCurrencyChartData();//Example past week
            return data.Select(x => new SharedCryptoData() { Name = x.Name, Data = x.Data.Select(z => z.Value).ToList() }).ToList();
        }
    }
}