using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Reflection;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Custom;
using VeronaAkademi.Data.Entities.Base;
using VeronaAkademi.Data.EntityFramework;
using System.Linq.Dynamic.Core;
using System.Collections;

namespace VeronaAkademi.Panel.Controllers
{
    public class BaseController : Controller
    {
        private Db _db;

        protected DbIncludeHelper _includeHelper;
        public CookieHelper cookieHelper { get; set; }
        private readonly IConfiguration _config;
        protected IWebHostEnvironment _webHostEnv { get; set; }
        protected IHttpContextAccessor _httpContextAccessor { get; set; }

        public BaseController(IConfiguration config, IWebHostEnvironment webHostEnv, IHttpContextAccessor httpContextAccessor)
        {
            cookieHelper = new CookieHelper();
            _db = new Db();
            _config = config;
            _webHostEnv = webHostEnv;
            _httpContextAccessor = httpContextAccessor;
            _includeHelper = new DbIncludeHelper();
        }


        public Db Db
        {
            get
            {
                if (_db == null)
                    _db = new Db();

                return _db;
            }
        }


        public Personel CurrentUser
        {
            get
            {
                var session = HttpContext.Session.GetString("Personel");
                var deserialized = JsonConvert.DeserializeObject<Personel>(session);
                return deserialized;
            }
            set
            {
                var serialized = JsonConvert.SerializeObject(value);
                HttpContext.Session.SetString("Personel", serialized);
            }
        }

        public string EnvironmentV
        {
            get
            {
                return _config.GetValue<string>("Environment");
            }
        }

