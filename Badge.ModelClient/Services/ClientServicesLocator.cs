using Patterns.Locator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelClient.Services
{
    public class ClientServicesLocator:LocatorBase
    {
        private static ClientServicesLocator _Instance;

        public static ClientServicesLocator Instance
        {
            get { return _Instance ?? (_Instance = new ClientServicesLocator()) ; }
        }

        private ClientServicesLocator()
        {
            Container.Register<CategoryService>();
            Container.Register<ProductService>();
            Container.Register<OrderLineService>();
            Container.Register<OrderService>();
        }

        public CategoryService GetCategoryService()
        {
            return Container.GetInstance<CategoryService>();
        }

        public ProductService GetProductService()
        {
            return Container.GetInstance<ProductService>();
        }

        public OrderLineService GetOrderLineService()
        {
            return Container.GetInstance<OrderLineService>();
        }

        public OrderService GetOrderService()
        {
            return Container.GetInstance<OrderService>();
        }

    }
}
