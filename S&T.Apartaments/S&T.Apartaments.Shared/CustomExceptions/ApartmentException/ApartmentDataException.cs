using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Shared.CustomExceptions.ApartmentException
{
    public class ApartmentDataException : Exception
    {
        public ApartmentDataException(string message) : base(message) { }
    }
}
