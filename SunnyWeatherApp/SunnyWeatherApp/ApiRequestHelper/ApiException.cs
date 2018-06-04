using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyWeatherApp.ApiRequestHelper
{
    class ApiException : System.Exception
    {
        public ApiException()
        {
            ServerErrorResponse = null;
        }

        public ApiException(ServerErrorResponseModel serverErrorResponse)
        {
            ServerErrorResponse = serverErrorResponse;
        }

        public ApiException(string message)
        {
            ServerErrorResponse.Message = message;
        }

        public ServerErrorResponseModel ServerErrorResponse { get; }
    }
}
