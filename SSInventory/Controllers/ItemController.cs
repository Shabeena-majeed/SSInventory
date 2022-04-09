using Microsoft.AspNetCore.Mvc;
using SSInventory.Models;
using SSInventory.ViewModels;

namespace SSInventory.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            ViewItem svm = new ViewItem();
            List<Item> Items = svm.GetAllItemData();
            return View(Items);
        }
        public IActionResult ItemForm(int intItemid = 0)
        {
            Item Items = new Item();
            if (intItemid == 0)
            {
                Items.intSeqId = 0;

            }
            else
            {
                ViewItem Items1 = new ViewItem();
                Items = Items1.getItemByid(intItemid);
            }

            return View(Items);

        }
        [HttpPost]
        public IActionResult ItemForm(Item Items)
        {

            if (ModelState.IsValid)
            {
                ViewItem smv = new ViewItem();
                if (Items.intSeqId == 0)
                {
                    smv.AddItem(Items);
                }
                else
                {
                    smv.updateItem(Items);
                }

                return RedirectToAction("Index", "Item");
            }
            return View();

        }
        public IActionResult DeleteInfo(int intItemid = 0)
        {
            ViewItem svm = new ViewItem();
            svm.DeleteItem(intItemid);
            return RedirectToAction("Index", "Item");
        }

    }
}
