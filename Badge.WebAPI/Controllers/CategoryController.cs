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
    public class CategoryController : ApiController
    {
        public IEnumerable<Category> Get()
        {
            return ClientServicesLocator.Instance.GetCategoryService().Get();
        }

        public Category Get(int id)
        {
            return ClientServicesLocator.Instance.GetCategoryService().Get(id);
        }
    }
}
