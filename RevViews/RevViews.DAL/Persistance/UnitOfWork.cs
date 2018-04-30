using RevViews.BLL;
using RevViews.DAL.Persistance.Repositories;

namespace RevViews.DAL.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RevViewsContext _context;

        public UnitOfWork(RevViewsContext context)
        {
            _context = context;
            Reviews = new ReviewRepository(_context);
            Restaurants = new RestaurantRepository(_context);
        }

        public IReviewRepository Reviews{ get; private set; }
        public IRestaurantRepository Restaurants { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}