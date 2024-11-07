using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Shared.CustomExceptions.UserExceptions
{
    public class UserDataException : Exception
    {
        public UserDataException(string message) : base(message) { }    
    }
}
