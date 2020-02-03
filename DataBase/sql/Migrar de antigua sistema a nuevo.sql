
/*
	 Se crea la tabla que se unira con Creditos y CreditoDesempenio
*/
CREATE TABLE [CreditosUnion](
	[CreditoID] [int]  NOT NULL    IDENTITY    PRIMARY KEY,
	[NumeroDeControl] [varchar](8) NOT NULL,
	[FechaDeOficio] [date] NOT NULL,
	[ActividadID] [int] NOT NULL,
	[Periodo] [int] NOT NULL,
	[ResponsableID] [smallint] NOT NULL,
	[JefeID] [int] NOT NULL,
	[CarreraID] [tinyint] NOT NULL,
	[Pregunta1] [tinyint] NULL,
	[Pregunta2] [tinyint] NULL,
	[Pregunta3] [tinyint] NULL,
	[Pregunta4] [tinyint] NULL,
	[Pregunta5] [tinyint] NULL,
	[Pregunta6] [tinyint] NULL,
	[Pregunta7] [tinyint] NULL,
	[Promedio] [float] NULL,
	[EstadoDeLaActividad] [char](1)  NULL,
	[Consecutivo] [int] NULL,
	[EstadoDeLaFirma] [char](1)  NOT NULL,
)

/*
	Se insertan los datos que existan en los creditos en CreditosUnion
*/
INSERT INTO CreditosUnion (consecutivo, NumeroDeControl, FechaDeOficio, ActividadID, Periodo,ResponsableID,JefeID,CarreraID, EstadoDeLaActividad, EstadoDeLaFirma) SELECT  Consecutivo, noControl, fechaOficio, idActividadD, periodo, idResponsable, idJefe, idCarrera,'A','P' FROM Creditos


/*
	Se le agregan sus desempeños de acuerdo al numero de control y numero consecutivo  a la tabla CreditosUnion, y posteriormente se le asigna como terminado
*/
UPDATE d
SET
d.Pregunta1 = o.pregunta1,
d.Pregunta2 = o.pregunta2,
d.Pregunta3 = o.pregunta3,
d.Pregunta4 = o.pregunta4,
d.Pregunta5 = o.pregunta5,
d.Pregunta6 = o.pregunta6,
d.Pregunta7 = o.pregunta7,
d.Promedio = o.Promedio,
d.EstadoDeLaActividad = 'T'

FROM CreditosUnion d
INNER JOIN CreditoDesempenio o
ON d.Consecutivo = o.Consecutivo AND d.NumeroDeControl = o.noControl

/*
	Se crea la nueva tabla definitiva que se utilizara para el proyecto
*/
CREATE TABLE [Creditosx](
	[CreditoID] [int]  NOT NULL    IDENTITY    PRIMARY KEY,
	[NumeroDeControl] [varchar](9) NOT NULL,
	[FechaDeOficio] [date] NOT NULL,
	[ActividadID] [int] NOT NULL,
	[Periodo] [int] NOT NULL,
	[ResponsableID] [int] NOT NULL,
	[JefeID] [int] NOT NULL,
	[CarreraID] [tinyint] NOT NULL,
	[Pregunta1] [tinyint] NULL,
	[Pregunta2] [tinyint] NULL,
	[Pregunta3] [tinyint] NULL,
	[Pregunta4] [tinyint] NULL,
	[Pregunta5] [tinyint] NULL,
	[Pregunta6] [tinyint] NULL,
	[Pregunta7] [tinyint] NULL,
	[Promedio] [float] NULL,
	[EstadoDeLaActividad] [char](1)  NOT NULL,
	[EstadoDeLaFirma] [char](1)  NOT NULL,
)

/*
	Se insertan los datos a la tabla definitiva
*/
INSERT INTO Creditosx ( NumeroDeControl, FechaDeOficio, ActividadID, Periodo,ResponsableID,JefeID,CarreraID, EstadoDeLaActividad, Pregunta1, Pregunta2, Pregunta3, Pregunta4, Pregunta5, Pregunta6, Pregunta7, Promedio, EstadoDeLaFirma) SELECT  NumeroDeControl, FechaDeOficio, ActividadID, Periodo,ResponsableID,JefeID,CarreraID, EstadoDeLaActividad, Pregunta1, Pregunta2, Pregunta3, Pregunta4, Pregunta5, Pregunta6, Pregunta7, Promedio, EstadoDeLaFirma FROM CreditosUnion

/*
	MIGRACION DE LA TABLA Actividad a una nueva

	Crear una tabla basandose en la anterior, con la unica diferencia de nombres de los campos y tabla
*/
CREATE TABLE [Secciones](
	[SeccionID] [int]  NOT NULL    IDENTITY    PRIMARY KEY,
	[Titulo] [varchar](100) NOT NULL,
	[PesoMaximo] [tinyInt]  NULL
)

INSERT INTO Secciones (Titulo) SELECT descripcionAct FROM Actividad


/*
	MIGRACION DE LA TABLA ActividadDetalle a una nueva

	Crear una tabla basandose en la anterior, con la unica diferencia de nombres de los campos y tabla
*/
CREATE TABLE [Actividades](
	[ActividadID] [int]  NOT NULL    IDENTITY    PRIMARY KEY,
	[SeccionID] [int]  NOT NULL,
	[Titulo] [varchar](100) NOT NULL,
	[Peso] [tinyInt] NOT NULL
)

INSERT INTO Actividades (SeccionID, Titulo,Peso) SELECT idActividad, descripcion,maxCreditos  FROM ActividadDetalle


/*
	Valores por default en el desempenio
*/
UPDATE Creditosx SET Pregunta1 = 0,Pregunta2 = 0,Pregunta3 = 0,Pregunta4 = 0,Pregunta5 = 0,Pregunta6 = 0,Pregunta7 = 0, Promedio = 0 WHERE Promedio IS NULL


/*
	Creacion de la tabla para el login de los usuarios
*/
CREATE TABLE [Usuarios](
	[UsuarioID] [int]  NOT NULL    IDENTITY    PRIMARY KEY,
	[Nombre][varchar](80) NOT NULL,
	[Apellidos][varchar](80) NOT NULL,
	[Clave] [varchar](40) NOT NULL,
	[Rol] [varchar](80) NOT NULL,
	[PersonalID][int] NOT NULL,
	[DepartamentoID][int] NOT NULL,
	[Genero][char](1) NOT NULL,
)

/*
	USUARIO POR DEFAULT:
	ADMINISTRADOR
*/
INSERT INTO Usuarios (Nombre, Apellidos, Clave, Rol,PersonalID, Genero, DepartamentoID) VALUES ('Administrador', '', '', 'Administrador', 1, 'H', 418)

UPDATE Secciones SET PesoMaximo = 2
/*
INSERT INTO Usuarios ( Nombre,Apellidos, DepartamentoID) SELECT idActividad, descripcion,maxCreditos, idDepto  FROM ActividadDetalle
*/


DROP TABLE CreditoDesempenio
DROP TABLE Creditos
DROP TABLE ActividadDetalle
DROP TABLE Actividad
DROP TABLE CreditosUnion

EXEC sp_rename 'Creditosx', 'Creditos';
