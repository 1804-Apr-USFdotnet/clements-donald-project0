using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using RevViews;
using RevViews.BLL;
using RevViews.DAL;
using RevViews.DAL.Persistance;
using RevViews.DAL.Persistance.Repositories;
using RevViews.Models;

namespace RevViews

{
    public static class LittleWorker
    {

        public static IEnumerable<Restraunt> ShowAll()
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

        public static void ViewTop()
        {
            List<ViewTopThree> t3 = new RevViewsDBEntities().ViewTopThrees.ToList();
            for (var index = 0; index < t3.Count; index++)
            {
                var e = t3[index];

                Console.WriteLine((index+1) + ":" + e.RestaurantName + " has rating of " + Math.Round((double)e.AvgRating, 1));
            }

            Console.WriteLine();
            Console.Write("Please make a selection for further information:  ");
            string input= Console.ReadLine();
            int.TryParse(input, out int parsed);
        }

    }
}