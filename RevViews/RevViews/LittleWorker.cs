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
using RevViews.Models;

namespace RevViews

{
    public class LittleWorker
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

    }
}