using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.Utils.Mediator
{
    public class MediatorForHistory<TMessage>
    {
        private static MediatorForHistory<TMessage> _Instance;

        private event Action<TMessage> _Broadcast;

        public static MediatorForHistory<TMessage> Instance
        {
            get
            {
                return _Instance ?? (_Instance = new MediatorForHistory<TMessage>());
            }
        }

        public MediatorForHistory()
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
