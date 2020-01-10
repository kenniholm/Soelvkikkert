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
            "2.60.0.0",
            "2.60.32.0",
            "2.60.64.0",
            "2.60.96.0",
            "2.60.128.0",
            "2.60.160.0",
            "2.60.192.0",
            "2.61.0.0",
            "2.61.32.0",
            "2.61.64.0",
            "2.61.96.0",
            "2.61.112.0",
            "2.61.120.0",
            "2.61.128.0",
            "2.61.160.0",
            "2.61.192.0",
            "2.62.0.0",
            "2.62.32.0",
            "2.62.48.0",
            "2.62.64.0",
        };

        public NoRussian(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            string ip = context.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            if (!blockList.Contains(ip))
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }


        }
    }
}