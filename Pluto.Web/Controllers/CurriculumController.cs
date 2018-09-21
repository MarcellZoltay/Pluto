using Pluto.BLL.Model;
using Pluto.BLL.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Pluto.Web.Controllers
{
    public class CurriculumController : Controller
    {
        private ISubjectService _subjectService;

        public CurriculumController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        // GET: Curriculum
        public ActionResult Index()
        {
            var subjects = _subjectService.GetSubjectsAsync();
            return View(subjects);
        }

        // GET: Curriculum/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Curriculum/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Credit")] Subject subject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _subjectService.AddSubjectAsync(subject);

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes");
            }

            return View(subject);
        }

        // GET: Curriculum/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var subject = _subjectService.GetSubjectById(id);
            if(subject == null)
            {
                return HttpNotFound();
            }

            return View(subject);
        }

        // POST: Curriculum/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var subjectToUpdate = _subjectService.GetSubjectById(id);
            if (TryUpdateModel(subjectToUpdate, "", new string[] { "Name", "Credit"}))
            {
                try
                {
                    _subjectService.UpdateSubjectAsync(subjectToUpdate);

                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return View(subjectToUpdate);
        }

        // GET: Curriculum/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed.";
            }

            var subject = _subjectService.GetSubjectById(id);
            if(subject == null)
            {
                return HttpNotFound();
            }
            
            return View(subject);
        }

        // POST: Curriculum/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                //_subjectService.DeleteSubjectById(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}
