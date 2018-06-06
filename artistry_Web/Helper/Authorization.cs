using artistry_Data.Context;
using artistry_Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Helper
{
    public class AuthorizationAttribute:TypeFilterAttribute
    {
        public AuthorizationAttribute(bool admin, bool museum, bool client)
            :base(typeof(Authorize))
        {
            Arguments = new object[] { admin, museum, client };
        }
    }

    public class Authorize:IAsyncActionFilter
    {
        public Authorize(bool admin, bool museum, bool client)
        {
            _admin = admin;
            _museum = museum;
            _client = client;
        }

        private readonly bool _admin;
        private readonly bool _museum;
        private readonly bool _client;

        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            UserAccounts u = filterContext.HttpContext.GetLoggedUser();

            if (u == null)
            {
                if(filterContext.Controller is Controller controller)
                {
                    controller.TempData["error_msg"] = "Niste logirani!";
                }

                filterContext.Result = new RedirectToActionResult("Index", "Autentification", new { area = "" });
                return;
            }

            Context db = (Context)filterContext.HttpContext.RequestServices.GetService(typeof(Context));

            //if(_client && db.Clients.Any(c => c.UserId==u.Id))
            //{
            //    await next();
            //    return;
            //}

            if (_museum && db.Museums.Any(m => m.UserId == u.Id))
            {
                await next();
                return;
            }

            if (_admin && db.Administrators.Any(a => a.UserId == u.Id))
            {
                await next();
                return;
            }

            if(filterContext.Controller is Controller c1)
            {
                c1.TempData["error_msg"] = "Nemate pravo pristupa!";
            }

            filterContext.Result = new RedirectToActionResult("Index", "Home", new { area = "" });

        }

        

    }
}
