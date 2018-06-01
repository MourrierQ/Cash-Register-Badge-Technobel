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
    public class OrderRepository:BaseRepository
    {
        public IEnumerable<Order> Get()
        {
            Command cmd = new Command("SELECT Id, OrderTime FROM Order");
            return Context.ExecuteReader(cmd, o => o.ToOrder());
        }

        public int Insert(Order entity)
        {
            Command cmd = new Command("INSERT INTO [Order](Volunteer) OUTPUT inserted.id VALUES(@Volunteer)");
            cmd.AddParameter("Volunteer", entity.Volunteer);

            return (int)Context.ExecuteScalar(cmd);
        }
    }
}
