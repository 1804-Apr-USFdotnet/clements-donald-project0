using System.Collections.Generic;
using System.Data.Entity;
using RevViews.BLL;
using RevViews.Models;

namespace RevViews.DAL.Persistance.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Review> GetPagenatedReviews(int id, int pageIndex, int pageSize=3)
        {
            throw new System.NotImplementedException();
        }

        public RevViewsContext RevViewsContext
        {
            get { return Context as RevViewsContext; }
        }
    }
}