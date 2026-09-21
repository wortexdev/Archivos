CREATE PROCEDURE usp_FiltrarEmployees
    @Filtro NVARCHAR(50)
AS
BEGIN
    SELECT EmployeeID,
           FirstName,
           LastName,
           Title
    FROM Employees
    WHERE FirstName COLLATE Latin1_General_CS_AS LIKE '%' + @Filtro + '%'
       OR LastName  COLLATE Latin1_General_CS_AS LIKE '%' + @Filtro + '%'
END



CREATE PROCEDURE usp_Customers_ListarPaginado
    @Page INT,
    @PageSize INT
AS
BEGIN
    SELECT CustomerID, CompanyName, ContactName, City, Country
    FROM Customers
    ORDER BY CustomerID
    OFFSET (@Page - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;

    SELECT COUNT(*) AS TotalRegistros FROM Customers;
END



CREATE PROCEDURE usp_Customers_Insertar
    @CustomerID NVARCHAR(5),
    @CompanyName NVARCHAR(40),
    @ContactName NVARCHAR(30),
    @City NVARCHAR(15),
    @Country NVARCHAR(15)
AS
BEGIN
    INSERT INTO Customers(CustomerID, CompanyName, ContactName, City, Country)
    VALUES(@CustomerID, @CompanyName, @ContactName, @City, @Country);
END


CREATE PROCEDURE usp_Customers_Actualizar
    @CustomerID NVARCHAR(5),
    @CompanyName NVARCHAR(40),
    @ContactName NVARCHAR(30),
    @City NVARCHAR(15),
    @Country NVARCHAR(15)
AS
BEGIN
    UPDATE Customers
    SET CompanyName = @CompanyName,
        ContactName = @ContactName,
        City = @City,
        Country = @Country
    WHERE CustomerID = @CustomerID;
END

CREATE PROCEDURE usp_Customers_Eliminar
    @CustomerID NVARCHAR(5)
AS
BEGIN
    DELETE FROM Customers WHERE CustomerID = @CustomerID;
END
