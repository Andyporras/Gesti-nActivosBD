--##################CREACIÓN DE LA BASE DE DATOS

--MILTON BARRERA ZEPEDA | 2021091205
--ANDY PORRAS ROMERO | 20210678934


USE master
GO

IF EXISTS (SELECT * FROM sys.databases WHERE [name] = N'GestorAplicaciones')
BEGIN
	PRINT 'ELIMINANDO...';
	--DROP DATABASE GestorAplicaciones;
END
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE (name = N'GestorAplicaciones'))
BEGIN
	PRINT 'CREANDO...';
	CREATE DATABASE GestorAplicaciones;
END
GO

USE GestorAplicaciones;
GO

IF OBJECT_ID(N'proyecto_error', N'U') IS NOT NULL
	ALTER TABLE proyecto_error DROP CONSTRAINT fk_proyecto_error_with_proyecto_id
	GO
	ALTER TABLE proyecto_error DROP CONSTRAINT fk_proyecto_error_with_error_id
	GO
	ALTER TABLE error DROP CONSTRAINT fk_error_with_numSerie_servidor
	GO
	ALTER TABLE error DROP CONSTRAINT fk_error_with_cod_aplicacion
	GO
	ALTER TABLE error DROP CONSTRAINT fk_error_with_proyecto_id
	GO
	ALTER TABLE software_servidores DROP CONSTRAINT fk_software_servidores_with_cod_aplicacion
	GO
	ALTER TABLE software_servidores DROP CONSTRAINT fk_software_servidores_with_numSerie_servidor
	GO
	ALTER TABLE software_servidores DROP CONSTRAINT fk_software_servidores_with_tipo_servidor
	GO
	ALTER TABLE software_departamento DROP CONSTRAINT fk_software_departamento_with_cod_aplicacion
	GO
	ALTER TABLE software_departamento DROP CONSTRAINT fk_software_departamento_with_cod_departamento
	GO
	ALTER TABLE empleado_departamento DROP CONSTRAINT fk_empleado_departamento_with_ced_empleado
	GO
	ALTER TABLE empleado_departamento DROP CONSTRAINT fk_empleado_departamento_with_cod_departamento
	GO
	ALTER TABLE gestionEmpleados DROP CONSTRAINT fk_gestionEmpleados_with_personas_id
	GO
	ALTER TABLE gestionEmpleados DROP CONSTRAINT fk_gestionEmpleados_with_proyecto_id
	GO
	DROP TABLE proyecto_error;

GO

IF OBJECT_ID(N'software_servidores', N'U') IS NOT NULL
	DROP TABLE software_servidores;
GO


IF OBJECT_ID(N'software_departamento', N'U') IS NOT NULL
	DROP TABLE software_departamento;
GO

IF OBJECT_ID(N'empleado_departamento', N'U') IS NOT NULL
	DROP TABLE empleado_departamento;
GO



IF OBJECT_ID(N'servidor', N'U') IS NOT NULL
	DROP TABLE servidor;
GO

IF OBJECT_ID(N'proyecto', N'U') IS NOT NULL
	DROP TABLE proyecto;
GO

IF OBJECT_ID(N'persona', N'U') IS NOT NULL
	DROP TABLE persona;
GO

IF OBJECT_ID(N'software', N'U') IS NOT NULL
	DROP TABLE software;
GO

IF OBJECT_ID(N'departamento', N'U') IS NOT NULL
	DROP TABLE departamento;
GO

IF OBJECT_ID(N'error', N'U') IS NOT NULL
	DROP TABLE error;
GO

IF OBJECT_ID(N'gestionEmpleados', N'U') IS NOT NULL
	DROP TABLE gestionEmpleados;
GO

IF OBJECT_ID(N'departamento', N'U') IS NOT NULL
	DROP TABLE departamento;
