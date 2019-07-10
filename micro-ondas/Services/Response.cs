using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace micro_ondas.Services
{
    class Response
    {
        public string message;

        public Response(string msg)
        {
            this.message = msg;
        }

    }

    class ErrorResponse
    {
        public string message;
        public string classError;


        public ErrorResponse(string classErr, string msg)
        {
            this.message = msg;
            this.classError = classErr;
        }
    }
}
