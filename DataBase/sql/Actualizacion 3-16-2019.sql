

CREATE TABLE Reportes(
    ID INTEGER IDENTITY PRIMARY KEY,
    Titulo VARCHAR(60) NOT NULL,
   	FechaDeOficio DATE NOT NULL,
	CarreraID INTEGER NOT NULL,
)
 
CREATE TABLE AlumnoReporte(
	NumeroDeControl VARCHAR(8) NOT NULL,
	ReporteID INTEGER NOT NULL,
	FOREIGN KEY (ReporteID) REFERENCES Reportes(ID)
)




 --SELECT NumeroDeControl, COUNT(NumeroDeControl) AS 'Completados' FROM Creditos WHERE EstadoDeLaActividad = 'T' GROUP BY NumeroDeControl HAVING COUNT(NumeroDeControl) >= 5 ORDER BY NumeroDeControl 
 

-- SELECT NumeroDeControl, COUNT(NumeroDeControl) FROM Creditos WHERE CarreraID = 1 AND EstadoDeLaActividad = 'T' GROUP BY NumeroDeControl HAVING COUNT(NumeroDeControl) >= 5


 




