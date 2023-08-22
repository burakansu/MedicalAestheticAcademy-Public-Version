using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VeronaAkademi.Core.Helper;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;
using Iyzipay.Model;
using Iyzipay.Request;
using Currency = Iyzipay.Model.Currency;
using Iyzipay;
using Product = VeronaAkademi.Data.Entities.Product;

namespace VeronaAkademi.Ui.Controllers
{
    public class BasketController : Controller
    {
        private readonly IConfiguration _config;
        CookieHelper cookieHelper = new CookieHelper();
        private Db _db;
        public Db Db
        {
            get
            {
                if (_db == null)
                    _db = new Db();

                return _db;
            }
        }


        //Actions
        [HttpPost]
        public IActionResult Save(string[] selectedLessonIds = null, int courseid = 0, int packageid = 0, int advisorid = 0)
        {
            int customerid = GetCustomerId();

            List<Basket> baskets = new List<Basket>();
            var courselessons = Db.Lesson.Where(x => x.CourseId == courseid).ToList();

            List<Order> orders = Db.Order
                .Include(x => x.Product)
                .Where(x => x.CustomerId == customerid && x.IsDeleted == false)
                .ToList();

            List<Basket> basketsdb = Db.Basket
                .Where(x => x.CustomerId == customerid)
                .Include(x => x.Product)
                .ToList();

            if (packageid != 0 && !basketsdb.Any(x => x.Product.ProductId == packageid && x.CustomerId == customerid && x.Product.Type == 2) && !Db.CustomerPackageRelation.Any(x => x.PackageId == packageid && x.CustomerId == customerid))
            {
                AddProductToBasket(customerid, packageid, 2);
                return Json(new { success = true });
            }
            else if (advisorid != 0 && !basketsdb.Any(x => x.Product.ProductId == advisorid && x.CustomerId == customerid && x.Product.Type == 3) && !Db.CustomerAdvisorRelation.Any(x => x.AdvisorId == advisorid && x.CustomerId == customerid))
            {
                AddProductToBasket(customerid, advisorid, 3);
                return Json(new { success = true });
            }
            else if (courseid != 0)
            {
                int[] ints = Db.Course.Include(x => x.Lesson).Single(x => x.CourseId == courseid).Lesson.Select(x => x.LessonId).ToArray();

                RemoveLessonFromBasket(customerid, ints);

                basketsdb = Db.Basket
                .Where(x => x.CustomerId == customerid)
                .Include(x => x.Product)
                .ToList();

                foreach (var lessonid in ints)
                {
                    if ((!basketsdb.Any(b => b.Product.ProductId == lessonid && b.CustomerId == customerid && b.Product.Type == 1)) && (!orders.Any(b => b.Product.ProductId == lessonid && b.CustomerId == customerid && b.Product.Type == 1)))
                    {
                        AddProductToBasket(customerid, lessonid, 1, baskets);
                    }
                }
            }
            else if (selectedLessonIds.Count() > 0)
            {
                var crs = Db.Lesson.Single(x => x.LessonId == Int32.Parse(selectedLessonIds[0])).CourseId;
                int[] ints = Db.Course.Include(x => x.Lesson).Single(x => x.CourseId == crs).Lesson.Select(x => x.LessonId).ToArray();

                RemoveLessonFromBasket(customerid, ints);

                foreach (var lessonid in selectedLessonIds)
                {
                    AddProductToBasket(customerid, Int32.Parse(lessonid), 1, baskets);
                }
            }

            if (baskets.Count > 0)
                Db.Basket.AddRange(baskets);

            Db.SaveChanges();

            return Json(new { success = true });
        }

        public IActionResult Delete(string lessonId)
        {
            int customerid = GetCustomerId();
            Basket basket = Db.Basket.Single(x => x.Product.ProductId == Int32.Parse(lessonId) && x.CustomerId == customerid);
            Db.Basket.Remove(basket);
            Db.SaveChanges();

            return Json(new { success = true });
        }

        public IActionResult ClearCourseBasket(int courseid)
        {
            int customerid = GetCustomerId();
            int[] ints = Db.Course.Include(x => x.Lesson).Single(x => x.CourseId == courseid).Lesson.Select(x => x.LessonId).ToArray();

            RemoveLessonFromBasket(customerid, ints);
            Db.SaveChanges();

            return Json(new { success = true });
        }

