using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restsharptest
{
    public class ApiError : Exception
    {

        public ApiError():base()
        {

        }

        public ApiError(string message):base(message)
        {

        }
    }
}
