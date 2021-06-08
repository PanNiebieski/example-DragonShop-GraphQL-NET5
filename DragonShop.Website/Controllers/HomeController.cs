using DragonShop.Website.Clients;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DragonShop.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly DragonHttpClient _httpClient;
        private readonly DragonGraphClientFromNuget _dragonGraphClientFromNuget;

        public HomeController(DragonHttpClient httpClient,
            DragonGraphClientFromNuget dragonGraphClientFromNuget)
        {
            _httpClient = httpClient;
            _dragonGraphClientFromNuget = dragonGraphClientFromNuget;
        }

        public async Task<IActionResult> DragonDetail(int id)
        {
            var d = await _dragonGraphClientFromNuget.GetDragon(id);
            return View(d);
        }

        public async Task<IActionResult> DragonDetailOld(int id)
        {
            var d = await _httpClient.GetDragon(id);
            return View("~/Views/Home/DragonDetail.cshtml", d.Data);
        }

        public async Task<IActionResult> Index()
        {
            var responseModel = await _httpClient.GetDragons();
            responseModel.ThrowErrors();
            return View(responseModel.Data.Dragons);
        }
    }
}
