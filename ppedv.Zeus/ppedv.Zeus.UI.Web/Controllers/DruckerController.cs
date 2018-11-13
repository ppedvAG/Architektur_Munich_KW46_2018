using ppedv.Zeus.Logic;
using ppedv.Zeus.Model;
using System.Web.Mvc;

namespace ppedv.Zeus.UI.Web.Controllers
{
    public class DruckerController : Controller
    {
        Core core = new Core();

        // GET: Drucker
        public ActionResult Index()
        {
            var result = core.Repository.GetAll<Drucker>();
            return View(result);
        }

        // GET: Drucker/Details/5
        public ActionResult Details(int id)
        {
            return View(core.Repository.GetById<Drucker>(id));
        }

        // GET: Drucker/Create
        public ActionResult Create()
        {
            return View(new Drucker() { Hersteller = "NEU", MaxX = 20 });
        }

        // POST: Drucker/Create
        [HttpPost]
        public ActionResult Create(Drucker drucker)
        {
            try
            {

                core.Repository.Add(drucker);
                core.Repository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Drucker/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.Repository.GetById<Drucker>(id));

        }

        // POST: Drucker/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Drucker drucker)
        {
            try
            {
                core.Repository.Update(drucker);
                core.Repository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Drucker/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.Repository.GetById<Drucker>(id));

        }

        // POST: Drucker/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Drucker drucker)
        {
            try
            {
                var loaded = core.Repository.GetById<Drucker>(id);
                if (loaded != null)
                {
                    core.Repository.Delete(loaded);
                    core.Repository.Save();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
