declare @OrderId int
declare @CustomerId int

INSERT INTO [Customers](customername, address, city, region, postalcode, country, phone, fax, Email) VALUES(@0,@1,@2,@3,@4,@5, @6,@7,@8 )", cusDetails.customername, cusDetails.Address, cusDetails.City,
                cusDetails.State, cusDetails.Zipcode, cusDetails.Country, cusDetails.phone, string.Empty, cusDetails.Email
select @CustomerId = @@IDENTITY


insert into [Orders] (CustomerId, orderdate,requireddate, DeliverCharge) values(1, CURRENT_TIMESTAMP,'2012/12/09', 200)
select @OrderId = @@IDENTITY

insert into [OrderDetails] (OrderId, productid, unitprice, qty, discount)
values (@OrderId, (select isnull(max(LineItem), 0) + 1 from [OrderDetails] where OrderId = @OrderId), 'Tennis Racket', 12



CREATE PROCEDURE updateOrderDetails(
    @CustomerId INT,
    @OrderId INT,
    @JOBID INT, 
    @COMMENT BIT,
    @DUEDATE NVARCHAR(32) --add a size, should this be DATETIME
)
AS
BEGIN

declare @OrderId int
declare @CustomerId int

INSERT INTO [Customers](
    [nameID],
    [houseID],
    [jobID],
    [Active],
    [comment],
    [dueDate],
    [needsMaintenance],
    [lastupdatedate]
) VALUES (
    @NAMEID,
    @HOUSEID,
    @JOBID,
    1,
    @COMMENT,
    @DUEDATE,
    NULL,
    GETDATE()
)
GO

INSERT INTO [Orders] (
    [nameID],
    [houseID],
    [jobID],
    [Active],
    [comment],
    [dueDate],
    [needsMaintenance],
    [lastupdatedate]
) VALUES (
    @NAMEID,
    @HOUSEID,
    @JOBID,
    1,
    @COMMENT,
    @DUEDATE,
    NULL,
    GETDATE()
)

GO

INSERT INTO [OrderDetails] (
    [nameID],
    [houseID],
    [jobID],
    [Active],
    [comment],
    [dueDate],
    [needsMaintenance],
    [lastupdatedate]
) VALUES (
    @NAMEID,
    @HOUSEID,
    @JOBID,
    1,
    @COMMENT,
    @DUEDATE,
    NULL,
    GETDATE()
)

GO


END


 
