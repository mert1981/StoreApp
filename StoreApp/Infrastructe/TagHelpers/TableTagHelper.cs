using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.Infrastructe.TagHelpers
{
    [HtmlTargetElement("table")]
    public class TableTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // proje de table gördüğü yerlerde boostrapin class table özelliğini ekliyor
            output.Attributes.SetAttribute("class", "table table-hover");

        }
    }
}