        public IActionResult ClearBasket()
        {
            int customerid = GetCustomerId();
            List<Basket> baskets = Db.Basket.Include("Product").Where(x => x.CustomerId == customerid).ToList();
            List<Product> products = baskets.Select(b => b.Product).ToList();

            Db.Basket.RemoveRange(baskets);
            Db.Product.RemoveRange(products);
            Db.SaveChanges();

            return Json(new { success = true });
        }

        public IActionResult SideBarBasket()
        {
            int customerid = GetCustomerId();
            List<Basket> baskets = Db.Basket.Include(x => x.Product).Where(x => x.CustomerId == customerid && x.Product.Type == 1).ToList();

            List<int> courseids = GetCompletedCourseIds(baskets);
            int Price = CalculateTotalPrice(customerid, courseids);

            ViewBag.total = Price;

            return View();
        }

        public IActionResult Cart(int id = 0, int packageid = 0, int advisorid = 0)
        {
            int courseid = id;
            int customerid = GetCustomerId();

            List<Order> orders = Db.Order
                .Where(x => x.CustomerId == customerid && x.IsDeleted == false)
                .ToList();
            List<Basket> baskets = new List<Basket>();
            List<Basket> basketsdb = Db.Basket.ToList();
            List<Basket> basketsdbs = Db.Basket.Include(x => x.Product).Where(x => x.Product.Type == 1 && x.CustomerId == customerid).ToList();

            List<int> courseids = GetCompletedCourseIds(basketsdbs);
            int pcount = Db.Basket.Where(x => x.Product.ProductId == packageid && x.CustomerId == customerid && x.Product.Type == 2).Count();
            int acount = Db.Basket.Where(x => x.Product.ProductId == advisorid && x.CustomerId == customerid && x.Product.Type == 3).Count();

            if (packageid != 0 && pcount == 0)
            {
                AddProductToBasket(customerid, packageid, 2);
                return View();
            }
            else if (advisorid != 0 && acount == 0)
            {
                AddProductToBasket(customerid, advisorid, 3);
                return View();
            }
            else if (courseid != 0)
            {
                var dblessons = Db.Lesson.Where(x => x.CourseId == courseid).ToList();
                int[] ints = dblessons.Select(x => x.LessonId).ToArray();

                RemoveLessonFromBasket(customerid, ints);

                foreach (var item in dblessons)
                {
                    if (!basketsdb.Any(b => b.ProductId == item.LessonId))
                    {
                        if (!orders.Any(b => b.Product.ProductId == item.LessonId && b.Product.Type == 1 && b.CustomerId == customerid))
                        {
                            AddProductToBasket(customerid, item.LessonId, 1, baskets);
                        }
                    }
                }

                if (baskets.Count > 0)
                    Db.Basket.AddRange(baskets);

                Db.SaveChanges();
            }

            int Price = CalculateTotalPrice(customerid, courseids);
            ViewBag.total = Price;
            return View();
        }

        [HttpGet]
        public IActionResult Table()
        {
            int customerid = GetCustomerId();
            var basket = Db.Basket.Include(x => x.Product).Where(x => x.CustomerId == customerid).ToList();

            var basketLessonIdList = basket
                .Where(x => x.Product.Type == 1 && x.CustomerId == customerid)
                .Select(x => x.Product.ProductId);

            var basketPackageIdList = basket
                .Where(x => x.Product.Type == 2 && x.CustomerId == customerid)
                .Select(x => x.Product.ProductId);

            var basketAdvisorIdList = basket
                .Where(x => x.Product.Type == 3 && x.CustomerId == customerid)
                .Select(x => x.Product.ProductId);

            var lessons = Db.Lesson
                .Include(x => x.Currency)
                .Include(x => x.Course)
                .Where(x => basketLessonIdList.Contains(x.LessonId))
                .ToList();

            var packages = Db.Package
                .Include(x => x.Currency)
                .Include(x => x.PackageCourseRelation)
                    .ThenInclude(x => x.Course)
                .Include(x => x.PackagePracticeLessonRelation)
                    .ThenInclude(x => x.PracticeLesson)
                .Include(x => x.PackageAdvisorRelation)
                    .ThenInclude(x => x.Advisor)
                .Where(x => basketPackageIdList.Contains(x.PackageId))
                .ToList();

            var advisors = Db.Advisor
                .Include(x => x.PackageAdvisorRelation)
                    .ThenInclude(x => x.Package)
                .Include(x => x.AdvisorCourseRelation)
                    .ThenInclude(x => x.Course)
                .Include(x => x.Currency)
                .Include(x => x.Lecturer)
                .Where(x => basketAdvisorIdList.Contains(x.AdvisorId))
                .ToList();

            ViewBag.lessons = lessons;
            ViewBag.packages = packages;
            ViewBag.advisors = advisors;

            List<int> courseids = GetCompletedCourseIds(basket);
            int price = CalculateTotalPrice(customerid, courseids);
            ViewBag.total = price;

            return PartialView();
        }

