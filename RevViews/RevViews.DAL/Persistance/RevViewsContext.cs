using System.Data.Entity;
using RevViews.Models;

namespace RevViews.DAL.Persistance
{
    public class RevViewsContext : DbContext
    {
        public RevViewsContext()
            : base("name=RevViewsDBEntities")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Restraunt> Restraunts { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
    }
}