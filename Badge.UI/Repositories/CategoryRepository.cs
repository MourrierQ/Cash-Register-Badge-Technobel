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
    public class CategoryRepository : BaseRepository
    {
        public IEnumerable<Category> Get()
        {
            HttpResponseMessage resultGetAll = Client.GetAsync("Category").Result;
            if (resultGetAll.IsSuccessStatusCode)
            {
                string jsonResult = resultGetAll.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<Category>>(jsonResult);
            }
            return null;
        }
    }
}
