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
           
            try
            {
                List<ViewTopThree> t3 = new RevViewsDBEntities().ViewTopThrees.ToList();
                var a3 = t3.Select(o => o.RestrauntID).ToArray();
                Console.WriteLine(a3.ToString());
                Console.ReadLine();
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
  
        }
    }
}