using System;
using System.Collections.Generic;
using System.Data.Entity;
using RevViews.BLL;
using RevViews.Models;

namespace RevViews.DAL.Persistance.Repositories
{
    public class RestaurantRepository : Repository<Restraunt>, IRestaurantRepository
    {
        public RestaurantRepository(DbContext context) : base(context)
        {
        }

        public RevViewsContext RevViewsContext
        {
            get { return Context as RevViewsContext; }
        }

        public IEnumerable<Restraunt> GetTopRated(int amount)
        {
            throw new NotImplementedException();
        }
    }
}