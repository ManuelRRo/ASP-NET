
USE DB_ACTIVOFIJO;
CREATE TABLE CAT.TBL_EspecificoGasto
(
	IdEspecifico int IDENTITY(1,1) NOT NULL,
	CodigoEspecifico varchar(10) NOT NULL,
	NombreEspecifico varchar(100) NOT NULL
	CONSTRAINT PK_TBL_EspecificoGasto PRIMARY KEY CLUSTERED (IdEspecifico)
);