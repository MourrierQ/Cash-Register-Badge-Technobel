using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.Utils.Mediator
{
    public class MediatorToProduct<TMessage>
    {
        private static MediatorToProduct<TMessage> _Instance;

        private event Action<TMessage> _Broadcast;

        public static MediatorToProduct<TMessage> Instance
        {
            get
            {
                return _Instance ?? (_Instance = new MediatorToProduct<TMessage>());
            }
        }

        public MediatorToProduct()
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
