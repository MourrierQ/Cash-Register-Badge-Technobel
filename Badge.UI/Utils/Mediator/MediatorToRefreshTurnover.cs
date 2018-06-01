using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.Utils.Mediator
{
    public class MediatorToRefreshTurnover
    {
        private static MediatorToRefreshTurnover _Instance;

        private event Action _Broadcast;

        public static MediatorToRefreshTurnover Instance
        {
            get
            {
                return _Instance ?? (_Instance = new MediatorToRefreshTurnover());
            }
        }

        public MediatorToRefreshTurnover()
        {

        }

        public void Register(Action method)
        {
            _Broadcast += method;
        }

        public void Unregister(Action method)
        {
            _Broadcast -= method;
        }

        public void Send()
        {
            _Broadcast?.Invoke();
        }
    }
}
