-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3308
-- Generation Time: Apr 15, 2021 at 02:00 AM
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
  `log_date` date NOT NULL,
  `cardio_type` varchar(30) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `start_time` time NOT NULL,
  `end_time` time NOT NULL,
  `calories_burned` int(3) NOT NULL,
  PRIMARY KEY (`clientID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cardio_log`
--

INSERT INTO `cardio_log` (`clientID`, `log_date`, `cardio_type`, `start_time`, `end_time`, `calories_burned`) VALUES
(0, '0000-00-00', '', '00:00:00', '00:00:00', 0),
(1, '2021-04-05', 'TreadMill', '10:10:14', '10:45:05', 500);

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

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`clientID`, `weight`, `height`, `waist_circ`, `hip_circ`, `neck_circ`) VALUES
(0, '185', '160', '32', '33', '18'),
(1, '217', '156', '34', '36', '20');

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

--
-- Dumping data for table `dietician`
--

INSERT INTO `dietician` (`dieticianID`, `practise`, `doctorate`, `bachelors_degree`, `associate_degree`, `certification/diploma`) VALUES
(5, 'Clinical Practitioner', 'University of California:\r\nLorem ipsum dolor sit amet, consectetur adipiscing elit. Ut id leo ac ligula dignissim volutpat. Curabitur et iaculis massa. In hac habitasse platea dictumst. In purus torto', 'noBdegree', 'noAdegree', 'noCert/Dip'),
(6, 'general practitioner', 'noDoctorate', 'Cal State University:\r\nLorem ipsum dolor sit amet, consectetur adipiscing elit. Proin augue ante, dignissim id elementum in, tempor ut turpis. Sed elementum, tellus a lobortis gravida, magna dui egest', 'noAdegree', 'noCert/Dip');

-- --------------------------------------------------------

--
-- Table structure for table `exercise_set`
--

