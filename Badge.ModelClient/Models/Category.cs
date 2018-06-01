using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelClient.Models
{
    public class Category
    {
        private int _Id;

        public int ID
        {
            get { return _Id; }
            private set { _Id = value; }
        }

        private string _CategoryName;

        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }

        public Category(int Id, string CategoryName)
        {
            ID = Id;
            this.CategoryName = CategoryName;
        }


    }
}
