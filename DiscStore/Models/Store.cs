using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Models
{
    public class Store
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