DROP TABLE IF EXISTS `exercise_set`;
CREATE TABLE IF NOT EXISTS `exercise_set` (
  `clientID` int(11) NOT NULL,
  `workoutLog_date` date NOT NULL,
  `workoutLog_time` time NOT NULL,
  `type` varchar(30) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `set_number` int(2) NOT NULL,
  `reps` int(2) NOT NULL,
  `weight` int(3) NOT NULL,
  PRIMARY KEY (`clientID`,`workoutLog_date`,`workoutLog_time`,`type`,`set_number`),
  KEY `exercise_set_ibfk_2` (`workoutLog_date`),
  KEY `exercise_set_ibfk_3` (`workoutLog_time`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `exercise_set`
--

INSERT INTO `exercise_set` (`clientID`, `workoutLog_date`, `workoutLog_time`, `type`, `set_number`, `reps`, `weight`) VALUES
(0, '2021-04-14', '17:25:12', 'Bench Press', 1, 12, 100),
(0, '2021-04-14', '17:25:12', 'Bench Press', 2, 10, 100),
(0, '2021-04-14', '17:25:12', 'Bench Press', 3, 8, 100),
(0, '2021-04-14', '17:25:12', 'Sqaut', 1, 8, 135),
(0, '2021-04-14', '17:25:12', 'Squat', 2, 8, 125),
(0, '2021-04-14', '17:25:12', 'Squat', 3, 8, 115);

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
  PRIMARY KEY (`instructor_authorID`,`name`),
  KEY `name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `fitness_prgrm`
--

INSERT INTO `fitness_prgrm` (`instructor_authorID`, `name`, `description`, `creation_date`, `routine`, `inst_vid`, `training_type`, `exercise_modality`) VALUES
(2, 'Seniors Cardio Training Porgra', 'ed lobortis elit non ex porttitor lacinia. Nulla facilisi. Nulla non mi in nulla aliquam dictum. Mauris eu blandit tellus. Sed in odio orci. Praesent efficitur quam sed ultrices tincidunt. Proin euismod pretium risus. Sed congue mi erat, ut mattis tortor tristique a. Sed lobortis efficitur iaculis. Praesent aliquam commodo urna non dapibus. Phasellus in semper enim. Maecenas commodo eu orci eu pulvinar. Phasellus ac eleifend eros, ut posuere ipsum. In hac habitasse platea dictumst. Nam aliquet tellus ac tellus imperdiet elementum eu in sem. Mauris lacinia ante a eros ultricies, ac varius massa tempor. ', '2020-11-18 10:12:23', ' Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent mauris orci, placerat id tincidunt vel, vehicula eget nunc. Phasellus sollicitudin pulvinar est at hendrerit. Aenean at diam id eros eleifend imperdiet quis nec quam. Ut tortor turpis, egestas eleifend auctor sed, vehicula in elit. Morbi quam arcu, viverra condimentum rhoncus non, malesuada ac sapien. Aenean tellus quam, ullamcorper a egestas in, vestibulum a est. Proin laoreet lacinia faucibus. Phasellus varius libero nec tempor suscipit. Integer pretium massa sed fermentum varius. Morbi suscipit hendrerit tortor, sed sagittis ligula finibus sed. Cras diam sem, cursus molestie mauris sed, laoreet hendrerit turpis. In eget tortor in libero facilisis malesuada vel sit amet ipsum. Pellentesque nisi ligula, commodo nec risus et, pharetra hendrerit velit. Donec neque sem, ornare a velit vulputate, pulvinar tempor ex. Sed malesuada gravida massa vitae placerat.\r\n\r\nNullam non tincidunt massa. Etiam augue odio, molestie eget est a, ultricies viverra lacus. Phasellus et porta ex. Integer volutpat a orci quis ornare. Nulla facilisi. Quisque sagittis, diam et lacinia vulputate, lectus ligula porta mauris, vel aliquet dolor enim eget tellus. Maecenas et justo vitae justo faucibus luctus sit amet eu est. Sed ac justo diam. ', 'https://www.youtube.com/watch?v=aViIzXtqi8c', 'Interval Training', 'Cardio'),
(3, 'Agility Training for Football', 'Cras purus tellus, accumsan id lobortis vitae, luctus et libero. Donec quis euismod lacus. Nam nulla leo, congue non hendrerit quis, iaculis vitae metus. Curabitur a elit id libero cursus sodales in sed purus. Mauris sit amet turpis in lacus ullamcorper scelerisque. Fusce faucibus mauris eget mauris venenatis pellentesque. Donec elementum turpis mauris, non vehicula metus sodales in. Pellentesque pulvinar dapibus metus a fermentum. ', '2021-01-07 14:26:00', ' Sed lobortis elit non ex porttitor lacinia. Nulla facilisi. Nulla non mi in nulla aliquam dictum. Mauris eu blandit tellus. Sed in odio orci. Praesent efficitur quam sed ultrices tincidunt. Proin euismod pretium risus. Sed congue mi erat, ut mattis tortor tristique a. Sed lobortis efficitur iaculis. Praesent aliquam commodo urna non dapibus. Phasellus in semper enim. Maecenas commodo eu orci eu pulvinar. Phasellus ac eleifend eros, ut posuere ipsum. In hac habitasse platea dictumst. Nam aliquet tellus ac tellus imperdiet elementum eu in sem. Mauris lacinia ante a eros ultricies, ac varius massa tempor.\r\n\r\nFusce sed finibus diam. Phasellus tortor lacus, varius non dolor sed, ultrices commodo lorem. Maecenas nec consequat nunc, sed convallis velit. Fusce pellentesque vehicula urna, ut auctor dui sagittis sit amet. Proin pellentesque consequat blandit. Suspendisse eget feugiat orci. Ut vestibulum, nunc id euismod venenatis, dolor justo iaculis urna, pellentesque consequat turpis velit non purus. In in mi rhoncus, commodo dolor eu, vehicula dolor. Vivamus ut rutrum risus. Donec non volutpat lorem, id hendrerit massa. Proin vestibulum, erat sit amet tincidunt pharetra, magna mi porttitor odio, a vulputate ipsum ipsum auctor ipsum. Mauris quis nunc leo. Nulla facilisi. In lobortis vitae quam malesuada sollicitudin. Aliquam vitae pulvinar elit, in fermentum lorem. ', 'https://www.youtube.com/watch?v=3ew2m3m5f0M', 'Agility', 'Flexiblity and Cardio'),
(3, 'Strength Training for Football', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras faucibus tempus urna, sollicitudin consequat tellus maximus ut. Aenean vulputate lorem vitae leo lacinia, et fringilla lectus porttitor. Proin nisl augue, consequat eget sapien et, molestie commodo diam. Mauris turpis libero, ullamcorper ac aliquet in, imperdiet ac enim. Cras sed consectetur risus, sit amet vehicula elit. Suspendisse eu congue urna. Suspendisse vitae ullamcorper urna. Nam in dapibus nunc. Maecenas venenatis, arcu sit amet cursus ultrices, ex lectus malesuada urna, ac mattis leo nisi ac est. ', '2020-09-23 09:31:31', ' Maecenas mattis, diam sed suscipit maximus, metus neque lacinia tellus, sit amet accumsan dolor ante ut ex. Suspendisse at neque dui. Donec a nulla dolor. Mauris placerat, eros in condimentum rutrum, ligula nisi convallis sem, a porta nunc neque id erat. Ut varius luctus purus. Mauris consequat egestas quam, vel venenatis augue dignissim et. In eleifend scelerisque facilisis. Fusce quis dui lacus. Suspendisse hendrerit lectus eget rutrum malesuada. Aliquam vel aliquet nunc.\r\n\r\nSuspendisse eu arcu et felis suscipit dignissim. In feugiat mattis lectus in pulvinar. Cras ornare ultricies efficitur. Vivamus dictum iaculis dui vitae lacinia. Sed vitae egestas velit. Curabitur nec dapibus tellus. Aliquam tincidunt feugiat lorem, nec mattis metus pulvinar ac. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Sed sollicitudin nibh metus, nec ultricies enim mattis sit amet.\r\n\r\nDonec ut sem nibh. Morbi nibh augue, tempus non rhoncus tincidunt, venenatis eu nisl. Praesent interdum nisl ex, et faucibus ligula gravida vitae. Donec ultrices vel magna et blandit. Praesent ut enim malesuada lacus pretium varius. Donec non sagittis felis. Etiam tincidunt molestie aliquet. Proin convallis ultricies lacinia. In finibus, sem non hendrerit elementum, ante eros rutrum nisl, et molestie metus sapien et eros. Cras hendrerit quam non leo posuere tempus. Nunc lobortis vulputate ipsum sit amet laoreet. ', 'https://www.youtube.com/watch?v=Um_w06BpxJ8', 'Strength', 'Continuous Training');

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
  PRIMARY KEY (`following_client`,`followed_dietician`,`followed_nutrition_plan`),
  KEY `follows_ibfk_2` (`followed_dietician`),
  KEY `follows_ibfk_3` (`followed_nutrition_plan`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `follows`
--

INSERT INTO `follows` (`following_client`, `followed_dietician`, `followed_nutrition_plan`, `join_dateTime`) VALUES
(0, 6, 'The weight gain Muscle Meal pl', '2021-04-24 11:21:32'),
(1, 5, 'Vegan Body For Life Diet', '2021-03-11 09:19:22');

-- --------------------------------------------------------

--
-- Table structure for table `food_log`
--

DROP TABLE IF EXISTS `food_log`;
CREATE TABLE IF NOT EXISTS `food_log` (
  `clientID` int(9) NOT NULL,
  `log_date` date NOT NULL,
  `log_time` time NOT NULL,
  `meal_desc` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `protein` int(2) NOT NULL COMMENT 'grams (g)',
  `carbohydrates` int(2) NOT NULL COMMENT 'grams (g)',
  `fat` int(2) NOT NULL COMMENT 'grams (g)',
  `calories` int(2) NOT NULL COMMENT 'grams (g)',
  PRIMARY KEY (`clientID`,`log_date`,`log_time`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `food_log`
--

INSERT INTO `food_log` (`clientID`, `log_date`, `log_time`, `meal_desc`, `protein`, `carbohydrates`, `fat`, `calories`) VALUES
(0, '2021-02-10', '14:16:00', 'Eggs on Toast', 15, 26, 10, 155),
(1, '2021-04-12', '18:10:17', 'Steak and Eggs', 80, 40, 12, 213);

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

--
-- Dumping data for table `instructor`
--

INSERT INTO `instructor` (`instructorID`, `client_pop`, `training_philosophy`, `accredidation`) VALUES
(2, 'Elderly people aged 40-60', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer mi urna, consectetur nec semper vel, blandit congue odio. Nulla eu dolor volutpat, ultricies tortor a, maximus felis. Morbi ullamcorper viverra turpis quis fermentum. Pellentesque ullamcorper rhoncus nulla non efficitur. Nulla facilisi. Integer sit amet fermentum lacus. Integer arcu mi, rhoncus et eros quis, congue malesuada velit.', 'American Council on Exercise:\r\nAenean accumsan, nibh at gravida luctus, nulla est iaculis odio, at venenatis augue risus ut lacus. Vestibulum ac consequat elit, in elementum nulla. Curabitur aliquet efficitur faucibus. Curabitur porttitor diam vel tortor finibus, in pharetra arcu rutrum. Nam placerat felis sed mi semper hendrerit eu sodales nisl. Fusce placerat sem non arcu hendrerit, in suscipit eros mattis. Nullam vulputate massa vel neque faucibus scelerisque.'),
(3, 'Young Adults aged 20-30 years', 'Nullam egestas lobortis volutpat. Aenean eu dui porttitor, porta ex placerat, condimentum elit. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Pellentesque id enim mauris. Vestibulum luctus posuere purus, sit amet volutpat risus tincidunt sit amet. Curabitur mollis nec massa consectetur sollicitudin. ', 'International Fitness Association:\r\nonsectetur adipiscing elit. Phasellus malesuada lacus at nisi blandit, id ullamcorper sem efficitur. Quisque hendrerit metus diam, a blandit justo ornare sed. Aenean viverra tellus sed augue convallis molestie. Aliquam vel aliquam ex. Nunc ultrices massa velit. Ut porta, nisi vel accumsan ornare, est odio sollicitudin lacus, quis consequat ipsum enim non orci.'),
(4, 'Youths aged 18-24', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec non vestibulum tellus, eu tincidunt elit. Nullam laoreet magna nec augue congue fringilla. Proin rhoncus dapibus dui non tincidunt. Lorem ipsum dolor sit amet, consectetur adipiscing elit. In mattis mi eget vulputate viverra. Donec a congue nisi. Nullam condimentum, lacus in sollicitudin bibendum, diam sapien pharetra justo, accumsan laoreet felis ex eget orci. Donec tristique tellus eget feugiat finibus. Aliquam semper ligula et elit rutrum, vitae convallis dui porta.', 'Ylab school of Health and Training:\r\nNulla sed facilisis lacus. Maecenas rhoncus, turpis eget ullamcorper molestie, nisl neque finibus libero, vel eleifend lectus lacus at massa. Donec mattis tincidunt nisi quis vehicula. Maecenas ac turpis sed nisl facilisis dictum sed venenatis est. Fusce eget nibh eget erat interdum lobortis. Sed elementum commodo eleifend. Donec ac augue in nisl lacinia consectetur eget non turpis. ');

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
  PRIMARY KEY (`joining_client`,`joined_inst`,`joined_fitness_prgm`),
  KEY `joins_ibfk_2` (`joined_inst`),
  KEY `joins_ibfk_3` (`joined_fitness_prgm`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `joins`
--

INSERT INTO `joins` (`joining_client`, `joined_inst`, `joined_fitness_prgm`, `join_dateTime`) VALUES
(0, 2, 'Seniors Cardio Training Porgra', '2021-01-07 11:45:27'),
(1, 3, 'Strength Training for Football', '2021-02-17 09:34:44');

-- --------------------------------------------------------

--
-- Table structure for table `link`
--

DROP TABLE IF EXISTS `link`;
CREATE TABLE IF NOT EXISTS `link` (
  `linker_page` int(9) NOT NULL,
  `linked_page` int(9) NOT NULL,
  PRIMARY KEY (`linker_page`,`linked_page`),
  KEY `link_ibfk_1` (`linked_page`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `link`
--

INSERT INTO `link` (`linker_page`, `linked_page`) VALUES
(4, 0),
(1, 3);

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
  PRIMARY KEY (`dietician_authorID`,`name`),
  KEY `name` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `nutrition_plan`
--

INSERT INTO `nutrition_plan` (`dietician_authorID`, `name`, `description`, `creation_date`, `grocery_list`, `meal_plan`) VALUES
(5, 'Vegan Body For Life Diet', 'Ut quis scelerisque urna. Praesent laoreet sem nec massa laoreet gravida. Duis at purus sit amet sem sagittis congue. Maecenas erat quam, sollicitudin id sagittis ultrices, convallis in nisl. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut pharetra tortor finibus, varius felis sit amet, congue arcu. Integer pretium quis tortor rhoncus feugiat. Duis nec sem et lectus dignissim convallis. ', '2021-02-17 09:31:14', ' Lorem ipsum dolor sit amet, consectetur adipiscing elit. In suscipit ullamcorper pellentesque. Ut vitae orci nulla. Nulla vestibulum nunc ut rhoncus viverra. Pellentesque et quam vel est mattis imperdiet nec quis urna. In pulvinar cursus nisi at vulputate. Proin porttitor interdum cursus. Curabitur venenatis libero urna, ut pharetra risus lacinia eu. Ut maximus vestibulum eleifend. Suspendisse dui est, eleifend auctor purus eget, rhoncus iaculis velit. Maecenas in pellentesque est. Morbi a porttitor eros, ut porttitor augue. Nullam elementum volutpat tellus, sed vulputate augue tristique et. Fusce sit amet sapien scelerisque, egestas libero quis, egestas quam. Nulla tincidunt magna eget pulvinar placerat. Quisque tristique eu enim id commodo.\r\n\r\nLorem ipsum dolor sit amet, consectetur adipiscing elit. Integer volutpat faucibus elit at laoreet. Phasellus ornare vel lacus ut placerat. Cras posuere vel tortor ut hendrerit. Sed finibus lacus et arcu auctor aliquam. Aliquam erat volutpat. Mauris vulputate est ac pulvinar venenatis. Vestibulum sit amet convallis ante. Nunc vel lorem ornare, eleifend ante et, facilisis felis. Mauris eu mi vel lacus accumsan varius placerat ac tellus. Nam lobortis sem dui, vel bibendum augue fermentum eu. Duis molestie a diam a accumsan. Suspendisse non sapien dignissim, placerat nulla non, blandit dui. Donec lacinia lacus eget elementum sagittis. Phasellus id odio aliquam, hendrerit augue eget, dapibus enim. ', ' Sed non laoreet urna, vitae maximus tortor. Fusce quis varius orci. Proin fermentum, sapien a mollis commodo, libero sem tempus massa, in ultrices ex purus sed justo. Vestibulum consequat ligula ac ipsum molestie laoreet. Ut elementum sem luctus, vulputate nulla vitae, faucibus mi. Vestibulum varius, eros eu finibus imperdiet, massa nisl lobortis justo, ac lobortis est ante luctus nisl. Donec id augue lorem. Phasellus orci orci, rhoncus ac nisi sed, dapibus aliquet est. Aenean feugiat nulla sed tortor fringilla sodales. Aliquam erat volutpat. Aenean rutrum at ex non semper. Nunc hendrerit mattis nunc, nec venenatis lacus vestibulum et. Ut non dignissim eros.\r\n\r\nClass aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Mauris nec elit justo. Nulla lacinia risus et ante aliquet, sed mollis tellus scelerisque. Curabitur congue tellus tempus malesuada laoreet. Praesent hendrerit varius urna quis dapibus. Fusce nec orci in nisi finibus scelerisque id quis lorem. Vestibulum maximus ante vestibulum lacinia hendrerit. '),
(6, 'The weight gain Muscle Meal pl', 'Pellentesque sagittis urna in facilisis dignissim. Pellentesque sed sagittis odio, sed commodo turpis. Ut fermentum quam eu nibh gravida, eu rhoncus tellus porta. Suspendisse ac suscipit diam. Integer fermentum turpis ac ante eleifend ornare. Etiam porta ex magna, ut vulputate diam tempus eu. Aenean faucibus metus neque, eget sodales ante varius non. Integer laoreet tortor at sem consequat mattis. Quisque eu purus sit amet massa tincidunt euismod. Pellentesque eu auctor arcu. Proin imperdiet venenatis ornare. Ut nec tincidunt mi, quis tempor urna. Aenean gravida, ex sit amet egestas scelerisque, neque magna convallis lacus, eget tempor tortor nulla in lectus. In commodo orci tortor, sit amet rutrum nunc efficitur mollis. ', '2021-02-04 09:15:20', ' Cras fringilla mi non libero finibus cursus. Maecenas rhoncus laoreet feugiat. Pellentesque accumsan lectus vitae justo egestas elementum. Nulla porttitor, odio tempus euismod auctor, erat massa vulputate quam, non sollicitudin turpis ligula id diam. Duis consequat porta neque vitae cursus. Nullam lobortis nisi gravida, blandit diam sit amet, mattis metus. Etiam dictum semper nulla. Donec consectetur rhoncus nulla, accumsan sagittis dui ultricies quis. Nulla nulla eros, rhoncus eget porta non, rutrum id lectus. Nam interdum, ante nec semper convallis, felis libero efficitur nunc, nec auctor lorem nulla vel tortor. In porta, felis accumsan sollicitudin elementum, mauris arcu tincidunt ex, at molestie tortor nunc et risus. Nullam finibus tristique turpis, nec volutpat massa convallis et. Cras ut ligula nec ante commodo consequat. Integer vitae mauris at lectus sodales sollicitudin. Aenean lacinia, metus et pulvinar gravida, mi ex mattis neque, eu ornare ligula sapien ut ipsum.\r\n\r\nNulla bibendum lectus felis, eu hendrerit est volutpat in. Ut in lacus odio. Ut massa risus, tincidunt eu dapibus vel, rhoncus dictum felis. Nunc quis diam eget risus cursus porta. Proin porttitor posuere felis, in maximus tellus sodales sit amet. Aliquam tempor congue mauris. In iaculis laoreet nunc a semper. In euismod posuere consequat.\r\n\r\nSed vel ipsum ut leo sodales molestie. Duis sed eros tortor. Sed vel volutpat felis, eget condimentum neque. Pellentesque pellentesque lectus vel velit fermentum, ut molestie tortor accumsan. Etiam vel erat mauris. Cras a sodales nisl. Aliquam tortor dolor, ultricies ac feugiat et, bibendum vitae nisi. ', '\r\n\r\nLorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus sed tellus felis. Nunc pretium, risus eu posuere cursus, sem orci euismod risus, at posuere justo eros ac diam. Nunc nunc mauris, tincidunt ut pharetra ac, lacinia et neque. Donec eu dui sed ex pharetra suscipit in et ex. Integer mollis orci a quam mattis tincidunt. Cras ac semper neque, a cursus ante. Fusce at semper purus. Nulla mattis mauris ac sapien dignissim luctus. Curabitur eget facilisis mi, eu gravida augue. Nullam tempor, velit id accumsan dignissim, sem turpis pulvinar ex, ac vestibulum nunc augue at augue. Sed leo libero, mattis eu erat a, venenatis condimentum urna. Maecenas nisl justo, eleifend in auctor ac, auctor at leo. Quisque ultrices rhoncus erat, sit amet gravida lectus vestibulum at. Maecenas facilisis, risus sit amet hendrerit pretium, nunc felis malesuada sem, sit amet ultricies ligula tortor in urna. ');

-- --------------------------------------------------------

--
-- Table structure for table `page`
--

DROP TABLE IF EXISTS `page`;
CREATE TABLE IF NOT EXISTS `page` (
  `pageID` int(9) NOT NULL,
  `content` text NOT NULL,
  `topic` varchar(30) NOT NULL,
  `view_count` int(15) NOT NULL DEFAULT '0',
  `author` varchar(30) NOT NULL,
  `write_date` date NOT NULL,
  PRIMARY KEY (`pageID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `page`
--

INSERT INTO `page` (`pageID`, `content`, `topic`, `view_count`, `author`, `write_date`) VALUES
(0, ' Donec vehicula dictum turpis ac cursus. Nulla id enim fringilla, sodales turpis eu, rhoncus sem. Praesent nec metus eu orci viverra pulvinar eget et justo. Duis dignissim felis id lacus aliquet sollicitudin. Sed vel tempus magna, finibus lobortis nisi. Vestibulum at tortor luctus, rhoncus ipsum ut, aliquet magna. Suspendisse potenti. Mauris erat nulla, congue et lacus quis, congue imperdiet lectus. Curabitur et velit volutpat, pharetra urna at, semper augue. Aenean in justo feugiat turpis varius pellentesque. Donec eleifend eu nisi ut imperdiet. Sed vestibulum consequat justo vehicula pretium. Nam ultrices nunc enim, quis pulvinar erat tempus rhoncus. Quisque in interdum tortor. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.\r\n\r\nMorbi consectetur, tortor id pulvinar semper, quam mauris consectetur ligula, eget interdum nibh ipsum eget urna. Mauris eget sem lacus. Pellentesque ac purus facilisis, cursus arcu in, tempor enim. Sed massa dui, euismod consequat efficitur in, tempor vel odio. Fusce scelerisque lectus id felis ornare, eu congue augue sagittis. Donec vehicula et nibh eu dignissim. Etiam non hendrerit dui. Nunc pretium hendrerit efficitur. Donec imperdiet rutrum tellus sit amet congue. Suspendisse faucibus bibendum nibh non pretium. Nam aliquam nisi nunc, eu mollis nisl rutrum in. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam ornare tempor elementum. Pellentesque sit amet ante eu enim sollicitudin tincidunt. Aliquam iaculis dignissim purus, at tempor diam euismod vel. ', 'Weightlifting', 15, 'Bruce Jhonson', '2021-02-24'),
(1, ' Vivamus ex elit, pellentesque id luctus sit amet, maximus ac nibh. Aliquam tempor neque vitae nisl pellentesque, nec hendrerit tellus pulvinar. Duis finibus ipsum efficitur enim dictum, a luctus libero venenatis. In purus libero, placerat ac nisi sit amet, maximus rutrum purus. Maecenas eu libero ex. Aliquam id risus aliquet, aliquet ex a, aliquet libero. Morbi maximus justo vel dapibus aliquet. Mauris eget odio dui. In hac habitasse platea dictumst. Nam consectetur erat dui, in euismod justo tincidunt et. Sed laoreet eros quis mauris ultrices, eget luctus leo imperdiet. Maecenas et eros at tellus blandit egestas vitae in lectus. Proin imperdiet lacus sit amet posuere condimentum.\r\n\r\nAliquam erat volutpat. In gravida porttitor erat eu tincidunt. Pellentesque molestie arcu id nisl viverra, non finibus odio blandit. Quisque blandit, purus ac mattis tempus, lorem sem sollicitudin nibh, eget placerat libero tellus quis nisi. Vestibulum sodales tristique felis et vestibulum. Maecenas rhoncus ultrices tellus vitae varius. Nam tincidunt augue sit amet semper lacinia. Vestibulum tristique consectetur mi sit amet convallis. Duis erat ante, ullamcorper non diam nec, porttitor porta mauris. Cras a justo a nunc malesuada bibendum quis vitae metus. Nam vel pellentesque ex. Fusce et blandit tortor. Pellentesque libero mi, consequat a scelerisque at, tempor nec est. Etiam elementum pulvinar leo, eu bibendum enim vestibulum sed. Nam ut augue erat. Vivamus ultricies, leo vitae vestibulum condimentum, lectus nisi imperdiet velit, id auctor odio purus sit amet nisl. ', 'Cardio Training In Winter Cond', 22, 'Jeanna Jannovich', '2021-04-12'),
(2, ' Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras finibus urna ut ligula pellentesque egestas. Mauris ut risus sed elit elementum mattis at at tellus. Proin finibus fringilla fermentum. Etiam auctor neque a nunc tincidunt, vel sodales quam hendrerit. Etiam et est diam. Phasellus convallis erat eu nibh facilisis mattis. Cras et ex vitae lorem tempor facilisis.\r\n\r\nEtiam commodo, tellus et tincidunt egestas, eros sapien vulputate nunc, ac porta ligula lorem eu magna. Fusce in rutrum magna, nec finibus nulla. Morbi efficitur convallis est, nec rutrum nibh dignissim ut. Nunc consequat placerat tempus. Nam vitae auctor dui. Quisque aliquet sagittis tortor sit amet finibus. Suspendisse quis egestas tellus. Ut fermentum neque vel accumsan dignissim. Donec lobortis accumsan neque, in porta quam fermentum a. Vestibulum sed ornare mi. Maecenas lacinia leo purus, quis consequat est tincidunt vel. Maecenas mattis nec diam id pellentesque. Duis eleifend faucibus ex, sit amet porttitor velit sodales in. Aliquam posuere dolor sem, non malesuada nisi molestie eget. ', '100 Ideas for a Vegan Christma', 10, 'Ahmed Salem', '2017-12-10'),
(3, ' Cras pharetra odio non tellus ultricies, nec accumsan ligula laoreet. Nunc at convallis velit. Morbi sagittis lorem at lectus placerat euismod. Sed quis auctor lacus. Sed imperdiet nulla ac justo ultricies interdum. Vivamus finibus velit hendrerit arcu pretium euismod. Pellentesque pretium imperdiet augue a faucibus.\r\n\r\nAliquam aliquam, purus a pharetra scelerisque, velit augue tincidunt mauris, non scelerisque ante libero ac dui. Suspendisse semper, libero in pulvinar pellentesque, ipsum justo lacinia purus, vel pharetra diam sapien sed neque. Quisque mi tellus, maximus ac mollis luctus, ultrices sed urna. Donec vestibulum diam ac arcu viverra consectetur. Maecenas suscipit tempus aliquam. Phasellus in eros ac neque pellentesque iaculis. Phasellus et faucibus libero. Nullam turpis lacus, posuere eget diam at, pretium auctor augue. Sed eleifend porttitor mi id ultricies. Nulla facilisi. Praesent porttitor tortor sed justo bibendum aliquet. Proin neque nunc, suscipit vel condimentum eu, consectetur non libero. Nulla facilisi. Mauris vitae luctus urna. Proin egestas mi mauris, et vehicula eros tristique et. ', 'The Top 10 Hicking trails in K', 345, 'Yolanda Smith', '2013-11-11'),
(4, ' Aliquam erat volutpat. Mauris a diam diam. Pellentesque mauris ligula, fringilla tempor metus id, mattis aliquet nulla. Vestibulum mollis nisl efficitur massa porta, quis pretium ante posuere. Proin non tortor enim. Pellentesque id rutrum ipsum, in consectetur elit. Morbi in mollis ipsum, vel tempus nisl. In ultricies volutpat nisi, eu ultricies leo rhoncus et. Duis varius neque vitae quam mattis facilisis. Maecenas id nisl libero. Vestibulum est nunc, vehicula quis molestie at, tempor a erat.\r\n\r\nAliquam ultrices commodo erat, in porttitor velit venenatis id. Fusce purus ipsum, volutpat eget convallis in, efficitur quis enim. Vestibulum libero nisi, porttitor non suscipit nec, scelerisque ac sapien. Morbi id purus finibus, fringilla nibh vulputate, tempus erat. Curabitur id auctor arcu. Nulla facilisi. Donec et porta orci. Morbi non metus commodo massa dictum bibendum. Sed ac blandit sem. Aliquam pulvinar eget metus eu auctor. Morbi a elementum ante, a semper ex. Nulla id urna venenatis, molestie elit eu, euismod odio. Phasellus iaculis turpis vel accumsan egestas.\r\n\r\nMaecenas euismod et enim in suscipit. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean suscipit vitae elit sed scelerisque. Mauris metus dolor, lacinia id leo vitae, rhoncus fermentum diam. Praesent eu felis eu justo eleifend dapibus aliquam non tortor. Vestibulum vitae ullamcorper dolor, eget luctus elit. Etiam in finibus mi. ', 'The 8 best kept secrets to a B', 231, 'Johnny Depp', '2021-04-26');

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
  KEY `rates_ibfk_2` (`ratedSpecialist`)
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

--
-- Dumping data for table `sleep_log`
--

INSERT INTO `sleep_log` (`clientID`, `date`, `time`, `duration`) VALUES
(0, '2021-04-12', '20:10:05', 8),
(1, '2021-04-16', '19:10:21', 6);

-- --------------------------------------------------------

--
-- Table structure for table `specialist`
--

DROP TABLE IF EXISTS `specialist`;
CREATE TABLE IF NOT EXISTS `specialist` (
  `specialistID` int(9) NOT NULL,
  `current_employment` varchar(100) DEFAULT 'unemployed',
  `reviewer` int(1) NOT NULL DEFAULT '0',
  `rating` int(3) NOT NULL DEFAULT '0',
  `phone` int(15) NOT NULL,
  `email` varchar(50) NOT NULL,
  PRIMARY KEY (`specialistID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `specialist`
--

INSERT INTO `specialist` (`specialistID`, `current_employment`, `reviewer`, `rating`, `phone`, `email`) VALUES
(2, 'unemployed', 0, 70, 3316785, 'bEyeLash334@gmail.com'),
(3, 'Golds Gym', 0, 80, 4569987, 'JJeanna@live.com'),
(4, 'IronClad Fitness', 1, 77, 3424423, 'BJhonson@gmail.com'),
(5, 'University of Calgary', 0, 65, 5553469, 'Ahmed.Salem@ucalgary.ca'),
(6, 'Health Stand Nutrition Consulting', 0, 0, 5546789, 'yolanS@gmail.com');

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
  `view_count` int(20) NOT NULL DEFAULT '0',
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
  `log_date` date NOT NULL,
  `start_time` time NOT NULL,
  `end_time` time NOT NULL,
  `calories_burned` int(3) NOT NULL,
  PRIMARY KEY (`clientID`,`log_date`,`start_time`),
  KEY `log_date` (`log_date`),
  KEY `start_time` (`start_time`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `workout_log`
--

INSERT INTO `workout_log` (`clientID`, `log_date`, `start_time`, `end_time`, `calories_burned`) VALUES
(0, '2021-04-14', '17:25:12', '18:15:08', 1300);

-- --------------------------------------------------------

--
-- Table structure for table `writes`
--

DROP TABLE IF EXISTS `writes`;
CREATE TABLE IF NOT EXISTS `writes` (
  `specialistID` int(9) NOT NULL,
  `written_page` int(9) NOT NULL,
  PRIMARY KEY (`specialistID`,`written_page`),
  KEY `writes_ibfk_2` (`written_page`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `writes`
--

INSERT INTO `writes` (`specialistID`, `written_page`) VALUES
(4, 0),
(3, 1),
(5, 2),
(6, 3);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `cardio_log`
--
ALTER TABLE `cardio_log`
  ADD CONSTRAINT `cardio_log_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `client` (`clientID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `client`
--
ALTER TABLE `client`
  ADD CONSTRAINT `client_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `user` (`userID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `dietician`
--
ALTER TABLE `dietician`
  ADD CONSTRAINT `dietician_ibfk_1` FOREIGN KEY (`dieticianID`) REFERENCES `specialist` (`specialistID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `exercise_set`
--
ALTER TABLE `exercise_set`
  ADD CONSTRAINT `exercise_set_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `workout_log` (`clientID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `exercise_set_ibfk_2` FOREIGN KEY (`workoutLog_date`) REFERENCES `workout_log` (`log_date`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `exercise_set_ibfk_3` FOREIGN KEY (`workoutLog_time`) REFERENCES `workout_log` (`start_time`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `fitness_prgrm`
--
ALTER TABLE `fitness_prgrm`
  ADD CONSTRAINT `fitness_prgrm_ibfk_1` FOREIGN KEY (`instructor_authorID`) REFERENCES `instructor` (`instructorID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `follows`
--
ALTER TABLE `follows`
  ADD CONSTRAINT `follows_ibfk_1` FOREIGN KEY (`following_client`) REFERENCES `client` (`clientID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `follows_ibfk_2` FOREIGN KEY (`followed_dietician`) REFERENCES `nutrition_plan` (`dietician_authorID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `follows_ibfk_3` FOREIGN KEY (`followed_nutrition_plan`) REFERENCES `nutrition_plan` (`name`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `food_log`
--
ALTER TABLE `food_log`
  ADD CONSTRAINT `food_log_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `client` (`clientID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `instructor`
--
ALTER TABLE `instructor`
  ADD CONSTRAINT `instructor_ibfk_1` FOREIGN KEY (`instructorID`) REFERENCES `specialist` (`specialistID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `joins`
--
ALTER TABLE `joins`
  ADD CONSTRAINT `joins_ibfk_1` FOREIGN KEY (`joining_client`) REFERENCES `client` (`clientID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `joins_ibfk_2` FOREIGN KEY (`joined_inst`) REFERENCES `fitness_prgrm` (`instructor_authorID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `joins_ibfk_3` FOREIGN KEY (`joined_fitness_prgm`) REFERENCES `fitness_prgrm` (`name`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `link`
--
ALTER TABLE `link`
  ADD CONSTRAINT `link_ibfk_1` FOREIGN KEY (`linked_page`) REFERENCES `page` (`pageID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `link_ibfk_2` FOREIGN KEY (`linker_page`) REFERENCES `page` (`pageID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `nutrition_plan`
--
ALTER TABLE `nutrition_plan`
  ADD CONSTRAINT `nutrition_plan_ibfk_1` FOREIGN KEY (`dietician_authorID`) REFERENCES `dietician` (`dieticianID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `rates`
--
ALTER TABLE `rates`
  ADD CONSTRAINT `rates_ibfk_1` FOREIGN KEY (`ratingClient`) REFERENCES `client` (`clientID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `rates_ibfk_2` FOREIGN KEY (`ratedSpecialist`) REFERENCES `specialist` (`specialistID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `sleep_log`
--
ALTER TABLE `sleep_log`
  ADD CONSTRAINT `sleep_log_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `client` (`clientID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `specialist`
--
ALTER TABLE `specialist`
  ADD CONSTRAINT `specialist_ibfk_1` FOREIGN KEY (`specialistID`) REFERENCES `user` (`userID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `view`
--
ALTER TABLE `view`
  ADD CONSTRAINT `view_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `user` (`userID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `view_ibfk_2` FOREIGN KEY (`viewed_page`) REFERENCES `page` (`pageID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `workout_log`
--
ALTER TABLE `workout_log`
  ADD CONSTRAINT `workout_log_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `client` (`clientID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `writes`
--
ALTER TABLE `writes`
  ADD CONSTRAINT `writes_ibfk_1` FOREIGN KEY (`specialistID`) REFERENCES `specialist` (`specialistID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `writes_ibfk_2` FOREIGN KEY (`written_page`) REFERENCES `page` (`pageID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
