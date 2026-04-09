using Microsoft.AspNetCore.Mvc;
using SmartExpenseTracker.Models;
using SmartExpenseTracker.Services;



namespace SmartExpenseTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
         private readonly DynamoDbService _service;
          public ExpenseController(DynamoDbService service)
        {
            _service = service;
        }
        private static List<Expense> expenses = new List<Expense>();

        // GET: api/expense
     [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var expenses = await _service.GetExpensesAsync();
            return Ok(expenses);
        }

        // GET: api/expense/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
                return NotFound();

            return Ok(expense);
        }

        // POST: api/expense
         [HttpPost]
        public async Task<IActionResult> Create([FromBody] Expense expense)
        {
            expense.Id = Guid.NewGuid();
            expense.CreatedAt = DateTime.UtcNow;

            await _service.AddExpenseAsync(expense); // 🔥 THIS IS KEY

            return Ok(expense);
        }

        // DELETE: api/expense/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
                return NotFound();

            expenses.Remove(expense);
            return Ok("Deleted successfully");
        }

        //[HttpPost("upload")]
       // public async Task<IActionResult> UploadReceipt(IFormFile file, [FromServices] S3Service s3Service)
       // {
        //    var url = await s3Service.UploadFileAsync(file);
         //   return Ok(new { FileUrl = url });
       // }

        [HttpPost("with-receipt")]
public async Task<IActionResult> CreateWithReceipt(
    IFormFile file,
    [FromForm] string title,
    [FromForm] double amount,
    [FromForm] string category,
    [FromServices] S3Service s3Service)
{
    var imageUrl = await s3Service.UploadFileAsync(file);

    var expense = new Expense
    {
        Id = Guid.NewGuid(),
        Title = title,
        Amount = amount,
        Category = category,
        CreatedAt = DateTime.UtcNow,
        ReceiptUrl = imageUrl
    };

    await _service.AddExpenseAsync(expense);

    return Ok(expense);
}
    }
}