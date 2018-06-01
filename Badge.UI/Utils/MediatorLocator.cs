using Badge.ModelClient.Models;
using Badge.UI.Utils.Mediator;
using Patterns.Locator;
using Patterns.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.Utils
{
    public class MediatorLocator:LocatorBase
    {
        private static MediatorLocator _Instance;

        public static MediatorLocator Instance
        {
            get { return _Instance ?? (_Instance = new MediatorLocator()); }
        }

        public MediatorLocator()
        {
            Container.Register<Mediator<Product>>();
            Container.Register<MediatorToProduct<int>>();
            Container.Register<MediatorToOrder<int>>();
            Container.Register<MediatorForTotal>();
            Container.Register<MediatorForHistory<DateTime>>();
            Container.Register<MediatorToRefreshTurnover>();
        }

        public Mediator<Product> GetMediator()
        {
            return Container.GetInstance<Mediator<Product>>();
        }

        public MediatorToProduct<int> GetMediatorToProduct()
        {
            return Container.GetInstance<MediatorToProduct<int>>();
        }

        public MediatorToOrder<int> GetMediatorToOrder()
        {
            return Container.GetInstance<MediatorToOrder<int>>();
        }

        public MediatorForTotal GetMediatorForTotal()
        {
            return Container.GetInstance<MediatorForTotal>();
        }

        public MediatorForHistory<DateTime> GetMediatorForHistory()
        {
            return Container.GetInstance<MediatorForHistory<DateTime>>();
        }

        public MediatorToRefreshTurnover GetMediatorToRefreshTurnover()
        {
            return Container.GetInstance<MediatorToRefreshTurnover>();
        }

    }
}
