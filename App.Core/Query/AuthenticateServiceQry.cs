﻿using App.Core.Contracts;
using App.Core.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace App.Core.Query
{
    public class AuthenticateServiceQry : IAuthenticateService
    {
        public void SetUserData(UserInfo obj)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, this.UserInfo(obj),
                 DateTime.Now, DateTime.Now.AddMinutes(30), false, String.Empty, FormsAuthentication.FormsCookiePath);
            string encryptedCookie = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedCookie);
            cookie.Expires = DateTime.Now.AddMinutes(30);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public string UserInfo(UserInfo obj)
        {
            return obj.Name + "|" + obj.UserId.ToString() + "|" + obj.Role + "|" + obj.RoleId.ToString() + "|" + obj.Email + "|" + string.Join(",", obj.Roles) + "|" + obj.IsAuthenticated.ToString() + "|" +
                CartIdGenerator.GetUniqueKey();
        }


        public void ClearUserData()
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                authCookie.Expires = DateTime.Now.AddYears(-1);
                HttpContext.Current.Response.Cookies.Add(authCookie);
            }
            FormsAuthentication.SignOut();
        }
    }
}
