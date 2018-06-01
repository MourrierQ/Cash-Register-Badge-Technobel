using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Badge.UI.Repositories
{
    public abstract class BaseRepository
    {
        private const string str_uri = "http://localhost:61410/api/";

        private HttpClient _Client;

        protected HttpClient Client
        {
            get { return _Client; }
            private set
            {
                _Client = value;
            }
        }

        public BaseRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(str_uri);
        }

    }
}
