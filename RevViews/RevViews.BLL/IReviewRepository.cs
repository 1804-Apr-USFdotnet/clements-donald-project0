using System.Collections.Generic;
using RevViews.Models;

namespace RevViews.BLL
{
    public interface IReviewRepository : IRepository<Review>
    {
        IEnumerable<Review> GetPagenatedReviews(int id, int pageIndex, int pageSize);
    }
}