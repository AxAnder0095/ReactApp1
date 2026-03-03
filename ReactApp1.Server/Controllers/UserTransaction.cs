using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTransactionController : ControllerBase
    {
        private static readonly List<UserTransaction> _transactions = new()
        {
            new UserTransaction { Id = Guid.NewGuid(), EntryType = "Credit", Source = "Salary", Amount = 5000 },
            new UserTransaction { Id = Guid.NewGuid(), EntryType = "Debit", Source = "Groceries", Amount = 150 },
            new UserTransaction { Id = Guid.NewGuid(), EntryType = "Credit", Source = "Freelance", Amount = 800 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<UserTransaction>> GetTransactions()
        {
            return Ok(_transactions);
        }

        [HttpGet("{id:Guid}")]
        public ActionResult<UserTransaction> GetTransactionById(Guid id)
        {
            var transaction = _transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
            //return transaction is null ? NotFound() : Ok(transaction); // This is a more concise way to write the same logic using a ternary operator.
        }

        [HttpGet("credits")]
        public ActionResult<IEnumerable<UserTransaction>> GetCreditTransactions()
        {
            var creditTransactions = _transactions.Where(t => t.EntryType == "Credit").ToList(); // Functions like the filter method in JavaScript
            return Ok(creditTransactions);
        }

        [HttpGet("debits")]
        public ActionResult<IEnumerable<UserTransaction>> GetDebitTransactions()
        {
            var debitTransactions = _transactions.Where(t => t.EntryType == "Debit").ToList(); // Functions like the filter method in JavaScript
            return Ok(debitTransactions);
        }

        [HttpPost]
        public ActionResult AddTransaction(UserTransaction transaction)
        {
            transaction.Id = Guid.NewGuid(); // Assign a new unique ID
            _transactions.Add(transaction);

            // nameof(GetTransactionById) is used to get the name of the method as a string, which helps avoid hardcoding the method name and reduces the risk of typos.
            // The CreatedAtAction method is used to return a 201 Created response, along with the location of the newly created resource (the transaction) and the transaction data itself in the response body.
            // The new { id = transaction._Id } is an anonymous object that contains the route parameters needed to generate the URL for the GetTransactionById action, allowing clients to easily access the newly created transaction.
            // transaction is the object body that will be returned in the response, providing the client with the details of the newly created transaction.
            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.Id }, transaction); 
        }

        [HttpPut("{id:Guid}")]
        public ActionResult UpdateTransaction(Guid id, UserTransaction updatedTransaction)
        {
            var transaction = _transactions.FirstOrDefault(t => t.Id == id); // Find the transaction _Id
            if (transaction == null)
            {
                return NotFound();
            }

            transaction.EntryType = updatedTransaction.EntryType;
            transaction.Source = updatedTransaction.Source;
            transaction.Amount = updatedTransaction.Amount;

            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            var transaction = _transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }
            _transactions.Remove(transaction);
            return NoContent();
        }
    }
}