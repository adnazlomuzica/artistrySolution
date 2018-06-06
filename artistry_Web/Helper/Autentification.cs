using artistry_Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace artistry_Web.Helper
{
    public static class Autentification
    {
        private const string LoggedUser = "logged_user";

        public static void SetLoggedUser(this HttpContext context, UserAccounts user, bool saveCookie = false)
        {
            context.Session.Set(LoggedUser, user);

            if (saveCookie)
                context.Response.SetCookieJson(LoggedUser, user);
            else
                context.Response.SetCookieJson(LoggedUser, null);          
        }

        public static UserAccounts GetLoggedUser(this HttpContext context)
        {
            UserAccounts user = context.Session.Get<UserAccounts>(LoggedUser);

            if (user == null)
            {
                context.Request.GetCookieJson<UserAccounts>(LoggedUser);
                context.Session.Set(LoggedUser, user);
            }

            return user;
        }
    }
}
