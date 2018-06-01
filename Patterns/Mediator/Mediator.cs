using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Mediator
{
    public class Mediator<TMessage>
    {
        private static Mediator<TMessage> _Instance;

        private event Action<TMessage> _Broadcast;

        public static Mediator<TMessage> Instance
        {
            get
            {
                return _Instance ?? (_Instance = new Mediator<TMessage>());
            }
        }

        protected Mediator()
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
