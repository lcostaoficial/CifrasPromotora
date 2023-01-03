using System.Web.Mvc;

namespace CIFRAS.Infra.CrossCutting.Helpers
{
    public static class HtmlGenerator
    {
        public static MvcHtmlString TableButton(this HtmlHelper helper, string classButton, string classIcon, string title, string url)
        {
            TagBuilder tagA = new TagBuilder("a");
            tagA.MergeAttribute("class", classButton);
            tagA.MergeAttribute("title", title);
            tagA.MergeAttribute("href", url);
            tagA.MergeAttribute("data-toggle", "tooltip");
            TagBuilder tagI = new TagBuilder("i");
            tagI.MergeAttribute("class", classIcon);
            tagA.MergeAttribute("aria-hidden", "true");
            tagA.InnerHtml += tagI;
            return MvcHtmlString.Create(tagA.ToString(TagRenderMode.Normal));
        }

        public static SelectList SelectListForBoolean(object selectedValue = null)
        {
            SelectListItem[] selectListItems = new SelectListItem[2];
            var itemTrue = new SelectListItem();
            itemTrue.Value = "true";
            itemTrue.Text = "Sim";
            selectListItems[0] = itemTrue;
            var itemFalse = new SelectListItem();
            itemFalse.Value = "false";
            itemFalse.Text = "Não";
            selectListItems[1] = itemFalse;
            var selectList = new SelectList(selectListItems, "Value", "Text", selectedValue);
            return selectList;
        }
    }
}