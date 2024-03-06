-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: prueba
-- ------------------------------------------------------
-- Server version	8.0.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `asignaciontecnico`
--

DROP TABLE IF EXISTS `asignaciontecnico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `asignaciontecnico` (
  `idAsignacion` int NOT NULL,
  `autoCliente` int NOT NULL,
  `tecnico` int NOT NULL,
  `extra` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`idAsignacion`),
  KEY `tecnicotrabajo_idx` (`tecnico`),
  KEY `autotecnico_idx` (`autoCliente`),
  CONSTRAINT `autotecnico` FOREIGN KEY (`autoCliente`) REFERENCES `entradaauto` (`idEntradaAuto`),
  CONSTRAINT `tecnicotrabajo` FOREIGN KEY (`tecnico`) REFERENCES `tecnico` (`idTecnico`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asignaciontecnico`
--

LOCK TABLES `asignaciontecnico` WRITE;
/*!40000 ALTER TABLE `asignaciontecnico` DISABLE KEYS */;
/*!40000 ALTER TABLE `asignaciontecnico` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `automovil`
--

DROP TABLE IF EXISTS `automovil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `automovil` (
  `Id_Auto` int NOT NULL AUTO_INCREMENT,
  `Modelo` varchar(110) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `marca` int NOT NULL,
  `año` int NOT NULL,
  `color` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `placas` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `estado` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id_Auto`),
  KEY `FK_marcaAutomovil_idx` (`marca`),
  CONSTRAINT `FK_marcaAutomovil` FOREIGN KEY (`marca`) REFERENCES `marca` (`Id_marca`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `automovil`
--

LOCK TABLES `automovil` WRITE;
/*!40000 ALTER TABLE `automovil` DISABLE KEYS */;
INSERT INTO `automovil` VALUES (1,'A1',2,2020,'Blanco','ADW353','Puebla'),(2,'Gold',2,2020,'Rojo','HSY362','Puebla'),(3,'Fit',7,2020,'Gris','AGD334','Puebla'),(4,'Swift',10,2022,'Amarillo','BDB230','Tlaxcala'),(5,'Corolla',6,2021,'Blanco','IOI232','Puebla'),(6,'M3',4,2022,'Azul','AER221','Puebla'),(7,'GT',1,1999,'Azul','OQE120','CDMX'),(8,'Yaris',6,2018,'Negro','JAS764','Puebla'),(9,'Rio',5,2021,'Blanco','OWN234','Puebla'),(10,'Focus-',1,2020,'Rojo','SJN638','Monterrey');
/*!40000 ALTER TABLE `automovil` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cliente`
--

DROP TABLE IF EXISTS `cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cliente` (
  `Id_Cliente` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `App` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Apm` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Celular` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `TelOficina` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `CorreoPer` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `CorreoCorp` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id_Cliente`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cliente`
--

LOCK TABLES `cliente` WRITE;
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` VALUES (1,'Osvaldo','González','Rojas','2215582358','2215582358','grosva@gmail.com','utp0158094@alumno.utpuebla.edu..mx'),(2,'Ashly','Ines','Bairan','221445345','224353545','ashly@gmail.com','aashly@gmail.com'),(3,'Juan Carlos','Gonzalez','Sandoval','2222443322','9988776655','juan@gmail.com','utp0156019@alumno.utpuebla.edu.mx'),(4,'Victor','Lopez','Solares','2244881122','9945673289','victor@gmail.com','utp0124328@alumno.utpuebla.edu.mx'),(5,'Daniel Arturo','Romano','Fuentes','2299785912','9283894223','daniel@gmail.com','utp1203492@alumno.utpuebla.edu.mx'),(6,'Alan Gabriel','Flores','Hernandez','2386277452','0123948213','alan@gmail.com','utp0912421@alumno.utpuebla.edu.mx'),(7,'Benjamin ','Figueroa','Mora','2034910234','1234234222','benjamin@gmail.com','utp0123421@alumno.utpuebla.edu.mx'),(8,'Diego','Lopez','Lujan','2234212342','2298839409','diego@gmail.com','utp1236968@alumno.utpuebla.edu.mx'),(9,'Yael','Gil','Castillo','2233638699','2299680002','yael@gmail.com','utp1234233@alumno.utpuebla.edu.mx'),(10,'Norma','Vargas','Bravo','2289840029','2929348885','norma@gmail.com','utp0124588@alumno.utpuebla.edu.mx'),(11,'Norma Fabiola','Vargas','Vargas','2211949400','2234290311','norma.fabiola@gmail.com','teneco@gmail.com');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `diagnostico`
--

DROP TABLE IF EXISTS `diagnostico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `diagnostico` (
  `iddiagnostico` int NOT NULL,
  `Diagnostico` varchar(350) NOT NULL,
  `Refacciones` varchar(350) DEFAULT NULL,
  `Fecha` date NOT NULL,
  `Garantia` varchar(100) DEFAULT NULL,
  `extra` varchar(150) DEFAULT NULL,
  `asignacionid` int NOT NULL,
  PRIMARY KEY (`iddiagnostico`),
  KEY `AsignacionDiagnostico_idx` (`asignacionid`),
  CONSTRAINT `AsignacionTecnico` FOREIGN KEY (`asignacionid`) REFERENCES `asignaciontecnico` (`idAsignacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `diagnostico`
--

LOCK TABLES `diagnostico` WRITE;
/*!40000 ALTER TABLE `diagnostico` DISABLE KEYS */;
/*!40000 ALTER TABLE `diagnostico` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `entradaauto`
--

DROP TABLE IF EXISTS `entradaauto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `entradaauto` (
  `idEntradaAuto` int NOT NULL AUTO_INCREMENT,
  `cliente` int NOT NULL,
  `auto` int NOT NULL,
  `fecha` date NOT NULL,
  `Falla` varchar(255) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `extra` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  PRIMARY KEY (`idEntradaAuto`),
  KEY `FK_EntradaAutomovil_idx` (`auto`),
  KEY `FK_EntradaCliente_idx` (`cliente`),
  CONSTRAINT `FK_EntradaAutomovil` FOREIGN KEY (`auto`) REFERENCES `automovil` (`Id_Auto`),
  CONSTRAINT `FK_EntradaCliente` FOREIGN KEY (`cliente`) REFERENCES `cliente` (`Id_Cliente`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `entradaauto`
--

LOCK TABLES `entradaauto` WRITE;
/*!40000 ALTER TABLE `entradaauto` DISABLE KEYS */;
INSERT INTO `entradaauto` VALUES (1,2,2,'2022-10-22',NULL,'N'),(2,3,1,'2024-01-01',NULL,NULL),(3,4,3,'2020-05-25',NULL,NULL),(4,4,3,'2021-06-27',NULL,NULL),(5,10,10,'2023-06-12',NULL,NULL),(6,9,6,'2022-07-04',NULL,NULL),(7,8,5,'2023-01-19',NULL,NULL),(8,6,7,'2024-01-10',NULL,NULL),(9,7,4,'2019-07-16',NULL,''),(10,5,8,'2022-12-12',NULL,'-');
/*!40000 ALTER TABLE `entradaauto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `marca`
--

DROP TABLE IF EXISTS `marca`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `marca` (
  `Id_marca` int NOT NULL AUTO_INCREMENT,
  `Marca` varchar(120) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`Id_marca`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `marca`
--

LOCK TABLES `marca` WRITE;
/*!40000 ALTER TABLE `marca` DISABLE KEYS */;
INSERT INTO `marca` VALUES (1,'Ford'),(2,'Audi'),(3,'Nissan'),(4,'BMW'),(5,'KIA'),(6,'Toyota'),(7,'Honda'),(8,'Aston Martin'),(9,'Mercedes Benz'),(10,'Suzuki');
/*!40000 ALTER TABLE `marca` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tecnico`
--

DROP TABLE IF EXISTS `tecnico`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tecnico` (
  `idTecnico` int NOT NULL,
  `Nombre` varchar(150) NOT NULL,
  `App` varchar(150) NOT NULL,
  `Apm` varchar(150) NOT NULL,
  `Celular` varchar(20) NOT NULL,
  `Correo` varchar(250) NOT NULL,
  `Especialidad` varchar(250) NOT NULL,
  `Extra` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`idTecnico`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tecnico`
--

LOCK TABLES `tecnico` WRITE;
/*!40000 ALTER TABLE `tecnico` DISABLE KEYS */;
/*!40000 ALTER TABLE `tecnico` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-31 20:44:59
