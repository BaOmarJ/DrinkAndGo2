using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DrinkAndGo2.TagHelpers
{
    public class EmailTagHelper:TagHelper
    {
        public string Address { get; set; }
        public string Content { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // use the output to define tag name
            output.TagName = "a";
            // set some attributes
            output.Attributes.SetAttribute("href", "mailto:" + Address);
            output.Content.SetContent(Content);
        }
    }
}
