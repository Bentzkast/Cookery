using Microsoft.AspNetCore.Http;

namespace Cookery.API.Helpers
{
    public static class Extentions
    {
        // this is an extention methods for existing class
        public static void AddApplicationError (this HttpResponse response, string message)
        {
            response.Headers.Add ("Application-Error", message);
            response.Headers.Add ("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add ("Access-Control-Allow-Origin", "*");
        }
    }
}