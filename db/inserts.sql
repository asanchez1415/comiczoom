use [comiczoom]
go
INSERT INTO REGION (nombre)
VALUES
	('Arica y Parinacota'),
	('Tarapac�'),
	('Antofagasta'),
	('Atacama'),
	('Coquimbo'),
	('Valparaiso'),
	('Metropolitana'),
	('O''Higgins'),
	('Maule'),
	('�uble'),
	('Biob�o'),
	('La Araucan�a'),
	('Los R�os'),
	('Los Lagos'),
	('Ays�n'),
	('Magallanes');

	INSERT INTO PROVINCIA (nombre, idREG)
VALUES
	('Arica',1),
	('Parinacota',1),
	('Iquique',2),
	('El Tamarugal',2),
	('Tocopilla',3),
	('El Loa',3),
	('Antofagasta',3),
	('Cha�aral',4),
	('Copiap�',4),
	('Huasco',4),
	('Elqui',5),
	('Limar�',5),
	('Choapa',5),
 	('Petorca',6),
	('Los Andes',6),
 	('San Felipe de Aconcagua',6),
 	('Quillota',6),
	('Valparaiso',6),
	('San Antonio',6),
	('Isla de Pascua',6),
	('Marga Marga',6),
	('Chacabuco',7),
	('Santiago',7),
	('Cordillera',7),
	('Maipo',7),
	('Melipilla',7),
	('Talagante',7),
	('Cachapoal',8),
	('Colchagua',8),
	('Cardenal Caro',8),
	('Curic�',9),
	('Talca',9),
 	('Linares',9),
	('Cauquenes',9),
	('Diguill�n',10),
	('Itata',10),
	('Punilla',10),
	('Bio B�o',11),
	('Concepci�n',11),
	('Arauco',11),
	('Malleco',12),
	('Caut�n',12),
	('Valdivia',13),
	('Ranco',13),
	('Osorno',14),
	('Llanquihue',14),
	('Chilo�',14),
	('Palena',14),
	('Coyhaique',15),
	('Ays�n',15),
	('General Carrera',15),
	('Capit�n Prat',15),
	('�ltima Esperanza',16),
	('Magallanes',16),
	('Tierra del Fuego',16),
	('Ant�rtica Chilena',16);


	INSERT INTO COMUNA (nombre, idPRO)
