using Microsoft.AspNetCore.Razor.TagHelpers;
namespace APIDemo.Helpers
{
    [HtmlTargetElement("custom-demo")]
    public class CustomDemo:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("class", "custom-demo-class");
            base.Process(context, output);
        }
    }
}
