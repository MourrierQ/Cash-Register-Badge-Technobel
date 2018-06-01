using ADOToolbox;
using Badge.ModelGlobal.Mappers;
using Badge.ModelGlobal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelGlobal.Services
{
    public class OrderLineRepository:BaseRepository
    {
        public IEnumerable<OrderLine> Get()
        {
            Command cmd = new Command("SELECT * FROM OrderLine");
            return Context.ExecuteReader(cmd, ol => ol.ToOrderLine());
        }

        public OrderLine Get(int id)
        {
            Command cmd = new Command("SELECT * FROM OrderLine WHERE Id = @Id");
            cmd.AddParameter("Id", id);
            return Context.ExecuteReader(cmd, ol => ol.ToOrderLine()).SingleOrDefault();
        }

        public IEnumerable<OrderLine> GetByDate(DateTime begin)
        {
    
            DateTime end = new DateTime();
            TimeSpan ts  = new TimeSpan(7, 0, 0);
            end          = begin.Add(ts);
            Command cmd  = new Command("SELECT * FROM OrderLine ol JOIN [Order] o ON ol.OrderId = o.Id WHERE o.OrderDate BETWEEN @begin AND @end");
            cmd.AddParameter("begin", begin);
            cmd.AddParameter("end", end);

            return Context.ExecuteReader(cmd, ol => ol.ToOrderLine());
        }

        public decimal GetProductTotalByDate(DateTime begin, int id)
        {
            DateTime ValidBegin = new DateTime(begin.Year, begin.Month, begin.Day, 18, 0, 0);
            DateTime end = new DateTime();
            TimeSpan ts = new TimeSpan(7, 0, 0);
            end = ValidBegin + ts;
            Command cmd = new Command("Stp_ProductTotalByDate", true);
            cmd.AddParameter("begin", ValidBegin);
            cmd.AddParameter("end", end);
            cmd.AddParameter("Id", id);
            object res = Context.ExecuteScalar(cmd);
            if (res == null)
            {
                return 0;
            }
            return (decimal)res;
        }

        public decimal GetTotalVolunteerByDate(DateTime begin)
        {
            DateTime ValidBegin = new DateTime(begin.Year, begin.Month, begin.Day, 18, 0, 0);
            DateTime end = new DateTime();
            TimeSpan ts = new TimeSpan(9, 0, 0);
            end = ValidBegin + ts;
            Command cmd = new Command("StP_GetTotalVolunteerByDate", true);
            cmd.AddParameter("begin", ValidBegin);
            cmd.AddParameter("end", end);
            object res = Context.ExecuteScalar(cmd);
            if (res == null)
                return 0;

            return (decimal)res;
        }

        public decimal GetTurnoverByDate(DateTime begin)
        {
            DateTime ValidBegin = new DateTime(begin.Year, begin.Month, begin.Day, 18, 0, 0);
            DateTime end = new DateTime();
            TimeSpan ts = new TimeSpan(9, 0, 0);
            end = ValidBegin + ts;
            Command cmd = new Command("StP_GetTurnoverByDate", true);
            cmd.AddParameter("begin", ValidBegin);
            cmd.AddParameter("end", end);
            object res = Context.ExecuteScalar(cmd);
            if (res == null)
                return 0;

            return (decimal)res;
        }

        public decimal GetGlobalTurnover()
        {
            Command cmd = new Command("StP_GetGlobalTurnover", true);
            object res = Context.ExecuteScalar(cmd);
            if (res == null)
                return 0;

            return (decimal)res;
        }

        public decimal GetTotalVolunteer()
        {
            Command cmd = new Command("StP_GetGlobalTotalVolunteer", true);
            object res = Context.ExecuteScalar(cmd);
            if (res == null)
                return 0;

            return (decimal)res;
        }

        public void Insert(OrderLine entity)
        {
            Command cmd = new Command("INSERT INTO OrderLine(OrderID, ProductID, Price, Quantity) VALUES(@OrderID, @ProductID, @Price, @Quantity) ");
            cmd.AddParameter("OrderID", entity.OrderID);
            cmd.AddParameter("ProductID", entity.ProductID);
            cmd.AddParameter("Price", entity.Price);
            cmd.AddParameter("Quantity", entity.Quantity);

            Context.ExecuteNonQuery(cmd);
        }

        public void InsertAll(DataTable entities)
        {
            Command cmd = new Command("StP_InsertOrderLines", true);
            cmd.AddParameter("NewOrderLines", entities);

            Context.ExecuteNonQuery(cmd);
        }
    }
}
