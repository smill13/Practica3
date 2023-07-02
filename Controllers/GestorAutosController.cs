using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practica3.Controllers
{
    public class GestorAutosController : Controller
    {
        // GET: GestorAutosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GestorAutosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GestorAutosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GestorAutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GestorAutosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GestorAutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GestorAutosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GestorAutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
