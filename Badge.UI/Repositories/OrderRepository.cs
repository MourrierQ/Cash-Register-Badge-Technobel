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
    public class OrderRepository:BaseRepository
    {

        public IEnumerable<Order> Get()
        {
            var res = Client.GetAsync("Order").Result;

            if (res.IsSuccessStatusCode)
            {
                string jsonResult = res.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<Order>>(jsonResult);
            }

            return null;
        }

        public int Insert(Order entity)
        {
            string json = JsonConvert.SerializeObject(entity);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var resultPost = Client.PostAsync("Order", content).Result;

            if (resultPost.IsSuccessStatusCode)
            {
                string jsonResult = resultPost.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<int>(jsonResult);
            }

            return 0;
        }
    }
}
