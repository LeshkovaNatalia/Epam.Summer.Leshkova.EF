using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTutorial
{
    public class GalleryContext : DbContext
    {
        public GalleryContext() : base() { }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<CategoryPhoto> CategoryPhotos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