        public IActionResult Checked(int id)
        {
            int customerid = id;

            List<Basket> baskets = Db.Basket.Include(x => x.Product).Where(x => x.CustomerId == customerid).ToList();
            List<Order> orders = new List<Order>();
            List<Lesson> lessons = GetLessonsFromBaskets(baskets);

            foreach (var course in Db.Course.Include(x => x.Lesson).ToList())
            {
                int count = 0;

                foreach (var lesson in course.Lesson)
                {
                    if (lessons.Where(x => x.LessonId == lesson.LessonId).Count() > 0)
                        count++;
                }

                if (course.Lesson.Count() == count && Db.CustomerCourseRelation.Where(x => x.CourseId == course.CourseId && x.CustomerId == customerid).Count() == 0)
                {
                    AddCustomerCourseRelation(customerid, course.CourseId);
                }
            }

            foreach (var item in baskets)
            {
                Order order = new Order();
                order.CustomerId = customerid;
                order.EklemeTarihi = DateTime.Now;

                switch (item.Product.Type)
                {
                    case 1:
                        order.ProductId = item.ProductId;
                        AddCustomerLessonRelation(customerid, item.Product.ProductId);
                        break;
                    case 2:
                        order.ProductId = item.ProductId;
                        AddCustomerPackageRelation(customerid, item.Product.ProductId);
                        AddCustomerCourseRelationsFromPackage(customerid, item.Product.ProductId);
                        AddCustomerAdvisorRelationsFromPackage(customerid, item.Product.ProductId);
                        AddCustomerPracticeLessonRelationsFromPackage(customerid, item.Product.ProductId);
                        break;
                    case 3:
                        order.ProductId = item.ProductId;
                        AddCustomerAdvisorRelation(customerid, item.Product.ProductId);
                        break;
                }

                order.FinishDate = DateTime.Now.AddMonths(6);
                orders.Add(order);
            }

            if (orders.Count > 0)
                Db.Order.AddRange(orders);

            Db.RemoveRange(Db.Basket.Where(x => x.CustomerId == customerid));
            Db.SaveChanges();

            try { cookieHelper.Set("CustomerId", customerid.ToString(), DateTime.Now.AddYears(1)); } finally { }

            return View();
        }





        // Common Methods
        private int GetCustomerId()
        {
            return Int32.Parse(cookieHelper.Get("CustomerId"));
        }

        private void AddProductToBasket(int customerId, int productId, int productType, List<Basket> baskets = null)
        {
            Product product = new Product();
            product.ProductId = productId;
            product.Type = productType;

            Db.Product.Add(product);
            Db.SaveChanges();

            Basket basket = new Basket();
            basket.CustomerId = customerId;
            basket.ProductId = product.Id;

            if (baskets != null)
                baskets.Add(basket);

            else
                Db.Basket.Add(basket);

            Db.SaveChanges();
        }

        private void RemoveLessonFromBasket(int customerId, int[] lessonIds)
        {
            foreach (var item in lessonIds)
            {
                if (Db.Basket.Where(x => x.Product.ProductId == item && x.CustomerId == customerId && x.Product.Type == 1).Count() > 0)
                {
                    Db.Basket.Remove(Db.Basket.Single(x => x.Product.ProductId == item && x.CustomerId == customerId && x.Product.Type == 1));
                }
            }

            Db.SaveChanges();
        }

        private List<int> GetCompletedCourseIds(List<Basket> baskets)
        {
            List<int> courseids = new List<int>();

            foreach (var baskett in baskets.Where(x => x.Product.Type == 1))
            {
                int cid = Db.Lesson.Single(x => x.LessonId == baskett.Product.ProductId).CourseId;
                int count = 0;
                Course course = Db.Course.Include(x => x.Lesson).Single(x => x.CourseId == cid);

                foreach (var lesson in course.Lesson)
                {
                    if (baskets.Where(x => x.Product.ProductId == lesson.LessonId).Count() > 0)
                        count++;
                }

                if (course.Lesson.Count() == count && !(courseids.Contains(cid)))
                    courseids.Add(cid);

            }

            return courseids;
        }

