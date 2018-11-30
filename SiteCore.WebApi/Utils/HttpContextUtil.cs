﻿using Microsoft.AspNetCore.Http;

namespace WebApiSample.Api._21
{
    public static class HttpContextUtil
    {
        private static IHttpContextAccessor _accessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _accessor = httpContextAccessor;
        }

        public static HttpContext HttpContext => _accessor.HttpContext;
    }
}
