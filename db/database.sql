-- CREATE DATABASE comiczoom 

use [comiczoom]
go

-- 1. TABLA REGION -- 
CREATE TABLE REGION
(
id int not null identity(1,1) primary key,
nombre varchar(50) not null 
)
---------------------

-- 2. TABLA PROVINCIA --  
CREATE TABLE PROVINCIA
(
id int not null identity(1,1) primary key,
idREG int not null,
nombre varchar(50),
constraint FK_PROVINCIA_REGION foreign key (idREG) references REGION(id)
)
---------------------

-- 3. TABLA COMUNA --    
CREATE TABLE COMUNA
(
id int not null identity(1,1) primary key,
idPRO int not null,
nombre varchar(70),
constraint FK_COMUNA_PROVINCIA foreign key (idPRO) references PROVINCIA(id)
)
---------------------
  
-- 4. TABLA SUCURSAL --    
CREATE TABLE SUCURSAL
(
id int not null identity(1,1) primary key,
idREG int not null,
idPRO int not null,
idCMN int not null,
nombre varchar(30) not null,
direccion varchar(70) not null,
constraint FK_SUCURSAL_REGION foreign key (idREG) references REGION(id),
constraint FK_SUCURSAL_PROVINCIA foreign key (idPRO) references PROVINCIA(id),
constraint FK_SUCURSAL_COMUNA foreign key (idCMN) references COMUNA(id)
)
---------------------
  
-- 5. TABLA TIPO_EMPLEADO --
CREATE TABLE TIPO_EMPLEADO
(
id int not null identity(1,1) primary key,
nombre varchar(30) not null
)
---------------------

-- 6. TABLA EMPLEADO --
CREATE TABLE EMPLEADO
(
id int not null Identity(1,1) primary key,
idREG int not null,
idPRO int not null,
idCMN int not null,
idSUC int not null,
idTE int not null,
rut varchar(12) not null,
nombre varchar(30) not null,
segNombre varchar(30),  
apellido varchar(30) not null,
segApellido varchar(30) not null,
telefono varchar(20) not null,
correo varchar(100) not null,
contrasenia varchar(50),
direccion varchar(70) not null,
constraint FK_EMPLEADO_REGION foreign key (idREG) references REGION(id),
constraint FK_EMPLEADO_PROVINCIA foreign key (idPRO) references PROVINCIA(id),
constraint FK_EMPLEADO_COMUNA foreign key (idCMN) references COMUNA(id),
constraint FK_EMPLEADO_SUCURSAL foreign key (idSUC) references SUCURSAL(id),
constraint FK_EMPLEADO_TIPO_EMPLEADO foreign key (idTE) references TIPO_EMPLEADO(id)
)
---------------------
-----------------------------------------------------------------------------------
-- Trabajo jueves productivo *carita fachera facherita*
-----------------------------------------------------------------------------------
-- TABLA COMIC --
CREATE TABLE COMIC
  (
id int not null identity(1,1) primary key,
nombre varchar(30) not null,
volumen int null,
estado int not null,
isbn varchar(15) not null,
categoria varchar(20) not null,
fechaCreacion date not null
);
---------------------

-- TABLA RUBRO --
CREATE TABLE RUBRO 
(
id int not null identity(1,1) primary key,
nombre varchar(200) not null
)
---------------------
  
-- TABLA EQUIPO COMIC --
CREATE TABLE EQUIPO_COMIC
(
  id int not null identity(1,1) primary key,
  idCOM int not null,
  fechaCreacion date not null,
  constraint FK_EQUIPO_COMIC_COMIC foreign key (idCOM) references COMIC(id)
)
---------------------
  
-- TABLA EMPLEADO EQUIPO COMIC --
CREATE TABLE EMPLEADO_EQUIPO_COMIC
(
  id int not null identity(1,1) primary key,
  idEMP int not null,
  idEC int not null,
  fechaCreacion date not null,
  constraint FK_EEC_EMPLEADO  foreign key (idEMP) references EMPLEADO(id),
  constraint FK_EEC_EQUIPO_COMIC foreign key (idEC) references EQUIPO_COMIC(id)
);
---------------------

