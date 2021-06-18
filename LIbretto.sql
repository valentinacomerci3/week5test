

CREATE TABLE StudenteEsame(
	StudenteID int NOT NULL,
	EsameID int NOT NULL,
	FOREIGN KEY (EsameID) REFERENCES Esame(ID),
	FOREIGN KEY (StudenteID) REFERENCES Studente(ID),
	
)

CREATE TABLE Studente(
	ID int IDENTITY(1, 1) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Cognome VARCHAR(50) NOT NULL,
	AnnoNascita int NOT NULL,
	PRIMARY KEY (ID),
)

CREATE TABLE Esame(
	ID int IDENTITY(1, 1) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	CFU int NOT NULL,
	DataEsame DATE NOT NULL,
	Voto int NOT NULL,
	Esito VARCHAR(50) NOT NULL,
	PRIMARY KEY (ID),
)

INSERT INTO Studente VALUES ('Mario', 'Rossi', 1995 )
INSERT INTO Studente VALUES ('Renata', 'Bianchi', 1995 )
INSERT INTO Studente VALUES ('Chiara', 'Verdi', 1996 )
INSERT INTO Studente VALUES ('Antonella', 'Gialli', 1992)

INSERT INTO StudenteEsame VALUES (1, 3)
INSERT INTO StudenteEsame VALUES (2, 1)
INSERT INTO StudenteEsame VALUES (3, 1)
INSERT INTO StudenteEsame VALUES (4, 2)
INSERT INTO StudenteEsame VALUES (5, 6)
INSERT INTO StudenteEsame VALUES (6, 5)

INSERT INTO Esame VALUES ('Storia', 6,  '2012-09-06',24, 'positivo')
INSERT INTO Esame VALUES ('Lingua2', 9,  '2012-09-06',24, 'positivo')
INSERT INTO Esame VALUES ('Informatica', 12,  '2012-09-06',24, 'positivo')
INSERT INTO Esame VALUES ('Biologia', 6,  '2012-09-06',24, 'positivo')
INSERT INTO Esame VALUES ('Matematica', 6,  '2012-09-06',24, 'positivo')
INSERT INTO Esame VALUES ('Storia Moderna', 6,  '2012-09-06',24, 'positivo')
