GO
CREATE TABLE USUARIOS(
nombreUsr VARCHAR(20),
contrasena VARCHAR(40),
tipo VARCHAR(20),
PRIMARY KEY (nombreUsr),
);

GO

CREATE TABLE AREA (
idArea varchar(10) primary key,
nombre varchar(50) not null,
fkArea varchar(10),
CONSTRAINT FK_AREA FOREIGN KEY (fkArea)
REFERENCES AREA(idArea)
);

GO

CREATE TABLE AUTORES (
    [codigo] INT NOT NULL,
    [nombre] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([codigo] ASC)
);

GO


CREATE TABLE MATERIAL (
    [idMaterial]        VARCHAR (10) NOT NULL,
    [titulo]            VARCHAR (30) NOT NULL,
    [descripcion]       VARCHAR (50) NULL,
    [tipo]              VARCHAR (30) NOT NULL,
    [fechaIngreso]      DATETIME     NULL,
    [fechaModificacion] DATETIME     NULL,
    [imagen] VARCHAR(MAX) NULL, 
    [ruta] VARCHAR(MAX) NOT NULL, 
    propietario varchar(20) not null,
    PRIMARY KEY CLUSTERED ([idMaterial] ASC),
    CONSTRAINT FK_MaterialUsuario FOREIGN KEY (propietario) REFERENCES USUARIOS(nombreUsr)
);

GO

CREATE TABLE MATERIAL_AUTOR(
	idMaterial VARCHAR(10),
	codigo INT,
	PRIMARY KEY (idMaterial, idArea),
	CONSTRAINT FK_AutorMaterial FOREIGN KEY(idMaterial) REFERENCES MATERIAL(idMaterial),
	CONSTRAINT FK_MaterialAutor FOREIGN KEY(codigo) REFERENCES AUTORES(codigo)
);

GO

CREATE TABLE MATERIAL_AREA(
	idMaterial VARCHAR(10),
	idArea VARCHAR(10),
	PRIMARY KEY (idMaterial, idArea),
	CONSTRAINT FK_MaterialArea FOREIGN KEY (idMaterial) REFERENCES MATERIAL(idMaterial),
	CONSTRAINT FK_AreaMaterial FOREIGN KEY (idArea) REFERENCES MATERIAL(idArea)
);

GO

CREATE TABLE MSJERROR(
mensaje VERCHAR(MAX) NOT NULL
);

GO


--CREATE PROCEDURE procInsertArea
@idArea varchar(10),
@nombre varchar(50),
@fkArea varchar(10)
AS
BEGIN TRANSACTION 
     BEGIN TRY 
		IF NOT EXISTS (SELECT idArea FROM AREA WHERE idArea = @idArea)
		INSERT INTO AREA(idArea,nombre,fkArea) VALUES (@idArea,@nombre,@fkArea)
		ELSE
		INSERT INTO MSJERROR(mensaje) VALUES ('this area already exists')
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH 
		ROLLBACK TRANSACTION
		INSERT INTO MSJERROR (mensaje)
		values (ERROR_MESSAGE())
	END CATCH

GO

--Modificar Area
BEGIN TRANSACTION
	BEGIN TRY
		UPDATE AREA SET nombre = @nombre, fkArea = @fkArea WHERE idArea = @idArea;
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		INSERT INTO MSJERROR values (ERROR_MESSAGE())
	END CATCH

-- Consultar Area
CREATE PROCEDURE [dbo].[procConsultarArea]
	@idArea varchar(10)
	
	
AS
BEGIN TRANSACTION
BEGIN TRY 
	SELECT nombre,fkArea FROM AREA WHERE idArea=@idArea ;
	COMMIT TRANSACTION 
	END TRY 
	BEGIN CATCH 
	ROLLBACK TRANSACTION 
	INSERT INTO MSJERROR values (ERROR_MESSAGE())
	END CATCH

-- Borrar Area
CREATE PROCEDURE [dbo].[procBorrarArea]
	@idArea varchar (10)
	
AS
BEGIN TRANSACTION
BEGIN TRY
DELETE FROM AREA WHERE idArea=@idArea;
COMMIT TRANSACTION
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION
INSERT INTO MSJERROR values (ERROR_MESSAGE())
END CATCH

--------------------------------###------------------------------------------

-- Consultar Autor
CREATE PROCEDURE [dbo].[procConsultarAutor]
	@codigo int

AS
BEGIN TRANSACTION
	BEGIN TRY 
		SELECT codigo, nombre FROM AUTORES WHERE codigo=@codigo;
		COMMIT TRANSACTION 
	END TRY 
	BEGIN CATCH 
		ROLLBACK TRANSACTION 
		INSERT INTO MSJERROR values (ERROR_MESSAGE())
	END CATCH

--Modificar Autor
CREATE PROCEDURE [dbo].[procModificarAutor]
	@codigo int,
	@nombre varchar(50)
AS
BEGIN TRANSACTION
	BEGIN TRY
		UPDATE AUTORES SET nombre = @nombre WHERE codigo = @codigo;
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		INSERT INTO MSJERROR values (ERROR_MESSAGE())
	END CATCH

-- Consultar Autor
CREATE PROCEDURE [dbo].[procConsultarAutor]
	@codigo int

AS
BEGIN TRANSACTION
	BEGIN TRY 
		SELECT nombre FROM AUTORES WHERE codigo=@codigo;
		COMMIT TRANSACTION 
	END TRY 
	BEGIN CATCH 
		ROLLBACK TRANSACTION 
		INSERT INTO MSJERROR values (ERROR_MESSAGE())
	END CATCH

