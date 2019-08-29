using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI
{
    public class MusicStoreError : HandleErrorAttribute
    {
        public override void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            //If the exeption is already handled we do nothing
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            else
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "../Error/Index"
                };
            }

            //Make sure that we mark the exception as handled
            filterContext.ExceptionHandled = true;
        }
    }
}