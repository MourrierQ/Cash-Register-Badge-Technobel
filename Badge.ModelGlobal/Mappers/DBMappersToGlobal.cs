using Badge.ModelGlobal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelGlobal.Mappers
{
    internal static class DBMappersToGlobal
    {
        public static Category ToCategory(this IDataRecord entity)
        {
            return new Category()
            {
                Id = (int)entity["Id"],
                CategoryName = entity["CategoryName"].ToString()
            };
        }

        public static Product ToProduct(this IDataRecord entity)
        {
            return new Product()
            {
                Id = (int)entity["Id"],
                ProductName = entity["ProductName"].ToString(),
                CategoryID = (int)entity["CategoryID"],
                Price = (decimal)entity["Price"]
            };
        }

        public static Order ToOrder(this IDataRecord entity)
        {
            return new Order()
            {
                Id = (int)entity["Id"],
                OrderTime = (DateTime)entity["OrderTime"]
            };
        }

        public static OrderLine ToOrderLine(this IDataRecord entity)
        {
            return new OrderLine()
            {
                OrderID = (int)entity["OrderID"],
                ProductID = (int)entity["ProductID"],
                Quantity = (int)entity["Quantity"],
                Price = (decimal)entity["Price"]
            };
        }


    }
}
