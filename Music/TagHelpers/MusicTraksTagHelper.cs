using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.TagHelpers
{
    [HtmlTargetElement("a", Attributes ="music")]

    public class MusicTraksTagHelper: TagHelper
    {
        public Datum Music { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.Add("class", "btn btn-primary");
            output.Attributes.Add("href", $"/Home/Music/{Music.album.id}");
            output.Attributes.Add("title", Music.album.title);

            //< i class="fa-solid fa-compact-disc"></i>

            var icon = new TagBuilder("i");
            icon.AddCssClass("fa-solid fa-compact-disc");

            output.Content.AppendHtml(icon);
            output.Content.Append("Track List");
        }
    }
}
