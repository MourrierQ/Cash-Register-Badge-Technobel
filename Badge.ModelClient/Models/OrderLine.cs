using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelClient.Models
{
    public class OrderLine
    {
        private int _OrderID;
        private int _ProductID;
        private decimal _Price;
        private int _Quantity;

        public int OrderID
        {
            get { return _OrderID; }
            private set { _OrderID = value; }
        }


        public int ProductID
        {
            get { return _ProductID; }
            private set { _ProductID = value; }
        }


        public decimal Price
        {
            get { return _Price; }
            private set { _Price = value; }
        }


        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }



        public OrderLine(int OrderID, int ProductID, decimal Price, int Quantity)
        {
            this.OrderID = OrderID;
            this.ProductID = ProductID;
            this.Price = Price;
            this.Quantity = Quantity;
        }

    }
}
