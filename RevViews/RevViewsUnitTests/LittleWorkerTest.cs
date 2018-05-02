using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevViews;
using RevViews.Models;

namespace RevViewsUnitTests
{
    [TestClass]
    public class LittleWorkerTest
    {
        [TestMethod]
        public void GetRestaurantTest()
        {
            var temp = LittleWorker.GetRestaurant(1);
            var actual = temp.RestrauntID;
            int expected = 1;
            Assert.AreEqual(actual, expected);
            
        }

        [TestMethod]
        public void GetReviewsTest()
        {
            List<Review> temp = LittleWorker.GetReviews(1).ToList();
            Review temp2 = temp.Where(o=>o.ReviewID==1).SingleOrDefault();
            int actual = temp2.ReviewID;
            int expected = 1;
            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void RatingTest()
        {
            double actual = LittleWorker.Rating(1);
            double expected = (double) 4.3;
            Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void GetAllRestaurantsTest()
        {
            int actual = LittleWorker.GetAllRestaurants().Count();
            int expected = 10;
            Assert.AreEqual(actual, expected);

        }

    }
}
