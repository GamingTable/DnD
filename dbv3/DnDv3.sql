-- MySQL dump 10.13  Distrib 5.6.24, for Win32 (x86)
--
-- Host: 127.0.0.1    Database: dnd
-- ------------------------------------------------------
-- Server version	5.6.27-log

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
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account` (
  `id_account` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  PRIMARY KEY (`id_account`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account`
--

LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aptitude`
--

DROP TABLE IF EXISTS `aptitude`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aptitude` (
  `id_aptitude` int(10) unsigned NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `class` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_aptitude`,`class`),
  KEY `fk_aptitude_class1_idx` (`class`),
  CONSTRAINT `fk_aptitude_class1` FOREIGN KEY (`class`) REFERENCES `class` (`id_class`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aptitude`
--

LOCK TABLES `aptitude` WRITE;
/*!40000 ALTER TABLE `aptitude` DISABLE KEYS */;
/*!40000 ALTER TABLE `aptitude` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attack`
--

DROP TABLE IF EXISTS `attack`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `attack` (
  `id_attack` int(8) unsigned NOT NULL,
  `name` varchar(255) NOT NULL,
  `modifier` tinyint(4) DEFAULT NULL,
  `damage` varchar(45) NOT NULL,
  `critic` varchar(45) NOT NULL,
  `range` int(8) NOT NULL,
  `type` varchar(45) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `ammo` tinyint(4) unsigned DEFAULT NULL,
  PRIMARY KEY (`id_attack`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attack`
--

LOCK TABLES `attack` WRITE;
/*!40000 ALTER TABLE `attack` DISABLE KEYS */;
/*!40000 ALTER TABLE `attack` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `category_equipment`
--

DROP TABLE IF EXISTS `category_equipment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `category_equipment` (
  `id_category_equipment` int(8) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `category_parent` int(8) unsigned NOT NULL DEFAULT '0',
  `description` varchar(511) DEFAULT NULL,
  PRIMARY KEY (`id_category_equipment`,`category_parent`),
  KEY `fk_category_equipment_category_equipment1_idx` (`category_parent`),
  CONSTRAINT `fk_category_equipment_category_equipment1` FOREIGN KEY (`category_parent`) REFERENCES `category_equipment` (`id_category_equipment`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category_equipment`
--

LOCK TABLES `category_equipment` WRITE;
/*!40000 ALTER TABLE `category_equipment` DISABLE KEYS */;
/*!40000 ALTER TABLE `category_equipment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `character`
--

DROP TABLE IF EXISTS `character`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `character` (
  `id_character` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `avatar` blob,
  `account` int(10) unsigned NOT NULL,
  `race` int(10) unsigned NOT NULL,
  `sex` varchar(1) NOT NULL,
  `background` varchar(511) DEFAULT NULL,
  `hair` varchar(45) DEFAULT NULL,
  `eyes` varchar(45) DEFAULT NULL,
  `skin` varchar(45) DEFAULT NULL,
  `height` varchar(45) DEFAULT NULL,
  `weight` varchar(45) DEFAULT NULL,
  `deity` tinyint(6) unsigned NOT NULL DEFAULT '0',
  `age` int(10) DEFAULT NULL,
  `height_category` varchar(2) DEFAULT 'M',
  `personnality` varchar(511) DEFAULT NULL,
  PRIMARY KEY (`id_character`,`account`,`race`,`deity`),
  KEY `fk_character_account1_idx` (`account`),
  KEY `fk_character_race1_idx` (`race`),
  KEY `fk_character_god1_idx` (`deity`),
  CONSTRAINT `fk_character_account1` FOREIGN KEY (`account`) REFERENCES `account` (`id_account`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_character_god1` FOREIGN KEY (`deity`) REFERENCES `god` (`id_god`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_character_race1` FOREIGN KEY (`race`) REFERENCES `race` (`id_race`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `character`
--

LOCK TABLES `character` WRITE;
/*!40000 ALTER TABLE `character` DISABLE KEYS */;
/*!40000 ALTER TABLE `character` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `characteristic`
--

DROP TABLE IF EXISTS `characteristic`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `characteristic` (
  `id_characteristic` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `abreviation` varchar(3) DEFAULT NULL,
  `description` varchar(511) DEFAULT NULL,
  `characteristic_type` tinyint(8) unsigned NOT NULL,
  PRIMARY KEY (`id_characteristic`,`characteristic_type`),
  KEY `fk_characteristic_characteristic_type1_idx` (`characteristic_type`),
  CONSTRAINT `fk_characteristic_characteristic_type1` FOREIGN KEY (`characteristic_type`) REFERENCES `characteristic_type` (`id_characteristic_type`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characteristic`
--

LOCK TABLES `characteristic` WRITE;
/*!40000 ALTER TABLE `characteristic` DISABLE KEYS */;
INSERT INTO `characteristic` VALUES (1,'Force','For',NULL,1),(2,'Constitution','Con',NULL,1),(3,'Dextérité','Dex',NULL,1),(4,'Intelligence','Int',NULL,1),(5,'Sagesse','Sag',NULL,1),(6,'Charisme','Cha',NULL,1),(7,'Initiative',NULL,NULL,5),(8,'Classe d\'Armure','CA',NULL,5),(9,'Vigueur',NULL,NULL,2),(10,'Réflexe',NULL,NULL,2),(11,'Volonté',NULL,NULL,2),(12,'Vitesse',NULL,NULL,3),(13,'Résistance Magique',NULL,NULL,4),(14,'Difficulté aux Sorts',NULL,NULL,4),(15,'Echec aux Sorts',NULL,NULL,4),(16,'Point de Vie','PV',NULL,5),(17,'Point de Vie Max','PVM',NULL,5),(18,'Attaque de Base',NULL,NULL,3),(19,'Lutte',NULL,NULL,3),(20,'Points de Dons',NULL,NULL,6),(21,'Points de Compétences',NULL,NULL,6),(22,'Points de Caractéristiques',NULL,NULL,6),(23,'Points d\'Expérience','PX',NULL,7),(24,'Karma',NULL,NULL,7),(25,'Alignement',NULL,NULL,7);
/*!40000 ALTER TABLE `characteristic` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `characteristic_type`
--

DROP TABLE IF EXISTS `characteristic_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `characteristic_type` (
  `id_characteristic_type` tinyint(8) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `description` varchar(511) DEFAULT NULL,
  PRIMARY KEY (`id_characteristic_type`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characteristic_type`
--

LOCK TABLES `characteristic_type` WRITE;
/*!40000 ALTER TABLE `characteristic_type` DISABLE KEYS */;
INSERT INTO `characteristic_type` VALUES (1,'Caractéristiques',NULL),(2,'Jets de Sauvegarde',NULL),(3,'Combat Physique',NULL),(4,'Combat Magique',NULL),(5,'Base',NULL),(6,'Points',NULL),(7,'Evolution',NULL);
/*!40000 ALTER TABLE `characteristic_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class`
--

DROP TABLE IF EXISTS `class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `class` (
  `id_class` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `health_progression` varchar(45) DEFAULT NULL,
  `template` int(10) unsigned NOT NULL,
  `description` varchar(511) DEFAULT NULL,
  `img` blob,
  PRIMARY KEY (`id_class`,`template`),
  KEY `fk_class_template1_idx` (`template`),
  CONSTRAINT `fk_class_template1` FOREIGN KEY (`template`) REFERENCES `template` (`id_template`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class`
--

LOCK TABLES `class` WRITE;
/*!40000 ALTER TABLE `class` DISABLE KEYS */;
/*!40000 ALTER TABLE `class` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class_has_spell`
--

DROP TABLE IF EXISTS `class_has_spell`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `class_has_spell` (
  `id_class` int(10) unsigned NOT NULL,
  `id_spell` tinyint(8) unsigned NOT NULL,
  `level_required` tinyint(8) unsigned DEFAULT NULL,
  PRIMARY KEY (`id_class`,`id_spell`),
  KEY `fk_class_has_spell_spell1_idx` (`id_spell`),
  KEY `fk_class_has_spell_class1_idx` (`id_class`),
  CONSTRAINT `fk_class_has_spell_class1` FOREIGN KEY (`id_class`) REFERENCES `class` (`id_class`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_class_has_spell_spell1` FOREIGN KEY (`id_spell`) REFERENCES `spell` (`id_spell`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class_has_spell`
--

LOCK TABLES `class_has_spell` WRITE;
/*!40000 ALTER TABLE `class_has_spell` DISABLE KEYS */;
/*!40000 ALTER TABLE `class_has_spell` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `effect`
--

DROP TABLE IF EXISTS `effect`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `effect` (
  `id_effect` int(32) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `description` varchar(511) DEFAULT NULL,
  PRIMARY KEY (`id_effect`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `effect`
--

LOCK TABLES `effect` WRITE;
/*!40000 ALTER TABLE `effect` DISABLE KEYS */;
/*!40000 ALTER TABLE `effect` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `effect_has_character`
--

DROP TABLE IF EXISTS `effect_has_character`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `effect_has_character` (
  `effect` int(10) unsigned NOT NULL,
  `character` int(10) unsigned NOT NULL,
  PRIMARY KEY (`effect`,`character`),
  KEY `fk_effect_has_character_character1_idx` (`character`),
  KEY `fk_effect_has_character_effect1_idx` (`effect`),
  CONSTRAINT `fk_effect_has_character_character1` FOREIGN KEY (`character`) REFERENCES `character` (`id_character`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_effect_has_character_effect1` FOREIGN KEY (`effect`) REFERENCES `effect` (`id_effect`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `effect_has_character`
--

LOCK TABLES `effect_has_character` WRITE;
/*!40000 ALTER TABLE `effect_has_character` DISABLE KEYS */;
/*!40000 ALTER TABLE `effect_has_character` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `effect_has_class`
--

DROP TABLE IF EXISTS `effect_has_class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `effect_has_class` (
  `effect` int(10) unsigned NOT NULL,
  `class` int(10) unsigned NOT NULL,
  PRIMARY KEY (`effect`,`class`),
  KEY `fk_effect_has_class_class1_idx` (`class`),
  KEY `fk_effect_has_class_effect1_idx` (`effect`),
  CONSTRAINT `fk_effect_has_class_class1` FOREIGN KEY (`class`) REFERENCES `class` (`id_class`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_effect_has_class_effect1` FOREIGN KEY (`effect`) REFERENCES `effect` (`id_effect`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `effect_has_class`
--

LOCK TABLES `effect_has_class` WRITE;
/*!40000 ALTER TABLE `effect_has_class` DISABLE KEYS */;
/*!40000 ALTER TABLE `effect_has_class` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `effect_has_gift`
--

DROP TABLE IF EXISTS `effect_has_gift`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `effect_has_gift` (
  `effect` int(10) unsigned NOT NULL,
  `gift` tinyint(6) unsigned NOT NULL,
  PRIMARY KEY (`effect`,`gift`),
  KEY `fk_effect_has_gift_gift1_idx` (`gift`),
  KEY `fk_effect_has_gift_effect1_idx` (`effect`),
  CONSTRAINT `fk_effect_has_gift_effect1` FOREIGN KEY (`effect`) REFERENCES `effect` (`id_effect`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_effect_has_gift_gift1` FOREIGN KEY (`gift`) REFERENCES `gift` (`id_gift`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `effect_has_gift`
--

LOCK TABLES `effect_has_gift` WRITE;
/*!40000 ALTER TABLE `effect_has_gift` DISABLE KEYS */;
/*!40000 ALTER TABLE `effect_has_gift` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `effect_has_race`
--

DROP TABLE IF EXISTS `effect_has_race`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `effect_has_race` (
  `effect` int(10) unsigned NOT NULL,
  `race` int(10) unsigned NOT NULL,
  PRIMARY KEY (`effect`,`race`),
  KEY `fk_effect_has_race_race1_idx` (`race`),
  KEY `fk_effect_has_race_effect1_idx` (`effect`),
  CONSTRAINT `fk_effect_has_race_effect1` FOREIGN KEY (`effect`) REFERENCES `effect` (`id_effect`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_effect_has_race_race1` FOREIGN KEY (`race`) REFERENCES `race` (`id_race`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `effect_has_race`
--

LOCK TABLES `effect_has_race` WRITE;
/*!40000 ALTER TABLE `effect_has_race` DISABLE KEYS */;
/*!40000 ALTER TABLE `effect_has_race` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `effect_has_skill`
--

DROP TABLE IF EXISTS `effect_has_skill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `effect_has_skill` (
  `effect` int(10) unsigned NOT NULL,
  `skill` int(10) unsigned NOT NULL,
  PRIMARY KEY (`effect`,`skill`),
  KEY `fk_effect_has_skill_skill1_idx` (`skill`),
  KEY `fk_effect_has_skill_effect1_idx` (`effect`),
  CONSTRAINT `fk_effect_has_skill_effect1` FOREIGN KEY (`effect`) REFERENCES `effect` (`id_effect`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_effect_has_skill_skill1` FOREIGN KEY (`skill`) REFERENCES `skill` (`id_skill`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `effect_has_skill`
--

LOCK TABLES `effect_has_skill` WRITE;
/*!40000 ALTER TABLE `effect_has_skill` DISABLE KEYS */;
/*!40000 ALTER TABLE `effect_has_skill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `effect_has_spell`
--

DROP TABLE IF EXISTS `effect_has_spell`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `effect_has_spell` (
  `effect` int(10) unsigned NOT NULL,
  `spell` tinyint(8) unsigned NOT NULL,
  PRIMARY KEY (`effect`,`spell`),
  KEY `fk_effect_has_spell_spell1_idx` (`spell`),
  KEY `fk_effect_has_spell_effect1_idx` (`effect`),
  CONSTRAINT `fk_effect_has_spell_effect1` FOREIGN KEY (`effect`) REFERENCES `effect` (`id_effect`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_effect_has_spell_spell1` FOREIGN KEY (`spell`) REFERENCES `spell` (`id_spell`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `effect_has_spell`
--

LOCK TABLES `effect_has_spell` WRITE;
/*!40000 ALTER TABLE `effect_has_spell` DISABLE KEYS */;
/*!40000 ALTER TABLE `effect_has_spell` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `effect_required_for_category`
--

DROP TABLE IF EXISTS `effect_required_for_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `effect_required_for_category` (
  `category` int(8) unsigned NOT NULL,
  `effect` int(10) unsigned NOT NULL,
  PRIMARY KEY (`category`,`effect`),
  KEY `fk_category_equipment_has_effect_effect1_idx` (`effect`),
  KEY `fk_category_equipment_has_effect_category_equipment1_idx` (`category`),
  CONSTRAINT `fk_category_equipment_has_effect_category_equipment1` FOREIGN KEY (`category`) REFERENCES `category_equipment` (`id_category_equipment`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_category_equipment_has_effect_effect1` FOREIGN KEY (`effect`) REFERENCES `effect` (`id_effect`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `effect_required_for_category`
--

LOCK TABLES `effect_required_for_category` WRITE;
/*!40000 ALTER TABLE `effect_required_for_category` DISABLE KEYS */;
/*!40000 ALTER TABLE `effect_required_for_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipment`
--

DROP TABLE IF EXISTS `equipment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `equipment` (
  `id_equipment` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `type` varchar(255) DEFAULT NULL COMMENT 'type refers to armor, specials, shield, weapon, ammos, consummable or else',
  `template` int(10) unsigned NOT NULL DEFAULT '0',
  `spell` tinyint(8) unsigned NOT NULL DEFAULT '0',
  `equipped` tinyint(1) DEFAULT NULL,
  `language` tinyint(8) unsigned NOT NULL DEFAULT '0',
  `attack` int(8) unsigned NOT NULL DEFAULT '0',
  `weight` int(6) unsigned DEFAULT NULL,
  `category` int(8) unsigned NOT NULL,
  `size` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`id_equipment`,`template`,`spell`,`language`,`attack`,`category`),
  KEY `fk_equipment_template1_idx` (`template`),
  KEY `fk_equipment_spell1_idx` (`spell`),
  KEY `fk_equipment_language1_idx` (`language`),
  KEY `fk_equipment_attack1_idx` (`attack`),
  KEY `fk_equipment_category_equipment1_idx` (`category`),
  CONSTRAINT `fk_equipment_attack1` FOREIGN KEY (`attack`) REFERENCES `attack` (`id_attack`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_equipment_category_equipment1` FOREIGN KEY (`category`) REFERENCES `category_equipment` (`id_category_equipment`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_equipment_language1` FOREIGN KEY (`language`) REFERENCES `language` (`id_language`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_equipment_spell1` FOREIGN KEY (`spell`) REFERENCES `spell` (`id_spell`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_equipment_template1` FOREIGN KEY (`template`) REFERENCES `template` (`id_template`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipment`
--

LOCK TABLES `equipment` WRITE;
/*!40000 ALTER TABLE `equipment` DISABLE KEYS */;
/*!40000 ALTER TABLE `equipment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipment_has_inventory`
--

DROP TABLE IF EXISTS `equipment_has_inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `equipment_has_inventory` (
  `equipment` int(10) unsigned NOT NULL,
  `inventory` int(10) unsigned NOT NULL,
  `number` int(10) unsigned DEFAULT NULL,
  PRIMARY KEY (`equipment`,`inventory`),
  KEY `fk_equipment_has_inventory_inventory1_idx` (`inventory`),
  KEY `fk_equipment_has_inventory_equipment1_idx` (`equipment`),
  CONSTRAINT `fk_equipment_has_inventory_equipment1` FOREIGN KEY (`equipment`) REFERENCES `equipment` (`id_equipment`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_equipment_has_inventory_inventory1` FOREIGN KEY (`inventory`) REFERENCES `inventory` (`id_inventory`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipment_has_inventory`
--

LOCK TABLES `equipment_has_inventory` WRITE;
/*!40000 ALTER TABLE `equipment_has_inventory` DISABLE KEYS */;
/*!40000 ALTER TABLE `equipment_has_inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gift`
--

DROP TABLE IF EXISTS `gift`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gift` (
  `id_gift` tinyint(6) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `category` varchar(255) DEFAULT NULL,
  `class` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_gift`,`class`),
  KEY `fk_gift_class1_idx` (`class`),
  CONSTRAINT `fk_gift_class1` FOREIGN KEY (`class`) REFERENCES `class` (`id_class`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gift`
--

LOCK TABLES `gift` WRITE;
/*!40000 ALTER TABLE `gift` DISABLE KEYS */;
/*!40000 ALTER TABLE `gift` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gift_conditions`
--

DROP TABLE IF EXISTS `gift_conditions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gift_conditions` (
  `gift` tinyint(6) unsigned NOT NULL,
  `effect` int(32) unsigned NOT NULL,
  PRIMARY KEY (`gift`,`effect`),
  KEY `fk_gift_has_effect_effect1_idx` (`effect`),
  KEY `fk_gift_has_effect_gift1_idx` (`gift`),
  CONSTRAINT `fk_gift_has_effect_effect1` FOREIGN KEY (`effect`) REFERENCES `effect` (`id_effect`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_gift_has_effect_gift1` FOREIGN KEY (`gift`) REFERENCES `gift` (`id_gift`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gift_conditions`
--

LOCK TABLES `gift_conditions` WRITE;
/*!40000 ALTER TABLE `gift_conditions` DISABLE KEYS */;
/*!40000 ALTER TABLE `gift_conditions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gift_has_character`
--

DROP TABLE IF EXISTS `gift_has_character`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gift_has_character` (
  `gift` tinyint(6) unsigned NOT NULL,
  `character` int(10) unsigned NOT NULL,
  PRIMARY KEY (`gift`,`character`),
  KEY `fk_gift_has_character_character1_idx` (`character`),
  KEY `fk_gift_has_character_gift1_idx` (`gift`),
  CONSTRAINT `fk_gift_has_character_character1` FOREIGN KEY (`character`) REFERENCES `character` (`id_character`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_gift_has_character_gift1` FOREIGN KEY (`gift`) REFERENCES `gift` (`id_gift`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gift_has_character`
--

LOCK TABLES `gift_has_character` WRITE;
/*!40000 ALTER TABLE `gift_has_character` DISABLE KEYS */;
/*!40000 ALTER TABLE `gift_has_character` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `god`
--

DROP TABLE IF EXISTS `god`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `god` (
  `id_god` tinyint(6) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `description` varchar(511) DEFAULT NULL,
  `karma` int(8) DEFAULT NULL,
  PRIMARY KEY (`id_god`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `god`
--

LOCK TABLES `god` WRITE;
/*!40000 ALTER TABLE `god` DISABLE KEYS */;
/*!40000 ALTER TABLE `god` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory`
--

DROP TABLE IF EXISTS `inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inventory` (
  `id_inventory` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `character` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id_inventory`,`character`),
  KEY `fk_inventory_character1_idx` (`character`),
  CONSTRAINT `fk_inventory_character1` FOREIGN KEY (`character`) REFERENCES `character` (`id_character`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `language`
--

DROP TABLE IF EXISTS `language`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `language` (
  `id_language` tinyint(8) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id_language`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `language`
--

LOCK TABLES `language` WRITE;
/*!40000 ALTER TABLE `language` DISABLE KEYS */;
/*!40000 ALTER TABLE `language` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `language_has_character`
--

DROP TABLE IF EXISTS `language_has_character`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `language_has_character` (
  `language` tinyint(8) unsigned NOT NULL,
  `character` int(10) unsigned NOT NULL,
  PRIMARY KEY (`language`,`character`),
  KEY `fk_language_has_character_character1_idx` (`character`),
  KEY `fk_language_has_character_language1_idx` (`language`),
  CONSTRAINT `fk_language_has_character_character1` FOREIGN KEY (`character`) REFERENCES `character` (`id_character`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_language_has_character_language1` FOREIGN KEY (`language`) REFERENCES `language` (`id_language`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `language_has_character`
--

LOCK TABLES `language_has_character` WRITE;
/*!40000 ALTER TABLE `language_has_character` DISABLE KEYS */;
/*!40000 ALTER TABLE `language_has_character` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `language_has_race`
--

DROP TABLE IF EXISTS `language_has_race`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `language_has_race` (
  `language` tinyint(8) unsigned NOT NULL,
  `race` int(10) unsigned NOT NULL,
  PRIMARY KEY (`language`,`race`),
  KEY `fk_language_has_race_race1_idx` (`race`),
  KEY `fk_language_has_race_language1_idx` (`language`),
  CONSTRAINT `fk_language_has_race_language1` FOREIGN KEY (`language`) REFERENCES `language` (`id_language`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_language_has_race_race1` FOREIGN KEY (`race`) REFERENCES `race` (`id_race`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `language_has_race`
--

LOCK TABLES `language_has_race` WRITE;
/*!40000 ALTER TABLE `language_has_race` DISABLE KEYS */;
/*!40000 ALTER TABLE `language_has_race` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modifier_has_spell`
--

DROP TABLE IF EXISTS `modifier_has_spell`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modifier_has_spell` (
  `spell` tinyint(8) unsigned NOT NULL,
  `template` int(10) unsigned NOT NULL,
  PRIMARY KEY (`spell`,`template`),
  KEY `fk_modifier_has_spell_spell1_idx` (`spell`),
  KEY `fk_modifier_has_spell_template1_idx` (`template`),
  CONSTRAINT `fk_modifier_has_spell_spell1` FOREIGN KEY (`spell`) REFERENCES `spell` (`id_spell`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_modifier_has_spell_template1` FOREIGN KEY (`template`) REFERENCES `template` (`id_template`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modifier_has_spell`
--

LOCK TABLES `modifier_has_spell` WRITE;
/*!40000 ALTER TABLE `modifier_has_spell` DISABLE KEYS */;
/*!40000 ALTER TABLE `modifier_has_spell` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `money`
--

DROP TABLE IF EXISTS `money`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `money` (
  `id_money` tinyint(4) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `conversion_value_in_gold` float unsigned DEFAULT NULL,
  PRIMARY KEY (`id_money`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `money`
--

LOCK TABLES `money` WRITE;
/*!40000 ALTER TABLE `money` DISABLE KEYS */;
/*!40000 ALTER TABLE `money` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `money_has_inventory`
--

DROP TABLE IF EXISTS `money_has_inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `money_has_inventory` (
  `money` tinyint(4) unsigned NOT NULL,
  `inventory` int(10) unsigned NOT NULL,
  `quantity` int(20) unsigned NOT NULL,
  PRIMARY KEY (`money`,`inventory`),
  KEY `fk_money_has_inventory_inventory1_idx` (`inventory`),
  KEY `fk_money_has_inventory_money1_idx` (`money`),
  CONSTRAINT `fk_money_has_inventory_inventory1` FOREIGN KEY (`inventory`) REFERENCES `inventory` (`id_inventory`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_money_has_inventory_money1` FOREIGN KEY (`money`) REFERENCES `money` (`id_money`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `money_has_inventory`
--

LOCK TABLES `money_has_inventory` WRITE;
/*!40000 ALTER TABLE `money_has_inventory` DISABLE KEYS */;
/*!40000 ALTER TABLE `money_has_inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `multiclasses`
--

DROP TABLE IF EXISTS `multiclasses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `multiclasses` (
  `id_multiclasses` int(11) NOT NULL AUTO_INCREMENT,
  `character` int(10) unsigned NOT NULL,
  `class` int(10) unsigned NOT NULL,
  `level` tinyint(4) unsigned DEFAULT NULL,
  PRIMARY KEY (`id_multiclasses`,`character`,`class`),
  KEY `fk_multiclasses_character1_idx` (`character`),
  KEY `fk_multiclasses_class1_idx` (`class`),
  CONSTRAINT `fk_multiclasses_character1` FOREIGN KEY (`character`) REFERENCES `character` (`id_character`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_multiclasses_class1` FOREIGN KEY (`class`) REFERENCES `class` (`id_class`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `multiclasses`
--

LOCK TABLES `multiclasses` WRITE;
/*!40000 ALTER TABLE `multiclasses` DISABLE KEYS */;
/*!40000 ALTER TABLE `multiclasses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `race`
--

DROP TABLE IF EXISTS `race`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `race` (
  `id_race` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `template` int(10) unsigned NOT NULL DEFAULT '0',
  `description` varchar(511) DEFAULT NULL,
  `img` blob,
  PRIMARY KEY (`id_race`,`template`),
  KEY `fk_race_template1_idx` (`template`),
  CONSTRAINT `fk_race_template1` FOREIGN KEY (`template`) REFERENCES `template` (`id_template`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `race`
--

LOCK TABLES `race` WRITE;
/*!40000 ALTER TABLE `race` DISABLE KEYS */;
/*!40000 ALTER TABLE `race` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skill`
--

DROP TABLE IF EXISTS `skill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `skill` (
  `id_skill` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `class` int(10) unsigned NOT NULL DEFAULT '0',
  `teacher` tinyint(1) DEFAULT '0',
  `innate` tinyint(1) DEFAULT '0',
  `key_ability` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`id_skill`,`class`),
  KEY `fk_skill_class1_idx` (`class`),
  CONSTRAINT `fk_skill_class1` FOREIGN KEY (`class`) REFERENCES `class` (`id_class`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skill`
--

LOCK TABLES `skill` WRITE;
/*!40000 ALTER TABLE `skill` DISABLE KEYS */;
/*!40000 ALTER TABLE `skill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skill_conditions`
--

DROP TABLE IF EXISTS `skill_conditions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `skill_conditions` (
  `skill` int(10) unsigned NOT NULL,
  `effect` int(32) unsigned NOT NULL,
  PRIMARY KEY (`skill`,`effect`),
  KEY `fk_skill_has_effect_effect1_idx` (`effect`),
  KEY `fk_skill_has_effect_skill1_idx` (`skill`),
  CONSTRAINT `fk_skill_has_effect_effect1` FOREIGN KEY (`effect`) REFERENCES `effect` (`id_effect`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_skill_has_effect_skill1` FOREIGN KEY (`skill`) REFERENCES `skill` (`id_skill`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skill_conditions`
--

LOCK TABLES `skill_conditions` WRITE;
/*!40000 ALTER TABLE `skill_conditions` DISABLE KEYS */;
/*!40000 ALTER TABLE `skill_conditions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skill_has_character`
--

DROP TABLE IF EXISTS `skill_has_character`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `skill_has_character` (
  `skill` int(10) unsigned NOT NULL,
  `character` int(10) unsigned NOT NULL,
  `mastery_degree` tinyint(6) unsigned DEFAULT NULL,
  PRIMARY KEY (`skill`,`character`),
  KEY `fk_skill_has_character_character1_idx` (`character`),
  KEY `fk_skill_has_character_skill1_idx` (`skill`),
  CONSTRAINT `fk_skill_has_character_character1` FOREIGN KEY (`character`) REFERENCES `character` (`id_character`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_skill_has_character_skill1` FOREIGN KEY (`skill`) REFERENCES `skill` (`id_skill`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skill_has_character`
--

LOCK TABLES `skill_has_character` WRITE;
/*!40000 ALTER TABLE `skill_has_character` DISABLE KEYS */;
/*!40000 ALTER TABLE `skill_has_character` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skill_has_modifier`
--

DROP TABLE IF EXISTS `skill_has_modifier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `skill_has_modifier` (
  `skill` int(10) unsigned NOT NULL,
  `characteristic` int(10) unsigned NOT NULL,
  `modifier` int(10) unsigned DEFAULT '0',
  PRIMARY KEY (`skill`,`characteristic`),
  KEY `fk_skill_has_template_skill1_idx` (`skill`),
  KEY `fk_skill_has_modifier_characteristic1_idx` (`characteristic`),
  CONSTRAINT `fk_skill_has_modifier_characteristic1` FOREIGN KEY (`characteristic`) REFERENCES `characteristic` (`id_characteristic`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_skill_has_template_skill1` FOREIGN KEY (`skill`) REFERENCES `skill` (`id_skill`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skill_has_modifier`
--

LOCK TABLES `skill_has_modifier` WRITE;
/*!40000 ALTER TABLE `skill_has_modifier` DISABLE KEYS */;
/*!40000 ALTER TABLE `skill_has_modifier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `spell`
--

DROP TABLE IF EXISTS `spell`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `spell` (
  `id_spell` tinyint(8) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `magic_resist` tinyint(1) DEFAULT NULL,
  `saving_throw` varchar(45) DEFAULT NULL,
  `duration` varchar(255) DEFAULT NULL,
  `target` tinyint(3) unsigned DEFAULT NULL,
  `range` int(10) unsigned DEFAULT NULL,
  `casting_time` varchar(255) DEFAULT NULL,
  `component` varchar(2) DEFAULT NULL,
  `wizardry` tinyint(8) unsigned NOT NULL,
  `Incantation` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_spell`,`wizardry`),
  KEY `fk_spell_wizardry1_idx` (`wizardry`),
  CONSTRAINT `fk_spell_wizardry1` FOREIGN KEY (`wizardry`) REFERENCES `wizardry` (`id_wizardry`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spell`
--

LOCK TABLES `spell` WRITE;
/*!40000 ALTER TABLE `spell` DISABLE KEYS */;
/*!40000 ALTER TABLE `spell` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `spell_has_character_mind`
--

DROP TABLE IF EXISTS `spell_has_character_mind`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `spell_has_character_mind` (
  `spell` tinyint(8) unsigned NOT NULL,
  `character` int(10) unsigned NOT NULL,
  PRIMARY KEY (`spell`,`character`),
  KEY `fk_spell_has_character_character1_idx` (`character`),
  KEY `fk_spell_has_character_spell1_idx` (`spell`),
  CONSTRAINT `fk_spell_has_character_character1` FOREIGN KEY (`character`) REFERENCES `character` (`id_character`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_spell_has_character_spell1` FOREIGN KEY (`spell`) REFERENCES `spell` (`id_spell`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spell_has_character_mind`
--

LOCK TABLES `spell_has_character_mind` WRITE;
/*!40000 ALTER TABLE `spell_has_character_mind` DISABLE KEYS */;
/*!40000 ALTER TABLE `spell_has_character_mind` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `spell_has_spellbook`
--

DROP TABLE IF EXISTS `spell_has_spellbook`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `spell_has_spellbook` (
  `spell` tinyint(8) unsigned NOT NULL,
  `spellbook` int(10) unsigned NOT NULL,
  PRIMARY KEY (`spell`,`spellbook`),
  KEY `fk_spell_has_spellbook_spellbook1_idx` (`spellbook`),
  KEY `fk_spell_has_spellbook_spell1_idx` (`spell`),
  CONSTRAINT `fk_spell_has_spellbook_spell1` FOREIGN KEY (`spell`) REFERENCES `spell` (`id_spell`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_spell_has_spellbook_spellbook1` FOREIGN KEY (`spellbook`) REFERENCES `spellbook` (`id_spellbook`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spell_has_spellbook`
--

LOCK TABLES `spell_has_spellbook` WRITE;
/*!40000 ALTER TABLE `spell_has_spellbook` DISABLE KEYS */;
/*!40000 ALTER TABLE `spell_has_spellbook` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `spellbook`
--

DROP TABLE IF EXISTS `spellbook`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `spellbook` (
  `id_spellbook` int(10) unsigned NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id_spellbook`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spellbook`
--

LOCK TABLES `spellbook` WRITE;
/*!40000 ALTER TABLE `spellbook` DISABLE KEYS */;
/*!40000 ALTER TABLE `spellbook` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `spellbook_has_inventory`
--

DROP TABLE IF EXISTS `spellbook_has_inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `spellbook_has_inventory` (
  `spellbook` int(10) unsigned NOT NULL,
  `inventory` int(10) unsigned NOT NULL,
  PRIMARY KEY (`spellbook`,`inventory`),
  KEY `fk_spellbook_has_inventory_inventory1_idx` (`inventory`),
  KEY `fk_spellbook_has_inventory_spellbook1_idx` (`spellbook`),
  CONSTRAINT `fk_spellbook_has_inventory_inventory1` FOREIGN KEY (`inventory`) REFERENCES `inventory` (`id_inventory`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_spellbook_has_inventory_spellbook1` FOREIGN KEY (`spellbook`) REFERENCES `spellbook` (`id_spellbook`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `spellbook_has_inventory`
--

LOCK TABLES `spellbook_has_inventory` WRITE;
/*!40000 ALTER TABLE `spellbook_has_inventory` DISABLE KEYS */;
/*!40000 ALTER TABLE `spellbook_has_inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `stats`
--

DROP TABLE IF EXISTS `stats`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `stats` (
  `id_stats` int(15) unsigned NOT NULL AUTO_INCREMENT,
  `template` int(10) unsigned NOT NULL DEFAULT '0',
  `character` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`id_stats`,`template`,`character`),
  KEY `fk_stats_template1_idx` (`template`),
  KEY `fk_stats_character1_idx` (`character`),
  CONSTRAINT `fk_stats_character1` FOREIGN KEY (`character`) REFERENCES `character` (`id_character`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_stats_template1` FOREIGN KEY (`template`) REFERENCES `template` (`id_template`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `stats`
--

LOCK TABLES `stats` WRITE;
/*!40000 ALTER TABLE `stats` DISABLE KEYS */;
/*!40000 ALTER TABLE `stats` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `template`
--

DROP TABLE IF EXISTS `template`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `template` (
  `id_template` int(10) unsigned NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id_template`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `template`
--

LOCK TABLES `template` WRITE;
/*!40000 ALTER TABLE `template` DISABLE KEYS */;
/*!40000 ALTER TABLE `template` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `template_has_characteristic`
--

DROP TABLE IF EXISTS `template_has_characteristic`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `template_has_characteristic` (
  `template` int(10) unsigned NOT NULL,
  `characteristic` int(10) unsigned NOT NULL,
  `value` int(11) DEFAULT NULL,
  PRIMARY KEY (`template`,`characteristic`),
  KEY `fk_template_has_characteristic_characteristic1_idx` (`characteristic`),
  KEY `fk_template_has_characteristic_template1_idx` (`template`),
  CONSTRAINT `fk_template_has_characteristic_characteristic1` FOREIGN KEY (`characteristic`) REFERENCES `characteristic` (`id_characteristic`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_template_has_characteristic_template1` FOREIGN KEY (`template`) REFERENCES `template` (`id_template`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `template_has_characteristic`
--

LOCK TABLES `template_has_characteristic` WRITE;
/*!40000 ALTER TABLE `template_has_characteristic` DISABLE KEYS */;
/*!40000 ALTER TABLE `template_has_characteristic` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `template_has_modifier`
--

DROP TABLE IF EXISTS `template_has_modifier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `template_has_modifier` (
  `characteristic` int(10) unsigned NOT NULL,
  `template` int(10) unsigned NOT NULL,
  `modifier` int(11) DEFAULT NULL,
  PRIMARY KEY (`characteristic`,`template`),
  KEY `fk_characteristic_has_template_template1_idx` (`template`),
  KEY `fk_characteristic_has_template_characteristic1_idx` (`characteristic`),
  CONSTRAINT `fk_characteristic_has_template_characteristic1` FOREIGN KEY (`characteristic`) REFERENCES `characteristic` (`id_characteristic`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_characteristic_has_template_template1` FOREIGN KEY (`template`) REFERENCES `template` (`id_template`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `template_has_modifier`
--

LOCK TABLES `template_has_modifier` WRITE;
/*!40000 ALTER TABLE `template_has_modifier` DISABLE KEYS */;
/*!40000 ALTER TABLE `template_has_modifier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wizardry`
--

DROP TABLE IF EXISTS `wizardry`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `wizardry` (
  `id_wizardry` tinyint(8) unsigned NOT NULL AUTO_INCREMENT,
  `profane_divine` tinyint(1) DEFAULT NULL,
  `school` varchar(255) DEFAULT NULL,
  `branch` varchar(255) DEFAULT NULL,
  `register` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_wizardry`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wizardry`
--

LOCK TABLES `wizardry` WRITE;
/*!40000 ALTER TABLE `wizardry` DISABLE KEYS */;
/*!40000 ALTER TABLE `wizardry` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-11-28 20:09:42
