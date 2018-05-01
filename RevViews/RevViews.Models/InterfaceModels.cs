using System;
using System.Collections.Generic;

namespace RevViews.Models
{
    public interface IRestrauntEntity : IAddress
    {
            int RestrauntID { get; set; }
            string RestaurantName { get; set; }
            string Phone { get; set; }
            string Website { get; set; }
            ICollection<Review> Reviews { get; set; }
     }
    public interface IAddress
    {
        string AddressLineOne { get; set; }
        string City { get; set; }
        string StateCode { get; set; }
        string PostalCode { get; set; }
    }
    public interface IReview
    {
        int ReviewID { get; set; }
        int RestrauntID { get; set; }
        string Username { get; set; }
        int Rating { get; set; }
        string Headline { get; set; }
        string Body { get; set; }
        DateTime ReviewedOn { get; set; }

        Restraunt Restraunt { get; set; }
    }
}
