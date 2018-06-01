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
    public class ProductController : ApiController
    {
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ClientServicesLocator.Instance.GetProductService().Get();
        }

        [HttpGet]
        public Product Get(int id)
        {
            return ClientServicesLocator.Instance.GetProductService().Get(id);
        }

        [HttpGet]
        [Route("api/productByCategory/{CatId}")]
        public IEnumerable<Product> FetchByCategory(int CatId)
        {
            return ClientServicesLocator.Instance.GetProductService().GetByCategory(CatId);
        }
    }
}
