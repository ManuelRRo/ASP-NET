USE CRUD_EMPLEADOS;
CREATE TABLE dbo.TBL_EMPLEADOS(
	codigo				VARCHAR(10)			NOT NULL,
	nombre				VARCHAR(20)			NOT NULL,
	apellidos			VARCHAR(20)			NOT NULL,
	direccion			VARCHAR(300)		NOT NULL,
	telefono			INT					NOT NULL,
	fecha_nacimiento	DATE				NOT NULL
	CONSTRAINT PK_Codigo PRIMARY KEY CLUSTERED (codigo)
);



INSERT INTO dbo.TBL_EMPLEADOS(codigo, nombre, apellidos, direccion, telefono, fecha_nacimiento) VALUES ('001', 'Jason Saul', 'Martinez Argueta', 'Direccion de prueba', 25252525, '1999-07-28');

SELECT *FROM TBL_EMPLEADOS;