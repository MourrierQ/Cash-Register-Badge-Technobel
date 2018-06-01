using Badge.ModelClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.Repositories
{
    public class ProductRepository:BaseRepository
    {
        public IEnumerable<Product> Get()
        {
            HttpResponseMessage resultGetAll = Client.GetAsync("Product").Result;
            if (resultGetAll.IsSuccessStatusCode)
            {
                string jsonResult = resultGetAll.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonResult);
            }
            return null;
        }

        public IEnumerable<Product> GetByCategory(int CatId)
        {
            HttpResponseMessage resultGetAll = Client.GetAsync($"productByCategory/{CatId}").Result;
            if (resultGetAll.IsSuccessStatusCode)
            {
                string jsonResult = resultGetAll.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonResult);
            }
            return null;
        }
    }
}
