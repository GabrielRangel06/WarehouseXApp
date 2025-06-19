-- Optimized SQL Query for recent orders
SELECT TOP 100 o.OrderId, c.Name AS CustomerName, o.OrderDate, 
       SUM(oi.Quantity * p.Price) AS TotalAmount
FROM Orders o
JOIN Customers c ON o.CustomerId = c.Id
JOIN OrderItems oi ON o.Id = oi.OrderId
JOIN Products p ON oi.ProductId = p.Id
WHERE o.OrderDate >= '2023-01-01'
GROUP BY o.OrderId, c.Name, o.OrderDate
ORDER BY o.OrderDate DESC;
