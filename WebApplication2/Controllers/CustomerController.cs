using Microsoft.AspNetCore.Mvc;
using VeronaAkademi.Data.Context;
using VeronaAkademi.Data.Entities;

namespace VeronaAkademi.Ui.Controllers
{
    public class CustomerController : Controller
    {
        private Db _db;
        public Db Db
        {
            get
            {
                if (_db == null) return new Db();

                return _db;
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult SaveAnamnez(Anamnez form)
        {
            var _form = Db.Anamnez.Find(form.AnamnezId);
            _form.AdvisorId = form.AdvisorId;
            _form.CustomerId = form.CustomerId;
            _form.Age = form.Age;
            _form.Allergies = form.Allergies;
            _form.CreateDate = form.CreateDate;
            _form.UpdateDate = DateTime.Now;
            Db.Anamnez.Update(_form);
            Db.SaveChanges();
            return Json(_form);
        }
        public JsonResult SaveClinicalExam(ClinicalExam form)
        {
            var _form = Db.ClinicalExam.Find(form.ClinicalExamId);
            _form.AdvisorId = form.AdvisorId;
            _form.CustomerId = form.CustomerId;
            _form.Temperature = form.Temperature;
            _form.ExamDate = form.ExamDate;
            _form.CreateDate = form.CreateDate;
            _form.UpdateDate = DateTime.Now;
            Db.ClinicalExam.Update(_form);
            Db.SaveChanges();
            return Json(_form);
        }
    }
}