VALUES
	('Arica',1),
	('Camarones',1),
	('General Lagos',2),
	('Putre',2),
	('Alto Hospicio',3),
	('Iquique',3),
	('Cami�a',4),
	('Colchane',4),
	('Huara',4),
	('Pica',4),
	('Pozo Almonte',4),
  ('Tocopilla',5),
  ('Mar�a Elena',5),
	('Calama',6),
	('Ollague',6),
	('San Pedro de Atacama',6),
  ('Antofagasta',7),
	('Mejillones',7),
	('Sierra Gorda',7),
	('Taltal',7),
	('Cha�aral',8),
	('Diego de Almagro',8),
  ('Copiap�',9),
	('Caldera',9),
	('Tierra Amarilla',9),
  ('Vallenar',10),
	('Alto del Carmen',10),
	('Freirina',10),
	('Huasco',10),
	('La Serena',11),
  ('Coquimbo',11),
  ('Andacollo',11),
  ('La Higuera',11),
  ('Paihuano',11),
	('Vicu�a',11),
	('Ovalle',12),
  ('Combarbal�',12),
  ('Monte Patria',12),
  ('Punitaqui',12),
	('R�o Hurtado',12),
	('Illapel',13),
	('Canela',13),
	('Los Vilos',13),
	('Salamanca',13),
	('La Ligua',14),
  ('Cabildo',14),
	('Zapallar',14),
  ('Papudo',14),
	('Petorca',14),
	('Los Andes',15),
	('San Esteban',15),
  ('Calle Larga',15),
  ('Rinconada',15),
	('San Felipe',16),
  ('Llaillay',16),
  ('Putaendo',16),
	('Santa Mar�a',16),
	('Catemu',16),
	('Panquehue',16),
  ('Quillota',17),
  ('La Cruz',17),
	('La Calera',17),
	('Nogales',17),
  ('Hijuelas',17),
	('Valpara�so',18),	
  ('Vi�a del Mar',18),
	('Conc�n',18),
 	('Quintero',18),
  ('Puchuncav�',18),
	('Casablanca',18),
	('Juan Fern�ndez',18),
	('San Antonio',19),
  ('Cartagena',19),
	('El Tabo',19),
	('El Quisco',19),
	('Algarrobo',19),
	('Santo Domingo',19),
	('Isla de Pascua',20),
	('Quilpu�',21),
	('Limache',21),
	('Olmu�',21),
	('Villa Alemana',21),
	('Colina',22),
	('Lampa',22),
	('Tiltil',22),
	('Santiago',23),
	('Vitacura',23),
  ('San Ram�n',23),
	('San Miguel',23),
	('San Joaqu�n',23),
  ('Renca',23),
	('Recoleta',23),
  ('Quinta Normal',23),
	('Quilicura',23),
  ('Pudahuel',23),
  ('Providencia',23),
	('Pe�alol�n',23),
  ('Pedro Aguirre Cerda',23),
	('�u�oa',23),
	('Maip�',23),
	('Macul',23),
	('Lo Prado',23),
	('Lo Espejo',23),
	('Lo Barnechea',23),
	('Las Condes',23),
	('La Reina',23),
	('La Pintana',23),
	('La Granja',23),
	('La Florida',23),
  ('La Cisterna',23),
  ('Independencia',23),
  ('Huechuraba',23),
	('Estaci�n Central',23),
  ('El Bosque',23),
  ('Conchal�',23),
  ('Cerro Navia',23),
  ('Cerrillos',23),
	('Puente Alto',24),
	('San Jos� de Maipo',24),
  ('Pirque',24),
	('San Bernardo',25),
	('Buin',25),
  ('Paine',25),
	('Calera de Tango',25),
	('Melipilla',26),
	('Alhu�',26),
	('Curacav�',26),
	('Mar�a Pinto',26),
	('San Pedro',26),
	('Isla de Maipo',27),
  ('El Monte',27),
	('Padre Hurtado',27),
	('Pe�aflor',27),
	('Talagante',27),
	('Codegua',28),
	('Co�nco',28),
	('Coltauco',28),
	('Do�ihue',28),
	('Graneros',28),
	('Las Cabras',28),
	('Machal�',28),
	('Malloa',28),
	('Mostazal',28),
	('Olivar',28),
	('Peumo',28),
	('Pichidegua',28),
	('Quinta de Tilcoco',28),
	('Rancagua',28),
	('Rengo',28),
	('Requ�noa',28),
	('San Vicente de Tagua Tagua',28),
	('Ch�pica',29),
	('Chimbarongo',29),
	('Lolol',29),
  ('Nancagua',29),
  ('Palmilla',29),
  ('Peralillo',29),
	('Placilla',29),
 	('Pumanque',29),
	('San Fernando',29),
	('Santa Cruz',29),
	('La Estrella',30),
	('Litueche',30),
	('Marchig�e',30),
	('Navidad',30),
	('Paredones',30),
	('Pichilemu',30),
	('Curic�',31),
	('Huala��',31),
	('Licant�n',31),
 	('Molina',31),
	('Rauco',31),
	('Romeral',31),
	('Sagrada Familia',31),
	('Teno',31),
	('Vichuqu�n',31),
	('Talca',32),
	('San Clemente',32),
	('Pelarco',32),
	('Pencahue',32),
	('Maule',32),
	('San Rafael',32),
	('Curepto',33),
	('Constituci�n',32),
	('Empedrado',32),
	('R�o Claro',32),
  ('Linares',33),
	('San Javier',33),
	('Parral',33),
	('Villa Alegre',33),
	('Longav�',33),
	('Colb�n',33),
	('Retiro',33),
	('Yerbas Buenas',33),
  ('Cauquenes',34),
	('Chanco',34),
	('Pelluhue',34),
	('Bulnes',35),
	('Chill�n',35),
	('Chill�n Viejo',35),
	('El Carmen',35),
	('Pemuco',35),
	('Pinto',35),
	('Quill�n',35),
	('San Ignacio',35),
	('Yungay',35),
	('Cobquecura',36),
	('Coelemu',36),
	('Ninhue',36),
	('Portezuelo',36),
	('Quirihue',36),
	('R�nquil',36),
	('Treguaco',36),
	('San Carlos',37),
	('Coihueco',37),
	('San Nicol�s',37),
	('�iqu�n',37),
	('San Fabi�n',37),
	('Alto Biob�o',38),
	('Antuco',38),
	('Cabrero',38),
	('Laja',38),
	('Los �ngeles',38),
	('Mulch�n',38),
	('Nacimiento',38),
	('Negrete',38),
	('Quilaco',38),
	('Quilleco',38),
	('San Rosendo',38),
	('Santa B�rbara',38),
	('Tucapel',38),
	('Yumbel',38),
	('Concepci�n',39),
	('Coronel',39),
	('Chiguayante',39),
	('Florida',39),
	('Hualp�n',39),
	('Hualqui',39),
	('Lota',39),
	('Penco',39),
	('San Pedro de La Paz',39),
	('Santa Juana',39),
	('Talcahuano',39),
	('Tom�',39),
	('Arauco',40),
	('Ca�ete',40),
	('Contulmo',40),
	('Curanilahue',40),
	('Lebu',40),
	('Los �lamos',40),
	('Tir�a',40),
	('Angol',41),
	('Collipulli',41),
	('Curacaut�n',41),
	('Ercilla',41),
	('Lonquimay',41),
	('Los Sauces',41),
	('Lumaco',41),
	('Pur�n',41),
	('Renaico',41),
	('Traigu�n',41),
	('Victoria',41),
	('Temuco',42),
	('Carahue',42),
	('Cholchol',42),
	('Cunco',42),
	('Curarrehue',42),
	('Freire',42),
	('Galvarino',42),
	('Gorbea',42),
	('Lautaro',42),
	('Loncoche',42),
	('Melipeuco',42),
	('Nueva Imperial',42),
	('Padre Las Casas',42),
	('Perquenco',42),
	('Pitrufqu�n',42),
	('Puc�n',42),
	('Saavedra',42),
	('Teodoro Schmidt',42),
	('Tolt�n',42),
	('Vilc�n',42),
	('Villarrica',42),
	('Valdivia',43),
	('Corral',43),
	('Lanco',43),
	('Los Lagos',43),
	('M�fil',43),
	('Mariquina',43),
	('Paillaco',43),
	('Panguipulli',43),
	('La Uni�n',44),
	('Futrono',44),
	('Lago Ranco',44),
	('R�o Bueno',44),
	('Osorno',45),
	('Puerto Octay',45),
	('Purranque',45),
	('Puyehue',45),
	('R�o Negro',45),
	('San Juan de la Costa',45),
	('San Pablo',45),
	('Calbuco',46),
	('Cocham�',46),
	('Fresia',46),
	('Frutillar',46),
	('Llanquihue',46),
	('Los Muermos',46),
	('Maull�n',46),
	('Puerto Montt',46),
	('Puerto Varas',46),
	('Ancud',47),
	('Castro',47),
	('Chonchi',47),
	('Curaco de V�lez',47),
	('Dalcahue',47),
	('Puqueld�n',47),
	('Queil�n',47),
	('Quell�n',47),
	('Quemchi',47),
	('Quinchao',47),
	('Chait�n',48),
	('Futaleuf�',48),
	('Hualaihu�',48),
	('Palena',48),
	('Lago Verde',49),
	('Coihaique',49),
	('Ays�n',50),
	('Cisnes',50),
	('Guaitecas',50),
	('R�o Ib��ez',51),
	('Chile Chico',51),
	('Cochrane',52),
	('O''Higgins',52),
	('Tortel',52),
	('Natales',53),
	('Torres del Paine',53),
	('Laguna Blanca',54),
	('Punta Arenas',54),
	('R�o Verde',54),
	('San Gregorio',54),
	('Porvenir',55),
	('Primavera',55),
	('Timaukel',55),
	('Cabo de Hornos',56),
	('Ant�rtica',56);

