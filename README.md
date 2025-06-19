# WarehouseX Order Management System

## 📦 Overview

WarehouseX is an order management system built with ASP.NET Core and Entity Framework Core. The system handles order records, customer data, and product inventories, and exposes RESTful endpoints for querying recent order summaries.

This project includes strategic performance optimization, SQL query refinement, application code enhancements, and thorough debugging using Microsoft Copilot.

---

## ✅ Project Objectives

- Optimize SQL queries for performance and scalability.
- Refactor application code to improve efficiency.
- Debug critical runtime issues and fix compiler warnings.
- Implement asynchronous service logic for better responsiveness.

---

## 🛠️ Tech Stack

- ASP.NET Core 7.0
- Entity Framework Core
- SQL Server
- Swagger for API documentation

---

## 📂 Project Structure

```
WarehouseXApp/
├── Controllers/
│   └── OrdersController.cs
├── Models/
│   ├── AppDbContext.cs
│   ├── Customer.cs
│   ├── Order.cs
│   ├── OrderItem.cs
│   ├── OrderSummary.cs
│   └── Product.cs
├── Services/
│   ├── IOrderService.cs
│   └── OrderService.cs
├── appsettings.json
├── Program.cs
```

---

## ⚙️ Setup Instructions

1. **Clone the project**
2. **Add your SQL Server connection string** in `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=WarehouseX;Trusted_Connection=True;"
}
```
3. **Run the project**:
```bash
dotnet restore
dotnet build
dotnet run
```

4. Access Swagger UI at: `http://localhost:5000/swagger`

---

## 📈 Optimized SQL Query

```sql
SELECT TOP 100 o.Id AS OrderId, c.Name AS CustomerName, o.OrderDate, 
       SUM(oi.Quantity * p.Price) AS TotalAmount
FROM Orders o
JOIN Customers c ON o.CustomerId = c.Id
JOIN OrderItems oi ON o.Id = oi.OrderId
JOIN Products p ON oi.ProductId = p.Id
WHERE o.OrderDate >= '2023-01-01'
GROUP BY o.Id, c.Name, o.OrderDate
ORDER BY o.OrderDate DESC;
```

---



## 📬 API Endpoint

`GET /api/orders/recent`  
Returns the latest 100 orders with customer name and total value.

---

## 📃 License

