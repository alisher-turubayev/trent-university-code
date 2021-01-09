-- phpMyAdmin SQL Dump
-- version 4.8.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 06, 2018 at 03:07 AM
-- Server version: 10.1.32-MariaDB
-- PHP Version: 5.6.36

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `projectdb`
--
CREATE DATABASE IF NOT EXISTS `projectdb` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `projectdb`;

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `customerID` int(11) NOT NULL,
  `custFullName` varchar(100) NOT NULL,
  `paymentMethod` varchar(15) DEFAULT NULL,
  `billingAddress` varchar(255) DEFAULT NULL,
  `shippingAddress` varchar(255) DEFAULT NULL,
  `custPhone` varchar(32) DEFAULT NULL,
  `custEmail` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`customerID`, `custFullName`, `paymentMethod`, `billingAddress`, `shippingAddress`, `custPhone`, `custEmail`) VALUES
(1, 'Francis Bogan', 'americanexpress', '0116 fruition\'s curriculum, tarnishing, database J7W5O5', '5007 nicknaming concocting, storerooms, obliging Q5Z8Y1', '+98-507-136-3853', 'lwimlet0@buzzfeed.com'),
(2, 'Maritza Lueilwitz', 'banktransfer', '7772 compulsory agnostic\'s, rhetorical, inflates L3P8E0', '1329 overhaul\'s publicizes, announcing, studying O0S7R1', '+48-785-268-9578', 'cchicchelli1@reverbnation.com'),
(3, 'Madeleine Runolfsson', 'debitcard', '1711 linchpin\'s quartering, milligrams, éclair\'s C5I0M2', '5732 carefuller eruption\'s, overcoat\'s, inquires N5V2H7', '+27-450-320-3767', 'tmcclymond2@hexun.com'),
(4, 'Trey Daniel', 'other', '8152 infantries metaphor\'s, transacted, survival A3W0X0', '1863 buttressed traveler\'s, antithesis, beguiles V7I5I6', '+62-385-642-1175', 'bsarfat3@about.me'),
(5, 'Lyle Kuhn', 'cheque', '4594 landmark\'s tailgate\'s, primrose\'s, chastens P3D2U6', '0701 clearing\'s dehydrates, panhandled, grille\'s O8H9J1', '+261-429-799-5752', 'zguilbert4@goodreads.com'),
(6, 'Earnest Walker', 'creditcard', '8892 coronary\'s perceiving, inactivity, concrete P9W0B4', '1031 credential scruffiest, explorer\'s, tenacity G6A1A3', '+62-969-827-6573', 'dconisbee5@paginegialle.it'),
(7, 'Nathaniel Simonis', 'cash', '0059 ugliness\'s attracting, percolates, musicals M8M0H0', '6161 instalment minimalism, impeccable, suggests H7P3N1', '+55-136-229-7133', 'leichmann6@google.de'),
(8, 'Lue Wisoky', 'debitcard', '4463 counteract expressive, reiterated, paroling F5R5O8', '5729 mannequins grouping\'s, embezzling, broaches L9I9N5', '+86-174-799-2096', 'aschuchmacher7@newyorker.com'),
(9, 'Jammie Franecki', 'cheque', '0433 smoothness flourish\'s, uniformity, tardiest B8M3K3', '7804 changeable parliament, folklore\'s, tattle\'s U4O0X2', '+33-619-408-0572', 'amackim8@discovery.com'),
(10, 'Sidney Leffler', 'debitcard', '4043 refinery\'s patterning, alteration, arrest\'s D0C2A4', '7225 parameters highjack\'s, elegance\'s, dittoing W7C3I2', '+51-694-438-0247', 'vmac9@buzzfeed.com'),
(11, 'Hipolito Spinka', 'cheque', '3626 humanizing ornamental, reproduced, imparted G8O4O7', '4014 blackening announcing, quandaries, patience S9W6H7', '+86-324-653-1178', 'golivellia@icio.us'),
(12, 'Tommy Treutel', 'cheque', '7722 bannisters pictorials, audacity\'s, compiles X8S9J5', '8136 inherently sustaining, airmailing, railways Z8T5X6', '+370-377-613-4036', 'aplutherob@uiuc.edu'),
(13, 'Connie Gorczany', 'americanexpress', '5356 charisma\'s perspiring, acquainted, shanties S3Z9B3', '0790 housewives fracturing, busybodies, feathers E5T6L8', '+48-445-506-7735', 'jaldwichc@irs.gov'),
(14, 'Elaine Weber', 'cheque', '8511 washable\'s stomaching, schoolboys, fragrant R8W6H4', '0338 forestalls customer\'s, electronic, turnpike A6C6G1', '+62-484-724-6782', 'eadamkiewiczd@huffingtonpost.com'),
(15, 'Leroy Lehner', 'cash', '4913 civilian\'s tightening, bloodhound, burden\'s K5O4N0', '5929 publicized dissipated, pleasanter, stancher V2P0K2', '+1-616-595-3779', 'gworlocke@businessweek.com'),
(16, 'Tanna Sawayn', 'deposit', '3751 positivism tomahawk\'s, newsletter, hacker\'s K5M2Q6', '0976 transverse shampooing, festival\'s, snappier D3Q4W7', '+55-314-846-6553', 'dvillef@vkontakte.ru'),
(17, 'Vonnie Schowalter', 'deposit', '0250 palomino\'s compromise, hundredths, airtight X5V0T5', '7285 crucifying broccoli\'s, cassette\'s, spectrum L2S6V6', '+51-819-197-7506', 'thearnesg@webmd.com'),
(18, 'Randolph Dicki', 'other', '8086 finalist\'s femininity, bridegroom, Sunday\'s D7R4C4', '7314 dissonance mosquitoes, inventions, location S0M6A2', '+86-231-399-4972', 'gheiferh@printfriendly.com'),
(19, 'Delores Emmerich', 'deposit', '7381 disguising armadillos, grapevines, revise\'s K1C4M0', '3840 heightened pinpoint\'s, artistry\'s, cleansed J3H1B0', '+33-178-522-9630', 'dbeckworthi@free.fr'),
(20, 'Gil Ernser', 'cheque', '3549 appendages marshalled, serviceman, perjures S2A6M7', '9458 gravestone nursemaids, vocabulary, shunning O7F4I6', '+48-243-816-8601', 'gholburyj@yellowbook.com'),
(21, 'Aron Feil', 'banktransfer', '6506 topography platform\'s, rendezvous, neuroses P0S2E7', '3646 scurrilous woodchucks, assurances, likewise M5V3V8', '+1-601-234-4725', 'bcawthornk@gizmodo.com'),
(22, 'Sung Kassulke', 'other', '2760 wrapping\'s morphology, pretenders, sizzling I9R6D1', '2609 disclosing comedian\'s, repudiated, thoughts R6H5K4', '+62-443-439-7536', 'tbattamsl@arstechnica.com'),
(23, 'Sunny Wilkinson', 'cheque', '1820 dispersing perversion, narcotic\'s, iodine\'s P5K5F2', '7503 mosquito\'s suspicious, neighborly, opaquing H8K6W8', '+33-157-815-4674', 'scumingm@discuz.net'),
(24, 'Oralee Jacobi', 'other', '7204 employer\'s equation\'s, perversion, receives S1C1G9', '2148 cashmere\'s liniment\'s, intruder\'s, drinking L7K9M4', '+81-512-845-0429', 'npardin@facebook.com'),
(25, 'Malcom Schuster', 'debitcard', '1896 nativity\'s sprinkle\'s, intriguing, quarried M9B6M8', '8551 recharging annotation, calmness\'s, beguiled X5Q4X7', '+48-942-434-9275', 'abrinklowo@imageshack.us'),
(26, 'Marty Prosacco', 'banktransfer', '9716 confronted annotating, horrendous, refund\'s K5K0N2', '7462 mortuaries derailment, commission, prison\'s P0U5C6', '+56-151-574-6761', 'bfuscop@shareasale.com'),
(27, 'Devon Beer', 'creditcard', '6532 outbreak\'s rediscover, débutantes, filter\'s A3U3B6', '1936 coniferous watchdog\'s, blasphemes, pastured S0T5T2', '+387-411-286-4168', 'mmarranq@usa.gov'),
(28, 'Stephan Mertz', 'creditcard', '9128 stringiest thunderous, permanents, cellular T5W6L6', '8580 uninspired afterwards, displacing, format\'s Y0R3F7', '+86-684-162-2932', 'nvendittor@ucla.edu'),
(29, 'Leonor Kreiger', 'creditcard', '7544 designates aircraft\'s, cassette\'s, strangle X6Y9Y1', '8779 soliciting paddocking, cartoonist, accented K5L3S3', '+86-485-278-5315', 'smccrofts@go.com'),
(30, 'Ron Abernathy', 'deposit', '9442 business\'s dispossess, blackboard, britches U7L3B2', '1987 destroying afterwards, hamburgers, freshman K4L8Q8', '+7-355-390-8367', 'zyepiskopovt@oaic.gov.au'),
(31, 'Kiesha Harris', 'americanexpress', '4032 tolerating critique\'s, feminist\'s, pampered H7W3X9', '5430 fortieth\'s courtyards, brassieres, dumpling R0B4S9', '+351-257-796-3304', 'renrricou@ed.gov'),
(32, 'Sau McDermott', 'cheque', '8777 associates fifteenths, kickback\'s, additive R3K2H5', '9262 securities documented, inventor\'s, visual\'s J3M8N6', '+63-682-305-8310', 'wpackmanv@xrea.com'),
(33, 'Marc Greenfelder', 'americanexpress', '5999 definitive collecting, scurrilous, mothered G0B2F5', '4285 compounded allegory\'s, signposted, hopeless D1P9L9', '+46-140-407-4177', 'lmeiklejohnw@sitemeter.com'),
(34, 'Rochel Ondricka', 'other', '4536 delicacy\'s discourage, extinction, cheapest A8Q0O3', '4179 liniment\'s aristocrat, humidity\'s, wilfully Q9F7R0', '+20-552-993-2924', 'bnuddex@si.edu'),
(35, 'Cameron Wolf', 'deposit', '8699 convoluted persuading, breakfasts, wizard\'s D1U3X8', '6994 smoothness depositing, garrison\'s, timbered Q7C7K8', '+48-845-415-5695', 'hbrendely@squidoo.com'),
(36, 'Mervin Shields', 'creditcard', '2565 sidetracks bartenders, scientific, overuses P6V2P2', '4380 thickening nectarines, caricature, maritime Y7K1A2', '+380-375-814-3997', 'dscoonz@bigcartel.com'),
(37, 'Aldo Lebsack', 'cheque', '2558 occupation centipedes, disavowing, astutely N4W9S5', '2604 forefronts redundancy, blackmails, minoring C3B7F6', '+62-129-640-0437', 'mjaves10@blogtalkradio.com'),
(38, 'Lazaro Cronin', 'banktransfer', '1934 cassette\'s aspirant\'s, originally, rustiest V3F1B1', '6792 luminaries reproached, pickabacks, safaried R8B7Z8', '+249-326-559-4618', 'khallut11@dailymotion.com'),
(39, 'Harriette Stanton', 'debitcard', '8548 delegation downfall\'s, designates, plastics Y6T1D3', '6297 percentage indicative, dreadfully, escape\'s G7E7Y6', '+52-470-227-5637', 'csparshott12@myspace.com'),
(40, 'Becki Metz', 'cheque', '7371 humorously headstones, transfer\'s, mildew\'s P6X8D5', '3863 euphemisms humidity\'s, headland\'s, loathing L3T6T3', '+374-234-250-9190', 'sbenois13@odnoklassniki.ru'),
(41, 'Paula Moore', 'debitcard', '7910 armament\'s kindling\'s, intimate\'s, polarize J2L6H2', '0129 elasticity treasury\'s, addictions, footnote L1H2R6', '+86-934-984-2753', 'mtwinning14@cbsnews.com'),
(42, 'Tova Altenwerth', 'cash', '9263 executable sovereigns, allegiance, initials O0R1P2', '2431 standstill comprising, proceeds\'s, scenting Z6T9V6', '+63-682-113-2785', 'carchibould15@tinypic.com'),
(43, 'Jonah Wyman', 'other', '9230 persevered exhilarate, represents, mammoths O5Q1F5', '0230 tailgate\'s chastity\'s, videotapes, fringe\'s J5H4Z1', '+62-998-962-3837', 'kszabo16@people.com.cn'),
(44, 'Candance Beatty', 'creditcard', '6230 stewardess mercifully, uncleanest, refilled M0L2W8', '4430 television exchanging, flanneling, forceful D3O2I8', '+86-876-654-0900', 'rlappin17@nba.com'),
(45, 'Anglea Jenkins', 'americanexpress', '3322 supervises separation, triumphing, composts V1O0Q6', '0118 linguistic sleeveless, derelict\'s, chippers A8A8G3', '+504-313-533-7427', 'tscreas18@imdb.com'),
(46, 'Antony Powlowski', 'creditcard', '0371 warranty\'s revision\'s, gratuities, paddling I4B4C5', '3066 connectors glossaries, railroad\'s, dragon\'s Z2T2V4', '+62-119-680-2648', 'cmarron19@devhub.com'),
(47, 'Jacinto Bosco', 'americanexpress', '1517 floweriest eliminated, zucchini\'s, surnames V4M7J3', '5540 compulsion renouncing, woodpecker, chilli\'s F7L8T0', '+33-812-983-3220', 'prichter1a@umich.edu'),
(48, 'Greg Schultz', 'deposit', '3447 colonizing intestines, abstention, exterior A5B1K2', '1815 broadsided motorbikes, paralyzing, ravaging H4Z9H9', '+20-780-241-4674', 'ccolleford1b@facebook.com'),
(49, 'Carmen Schoen', 'deposit', '1371 duplicates syllabus\'s, recognizes, onrushes Y2L6R9', '2689 mandolin\'s geometries, accomplice, bounding R9W4C7', '+62-873-282-3738', 'mhabergham1c@reddit.com'),
(50, 'Aline Monahan', 'deposit', '2701 twentieths containers, customizes, validity Z9A3X5', '9626 overthrows December\'s, abundances, bookends H2N8D7', '+57-527-515-5094', 'rwyllcock1d@latimes.com'),
(51, 'Herbert Glover', 'cash', '8423 appetizers interjects, chastising, doodle\'s D6N0T8', '6415 displaying undressing, masochists, rotaries L8A7F0', '+63-566-249-2701', 'tstickings1e@usda.gov'),
(52, 'Lenna Bartell', 'banktransfer', '6154 nonsense\'s humanities, exchange\'s, expended P6N8U7', '5665 connectors convenient, semifinals, esoteric F0X9D1', '+62-953-278-6648', 'dboraston1f@reddit.com'),
(53, 'Darron Schumm', 'cash', '7020 perennials pinnacle\'s, astonishes, quitters Z6P2P6', '7289 healthiest fictitious, receptions, gentiles W3R2S4', '+86-581-810-6670', 'epacheco1g@issuu.com'),
(54, 'Kennith Gutmann', 'cash', '4572 favorite\'s attorney\'s, immaculate, optional J3Z4C1', '8317 receptacle convention, subterfuge, bridle\'s X5A9F8', '+55-346-565-5765', 'blake1h@canalblog.com'),
(55, 'Cary O\'Reilly', 'creditcard', '3160 divorcée\'s subdivided, patriotism, punter\'s O9S6Q2', '6252 torrential characters, aluminum\'s, overhear F1E6V5', '+63-510-703-3973', 'karonson1i@opera.com'),
(56, 'Roderick Paucek', 'debitcard', '4405 favorite\'s influenced, vestment\'s, padlocks L3P3S0', '7292 proprietor mistrusted, matriarchs, engulfed T2P1X1', '+7-963-650-7621', 'lchazelas1j@npr.org'),
(57, 'Marni Ortiz', 'other', '0544 tumultuous adjourning, deflection, conquest F5G9S4', '2365 imitations treasurers, imprinting, trawling X7B3G2', '+961-542-829-5608', 'tkeedwell1k@ask.com'),
(58, 'Merrill Lakin', 'deposit', '8688 windowpane continuing, condemning, patterns T1T8O2', '0512 extraverts birthplace, aggressive, crumples U3D1Y1', '+62-536-525-7178', 'dbellocht1l@buzzfeed.com'),
(59, 'Lizbeth Hegmann', 'cash', '6709 intermarry detergents, odometer\'s, snatched X0O0T5', '6025 delinquent implicated, unbalanced, assureds Q0C5B8', '+63-423-212-1234', 'dbigby1m@shareasale.com'),
(60, 'Duane Tromp', 'deposit', '3334 designer\'s acquiesces, ringleader, heaven\'s L9X6B6', '5730 truncation vanquishes, relocation, presided J7H8Z3', '+63-806-662-1315', 'kbrandom1n@paypal.com'),
(61, 'Alisa Conroy', 'cash', '5178 percolates relegating, jeopardize, doggedly D0K8M6', '1755 recovering antisocial, innuendo\'s, stranded O2L7U3', '+590-410-573-8993', 'wperkinson1o@taobao.com'),
(62, 'Edgar Reynolds', 'creditcard', '2444 references playwright, pretenders, hyacinth N6S1N3', '7130 headstones subscripts, thirstiest, staggers M5Z9T6', '+353-300-935-2343', 'cbattaille1p@youtube.com'),
(63, 'Jesse Grant', 'cheque', '1666 dismissals rotisserie, vanquishes, deluding V5F2M4', '2851 buffaloing disgracing, statements, scuffled E6L5N3', '+1-757-273-2390', 'gallsopp1q@seattletimes.com'),
(64, 'Gerald Hane', 'creditcard', '0644 speculates ministry\'s, orthogonal, pillaged X7J9O4', '0266 butchery\'s pallbearer, monologues, poetry\'s N6B2I0', '+374-959-310-3566', 'meby1r@epa.gov'),
(65, 'Stanley Dibbert', 'debitcard', '7881 compliment sovereigns, enthusiast, pacifies K0H4V3', '1994 engineer\'s harmonized, abortion\'s, upheaval H6R9P1', '+86-322-192-8510', 'nsteabler1s@census.gov'),
(66, 'Theron Kuphal', 'debitcard', '0135 heredity\'s tabernacle, queenliest, doctor\'s Q4S6F0', '5268 quadrupled misfitting, lethargy\'s, neglects J3E4N7', '+51-905-836-7181', 'ahaworth1t@rakuten.co.jp'),
(67, 'Sheldon Stroman', 'banktransfer', '6077 admonition emigrant\'s, crockery\'s, fighting B6U0P5', '0119 encouraged rationally, overture\'s, trucking N6I8W5', '+352-544-168-0810', 'fdomerc1u@arizona.edu'),
(68, 'Dixie Hettinger', 'other', '7763 interments reinforces, locomotive, rattling Q7F4Z2', '8902 slipperier question\'s, changeover, genially Z4Z8P5', '+63-669-887-3783', 'mhaddinton1v@feedburner.com'),
(69, 'Ward Anderson', 'banktransfer', '4655 courtesy\'s optionally, distressed, easterly V6F7A9', '7581 pronounces impossible, mischief\'s, virtue\'s S0X8P5', '+7-770-477-7791', 'mfalk1w@upenn.edu'),
(70, 'Mary Murphy', 'debitcard', '1231 surcharged modernizes, rightfully, rambling V8B4M0', '6480 inundation theorizing, ejection\'s, disavows Z9Y2D9', '+355-973-436-8152', 'kduiguid1x@51.la'),
(71, 'Youlanda Satterfield', 'banktransfer', '3572 approached ministered, subsidizes, shutting P5X3U5', '5742 sandpapers reprieve\'s, privatized, strand\'s A5A3L5', '+351-240-206-4131', 'crowntree1y@ebay.co.uk'),
(72, 'Kum Bosco', 'americanexpress', '7224 smoulder\'s introduced, clambering, evillest O4G8T3', '6239 shotgunned hallelujah, litigation, astutest E8D7U1', '+420-644-464-8262', 'fnellen1z@seattletimes.com'),
(73, 'Antonette Hyatt', 'cheque', '7184 eviction\'s likeness\'s, intrenched, unseated K4S9W0', '0185 sedative\'s convoluted, redemption, woodiest G6E6Q9', '+48-619-505-1517', 'pandreazzi20@geocities.jp'),
(74, 'Oneida Orn', 'cheque', '6574 fertilizer disfigures, infantry\'s, earthier D2U8K6', '8419 pavement\'s despairing, outfitting, recycled Q4U1U1', '+55-320-111-4913', 'ftixall21@cyberchimps.com'),
(75, 'Leonel Cummings', 'banktransfer', '6183 velvetiest inaccuracy, reconciled, strainer W6S1M1', '7434 recklessly earnings\'s, fashioning, rejoiced O9U7T3', '+51-722-346-6687', 'belman22@mapy.cz'),
(76, 'Sarah Bosco', 'other', '0150 ripeness\'s sentiments, unaccepted, epilogue E3M7J0', '4036 invariably patronizes, inhumanity, breezing P7G8X9', '+54-102-740-6764', 'ldarrigrand23@paginegialle.it'),
(77, 'Norma Runte', 'creditcard', '9890 disfavored matchmaker, canvassing, ruthless D6G9V5', '8501 videotapes glamorized, petitioned, spotless T2L7A8', '+977-101-276-7917', 'ddenys24@examiner.com'),
(78, 'Audrea Romaguera', 'cash', '7291 pressuring valentines, adulterate, immature O8D1H9', '7353 passbook\'s improvised, fragrances, fracases L5K9Y5', '+252-126-887-7277', 'kharriss25@last.fm'),
(79, 'Francine Feeney', 'other', '1901 hypnosis\'s homicide\'s, yesterdays, beguiled V8P6J0', '2327 phenomenon fabricates, neighborly, unsettle S2D7B6', '+63-328-917-1843', 'lsteade26@imdb.com'),
(80, 'Evan Halvorson', 'creditcard', '3350 interested subroutine, discounted, crowbars R4J0X9', '1267 competence negligible, previewing, second\'s I9B8P8', '+351-763-227-5848', 'dmanklow27@xing.com'),
(81, 'Seymour Orn', 'banktransfer', '5362 sabotaging withstands, compensate, toppling H8B7V6', '2672 suspicions odometer\'s, scolloping, cantered I2W2R1', '+1-337-704-2795', 'dcranidge28@amazon.co.uk'),
(82, 'Janise Kemmer', 'americanexpress', '9649 shrapnel\'s fearlessly, snickering, ranger\'s X7K6G3', '1078 stockyards inaugurals, hundredths, pastries S0H9P0', '+54-812-933-3939', 'klackie29@dion.ne.jp'),
(83, 'Sherry Wolff', 'debitcard', '6610 darkness\'s surplussed, upholstery, hurdle\'s W0N8Y6', '0678 occasion\'s cherishing, woodchucks, cheating W0P7I9', '+62-717-518-1292', 'pkilsby2a@hubpages.com'),
(84, 'Davis Gibson', 'cheque', '8387 believable courtrooms, pockmarked, critic\'s L4F8E5', '1746 meddlesome processors, billboards, hurdling W5O1M6', '+504-527-763-4483', 'afifield2b@census.gov'),
(85, 'Herma Corkery', 'cash', '5511 paunchiest retailer\'s, chattering, switch\'s T9L1P9', '4777 hospital\'s disbursing, nightmares, asterisk D9F0S7', '+7-749-156-9613', 'rsimcox2c@vinaora.com'),
(86, 'Riley Haley', 'americanexpress', '0714 officiates introduces, anticlimax, sanctify B9R3Q2', '4209 previewers pocketbook, greenhouse, quenched S5U7G4', '+51-810-722-4677', 'ncicculi2d@facebook.com'),
(87, 'Sheldon Rowe', 'banktransfer', '3979 scrutinize naughtiest, princess\'s, debtor\'s W8D6D9', '3873 registrars communique, playhouses, rarity\'s A6Y7X6', '+31-329-960-2641', 'adevenport2e@tmall.com'),
(88, 'Thomas Marvin', 'cash', '8878 straight\'s botanist\'s, uniforming, triumphs S6I6M7', '8481 advantages concerto\'s, expletives, rhubarbs T4F3D6', '+502-490-634-1756', 'ycapstake2f@creativecommons.org'),
(89, 'Sung White', 'americanexpress', '8864 question\'s ballistics, washroom\'s, drafting L6M3K9', '6094 citation\'s proprietor, blasphemes, democrat L3C0F5', '+389-181-468-7661', 'msarjant2g@meetup.com'),
(90, 'Tempie Dare', 'cash', '6808 treasury\'s liveliness, acrimony\'s, provisos A3Q6Y1', '2908 overlooked pernicious, sorority\'s, performs L7P3O5', '+81-938-268-3450', 'nmutch2h@livejournal.com'),
(91, 'Arleen Aufderhar', 'debitcard', '7989 reindeer\'s mothballed, delegating, writable M6F2E8', '6064 unluckiest velocities, idealist\'s, trickier Y9H2F8', '+62-809-630-4117', 'gkarczinski2i@e-recht24.de'),
(92, 'Allyson Konopelski', 'deposit', '4271 uprising\'s radiations, atrocities, coffin\'s D9M5R6', '6147 district\'s weakling\'s, stimulus\'s, addict\'s R4T8Z5', '+86-101-199-0246', 'nsunners2j@princeton.edu'),
(93, 'Devin Homenick', 'cheque', '0485 phenomenal equatorial, opponent\'s, belfries V0Z7N1', '3259 barricades containing, segregates, audibles S5X5J4', '+7-592-209-1519', 'amurtagh2k@oracle.com'),
(94, 'Russ Mayer', 'creditcard', '5179 lavender\'s alligators, astronomer, divorcée U0O8A1', '7730 infidelity initiate\'s, dehydrated, causeway Y9L1K0', '+63-422-292-7245', 'ctroake2l@phoca.cz'),
(95, 'Donovan Schmeler', 'debitcard', '2563 volleyball chartering, reassuring, occurred K5S6T8', '6038 insomnia\'s heartening, agitator\'s, muggiest P0N5N5', '+216-854-468-7103', 'hmaccolgan2m@patch.com'),
(96, 'Gerry Kunze', 'deposit', '8134 extricates qualifiers, rightfully, enslaves N4O2O1', '3067 yearning\'s innkeepers, plumbing\'s, American P8J1B3', '+886-985-332-1826', 'gouslem2n@usnews.com'),
(97, 'Holley Hartmann', 'cash', '6299 brilliants indefinite, turnpike\'s, shakiest A0Z7S2', '3814 orthogonal ancestor\'s, kerchieves, poison\'s F2K6Q7', '+420-935-114-8016', 'fyockney2o@xinhuanet.com'),
(98, 'Shu Block', 'cash', '4754 fortresses inevitably, stretching, undertow E4P6Q6', '9364 ugliness\'s official\'s, corporal\'s, ornately R9U7H6', '+51-587-867-7416', 'lleeman2p@blogs.com'),
(99, 'Juan Osinski', 'deposit', '0454 interloper desolating, ostensibly, shabbily H6B2J3', '4092 prejudices rejections, glossary\'s, grammars G1J2K6', '+886-532-862-7163', 'mcatterill2q@accuweather.com'),
(100, 'Diedre Beatty', 'creditcard', '3435 crumbliest preserving, preventive, powerful K3J1S5', '7172 motherhood arthritics, investment, statue\'s R9J4O8', '+7-833-228-7052', 'bgigg2r@seesaa.net');

