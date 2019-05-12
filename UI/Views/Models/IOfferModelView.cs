using System;

namespace UI.Views.Models
{
    public interface IOfferModelView
    {
        object Car { get; set; }
        DateTime From { get; set; }
        DateTime To { get; set; }
        double PricePerDay { get; set; }
    }
}
