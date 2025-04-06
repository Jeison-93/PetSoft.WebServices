CREATE SCHEMA `petsoftdb` DEFAULT CHARACTER SET utf8 COLLATE utf8_bin ;


/*========================================================================================
 TABLES
=========================================================================================*/
CREATE TABLE petsoftdb.DocumentType
(
	Code VARCHAR(10) PRIMARY KEY NOT NULL,
	Description VARCHAR(50) NOT NULL,
	State TINYINT NOT NULL
);


CREATE TABLE petsoftdb.UserType  (
    Code VARCHAR(10) PRIMARY KEY NOT NULL,
    Description VARCHAR(50) NOT NULL,
	State TINYINT NOT NULL
);

CREATE TABLE petsoftdb.ServiceType  (
    Code VARCHAR(10) PRIMARY KEY NOT NULL,
    Description VARCHAR(50) NOT NULL,
    Value double null,
	State TINYINT NOT NULL
);


CREATE TABLE petsoftdb.ServiceState  (
    Code VARCHAR(10) PRIMARY KEY NOT NULL,
    Description VARCHAR(50) NOT NULL,
	State TINYINT NOT NULL
);

CREATE TABLE petsoftdb.Species
(
	Code VARCHAR(10) PRIMARY KEY NOT NULL,
	Description VARCHAR(50) NOT NULL,
	State TINYINT NOT NULL
);

CREATE TABLE petsoftdb.User
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
	DocumentType VARCHAR(10) NOT NULL,
	DocumentNumber VARCHAR(50) NOT NULL,
	Name VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	Address VARCHAR(100)  NULL,
	Phone VARCHAR(50) NOT NULL,
	Password VARCHAR(250),
	UserType VARCHAR(10) NOT NULL,
	State TINYINT NOT NULL
);


CREATE TABLE petsoftdb.Client
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
	DocumentType VARCHAR(10) NOT NULL,
	DocumentNumber VARCHAR(50) NOT NULL,
	Name VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	Address VARCHAR(100)  NULL,
	Phone VARCHAR(50) NOT NULL,
	State TINYINT NOT NULL
);


CREATE TABLE petsoftdb.Pet (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Species VARCHAR(10) NOT NULL,
    Breed VARCHAR(100),
    Age INT,
    Weight DECIMAL(5,2),
    Client INT NOT NULL,
	State TINYINT NOT NULL
);


CREATE TABLE petsoftdb.ClientService
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
	Pet INT NOT NULL,
	DateService VARCHAR(20) NOT NULL,
	HourService VARCHAR(20) NOT NULL,
	ServiceType VARCHAR(10) NOT NULL,
    ServiceState VARCHAR(10) NOT NULL,
	Value DOUBLE NOT NULL,
    SaveDate TIMESTAMP NOT NULL,
    UserSave INT NOT NULL,
    UpdateDate TIMESTAMP NULL,
    UserUpdate INT NULL
);


/*========================================================================================
 FOREIGN KEY
=========================================================================================*/

ALTER TABLE petsoftdb.User
ADD FOREIGN KEY (DocumentType) REFERENCES DocumentType(Code);

ALTER TABLE petsoftdb.User
ADD FOREIGN KEY (UserType) REFERENCES UserType(Code);

ALTER TABLE petsoftdb.Client
ADD FOREIGN KEY (DocumentType) REFERENCES DocumentType(Code);

ALTER TABLE petsoftdb.Pet
ADD FOREIGN KEY (Species) REFERENCES Species(Code);

ALTER TABLE petsoftdb.Pet
ADD FOREIGN KEY (Client) REFERENCES Client(Id);

ALTER TABLE petsoftdb.ClientService
ADD FOREIGN KEY (Pet) REFERENCES Pet(Id);

ALTER TABLE petsoftdb.ClientService
ADD FOREIGN KEY (ServiceType) REFERENCES ServiceType(Code);

ALTER TABLE petsoftdb.ClientService
ADD FOREIGN KEY (ServiceState) REFERENCES ServiceState(Code);

