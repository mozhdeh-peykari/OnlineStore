using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Infrastructures
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PagingTagHelper : TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;
        public PagingTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }
        public PagingInfo PageModel { get; set; }
        public string PageClassSelected { get; set; }
        public string PageClassDefault { get; set; }
        //public string PageUrlCategory { get; set; }
        //public int PageUrlPage { get; set; }
        [HtmlAttributeName(DictionaryAttributePrefix ="page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();
        public string PageAction { get; set; }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(viewContext);
            TagBuilder div = new TagBuilder("div");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                
                TagBuilder tag = new TagBuilder("a");

                PageUrlValues["Page"] = i;

                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                tag.AddCssClass("btn");
                tag.AddCssClass(i == PageModel.PageNumber ? PageClassSelected : PageClassDefault);
                tag.InnerHtml.AppendHtml(i.ToString());
                div.InnerHtml.AppendHtml(tag);

            }
            output.Content.AppendHtml(div.InnerHtml);
            //   base.Process(context, output);
        }

    }
}
