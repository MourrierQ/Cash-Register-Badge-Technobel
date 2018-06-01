using C = Badge.ModelClient.Models;
using G = Badge.ModelGlobal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelClient.Mappers
{
    public static class OrderMappers
    {
        public static G.Order ToGlobal(this C.Order entity)
        {
            return new G.Order()
            {
                OrderTime = entity.OrderTime,
                Volunteer = entity.Volunteer
            };
        }

        public static C.Order ToClient(this G.Order entity)
        {
            return new C.Order(entity.Volunteer);
        }
    }
}
