using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
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
            IEnumerable<Restraunt> restraunts = RevViewsContext.Restraunts;
            //var aveR = new RevViewsDBEntities().AveRating().OrderByDescending(o=>o.AvgRating).Take(amount).ToList();
            //var q = RevViewsContext.Restraunts.Where( o=> o.RestrauntID in aveR)
            //return
           List<ViewTopThree> t3 = new RevViewsDBEntities().ViewTopThrees.ToList();
                    
        throw new NotImplementedException();
        }
    }
}