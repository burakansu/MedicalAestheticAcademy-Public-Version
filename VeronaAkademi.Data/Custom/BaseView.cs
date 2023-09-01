using Microsoft.AspNetCore.Mvc.Razor;

namespace VeronaAkademi.Data.Custom
{
    public abstract class BaseView : RazorPage<object>
    {
        public string Test()
        {
            return "1";
        }
    }
}
