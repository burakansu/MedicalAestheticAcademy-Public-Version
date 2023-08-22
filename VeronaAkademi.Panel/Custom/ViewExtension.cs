using Newtonsoft.Json;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Panel.Custom
{
    public static class ViewExtension
    {
        public static Personel CurrentUser(this HttpContext context)
        {
            var sessionVal = context.Session.GetString("Personel");
            if (sessionVal != null) {
                return JsonConvert.DeserializeObject<Personel>(sessionVal);
            }
            return null;
            
        }
    }
}
