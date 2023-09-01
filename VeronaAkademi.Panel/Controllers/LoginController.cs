using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Panel.Controllers
{
    public class LoginController : Controller
    {
        private readonly CookieHelper cookieHelper;
        private readonly IConfiguration _config;

        public string UserNameTag { get; set; }
        public string PasswordTag { get; set; }
        public string PersonelIdTag { get; set; }


        public LoginController(IConfiguration config)
        {
            cookieHelper = new CookieHelper();
            _config = config;

            PersonelIdTag = _config.GetValue<string>("CookieSettings:PersonelIdTag");
            UserNameTag = _config.GetValue<string>("CookieSettings:UserNameTag");
            PasswordTag = _config.GetValue<string>("CookieSettings:PasswordTag");

        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {

            if (cookieHelper.Exists(PersonelIdTag))
            {
                return Redirect("/");
            }

            if (cookieHelper.Exists(UserNameTag) && cookieHelper.Exists(PasswordTag))
            {
                ViewBag.UserName = cookieHelper.Get(UserNameTag);
                ViewBag.Password = cookieHelper.Get(PasswordTag);
                ViewBag.Remember = "Checked";
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(string email, string password, string remember = "off", string returnUrl = "")
        {
            var db = new Db();

            var user = db.Personel
                .Include(x => x.PersonelType)
                .Include(y => y.PersonelInterfaceRestriction)
                .Include(y => y.PersonelInterfaceRestrictionRelation)
                    .ThenInclude(x => x.Restriction)
                .FirstOrDefault(i => i.Email == email && i.Password == password);

            if (user != null)
            {

                cookieHelper.Set(PersonelIdTag, user.PersonelId.ToString(), 1);
                if (remember == "on")
                {
                    cookieHelper.Set(UserNameTag, email, DateTime.Now.AddYears(1));
                    cookieHelper.Set(PasswordTag, password, DateTime.Now.AddYears(1));
                }
                else
                {
                    cookieHelper.Delete(UserNameTag);
                    cookieHelper.Delete(PasswordTag);
                }

                var contextAccessor = new HttpContextAccessor();

                HttpContext.Session.SetString("Personel", JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

                //giriş yapan kullanıcının yetkilerini kaydet
                var Restrictions = user.PersonelInterfaceRestrictionRelation?.AsEnumerable()
                    .Select(x => new Restriction
                    {
                        RestrictionId = x.RestrictionId,
                        Name = x.Restriction.Name,
                        Group = x.Restriction.Group,
                        Controller = x.Restriction.Controller,
                        Action = x.Restriction.Action,
                        NameSpace = x.Restriction.NameSpace,

                    }).ToList();

                contextAccessor.HttpContext?.Session.SetString("Restrictions", JsonConvert.SerializeObject(Restrictions));

                var url = !string.IsNullOrEmpty(returnUrl) ? returnUrl : "/";
                return Redirect(url);
            }
            else
                ViewBag.err = "Kullanıcı adı yada şifre hatalı";

            return View();
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            cookieHelper.Delete(PersonelIdTag);
            return Redirect("/login");
        }
    }
}
