using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Models
{
    public class Artist
    {
        #region Data Members

        public int ArtistID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public string Language { get; set; }
        public string ImgPath { get; set; }
        //public virtual ICollection<Disc> Discs { get; set;}
        public virtual ICollection<ArtistGenreLink> GenresLinks { get; set; }

        #endregion
    }
}
