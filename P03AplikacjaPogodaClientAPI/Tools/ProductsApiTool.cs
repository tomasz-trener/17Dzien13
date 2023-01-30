using Microsoft.Extensions.Configuration;
using P03AplikacjaPogodaClientAPI.Models.CityModel;
using P05Sklep.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P03AplikacjaPogodaClientAPI.Tools
{
    internal class ProductsApiTool
    {
        private string _baseURl;
        public ProductsApiTool()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<App>();
            //.SetBasePath(Directory.GetCurrentDirectory()) // odwołanie do pliku konfiguracyjnego 
            // .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            _baseURl = configuration["products_base_url"];
        }

        public async Task<Product[]> GetProducts()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseURl);
                var result = await client.GetFromJsonAsync <ServiceReponse<Product[]>>("api/product");

                return result.Data;
            }
        }
}
}
