using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RevViews.Models;

namespace RevViewsDB.Fake
{
    public class Class1
    {
        public Restraunt R1 = new Restraunt()
        {
            RestrauntID = 1,
            
            RestaurantName = "The Best One",
            AddressLineOne = "Line one",
            City = "City", StateCode = "TX", PostalCode = "76543",

            Phone = "706-910-2470",
            Website = "NA"
        };

        public Restraunt R2 = new Restraunt()
        {
            RestrauntID = 1,

            RestaurantName = "The Best One",
            AddressLineOne = "Line one",
            City = "City",
            StateCode = "TX",
            PostalCode = "76543",

            Phone = "706-910-2470",
            Website = "NA"
        };

    }
}
