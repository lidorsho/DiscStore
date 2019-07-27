using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace DiscStore.Models
{
    public class DiscStoreContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DiscStoreContext() : base("name=DiscStoreContext")
        {
            Database.SetInitializer<DiscStoreContext>(null);

        }

        public DbSet<Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<DiscStore.Models.Artist> Artists { get; set; }

        public System.Data.Entity.DbSet<DiscStore.Models.ArtistGenreLink> ArtistGenreLinks { get; set; }

        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<DiscStore.Models.Disc> Discs { get; set; }

        public System.Data.Entity.DbSet<DiscStore.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<DiscStore.Models.Store> Stores { get; set; }
    }
}
