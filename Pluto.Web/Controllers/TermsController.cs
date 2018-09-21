using Pluto.BLL.Model;
using Pluto.BLL.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pluto.Web.Controllers
{
    public class TermsController : Controller
    {
        private ITermService _termService;

        public TermsController(ITermService termService)
        {
            _termService = termService;
        }
        // GET: Terms
        public ActionResult Index()
        {
            var terms = _termService.GetTermsAsync();

            return View(terms);
        }

        // GET: Terms/Create
        public async Task<ActionResult> Create()
        {
            var terms = await _termService.GetTermsAsync();
            int count = terms.Count;
            ViewBag.TermName = (count+1) + ". term";
            return View();
        }

        // POST: Terms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IsActive")] Term term)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var terms = await _termService.GetTermsAsync();
                    int count = terms.Count;
                    term.Name = (count + 1) + ". term";
                    _termService.AddTermAsync(term);

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to save changes");
            }

            return View(term);
        }

        // GET: Terms/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var term = _termService.GetTermById(id);
            if(term == null)
            {
                return HttpNotFound();
            }

            return View(term);
        }

        // POST: Terms/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var termToUpdate = _termService.GetTermById(id);
            if (TryUpdateModel(termToUpdate, "", new string[] { "IsActive" }))
            {
                try
                {
                    _termService.UpdateTermAsync(termToUpdate);

                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return View(termToUpdate);
        }

        // GET: Terms/Delete/5
        public ActionResult Delete(bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed.";
            }

            return View();
        }

        // POST: Terms/Delete/5
        [HttpPost]
        public ActionResult Delete()
        {
            try
            {
                _termService.DeleteLastTermAsync();
            }
            catch
            {
                return RedirectToAction("Delete", new { saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}
