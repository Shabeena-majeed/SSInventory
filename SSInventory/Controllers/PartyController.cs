using Microsoft.AspNetCore.Mvc;
using SSInventory.Models;
using SSInventory.ViewModels;

namespace SSInventory.Controllers
{
    public class PartyController : Controller
    {
        public IActionResult Index()
        {
            ViewParty svm = new ViewParty();
            List<Party> Parties = svm.GetAllPartyData();
            return View(Parties);
        }
        public IActionResult PartyForm(int intPartyid = 0)
        {
            Party Parties = new Party();
            if (intPartyid == 0)
            {
                Parties.intSeqId = 0;

            }
            else
            {
                ViewParty Party1 = new ViewParty();
                Parties = Party1.getPartyByid(intPartyid);
            }

            return View(Parties);

        }
        [HttpPost]
        public IActionResult PartyForm(Party party)
        {

            if (ModelState.IsValid)
            {
                ViewParty smv = new ViewParty();
                if (party.intSeqId == 0)
                {
                    smv.AddParty(party);
                }
                else
                {
                    smv.updateParty(party);
                }

                return RedirectToAction("Index", "Party");
            }
            return View();

        }
        public IActionResult DeleteInfo(int intPartyid = 0)
        {
            ViewParty svm = new ViewParty();
            svm.DeleteParty(intPartyid);
            return RedirectToAction("Index", "Party");
        }

    }
}