GO

  
-- ANDY  
CREATE TABLE servidor(
  numeroSerie varchar(20) NOT NULL UNIQUE,
  tipo VARCHAR(10) NOT NULL UNIQUE,
  memoria varchar(50) NOT NULL,
  capacidadAlmacenamiento varchar(50) NOT NULL,
  capacidadProcesamiento varchar(50) NOT NULL,
  modelo varchar(50) NOT NULL,
  marca varchar(50) NOT NULL,
  fechaCompra DATE NOT NULL,
  cod_aplicaciones TEXT NOT NULL,
  PRIMARY KEY(numeroSerie, tipo)
);

CREATE TABLE proyecto(
  identificador varchar(20) NOT NULL UNIQUE,
  nombre varchar(50) NOT NULL,
  descripcion TEXT NOT NULL,
  esfuerzoEstimado varchar(30) NOT NULL,
  esfuerzoReal varchar(35) NOT NULL,
  fechaInicio DATE NOT NULL,
  fechaFinal DATE NOT NULL,
  PRIMARY KEY (identificador)
);
  
 CREATE TABLE persona(
  cedula varchar(20) NOT NULL UNIQUE,
  apellidos varchar(50) NOT NULL,
  nombre varchar(50) NOT NULL,
  rol varchar(50) NOT NULL,
  PRIMARY KEY (cedula)
 );
  
  --MILTON⏬
CREATE TABLE software (
  codigo VARCHAR(20) NOT NULL UNIQUE,
  numero_patente VARCHAR(50) NOT NULL UNIQUE,
  numSerie_servidor VARCHAR(20) NOT NULL UNIQUE,
  tipo VARCHAR(10) NOT NULL UNIQUE,
  nombre VARCHAR(25) NOT NULL,
  descripcion TEXT NOT NULL,
  fecha_produccion DATE NOT NULL,
  fecha_expiracion DATE NOT NULL,
  cod_departamento VARCHAR(25) NOT NULL,
  PRIMARY KEY (codigo, numero_patente, numSerie_servidor, tipo)
);

CREATE TABLE departamento(
  codigo VARCHAR (20) UNIQUE,
  nombre VARCHAR (50),
  jefe_ced VARCHAR (50),
  ced_empleados TEXT,
  softwares_id TEXT,
  PRIMARY KEY (codigo)
)


CREATE TABLE error (
  identificador VARCHAR(20) NOT NULL UNIQUE,
  descripcion TEXT NOT NULL,
  numSerie_servidor VARCHAR(20),
  cod_aplicacion VARCHAR(20),
  impacto VARCHAR NOT NULL,
  fecha DATE NOT NULL,
  hora DATE NOT NULL,
  proyecto_id VARCHAR(20),
  PRIMARY KEY (identificador)
);

CREATE TABLE gestionEmpleados(
  id VARCHAR (50) NOT NULL,
  proyecto_id VARCHAR(20) NOT NULL,
  personas_id VARCHAR(20) NOT NULL,
  PRIMARY KEY (id, proyecto_id)
);

--TABLAS TRANSITIVAS ABAJO

CREATE TABLE software_servidores(
	cod_aplicacion VARCHAR(20) NOT NULL,
	numSerie_servidor VARCHAR(20)  NOT NULL,
	tipo_servidor VARCHAR(10) NOT NULL,
	PRIMARY KEY (cod_aplicacion, numSerie_servidor, tipo_servidor)
);

CREATE TABLE proyecto_error(
	proyecto_id VARCHAR(20) NOT NULL UNIQUE,
	error_id VARCHAR(20) NOT NULL UNIQUE,
	PRIMARY KEY (proyecto_id, error_id)
);

CREATE TABLE software_departamento(
	cod_aplicacion VARCHAR(20) NOT NULL,
	cod_departamento VARCHAR(20)  NOT NULL,
	PRIMARY KEY (cod_aplicacion, cod_departamento)
);

CREATE TABLE empleado_departamento(
	ced_empleado VARCHAR(20) NOT NULL,
	cod_departamento VARCHAR(20)  NOT NULL,
	PRIMARY KEY (ced_empleado, cod_departamento)
);

