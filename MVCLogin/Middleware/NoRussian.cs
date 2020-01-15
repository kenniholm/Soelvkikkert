using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.Net;

namespace MVCLogin.Middleware
{
    public static class NoRussianMiddlewareExtensions
    {
        public static IApplicationBuilder UseNoRussian(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NoRussian>();
        }
    }


    public class NoRussian
    {
        private readonly RequestDelegate _next;
        private List<String> blockList = new List<string>
        {
            "2.60.0.",
            "2.60.32.",
            "2.60.64.",
            "2.60.96.",
            "2.60.128.",
            "2.60.160.",
            "2.60.192.",
            "2.61.0.",
            "2.61.32.",
            "2.61.64.",
            "2.61.96.",
            "2.61.112.",
            "2.61.120.",
            "2.61.128.",
            "2.61.160.",
            "2.61.192.",
            "2.62.0.",
            "2.62.32.",
            "2.62.48.",
            "2.62.64.",
        };

        public NoRussian(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            string ip = context.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            bool blockIp = false;
            foreach (string block in blockList)
            {
                if (ip.StartsWith(block))
                {
                    blockIp = true;
                    
                }
            }

            if (blockIp)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                await _next(context);
            }

        }
    }
}