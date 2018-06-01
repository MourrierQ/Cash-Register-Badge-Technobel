using Badge.ModelClient.Models;
using Badge.ModelClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Badge.WebAPI.Controllers
{
    public class OrderController : ApiController
    {
        public IEnumerable<Order> Get()
        {
            return ClientServicesLocator.Instance.GetOrderService().Get();
        }

        public int Post(Order entity)
        {
            return ClientServicesLocator.Instance.GetOrderService().Insert(entity);
        }
    }
}
