﻿using System.Web;
using System.Web.Mvc;

namespace Loja_Virtual_Feminina
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
