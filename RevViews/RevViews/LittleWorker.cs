using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using RevViews.DAL.Persistance;
using RevViews.Models;

namespace RevViews

{
    public static class LittleWorker
    {

        public static IEnumerable<Restraunt> GetAllRestaurants()
        {
            UnitOfWork unitOfWork = new UnitOfWork(new RevViewsContext());
            var results = unitOfWork.Restaurants.GetAll();
            unitOfWork.Dispose();
            return results;

        }

        public static IEnumerable<Restraunt> Search(string input)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new RevViewsContext());
            var results = unitOfWork.Restaurants.GetAll().Where(o => o.RestaurantName.ToUpper().Contains(input.ToUpper()));
            unitOfWork.Dispose();
            return results;

        }

        public static List<int> ViewTop()
        {
            List<int> T3IDs = new List<int>();
            List<ViewTopThree> t3 = new RevViewsDBEntities().ViewTopThrees.ToList();
            for (var index = 0; index < t3.Count; index++)
            {
                var e = t3[index];

                Console.WriteLine("\t"+(index+1) + ":   " + e.RestaurantName + " has rating of " + Math.Round((double)e.AvgRating, 1));
                T3IDs.Add(e.RestrauntID);
            }

            return T3IDs;

        }

        public static Restraunt GetRestaurant(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new RevViewsContext());
            Restraunt results = unitOfWork.Restaurants.Get(id);
            unitOfWork.Dispose();
            return results;
        }

        public static IEnumerable<Review> GetReviews(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new RevViewsContext());
            var results = unitOfWork.Reviews.GetAll().Where(o => o.RestrauntID == id);
            unitOfWork.Dispose();
            return results;
        }

        public static double Rating(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new RevViewsContext());
            double result = Math.Round (unitOfWork.Reviews.GetAll()
                .Where(c => c.RestrauntID == id)
                .Average(c => c.Rating),1);
            unitOfWork.Dispose();
            return result;
        }

        public static List<Restraunt> SortRestraunts(ref List<Restraunt> r, int i)
        {
            switch (i)
            {
                case 1:
                     return r.OrderBy(o => o.RestaurantName).ToList();
                    break;
                case 2:
                    return r.OrderByDescending(o => o.RestaurantName).ToList();
                    break;
                case 3:
                    return r.OrderBy(o => Rating(o.RestrauntID)).ToList();
                    break;
                case 4:
                    return r.OrderByDescending(o => Rating(o.RestrauntID)).ToList();
                    break;
                default:
                    break;
            }

            return r;
        }

    }
}