INSERT INTO TIPO_EMPLEADO (nombre) 
VALUES
('Administrador'),
('Vendedor'),
('Dibujante'),
('Guionista'),
('Pintor'),
('Editor');

INSERT INTO SUCURSAL (idREG, idPRO, idCMN, nombre, direccion) 
VALUES
(7, 3, 99, 'Sede Santiago', 'Calle, 1234'),
(8, 28, 148, 'Sede Rancagua', 'Calle, 5678'),
(6, 18, 65, 'Sede Valparaiso', 'Calle, 69420'), 
(12, 42, 263, 'Sede Temuco', 'Calle, 67343');


INSERT INTO EMPLEADO(idREG,	idPRO,	idCMN,	idSUC,	idTE,	rut, nombre, segNombre,	apellido, segApellido, telefono, correo, contrasenia, direccion) 
VALUES
(7, 3, 98, 1, 1, '12123123-2', 'Juan', '', 'D�az', 'Rosales', '56912341234', 'a@gmail.com','1234', 'Calle 1234'),
(7, 3, 99, 1, 2, '18123123-2', 'Diego', 'Pedro', 'Portales', 'Zacar�as', '56912341234', 'a@gmail.com', '12345', 'Calle 1234');

-- RUBRO --
INSERT INTO RUBRO(nombre)
VALUES
('Reproducir textos e im�genes sobre el papel, u otros materiales.'),
('Venta de material escolar, de oficina y de papeler�a.'),
('Fabricaci�n de tintas de imprenta y masillas.');

