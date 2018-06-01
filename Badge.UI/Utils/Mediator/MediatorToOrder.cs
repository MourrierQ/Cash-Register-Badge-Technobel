using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.Utils.Mediator
{
    public class MediatorToOrder<TMessage>
    {
        private static MediatorToOrder<TMessage> _Instance;

        private event Action<TMessage> _Broadcast;

        public static MediatorToOrder<TMessage> Instance
        {
            get
            {
                return _Instance ?? (_Instance = new MediatorToOrder<TMessage>());
            }
        }

        public MediatorToOrder()
        {

        }

        public void Register(Action<TMessage> method)
        {
            _Broadcast += method;
        }

        public void Unregister(Action<TMessage> method)
        {
            _Broadcast -= method;
        }

        public void Send(TMessage message)
        {
            _Broadcast?.Invoke(message);
        }
    }
}