-- --------------------------------------------------------

--
-- Table structure for table `department`
--

CREATE TABLE `department` (
  `deptID` int(11) NOT NULL,
  `deptName` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `department`
--

INSERT INTO `department` (`deptID`, `deptName`) VALUES
(1, 'Services'),
(2, 'Support'),
(3, 'Marketing'),
(4, 'Business Development'),
(5, 'Research and Development');

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `empID` int(11) NOT NULL,
  `empFullName` varchar(100) NOT NULL,
  `empAddress` varchar(255) DEFAULT NULL,
  `empPhone` varchar(32) DEFAULT NULL,
  `empEmail` varchar(60) DEFAULT NULL,
  `deptID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`empID`, `empFullName`, `empAddress`, `empPhone`, `empEmail`, `deptID`) VALUES
(1, 'Radcliffe Daish', '8684 Pconsort\'s, Spoled K9C3R7', '496-821-7189', 'radcliffedaish@coldgear.ca', 4),
(2, 'Che Verrell', '2048 Cpyramid\'s, Ybents U4B2U8', '430-917-3583', 'cheverrell@coldgear.ca', 4),
(3, 'Anson Rollinson', '0855 Jretreated, Gsinks U6N8J2', '648-830-7454', 'ansonrollinson@coldgear.ca', 3),
(4, 'Devan Demcak', '5826 Gkoshering, Fthyme O6L4Z1', '635-647-5069', 'devandemcak@coldgear.ca', 1),
(5, 'Nelly Kliche', '9103 Iwhinnying, Mrue\'s E3F8O9', '453-447-8704', 'nellykliche@coldgear.ca', 3),
(6, 'Doyle Farncomb', '2067 Dgardeners, Sair\'s U8A8A2', '890-999-0774', 'doylefarncomb@coldgear.ca', 2),
(7, 'Martelle Imlock', '5580 Nclimaxing, Jkin\'s Z2Q4D3', '483-410-4095', 'martelleimlock@coldgear.ca', 3),
(8, 'Kain Carmont', '3132 Nnortheast, Mdoers U2V8Z4', '394-741-8748', 'kaincarmont@coldgear.ca', 1),
(9, 'Daffie Paget', '4190 Pclapper\'s, Ztunas R2P4D7', '312-993-3051', 'daffiepaget@coldgear.ca', 4),
(10, 'Jelene Stanhope', '5399 Yenrolment, Hlapse A9Q2I8', '359-507-1048', 'jelenestanhope@coldgear.ca', 5),
(11, 'Tadeo Rennels', '9846 Qloveliest, Sploys L0X8E1', '867-789-9629', 'tadeorennels@coldgear.ca', 2),
(12, 'Brandyn Ballinger', '5069 Cballerina, Bclang N6Y1Y2', '805-719-0961', 'brandynballinger@coldgear.ca', 4),
(13, 'Tomas Tremberth', '5809 Mfrizziest, Uhub\'s G8W4Q5', '416-844-2602', 'tomastremberth@coldgear.ca', 1),
(14, 'Artair Spivie', '2010 Zsubsisted, Nrotor I4H1X9', '515-563-3888', 'artairspivie@coldgear.ca', 3),
(15, 'Betti Liepina', '3722 Yweekday\'s, Nrigor U3M7Y6', '890-593-7975', 'bettiliepina@coldgear.ca', 1),
(16, 'Luis Maasz', '7137 Daudacious, Qpower T8O0J7', '816-752-2776', 'luismaasz@coldgear.ca', 1),
(17, 'Sergei MacGaughie', '1953 Oshortlist, Qfogey I9J0E0', '833-150-6368', 'sergeimacgaughie@coldgear.ca', 1),
(18, 'Bradley Bodker', '6126 Kdecimal\'s, Eclank I2T3S3', '334-711-4223', 'bradleybodker@coldgear.ca', 4),
(19, 'Riane Labden', '6755 Ocondemned, Jtaxes E2M2F6', '851-492-2089', 'rianelabden@coldgear.ca', 5),
(20, 'Leonard Sheldrick', '4999 Uallergies, Mcanny O9B0Z7', '183-866-1271', 'leonardsheldrick@coldgear.ca', 4);

-- --------------------------------------------------------

--
-- Table structure for table `manufacturer`
--

CREATE TABLE `manufacturer` (
  `manufID` int(11) NOT NULL,
  `manufName` varchar(50) NOT NULL,
  `manufAddress` varchar(255) DEFAULT NULL,
  `manufPhone` varchar(32) DEFAULT NULL,
  `manufEmail` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `manufacturer`
--

INSERT INTO `manufacturer` (`manufID`, `manufName`, `manufAddress`, `manufPhone`, `manufEmail`) VALUES
(1, 'Twitterbeat', '5824 bronchitis eliminates, meringue\'s, twitters N5P4P8', '+260-549-697-9662', 'lnorthill0@bluehost.com'),
(2, 'Bluejam', '4064 convertors skirmishes, annotation, sweating J0R7J5', '+62-484-599-0525', 'mspinage1@tiny.cc'),
(3, 'Kazio', '1649 incinerate capricious, correctest, smocking B2J1F3', '+7-375-288-0019', 'millesley2@dedecms.com'),
(4, 'Trilia', '9539 governor\'s promontory, seasonable, aviation S8C0K7', '+62-771-110-2027', 'mfreddi3@dailymail.co.uk'),
(5, 'Flashpoint', '3091 weathering revision\'s, improperly, Hispanic U2Q2C7', '+420-353-623-3002', 'rmecozzi4@umn.edu'),
(6, 'Zoomcast', '2186 remainders explicitly, gladiators, murmured E5P8A3', '+63-183-523-5814', 'cdoughtery5@wisc.edu'),
(7, 'Ntag', '2807 percussion brandishes, primrose\'s, parsec\'s E7A6G5', '+62-455-335-1877', 'lscullard6@yolasite.com'),
(8, 'Divavu', '5581 ambassador trellising, cumbersome, barbecue Z4N1Z2', '+54-858-924-4257', 'beverist7@blogspot.com'),
(9, 'Flashspan', '1169 paralytics upholstery, successive, sequel\'s M0Q0U7', '+381-953-700-6756', 'hgiannazzi8@uol.com.br'),
(10, 'Eazzy', '0667 hallelujah obsessions, disdainful, cleric\'s H9C3V0', '+86-633-179-4192', 'utiuit9@photobucket.com'),
(11, 'Innotype', '4550 kindnesses occasion\'s, citation\'s, interact K1X9F4', '+232-702-962-1124', 'ckrugmanna@phpbb.com'),
(12, 'Flipbug', '9579 compound\'s crevasse\'s, probable\'s, contacts W6R6V7', '+62-638-875-3597', 'broubottomb@wordpress.com'),
(13, 'Rhyloo', '0927 cloistered forearming, sailboat\'s, cotton\'s G6U4I9', '+55-413-743-7401', 'hkelwaybamberc@miitbeian.gov.cn'),
(14, 'Meetz', '9116 empowering repudiates, crumbliest, delicacy U8F6J0', '+86-464-935-1441', 'tevettd@disqus.com'),
(15, 'Yata', '2330 appendages relative\'s, scrupulous, grouping Y1T5N0', '+420-941-982-1687', 'lspittlese@scientificamerican.com'),
(16, 'Buzzbean', '3320 assailants radiations, defensible, totter\'s M4O5T0', '+998-655-201-8584', 'litzcovichchf@google.it'),
(17, 'Meetz', '6337 production district\'s, spelling\'s, transmit Z0N0O6', '+53-940-601-2142', 'dhazleg@istockphoto.com'),
(18, 'Snaptags', '7565 plagiarist moisture\'s, thousandth, ravine\'s D1K3Z0', '+55-345-345-3237', 'mmactrustramh@virginia.edu'),
(19, 'Quamba', '7380 diabetic\'s recharging, outgrowths, voodooed Z0M8J2', '+81-875-188-3045', 'jbeardoni@foxnews.com'),
(20, 'Innojam', '2115 infelicity helplessly, transitted, fizzle\'s P1Y2C2', '+46-409-985-6748', 'vmacneilleyj@sina.com.cn');

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `productID` int(11) NOT NULL,
  `productName` varchar(50) NOT NULL,
  `productDesc` tinytext,
  `productPrice` float DEFAULT NULL,
  `unitsInStock` int(11) DEFAULT NULL,
  `manufID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`productID`, `productName`, `productDesc`, `productPrice`, `unitsInStock`, `manufID`) VALUES
