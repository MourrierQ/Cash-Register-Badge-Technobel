using C = Badge.ModelClient.Models;
using G = Badge.ModelGlobal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelClient.Mappers
{
    public static class OrderLineMappers
    {
        public static G.OrderLine ToGlobal(this C.OrderLine entity)
        {
            return new G.OrderLine()
            {
                OrderID = entity.OrderID,
                ProductID = entity.ProductID,
                Price = entity.Price,
                Quantity = entity.Quantity
            };
        }

        public static C.OrderLine ToClient(this G.OrderLine entity)
        {
            return new C.OrderLine(entity.OrderID, entity.ProductID, entity.Price, entity.Quantity);
        }
    }
}
