using Badge.ModelClient.Mappers;
using Badge.ModelClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelClient.Services
{
    public class CategoryService
    {
        public IEnumerable<Category> Get()
        {
            return GlobalServicesLocator.Instance.GetCategoryRepository().Get().Select(c => c.ToClient());
        }

        public Category Get(int id)
        {
            return GlobalServicesLocator.Instance.GetCategoryRepository().Get(id).ToClient();
        }
    }
}
