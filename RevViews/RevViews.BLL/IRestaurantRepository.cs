using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevViews.Models;

namespace RevViews.BLL
{
    public interface IRestaurantRepository : IRepository<Restraunt>
    {
        IEnumerable<Restraunt> GetTopRated(int amount);

    }
}
