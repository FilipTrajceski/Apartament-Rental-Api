using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Shared.CustomExceptions.ServerExceptions
{
    public class InternalServerException : Exception
    {
        public InternalServerException(string message) : base(message) { }
    }
}
