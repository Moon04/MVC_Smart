using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC.Helpers
{
    public static class Extentions
    {
        public static MvcHtmlString UlFor(this HtmlHelper caller, ICollection<object> arr)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");
            foreach(object item in arr)
            {
                sb.Append("<li>");
                sb.Append(item.ToString());
                sb.Append("</li>");
            }
            sb.Append("</ul>");
            return new MvcHtmlString(sb.ToString());
        }
    }
}