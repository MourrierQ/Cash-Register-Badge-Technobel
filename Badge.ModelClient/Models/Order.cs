using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelClient.Models
{
    public class Order
    {
        private int id;
        private DateTime _OrderTime;
        private bool _Volunteer;

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }


        public DateTime OrderTime
        {
            get { return _OrderTime; }
            private set { _OrderTime = value; }
        }


        public bool Volunteer
        {
            get { return _Volunteer; }
            private set { _Volunteer = value; }
        }

        public  Order(bool Volunteer)
        {
            this.Volunteer = Volunteer;
        }

     

    }
}