        private int CalculateTotalPrice(int customerId, List<int> courseIds)
        {
            var baskets_db = Db.Basket.Include(x => x.Product).Where(x => x.CustomerId == customerId).ToList();
            int Price = 0;

            foreach (var basket in baskets_db)
            {
                switch (basket.Product.Type)
                {
                    case 1:
                        int coursid = Db.Lesson.Single(x => x.LessonId == basket.Product.ProductId).CourseId;
                        if (!(courseIds.Count > 0))
                        {
                            if (!(courseIds.Contains(coursid)))
                                Price += Db.Lesson.Single(x => x.LessonId == basket.Product.ProductId).Price;
                        }
                        break;
                    case 2:
                        Price += Db.Package.Single(x => x.PackageId == basket.Product.ProductId).Price;
                        break;
                    case 3:
                        Price += Db.Advisor.Single(x => x.AdvisorId == basket.Product.ProductId).Price;
                        break;
                }
            }

            if (courseIds.Count() > 0)
            {
                foreach (var item in courseIds)
                {
                    Price += Db.Course.Single(x => x.CourseId == item).Price;
                }
            }

            return Price;
        }

        private List<Lesson> GetLessonsFromBaskets(List<Basket> baskets)
        {
            List<Lesson> lessons = new List<Lesson>();

            foreach (var basket in baskets)
            {
                if (basket.Product.Type == 1)
                    lessons.Add(Db.Lesson.Single(x => x.LessonId == basket.Product.ProductId));
            }

            return lessons;
        }

        private void AddCustomerCourseRelation(int customerId, int courseId)
        {
            if (Db.CustomerCourseRelation.Where(x => x.CourseId == courseId && x.CustomerId == customerId).Count() == 0)
            {
                CustomerCourseRelation customerCourseRelation = new CustomerCourseRelation();
                customerCourseRelation.CustomerId = customerId;
                customerCourseRelation.CourseId = courseId;
                customerCourseRelation.Completed = 0;
                Db.CustomerCourseRelation.Add(customerCourseRelation);
                Db.SaveChanges();
            }
        }

        private void AddCustomerLessonRelation(int customerId, int lessonId)
        {
            if (Db.CustomerLessonRelation.Where(x => x.LessonId == lessonId && x.CustomerId == customerId).Count() == 0)
            {
                CustomerLessonRelation customerLessonRelation = new CustomerLessonRelation();
                customerLessonRelation.CustomerId = customerId;
                customerLessonRelation.LessonId = lessonId;
                customerLessonRelation.Completed = 0;
                Db.CustomerLessonRelation.Add(customerLessonRelation);
            }
        }

        private void AddCustomerPackageRelation(int customerId, int packageId)
        {
            if (Db.CustomerPackageRelation.Where(x => x.PackageId == packageId && x.CustomerId == customerId).Count() == 0)
            {
                CustomerPackageRelation customerPackageRelation = new CustomerPackageRelation();
                customerPackageRelation.PackageId = packageId;
                customerPackageRelation.CustomerId = customerId;
                Db.CustomerPackageRelation.Add(customerPackageRelation);
                Db.SaveChanges();
            }
        }

        private void AddCustomerCourseRelationsFromPackage(int customerId, int packageId)
        {
            var package = Db.Package.Include(x => x.PackageCourseRelation).Single(x => x.PackageId == packageId);

            foreach (var i in package.PackageCourseRelation.ToList())
            {
                if (Db.CustomerCourseRelation.Where(x => x.CourseId == i.CourseId && x.CustomerId == customerId).Count() == 0)
                {
                    AddCustomerCourseRelation(customerId, i.CourseId);
                }

                foreach (var l in i.Course.Lesson)
                {
                    AddCustomerLessonRelation(customerId, l.LessonId);
                }
            }
        }

        private void AddCustomerLessonRelationsFromPackage(int customerId, int packageId)
        {
            var courseIds = Db.PackageCourseRelation.Where(x => x.PackageId == packageId).ToList();

            foreach (var item in courseIds)
            {
                var course = Db.Course.Include(x => x.Lesson).Single(x => x.CourseId == item.CourseId);

                foreach (var lesson in course.Lesson)
                {
                    AddCustomerLessonRelation(customerId, lesson.LessonId);
                }
            }
        }

