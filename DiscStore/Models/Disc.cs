using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Models
{
    public class Disc
    {
        #region Data Members

        public int DiscID { get; set; }
        public string Name { get; set; }
        public int ArtistID { get; set; }
        public int GenreID { get; set; }
        public int Price { get; set; }
        public System.DateTime IssueDate { get; set; }
        public string ImgPath { get; set; }

        public virtual Artist Artists { get; set; }
        public virtual Genre Genres { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        #endregion
    }
}
