using System;

namespace RevViews.BLL
{
    public interface IUnitOfWork : IDisposable
    {
        IRestaurantRepository Restaurants { get; }
        IReviewRepository Reviews { get; }
        int Complete();
    }
}