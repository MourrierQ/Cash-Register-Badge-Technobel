using Badge.ModelClient.Models;
using Badge.ModelClient.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Badge.WebAPI.Controllers
{
    public class OrderLineController : ApiController
    {
        public IEnumerable<OrderLine> Get()
        {
            return ClientServicesLocator.Instance.GetOrderLineService().Get();
        }

        [HttpGet]
        [Route("api/OrderLinesByDate/{d}")]
        public IEnumerable<OrderLine> GetByDate(DateTime d)
        {
            return ClientServicesLocator.Instance.GetOrderLineService().GetByDate(d);
        }

        [HttpGet]
        [Route("api/ProductTotalByDate/{y}/{m}/{d}/{id}")]
        public decimal GetProductTotalByDate(int y, int m, int d, int id)
        {
            DateTime ReqDate = new DateTime(y, m, d);
            return ClientServicesLocator.Instance.GetOrderLineService().GetProductTotalByDate(ReqDate, id);
        }

        [HttpGet]
        [Route("api/GlobalTurnover")]
        public decimal GetGlobalTurnover()
        {
            return ClientServicesLocator.Instance.GetOrderLineService().GetGlobalTurnover();
        }

        [HttpGet]
        [Route("api/GlobalTurnover/{y}/{m}/{d}")]
        public decimal GetGlobalTurnoverByDate(int y, int m, int d)
        {
            DateTime ReqDate = new DateTime(y, m, d);
            return ClientServicesLocator.Instance.GetOrderLineService().GetGlobalTurnoverByDate(ReqDate);
        }

        [HttpGet]
        [Route("api/TotalVolunteer")]
        public decimal GetTotalVolunteer()
        {
            return ClientServicesLocator.Instance.GetOrderLineService().GetTotalVolunteer();
        }

        [HttpGet]
        [Route("api/TotalVolunteer/{y}/{m}/{d}")]
        public decimal GetTotalVolunteerByDate(int y, int m, int d)
        {
            DateTime ReqDate = new DateTime(y, m, d);
            return ClientServicesLocator.Instance.GetOrderLineService().GetTotalVolunteerByDate(ReqDate);
        }

        public void Post(OrderLine entity)
        {
            ClientServicesLocator.Instance.GetOrderLineService().Insert(entity);
        }

        [HttpPost]
        [Route("api/InsertOrderLines")]
        public void InsertAll(DataTable dt)
        {
            ClientServicesLocator.Instance.GetOrderLineService().InsertAll(dt);
        }
    }
}
