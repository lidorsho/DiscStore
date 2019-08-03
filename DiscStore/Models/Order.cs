using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int DiscID { get; set; }
        public int StoreID { get; set; }

        public virtual User Users { get; set; }
        public virtual Disc Discs { get; set; }
        public virtual Store Stores { get; set; }

    }
}
