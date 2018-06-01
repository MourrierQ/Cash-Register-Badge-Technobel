using G = Badge.ModelGlobal.Models;
using C = Badge.ModelClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelClient.Mappers
{
    internal static class ProductMappers
    {
        public static G.Product ToGlobal(this C.Product entity)
        {
            return new G.Product()
            {
                Id = entity.ID,
                ProductName = entity.ProductName,
                Price = entity.Price,
                CategoryID = entity.CategoryID
            };
        }

        public static C.Product ToClient(this G.Product entity)
        {
            return new C.Product(entity.Id, entity.ProductName, entity.Price, entity.CategoryID);
        }
    }
}
