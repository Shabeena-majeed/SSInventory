using Microsoft.AspNetCore.Mvc;
using SSInventory.Models;
using SSInventory.ViewModels;

namespace SSInventory.Controllers
{
    public class CatagoryController : Controller
    {
        public IActionResult Index()
        {
            ViewCatagory svm = new ViewCatagory();
            List<Catagory> catagories = svm.GetAllCatagoryData();
            return View(catagories);
        }
        public IActionResult CatagoryForm(int intCatagoryid = 0)
        {
            Catagory catagory = new Catagory();
            if (intCatagoryid == 0)
            {
                catagory.intSeqId = 0;

            }
            else
            {
                ViewCatagory catagory1 = new ViewCatagory();
                catagory = catagory1.getCatagoryByid(intCatagoryid);
            }

            return View(catagory);

        }
        [HttpPost]
        public IActionResult CatagoryForm(Catagory catagory)
        {

            if (ModelState.IsValid)
            {
                ViewCatagory smv = new ViewCatagory();
                if (catagory.intSeqId == 0)
                {
                    smv.AddCatagory(catagory);
                }
                else
                {
                    smv.updateCatagory(catagory);
                }

                return RedirectToAction("Index", "Catagory");
            }
            return View();

        }
        public IActionResult DeleteInfo(int intCatagoryid = 0)
        {
            ViewCatagory svm = new ViewCatagory();
            svm.DeletCatagory(intCatagoryid);
            return RedirectToAction("Index", "Catagory");
        }


    }
}
