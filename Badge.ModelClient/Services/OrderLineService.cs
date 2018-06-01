using Badge.ModelClient.Mappers;
using G = Badge.ModelGlobal.Models;
using Badge.ModelClient.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelClient.Services
{
    public class OrderLineService
    {
        public IEnumerable<OrderLine> Get()
        {
            return GlobalServicesLocator.Instance.GetOrderLineRepository().Get().Select(ol => ol.ToClient());
        }

        public IEnumerable<OrderLine> GetByDate(DateTime d)
        {
            return GlobalServicesLocator.Instance.GetOrderLineRepository().GetByDate(d).Select(ol => ol.ToClient());
        }

        public decimal GetProductTotalByDate(DateTime d, int id)
        {
            return GlobalServicesLocator.Instance.GetOrderLineRepository().GetProductTotalByDate(d, id);
        }

        public void Insert(OrderLine entity)
        {
            GlobalServicesLocator.Instance.GetOrderLineRepository().Insert(entity.ToGlobal());
        }
        
        /// <summary>
        /// Receives a DataTable
        /// I took all the elements inside and map them to the client model.
        /// Then, I map each of them to the global model and put their values in another datatable
        /// The datatable will then be sent as a parameter to the stored procedure
        /// </summary>
        /// <param name="dt"></param>
        public void InsertAll(DataTable dt)
        {
            DataTable NewDt = new DataTable();
            List<OrderLine> OrderLinesClient = new List<OrderLine>();
            List<G.OrderLine> OrderLines = new List<G.OrderLine>();

            int OrderID, ProductID, Quantity;
            decimal Price;

            foreach (DataRow dr in dt.Rows)
            {
                
                int.TryParse(dr["OrderID"].ToString(), out OrderID);
                int.TryParse(dr["ProductID"].ToString(), out ProductID);
                int.TryParse(dr["Quantity"].ToString(), out Quantity);

                decimal.TryParse(dr["Price"].ToString(), out Price);
                

                
                OrderLinesClient.Add(new OrderLine(OrderID, ProductID, Price, Quantity));
            }

            foreach(OrderLine ol in OrderLinesClient)
            {
                OrderLines.Add(ol.ToGlobal());
            }

            //Column names
            NewDt.Columns.Add("OrderID");
            NewDt.Columns.Add("ProductID");
            NewDt.Columns.Add("Price");
            NewDt.Columns.Add("Quantity");

            foreach (G.OrderLine ol in OrderLines)
            {
                NewDt.Rows.Add(ol.OrderID, ol.ProductID, ol.Price, ol.Quantity);  
            }


            GlobalServicesLocator.Instance.GetOrderLineRepository().InsertAll(NewDt);
        }

        public decimal GetGlobalTurnover()
        {
            return GlobalServicesLocator.Instance.GetOrderLineRepository().GetGlobalTurnover();
        }

        public decimal GetGlobalTurnoverByDate(DateTime d)
        {
            return GlobalServicesLocator.Instance.GetOrderLineRepository().GetTurnoverByDate(d);
        }

        public decimal GetTotalVolunteer()
        {
            return GlobalServicesLocator.Instance.GetOrderLineRepository().GetTotalVolunteer();
        }

        public decimal GetTotalVolunteerByDate(DateTime d)
        {
            return GlobalServicesLocator.Instance.GetOrderLineRepository().GetTotalVolunteerByDate(d);
        }
    }
}
