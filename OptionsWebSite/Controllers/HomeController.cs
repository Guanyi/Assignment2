using DiplomaDataModel.Models;
using System;
using System.Linq;
using System.Web.Mvc;


namespace OptionsWebSite.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Student")]
        public ActionResult SelectOption()
        {
            //from the option table, only select the active options, pass these records with OptionId to be drop down menu value
            //Title will be the drop down menu text/
            ViewBag.OptionList = new SelectList(db.Options.Where(o => o.IsActive == true).OrderBy(o => o.Title), "OptionId", "Title");

            //if the login user is not admin, then get the student's student number, put it in the Student Id text box.
            if (!User.IsInRole("Admin"))
            {
                ViewBag.CurrentStudentId = User.Identity.Name;
            }
            return View();
        }

        [Authorize(Roles = "Student")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectOption(Choice choice)
        {
            //get the only default YearTerm row by BCIT option policy
            choice.YearTermId = db.YearTerms.SingleOrDefault(y => y.IsDefault == true).YearTermId;

            //check the input model is valid and duplicate rows with the same StudentId in the StudentOptionChoices is not allowed in the same YearTerm
            if (ModelState.IsValid && !db.Choices.Any(c => c.StudentId == choice.StudentId && c.YearTermId == choice.YearTermId))
            {
                choice.SelectionDate = DateTime.Now;
                db.Choices.Add(choice);
                db.SaveChanges();
                TempData["success"] = true;
                return RedirectToAction("Index");
            }
            ViewBag.OptionList = new SelectList(db.Options.Where(o => o.IsActive == true).OrderBy(o => o.Title), "OptionId", "Title");
            ModelState.AddModelError("", "You may only make option selections once.");
            if (!User.IsInRole("Admin"))
            {
                ViewBag.CurrentStudentId = User.Identity.Name;
            }
            return View();
        }
    }
}