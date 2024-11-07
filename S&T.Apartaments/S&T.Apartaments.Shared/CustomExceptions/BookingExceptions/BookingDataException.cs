using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Shared.CustomExceptions.BookingExceptions
{
    public class BookingDataException : Exception
    {
        public BookingDataException(string message) : base(message) { }
    }
}
