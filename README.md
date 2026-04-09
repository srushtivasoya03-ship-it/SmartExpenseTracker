# 💰 Smart Expense Tracker (ASP.NET + AWS)

A backend-based expense tracking system built using ASP.NET Core with integration of AWS services like S3 and DynamoDB.

---

## 🚀 Features

- 📌 Add expenses with title, amount, and category
- 📸 Upload receipt images to AWS S3
- 🔗 Store image URL along with expense data
- 🗄️ Store expense records in AWS DynamoDB
- ⚡ REST API using ASP.NET Core

---

## 🛠️ Tech Stack

- Backend: ASP.NET Core Web API
- Cloud Storage: AWS S3
- Database: AWS DynamoDB
- Language: C#
- Tools: Swagger UI, Visual Studio

---

## 📂 Project Structure
SmartExpenseTracker/
|
│├── Models/
├ ├─ Controllers/
│ └── ExpenseController.cs
│ ├─ Expense.cs
|
├── Services/
│ ├── S3Service.cs
│ └── DynamoDbService.cs
│
├── Program.cs
├── appsettings.json
└── README.md


---

## ⚙️ How It Works

1. User uploads expense details + receipt image
2. Image is uploaded to AWS S3 bucket
3. S3 returns image URL
4. Expense data + image URL is stored in DynamoDB

---

## 🔐 Security Note

AWS credentials are NOT included in this repository.  
Use environment variables or secure configuration for access keys.

---

## ▶️ How to Run

1. Clone the repository:
   
2. Open project in Visual Studio

3. Configure AWS credentials (locally)

4. Run the project

5. Test APIs using Swagger

---

## 📌 Future Improvements

- Add frontend (React / Angular)
- User authentication (JWT)
- Expense analytics dashboard
- Monthly reports

---

## 🙋‍♀️ Author

Srushti Vasoya  
MCA Student | Aspiring Cloud Developer

---

## ⭐ If you like this project

Give it a star on GitHub ⭐
