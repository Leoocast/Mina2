# Host: 127.0.0.1  (Version 5.1.50-community)
# Date: 2018-01-14 14:47:06
# Generator: MySQL-Front 6.0  (Build 2.20)


#
# Structure for table "categorias"
#

DROP TABLE IF EXISTS `categorias`;
CREATE TABLE `categorias` (
  `idcategoria` bigint(20) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`idcategoria`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "categorias"
#


#
# Structure for table "permisos"
#

DROP TABLE IF EXISTS `permisos`;
CREATE TABLE `permisos` (
  `id_permisos` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_permisos`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

#
# Data for table "permisos"
#

INSERT INTO `permisos` VALUES (1,'Administrador'),(2,'Gerente'),(3,'Empleado');

#
# Structure for table "permisos_denegados"
#

DROP TABLE IF EXISTS `permisos_denegados`;
CREATE TABLE `permisos_denegados` (
  `id_permneg` int(11) NOT NULL AUTO_INCREMENT,
  `id_rolf` bigint(20) DEFAULT NULL,
  `id_permisosf` bigint(1) DEFAULT NULL,
  PRIMARY KEY (`id_permneg`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

#
# Data for table "permisos_denegados"
#

INSERT INTO `permisos_denegados` VALUES (1,2,1),(2,3,2),(3,3,1);

#
# Structure for table "proveedores"
#

DROP TABLE IF EXISTS `proveedores`;
CREATE TABLE `proveedores` (
  `idproveedor` bigint(20) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(60) NOT NULL DEFAULT '0',
  `direccion` varchar(60) NOT NULL DEFAULT '0',
  `ciudad` varchar(30) NOT NULL DEFAULT '0',
  `estado` varchar(20) NOT NULL DEFAULT '0',
  `telefono` varchar(15) NOT NULL DEFAULT '0',
  `extencion` int(11) NOT NULL DEFAULT '0',
  `repre` varchar(60) NOT NULL DEFAULT '0',
  `emailrepre` varchar(50) NOT NULL DEFAULT '0',
  `telrepre` varchar(15) NOT NULL DEFAULT '0',
  `status` varchar(20) NOT NULL DEFAULT '0',
  `idcategoria` bigint(20) NOT NULL DEFAULT '0',
  `id_usuariof` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`idproveedor`),
  KEY `idcategoriaf` (`idcategoria`),
  CONSTRAINT `idcategoriaf` FOREIGN KEY (`idcategoria`) REFERENCES `categorias` (`idcategoria`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "proveedores"
#


#
# Structure for table "productos"
#

DROP TABLE IF EXISTS `productos`;
CREATE TABLE `productos` (
  `idproductos` bigint(20) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `descripcion` varchar(50) NOT NULL,
  `tiemporesp` varchar(50) NOT NULL,
  `capacidadprod` varchar(50) NOT NULL,
  `lugarentrega` varchar(50) NOT NULL,
  `idproveedorf` bigint(20) NOT NULL,
  PRIMARY KEY (`idproductos`),
  KEY `idproveedorf` (`idproveedorf`),
  CONSTRAINT `idproveedorf` FOREIGN KEY (`idproveedorf`) REFERENCES `proveedores` (`idproveedor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "productos"
#


#
# Structure for table "roles"
#

DROP TABLE IF EXISTS `roles`;
CREATE TABLE `roles` (
  `id_rol` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id_rol`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

#
# Data for table "roles"
#

INSERT INTO `roles` VALUES (1,'Administrador'),(2,'Gerente'),(3,'Empleado'),(4,'Otro');

#
# Structure for table "solicita"
#

DROP TABLE IF EXISTS `solicita`;
CREATE TABLE `solicita` (
  `idsolicita` bigint(20) NOT NULL AUTO_INCREMENT,
  `comnt` varchar(80) NOT NULL DEFAULT '0',
  `idproveedorf2` bigint(20) NOT NULL DEFAULT '0',
  `idusuariof` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idsolicita`),
  KEY `idproveedorf2` (`idproveedorf2`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "solicita"
#


#
# Structure for table "usuarios"
#

DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE `usuarios` (
  `id_us` bigint(20) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(60) NOT NULL,
  `cuenta` varchar(20) NOT NULL,
  `clave` varchar(128) NOT NULL,
  `status` varchar(20) DEFAULT NULL,
  `id_rolf` varchar(20) NOT NULL DEFAULT '',
  PRIMARY KEY (`id_us`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

#
# Data for table "usuarios"
#

INSERT INTO `usuarios` VALUES (1,'asd','asd','1e48c4420b7073bc11916c6c1de226bb','Activo','1'),(2,'nombre','cuenta','d9b1d7db4cd6e70935368a1efb10e377','Activo','1'),(3,'Empleado','empleado','202cb962ac59075b964b07152d234b70','Activo','3'),(4,'eva','eva2','202cb962ac59075b964b07152d234b70','Activo','1'),(5,'Gerente','gerente','202cb962ac59075b964b07152d234b70','Activo','2'),(6,'Hermelindo Gomez','herme','202cb962ac59075b964b07152d234b70','Activo','1'),(7,'Leo Castellanos','leo','202cb962ac59075b964b07152d234b70','Activo','1'),(8,'Miguel Valencia','mike','202cb962ac59075b964b07152d234b70','Desactivado','1'),(10,'Santiago Rivera','santi','202cb962ac59075b964b07152d234b70','Activo','1'),(11,'Suker','suker','','Activo','1');
