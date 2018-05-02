using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using NLog;
using RevViews.DAL.Persistance;
using RevViews.Models;

namespace RevViews

{
    public static class LittleWorker
    {
        static Logger log = LogManager.GetCurrentClassLogger();

        public static IEnumerable<Restraunt> GetAllRestaurants()
        {
            var unitOfWork = new UnitOfWork(new RevViewsContext());
            var results = unitOfWork.Restaurants.GetAll();
            unitOfWork.Dispose();
            return results;
        }

        public static IEnumerable<Restraunt> Search(string input)
        {
            var unitOfWork = new UnitOfWork(new RevViewsContext());
            var results = unitOfWork.Restaurants.GetAll()
                .Where(o => o.RestaurantName.ToUpper().Contains(input.ToUpper()));
            unitOfWork.Dispose();
            return results;
        }

        public static List<int> ViewTop()
        {
            var t3IDs = new List<int>();
            var t3 = new RevViewsDBEntities().ViewTopThrees.ToList();
            for (var index = 0; index < t3.Count; index++)
            {
                var e = t3[index];

                Console.WriteLine("\t" + (index + 1) + ":   " + e.RestaurantName + " has rating of " +
                                  Math.Round((double) e.AvgRating, 1));
                t3IDs.Add(e.RestrauntID);
            }

            return t3IDs;
        }

        public static Restraunt GetRestaurant(int id)
        {
            var unitOfWork = new UnitOfWork(new RevViewsContext());
            var results = unitOfWork.Restaurants.Get(id);
            unitOfWork.Dispose();
            return results;
        }

        public static IEnumerable<Review> GetReviews(int id)
        {
            var unitOfWork = new UnitOfWork(new RevViewsContext());
            var results = unitOfWork.Reviews.GetAll().Where(o => o.RestrauntID == id);
            unitOfWork.Dispose();
            return results;
        }

        public static double Rating(int id)
        {
            var unitOfWork = new UnitOfWork(new RevViewsContext());
            var result = Math.Round(unitOfWork.Reviews.GetAll()
                .Where(c => c.RestrauntID == id)
                .Average(c => c.Rating), 1);
            unitOfWork.Dispose();
            return result;
        }

        public static List<Restraunt> SortRestraunts(ref List<Restraunt> r, int i)
        {
            Console.WriteLine("Sort pending.  Options 3 and 4 may take a moment...");
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

        public static void ToJSON()
        {
            Console.WriteLine("Begin JSON Demo");
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Restraunt));
            var r = GetAllRestaurants();
            foreach (var Restraunt in r)
            {
                try
                {
                    ser.WriteObject(stream1, Restraunt);
                }
                catch (Exception e)
                {
                    log.Error(e, "");
                }
            }
            Console.WriteLine("End JSON Demo");
            Console.ReadLine();

        }
    }
}