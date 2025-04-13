using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace ComponentChallenge.Components
{
    public class Hx : ComponentBase
    {
        [Parameter] public int Level { get; set; } = 1;
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Class { get; set; } = "";

        protected override void OnParametersSet()
        {
            Level = Math.Clamp(Level, 1, 6);
            base.OnParametersSet();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            string tagName = $"h{Level}";

            builder.OpenElement(0, tagName);

            if (!string.IsNullOrEmpty(Class))
            {
                builder.AddAttribute(1, "class", Class);
            }

            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}