-- TABLA TIRAJE --
CREATE TABLE TIRAJE
(
  id int not null identity(1,1) primary key,
  idSUC int not null,
  fecha date not null,
  hora time not null,
  estado int not null,
  constraint FK_TIRAJE_SUCURSAL foreign key (idSUC) references SUCURSAL(id)
);
---------------------

-- TABLA DETALLE TIRAJE --
CREATE TABLE DETALLE_TIRAJE
(
  id int not null identity(1,1) primary key,
  idCOM int not null,
  idTIR int not null,
  cantidad int not null,
  precioUnit decimal not null,
  precioTotal decimal not null,
  constraint FK_DT_COMIC foreign key(idCOM) references COMIC(id),
  constraint FK_DT_TIRAJE foreign key(idTIR) references TIRAJE(id)
);
---------------------

-- TABLA RECEPCION TIRAJE --
CREATE TABLE RECEPCION_TIRAJE
(
  id int not null identity(1,1) primary key,
  idTIR int not null,
  fecha date not null,
  hora time not null,
  constraint FK_RT_TIRAJE foreign key (idTIR) references TIRAJE(id)
);
---------------------

-- TABLA DETALLE RECEPCION TIRAJE --
CREATE TABLE DETALLE_RECEPCION_TIRAJE
(
  id int not null identity(1,1) primary key,
  idRT int not null,
  idCOM int not null,
  cantidad int not null, -- Validacion <0
  constraint FK_DRT_TIR foreign key (idRT) references RECEPCION_TIRAJE(id), 
  constraint FK_DRT_COM foreign key (idCOM) references COMIC(id)
);
---------------------

-- TABLA CLIENTE --
CREATE TABLE CLIENTE
(
  id int not null identity(1,1) primary key,
  idREG int not null,
  idPRO int not null,
  idCMN int not null,
  nombre varchar(30) not null,
  segNombre varchar(30) null,
  apellido varchar(30) not null,
  segApellido varchar(30) null,
  rut varchar(12) not null,
  tipo int not null,
  direccion varchar(30) not null,
  telefono varchar(20) null,
  constraint FK_CLIENTE_REGION foreign key (idREG) references REGION(id),
  constraint FK_CLIENTE_PROVINCIA foreign key (idPRO) references PROVINCIA(id),
  constraint FK_CLIENTE_COMUNA foreign key (idCMN) references COMUNA(id)
  )
---------------------

-- TABLA VENTA --
CREATE TABLE VENTA
(
  id int not null  identity(1,1) primary key,
  idSUC int not null,
  idCLI int not null,
  idEMP int not null,
  fechaHora datetime not null,
  constraint FK_VENTA_SUCURSAL foreign key (idSUC) references SUCURSAL(id),
  constraint FK_VENTA_CLIENTE foreign key (idCLI) references CLIENTE(id),
  constraint FK_VENTA_EMPLEADO foreign key (idEMP) references EMPLEADO(id)
)
---------------------
  
-- TABLA PROVEEDOR --
CREATE TABLE PROVEEDOR
  (
  id int not null identity(1,1) primary key,
  rut varchar(12) not null,
  idRUB int not null,
  idREG int not null,
  idPRO int not null,
  idCMN int not null,
  nombre varchar(30) not null,
  fechaCreacion date not null,
  direccion varchar(30),
  telefono varchar(20) not null,
  correo varchar(100) not null,
  constraint FK_PROVEEDOR_RUBRO foreign key (idRUB) references RUBRO(id),
  constraint FK_PROVEEDOR_REGION foreign key (idREG) references REGION(id),
  constraint FK_PROVEEDOR_PROVINCIA foreign key (idPRO) references PROVINCIA(id),
  constraint FK_PROVEEDOR_COMUNA foreign key (idCMN) references COMUNA(id)
  )
---------------------
  
