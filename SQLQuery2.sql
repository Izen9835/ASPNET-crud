create procedure mockstoreUpdate @Id int, @Name nchar(10), @Address nchar(100), @Revenue money, @Description nchar(1000)
as
	UPDATE MockStore.dbo.MockStores SET Name = @Name, Address = @Address, Revenue = @Revenue, Description = @Description WHERE Id = @Id
GO;


create procedure mockstoreDelete @Id int
as
	delete MockStore.dbo.MockStores where Id=@Id
GO;


create procedure mockstoreInsert @Name nchar(10), @Address nchar(100), @Revenue money, @Description nchar(1000)
as
	INSERT INTO MockStore.dbo.MockStores VALUES (@Name, @Address, @Revenue, @Description)
GO;


create procedure mockstoreSearchDesc @Desc nvarchar(1000)
as
	select * FROM MockStore.dbo.MockStores WHERE Description LIKE '%' + @Desc + '%'
GO;


create procedure mockstoreSearchStoreByID @Id int
as
	SELECT * FROM MockStore.dbo.MockStores WHERE Id = @Id
GO;



