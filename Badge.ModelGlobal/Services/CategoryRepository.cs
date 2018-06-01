using ADOToolbox;
using Badge.ModelGlobal.Mappers;
using Badge.ModelGlobal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelGlobal.Services
{
    public  class CategoryRepository : BaseRepository
    {
        public IEnumerable<Category> Get()
        {
            Command cmd = new Command("SELECT * FROM Category");
            return Context.ExecuteReader(cmd, c => c.ToCategory());
        }

        public  Category Get(int Id)
        {
            Command cmd = new Command("SELECT * FROM Category WHERE Id = @Id");
            cmd.AddParameter("Id", Id);

            return Context.ExecuteReader(cmd, c => c.ToCategory()).SingleOrDefault();
        }
    }
}
