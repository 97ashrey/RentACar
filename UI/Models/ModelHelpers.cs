using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public static class ModelHelpers
    {
        public static string OfferInfo(this OfferModelWrapper offer)
        {
            string output = $"Ponuda sa podacima: \n" +
                            $"Automobil: {offer.CarName}\n" +
                            $"Datum od: {offer.From}\n" +
                            $"Datum do: {offer.To}\n" +
                            $"Cena po danu: {offer.PricePerDay}\n";
            return output;
        }

    }
}
