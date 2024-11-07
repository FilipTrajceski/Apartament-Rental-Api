using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Shared.CustomExceptions.ApartmentException
{
    public class ApartmentNotFoundException : Exception
    {
        public ApartmentNotFoundException(string message) : base(message) { }
    }
}
