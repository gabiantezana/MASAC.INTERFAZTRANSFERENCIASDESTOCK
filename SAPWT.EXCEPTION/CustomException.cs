using SAPWT.HELPER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPWT.EXCEPTION
{
    public class CustomException : Exception
    {
        public ApplicationErrorType ApplicationErrorType { get; set; }

        public CustomException(ApplicationErrorType type, Exception inner, String message = null) : base((message ?? inner.Message), inner) { ApplicationErrorType = type; }
    }

}
