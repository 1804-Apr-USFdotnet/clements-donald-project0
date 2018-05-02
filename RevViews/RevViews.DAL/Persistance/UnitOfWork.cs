using System;
using RevViews.BLL;
using NLog;
using RevViews.DAL.Persistance.Repositories;

namespace RevViews.DAL.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        static Logger log = LogManager.GetCurrentClassLogger();
        private readonly RevViewsContext _context;

        public UnitOfWork(RevViewsContext context)
        {
            _context = context;
            Reviews = new ReviewRepository(_context);
            Restaurants = new RestaurantRepository(_context);
        }

        public IReviewRepository Reviews { get; }
        public IRestaurantRepository Restaurants { get; }

        public int Complete()
        {
            log.Error("Since the app does not invoke update or insert, you REALLY should not see this.");
            return _context.SaveChanges();
        }

        public void Dispose()
        {
                _context.Dispose();

        }
    }
}