(1, 'Usubmissive', 'Donec ut dolor. Morbi vel lectus in quam fringilla rhoncus. Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis.', 2669.58, 39, 11),
(2, 'Xcrookedest', 'Aenean lectus. Pellentesque eget nunc.', 4827.54, 1, 14),
(3, 'Ygracefully', 'Praesent blandit. Nam nulla. Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.', 4854.34, 67, 14),
(4, 'Lautonomy\'s', 'Aenean fermentum.', 2892.53, 82, 14),
(5, 'Finequality', 'Nam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla.', 2529.53, 100, 2),
(6, 'Nreprograms', 'Quisque porta volutpat erat. Quisque erat eros, viverra eget, congue eget, semper rutrum, nulla.', 1218.93, 94, 1),
(7, 'Junfeasible', 'Integer non velit. Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi', 2888.04, 56, 10),
(8, 'Rattributed', 'Nulla facilisi. Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit.', 1226.3, 39, 7),
(9, 'Kapartments', 'Duis ac nibh.', 4610.8, 77, 20),
(10, 'Iimpervious', 'Cras pellentesque volutpat dui. Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc.', 855.62, 100, 2),
(11, 'Pcheapening', 'Sed sagittis.', 3187.94, 82, 15),
(12, 'Gdissidents', 'Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum.', 2426.4, 54, 1),
(13, 'Sfearlessly', 'Proin risus. Praesent lectus. Vestibulum quam sapien, varius ut, blandit non, interdum in, ante.', 3848.58, 44, 16),
(14, 'Lkidnapping', 'Etiam pretium iaculis justo.', 2643.29, 24, 4),
(15, 'Imonument\'s', 'Etiam faucibus cursus urna. Ut tellus.', 421.94, 56, 16);

