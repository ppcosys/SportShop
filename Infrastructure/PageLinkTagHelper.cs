using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Shop.Models.ViewModels;

namespace Shop.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }

        public PagingInfo? PageModel { get; set; }

        public string? PageAction { get; set; }

        //reads Category from url
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string,  object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        // pagination styling
        public bool PageClassEnabled { get; set; } = false;

        public string PageClass { get; set; } = string.Empty;

        public string PageClassNormal { get; set; } = string.Empty;

        public string PageClassSelected { get; set; } = string.Empty;


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(ViewContext != null && PageModel != null)
            {
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");
                for(int i =1; i <= PageModel.TotalPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");

                    PageUrlValues["productPage"] = i;

                    tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                    //tag.Attributes["href"] = urlHelper.Action(PageAction, new { productPage = i });

                    //Adding a style class for pagination
                    if (PageClassEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    tag.InnerHtml.Append(i.ToString());
                    result.InnerHtml.AppendHtml(tag);
                }
                output.Content.AppendHtml(result.InnerHtml);
            }
        }

    }
}
