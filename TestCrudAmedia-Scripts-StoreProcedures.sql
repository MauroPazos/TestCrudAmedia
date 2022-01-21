--1)-------------------------------------------------------
USE TestCrud

CREATE TABLE [dbo].[tAlquileres](
	[cod_alquiler] [int] IDENTITY PRIMARY KEY NOT NULL,
	[cod_pelicula] [int] NOT NULL,
	[cod_usuario] [int] NOT NULL,
	[fechahora] [datetime] NOT NULL,
	[monto] [float] NOT NULL,
	[senia] [float] NOT NULL,
	[fechadevolucionpactada] [datetime] NOT NULL,
	[fechadevolucion] [datetime] NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tVentas](
	[cod_venta] [int] IDENTITY PRIMARY KEY NOT NULL,
	[cod_usuario] [int] NOT NULL,
	[cod_pelicula] [int] NOT NULL,
	[fechahora] [datetime] NOT NULL,
	[monto] [float] NOT NULL
) ON [PRIMARY]
GO

--1)-------------------------------------------------------


--1)-------------------------------------------------------
  GO
  CREATE PROCEDURE Dbo.InsertUniqueUser
		@user varchar(50),
		@pass varchar(50),
		@name varchar(200),
		@lastname varchar(200),
		@ndoc varchar(50),
		@cod_rol int
		
  AS 
	BEGIN
	
		IF ((SELECT COUNT(*) FROM tUsers WHERE nro_doc = @ndoc OR txt_user = @user) > 0)
			PRINT('Ya existe un usuario con ese documento o con ese nombre de usuario');
		ELSE 
			INSERT INTO tUsers (txt_user, txt_password, txt_nombre, txt_apellido, nro_doc, cod_rol, sn_activo)
			VALUES(@user, @pass, @name, @lastname, @ndoc, @cod_rol, -1);
		
	END

		
		EXECUTE dbo.InsertUniqueUser
		@user = Mauro1112121,
		@pass = 123,
		@name = Mauro,
		@lastname= Pazos,
		@ndoc= 9977891,
		@cod_rol = 1;
  GO
--1)-------------------------------------------------------



--2)-------------------------------------------------------

--2)-------------------------------------------------------


--3)-------------------------------------------------------
GO
	CREATE PROCEDURE dbo.CreateGender
	@gender varchar(500)
	AS 
	BEGIN
		INSERT INTO tGenero(txt_desc) VALUES(@gender)
	END

	EXECUTE dbo.CreateGender
	@gender = 'Aventura'
--3)-------------------------------------------------------

--4)-------------------------------------------------------
--4)-------------------------------------------------------


--5)-------------------------------------------------------
--Son 8 y 9
--5)-------------------------------------------------------


--6 y 7)-------------------------------------------------------
GO
CREATE PROCEDURE GetMoviesAvailable
AS 
BEGIN
  SELECT cod_pelicula AS ID, txt_desc AS PELICULA, cant_disponibles_venta AS CantDispoVenta, precio_venta AS PRECIO FROM tPelicula 
  WHERE cant_disponibles_venta > 0 
  ORDER BY DISPONIBLES DESC

  SELECT  cod_pelicula AS ID, txt_desc AS PELICULA, cant_disponibles_alquiler AS CantDispoAlquiler, precio_alquiler AS PRECIO 
  FROM tPelicula WHERE cant_disponibles_alquiler> 0
  ORDER BY DISPONIBLES DESC
 END

  EXECUTE GetMoviesAvailable
  GO 
--6 y 7)-------------------------------------------------------


