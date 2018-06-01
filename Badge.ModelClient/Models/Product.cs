using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelClient.Models
{
    public class Product
    {
        private int _Id;
        private string _ProductName;
        private decimal _Price;
        private int _CategoryID;

        public int ID
        {
            get { return _Id; }
            private set { _Id = value; }
        }


        public string ProductName
        {
            get { return _ProductName; }
            private set { _ProductName = value; }
        }


        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }


        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }


        public Product(int id, string ProductName, decimal Price, int categoryID)
        {
            ID = id;
            this.ProductName = ProductName;
            this.Price = Price;
            CategoryID = categoryID;
        }

    }
}
