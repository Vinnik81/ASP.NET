using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_6.HtmlHelpers
{
    public static class MovieHtmlsHelpers
    {
        public static IHtmlContent MovieLink(this IHtmlHelper htmlHelper)
        {
            string link = "<a href=\"https://www.google.com\">Google<a/>";
            return new HtmlString(link);
        }

        public static IHtmlContent EmalLink(this IHtmlHelper htmlHelper, string mail, string title = null)
        {
            string link = $"<a href=\"mailto:{mail}\">{title ?? mail}<a/>";
            return new HtmlString(link);
        }

        public static IHtmlContent EmalLink2(this IHtmlHelper htmlHelper, string mail, string title = null)
        {
            var link = new TagBuilder("a");
            link.InnerHtml.Append(title ?? mail);
            link.Attributes.Add("href", $"mailto:{mail}");
            link.AddCssClass("text-danger");
            return link;
        }
    }
}
