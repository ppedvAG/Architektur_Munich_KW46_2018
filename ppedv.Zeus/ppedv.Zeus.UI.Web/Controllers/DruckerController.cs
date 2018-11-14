using ppedv.Zeus.Logic;
using ppedv.Zeus.Model;
using System.Linq;
using System.Web.Mvc;

namespace ppedv.Zeus.UI.Web.Controllers
{

    public class DruckerController : Controller
    {
        Core core = new Core();

        // GET: Drucker
        public ActionResult Index()
        {
            return View(core.Drucker);
        }

        // GET: Drucker/Details/5
        public ActionResult Details(int id)
        {
            return View(core.Repository.GetById<Drucker>(id));
        }

        public ActionResult StartPrinter(int id)
        {
            var dd = core.Drucker.FirstOrDefault(x => x.Key.Id == id).Value;
            if (dd != null)
                dd.Start("lalalala");

            return RedirectToAction("Index");
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