-- COMIC --
INSERT INTO COMIC(nombre, volumen, estado, isbn, categoria, fechaCreacion) --(en desarrollo (0), en venta(1), descontinuado(2))--
VALUES
('La guerra al estrellato', 25, 1, 0133203472036, 'Aventura', '2021-07-05'),
('El gato de Valparaiso', 17, 1, 0443274888033, 'Superh�roes', '2021-08-20'),
('Ring King', 103, 0, 8300952953167, 'Boxeo', '2021-09-15'),
('Amores de mercado', 2, 0, 8300952953167, 'Romance', '2002-08-06');

-- CLIENTE --
INSERT INTO CLIENTE(idREG,idPRO,idCMN,nombre,segNombre,apellido,segApellido,rut,tipo,direccion,telefono)
VALUES
(7,3,98,'Fernando','Alejandro','Veroiza','Pe�a','115674906',0,'Calle 512','56967543324'),
(7,3,99,'Antonio','Lucas','Garcia','Sepulveda','176542780',1,'Calle 602','56939576234');
--Persona = 0; Empresa = 1--

-- EQUIPO_COMIC --
INSERT INTO EQUIPO_COMIC(idCOM, fechaCreacion)
VALUES
(1, '2021-02-14'),
(2, '2021-01-07'),
(3, '2021-04-23');

-- EMPLEADO_EQUIPO_COMIC --
INSERT INTO EMPLEADO_EQUIPO_COMIC(idEMP, idEC, roleq, fechaCreacion)
VALUES
(1, 1, 'Dibujante', '2021-02-03'),
(2, 1, 'Dibujante', '2021-04-29'),
(2, 2, 'Editor', '2021-05-20'),
(1, 3, 'Pintor', '2021-11-25');

-- TIRAJE --
INSERT INTO TIRAJE(idSUC, estado, fecha, hora) --tiraje recibido: 1, tiraje en proceso: 2, tiraje sin recibir: 0
VALUES
(1, 1, '2021-02-07', '08:23'),
(1, 2, '2021-02-09', '08:59'),
(1, 0, '2021-03-02', '05:43');

---------------------------------------------------------------------------
INSERT INTO DETALLE_TIRAJE(idTIR, idCOM, cantidad, precioUnit, precioTotal)
VALUES
(1, 1, 100, 3000.0,300000.0),
(1, 2, 150, 3000.0,450000.0),
(1, 3, 95, 3500.0,285000.0),
(2, 1, 45, 3000.0,135000.0),
(3, 1, 20, 3000.0,60000.0);

---------------------------------------------------------------------------
INSERT INTO RECEPCION_TIRAJE(idTIR, fecha, hora)
VALUES
(1, '2021-03-31', '10:38'),
(2, '2021-04-20', '9:46'),
(2, '2021-04-23', '10:56');

---------------------------------------------------------------------------
INSERT INTO DETALLE_RECEPCION_TIRAJE(idRT, idCOM, cantidad)
VALUES
(1, 1, 50),
(1, 2, 75),
(1, 3, 45),
(2, 1, 25),
(3, 1, 25);

INSERT INTO VENTA(idSUC,idCLI,idEMP,fechaHora)
VALUES
  (1,1,1,'20210513 11:30:02 AM'),
  (1,2,1,'20210222 05:30:02 PM'),
  (1,2,2,'20210327 10:00:02 AM');