--RESTRICCIONES
ALTER TABLE software ADD CONSTRAINT chk_tipoSoftware CHECK (tipo = 'NEGOCIO' OR tipo = 'UTILITARIA' OR tipo = 'OTRO');

ALTER TABLE persona ADD CONSTRAINT chk_rolPersona CHECK (rol = 'CODER' OR rol = 'SUPERVISOR' OR rol = 'TESTER');

ALTER TABLE error ADD CONSTRAINT chk_impactoError CHECK (impacto = 'BAJO' OR impacto = 'MEDIO' OR impacto = 'ALTO' OR impacto = 'DESCONOCIDO');

ALTER TABLE servidor ADD CONSTRAINT chk_tipoServidor CHECK (tipo = 'PRODUCTION' OR tipo = 'TESTING' OR tipo = 'STAGGING' OR tipo = 'BACKUP');

--LLAVES FORANEAS
ALTER TABLE proyecto_error ADD CONSTRAINT fk_proyecto_error_with_proyecto_id FOREIGN KEY (proyecto_id) REFERENCES proyecto(identificador) ON DELETE NO ACTION;
ALTER TABLE proyecto_error ADD CONSTRAINT fk_proyecto_error_with_error_id FOREIGN KEY (error_id) REFERENCES error(identificador) ON DELETE NO ACTION;

ALTER TABLE error ADD CONSTRAINT fk_error_with_numSerie_servidor FOREIGN KEY (numSerie_servidor) REFERENCES software(numSerie_servidor) ON DELETE NO ACTION;
ALTER TABLE error ADD CONSTRAINT fk_error_with_cod_aplicacion FOREIGN KEY (cod_aplicacion) REFERENCES software(codigo) ON DELETE NO ACTION;
ALTER TABLE error ADD CONSTRAINT fk_error_with_proyecto_id FOREIGN KEY (proyecto_id) REFERENCES proyecto_error(proyecto_id) ON DELETE NO ACTION;

ALTER TABLE software_servidores ADD CONSTRAINT fk_software_servidores_with_cod_aplicacion FOREIGN KEY (cod_aplicacion) REFERENCES software(codigo) ON DELETE NO ACTION;
ALTER TABLE software_servidores ADD CONSTRAINT fk_software_servidores_with_numSerie_servidor FOREIGN KEY (numSerie_servidor) REFERENCES software(numSerie_servidor) ON DELETE NO ACTION;
ALTER TABLE software_servidores ADD CONSTRAINT fk_software_servidores_with_tipo_servidor FOREIGN KEY (tipo_servidor) REFERENCES servidor(tipo) ON DELETE NO ACTION;

ALTER TABLE software_departamento ADD CONSTRAINT fk_software_departamento_with_cod_aplicacion FOREIGN KEY (cod_aplicacion) REFERENCES software(codigo) ON DELETE NO ACTION;
ALTER TABLE software_departamento ADD CONSTRAINT fk_software_departamento_with_cod_departamento FOREIGN KEY (cod_departamento) REFERENCES departamento(codigo) ON DELETE NO ACTION;

ALTER TABLE empleado_departamento ADD CONSTRAINT fk_empleado_departamento_with_ced_empleado FOREIGN KEY (ced_empleado) REFERENCES persona(cedula) ON DELETE NO ACTION;
ALTER TABLE empleado_departamento ADD CONSTRAINT fk_empleado_departamento_with_cod_departamento FOREIGN KEY (cod_departamento) REFERENCES departamento(codigo) ON DELETE NO ACTION;


ALTER TABLE gestionEmpleados ADD CONSTRAINT fk_gestionEmpleados_with_personas_id FOREIGN KEY (personas_id) REFERENCES persona(cedula) ON DELETE NO ACTION;
ALTER TABLE gestionEmpleados ADD CONSTRAINT fk_gestionEmpleados_with_proyecto_id FOREIGN KEY (proyecto_id) REFERENCES proyecto(identificador) ON DELETE NO ACTION;

