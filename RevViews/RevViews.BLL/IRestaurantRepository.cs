using System.Collections.Generic;
using RevViews.Models;

namespace RevViews.BLL
{
    public interface IRestaurantRepository : IRepository<Restraunt>
    {
        IEnumerable<Restraunt> GetTopRated(int amount);
    }
}