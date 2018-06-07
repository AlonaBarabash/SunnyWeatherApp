using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyWeatherApp.ApiRequestHelper
{
    public class ApiException : System.Exception
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
            ServerErrorResponse = new ServerErrorResponseModel
            {
                Message = message,
                Code = ""
            };
        }

        public ServerErrorResponseModel ServerErrorResponse { get; }
    }
}
