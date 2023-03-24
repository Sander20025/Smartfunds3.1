using Microsoft.AspNetCore.Mvc;
using SmartFunds.Model;
using SmartFunds.Ui.Webapp.Sdk;

namespace SmartFunds.Ui.Webapp.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly TransactionSdk _transactionSdk;
        private readonly OrganizationSdk _organizationSdk;

        public TransactionsController(
            TransactionSdk transactionSdk, 
            OrganizationSdk organizationSdk)
        {
            _transactionSdk = transactionSdk;
            _organizationSdk = organizationSdk;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id.HasValue)
            {
                var organization = await _organizationSdk.Get(id.Value);
                if (organization is null)
                {
                    return RedirectToAction("Index", "Organization");
                }

                ViewData["Organization"] = organization;
            }

            var transactions = await _transactionSdk.Find(id);

            return View(transactions);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? organizationId)
        {
            if (organizationId.HasValue)
            {
                var transaction = new Transaction
                {
                    OrganizationId = organizationId.Value,
                    Owner = string.Empty,
                    Remarks = string.Empty
                };
                return View(transaction);
            }

            var organizations = await _organizationSdk.Find();
            ViewBag.Organizations = organizations;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return View(transaction);
            }

            await _transactionSdk.Create(transaction);

            return RedirectToAction("Index", new{Id = transaction.OrganizationId});
        }

        [HttpPost("[controller]/Delete/{id:int?}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _transactionSdk.Get(id);

            if (transaction is null)
            {
                return RedirectToAction("Index", "Organization");
            }

            await _transactionSdk.Delete(id);

            return RedirectToAction("Index", new{Id = transaction.OrganizationId});
        }
    }
}
