using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_4.TagHelpers
{
    [HtmlTargetElement("a")]
    public class EmailLinkTagHelper: TagHelper
    {
        public string MyEmail { get; set; }
        public string MyTitle { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(MyEmail != null)
            {
                output.TagName = "a";
                output.Content.Append(MyTitle ?? MyEmail);
                output.Attributes.Add("href", $"mailto:{MyEmail}");
            }
            
        }
    }
}