INSERT INTO DETALLE_VENTA(idVEN,idCOM,cantidad,precioUnit,precioTotal)
VALUES
(1,4,20,7200.0,144000.0),
(2,3,35,5500.0,192500.0);

INSERT INTO PROVEEDOR(rut, idRUB, idREG, idPRO, idCMN, nombre, fechaCreacion, direccion, telefono, correo)
VALUES
  ('73111111-2', 2, 7, 26, 125, 'LA PAPELERA S.A.', '2010-03-18', 'Calle 1234', '+56912341234', 'info@lapapelera.com'),
  ('72111111-3', 3, 7, 25, 121, 'TINTAS CALAMAR', '2012-03-05', 'Calle 1234', '+56912341234', 'contacto@tintascal.com' ),
  ('71111111-4', 1, 7, 27, 133, 'DON IMPRESION LTD.', '2012-05-15', 'Calle 1234', '+56912341234', 'info@gmail.com'),
  ('76111111-5', 1, 8, 30, 165, 'LA IMPRENTA S.A.', '2013-10-04', 'Calle 1234', '+56912341234', 'contacto@laimprenta.com'),
  ('78111111-6', 3, 8, 28, 148, 'MUNDO COLOR LTD.', '2014-09-15', 'Calle 1234', '+56912341234', 'contacto@mundocolor.com'),
  ('70111111-7', 2, 8, 29, 153, 'CASA DE PAPEL', '2015-11-17', 'Calle 1234', '+56912341234', 'ventas@casapapel.com'),
  ('71111111-8', 3, 6, 18, 65, 'INK HOUSE', '2016-09-16', 'Calle 1234', '+56912341234', 'info@ink.com'),
  ('72111113-9', 1, 6, 17, 62, 'PLANETA IMPRESIONES', '2017-02-24', 'Calle 1234', '+56912341234', 'ventas@planetaimp.com'),
  ('78111891-9', 2, 6, 21, 81, 'PAPELERA ATLANTICA', '2018-06-28', 'Calle 1234', '+56912341234', 'info@papatlantica.com'),
  ('72111111-6', 2, 12, 41, 254, 'PAPELES DEL BOSQUE S.A.', '2018-11-27', 'Calle 1234', '+56912341234', 'contacto@papelesbosque.com'),
  ('73111111-4', 1, 12, 41, 253, 'MARCAHISTORIAS LTD', '2019-08-22', 'Calle 1234', '+56912341234', 'ventas@marcahistorias.com'),
  ('72111123/3', 3, 12, 42, 283, 'EL TINTERO AMIGABLE', '2020-11-16', 'Calle 1234', '+56912341234', 'ventas@tinteroamigable.com');

INSERT INTO STOCK_COMIC(idSUC, idCOM, cantidad, fecha, hora, tipoTransaccion)
VALUES
  (1, 1, 54, '2022-03-11', '10:30', 0),
  (1, 2, 56, '2022-03-15', '20:20', 0),
  (1, 2, 46, '2022-03-15', '20:30', 1),
  (1, 3, 65, '2022-03-17', '11:45', 0),
  (1, 3, 57, '2022-03-17', '11:45', 1),
  (1, 4, 34, '2022-03-21', '13:00', 0),
  (2, 1, 92, '2022-03-24', '14:20', 0),
  (2, 1, 65, '2022-03-24', '14:30', 1),
  (2, 2, 43, '2022-03-25', '08:45', 0),
  (2, 3, 87, '2022-03-29', '13:20', 0),
  (2, 3, 56, '2022-03-29', '13:30', 1),
  (2, 4, 35, '2022-04-06', '21:00', 0),
  (3, 1, 70, '2022-04-18', '08:15', 0),
  (3, 1, 67, '2022-04-18', '08:15', 1),
  (3, 2, 43, '2022-04-25', '13:45', 0),
  (3, 3, 23, '2022-04-28', '10:15', 0),
  (3, 4, 20, '2022-04-29', '19:45', 0),
  (3, 4, 12, '2022-04-29', '19:45', 1),
  (4, 1, 75, '2022-05-02', '11:00', 0),
  (4, 2, 65, '2022-05-04', '14:00', 0),
  (4, 2, 45, '2022-05-04', '14:00', 1),
  (4, 3, 63, '2022-05-06', '16:45', 0),
  (4, 4, 55, '2022-05-13', '12:30', 0);

