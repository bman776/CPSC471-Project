-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3308
-- Generation Time: Apr 14, 2021 at 01:34 AM
-- Server version: 8.0.18
-- PHP Version: 7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cpsc471_project_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `cardio_log`
--

DROP TABLE IF EXISTS `cardio_log`;
CREATE TABLE IF NOT EXISTS `cardio_log` (
  `clientID` int(9) NOT NULL,
  `log_dateTime` datetime NOT NULL,
  `cardio_type` varchar(30) NOT NULL,
  `start_time` time NOT NULL,
  `end_time` time NOT NULL,
  `calories_burned` int(3) NOT NULL,
  PRIMARY KEY (`clientID`,`log_dateTime`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
CREATE TABLE IF NOT EXISTS `client` (
  `clientID` int(9) NOT NULL DEFAULT '0',
  `weight` decimal(5,0) DEFAULT NULL COMMENT 'pounds (lb)',
  `height` decimal(5,0) DEFAULT NULL COMMENT 'centimeters (cm)',
  `waist_circ` decimal(4,0) DEFAULT NULL COMMENT 'inches (in)',
  `hip_circ` decimal(4,0) DEFAULT NULL COMMENT 'inches (in)',
  `neck_circ` decimal(4,0) DEFAULT NULL COMMENT 'inches (in)',
  PRIMARY KEY (`clientID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin COMMENT='attribute comments denote units of measurements';

-- --------------------------------------------------------

--
-- Table structure for table `dietician`
--

DROP TABLE IF EXISTS `dietician`;
CREATE TABLE IF NOT EXISTS `dietician` (
  `dieticianID` int(9) NOT NULL,
  `practise` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT 'general practitioner',
  `doctorate` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL DEFAULT 'noDoctorate',
  `bachelors_degree` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL DEFAULT 'noBdegree',
  `associate_degree` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL DEFAULT 'noAdegree',
  `certification/diploma` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL DEFAULT 'noCert/Dip',
  PRIMARY KEY (`dieticianID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

-- --------------------------------------------------------

--
-- Table structure for table `exercise_set`
--

DROP TABLE IF EXISTS `exercise_set`;
CREATE TABLE IF NOT EXISTS `exercise_set` (
  `clientID` int(11) NOT NULL,
  `workoutLog_dateTime` datetime NOT NULL,
  `type` varchar(30) NOT NULL,
  `set_number` int(2) NOT NULL,
  `reps` int(2) NOT NULL,
  PRIMARY KEY (`clientID`,`workoutLog_dateTime`,`type`,`set_number`),
  KEY `workoutLog_dateTime` (`workoutLog_dateTime`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `fitness_prgrm`
--

DROP TABLE IF EXISTS `fitness_prgrm`;
CREATE TABLE IF NOT EXISTS `fitness_prgrm` (
  `instructor_authorID` int(9) NOT NULL,
  `name` varchar(30) NOT NULL,
  `description` varchar(3000) NOT NULL,
  `creation_date` datetime NOT NULL,
  `routine` text,
  `inst_vid` varchar(2083) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  `training_type` varchar(30) DEFAULT NULL,
  `exercise_modality` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`instructor_authorID`,`name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `follows`
--

DROP TABLE IF EXISTS `follows`;
CREATE TABLE IF NOT EXISTS `follows` (
  `following_client` int(9) NOT NULL,
  `followed_dietician` int(9) NOT NULL,
  `followed_nutrition_plan` varchar(30) NOT NULL,
  `join_dateTime` datetime NOT NULL,
  PRIMARY KEY (`following_client`,`followed_dietician`,`followed_nutrition_plan`,`join_dateTime`),
  KEY `followed_dietician` (`followed_dietician`),
  KEY `follows_ibfk_3` (`followed_nutrition_plan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `food_log`
--

DROP TABLE IF EXISTS `food_log`;
CREATE TABLE IF NOT EXISTS `food_log` (
  `clientID` int(9) NOT NULL,
  `log_datetime` datetime NOT NULL,
  `meal_desc` varchar(50) NOT NULL,
  `protein` int(2) NOT NULL COMMENT 'grams (g)',
  `carbohydrates` int(2) NOT NULL COMMENT 'grams (g)',
  `fat` int(2) NOT NULL COMMENT 'grams (g)',
  `calories` int(2) NOT NULL COMMENT 'grams (g)',
  PRIMARY KEY (`clientID`,`log_datetime`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `instructor`
--

DROP TABLE IF EXISTS `instructor`;
CREATE TABLE IF NOT EXISTS `instructor` (
  `instructorID` int(9) NOT NULL,
  `client_pop` varchar(3000) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL,
  `training_philosophy` varchar(3000) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin DEFAULT NULL,
  `accredidation` varchar(3000) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL DEFAULT 'accredidationPending',
  PRIMARY KEY (`instructorID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

-- --------------------------------------------------------

--
-- Table structure for table `joins`
--

DROP TABLE IF EXISTS `joins`;
CREATE TABLE IF NOT EXISTS `joins` (
  `joining_client` int(9) NOT NULL,
  `joined_inst` int(9) NOT NULL,
  `joined_fitness_prgm` varchar(30) NOT NULL,
  `join_dateTime` datetime NOT NULL,
  PRIMARY KEY (`joining_client`,`joined_inst`,`joined_fitness_prgm`,`join_dateTime`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `link`
--

DROP TABLE IF EXISTS `link`;
CREATE TABLE IF NOT EXISTS `link` (
  `linker_page` int(9) NOT NULL,
  `linked_page` int(9) NOT NULL,
  PRIMARY KEY (`linker_page`,`linked_page`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `nutrition_plan`
--

DROP TABLE IF EXISTS `nutrition_plan`;
CREATE TABLE IF NOT EXISTS `nutrition_plan` (
  `dietician_authorID` int(9) NOT NULL,
  `name` varchar(30) NOT NULL,
  `description` varchar(3000) NOT NULL,
  `creation_date` datetime NOT NULL,
  `grocery_list` text,
  `meal_plan` text,
  PRIMARY KEY (`dietician_authorID`,`name`,`description`,`creation_date`),
  KEY `name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `page`
--

DROP TABLE IF EXISTS `page`;
CREATE TABLE IF NOT EXISTS `page` (
  `pageID` int(9) NOT NULL,
  `content` text NOT NULL,
  `topic` varchar(30) NOT NULL,
  PRIMARY KEY (`pageID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `rates`
--

DROP TABLE IF EXISTS `rates`;
CREATE TABLE IF NOT EXISTS `rates` (
  `ratingClient` int(9) NOT NULL,
  `ratedSpecialist` int(9) NOT NULL,
  `rate_dateTime` datetime NOT NULL,
  `comment` varchar(300) DEFAULT NULL,
  `rating` int(3) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ratingClient`,`ratedSpecialist`,`rate_dateTime`),
  KEY `ratedSpecialist` (`ratedSpecialist`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sleep_log`
--

DROP TABLE IF EXISTS `sleep_log`;
CREATE TABLE IF NOT EXISTS `sleep_log` (
  `clientID` int(9) NOT NULL,
  `date` date NOT NULL,
  `time` time NOT NULL,
  `duration` int(1) NOT NULL,
  PRIMARY KEY (`clientID`,`date`,`time`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

-- --------------------------------------------------------

--
-- Table structure for table `specialist`
--

DROP TABLE IF EXISTS `specialist`;
CREATE TABLE IF NOT EXISTS `specialist` (
  `specialistID` int(9) NOT NULL,
  `current_employment` varchar(100) DEFAULT 'unemployed',
  `contact_info` varchar(2000) DEFAULT NULL,
  `reviewer` int(1) NOT NULL DEFAULT '0',
  `rating` int(3) NOT NULL DEFAULT '0',
  PRIMARY KEY (`specialistID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `userID` int(9) NOT NULL,
  `name` varchar(30) NOT NULL,
  `DoB` date NOT NULL,
  `username` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL,
  PRIMARY KEY (`userID`),
  UNIQUE KEY `username` (`username`,`password`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`userID`, `name`, `DoB`, `username`, `password`) VALUES
(0, 'Broosty Sprinkler', '1989-01-03', 'Broostman999', 'psswd1234'),
(1, 'Goerge Batista', '2001-07-15', 'DraxTheLax19', 'ILove123Marvel'),
(2, 'Billy Eyelashes', '1995-08-14', '3y3Spy', 'LucsiousLocks666'),
(3, 'Jeanna Jannovich', '1991-09-18', 'JJgurl5', 'prettL4dY'),
(4, 'Bruce Johnson', '2021-01-13', 'luckyNum13', 'FortunaSancutm'),
(5, 'Ahmed Salem', '2003-04-15', 'AllKnowingAhmed45', 'psswd445PsswdsHard'),
(6, 'Yolanda Smith', '1999-10-27', 'yolandaBc00l', '4mercanoLate');

-- --------------------------------------------------------

--
-- Table structure for table `view`
--

DROP TABLE IF EXISTS `view`;
CREATE TABLE IF NOT EXISTS `view` (
  `userID` int(9) NOT NULL,
  `viewed_page` int(9) NOT NULL,
  `view_dateTime` datetime NOT NULL,
  PRIMARY KEY (`userID`,`viewed_page`,`view_dateTime`),
  KEY `view_ibfk_2` (`viewed_page`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `workout_log`
--

DROP TABLE IF EXISTS `workout_log`;
CREATE TABLE IF NOT EXISTS `workout_log` (
  `clientID` int(9) NOT NULL,
  `log_dateTime` datetime NOT NULL,
  `start_time` time NOT NULL,
  `end_time` time NOT NULL,
  `calories_burned` int(3) NOT NULL,
  PRIMARY KEY (`clientID`,`log_dateTime`),
  KEY `log_dateTime` (`log_dateTime`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `writes`
--

DROP TABLE IF EXISTS `writes`;
CREATE TABLE IF NOT EXISTS `writes` (
  `specialistID` int(9) NOT NULL,
  `written_page` int(9) NOT NULL,
  `write_dateTime` datetime NOT NULL,
  PRIMARY KEY (`specialistID`,`written_page`,`write_dateTime`),
  KEY `written_page` (`written_page`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `cardio_log`
--
ALTER TABLE `cardio_log`
  ADD CONSTRAINT `cardio_log_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `client` (`clientID`);

--
-- Constraints for table `client`
--
ALTER TABLE `client`
  ADD CONSTRAINT `client_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `user` (`userID`);

--
-- Constraints for table `dietician`
--
ALTER TABLE `dietician`
  ADD CONSTRAINT `dietician_ibfk_1` FOREIGN KEY (`dieticianID`) REFERENCES `specialist` (`specialistID`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Constraints for table `exercise_set`
--
ALTER TABLE `exercise_set`
  ADD CONSTRAINT `exercise_set_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `workout_log` (`clientID`),
  ADD CONSTRAINT `exercise_set_ibfk_2` FOREIGN KEY (`workoutLog_dateTime`) REFERENCES `workout_log` (`log_dateTime`);

--
-- Constraints for table `fitness_prgrm`
--
ALTER TABLE `fitness_prgrm`
  ADD CONSTRAINT `fitness_prgrm_ibfk_1` FOREIGN KEY (`instructor_authorID`) REFERENCES `instructor` (`instructorID`);

--
-- Constraints for table `follows`
--
ALTER TABLE `follows`
  ADD CONSTRAINT `follows_ibfk_1` FOREIGN KEY (`following_client`) REFERENCES `client` (`clientID`),
  ADD CONSTRAINT `follows_ibfk_2` FOREIGN KEY (`followed_dietician`) REFERENCES `dietician` (`dieticianID`),
  ADD CONSTRAINT `follows_ibfk_3` FOREIGN KEY (`followed_nutrition_plan`) REFERENCES `nutrition_plan` (`name`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Constraints for table `food_log`
--
ALTER TABLE `food_log`
  ADD CONSTRAINT `food_log_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `client` (`clientID`);

--
-- Constraints for table `instructor`
--
ALTER TABLE `instructor`
  ADD CONSTRAINT `instructor_ibfk_1` FOREIGN KEY (`instructorID`) REFERENCES `specialist` (`specialistID`);

--
-- Constraints for table `joins`
--
ALTER TABLE `joins`
  ADD CONSTRAINT `joins_ibfk_1` FOREIGN KEY (`joining_client`) REFERENCES `client` (`clientID`);

--
-- Constraints for table `nutrition_plan`
--
ALTER TABLE `nutrition_plan`
  ADD CONSTRAINT `nutrition_plan_ibfk_1` FOREIGN KEY (`dietician_authorID`) REFERENCES `dietician` (`dieticianID`);

--
-- Constraints for table `rates`
--
ALTER TABLE `rates`
  ADD CONSTRAINT `rates_ibfk_1` FOREIGN KEY (`ratingClient`) REFERENCES `client` (`clientID`),
  ADD CONSTRAINT `rates_ibfk_2` FOREIGN KEY (`ratedSpecialist`) REFERENCES `specialist` (`specialistID`);

--
-- Constraints for table `sleep_log`
--
ALTER TABLE `sleep_log`
  ADD CONSTRAINT `sleep_log_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `client` (`clientID`);

--
-- Constraints for table `specialist`
--
ALTER TABLE `specialist`
  ADD CONSTRAINT `specialist_ibfk_1` FOREIGN KEY (`specialistID`) REFERENCES `user` (`userID`);

--
-- Constraints for table `view`
--
ALTER TABLE `view`
  ADD CONSTRAINT `view_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `user` (`userID`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `view_ibfk_2` FOREIGN KEY (`viewed_page`) REFERENCES `page` (`pageID`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Constraints for table `workout_log`
--
ALTER TABLE `workout_log`
  ADD CONSTRAINT `workout_log_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `client` (`clientID`);

--
-- Constraints for table `writes`
--
ALTER TABLE `writes`
  ADD CONSTRAINT `writes_ibfk_1` FOREIGN KEY (`specialistID`) REFERENCES `specialist` (`specialistID`),
  ADD CONSTRAINT `writes_ibfk_2` FOREIGN KEY (`written_page`) REFERENCES `page` (`pageID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