--Borrar autor
CREATE PROCEDURE [dbo].[procBorrarAutor]
	@codigo int
	
AS
BEGIN TRANSACTION
	BEGIN TRY
		DELETE FROM AUTORES WHERE codigo = @codigo;
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		INSERT INTO MSJERROR values (ERROR_MESSAGE())
	END CATCH
----------------------------------------------###-----------------------------------------
--Crear material
CREATE PROCEDURE [dbo].[procInsertMaterial]
@idMaterial varchar(10),
@titulo varchar(30),
@descripcion varchar(50),
@tipo varchar(30),
@autor int,
@fechaIngreso datetime,
@imagen varchar(max),
@ruta varchar(max)

AS
BEGIN TRANSACTION 
     BEGIN TRY
		IF NOT EXISTS (select titulo from MATERIAL where titulo = @titulo)
		INSERT INTO MATERIAL(idMaterial,titulo,descripcion, tipo, autor, fechaIngreso,imagen, ruta)
		VALUES(@idMaterial, @titulo, @descripcion, @tipo, @autor, @fechaIngreso,@imagen, @ruta)
		COMMIT TRANSACTION
	 END TRY
	 BEGIN CATCH 
		ROLLBACK TRANSACTION
		INSERT INTO MSJERROR (mensaje)
		values (ERROR_MESSAGE())
	 END CATCH

--Modificar material
CREATE PROCEDURE [dbo].[procModificarMaterial]
@idMaterial varchar(10),
@titulo varchar(30),
@descripcion varchar(50),
@tipo varchar(30),
@autor int,
@fechaModificacion datetime,
@imagen varchar(max),
@ruta varchar(max)

AS
BEGIN TRANSACTION 
     BEGIN TRY
		
		UPDATE MATERIAL SET idMaterial = @idMaterial, titulo = @titulo, descripcion = @descripcion, tipo = @tipo, autor = @autor, fechaModificacion = @fechaModificacion, imagen = @imagen, ruta = @ruta;
		COMMIT TRANSACTION
	 END TRY
	 BEGIN CATCH 
		ROLLBACK TRANSACTION
		INSERT INTO MSJERROR (mensaje)
		values (ERROR_MESSAGE())
	 END CATCH

--Consultar Material
CREATE PROCEDURE [dbo].[procConsultarMaterial]
	@idMaterial varchar(10)
AS
BEGIN TRANSACTION
	BEGIN TRY
		SELECT idMaterial,titulo,descripcion, tipo, autor, fechaIngreso, fechaModificacion, imagen, ruta FROM MATERIAL WHERE idMaterial = @idMaterial;
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		INSERT INTO MSJERROR (mensaje)
		values (ERROR_MESSAGE())
	END CATCH


-- Borrar Material
CREATE PROCEDURE [dbo].[procBorrarMaterial]
@idMaterial varchar(10)

AS
BEGIN TRANSACTION 
     BEGIN TRY
		
		DELETE FROM MATERIAL WHERE idMaterial = @idMaterial;
		COMMIT TRANSACTION
	 END TRY
	 BEGIN CATCH 
		ROLLBACK TRANSACTION
		INSERT INTO MSJERROR (mensaje)
		values (ERROR_MESSAGE())
	 END CATCH
------------------------------------------###------------------------------
-- Insertar Usuario

CREATE PROCEDURE [dbo].[procInsertUsuario]
@nombreUsr varchar(20),
@contrasena varchar(40),
@tipo varchar(20)


AS
BEGIN TRANSACTION 
     BEGIN TRY
		IF NOT EXISTS (select nombreUsr from USUARIOS where nombreUsr = @nombreUsr)
		INSERT INTO USUARIOS(nombreUsr, contrasena, tipo)
		VALUES (@nombreUsr, @contrasena, @tipo);
		COMMIT TRANSACTION
	 END TRY
	 BEGIN CATCH 
		ROLLBACK TRANSACTION
		INSERT INTO MSJERROR (mensaje)
		values (ERROR_MESSAGE())
	 END CATCH

-- Modificar Usuario 
CREATE PROCEDURE [dbo].[procModificarUsuario]
@nombreUsr varchar(20),
@contrasena varchar(40),
@tipo varchar(20)


AS
BEGIN TRANSACTION 
     BEGIN TRY
		UPDATE USUARIOS SET contrasena = @contrasena, tipo = @tipo;
		COMMIT TRANSACTION
	 END TRY
	 BEGIN CATCH 
		ROLLBACK TRANSACTION
		INSERT INTO MSJERROR (mensaje)
		values (ERROR_MESSAGE())
	 END CATCH

--Consultar Usuario
CREATE PROCEDURE [dbo].[procConsultarUsuario]
	@nombreUsr varchar(20)
AS
BEGIN TRANSACTION
	BEGIN TRY
		SELECT nombreUsr, contrasena, tipo FROM USUARIOS WHERE nombreUsr = @nombreUsr;
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		INSERT INTO MSJERROR (mensaje)
		values (ERROR_MESSAGE())
	END CATCH


-- Borrar Usuarios
CREATE PROCEDURE [dbo].[procBorrarUsuario]
@nombreUsr varchar(20)

AS
BEGIN TRANSACTION 
     BEGIN TRY
		DELETE FROM USUARIOS WHERE nombreUsr = @nombreUsr
		COMMIT TRANSACTION
	 END TRY
	 BEGIN CATCH 
		ROLLBACK TRANSACTION
		INSERT INTO MSJERROR (mensaje)
		values (ERROR_MESSAGE())
	 END CATCH