INSERT INTO INSUMO(idRUB, nombre, descripcion)
VALUES
  (1, 'IMPRESORA', 'Impresora laser para la produccion de documentos.'),
  (2, 'PAPEL COUCHE', 'Papel para la ilustracion de comics.'),
  (3, 'TINTA NEGRA', 'Tinta para el dibujo de comics.'),
  (3, 'SET DE PINTURA', 'Pintura para el coloreado de comics.');

INSERT INTO STOCK_INSUMO(idSUC, idINS, cantidad, fecha, hora, tipoTransaccion)
VALUES
  (1, 1, 54, '2022-03-11', '10:30', 0),
  (1, 2, 56, '2022-03-15', '20:30', 0),
  (1, 2, 46, '2022-03-15', '21:30', 1),
  (1, 3, 63, '2022-03-17', '11:50', 0),
  (1, 3, 57, '2022-03-17', '11:45', 1),
  (1, 4, 34, '2022-03-21', '13:00', 0),
  (2, 1, 72, '2022-03-24', '14:30', 0),
  (2, 1, 65, '2022-03-24', '14:30', 1),
  (2, 2, 43, '2022-03-25', '08:45', 0),
  (2, 3, 80, '2022-03-29', '13:45', 0),
  (2, 3, 56, '2022-03-29', '13:30', 1),
  (2, 4, 35, '2022-04-06', '21:00', 0),
  (3, 1, 100, '2022-04-18', '08:10', 0),
  (3, 1, 67, '2022-04-18', '08:15', 1),
  (3, 2, 43, '2022-04-25', '13:45', 0),
  (3, 3, 23, '2022-04-28', '10:15', 0),
  (3, 4, 37, '2022-04-29', '19:45', 0),
  (3, 4, 12, '2022-04-29', '19:45', 1),
  (4, 1, 75, '2022-05-02', '11:00', 0),
  (4, 2, 69, '2022-05-04', '14:00', 0),
  (4, 2, 45, '2022-05-04', '14:00', 1),
  (4, 3, 63, '2022-05-06', '16:45', 0),
  (4, 4, 55, '2022-05-13', '12:30', 0);

INSERT INTO ORDEN_COMPRA(idSUC, idPRV, estado, fechaHora)
VALUES
  (1, 2, 2, '20220324 12:30:09 PM'),
  (1, 3, 2, '20220406 14:00:20 PM');
---------------------------------------------------------------------------
INSERT INTO DETALLE_OC(idINS, idOC, cantidad, precioUnit, precioTotal)
VALUES
  (4, 1, 10, 6000.0, 60000.0),
  (1, 1, 4, 55000.0, 220000.0),
  (3, 2, 7, 4500.0, 31500.0),
  (1, 2, 3, 60000.0, 180000.0),
  (2, 2, 8, 3500.0, 28000.0);
---------------------------------------------------------------------------
INSERT INTO RECEPCION_OC(idOC, fecha, hora)
VALUES
  (1,'2022-03-24', '12:30'),
  (2, '2022-04-06', '14:00'),
  (2, '2022-04-28', '19:45');
---------------------------------------------------------------------------
INSERT INTO DETALLE_RECEPCION_OC(idRO, idINS, cantidad)
VALUES
  (1, 4, 10),
  (1, 1, 4),
  (2, 3, 4),
  (2, 1, 1),
  (2, 2, 4),
  (3, 3, 3),
  (3, 1, 2),
  (3, 2, 4);

INSERT INTO PRECIO_SUCURSAL(idSUC,idCOM,normal,alMayor,oferta)
VALUES
(1,1,8500,20000,6700),
(1,2,8500,20000,6700),
(1,3,8500,20000,6700),
(1,4,8500,20000,6700),
(2,1,7000,26000,6500),
(2,2,7000,26000,6500),
(2,3,7000,26000,6500),
(2,4,7000,26000,6500),
(3,1,7000,26000,6500),
(3,2,7000,26000,6500),
(3,3,7000,26000,6500),
(3,4,7000,26000,6500),
(4,1,7000,26000,6500),
(4,2,7000,26000,6500),
(4,3,7000,26000,6500),
(4,4,7000,26000,6500);