        private void AddCustomerPracticeLessonRelationsFromPackage(int customerId, int packageId)
        {
            var package = Db.Package.Include(x => x.PackagePracticeLessonRelation).Single(x => x.PackageId == packageId);
            var packagepracticelessons = package.PackagePracticeLessonRelation.ToList();

            foreach (var item in packagepracticelessons)
            {
                if (Db.CustomerPracticeLessonRelation.Where(x => x.PracticeLessonId == item.PracticeLessonId && x.CustomerId == customerId).Count() == 0)
                {
                    CustomerPracticeLessonRelation customerPracticeLessonRelation = new CustomerPracticeLessonRelation();
                    customerPracticeLessonRelation.CustomerId = customerId;
                    customerPracticeLessonRelation.PracticeLessonId = 1;
                    Db.CustomerPracticeLessonRelation.Add(customerPracticeLessonRelation);
                }
            }
        }

        private void AddCustomerAdvisorRelationsFromPackage(int customerId, int packageId)
        {
            var package = Db.Package.Include(x => x.PackageAdvisorRelation).Single(x => x.PackageId == packageId);

            foreach (var a in package.PackageAdvisorRelation.ToList())
            {
                if (Db.CustomerAdvisorRelation.Where(x => x.AdvisorId == a.AdvisorId && x.CustomerId == customerId).Count() == 0)
                {
                    CustomerAdvisorRelation customerAdvisorRelation = new CustomerAdvisorRelation();
                    customerAdvisorRelation.CustomerId = customerId;
                    customerAdvisorRelation.AdvisorId = a.AdvisorId;
                    Db.CustomerAdvisorRelation.Add(customerAdvisorRelation);
                }
            }
        }

        private void AddCustomerAdvisorRelation(int customerId, int advisorId)
        {
            if (Db.CustomerAdvisorRelation.Where(x => x.AdvisorId == advisorId && x.CustomerId == customerId).Count() == 0)
            {
                CustomerAdvisorRelation customerAdvisorRelation = new CustomerAdvisorRelation();
                customerAdvisorRelation.CustomerId = customerId;
                customerAdvisorRelation.AdvisorId = advisorId;
                Db.CustomerAdvisorRelation.Add(customerAdvisorRelation);
                Db.SaveChanges();
            }
        }





