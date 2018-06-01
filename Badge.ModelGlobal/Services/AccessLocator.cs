using ADOToolbox;
using Patterns.Locator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelGlobal.Services
{
    public class AccessLocator : LocatorBase
    {
        private static AccessLocator _Instance;

        public static AccessLocator Instance
        {
            get
            {
                return _Instance ?? (_Instance = new AccessLocator());
            }
        }

        private AccessLocator()
        {
            Container.Register<Connection>("Data Source=localhost;Initial Catalog=BadgeDB;Integrated Security=True", "System.Data.SqlClient");   
        }

        public Connection GetConnection()
        {
            return Container.GetInstance<Connection>();
        }

    }
}
