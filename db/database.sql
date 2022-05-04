-- CREATE DATABASE comiczoom 

use [comiczoom]
go

-- 1. TABLA REGION --
CREATE TABLE REGION
(
REGid int not null identity(1,1) primary key,
REGnombre varchar(50)
)
---------------------

-- 2. TABLA PROVINCIA --  
CREATE TABLE PROVINCIA
(
PROid int not null identity(1,1) primary key,
PROidREG int not null,
PROnombre varchar(50),
constraint FK_PROVINCIA_REGION foreign key (PROidREG) references REGION(REGid)
)
---------------------

-- 3. TABLA COMUNA --    
CREATE TABLE COMUNA
(
CMNid int not null identity(1,1) primary key,
CMNidPRO int not null,
CMNnombre varchar(70),
constraint FK_COMUNA_PROVINCIA foreign key (CMNidPRO) references PROVINCIA(PROid)
)
---------------------
  
-- 4. TABLA SUCURSAL --    
CREATE TABLE SUCURSAL
(
SUCid int not null identity(1,1) primary key,
SUCidREG int not null,
SUCidPRO int not null,
SUCidCMN int not null,
SUCnombre varchar(30) not null,
SUCdireccion varchar(70) not null,
constraint FK_SUCURSAL_REGION foreign key (SUCidREG) references REGION(REGid),
constraint FK_SUCURSAL_PROVINCIA foreign key (SUCidPRO) references PROVINCIA(PROid),
constraint FK_SUCURSAL_COMUNA foreign key (SUCidCMN) references COMUNA(CMNid)
)
---------------------
  
-- 5. TABLA TIPO_EMPLEADO --
CREATE TABLE TIPO_EMPLEADO
(
TEid int not null identity(1,1) primary key,
TEnombre varchar(30) not null
)
---------------------

-- 6. TABLA EMPLEADO --
CREATE TABLE EMPLEADO
(
EMid int not null Identity(1,1) primary key,
EMidREG int not null,
EMidPRO int not null,
EMidCMN int not null,
EMidSUC int not null,
EMidTE int not null,
EMrut varchar(12) not null,
EMnombre varchar(30) not null,
EMsegNombre varchar(30),  
EMapellido varchar(30) not null,
EMsegApellido varchar(30) not null,
EMtelefono varchar(20) not null,
EMcontrasenia varchar(50),
EMdireccion varchar(70) not null,
constraint FK_EMPLEADO_REGION foreign key (EMidREG) references REGION(REGid),
constraint FK_EMPLEADO_PROVINCIA foreign key (EMidPRO) references PROVINCIA(PROid),
constraint FK_EMPLEADO_COMUNA foreign key (EMidCMN) references COMUNA(CMNid),
constraint FK_EMPLEADO_SUCURSAL foreign key (EMidSUC) references SUCURSAL(SUCid),
constraint FK_EMPLEADO_TIPO_EMPLEADO foreign key (EMidTE) references TIPO_EMPLEADO(TEid)
)
---------------------

