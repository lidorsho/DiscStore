using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Models
{
    public class Genre
    {
        #region Properties

        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Disc> Discs { get; set; }
        public virtual ICollection<ArtistGenreLink> ArtistsLinks { get; set; }


        #endregion

    }
}
