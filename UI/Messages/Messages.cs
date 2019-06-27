using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public static class Messages
    {
        public static string ErrorRequiredField(string fieldName)
        {
            return $"Polje '{fieldName}' je obavezno polje";
        }

        public static string ERROR_FORM_FILL { get => "Polja neispravno popunjena!"; }

        // User messages

        public static string ERROR_WRONG_PASSWORD { get => "Pogrešna lozinka"; }

        public static string ErrorUserExists(string username)
        {
            return $"Korisnik sa korisničkim imenom '{username}' već postoji";
        }

        public static string ErrorUserDoesntExist(string username)
        {
            return $"Korisnik sa korisničkim imenom '{username}' ne postoji";
        }

        // Registration messages

        public static string ErrorInvalidUMCNFormat()
        {
            return $"JMBG sadrži {Constants.UMCN_MAX_LENGTH} cifara!";
        }

        public static string ErrorInvalidPhoneNumberLength()
        {
            return $"Telefonski broj sadrži {Constants.PHONE_NUMBER_MAX_LENGTH} cifara!";
        }

        public static string ERROR_WRONG_PHONE_FORMAT { get; } = "Broj telefona je u pogrešnom formatu!";

        public static string ERROR_DATE_IN_FUTURE { get; } = "Izabrali ste datum u buducnosti!";

        #region Crud Messages
        public static string MessageDeletionSuccess(int count, int outOf)
        {
            return $"Uspešno ste obrisali {count}/{outOf} zapisa";
        }

        // Registration messages
        public static string ERROR_CUSTOMER_CREATED { get; } = "Došlo je do greške prilikom kreiranja vašeg naloga, pokušajte ponovo";

        public static string MESSAGE_CUSTOMER_CREATED { get; } = "Uspešno ste se registrovali, možete da se ulogujete";

        // Customers view messages

        public static string ERROR_CUSTOMER_UPDATE { get; } = "Došlo je do greške prilikom ažuriranja!";

        public static string MESSAGE_CUSTOMER_UPDATE { get; } = "Uspešno ste ažurirali korisnika";


        // Cars view messages

        public static string ERROR_CAR_UPDATE { get; } = "Došlo je do greške prilikom ažuriranja!";

        public static string MESSAGE_CAR_UPDATE { get; } = "Uspešno ste ažurirali vozilo";

        public static string ERROR_CAR_CREATE { get; } = "Došlo je do greške prilikom kreiranja novog vozila!";

        public static string MESSAGE_CAR_CREATE { get; } = "Uspešno ste kreirali vozilo";


        // Offers view messages
        public static string ERROR_OFFER_UPDATE { get; } = "Došlo je do greške prilikom ažuriranja!";

        public static string MESSAGE_OFFER_UPDATE { get; } = "Uspešno ste ažurirali ponudu";

        public static string ERROR_OFFER_CREATE { get; } = "Došlo je do greške prilikom kreiranja nove ponude!";

        public static string MESSAGE_OFFER_CREATE { get; } = "Uspešno ste kreirali ponudu";

        // Reservations view messages

        public static string ERROR_RESERVATION_UPDATE { get; } = "Došlo je do greške prilikom ažuriranja!";

        public static string MESSAGE_RESERVATION_UPDATE { get; } = "Uspešno ste ažurirali rezervaciju";

        public static string ERROR_RESERVATION_CREATE { get; } = "Došlo je do greške prilikom kreiranja nove rezervacije!";

        public static string MESSAGE_RESERVATION_CREATE { get; } = "Uspešno ste kreirali rezervaciju";
        #endregion

        public static string ERROR_DATE_FROM_BEFORE_DATE_TO { get; } = "Datum 'od' mora biti pre datuma 'do'!";

        public static string ERROR_DATE_IN_THE_PAST { get; } = "Datum ne sme biti u prošlosti!";

        public static string ERROR_NO_TIME_PERIOD { get; } = "Nema tog termina!";
    }
}
