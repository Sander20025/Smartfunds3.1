
using Microsoft.AspNetCore.Mvc;
using SmartFunds.Model;
using SmartFunds.Services;

namespace SmartFunds.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionService _transactionService;

        public TransactionsController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        // /api/transactions/1
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var transaction = _transactionService.Get(id);
            return Ok(transaction);
        }

        // /api/transactions
        [HttpGet("{organizationId:int?}")]
        public IActionResult Find(int? organizationId)
        {
            var transactions = _transactionService.Find(organizationId);
            return Ok(transactions);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Transaction transaction)
        {
            var createdTransaction = _transactionService.Create(transaction);
            return Ok(createdTransaction);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _transactionService.Delete(id);
            return Ok();
        }
    }
}