-- TABLA STOCK COMIC --
CREATE TABLE STOCK_COMIC
(
  id int not null identity(1,1) primary key,
  idSUC int not null,
  idCOM int not null,
  cantidad int not null,
  fecha date not null,
  hora time not null,
  tipoTransaccion int not null,
  constraint FK_STOCK_COMIC_SUCURSAL foreign key (idSUC) references SUCURSAL(id),
  constraint FK_STOCK_COMIC_COMIC foreign key (idCOM) references COMIC(id)
)
---------------------
  
-- TABLA INSUMO --
CREATE TABLE INSUMO
  (
  id int not null identity(1,1) primary key,
  idRUB int not null,
  nombre varchar(30) not null,
  descripcion varchar(100) not null,
  constraint FK_INSUMO_RUBRO foreign key (idRUB) references RUBRO(id)
  )
---------------------
  
-- TABLA STOCK INSUMO --
CREATE TABLE STOCK_INSUMO
  (
  id int not null identity(1,1) primary key,
  idINS int not null,
  idSUC int not null,
  cantidad int not null,
  fecha date not null,
  hora time not null,
  tipoTransaccion int not null,
  constraint FK_STOCK_INSUMO_INSUMO foreign key (idINS) references INSUMO(id),
  constraint FK_STOCK_INSUMO_SUCURSAL foreign key (idSUC) references SUCURSAL(id)
  )
---------------------
  
-- TABLA ORDEN COMPRA --
CREATE TABLE ORDEN_COMPRA
  (
  id int not null identity(1,1) primary key,
  idSUC int not null,
  idPRV int not null,
  estado int not null,
  fechaHora datetime not null,
  constraint FK_ORDEN_COMPRA_SUCURSAL foreign key (idSUC) references SUCURSAL(id),
  constraint FK_ORDEN_COMPRA_PROVEEDOR foreign key (idPRV) references PROVEEDOR(id)
  )
---------------------

-- TABLA DETALLE_OC --
CREATE TABLE DETALLE_OC
(
  id int not null identity(1,1) primary key,
  idINS int not null,
  idOC int not null,
  cantidad int not null,
  precioUnit decimal not null,
  precioTotal decimal not null,
  constraint FK_DETALLE_OC_INSUMO foreign key (idINS) references INSUMO(id),
  constraint FK_DETALLE_OC_OC foreign key (idOC) references ORDEN_COMPRA(id)
)
---------------------
  
-- TABLA DETALLE VENTA --
CREATE TABLE DETALLE_VENTA
(
  id int not null identity(1,1) primary key,
  idVEN int not null,
  idCOM int not null,
  cantidad int not null,
  precioUnit decimal not null,
  precioTotal decimal not null,
  constraint FK_DETALLE_VENTA_VENTA foreign key (idVEN) references VENTA(id),
  constraint FK_DETALLE_VENTA_COMIC foreign key (idCOM) references COMIC(id)
);
---------------------
  
-- TABLA PRECIO SUCURSAL --
CREATE TABLE PRECIO_SUCURSAL
(
  id int not null identity(1,1) primary key, 
  idSUC int not null,
  idCOM int not null,
  normal decimal not null,
  alMayor decimal not null,
  oferta decimal null,
  constraint FK_PRECIO_SUCURSAL_SUCURSAL foreign key (idSUC) references SUCURSAL(id),
  constraint FK_PRECIO_SUCURSAL_COMIC foreign key (idCOM) references COMIC(id),)
---------------------

-- TABLA RECEPCION ORDEN DE COMPRA --
CREATE TABLE RECEPCION_OC
(
  id int not null identity(1,1) primary key,
  idOC int not null,
  fecha date not null,
  hora time not null,
  constraint FK_RECEPCION_OC_OC foreign key (idOC) references ORDEN_COMPRA(id)
)
---------------------

-- TABLA DETALLE RECEPCION ORDEN DE COMPRA --
CREATE TABLE DETALLE_RECEPCION_OC
(
  id int not null identity(1,1) primary key,
  idINS int not null,
  idRO int not null,
  cantidad int not null,
  constraint FK_DETALLE_RECEPCION_OC_INSUMO foreign key (idINS) references INSUMO(id),
  constraint FK_DETALLE_RECEPCION_OC_RECEPCION_OC foreign key (idRO) references RECEPCION_OC(id)
)
---------------------
