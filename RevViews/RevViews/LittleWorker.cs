using System;
using System.Collections.Generic;
using System.Linq;
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

                Console.WriteLine((index+1) + ":" + e.RestaurantName + " has rating of " + Math.Round((double)e.AvgRating, 1));
                T3IDs.Add(e.RestrauntID);
            }

            return T3IDs;

        }

        public static Restraunt GetRestraunt(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new RevViewsContext());
            Restraunt results = unitOfWork.Restaurants.Get(id);
            unitOfWork.Dispose();
            return results;
        }

    }
}