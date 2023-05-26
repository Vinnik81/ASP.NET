using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Movie_6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_6.TagHelpers
{
    public enum MovieDetailsType
    {
        Full, Modal
    }

    [HtmlTargetElement("a", Attributes ="movie")]

    public class MovieDetailsTagHelper: TagHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory;

        public MovieDetailsTagHelper(IUrlHelperFactory urlHelperFactory)
        {
           this.urlHelperFactory = urlHelperFactory;
        }

        public Cinema Movie { get; set; }
        public MovieDetailsType MovieType { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext Context { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(Context);
            output.TagName = "a";
            output.Attributes.Add("class", "btn btn-primary");
            //output.Attributes.Add("href", $"/Home/Movie/{Movie.imdbID}");

            string route = "";

            var icon = new TagBuilder("i");

            if (MovieType == MovieDetailsType.Full)
            {
                route = urlHelper.ActionLink("Movie", "Home", new { id = Movie.imdbID });
                if (Movie.Type == "game")
                {
                    icon.AddCssClass("fa-solid fa-gamepad");
                }
                else if (Movie.Type == "series")
                {
                    icon.AddCssClass("fa-solid fa-tv");
                }
                else
                {
                    icon.AddCssClass("fa-solid fa-film");
                }

                output.Content.AppendHtml(icon);
                output.Content.Append("Details");
            }
            else
            {
                route = urlHelper.ActionLink("MovieModal", "Home", new { id = Movie.imdbID });
                icon.AddCssClass("fa-solid fa-eye");
                output.Content.AppendHtml(icon);
                output.Attributes.Add("data-open-modal", true);
            }
            output.Attributes.Add("href", route);
            output.Attributes.Add("title", Movie.Title);
        }
    }
}
