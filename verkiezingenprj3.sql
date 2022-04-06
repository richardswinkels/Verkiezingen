-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Gegenereerd op: 01 jul 2021 om 07:01
-- Serverversie: 5.7.31
-- PHP-versie: 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `verkiezingenprj3`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `partij`
--

DROP TABLE IF EXISTS `partij`;
CREATE TABLE IF NOT EXISTS `partij` (
  `PartijId` int(11) NOT NULL AUTO_INCREMENT,
  `PartijName` varchar(200) NOT NULL,
  `Adres` varchar(200) DEFAULT NULL,
  `Postcode` varchar(10) DEFAULT NULL,
  `Gemeente` varchar(200) DEFAULT NULL,
  `EmailAdres` varchar(50) DEFAULT NULL,
  `Telefoonnummer` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`PartijId`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;

--
-- Gegevens worden geëxporteerd voor tabel `partij`
--

INSERT INTO `partij` (`PartijId`, `PartijName`, `Adres`, `Postcode`, `Gemeente`, `EmailAdres`, `Telefoonnummer`) VALUES
(1, 'Volkspartij voor Vrijheid en Democratie', 'Mauritskade 21', '2500 GV', 'Den Haag', 'info@vvd.nl', '0703613061'),
(2, 'Democraten 66', 'Lange Houtstraat 11', '2511 CV', 'Den Haag', 'info@d66.nl', '0703566066'),
(3, 'Partij voor de Vrijheid', NULL, NULL, 'Den Haag', 'pvv.publiek@tweedekamer.nl', '0703182867'),
(4, 'Christen-Democratisch Appèl', 'Buitenom 18', '2512 XA', 'Den Haag', 'cda@cda.nl', '0703183020'),
(5, 'Socialistische Partij', 'Snouckaertlaan 70', '3811 MB', 'Amersfoort', 'sp@sp.nl', '0882435555'),
(6, 'Partij van de Arbeid', 'Leeghwaterplein 45', '2521 DB', 'Den Haag', 'voorzitter@pvda.nl', '0705500555'),
(7, 'GroenLinks', 'Sint Jacobsstraat 12', '3511 BS', 'Utrecht', 'vragen@groenlinks.nl', '0302399900'),
(8, 'Partij voor de Dieren', 'Nieuwezijds Voorburgwal 32', '1012 RZ', 'Amsterdam', 'administratie@partijvoordedieren.nl', '0205203870'),
(9, 'ChristenUnie', 'Johan van Oldenbarneveltlaan 46', '3818 HB', 'Amersfoort', 'info@christenunie.nl', '0334226969'),
(10, 'Forum voor Democratie', 'Herengracht 74', '1015 BR', 'Amsterdam', 'partij@fvd.nl', '0202612874'),
(11, 'Volt', 'Franklinstraat 161', '2562 CD', 'Den Haag', 'info@voltnederland.org', NULL),
(12, 'JA21', 'Tweede Boerhaavestraat 55 E', '1091 AL', 'Amsterdam', 'partij@ja21.nl', NULL),
(13, 'Staatkundig Gereformeerde Partij', 'Dinkel 7', '3068 HB', 'Rotterdam', 'info@sgp.nl', '0107200770'),
(14, 'DENK', 'Schiekade 10', '3032 AJ', 'Rotterdam', 'info@bewegingdenk.nl', NULL),
(15, 'Fractie Den Haan', NULL, NULL, NULL, 'fractiedenhaan@tweedekamer.nl', NULL),
(16, 'BoerBurgerBeweging', 'Groningerstraat 21', '7418 BX', 'Deventer', 'info@boerburgerbeweging.nl', '0703183341'),
(17, 'BIJ1', 'Wapenstraat 37 A', '3074 ZR', 'Rotterdam', NULL, NULL),
(18, 'Groep Van Haga', '', '', '', 'w.vhaga@tweedekamer.nl', ''),
(19, 'Water Natuurlijk', '', '', '', 'secretaris@waternatuurlijk.nl', '0334532581'),
(20, 'Werken aan water', 'Stevertsebaan 30', '5561 TS', 'Riethoven', 'jvgerven@werkenaanwater.com', '0497513166'),
(21, 'Algemene Waterschapspartij', '', '', '', '', ''),
(22, 'Ouderen Appèl - Hart voor Water', 'Stadhuisplein 1', '5611 EM', 'Eindhoven', '', '0402382392'),
(23, 'Onafhankelijke senaatsfractie', 'Ruysdaellaan 34', '6165 TZ', 'Geleen', 'info@osf.nl', '0641203604');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `standpunten`
--

DROP TABLE IF EXISTS `standpunten`;
CREATE TABLE IF NOT EXISTS `standpunten` (
  `StandpuntId` int(11) NOT NULL AUTO_INCREMENT,
  `PartijId` int(11) NOT NULL,
  `PartijName` varchar(200) NOT NULL,
  `ThemaId` int(11) NOT NULL,
  `Thema` varchar(200) NOT NULL,
  `Standpunt` varchar(2000) NOT NULL,
  PRIMARY KEY (`StandpuntId`),
  KEY `PartijId` (`PartijId`),
  KEY `ThemaId` (`ThemaId`)
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8;

--
-- Gegevens worden geëxporteerd voor tabel `standpunten`
--

INSERT INTO `standpunten` (`StandpuntId`, `PartijId`, `PartijName`, `ThemaId`, `Thema`, `Standpunt`) VALUES
(1, 1, 'Volkspartij voor Vrijheid en Democratie', 1, 'Arbeidsmigratie', 'Toptalenten uit het buitenland zijn van harte welkom in Nederland.'),
(2, 1, 'Volkspartij voor Vrijheid en Democratie', 2, 'Asielzoekers', 'Als een asielzoeker Nederland binnenkomt, moet snel en definitief duidelijk worden of hij of zij een echte vluchteling is.'),
(3, 1, 'Volkspartij voor Vrijheid en Democratie', 3, 'Cultuur', 'Cultuur is van en voor de samenleving.'),
(4, 1, 'Volkspartij voor Vrijheid en Democratie', 4, 'Handel en economie', 'Tijd om de belastingen voor middengroepen te verlagen.'),
(5, 1, 'Volkspartij voor Vrijheid en Democratie', 5, 'Klimaat', 'Kernenergie is een schone en stabiele energiebron.'),
(6, 1, 'Volkspartij voor Vrijheid en Democratie', 6, 'Onderwijs', 'Ieder kind verdient het onderwijs dat hij of zij nodig heeft.'),
(7, 1, 'Volkspartij voor Vrijheid en Democratie', 7, 'Nederland in de EU', 'De Europese Unie moet de grote problemen oplossen.'),
(8, 1, 'Volkspartij voor Vrijheid en Democratie', 8, 'Veiligheid', 'Drugscriminelen aanpakken en softdrugs slimmer regelen.'),
(9, 1, 'Volkspartij voor Vrijheid en Democratie', 9, 'Werkgelegenheid', 'Een brede en sterke middengroep is cruciaal voor een stabiele samenleving. '),
(10, 1, 'Volkspartij voor Vrijheid en Democratie', 10, 'Zorg', 'Het eigen risico voorlopig gelijk houden.'),
(11, 2, 'Democraten 66', 1, 'Arbeidsmigratie', 'Arbeidsmigranten moeten veilig naar Nederland kunnen reizen en vacatures vervullen die nu open blijven staan.'),
(12, 2, 'Democraten 66', 2, 'Asielzoekers', 'Gezamenlijk kan de Europese Unie de vluchtelingenopvang aan.'),
(13, 2, 'Democraten 66', 3, 'Cultuur', 'Cultuur is geen simpele vrijetijdsbesteding, maar van levensbelang voor de samenleving.'),
(14, 2, 'Democraten 66', 4, 'Handel en economie', 'We mogen toekomstige generaties nooit opzadelen met torenhoge schulden.'),
(15, 2, 'Democraten 66', 5, 'Klimaat', 'Zorgen voor een rechtvaardige en eerlijke klimaatomslag.'),
(16, 2, 'Democraten 66', 6, 'Onderwijs', 'Stoppen met selectie aan de poort voor hbo en wo.'),
(17, 2, 'Democraten 66', 7, 'Nederland in de EU', 'We hebben een sterk Europa nodig dat de grote uitdagingen van nu aanpakt.'),
(18, 2, 'Democraten 66', 8, 'Veiligheid', 'De rechtspraak moet voor iedereen toegankelijk zijn.'),
(19, 2, 'Democraten 66', 9, 'Werkgelegenheid', 'We moeten de ongelijkheid tussen werkenden verkleinen.'),
(20, 2, 'Democraten 66', 10, 'Zorg', 'Goede, toegankelijke en betaalbare zorg is van levensbelang.'),
(21, 3, 'Partij voor de Vrijheid', 1, 'Arbeidsmigratie', 'We moeten een tewerkstellingsvergunning invoeren voor arbeidsmigranten.'),
(22, 3, 'Partij voor de Vrijheid', 2, 'Asielzoekers', 'We moeten de grenzen sluiten voor alle asielzoekers en migranten uit islamitische landen.'),
(23, 3, 'Partij voor de Vrijheid', 3, 'Cultuur', 'Het is zeer belangrijk dat grondwettelijk wordt vastgelegd dat onze Joods- christelijke en humanistische wortels de dominante en leidende cultuur vormen in Nederland.'),
(24, 3, 'Partij voor de Vrijheid', 4, 'Handel en economie', 'We moeten de btwverhoging op boodschappen terugdraaien.'),
(25, 3, 'Partij voor de Vrijheid', 5, 'Klimaat', 'Een landschap om zuinig op te zijn en onze bescherming verdient tegen het vernietigende klimaatbeleid zoals windturbines en zonneparken.'),
(26, 3, 'Partij voor de Vrijheid', 6, 'Onderwijs', 'Het onderwijs moet ruime aandacht geven aan de verworven westerse vrijheden.'),
(27, 3, 'Partij voor de Vrijheid', 7, 'Nederland in de EU', 'We moeten ons niet de les laten lezen door de Europese Unie.'),
(28, 3, 'Partij voor de Vrijheid', 8, 'Veiligheid', 'We moeten taakstraffen afschaffen.'),
(29, 3, 'Partij voor de Vrijheid', 9, 'Werkgelegenheid', 'De AOW-leeftijd moet terug naar 65.'),
(30, 3, 'Partij voor de Vrijheid', 10, 'Zorg', 'We moeten een voltijdbonus voor zorgmedewerkers invoeren.'),
(31, 4, 'Christen-Democratisch Appèl', 1, 'Arbeidsmigratie', 'Werkgevers met een grote behoefte aan arbeidsmigranten een eigen verantwoordelijkheid in de opvang, huisvesting en begeleiding geven. '),
(32, 4, 'Christen-Democratisch Appèl', 2, 'Asielzoekers', 'Nederland moet een voortrekkersrol vervullen in de ontwikkeling van een Europees vluchtelingen- en asielbeleid'),
(33, 4, 'Christen-Democratisch Appèl', 3, 'Cultuur', 'Er moet een betere regionale spreiding komen van middelen en voorzieningen.'),
(34, 4, 'Christen-Democratisch Appèl', 4, 'Handel en economie', 'We moeten af van onnodige regels en ingewikkelde procedures voor ondernemers.'),
(35, 4, 'Christen-Democratisch Appèl', 5, 'Klimaat', 'We moeten afspraken maken over reductiedoelen en ondersteuning met de tien bedrijven die het meeste broeikasgas uitstoten.'),
(36, 4, 'Christen-Democratisch Appèl', 6, 'Onderwijs', 'Onderwijs in het Engels mag er niet toe leiden dat specifieke Nederlandse vraagstukken niet meer worden bestudeerd of gedoceerd.'),
(37, 4, 'Christen-Democratisch Appèl', 7, 'Nederland in de EU', 'We moeten anders kijken naar de EU dan we in de voorbije decennia deden.'),
(38, 4, 'Christen-Democratisch Appèl', 8, 'Veiligheid', 'We moeten komen met een uitsterfbeleid voor coffeeshops.'),
(39, 4, 'Christen-Democratisch Appèl', 9, 'Werkgelegenheid', 'Meer mensen moeten aan het werk kunnen gaan in contracten voor onbepaalde tijd. '),
(40, 4, 'Christen-Democratisch Appèl', 10, 'Zorg', 'We moeten een einde maken aan onzinnige regels waar veel zorgcoöperaties in ons land tegenaan lopen. '),
(41, 5, 'Socialistische Partij', 1, 'Arbeidsmigratie', 'Er moet een einde komen aan de grenzeloze en ontwrichtende arbeidsmigratie binnen de EU. '),
(42, 5, 'Socialistische Partij', 2, 'Asielzoekers', 'Tijdens extreem grote vluchtelingenstromen en voor langdurige humanitaire rampen is een eerlijke verdeling van vluchtelingen over alle andere landen een noodzaak. '),
(43, 5, 'Socialistische Partij', 3, 'Cultuur', 'We moeten stoppen met bezuinigen op cultuur. '),
(44, 5, 'Socialistische Partij', 4, 'Handel en economie', 'We moeten werknemers voortaan eerlijk laten delen in de winsten.'),
(45, 5, 'Socialistische Partij', 5, 'Klimaat', 'Investeringen in duurzaamheid moeten leiden tot meer werkgelegenheid, gerichte scholing en lagere lasten voor mensen met een middeninkomen of lager inkomen.'),
(46, 5, 'Socialistische Partij', 6, 'Onderwijs', 'Studenten moeten zonder schulden kunnen studeren.'),
(47, 5, 'Socialistische Partij', 7, 'Nederland in de EU', 'Het is belangrijk dat we onze eigen keuzes kunnen maken over bijvoorbeeld onze zorg, pensioenen en onze volkshuisvesting.'),
(48, 5, 'Socialistische Partij', 8, 'Veiligheid', 'Het is belangrijk dat iedereen toegang tot de rechter heeft.'),
(49, 5, 'Socialistische Partij', 9, 'Werkgelegenheid', 'We moeten gemeentelijke leerwerkbedrijven oprichten die mensen met een bijstandsuitkering ondersteuning bieden bij het vinden van een baan.'),
(50, 5, 'Socialistische Partij', 10, 'Zorg', 'De ziektekostenpremie moet inkomensafhankelijk gemaakt worden.'),
(51, 6, 'Partij van de Arbeid', 1, 'Arbeidsmigratie', 'Arbeidsmigratie als verdienmodel moet worden aangepakt.'),
(52, 6, 'Partij van de Arbeid', 2, 'Asielzoekers', 'Asielzoekers moeten snel duidelijkheid krijgen.'),
(53, 6, 'Partij van de Arbeid', 3, 'Cultuur', 'Alle jongeren tot en met 25 jaar moeten een cultuurkaart krijgen met een budget en kortingen voor kunst en cultuur.');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `stem`
--

DROP TABLE IF EXISTS `stem`;
CREATE TABLE IF NOT EXISTS `stem` (
  `standpunt_id` int(11) NOT NULL,
  `naamgebruiker` varchar(255) NOT NULL,
  `eens` tinyint(1) NOT NULL,
  `weging` int(11) DEFAULT NULL,
  PRIMARY KEY (`standpunt_id`,`naamgebruiker`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Gegevens worden geëxporteerd voor tabel `stem`
--

INSERT INTO `stem` (`standpunt_id`, `naamgebruiker`, `eens`, `weging`) VALUES
(1, 'test', 1, NULL);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `thema`
--

DROP TABLE IF EXISTS `thema`;
CREATE TABLE IF NOT EXISTS `thema` (
  `ThemaId` int(11) NOT NULL AUTO_INCREMENT,
  `Thema` varchar(200) NOT NULL,
  PRIMARY KEY (`ThemaId`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

--
-- Gegevens worden geëxporteerd voor tabel `thema`
--

INSERT INTO `thema` (`ThemaId`, `Thema`) VALUES
(1, 'Arbeidsmigratie'),
(2, 'Asielzoekers'),
(3, 'Cultuur'),
(4, 'Handel en economie'),
(5, 'Klimaat'),
(6, 'Onderwijs'),
(7, 'Nederland in de EU'),
(8, 'Veiligheid'),
(9, 'Werkgelegenheid'),
(10, 'Zorg');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `verkiezing`
--

DROP TABLE IF EXISTS `verkiezing`;
CREATE TABLE IF NOT EXISTS `verkiezing` (
  `VerkiezingId` int(11) NOT NULL AUTO_INCREMENT,
  `SoortId` int(11) NOT NULL,
  `Verkiezingsoort` varchar(100) NOT NULL,
  `Datum` date DEFAULT NULL,
  PRIMARY KEY (`VerkiezingId`),
  KEY `SoortId` (`SoortId`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Gegevens worden geëxporteerd voor tabel `verkiezing`
--

INSERT INTO `verkiezing` (`VerkiezingId`, `SoortId`, `Verkiezingsoort`, `Datum`) VALUES
(1, 5, 'Gemeenteraadsverkiezing', '2022-03-16'),
(2, 3, 'Provinciale Statenverkiezing', '2023-03-15'),
(3, 4, 'Waterschapsverkiezing', '2023-03-15'),
(4, 1, 'Eerste Kamerverkiezing', '2023-05-29');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `verkiezingsoort`
--

DROP TABLE IF EXISTS `verkiezingsoort`;
CREATE TABLE IF NOT EXISTS `verkiezingsoort` (
  `SoortId` int(11) NOT NULL AUTO_INCREMENT,
  `Verkiezingsoort` varchar(100) NOT NULL,
  PRIMARY KEY (`SoortId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Gegevens worden geëxporteerd voor tabel `verkiezingsoort`
--

INSERT INTO `verkiezingsoort` (`SoortId`, `Verkiezingsoort`) VALUES
(1, 'Eerste Kamerverkiezing'),
(2, 'Tweede Kamerverkiezing'),
(3, 'Provinciale Statenverkiezing'),
(4, 'Waterschapsverkiezing'),
(5, 'Gemeenteraadsverkiezing'),
(6, 'Europese verkiezing');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `verkiezingspartijen`
--

DROP TABLE IF EXISTS `verkiezingspartijen`;
CREATE TABLE IF NOT EXISTS `verkiezingspartijen` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PartijId` int(11) NOT NULL,
  `VerkiezingId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `VerkiezingId` (`VerkiezingId`),
  KEY `PartijId` (`PartijId`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;

--
-- Gegevens worden geëxporteerd voor tabel `verkiezingspartijen`
--

INSERT INTO `verkiezingspartijen` (`Id`, `PartijId`, `VerkiezingId`) VALUES
(1, 1, 1),
(2, 2, 1),
(3, 4, 1),
(4, 5, 1),
(5, 6, 1),
(6, 7, 1),
(7, 9, 1),
(8, 14, 1),
(9, 1, 2),
(10, 2, 2),
(11, 3, 2),
(12, 4, 2),
(13, 5, 2),
(14, 6, 2),
(15, 7, 2),
(16, 8, 2),
(17, 9, 2),
(18, 10, 2),
(19, 13, 2),
(20, 14, 2),
(21, 1, 3),
(22, 4, 3),
(23, 6, 3),
(24, 9, 3),
(25, 19, 3),
(26, 20, 3),
(27, 21, 3),
(28, 22, 3),
(29, 1, 4),
(30, 2, 4),
(31, 3, 4),
(32, 4, 4),
(33, 5, 4),
(34, 6, 4),
(35, 7, 4),
(36, 8, 4),
(37, 9, 4),
(38, 10, 4),
(39, 13, 4),
(40, 14, 4),
(41, 23, 4);

--
-- Beperkingen voor geëxporteerde tabellen
--

--
-- Beperkingen voor tabel `standpunten`
--
ALTER TABLE `standpunten`
  ADD CONSTRAINT `standpunten_ibfk_1` FOREIGN KEY (`PartijId`) REFERENCES `partij` (`PartijId`),
  ADD CONSTRAINT `standpunten_ibfk_2` FOREIGN KEY (`ThemaId`) REFERENCES `thema` (`ThemaId`);

--
-- Beperkingen voor tabel `stem`
--
ALTER TABLE `stem`
  ADD CONSTRAINT `stem_ibfk_1` FOREIGN KEY (`standpunt_id`) REFERENCES `standpunten` (`StandpuntId`);

--
-- Beperkingen voor tabel `verkiezing`
--
ALTER TABLE `verkiezing`
  ADD CONSTRAINT `verkiezing_ibfk_1` FOREIGN KEY (`SoortId`) REFERENCES `verkiezingsoort` (`SoortId`);

--
-- Beperkingen voor tabel `verkiezingspartijen`
--
ALTER TABLE `verkiezingspartijen`
  ADD CONSTRAINT `verkiezingspartijen_ibfk_1` FOREIGN KEY (`VerkiezingId`) REFERENCES `verkiezing` (`VerkiezingId`),
  ADD CONSTRAINT `verkiezingspartijen_ibfk_2` FOREIGN KEY (`PartijId`) REFERENCES `partij` (`PartijId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
