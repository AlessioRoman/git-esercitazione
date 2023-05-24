using LaMiaPizzeriaRefactoring.Database;
using LaMiaPizzeriaRefactoring.Models;
using Microsoft.AspNetCore.Mvc;

namespace pizzeria_git.Controllers
{
    public class BeverageController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new())
            {
                List<BeverageModel> bevande = db.Beverages.ToList();
                return View(bevande);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BeverageModel newBev)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newBev);
            }

            using (PizzaContext db = new())
            {
                db.Beverages.Add(newBev);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public IActionResult Details(int id)
        {
            using (PizzaContext db = new())
            {
                BeverageModel? bevDetails = db.Beverages.Where(BeverageModel => BeverageModel.Id == id).FirstOrDefault();

                if (bevDetails != null)
                {
                    return View("Details", bevDetails);
                }
                else
                {
                    return NotFound($"L'articolo con id {id} non è stato trovato!");
                }
            }
        }
    }
}
