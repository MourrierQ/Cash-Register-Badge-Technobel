using Patterns.Locator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.Repositories
{
    public class RepositoryLocator: LocatorBase
    {
        private static RepositoryLocator _Instance;

        public static RepositoryLocator Instance
        {
            get { return _Instance ?? (_Instance = new RepositoryLocator()); }
        }

        private RepositoryLocator()
        {
            Container.Register<CategoryRepository>();
            Container.Register<ProductRepository>();
            Container.Register<OrderRepository>();
            Container.Register<OrderLineRepository>();
        }

        public CategoryRepository GetCategoryRepository()
        {
            return Container.GetInstance<CategoryRepository>();
        }

        public ProductRepository GetProductRepository()
        {
            return Container.GetInstance<ProductRepository>();
        }

        public OrderRepository GetOrderRepository()
        {
            return Container.GetInstance<OrderRepository>();
        }

        public OrderLineRepository GetOrderLineRepository()
        {
            return Container.GetInstance<OrderLineRepository>();
        }

    }
}
