using Microsoft.AspNetCore.Mvc;
using PremiumCalculator.Repositories;

namespace PremiumCalculator.Controllers
{
    public class PremiumController : Controller
    {
        private readonly IOccupationRepository _repo;

        public PremiumController(IOccupationRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            ViewBag.Occupations = _repo.GetOccupations().Keys;
            return View();
        }
    }
}
