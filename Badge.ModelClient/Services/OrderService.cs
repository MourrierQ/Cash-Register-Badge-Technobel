using Badge.ModelClient.Mappers;
using Badge.ModelClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelClient.Services
{
    public class OrderService
    {
        public int Insert(Order entity)
        {
           return GlobalServicesLocator.Instance.GetOrderRepository().Insert(entity.ToGlobal());
        }

        public IEnumerable<Order> Get()
        {
            return GlobalServicesLocator.Instance.GetOrderRepository().Get().Select(o => o.ToClient());
        }
    }
}
