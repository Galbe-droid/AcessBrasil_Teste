CREATE TABLE DbCarro (
	Codigo INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	MarcaCodigo INT NOT NULL,
	Modelo VARCHAR(40) NOT NULL,
	Ano INT NOT NULL,
	Cor VARCHAR(40)
);

CREATE TABLE DbMarca(
	Codigo INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Marca VARCHAR(40) NOT NULL
);