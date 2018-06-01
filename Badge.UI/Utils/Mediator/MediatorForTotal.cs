using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.Utils.Mediator
{
    public class MediatorForTotal
    {
        private static MediatorForTotal _Instance;

        private event Action _Broadcast;

        public static MediatorForTotal Instance
        {
            get
            {
                return _Instance ?? (_Instance = new MediatorForTotal());
            }
        }

        public MediatorForTotal()
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
