
CREATE PROCEDURE sp_employee
AS
SELECT TitleOfCourtesy, FirstName, LastName, City FROM Employees

EXECUTE sp_employee



ALTER PROC sp_category @ID INT
AS
SELECT C.CategoryName , P.ProductName FROM Categories C
JOIN Products P ON P.CategoryID = C.CategoryID
WHERE C.CategoryID=@ID
ORDER BY 1
EXEC sp_category 3

CREATE PROC sp_EMPLOYELIST @NAME NVARCHAR(10), @SURNAME NVARCHAR(20)
AS
SELECT * FROM Employees E
WHERE E.FirstName = @NAME AND E.LastName = @SURNAME


sp_EMPLOYELIST 'NANCY' , 'DAVOLIO'

select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Customers'

alter PROC sp_customers 
@CustomerID nvarchar(5),
@CompanyName nvarchar(40),
@ContactName nvarchar(30) = null,
@ContactTitle nvarchar(30) = null,
@Address  nvarchar(60) = null,
@City nvarchar(15) = null,
@Region  nvarchar(15) = null,
@PostalCode  nvarchar(10) = null,
@Country  nvarchar(15) = null,
@Phone nvarchar(24) = null,
@Fax  nvarchar(24) = null
AS
insert into Customers (CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax)
VALUES (@CustomerID,@CompanyName,@ContactName,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country,@Phone,@Fax)

-- ürün satışında çalışacak olan trigger
CREATE TRIGGER SaleProduct
ON [Order Details]
-- AFTER INSERT  -- Order Details Tablosuna kayıt eklendiğinde çalışacak olan trigger
INSTEAD OF INSERT
AS
DECLARE @productId INT, @quantity SMALLINT, @orderId INT, @discount REAL, @unitPrice MONEY
SELECT @productId=ProductID, @quantity=Quantity,@orderId = OrderID, @unitPrice = UnitPrice , @discount = Discount FROM inserted
IF EXISTS (SELECT *
           FROM Products
           Where ProductID=@productId and UnitsInStock>=@quantity)
BEGIN
    INSERT INTO [Order Details]
    VALUES(@orderId, @productId, @unitPrice, @discount)
    UPDATE Products SET UnitsInStock=UnitsInStock-@quantity WHERE ProductID = @productId
END
ELSE BEGIN
    PRINT('Sakiz var yermisin')
END



SELECT * FROM [Order Details] Where OrderID = 10248
SELECT * FROM Products WHere ProductID = 77  -- stock 32
-- -> ürün satışı gerçekleşti kontrol 0 adet ürün satılamaz, stoktan büyük olamaz


alter proc sp_cat 
@catname nvarchar(15),
@description ntext
as begin
if exists(select * from Categories where CategoryName = @catname)
begin 
 UPDATE Categories
        SET [Description] = @description
        WHERE CategoryName = @catname;
print('category var')
end
else 
begin
insert into Categories(CategoryName,[Description]) values (@catname,@description)
print 'Description guncellendi';
end
end


alter proc sp_proc 
@pname nvarchar(40),
@price money, 
@pstok smallint,
@categoryName nvarchar(15)
as
if exists (select * from Categories where CategoryName = @categoryName)
begin
insert into Products (ProductName,UnitPrice,UnitsInStock,CategoryID) values (@pname,@price,@pstok,(select CategoryID from Categories where CategoryName = @categoryName))
end
else
begin
insert into Categories(CategoryName) values(@categoryName)
insert into Products (ProductName,UnitPrice,UnitsInStock,CategoryID) values (@pname,@price,@pstok,SCOPE_IDENTITY())
end

sp_proc 'meee', 23123,12,'asdsdf'

select * from Products
select*from Categories
