using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Models
{
    [Table("ARTISTS_GENRES_LINKS")]
    public class ArtistGenreLink
    {
        [Key]
        public int LinkID { get; set; }
        public int GenreID { get; set; }
        public int ArtistID { get; set; }

        public virtual Artist Artists { get; set; }
        public virtual Genre Genres { get; set; }

    }
}
