using Badge.ModelClient.Mappers;
using Badge.ModelClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelClient.Services
{
    public class ProductService
    {
        public IEnumerable<Product> Get()
        {
            return GlobalServicesLocator.Instance.GetProductRepository().Get().Select(p => p.ToClient());
        }

        public Product Get(int id)
        {
            return GlobalServicesLocator.Instance.GetProductRepository().Get(id).ToClient();
        }

        public IEnumerable<Product> GetByCategory(int categoryID)
        {
            return GlobalServicesLocator.Instance.GetProductRepository().GetByCategory(categoryID).Select(p => p.ToClient());
        }
    }
}
