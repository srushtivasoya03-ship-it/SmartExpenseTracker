using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using SmartExpenseTracker.Models;

namespace SmartExpenseTracker.Services
{
    public class DynamoDbService
    {
        private readonly IAmazonDynamoDB _dynamoDb;

        public DynamoDbService(IAmazonDynamoDB dynamoDb)
        {
            _dynamoDb = dynamoDb;
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            var request = new PutItemRequest
            {
                TableName = "Expenses",
                Item = new Dictionary<string, AttributeValue>
                {
                    { "Id", new AttributeValue { S = expense.Id.ToString() } },
                    { "Title", new AttributeValue { S = expense.Title } },
                    { "Amount", new AttributeValue { N = expense.Amount.ToString() } },
                    { "Category", new AttributeValue { S = expense.Category } },
                    { "CreatedAt", new AttributeValue { S = expense.CreatedAt.ToString() } },
                    { "ReceiptUrl", new AttributeValue { S = expense.ReceiptUrl ?? "" } }
                }
            };

            await _dynamoDb.PutItemAsync(request);
        }

        public async Task<List<Expense>> GetExpensesAsync()
        {
            var response = await _dynamoDb.ScanAsync(new ScanRequest
            {
                TableName = "Expenses"
            });

            var expenses = new List<Expense>();

            foreach (var item in response.Items)
            {
                expenses.Add(new Expense
                {
                    Id = Guid.Parse(item["Id"].S),
                    Title = item["Title"].S,
                    Amount = double.Parse(item["Amount"].N),
                    Category = item["Category"].S,
                    CreatedAt = DateTime.Parse(item["CreatedAt"].S),
                    ReceiptUrl = item.ContainsKey("ReceiptUrl") ? item["ReceiptUrl"].S : null
                });
            }

            return expenses;
        }
    }
}