        //Online Pay System
        public JsonResult Pay(int total)
        {
            int customerid = GetCustomerId();
            Data.Entities.Customer customer = Db.Customer.Single(x => x.CustomerId == customerid);
            string phrase = customer.NameSurname + " -";
            string[] splitnamesurname = phrase.Split(' ');
            Guid ConservationId = Guid.NewGuid();
            Guid BasketId = Guid.NewGuid();

            List<Basket> baskets = Db.Basket
                .Include(x => x.Product)
                .Include(x => x.Customer)
                .Where(x => x.CustomerId == customerid).ToList();

            int Price = 0;
            foreach (var basket in baskets)
            {
                switch (basket.Product.Type)
                {
                    case 1:
                        Price += Db.Lesson.Single(x => x.LessonId == basket.Product.ProductId).Price;
                        break;
                    case 2:
                        Price += Db.Package.Single(x => x.PackageId == basket.Product.ProductId).Price;
                        break;
                    case 3:
                        Price += Db.Advisor.Single(x => x.AdvisorId == basket.Product.ProductId).Price;
                        break;
                }
            }

            Options options = new Options();
            options.ApiKey = "***********************";
            options.SecretKey = "***********************";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";


            //Kart Bilgileri
            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = ConservationId.ToString();

            request.Price = total.ToString();
            request.PaidPrice = total.ToString();
            request.Currency = Currency.TRY.ToString();
            request.BasketId = "B67832" + BasketId;
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.CallbackUrl = "https://medicalestheticacedemy.com/Basket/Checked/" + customerid;
            //request.CallbackUrl = "https://localhost:7257/Basket/Checked/" + customerid;
            List<int> enabledInstallments = new List<int>();
            enabledInstallments.Add(2);
            enabledInstallments.Add(3);
            enabledInstallments.Add(6);
            enabledInstallments.Add(9);
            request.EnabledInstallments = enabledInstallments;

            //Alıcı Bilgileri
            Buyer buyer = new Buyer();
            buyer.Id = customer.CustomerId.ToString();
            buyer.Name = splitnamesurname[0];
            buyer.Surname = splitnamesurname[1];
            buyer.GsmNumber = customer.PhoneNumber;
            buyer.Email = customer.Email;
            buyer.IdentityNumber = "12345678911";
            buyer.LastLoginDate = "2023-09-04 11:40:00";
            buyer.RegistrationDate = "2022-09-04 11:40:00";
            buyer.RegistrationAddress = "İzmir";
            buyer.Ip = "91.93.129.194";
            buyer.City = "İzmir";
            buyer.Country = "Turkey";
            buyer.ZipCode = "35130";
            request.Buyer = buyer;
            Address shippingAddress = new Address();
            shippingAddress.ContactName = customer.NameSurname;
            shippingAddress.City = "Antalya";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Mahalle --- İzmir";
            shippingAddress.ZipCode = "35130";
            request.ShippingAddress = shippingAddress;
            Address billingAddress = new Address();
            billingAddress.ContactName = customer.NameSurname;
            billingAddress.City = "Turkey";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Mahalle --- İzmir";
            billingAddress.ZipCode = "35130";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();

            foreach (var item in baskets)
            {
                if (item.Product.Type == 1)
                {
                    Lesson lesson = Db.Lesson.Include(x => x.Course).Include(x => x.Course.Category).Single(x => x.LessonId == item.Product.ProductId);

                    double lessonprice = lesson.Price;
                    if (total < Price)
                    {
                        lessonprice = total / baskets.Count();
                    }

                    BasketItem basketItem = new BasketItem();
                    basketItem.Id = item.BasketId.ToString();
                    basketItem.Name = lesson.Name;
                    basketItem.Category1 = lesson.Course.Category.Name;
                    basketItem.Category2 = lesson.Course.Category.Name;
                    basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                    basketItem.Price = lessonprice.ToString();
                    basketItems.Add(basketItem);
                }
                if (item.Product.Type == 2)
                {
                    Package package = Db.Package.Single(x => x.PackageId == item.Product.ProductId);

                    double packageprice = package.Price;
                    if (total < Price)
                    {
                        packageprice = total / baskets.Count();
                    }

                    BasketItem basketItem = new BasketItem();
                    basketItem.Id = item.BasketId.ToString();
                    basketItem.Name = package.Name;
                    basketItem.Category1 = "Paketler";
                    basketItem.Category2 = "Kurs PratikDers Danışmanlık FullPaket";
                    basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                    basketItem.Price = packageprice.ToString();
                    basketItems.Add(basketItem);
                }
                if (item.Product.Type == 3)
                {
                    Advisor advisor = Db.Advisor.Single(x => x.AdvisorId == item.Product.ProductId);

                    double advisorprice = advisor.Price;
                    if (total < Price)
                    {
                        advisorprice = total / baskets.Count();
                    }

                    BasketItem basketItem = new BasketItem();
                    basketItem.Id = item.BasketId.ToString();
                    basketItem.Name = "Şeffaf Plak Ve Vaka Danışmanlığı";
                    basketItem.Category1 = "Danışmanlık Ve Hizmetler";
                    basketItem.Category2 = "Canlı Danışmanlık Hizmetleri";
                    basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                    basketItem.Price = advisorprice.ToString();
                    basketItems.Add(basketItem);
                }
            }

            var remainder = total % basketItems.Count;
            var basketItemPrice = remainder == 0 ? total / basketItems.Count() : (total - remainder) / basketItems.Count();
            var firstBasketItemPrice = (basketItemPrice + remainder).ToString().Replace(",", ".");
            basketItems.FirstOrDefault().Price = firstBasketItemPrice;
            basketItems.Skip(1).ToList().ForEach(i => i.Price = basketItemPrice.ToString().Replace(",", "."));


            request.BasketItems = basketItems;
            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);
            ViewBag.CheckoutFormInitialize1 = checkoutFormInitialize;
            return Json(checkoutFormInitialize);
        }

        public ActionResult ResultPay(RetrieveCheckoutFormRequest model)
        {
            string data = "";
            Options options = new Options();
            options.ApiKey = "sandbox-5kRqha41xZsaFTSdhzMyFioKdXIgrPUu";
            options.SecretKey = "sandbox-waJoyD3RFYk4Os3TfEdBbAOQSv4lhi4i";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            data = model.Token;
            RetrieveCheckoutFormRequest request = new RetrieveCheckoutFormRequest();
            request.Token = data;
            CheckoutForm checkoutForm = CheckoutForm.Retrieve(request, options);

            if (checkoutForm.PaymentStatus == "SUCCESS")
                return RedirectToAction("Confirmation");
            

            return View();
        }
    }
}
