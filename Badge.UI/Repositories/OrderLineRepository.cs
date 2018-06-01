using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.Repositories
{
    public class OrderLineRepository: BaseRepository
    {
        public int InsertAll(DataTable dt)
        {
            string json = JsonConvert.SerializeObject(dt);

            HttpContent Content = new StringContent(json, Encoding.UTF8, "application/json");
            var ResultPost = Client.PostAsync("InsertOrderLines", Content).Result;

            if (ResultPost.IsSuccessStatusCode)
                return 1;
            return 0;
        }

        public decimal GetProductTotalByDate(DateTime d, int id)
        {
            HttpResponseMessage ResultGetTotal = Client.GetAsync($"ProductTotalByDate/{d.Year}/{d.Month}/{d.Day}/{id}").Result;

            if (ResultGetTotal.IsSuccessStatusCode)
            {
                string jsonResult = ResultGetTotal.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<decimal>(jsonResult);
            }

            return -1;
                
        }

        public decimal GetGlobalTurnover()
        {
            HttpResponseMessage Res = Client.GetAsync("GlobalTurnover").Result;

            if (Res.IsSuccessStatusCode)
            {
                string jsonRes = Res.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<decimal>(jsonRes);
            }

            return -1;
        }

        public decimal GetGlobalTurnoverByDate(DateTime d)
        {
            HttpResponseMessage Res = Client.GetAsync($"GlobalTurnover/{d.Year}/{d.Month}/{d.Day}").Result;

            if (Res.IsSuccessStatusCode)
            {
                string jsonRes = Res.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<decimal>(jsonRes);
            }

            return -1;
        }

        public decimal GetTotalVolunteer()
        {
            HttpResponseMessage Res = Client.GetAsync("TotalVolunteer").Result;

            if (Res.IsSuccessStatusCode)
            {
                string jsonRes = Res.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<decimal>(jsonRes);
            }

            return -1;
        }

        public decimal GetTotalVolunteerByDate(DateTime d)
        {
            HttpResponseMessage Res = Client.GetAsync($"TotalVolunteer/{d.Year}/{d.Month}/{d.Day}").Result;

            if (Res.IsSuccessStatusCode)
            {
                string jsonRes = Res.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<decimal>(jsonRes);
            }

            return -1;
        }
    }
}
