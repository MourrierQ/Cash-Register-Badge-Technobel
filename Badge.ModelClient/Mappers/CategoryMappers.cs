using C = Badge.ModelClient.Models;
using G = Badge.ModelGlobal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelClient.Mappers
{
    internal static class CategoryMappers
    {
        public static G.Category ToGlobal(this C.Category entity)
        {
            return new G.Category()
            {
                Id = entity.ID,
                CategoryName = entity.CategoryName
            };
        }

        public static C.Category ToClient(this G.Category entity)
        {
            return new C.Category(entity.Id, entity.CategoryName);
        }
    }
}
