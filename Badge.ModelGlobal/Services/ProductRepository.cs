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
    public class ProductRepository : BaseRepository
    {
        public IEnumerable<Product> Get()
        {
            Command cmd = new Command("SELECT * FROM Product");
            return Context.ExecuteReader(cmd, p => p.ToProduct());
        }

        public Product Get(int Id)
        {
            Command cmd = new Command("SELECT * FROM Product WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return Context.ExecuteReader(cmd, p => p.ToProduct()).SingleOrDefault();
        }

        public IEnumerable<Product> GetByCategory(int categoryID)
        {
            Command cmd = new Command("SELECT * FROM Product WHERE CategoryID = @CategoryID");
            cmd.AddParameter("CategoryID", categoryID);
            return Context.ExecuteReader(cmd, p => p.ToProduct());
        }
    }
}
