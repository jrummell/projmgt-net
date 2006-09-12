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

/*Data for the table `compLevels` */

insert into `compLevels`(`userID`,`competence`) values (7,2);

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

/*Data for the table `compMatrix` */

insert into `compMatrix`(`ID`,`compLevel`,`highComplexity`,`medComplexity`,`lowComplexity`) values (1,0,20,15,10),(2,1,30,25,20),(3,2,40,35,30);

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

/*Data for the table `messages` */

insert into `messages`(`ID`,`SenderID`,`Subject`,`Body`,`DateSent`) values (1,1,'testing testing','testing more ...','2006-08-09 23:14:33'),(2,1,'testing testing','testing more ...','2006-08-09 23:15:50'),(3,1,'wooha','woo hoo hoo woo boo boo','2006-08-09 23:20:25'),(4,1,'asdfasdfadsfadfadfdsa','asdflk adslj faldsjflk dsjfadsj f ;ldsajfa faldsj flsakdjf lakdsj flakdsfjdsa flsa dfasdfdsaf dsaf dsafds s fasd ff dsaf dsa','2006-08-09 23:23:02');

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

/*Data for the table `modules` */

insert into `modules`(`ID`,`Name`,`Description`,`StartDate`,`ExpEndDate`,`ActEndDate`,`ProjectID`) values (1,'module 1','testing 1 2 4','2007-12-12 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00',5);

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

/*Data for the table `projects` */

insert into `projects`(`ID`,`Name`,`Description`,`StartDate`,`ExpEndDate`,`ActEndDate`) values (5,'project 1','','2006-08-06 00:00:00','0001-01-01 00:00:00','0001-01-01 00:00:00');

/*Table structure for table `recipients` */

DROP TABLE IF EXISTS `recipients`;

CREATE TABLE `recipients` (
  `MessageID` int(10) unsigned NOT NULL default '0',
  `RecipientID` int(10) unsigned NOT NULL default '0',
  `DateReceived` datetime NOT NULL default '0001-01-01 00:00:00'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `recipients` */

insert into `recipients`(`MessageID`,`RecipientID`,`DateReceived`) values (1,1,'0001-01-01 00:00:00'),(2,1,'0001-01-01 00:00:00'),(2,7,'0001-01-01 00:00:00'),(2,8,'0001-01-01 00:00:00'),(3,1,'0001-01-01 00:00:00'),(4,1,'0001-01-01 00:00:00'),(4,7,'0001-01-01 00:00:00');

/*Table structure for table `taskAssignments` */

DROP TABLE IF EXISTS `taskAssignments`;

CREATE TABLE `taskAssignments` (
  `devID` int(11) NOT NULL default '0',
  `taskID` int(11) NOT NULL default '0',
  `dateAssigned` datetime NOT NULL default '0001-01-01 00:00:00',
  PRIMARY KEY  (`devID`,`taskID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `taskAssignments` */

insert into `taskAssignments`(`devID`,`taskID`,`dateAssigned`) values (7,1,'2006-08-31 00:00:00'),(7,2,'0001-01-01 00:00:00');

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

/*Data for the table `tasks` */

insert into `tasks`(`ID`,`Name`,`Description`,`Complexity`,`Status`,`StartDate`,`ExpEndDate`,`ActEndDate`,`ModuleID`,`ProjectID`) values (1,'task 1','',0,3,'2007-12-12 00:00:00','0001-01-01 00:00:00','2006-08-30 21:58:37',1,5),(2,'task 1.1.2','',0,3,'2009-01-01 00:00:00','0001-01-01 00:00:00','2006-08-30 21:58:37',1,5);

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

/*Data for the table `userInfo` */

insert into `userInfo`(`ID`,`FirstName`,`LastName`,`Address`,`City`,`State`,`Zip`,`PhoneNumber`,`Email`) values (1,'John','Rummell',NULL,NULL,NULL,NULL,NULL,'jrummell@users.sourceforge.net'),(8,'John','Rummell','asdf','asdf','asdf','44720','123-456-7890','asdf2@asdf.com'),(7,'John','Rummell','asdf','asdf','asdf','44720','123-456-7890','asdf@asdf.com');

/*Table structure for table `userReference` */

DROP TABLE IF EXISTS `userReference`;

CREATE TABLE `userReference` (
  `userID` int(10) unsigned NOT NULL default '0',
  `projectID` int(10) unsigned NOT NULL default '0',
  `managerID` int(10) unsigned NOT NULL default '0',
  KEY `FK_userReference_userID` (`userID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `userReference` */

insert into `userReference`(`userID`,`projectID`,`managerID`) values (8,3,8),(8,4,8),(8,5,8);

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

/*Data for the table `users` */

insert into `users`(`UserName`,`Password`,`ID`,`Role`,`Enabled`) values ('jrummell_admin','912ec803b2ce49e4a541068d495ab570',1,3,1),('jrummell_dev','912ec803b2ce49e4a541068d495ab570',7,1,1),('jrummell_pm','912ec803b2ce49e4a541068d495ab570',8,2,1);

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
