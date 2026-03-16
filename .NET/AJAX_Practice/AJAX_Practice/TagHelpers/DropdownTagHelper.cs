using AJAX_Practice.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Diagnostics.Metrics;
using System.Text;

namespace AJAX_Practice.TagHelpers
{
    [HtmlTargetElement("role-dropdown")]
    public class DropdownTagHelper : TagHelper
    {
        public List<CountryModel> Items { get; set; }
        public string Name { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            output.Attributes.SetAttribute("name", Name);
            output.Attributes.SetAttribute("class", "form-control");

            var content = new StringBuilder();

            content.Append("<option value=''>Select Country</option>");

            if (Items != null)
            {
                foreach (var item in Items)
                {
                    content.Append($"<option value='{item.Id}'>{item.Name}</option>");
                }
            }

            output.Content.SetHtmlContent(content.ToString());
        }
    }
}
