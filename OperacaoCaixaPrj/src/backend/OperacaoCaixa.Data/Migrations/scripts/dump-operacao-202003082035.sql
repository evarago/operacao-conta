-- MySQL dump 10.13  Distrib 5.5.62, for Win64 (AMD64)
--
-- Host: digital-documento.cluster-c58ihsrye390.us-east-1.rds.amazonaws.com    Database: operacao
-- ------------------------------------------------------
-- Server version	5.6.10

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ContaCliente`
--

DROP TABLE IF EXISTS `ContaCliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ContaCliente` (
  `Id` varchar(32) NOT NULL,
  `IdCliente` varchar(32) NOT NULL,
  `CodigoAgencia` varchar(5) NOT NULL,
  `NumeroConta` bigint(20) NOT NULL,
  `TipoConta` char(2) NOT NULL,
  `Modificado` datetime NOT NULL,
  `StatusRow` char(1) NOT NULL,
  `IdUserInsert` int(11) NOT NULL,
  `IdUserUpdate` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ContaCliente`
--

LOCK TABLES `ContaCliente` WRITE;
/*!40000 ALTER TABLE `ContaCliente` DISABLE KEYS */;
INSERT INTO `ContaCliente` VALUES ('za60f4f6d123446dbcb109b78b3bc860','ca60f4f6d123446dbcb109b78b3bc861','0899',9188827893,'CC','2020-03-06 20:47:18','I',-1,NULL);
/*!40000 ALTER TABLE `ContaCliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ContaOperacao`
--

DROP TABLE IF EXISTS `ContaOperacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ContaOperacao` (
  `Id` varchar(32) NOT NULL,
  `IdCliente` varchar(32) NOT NULL,
  `IdConta` varchar(32) NOT NULL,
  `TipoOperacao` char(1) NOT NULL,
  `Valor` double(14,9) NOT NULL,
  `DataOperacao` datetime NOT NULL,
  `Modificado` datetime NOT NULL,
  `StatusRow` char(1) NOT NULL,
  `IdUserInsert` int(11) NOT NULL,
  `IdUserUpdate` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ContaOperacao`
--

LOCK TABLES `ContaOperacao` WRITE;
/*!40000 ALTER TABLE `ContaOperacao` DISABLE KEYS */;
INSERT INTO `ContaOperacao` VALUES ('bb60f4f6d123446dbcb109b78b3bc890','ca60f4f6d123446dbcb109b78b3bc861','za60f4f6d123446dbcb109b78b3bc860','C',86.000000000,'2020-03-06 20:50:12','2020-03-06 20:50:12','I',-1,NULL),('ee65bf83f36143f082bd1adf25e3f8db','ca60f4f6d123446dbcb109b78b3bc861','za60f4f6d123446dbcb109b78b3bc860','C',200.000000000,'2020-03-07 16:10:35','2020-03-07 16:10:35','I',-1,NULL),('4242bc9276a546dd9d7d6bff4014fb0b','ca60f4f6d123446dbcb109b78b3bc861','za60f4f6d123446dbcb109b78b3bc860','C',7.010000000,'2020-03-07 16:11:42','2020-03-07 16:11:47','I',-1,NULL),('8f2f113a228349148e753e4fd228a222','ca60f4f6d123446dbcb109b78b3bc861','za60f4f6d123446dbcb109b78b3bc860','D',0.980000000,'2020-03-08 16:31:06','2020-03-08 16:31:06','I',-1,NULL),('aea5cbf9168e4571a21a8f1a1e6bef1f','ca60f4f6d123446dbcb109b78b3bc861','za60f4f6d123446dbcb109b78b3bc860','C',1.000000000,'2020-03-08 16:31:53','2020-03-08 16:31:53','I',-1,NULL),('74e6b06d595c4c2e875fb33b6e428985','ca60f4f6d123446dbcb109b78b3bc861','za60f4f6d123446dbcb109b78b3bc860','C',0.010000000,'2020-03-08 16:32:00','2020-03-08 16:32:00','I',-1,NULL),('4eb309ada8c54eda87780e8341132117','ca60f4f6d123446dbcb109b78b3bc861','za60f4f6d123446dbcb109b78b3bc860','C',0.100000000,'2020-03-08 16:32:12','2020-03-08 16:32:12','I',-1,NULL);
/*!40000 ALTER TABLE `ContaOperacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ContaSaldo`
--

DROP TABLE IF EXISTS `ContaSaldo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ContaSaldo` (
  `IdConta` varchar(32) NOT NULL,
  `IdCliente` varchar(32) NOT NULL,
  `SaldoAtual` double(14,9) NOT NULL,
  `SaldoAnterior` double(14,9) NOT NULL,
  `DataAtualizacao` datetime NOT NULL,
  `Modificado` datetime NOT NULL,
  `StatusRow` char(1) NOT NULL,
  `IdUserInsert` int(11) NOT NULL,
  `IdUserUpdate` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ContaSaldo`
--

LOCK TABLES `ContaSaldo` WRITE;
/*!40000 ALTER TABLE `ContaSaldo` DISABLE KEYS */;
INSERT INTO `ContaSaldo` VALUES ('za60f4f6d123446dbcb109b78b3bc860','ca60f4f6d123446dbcb109b78b3bc861',290.000000000,290.000000000,'2020-03-06 20:48:35','2020-03-06 20:48:35','I',-1,NULL);
/*!40000 ALTER TABLE `ContaSaldo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Pessoa`
--

DROP TABLE IF EXISTS `Pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Pessoa` (
  `Id` varchar(32) NOT NULL,
  `Identidade` varchar(14) NOT NULL,
  `Nome` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Pessoa_Identidade_IDX` (`Identidade`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Pessoa`
--

LOCK TABLES `Pessoa` WRITE;
/*!40000 ALTER TABLE `Pessoa` DISABLE KEYS */;
INSERT INTO `Pessoa` VALUES ('aa60f4f6d123446dbcb109b78b3bc862','33322211101','Anna'),('ca60f4f6d123446dbcb109b78b3bc861','33322211100','Everton');
/*!40000 ALTER TABLE `Pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'operacao'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-03-08 20:35:18
