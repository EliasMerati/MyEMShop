using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Entities.Visitors;
using System;
using UAParser;

namespace MyEMShop.EndPoint.Filters
{
    public class SaveVisitorsFilter : IActionFilter
    {
        #region Inject Service
        private readonly IVisitorService _visitorService;
        public SaveVisitorsFilter(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }
        #endregion

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string ip = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var actionName = ((ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            var controllerName = ((ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            var userAgent = context.HttpContext.Request.Headers["User-Agent"];
            var referer = context.HttpContext.Request.Headers["Referer"].ToString();
            var currentUrl = context.HttpContext.Request.Path;
            var request = context.HttpContext.Request;
            string visitid = context.HttpContext.Request.Cookies["VisitID"];
            if (visitid is null)
            {
                visitid = GenerateCode.GenerateUniqueCode();
                context.HttpContext.Response.Cookies.Append("VisitID", visitid, new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Path = "/",
                    HttpOnly = true,
                    Expires = DateTime.Now.AddDays(30)
                });
            }
            var parser = Parser.GetDefault();
            ClientInfo client = parser.Parse(userAgent);
            var visitor = new Visitor
            {
                CurrentLink = currentUrl,
                Ip = ip,
                ReferrerLink = referer,
                VisitID = visitid,
                Method = request.Method,
                PhisicalPath = $"{controllerName}/{actionName}",
                Protocol = request.Protocol,
                OperationSystem = new VisitorOs
                {
                    Family = client.OS.Family,
                    Version = $"{client.OS.Major}.{client.OS.Minor}.{client.OS.Patch}"
                },
                Browser = new VisitorBrowser
                {
                    Family = client.UA.Family,
                    Version = $"{client.UA.Major}.{client.UA.Minor}.{client.UA.Patch}"
                },
                VisitorDevice = new VisitorDevice
                {
                    Brand = client.Device.Brand,
                    Family = client.Device.Family,
                    IsSpider = client.Device.IsSpider,
                    Model = client.Device.Model
                },
            };
            _visitorService.AddVisitorInfo(visitor);

        }
    }
}
