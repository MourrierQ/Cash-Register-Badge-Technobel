using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge.ModelGlobal.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public bool Volunteer { get; set; }

    }
}
