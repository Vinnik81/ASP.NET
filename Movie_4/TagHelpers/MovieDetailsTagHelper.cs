using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Movie_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_4.TagHelpers
{
    [HtmlTargetElement("a", Attributes ="movie")]

    public class MovieDetailsTagHelper: TagHelper
    {
        public Cinema Movie { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("class", "btn btn-primary");
            output.Attributes.Add("href", $"/Home/Movie/{Movie.imdbID}");
            output.Attributes.Add("title", Movie.Title);
            

            //<i class="fa-solid fa-film"></i>
            //<i class="fa-solid fa-gamepad"></i>
            //<i class="fa-solid fa-tv"></i>

            var icon = new TagBuilder("i");
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
    }
}
