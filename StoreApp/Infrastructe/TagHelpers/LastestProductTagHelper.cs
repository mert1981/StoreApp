using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.VisualBasic;
using Services.Contracts;

namespace StoreApp.Infrastructe.TagHelpers
{
    [HtmlTargetElement("div",Attributes ="products")]
    public class LastestProductTagHelper :  TagHelper
    {
        private readonly IServiceManager _manager;
        [HtmlAttributeName("number")]
        public int Number {  get; set; }

        public LastestProductTagHelper(IServiceManager manager)
        { 
            _manager = manager;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div"); //yeni bir div elemanı inşaa ediyoruz
            div.Attributes.Add("class", "my-3"); //class gördüğü zaman içine my-3 ekleyecek

            TagBuilder h6 = new TagBuilder("h6"); //h6 tagi inşaa ediyoruz
            h6.Attributes.Add("class", "lead");

            //h6 div içinde olduğu için onu divin içine yerleştriyoruz
            h6.InnerHtml.AppendHtml("Lastest Product");


            TagBuilder ul = new TagBuilder("ul");
            var products = _manager.ProductService.GetLastestProduct(Number, false);
            foreach (Product prd in products)
            {
                TagBuilder li = new TagBuilder("li");

                TagBuilder a = new TagBuilder("a");
                a.Attributes.Add("href", $"/product/get/{prd.Id}");
                a.InnerHtml.AppendHtml(prd.ProductName);

                li.InnerHtml.AppendHtml(a);
                ul.InnerHtml.AppendHtml(li);
            }

            div.InnerHtml.AppendHtml(h6);
            div.InnerHtml.AppendHtml(ul);
            output.Content.AppendHtml(div);

        }
    }
}


