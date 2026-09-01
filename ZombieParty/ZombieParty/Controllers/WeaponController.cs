using Microsoft.AspNetCore.Mvc;
using ZombieParty.Models;
namespace ZombieParty.Controllers
{
    public class WeaponController : Controller
    {
        private BaseDonnees db;

        public WeaponController(BaseDonnees _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            return View(db.Weapons);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Weapon weapon)
        {
            // check validitee
            if (!ModelState.IsValid)
            {
                // ajouter a la DB
                db.Weapons.Add(weapon);

                return RedirectToAction("Index");
            } else
                return View();
        }
    }

}