ALTER TABLE petsoftdb.ClientService
ADD FOREIGN KEY (UserSave) REFERENCES User(Id);

ALTER TABLE petsoftdb.ClientService
ADD FOREIGN KEY (UserUpdate) REFERENCES User(Id);

/*--========================================================================================
--DEFAULT VALUES
--========================================================================================*/



/*DOCUMENT TYPES*/
INSERT INTO petsoftdb.DocumentType (Code, Description, State) VALUES ('CC', 'Cédula de Ciudadanía', 1);
INSERT INTO petsoftdb.DocumentType (Code, Description, State) VALUES ('CE', 'Cédula de Extranjería', 1);
INSERT INTO petsoftdb.DocumentType (Code, Description, State) VALUES ('RUT', 'Registro Único Tributario', 1);


/*USER TYPE*/
INSERT INTO petsoftdb.UserType (Code, Description, State) VALUES ('ADM', 'Administrador', 1);
INSERT INTO petsoftdb.UserType (Code, Description, State) VALUES ('AUX', 'Auxiliar', 1);
INSERT INTO petsoftdb.UserType (Code, Description, State) VALUES ('VET', 'Veterinario', 1);

/*USER*/
INSERT INTO petsoftdb.User (DocumentType,DocumentNumber,Name,LastName,Email,Password,UserType, phone,State) 
VALUE('CC',	'00000000',	'Administrador','Pruebas','admon@gmail.com','OkKH61z3fxkO2pQJ2Rk3gQ==','ADM', '0000000',1);

cls
/*SERVICE STATE*/
INSERT INTO petsoftdb.ServiceState (Code, Description, State) VALUES ('AGD', 'Agendado', 1);
INSERT INTO petsoftdb.ServiceState (Code, Description, State) VALUES ('CONF', 'Confirmado', 1);
INSERT INTO petsoftdb.ServiceState (Code, Description, State) VALUES ('CAN', 'Cancelado', 1);
INSERT INTO petsoftdb.ServiceState (Code, Description, State) VALUES ('REAG', 'Reagendado', 1);
INSERT INTO petsoftdb.ServiceState (Code, Description, State) VALUES ('ATEN', 'Atendido', 1);
INSERT INTO petsoftdb.ServiceState (Code, Description, State) VALUES ('PAG', 'Pagado', 1);

/*SERVICE TYPE*/
INSERT INTO petsoftdb.ServiceType (Code, Description, Value, State) VALUES ('PEL', 'Peluquería', 35000, 1);
INSERT INTO petsoftdb.ServiceType (Code, Description, Value, State) VALUES ('CEXT', 'Consulta Externa', 30000, 1);
INSERT INTO petsoftdb.ServiceType (Code, Description, Value, State) VALUES ('VAC', 'Vacunación', 15000, 1);
INSERT INTO petsoftdb.ServiceType (Code, Description, Value, State) VALUES ('LABO', 'Laboratorio', 25000, 1);
INSERT INTO petsoftdb.ServiceType (Code, Description, Value, State) VALUES ('CIRU', 'Cirugía', 120000, 1);

/*SPECIES*/
INSERT INTO petsoftdb.Species (Code, Description, State) VALUES ('PERRO', 'Perro', 1);
INSERT INTO petsoftdb.Species (Code, Description, State) VALUES ('GATO', 'Gato', 1);
INSERT INTO petsoftdb.Species (Code, Description, State) VALUES ('AVE', 'Ave', 1);
INSERT INTO petsoftdb.Species (Code, Description, State) VALUES ('REP', 'Reptil', 1);
INSERT INTO petsoftdb.Species (Code, Description, State) VALUES ('VAC', 'Vacuno', 1);
INSERT INTO petsoftdb.Species (Code, Description, State) VALUES ('BOV', 'Bovino', 1);
INSERT INTO petsoftdb.Species (Code, Description, State) VALUES ('OTRO', 'Otro', 1);

