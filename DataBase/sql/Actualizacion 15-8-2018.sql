
/*
    Agregar columna de grupos
*/
ALTER TABLE Creditos ADD GrupoID int NULL
/*
	 Creacion de una tabla para crear grupos
*/
CREATE TABLE [Grupos](
	[GrupoID] [int]  NOT NULL    IDENTITY    PRIMARY KEY,
	[Titulo] [varchar](100) NOT NULL,
	[ActividadID] [int] NOT NULL,
	[Limite] [int] NOT NULL,
	[ResponsableID] [int] NOT NULL
)




 
/*

------------------------------------------>EN PROCESO<------------------------------------------------
CREATE TABLE [Ajustes](
	[Titulo] [varchar](30) NOT NULL,
  [Valor] [varchar](30) NOT NULL,
)
*/


/*
	 Creacion de una tabla para los logs
*/
CREATE TABLE [Logs](
	[LogID] [int]  NOT NULL    IDENTITY    PRIMARY KEY,
	[UsuarioID] [int] NOT NULL,
	[Contenido] [varchar](200) NOT NULL,
	[Fecha] [date] NOT NULL,
)
