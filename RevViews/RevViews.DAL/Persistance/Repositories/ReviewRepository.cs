using System;
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

        public RevViewsContext RevViewsContext => Context as RevViewsContext;

        public IEnumerable<Review> GetPagenatedReviews(int id, int pageIndex, int pageSize = 3)
        {
            throw new NotImplementedException();
        }
    }
}