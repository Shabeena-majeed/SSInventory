using Microsoft.AspNetCore.Mvc;
using SSInventory.Models;
using SSInventory.ViewModels;

namespace SSInventory.Controllers
{
    public class WearhouseController : Controller
    {
        public IActionResult Index()
        {
            ViewWearhouse svm = new ViewWearhouse();
            List<Wearhouse> wearhouse = svm.GetAllWearhouseData();
            return View(wearhouse);
        }
        public IActionResult WearhouseForm(int intWearhouseid = 0)
        {
            Wearhouse wearhouse = new Wearhouse();
            if (intWearhouseid == 0)
            {
                wearhouse.intSeqId = 0;

            }
            else
            {
                ViewWearhouse wearhouse1 = new ViewWearhouse();
                wearhouse = wearhouse1.getWearhouseByid(intWearhouseid);
            }

            return View(wearhouse);

        }
        [HttpPost]
        public IActionResult WearhouseForm(Wearhouse wearhouse)
        {

            if (ModelState.IsValid)
            {
                ViewWearhouse smv = new ViewWearhouse();
                if (wearhouse.intSeqId == 0)
                {
                    smv.AddWearhouse(wearhouse);
                }
                else
                {
                    smv.AddWearhouse(wearhouse);
                }

                return RedirectToAction("Index", "Wearhouse");
            }
            return View();

        }
        public IActionResult DeleteInfo(int intWearhouseid = 0)
        {
            ViewWearhouse svm = new ViewWearhouse();
            svm.DeleteWearhouse(intWearhouseid);
            return RedirectToAction("Index", "Wearhouse");
        }

    }
}
