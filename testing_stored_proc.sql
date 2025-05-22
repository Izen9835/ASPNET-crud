--create procedure mockstoreUpdate @Id int, @Name nchar(10), @Address nchar(100), @Revenue money, @Description nchar(1000)
--as
--	UPDATE MockStore.dbo.MockStores SET Name = @Name, Address = @Address, Revenue = @Revenue, Description = @Description WHERE Id = @Id

--exec mockStoreUpdate @Id=8, @Name='asdf', @Address='af', @Revenue=10.0, @Description='adfadfa';

--create procedure mockstoreDelete @Id int
--as
--	delete MockStore.dbo.MockStores where Id=@Id

--exec mockstoreDelete @Id=8

--create procedure mockstoreInsert @Name nchar(10), @Address nchar(100), @Revenue money, @Description nchar(1000)
--as
--	INSERT INTO MockStore.dbo.MockStores VALUES (@Name, @Address, @Revenue, @Description)

--create procedure mockstoreSearchDesc @Desc nvarchar(1000)
--as
--	select * FROM MockStore.dbo.MockStores WHERE Description LIKE '%' + @Desc + '%'

exec mockstoreSearchDesc @Desc='kale'

--drop procedure mockstoreSearchDesc


--select * from MockStore.dbo.MockStores

