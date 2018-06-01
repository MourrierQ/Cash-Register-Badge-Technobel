using ADOToolbox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelGlobal.Services
{
    public abstract class BaseRepository
    {
        private  Connection _context;

        protected  Connection Context
        {
            get
            {
                return _context;
            }

            private set
            {
                _context = value;
            }
        }

        public BaseRepository()
        {
            Context = AccessLocator.Instance.GetConnection();
        }

    }
}