        public List<dynamic> RestrictionControlActionList(string pre = "Development", string nameSpace = "VeronaAkademi.Panel.Controllers")
        {

            Assembly asm = Assembly.GetExecutingAssembly();
            var controlleractionlist = asm.GetTypes()
                    .Where(type => typeof(Controller).IsAssignableFrom(type) && type.Namespace == nameSpace)
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new
                    {
                        Controller = x.DeclaringType.Name,
                        Action = x.Name,
                        ReturnType = x.ReturnType.Name,
                        Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))),
                        Attribute = x.GetCustomAttributes().FirstOrDefault(f => f.GetType().Name == pre + "Attribute"),
                        NameSpace = nameSpace
                    })
                    .Where(x => x.Attributes.Contains(pre))
                    .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList<dynamic>();

            return controlleractionlist;


        }
        public virtual void RestrictionFix(string pre = "Yetki", string nameSpace = "VeronaAkademi.Panel.Controllers")
        {
            //yeni bir yetki eklediten veya bir yetkiyi güncelledikten sonra bu metodun bir kere manuel çağrılması gerekmektedir.
            //canlıya alınınca bu metodu yoruma alabilirsiniz

            Assembly asm = Assembly.GetExecutingAssembly();
            var controlleractionlist = asm.GetTypes()
                    .Where(type => typeof(Controller).IsAssignableFrom(type) && type.Namespace == nameSpace)
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new
                    {
                        Controller = x.DeclaringType.Name,
                        Action = x.Name,
                        ReturnType = x.ReturnType.Name,
                        Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))),
                        Attribute = x.GetCustomAttributes().FirstOrDefault(f => f.GetType().Name == pre + "Attribute"),
                        NameSpace = nameSpace
                    })
                    .Where(x => x.Attributes.Contains(pre))
                    .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList<dynamic>();

            var RestrictionListe = Db.Restriction.ToList();
            foreach (var yetki in controlleractionlist)
            {
                var ks = new Restriction();
                ks.Description = yetki.Attribute.GetType().GetProperty("Description").GetValue(yetki.Attribute, null).ToString();
                ks.Action = yetki.Action;
                ks.Name = "";
                ks.Controller = yetki.Controller;
                ks.Group = yetki.Attribute.GetType().GetProperty("Group").GetValue(yetki.Attribute, null).ToString();
                ks.TargetDivId = yetki.Attribute.GetType().GetProperty("TargetDiv").GetValue(yetki.Attribute, null).ToString();
                ks.NameSpace = yetki.NameSpace;


                var _yetki = RestrictionListe.FirstOrDefault(x => x.Controller == yetki.Controller && x.Action == yetki.Action);
                if (_yetki == null)
                {
                    //veri tabanına yetkiyi ekle
                    Db.Restriction.Add(ks);
                }
                else
                {
                    _yetki.Description = ks.Description;
                    _yetki.Group = ks.Group;
                    _yetki.Controller = ks.Controller;
                    _yetki.Action = ks.Action;
                    _yetki.NameSpace = ks.NameSpace;
                    _yetki.TargetDivId = ks.TargetDivId;

                }
                Db.SaveChanges();
            }

        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var _personelId = _config.GetValue<string>("CookieSettings:PersonelIdTag");

            if (!cookieHelper.Exists(_personelId))
            {
                string redirectUrl = string.Format("?returnUrl={0}",
                            filterContext.HttpContext.Request.Path);
                filterContext.Result = Redirect("/Login/" + redirectUrl);
            }

            else
            {
                var personelId = Convert.ToInt32(cookieHelper.Get(_personelId));

                var _currentUser = _db.Personel
                    .Include(x => x.PersonelInterfaceRestrictionRelation)
                        .ThenInclude(x => x.Restriction)
                    .FirstOrDefault(i => i.PersonelId == personelId);

                if (HttpContext.Session.GetString("Personel") == null)
                {
                    HttpContext.Session.SetString("Personel", JsonConvert.SerializeObject(_currentUser, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                }



                // Kısıtlaması var mı yok mu kontrol et
                var descriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
                var actionName = descriptor.ActionName;
                var controllerName = descriptor.ControllerName + "Controller";

                if (EnvironmentV != "dev")
                {
                    if (RestrictionControlActionList().Any(i => i.Controller == controllerName && i.Action == actionName))
                    {
                        var RestrictionList = _currentUser.PersonelInterfaceRestrictionRelation?.Select(s => s.Restriction).ToList();
                        var Restriction = RestrictionList?.FirstOrDefault(i => i.Controller == controllerName && i.Action == actionName);
                        var _Restriction = Db.Restriction.FirstOrDefault(i => i.Controller == controllerName && i.Action == actionName);
                        if (Restriction == null)
                        {
                            var type = filterContext.HttpContext.Request.Headers["X-Requested-With"].ToString();
                            if (type == "XMLHttpRequest")
                            {
                                // Log exception first
                                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;

                                var r = new Response<string>
                                {
                                    Description = "Bu işlemi yapmak için yetkiniz yok",
                                    Success = false,
                                    Data = _Restriction?.TargetDivId

                                };

                                ContentResult content = new ContentResult();
                                content.ContentType = "application/json";
                                content.Content = JsonConvert.SerializeObject(r);
                                filterContext.Result = content;
                            }
                            else
                            {
                                var TempData = ((Controller)filterContext.Controller).TempData;
                                TempData["Status"] = "Bu işlemi yapmak için yetkiniz yok";
                                filterContext.Result = RedirectToAction("Home", "Index");
                            }
                        }
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }

    public class BaseController<T> : BaseController where T : BaseEntity
    {
        public IHttpContextAccessor _http { get; set; }
        public HttpRequest _request { get; set; }
        public DbSet<T> dbset;
        public GenericRepository<T> repo = new GenericRepository<T>();


        public BaseController(IConfiguration config, IHttpContextAccessor httpcontext, IWebHostEnvironment webHostEnvironment) : base(config, webHostEnvironment, httpcontext)
        {
            _http = httpcontext;
            _request = _http.HttpContext.Request;
            dbset = Db.Set<T>();
        }

        public BaseController(IConfiguration config, IWebHostEnvironment webHostEnv, IHttpContextAccessor httpContextAccessor) : base(config, webHostEnv, httpContextAccessor)
        {
        }

        public virtual JsonResult Kaydet(T form)
        {

            var response = new Response<List<string>>();

            if (form.tempId == 0)
            {
                form.CreateDate = DateTime.Now;
                form.Active = true;
                form.Deleted = false;
                dbset.Add(form);
                Db.SaveChanges();
                response.Success = true;
                response.Description = "Kayıt edildi.";

            }
            else
            {
                T entity = null;

                var model = dbset.AsQueryable();
                var dbInclude = _includeHelper.GetField(typeof(T).Name);

                if (dbInclude != null)
                {
                    foreach (var include in dbInclude)
                    {
                        model = model.Include(include);
                    }
                    entity = model.FirstOrDefault(o => EF.Property<int>(o, Db.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0].Name) == form.tempId);
                }
                else
                    entity = dbset.Find(form.tempId);


                if (entity != null)
                {
                    // Alanları güncelle
                    var propList = entity.GetType().GetProperties().Where(prop => !prop.IsDefined(typeof(NotMappedAttribute), false)).ToList();
                    foreach (var prop in propList)
                    {
                        if (form.Include.Contains(prop.Name))
                        {
                            prop.SetValue(entity, form.GetType().GetProperty(prop.Name).GetValue(form, null));
                        }
                    }
                    entity.UpdateDate = DateTime.Now;

                    // İlişkili özellikler
                    var relatedPropList = entity.GetType().GetProperties().Where(prop => prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>)).ToList();
                    foreach (var relatedProp in relatedPropList)
                    {
                        var relatedData = form.GetType().GetProperty(relatedProp.Name).GetValue(form, null);
                        if (relatedData != null)
                        {
                            var _relatedEntityList = JsonConvert.SerializeObject(relatedData, new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                            });
                            var elementType = relatedProp.PropertyType.GetGenericArguments()[0];
                            var listType = typeof(List<>).MakeGenericType(elementType);
                            var relatedEntityList = (ICollection)JsonConvert.DeserializeObject(_relatedEntityList, listType);

                            // Koleksiyonu temizle
                            relatedProp.PropertyType.GetMethod("Clear").Invoke(relatedEntityList, null);

                            foreach (var data in (IEnumerable)relatedData)
                            {
                                relatedEntityList.GetType().GetMethod("Add").Invoke(relatedEntityList, new[] { data });
                            }

                            relatedProp.SetValue(entity, relatedEntityList); // İlgili özelliği form verisiyle güncelle
                        }
                    }

                    Db.SaveChanges();
                    response.Success = true;
                    response.Description = "Güncellendi.";
                }
                else
                {
                    response.Success = false;
                    response.Description = "kayıt bulunamadı.";
                }
            }

            return Json(response);
        }

        public virtual JsonResult Durum(int id)
        {
            var response = new Response();
            var model = dbset.Find(id);
            if (model != null)
            {
                var status = model.Active == true ? false : true;
                var title = model.Active == true ? "Pasif" : "Aktif";
                model.Active = status;

                if (status == true)
                    model.Deleted = false;
                
                Db.SaveChanges();
                response.Success = true;
                response.Description = "kayıt " + title + " edildi";
                return Json(response);
            }
            response.Success = false;
            response.Description = "kayıt bulunamadı";
            return Json(response);
        }

        public virtual JsonResult Sil(int id)
        {
            var response = new Response();
            var model = dbset.Find(id);
            if (model != null)
            {
                model.Active = false;
                model.Deleted = true;
                Db.SaveChanges();
                response.Success = true;
                response.Description = "kayıt silindi";
                return Json(response);
            }
            response.Success = false;
            response.Description = "kayıt bulunamadı";
            return Json(response);
        }

        public virtual IActionResult Form(int id = 0, int relationId = 0)
        {
            T model = null;
            var list = dbset.AsQueryable();

            var dbInclude = _includeHelper.GetField(typeof(T).Name);

            if (dbInclude != null)
            {
                foreach (var include in dbInclude)
                {
                    list = list.Include(include);
                }
                model = list.FirstOrDefault(o => EF.Property<int>(o, Db.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0].Name) == id);
            }
            else
                model = dbset.Find(id);

            ViewBag.relationId = relationId;

            return PartialView(model);
        }





        public virtual IActionResult GetList(int page = 1, int adet = 10)
        {
            return GetListModel(repo.GetAll(x => !x.Deleted), page, adet);
        }
        public IActionResult GetListModel(IQueryable<T> model, int page = 1, int adet = 10, List<string> Filter = null)
        {
            var searchText = Request.Query["searchText"].ToString();
            var orderBy = Request.Query["orderBy"].ToString();
            var orderWay = Request.Query["orderWay"].ToString();

            if (page < 1)
                page = 1;

            var count = model.Count();
            var pager = new Pager(count, page, adet);
            pager.SearchText = searchText;

            if (!string.IsNullOrEmpty(orderBy))
            {
                var _orderWay = !string.IsNullOrEmpty(orderWay) ? orderWay : "Desc";
                model = model.OrderBy(orderBy + " " + _orderWay);
            }
            else
                model = model.OrderByDescending(x => x.CreateDate);


            model = model.Skip((page - 1) * adet).Take(adet);

            ViewBag.Pager = pager;
            ViewBag.Toplam = count;

            return PartialView(model.Where(x => !x.Deleted).ToList());
        }

        public virtual JsonResult TopluSil(List<int> selectedValues)
        {
            var response = new Response();
            int count = 0;
            if (selectedValues.Count() > 0)
            {
                foreach (var item in selectedValues)
                {
                    try
                    {
                        var entity = repo.Get(item);
                        entity.Deleted = true;
                        entity.Active = false;
                        repo.Update(entity);
                        count++;
                    }
                    catch (Exception ex)
                    {
                        //hata mesajı kaydedilebilir
                    }
                }
                response.Success = true;
                response.Description = $"{count} adet kayıt silindi. başarısız {selectedValues.Count() - count}";
            }
            else
            {
                response.Success = false;
                response.Description = "en az bir adet kayıt seçmeniz gerekiyor.";
            }
            return Json(response);

        }
        public virtual JsonResult TopluAktif(List<int> selectedValues)
        {
            var response = new Response();
            int count = 0;
            if (selectedValues.Count() > 0)
            {
                foreach (var item in selectedValues)
                {
                    try
                    {
                        var entity = repo.Get(item);
                        entity.Deleted = false;
                        entity.Active = true;
                        repo.Update(entity);
                        count++;
                    }
                    catch (Exception ex)
                    {
                        //hata mesajı kaydedilebilir
                    }
                }
                response.Success = true;
                response.Description = $"{count} adet kayıt aktifleştirildi. başarısız {selectedValues.Count() - count}";
            }
            else
            {
                response.Success = false;
                response.Description = "en az bir adet kayıt seçmeniz gerekiyor.";
            }

            return Json(response);
        }
        public virtual JsonResult TopluPasif(List<int> selectedValues)
        {
            var response = new Response();
            int count = 0;
            if (selectedValues.Count() > 0)
            {
                foreach (var item in selectedValues)
                {
                    try
                    {
                        var entity = repo.Get(item);
                        entity.Active = false;
                        repo.Update(entity);
                        count++;
                    }
                    catch (Exception ex)
                    {
                        //hata mesajı kaydedilebilir
                    }
                }
                response.Success = true;
                response.Description = $"{count} adet kayıt pasifleştirildi. başarısız {selectedValues.Count() - count}";
            }
            else
            {
                response.Success = false;
                response.Description = "en az bir adet kayıt seçmeniz gerekiyor.";
            }

            return Json(response);
        }
    }

}