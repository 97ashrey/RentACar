using System;

namespace UI.Views.Models
{
    public interface IReservationModelView
    {
        object User { get; set; }
        object Car { get; set; }
        DateTime From { get; set; }
        DateTime To { get; set; }
        double Price { get; set; }
    }
}