--8)-------------------------------------------------------
GO
  CREATE PROCEDURE Dbo.RentMovie
		@movie int,
		@user int,
		@date datetime,
		@amount float,
		@advancemount float,
		@returndate datetime
  AS 
	BEGIN
		IF ((SELECT cant_disponibles_alquiler FROM tPelicula WHERE cod_pelicula = @movie) > 0) 
			BEGIN
				INSERT INTO tAlquileres(cod_pelicula, cod_usuario, fechahora, monto, senia, fechadevolucionpactada)
				VALUES(@movie, @user, @date, @amount, @advancemount, @returndate);
				UPDATE tPelicula SET cant_disponibles_alquiler = cant_disponibles_alquiler-1 where cod_pelicula = @movie;
			END
		ELSE
			PRINT('No quedan ejemplares disponibles para esa pelicula');
			
	END

	EXECUTE dbo.RentMovie
		@movie = 1,
		@user = 3,
		@date = '2022/1/21',
		@amount = 11,
		@advancemount = 5,
		@returndate = '2022/1/31';
	
--8)-------------------------------------------------------


--9)-------------------------------------------------------
USE TestCrud
  GO
  --drop procedure Dbo.BuyMovie

  CREATE PROCEDURE Dbo.BuyMovie
		@user int,
		@movie int,
		@date datetime,
		@amount float
  AS 
	BEGIN
		IF ((SELECT cant_disponibles_venta FROM tPelicula WHERE cod_pelicula = @movie) > 0) 
			BEGIN
				INSERT INTO tVentas( cod_usuario, cod_pelicula, fechahora, monto)
				VALUES(@movie, @user, @date, @amount);
				UPDATE tPelicula SET cant_disponibles_venta = cant_disponibles_venta - 1 where cod_pelicula = @movie;
			END
		ELSE
			PRINT('No quedan ejemplares disponibles para esa pelicula');
			
	END

	EXECUTE dbo.BuyMovie
		@user = 3,
		@movie = 4,
		@date = '2022/1/21',
		@amount = 11;
--9)-------------------------------------------------------
  

--10)-------------------------------------------------------	
	GO
	CREATE PROCEDURE Dbo.GiveBackMovie
	@cod_movie int,
	@cod_user int
	AS 
	BEGIN 
		UPDATE tAlquileres SET fechadevolucion = GETDATE() where cod_pelicula = @cod_movie and cod_usuario = @cod_user;
		UPDATE tPelicula SET cant_disponibles_alquiler = cant_disponibles_alquiler +1 where cod_pelicula = @cod_movie;
	END


	EXECUTE dbo.GiveBackMovie
	@cod_movie = 2,
	@cod_user = 3
	
--10)-------------------------------------------------------		
	
--11)-------------------------------------------------------
	GO
	CREATE PROCEDURE dbo.GetUnreturnedMovies
	AS
	BEGIN
		select p.txt_desc as Pelicula, u.txt_user as UsuarioDeudor from tAlquileres a
		inner join tPelicula p
		on a.cod_pelicula = p.cod_pelicula
		inner join tUsers u
		on a.cod_usuario = u.cod_usuario
		where fechadevolucion is null
	END

	EXECUTE dbo.GetUnreturnedMovies		
--11)-------------------------------------------------------		
	
	
--12)-------------------------------------------------------
GO
	CREATE PROCEDURE dbo.MoviesRentByUser
	@cod_user int
	AS
	BEGIN
		SELECT p.txt_desc AS Pelicula, SUM(Monto) AS PagoTotal, fechahora AS Fecha FROM tAlquileres a
		JOIN tPelicula p 
		ON a.cod_pelicula = p.cod_pelicula
		WHERE cod_usuario = @cod_user
		GROUP BY p.txt_desc, monto, fechahora
	END

	EXECUTE dbo.MoviesRentByUser 
	@cod_user = 4		
--12)-------------------------------------------------------		
	
	
--13)-------------------------------------------------------	
	GO
	CREATE PROCEDURE Dbo.MoviesWithRents
	AS 
	BEGIN 
		select txt_desc, SUM(a.monto) as DineroRecaudado, COUNT(*) as CantAlquileres
		from tPelicula p
		join tAlquileres a
		on p.cod_pelicula = a.cod_pelicula
		group by p.txt_desc, a.monto
		order by CantAlquileres desc

	END

	EXECUTE dbo.MoviesWithRents
--13)-------------------------------------------------------		
		


