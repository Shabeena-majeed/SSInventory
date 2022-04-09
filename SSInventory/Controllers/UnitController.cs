using Microsoft.AspNetCore.Mvc;
using SSInventory.Models;
using SSInventory.ViewModels;

namespace SSInventory.Controllers
{
    public class UnitController : Controller
    {
        public IActionResult Index()
        {
            ViewUnit svm = new ViewUnit();
            List<Unit> catagories = svm.GetAllUnitData();
            return View(catagories);
        }
        public IActionResult UnitForm(int intUnitid = 0)
        {
            Unit Units = new Unit();
            if (intUnitid == 0)
            {
                Units.intSeqId = 0;

            }
            else
            {
                ViewUnit Unit1 = new ViewUnit();
                Units = Unit1.getUnitByid(intUnitid);
            }

            return View(Units);

        }
        [HttpPost]
        public IActionResult UnitForm(Unit unit)
        {

            if (ModelState.IsValid)
            {
                ViewUnit smv = new ViewUnit();
                if (unit.intSeqId == 0)
                {
                    smv.AddUnit(unit);
                }
                else
                {
                    smv.updateUnit(unit);
                }

                return RedirectToAction("Index", "Unit");
            }
            return View();

        }
        public IActionResult DeleteInfo(int intUnitid = 0)
        {
            ViewUnit svm = new ViewUnit();
            svm.DeleteUnit(intUnitid);
            return RedirectToAction("Index", "Catagory");
        }

    }
}
