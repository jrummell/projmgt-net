/*
SQLyog Community Edition- MySQL GUI v5.2 Beta 2
Host - 4.1.21-standard : Database - p173191_
*********************************************************************
Server version : 4.1.21-standard
*/

SET NAMES utf8;

SET SQL_MODE='';

create database if not exists `p173191_`;

USE `p173191_`;

SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO';

/*Table structure for table `compLevels` */

DROP TABLE IF EXISTS `compLevels`;

CREATE TABLE `compLevels` (
  `userID` int(10) unsigned NOT NULL default '0',
  `competence` smallint(5) unsigned NOT NULL default '0',
  KEY `FK__userID` (`userID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `compMatrix` */

DROP TABLE IF EXISTS `compMatrix`;

CREATE TABLE `compMatrix` (
  `ID` int(11) NOT NULL auto_increment,
  `compLevel` smallint(6) NOT NULL default '0',
  `highComplexity` double NOT NULL default '0',
  `medComplexity` double NOT NULL default '0',
  `lowComplexity` double NOT NULL default '0',
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1 COMMENT='Complexity vs Competency Matrix';

/*Table structure for table `messages` */

DROP TABLE IF EXISTS `messages`;

CREATE TABLE `messages` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `SenderID` int(10) unsigned NOT NULL default '0',
  `Subject` varchar(45) NOT NULL default '',
  `Body` text NOT NULL,
  `DateSent` datetime NOT NULL default '0001-01-01 00:00:00',
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Table structure for table `modules` */

DROP TABLE IF EXISTS `modules`;

CREATE TABLE `modules` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `Name` varchar(45) NOT NULL default '',
  `Description` varchar(200) NOT NULL default '',
  `StartDate` datetime NOT NULL default '0001-01-01 00:00:00',
  `ExpEndDate` datetime NOT NULL default '0001-01-01 00:00:00',
  `ActEndDate` datetime NOT NULL default '0001-01-01 00:00:00',
  `ProjectID` int(10) unsigned NOT NULL default '0',
  PRIMARY KEY  (`ID`),
  KEY `FK_modules_projectID` USING BTREE (`ProjectID`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `projects` */

DROP TABLE IF EXISTS `projects`;

CREATE TABLE `projects` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `Name` varchar(45) NOT NULL default '',
  `Description` varchar(200) NOT NULL default '',
  `StartDate` datetime NOT NULL default '0001-01-01 00:00:00',
  `ExpEndDate` datetime NOT NULL default '0001-01-01 00:00:00',
  `ActEndDate` datetime NOT NULL default '0001-01-01 00:00:00',
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

/*Table structure for table `recipients` */

DROP TABLE IF EXISTS `recipients`;

CREATE TABLE `recipients` (
  `MessageID` int(10) unsigned NOT NULL default '0',
  `RecipientID` int(10) unsigned NOT NULL default '0',
  `DateReceived` datetime NOT NULL default '0001-01-01 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `taskAssignments` */

DROP TABLE IF EXISTS `taskAssignments`;

CREATE TABLE `taskAssignments` (
  `devID` int(11) NOT NULL default '0',
  `taskID` int(11) NOT NULL default '0',
  `dateAssigned` datetime NOT NULL default '0001-01-01 00:00:00',
  PRIMARY KEY  (`devID`,`taskID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `tasks` */

DROP TABLE IF EXISTS `tasks`;

CREATE TABLE `tasks` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `Name` varchar(45) NOT NULL default '',
  `Description` varchar(200) NOT NULL default '',
  `Complexity` smallint(6) NOT NULL default '0' COMMENT 'low=0, med=1, high=2',
  `Status` smallint(6) NOT NULL default '0',
  `StartDate` datetime NOT NULL default '0001-01-01 00:00:00',
  `ExpEndDate` datetime NOT NULL default '0001-01-01 00:00:00',
  `ActEndDate` datetime NOT NULL default '0001-01-01 00:00:00',
  `ModuleID` int(10) unsigned NOT NULL default '0',
  `ProjectID` int(10) unsigned NOT NULL default '0',
  PRIMARY KEY  (`ID`),
  KEY `FK_tasks_moduleID` (`ModuleID`),
  KEY `FK_tasks_projectID` (`ProjectID`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Table structure for table `userInfo` */

DROP TABLE IF EXISTS `userInfo`;

CREATE TABLE `userInfo` (
  `ID` int(11) NOT NULL default '0',
  `FirstName` varchar(30) NOT NULL default '',
  `LastName` varchar(30) NOT NULL default '',
  `Address` varchar(50) default NULL,
  `City` varchar(30) default NULL,
  `State` varchar(30) default NULL,
  `Zip` varchar(10) default NULL,
  `PhoneNumber` varchar(13) default NULL,
  `Email` varchar(50) NOT NULL default '',
  KEY `FK_userInfo_id` (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `userReference` */

DROP TABLE IF EXISTS `userReference`;

CREATE TABLE `userReference` (
  `userID` int(10) unsigned NOT NULL default '0',
  `projectID` int(10) unsigned NOT NULL default '0',
  `managerID` int(10) unsigned NOT NULL default '0',
  KEY `FK_userReference_userID` (`userID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `users` */

DROP TABLE IF EXISTS `users`;

CREATE TABLE `users` (
  `UserName` varchar(30) NOT NULL default '',
  `Password` varchar(32) NOT NULL default '',
  `ID` int(11) NOT NULL auto_increment,
  `Role` smallint(2) NOT NULL default '0' COMMENT 'Security (0=client, 1=developer, 2=proj manager, 3=admin)',
  `Enabled` smallint(2) NOT NULL default '0' COMMENT '0=disabled, 1=enabled, 2=deleted?',
  PRIMARY KEY  (`ID`),
  UNIQUE KEY `Index_UserName` (`UserName`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
