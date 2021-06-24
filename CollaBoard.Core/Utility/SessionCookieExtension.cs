using Microsoft.AspNetCore.Http;

namespace CollaBoard.Core.Utility
{
    public static class SessionCookieExtension
    {
        public static string GetSessionCookie(this HttpContext context)
        {
            if (context.Request.Cookies.TryGetValue("Session", out var value))
            {
                return value;
            }
            return null;
        }
    }
}