-- --------------------------------------------------------

--
-- Table structure for table `productorder`
--

CREATE TABLE `productorder` (
  `productOrderID` int(11) NOT NULL,
  `productID` int(11) NOT NULL,
  `customerID` int(11) NOT NULL,
  `empID` int(11) DEFAULT NULL,
  `unitsOrdered` int(11) NOT NULL,
  `isComplete` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `productorder`
--

INSERT INTO `productorder` (`productOrderID`, `productID`, `customerID`, `empID`, `unitsOrdered`, `isComplete`) VALUES
(1, 15, 81, 11, 77, 1),
(2, 8, 82, 10, 82, 1),
(3, 3, 36, 13, 19, 1),
(4, 2, 67, 20, 46, 1),
(5, 4, 53, 10, 78, 1),
(6, 9, 85, 18, 58, 1),
(7, 10, 57, 13, 38, 1),
(8, 8, 39, 1, 70, 1),
(9, 4, 71, 1, 41, 1),
(10, 3, 73, 10, 95, 1),
(11, 5, 15, 18, 47, 1),
(12, 13, 9, 13, 87, 1),
(13, 11, 89, 9, 23, 1),
(14, 8, 37, 13, 34, 1),
(15, 9, 19, 14, 11, 1),
(16, 13, 70, 2, 91, 1),
(17, 12, 97, 6, 42, 1),
(18, 6, 47, 11, 88, 1),
(19, 13, 80, 10, 27, 1),
(20, 9, 21, 3, 12, 1),
(21, 11, 6, 9, 5, 1),
(22, 11, 54, 9, 3, 1),
(23, 5, 77, 3, 44, 1),
(24, 13, 7, 17, 30, 1),
(25, 6, 48, 3, 73, 1),
(26, 6, 60, 8, 10, 1),
(27, 3, 93, 16, 19, 1),
(28, 8, 93, 8, 85, 1),
(29, 7, 25, 5, 2, 1),
(30, 5, 28, 9, 23, 1),
(31, 7, 86, 10, 82, 1),
(32, 12, 58, 15, 15, 1),
(33, 2, 1, 7, 99, 1),
(34, 14, 20, 20, 85, 1),
(35, 9, 48, 15, 52, 1),
(36, 4, 98, 9, 4, 1),
(37, 10, 62, 1, 55, 1),
(38, 3, 68, 2, 46, 1),
(39, 9, 83, 1, 46, 1),
(40, 7, 82, 3, 44, 1),
(41, 7, 42, 8, 41, 1),
(42, 14, 7, 8, 36, 1),
(43, 12, 31, 19, 54, 1),
(44, 11, 27, 10, 28, 1),
(45, 6, 83, 7, 86, 1),
(46, 11, 57, 3, 75, 1),
(47, 8, 100, 13, 15, 1),
(48, 1, 8, 7, 39, 1),
(49, 14, 10, 11, 39, 1),
(50, 5, 34, 4, 98, 1),
(51, 10, 86, 11, 51, 1),
(52, 9, 80, 2, 31, 1),
(53, 15, 99, 3, 79, 1),
(54, 5, 39, 6, 21, 1),
(55, 6, 46, 19, 52, 1),
(56, 13, 10, 11, 43, 1),
(57, 11, 43, 14, 49, 1),
(58, 11, 54, 20, 33, 1),
(59, 1, 52, 6, 34, 1),
(60, 15, 33, 10, 61, 1),
(61, 7, 99, 6, 8, 1),
(62, 3, 47, 1, 88, 1),
(63, 1, 15, 15, 52, 1),
(64, 12, 33, 14, 75, 1),
(65, 7, 40, 11, 51, 1),
(66, 12, 2, 16, 33, 1),
(67, 11, 43, 11, 100, 1),
(68, 15, 27, 13, 48, 1),
(69, 12, 21, 6, 49, 1),
(70, 12, 59, 13, 15, 1),
(71, 13, 18, 14, 24, 1),
(72, 15, 52, 1, 8, 1),
(73, 9, 33, 16, 32, 1),
(74, 7, 71, 15, 69, 1),
(75, 12, 30, 5, 93, 1),
(76, 3, 22, 10, 45, 1),
(77, 1, 2, 9, 21, 1),
(78, 9, 12, 15, 62, 1),
(79, 2, 77, 17, 28, 1),
(80, 6, 45, 9, 3, 1),
(81, 10, 43, 19, 95, 1),
(82, 14, 59, 19, 30, 1),
(83, 5, 83, 16, 96, 1),
(84, 1, 3, 13, 50, 1),
(85, 6, 21, 11, 4, 1),
(86, 13, 99, 3, 83, 1),
(87, 1, 89, 15, 34, 1),
(88, 7, 93, 19, 39, 1),
(89, 3, 64, 9, 72, 1),
(90, 3, 7, 1, 37, 1),
(91, 7, 79, 19, 50, 1),
(92, 4, 29, 9, 27, 1),
(93, 5, 58, 3, 39, 1),
(94, 2, 47, 8, 94, 1),
(95, 10, 100, 18, 57, 1),
(96, 8, 50, 10, 12, 1),
(97, 13, 8, 14, 32, 1),
(98, 12, 33, 10, 44, 1),
(99, 1, 50, 11, 25, 1),
(100, 15, 90, 3, 25, 1),
(101, 5, 4, 1, 90, 1),
(102, 1, 18, 4, 58, 1),
(103, 7, 83, 11, 46, 1),
(104, 5, 95, 6, 95, 1),
(105, 6, 20, 19, 34, 1),
(106, 14, 40, 16, 3, 1),
(107, 8, 96, 1, 77, 1),
(108, 2, 20, 4, 83, 1),
(109, 4, 40, 20, 36, 1),
(110, 10, 73, 3, 25, 1),
(111, 2, 88, 3, 50, 1),
(112, 11, 24, 5, 63, 1),
(113, 5, 82, 18, 80, 1),
(114, 2, 32, 15, 61, 1),
(115, 15, 91, 16, 94, 1),
(116, 6, 31, 14, 15, 1),
(117, 5, 77, 2, 92, 1),
(118, 15, 60, 2, 35, 1),
(119, 8, 68, 7, 81, 1),
(120, 13, 55, 16, 13, 1),
(121, 5, 27, 20, 70, 1),
(122, 3, 98, 14, 56, 1),
(123, 3, 74, 9, 68, 1),
(124, 1, 6, 8, 88, 1),
(125, 4, 24, 3, 51, 1),
(126, 3, 56, 18, 100, 1),
(127, 2, 61, 16, 25, 1),
(128, 15, 61, 15, 15, 1),
(129, 15, 60, 14, 80, 1),
(130, 9, 1, 10, 91, 1),
(131, 7, 57, 13, 22, 1),
(132, 14, 100, 2, 71, 1),
(133, 12, 21, 17, 89, 1),
(134, 9, 8, 13, 28, 1),
(135, 8, 26, 16, 2, 1),
(136, 1, 12, 4, 17, 1),
(137, 6, 10, 2, 29, 1),
(138, 13, 41, 9, 32, 1),
(139, 15, 63, 8, 32, 1),
(140, 3, 60, 13, 83, 1),
(141, 9, 9, 20, 39, 1),
(142, 13, 33, 12, 28, 1),
(143, 15, 25, 20, 41, 1),
(144, 4, 40, 5, 79, 1),
(145, 4, 9, 10, 71, 1),
(146, 4, 49, 4, 79, 1),
(147, 15, 5, 16, 19, 1),
(148, 6, 33, 10, 61, 1),
(149, 3, 46, 11, 48, 1),
(150, 9, 91, 3, 45, 1),
(151, 2, 23, 5, 7, 1),
(152, 9, 87, 4, 95, 1),
(153, 1, 18, 20, 93, 1),
(154, 14, 50, 6, 58, 1),
(155, 5, 1, 11, 78, 1),
(156, 1, 53, 2, 89, 1),
(157, 10, 68, 10, 52, 1),
(158, 3, 15, 10, 98, 1),
(159, 3, 9, 2, 15, 1),
(160, 8, 60, 10, 38, 1),
(161, 5, 14, 9, 71, 1),
(162, 1, 43, 5, 86, 1),
(163, 4, 73, 2, 64, 1),
(164, 10, 6, 12, 93, 1),
(165, 2, 40, 2, 41, 1),
(166, 10, 13, 14, 89, 1),
(167, 7, 16, 16, 82, 1),
(168, 13, 27, 13, 61, 1),
(169, 3, 4, 19, 68, 1),
(170, 15, 4, 13, 3, 1),
(171, 12, 54, 20, 59, 1),
(172, 2, 45, 8, 67, 1),
(173, 13, 75, 16, 79, 1),
(174, 11, 6, 14, 66, 1),
(175, 2, 40, 13, 55, 1),
(176, 4, 95, 15, 46, 1),
(177, 1, 6, 4, 59, 1),
(178, 15, 34, 18, 83, 1),
(179, 14, 78, 1, 64, 1),
(180, 6, 55, 13, 53, 1),
(181, 8, 92, 10, 20, 1),
(182, 15, 83, 1, 48, 1),
(183, 9, 13, 18, 7, 1),
(184, 10, 18, 2, 95, 1),
(185, 4, 97, 13, 54, 1),
(186, 2, 46, 13, 26, 1),
(187, 4, 61, 16, 15, 1),
(188, 2, 14, 14, 29, 1),
(189, 13, 32, 3, 29, 1),
(190, 14, 52, 10, 2, 1),
(191, 9, 35, 4, 16, 1),
(192, 6, 56, 20, 48, 1),
(193, 1, 8, 2, 74, 1),
(194, 7, 67, 16, 18, 1),
(195, 15, 18, 2, 85, 1),
(196, 13, 20, 14, 77, 1),
(197, 8, 96, 8, 88, 1),
(198, 3, 96, 6, 36, 1),
(199, 2, 41, 20, 26, 1),
(200, 10, 87, 6, 17, 1),
(201, 4, 94, 3, 95, 1),
(202, 1, 61, 8, 25, 1),
(203, 10, 93, 5, 80, 1),
(204, 11, 85, 12, 55, 1),
(205, 13, 56, 6, 87, 1),
(206, 15, 5, 1, 90, 1),
(207, 7, 52, 9, 64, 1),
(208, 9, 27, 3, 66, 1),
(209, 3, 41, 6, 9, 1),
(210, 15, 79, 11, 57, 1),
(211, 11, 46, 2, 49, 1),
(212, 6, 83, 18, 17, 1),
(213, 2, 47, 1, 88, 1),
(214, 15, 13, 3, 71, 1),
(215, 9, 62, 17, 33, 1),
(216, 9, 95, 10, 68, 1),
(217, 4, 86, 20, 72, 1),
(218, 1, 65, 5, 40, 1),
(219, 2, 69, 7, 30, 1),
(220, 8, 65, 5, 93, 1),
(221, 4, 37, 3, 99, 1),
(222, 10, 92, 14, 5, 1),
(223, 4, 28, 4, 83, 1),
(224, 13, 58, 11, 5, 1),
(225, 10, 75, 5, 53, 1),
(226, 3, 78, 17, 2, 1),
(227, 9, 68, 2, 98, 1),
(228, 2, 6, 5, 25, 1),
(229, 12, 41, 15, 67, 1),
(230, 1, 30, 9, 19, 1),
(231, 11, 18, 19, 9, 1),
(232, 14, 42, 14, 29, 1),
(233, 3, 57, 11, 15, 1),
(234, 9, 37, 1, 86, 1),
(235, 11, 68, 15, 58, 1),
(236, 6, 97, 14, 69, 1),
(237, 3, 35, 5, 7, 1),
(238, 9, 34, 1, 17, 1),
(239, 9, 96, 20, 50, 1),
(240, 14, 18, 1, 24, 1),
(241, 6, 28, 6, 33, 1),
(242, 6, 49, 3, 46, 1),
(243, 5, 85, 13, 66, 1),
(244, 13, 25, 14, 1, 1),
(245, 14, 46, 9, 88, 1),
(246, 14, 79, 10, 69, 1),
(247, 4, 72, 2, 90, 1),
(248, 2, 34, 19, 24, 1),
(249, 5, 92, 18, 81, 1),
(250, 12, 8, 1, 14, 1),
(251, 13, 21, 4, 1, 1),
(252, 6, 42, 16, 62, 1),
(253, 2, 50, 16, 89, 1),
(254, 13, 100, 10, 81, 1),
(255, 9, 84, 9, 27, 1),
(256, 3, 83, 6, 41, 1),
(257, 14, 94, 19, 61, 1),
(258, 15, 43, 11, 59, 1),
(259, 11, 49, 5, 31, 1),
(260, 10, 45, 15, 66, 1),
(261, 4, 63, 20, 48, 1),
(262, 5, 24, 5, 61, 1),
(263, 7, 52, 7, 78, 1),
(264, 13, 1, 3, 31, 1),
(265, 2, 64, 14, 37, 1),
(266, 10, 53, 7, 41, 1),
(267, 3, 58, 14, 79, 1),
(268, 4, 67, 2, 35, 1),
(269, 15, 29, 10, 33, 1),
(270, 14, 51, 14, 76, 1),
(271, 14, 63, 10, 27, 1),
(272, 6, 23, 8, 8, 1),
(273, 7, 13, 9, 31, 1),
(274, 2, 12, 12, 90, 1),
(275, 5, 37, 20, 31, 1),
(276, 8, 23, 9, 34, 1),
(277, 7, 79, 3, 27, 1),
(278, 5, 94, 7, 25, 1),
(279, 15, 81, 8, 52, 1),
(280, 1, 83, 1, 43, 1),
(281, 15, 19, 18, 30, 1),
(282, 6, 57, 3, 70, 1),
(283, 11, 86, 18, 6, 1),
(284, 1, 98, 6, 64, 1),
(285, 1, 2, 13, 91, 1),
(286, 5, 46, 7, 41, 0),
(287, 9, 44, 11, 61, 0),
(288, 13, 35, 4, 25, 0),
(289, 14, 88, 10, 66, 0),
(290, 4, 11, 18, 30, 0),
(291, 1, 55, 14, 29, 0),
(292, 4, 74, 20, 11, 0),
(293, 9, 6, 20, 88, 0),
(294, 5, 75, 10, 79, 0),
(295, 1, 57, 7, 13, 0),
(296, 4, 98, 15, 3, 0),
(297, 10, 35, 3, 71, 0),
(298, 14, 59, 14, 26, 0),
(299, 14, 8, 12, 32, 0),
(300, 11, 32, 2, 44, 0);

-- --------------------------------------------------------

--
-- Table structure for table `service`
--

CREATE TABLE `service` (
  `serviceID` int(11) NOT NULL,
  `serviceName` varchar(50) NOT NULL,
  `serviceType` varchar(30) DEFAULT NULL,
  `servicePrice` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `service`
--

INSERT INTO `service` (`serviceID`, `serviceName`, `serviceType`, `servicePrice`) VALUES
(1, 'Standard replacement', 'Replacement', 150.99),
(2, 'Standard cleaning', 'Cleaning', 20.99),
(3, 'Coolant refill', 'Maintenance', 40.99),
(4, 'Standard takedown', 'Takedown', 80.99),
(5, 'Product installation', 'Installation', 70.99),
(6, 'Quick replacement', 'Replacement', 200.99);

-- --------------------------------------------------------

--
-- Table structure for table `serviceorder`
--

CREATE TABLE `serviceorder` (
  `serviceOrderID` int(11) NOT NULL,
  `serviceID` int(11) NOT NULL,
  `customerID` int(11) NOT NULL,
  `empID` int(11) DEFAULT NULL,
  `isComplete` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `serviceorder`
--

INSERT INTO `serviceorder` (`serviceOrderID`, `serviceID`, `customerID`, `empID`, `isComplete`) VALUES
(1, 5, 98, 20, 1),
(2, 4, 78, 17, 1),
(3, 3, 19, 15, 1),
(4, 1, 73, 13, 1),
(5, 6, 20, 16, 1),
(6, 5, 93, 12, 1),
(7, 4, 76, 13, 1),
(8, 4, 3, 19, 1),
(9, 2, 12, 10, 1),
(10, 6, 48, 10, 1),
(11, 2, 13, 10, 1),
(12, 3, 19, 14, 1),
(13, 1, 76, 9, 1),
(14, 6, 31, 1, 1),
(15, 2, 52, 5, 1),
(16, 2, 46, 19, 1),
(17, 1, 73, 6, 1),
(18, 4, 17, 11, 1),
(19, 4, 32, 6, 1),
(20, 3, 91, 2, 1),
(21, 2, 18, 14, 1),
(22, 6, 33, 15, 1),
(23, 5, 84, 7, 1),
(24, 6, 92, 1, 1),
(25, 2, 7, 4, 1),
(26, 5, 72, 15, 1),
(27, 6, 82, 4, 1),
(28, 5, 45, 15, 1),
(29, 6, 11, 5, 1),
(30, 1, 29, 15, 1),
(31, 6, 91, 9, 1),
(32, 6, 66, 9, 1),
(33, 2, 100, 1, 1),
(34, 3, 59, 9, 1),
(35, 4, 35, 11, 1),
(36, 5, 52, 14, 1),
(37, 3, 32, 14, 1),
(38, 3, 9, 20, 1),
(39, 6, 29, 18, 1),
(40, 3, 28, 6, 1),
(41, 1, 98, 18, 1),
(42, 4, 61, 8, 1),
(43, 4, 18, 7, 1),
(44, 2, 52, 5, 1),
(45, 6, 17, 19, 1),
(46, 1, 91, 16, 1),
(47, 3, 58, 1, 1),
(48, 2, 17, 5, 1),
(49, 5, 87, 9, 1),
(50, 2, 83, 18, 1),
(51, 5, 89, 5, 1),
(52, 4, 8, 8, 1),
(53, 3, 97, 2, 1),
(54, 3, 89, 3, 1),
(55, 4, 60, 2, 1),
(56, 5, 92, 18, 1),
(57, 4, 63, 2, 1),
(58, 6, 24, 10, 1),
(59, 2, 65, 2, 1),
(60, 4, 77, 17, 1),
(61, 2, 39, 12, 1),
(62, 1, 43, 11, 1),
(63, 1, 88, 1, 1),
(64, 1, 50, 5, 1),
(65, 4, 88, 20, 1),
(66, 2, 71, 5, 1),
(67, 4, 43, 5, 1),
(68, 2, 30, 7, 1),
(69, 3, 36, 16, 1),
(70, 2, 24, 6, 1),
(71, 4, 30, 6, 1),
(72, 6, 94, 7, 1),
(73, 6, 94, 5, 1),
(74, 6, 7, 14, 1),
(75, 6, 57, 3, 1),
(76, 2, 93, 2, 1),
(77, 4, 62, 13, 1),
(78, 2, 91, 5, 1),
(79, 6, 71, 10, 1),
(80, 2, 79, 18, 1),
(81, 4, 91, 20, 1),
(82, 6, 57, 7, 1),
(83, 2, 5, 14, 1),
(84, 6, 97, 3, 1),
(85, 6, 74, 5, 1),
(86, 1, 57, 4, 1),
(87, 6, 60, 16, 1),
(88, 6, 20, 6, 1),
(89, 6, 10, 20, 1),
(90, 2, 3, 4, 1),
(91, 5, 75, 17, 1),
(92, 1, 60, 16, 1),
(93, 4, 79, 17, 1),
(94, 4, 42, 10, 1),
(95, 5, 87, 14, 1),
(96, 2, 48, 18, 1),
(97, 5, 60, 12, 1),
(98, 5, 60, 6, 1),
(99, 2, 21, 10, 1),
(100, 6, 16, 17, 1),
(101, 2, 61, 18, 1),
(102, 2, 71, 20, 1),
(103, 3, 93, 20, 1),
(104, 2, 17, 16, 1),
(105, 3, 20, 6, 1),
(106, 3, 68, 7, 1),
(107, 3, 96, 18, 1),
(108, 5, 25, 20, 1),
(109, 3, 11, 19, 1),
(110, 3, 13, 17, 1),
(111, 2, 16, 8, 1),
(112, 5, 39, 17, 1),
(113, 1, 86, 1, 1),
(114, 1, 19, 5, 1),
(115, 4, 60, 12, 1),
(116, 6, 15, 8, 0),
(117, 1, 38, 20, 0),
(118, 3, 47, 11, 0),
(119, 3, 16, 3, 0),
(120, 4, 32, 18, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`customerID`);

--
-- Indexes for table `department`
--
ALTER TABLE `department`
  ADD PRIMARY KEY (`deptID`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`empID`),
  ADD KEY `deptID` (`deptID`);

--
-- Indexes for table `manufacturer`
--
ALTER TABLE `manufacturer`
  ADD PRIMARY KEY (`manufID`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`productID`),
  ADD KEY `manufID` (`manufID`);

--
-- Indexes for table `productorder`
--
ALTER TABLE `productorder`
  ADD PRIMARY KEY (`productOrderID`),
  ADD KEY `productID` (`productID`),
  ADD KEY `customerID` (`customerID`),
  ADD KEY `empID` (`empID`);

--
-- Indexes for table `service`
--
ALTER TABLE `service`
  ADD PRIMARY KEY (`serviceID`);

--
-- Indexes for table `serviceorder`
--
ALTER TABLE `serviceorder`
  ADD PRIMARY KEY (`serviceOrderID`),
  ADD KEY `serviceID` (`serviceID`),
  ADD KEY `customerID` (`customerID`),
  ADD KEY `empID` (`empID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `customerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=101;

--
-- AUTO_INCREMENT for table `department`
--
ALTER TABLE `department`
  MODIFY `deptID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `empID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `manufacturer`
--
ALTER TABLE `manufacturer`
  MODIFY `manufID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `productID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `productorder`
--
ALTER TABLE `productorder`
  MODIFY `productOrderID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=301;

--
-- AUTO_INCREMENT for table `service`
--
ALTER TABLE `service`
  MODIFY `serviceID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `serviceorder`
--
ALTER TABLE `serviceorder`
  MODIFY `serviceOrderID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=121;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `employee`
--
ALTER TABLE `employee`
  ADD CONSTRAINT `employee_ibfk_1` FOREIGN KEY (`deptID`) REFERENCES `department` (`deptID`);

--
-- Constraints for table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `product_ibfk_1` FOREIGN KEY (`manufID`) REFERENCES `manufacturer` (`manufID`);

--
-- Constraints for table `productorder`
--
ALTER TABLE `productorder`
  ADD CONSTRAINT `productorder_ibfk_1` FOREIGN KEY (`productID`) REFERENCES `product` (`productID`),
  ADD CONSTRAINT `productorder_ibfk_2` FOREIGN KEY (`customerID`) REFERENCES `customer` (`customerID`),
  ADD CONSTRAINT `productorder_ibfk_3` FOREIGN KEY (`empID`) REFERENCES `employee` (`empID`);

--
-- Constraints for table `serviceorder`
--
ALTER TABLE `serviceorder`
  ADD CONSTRAINT `serviceorder_ibfk_1` FOREIGN KEY (`serviceID`) REFERENCES `service` (`serviceID`),
  ADD CONSTRAINT `serviceorder_ibfk_2` FOREIGN KEY (`customerID`) REFERENCES `customer` (`customerID`),
  ADD CONSTRAINT `serviceorder_ibfk_3` FOREIGN KEY (`empID`) REFERENCES `employee` (`empID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
