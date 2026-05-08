-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Creato il: Mag 08, 2026 alle 10:07
-- Versione del server: 8.2.0
-- Versione PHP: 8.3.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_gestione_magazzino`
--

-- --------------------------------------------------------

--
-- Struttura della tabella `acquirente`
--

CREATE TABLE `acquirente` (
  `P_IVA` varchar(20) NOT NULL,
  `RAGIONE_SOCIALE` varchar(150) NOT NULL,
  `INDIRIZZO` varchar(255) DEFAULT NULL,
  `CAP_COMUNE` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dump dei dati per la tabella `acquirente`
--

INSERT INTO `acquirente` (`P_IVA`, `RAGIONE_SOCIALE`, `INDIRIZZO`, `CAP_COMUNE`) VALUES
('123', 'Matt', 'Via dell\'Industria', '60035'),
('1234', 'Pallotta Srl', 'Via 22 settmbre n.33', '60037');

-- --------------------------------------------------------

--
-- Struttura della tabella `comune`
--

CREATE TABLE `comune` (
  `CAP` varchar(10) NOT NULL,
  `CITTA` varchar(100) NOT NULL,
  `PROVINCIA` varchar(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dump dei dati per la tabella `comune`
--

INSERT INTO `comune` (`CAP`, `CITTA`, `PROVINCIA`) VALUES
('60035', 'Jesi', 'AN'),
('60037', 'Monte San Vito', 'AN'),
('62100', 'Macerata', 'MC');

-- --------------------------------------------------------

--
-- Struttura della tabella `custodita_in`
--

CREATE TABLE `custodita_in` (
  `ID_MERCE` int NOT NULL,
  `ID_SCAFFALE` varchar(20) NOT NULL,
  `QUANTITA_GIACENZA` int NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dump dei dati per la tabella `custodita_in`
--

INSERT INTO `custodita_in` (`ID_MERCE`, `ID_SCAFFALE`, `QUANTITA_GIACENZA`) VALUES
(1, '1', 34),
(2, '1', 11),
(3, '1', 2),
(4, '1', 3),
(6, '1', 30);

-- --------------------------------------------------------

--
-- Struttura della tabella `fattura`
--

CREATE TABLE `fattura` (
  `ID_FATTURA` int NOT NULL,
  `NUMERO_FATTURA` varchar(20) NOT NULL,
  `DATA_EMISSIONE` date NOT NULL,
  `P_IVA_ACQUIRENTE` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dump dei dati per la tabella `fattura`
--

INSERT INTO `fattura` (`ID_FATTURA`, `NUMERO_FATTURA`, `DATA_EMISSIONE`, `P_IVA_ACQUIRENTE`) VALUES
(6, '1', '2026-05-07', '1234'),
(7, 'Prima Fattura', '2026-05-08', '123');

-- --------------------------------------------------------

--
-- Struttura della tabella `magazzino`
--

CREATE TABLE `magazzino` (
  `ID_SCAFFALE` varchar(20) NOT NULL,
  `REPARTO` varchar(50) DEFAULT NULL,
  `CORSIA` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dump dei dati per la tabella `magazzino`
--

INSERT INTO `magazzino` (`ID_SCAFFALE`, `REPARTO`, `CORSIA`) VALUES
('1', 'Reparto1', 1);

-- --------------------------------------------------------

--
-- Struttura della tabella `merce`
--

CREATE TABLE `merce` (
  `ID_MERCE` int NOT NULL,
  `DESCRIZIONE` varchar(255) NOT NULL,
  `PREZZO_UNITARIO` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dump dei dati per la tabella `merce`
--

INSERT INTO `merce` (`ID_MERCE`, `DESCRIZIONE`, `PREZZO_UNITARIO`) VALUES
(1, 'Penna Bic Rossa', 2.00),
(2, 'Penna Bic Nera', 2.00),
(3, 'Blu', 2.00),
(4, 'Biro', 23.00),
(5, 'Pippo', 23.00),
(6, 'Quaderno a Quadretti', 2.30);

-- --------------------------------------------------------

--
-- Struttura della tabella `righe_fattura`
--

CREATE TABLE `righe_fattura` (
  `ID_FATTURA` int NOT NULL,
  `ID_MERCE` int NOT NULL,
  `QUANTITA_VENDUTA` int NOT NULL,
  `PREZZO_VENDITA` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dump dei dati per la tabella `righe_fattura`
--

INSERT INTO `righe_fattura` (`ID_FATTURA`, `ID_MERCE`, `QUANTITA_VENDUTA`, `PREZZO_VENDITA`) VALUES
(6, 1, 2, 2.00),
(6, 4, 2, 23.00),
(7, 1, 10, 2.00),
(7, 2, 11, 2.00),
(7, 6, 20, 2.30);

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `acquirente`
--
ALTER TABLE `acquirente`
  ADD PRIMARY KEY (`P_IVA`),
  ADD KEY `FK_ComuneAcquirente` (`CAP_COMUNE`);

--
-- Indici per le tabelle `comune`
--
ALTER TABLE `comune`
  ADD PRIMARY KEY (`CAP`);

--
-- Indici per le tabelle `custodita_in`
--
ALTER TABLE `custodita_in`
  ADD PRIMARY KEY (`ID_MERCE`,`ID_SCAFFALE`),
  ADD KEY `FK_CustoditaScaffale` (`ID_SCAFFALE`);

--
-- Indici per le tabelle `fattura`
--
ALTER TABLE `fattura`
  ADD PRIMARY KEY (`ID_FATTURA`),
  ADD UNIQUE KEY `NUMERO_FATTURA` (`NUMERO_FATTURA`),
  ADD KEY `FK_AcquirenteFattura` (`P_IVA_ACQUIRENTE`);

--
-- Indici per le tabelle `magazzino`
--
ALTER TABLE `magazzino`
  ADD PRIMARY KEY (`ID_SCAFFALE`);

--
-- Indici per le tabelle `merce`
--
ALTER TABLE `merce`
  ADD PRIMARY KEY (`ID_MERCE`);

--
-- Indici per le tabelle `righe_fattura`
--
ALTER TABLE `righe_fattura`
  ADD PRIMARY KEY (`ID_FATTURA`,`ID_MERCE`),
  ADD KEY `FK_RigaMerce` (`ID_MERCE`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `fattura`
--
ALTER TABLE `fattura`
  MODIFY `ID_FATTURA` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT per la tabella `merce`
--
ALTER TABLE `merce`
  MODIFY `ID_MERCE` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Limiti per le tabelle scaricate
--

--
-- Limiti per la tabella `acquirente`
--
ALTER TABLE `acquirente`
  ADD CONSTRAINT `FK_ComuneAcquirente` FOREIGN KEY (`CAP_COMUNE`) REFERENCES `comune` (`CAP`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Limiti per la tabella `custodita_in`
--
ALTER TABLE `custodita_in`
  ADD CONSTRAINT `FK_CustoditaMerce` FOREIGN KEY (`ID_MERCE`) REFERENCES `merce` (`ID_MERCE`),
  ADD CONSTRAINT `FK_CustoditaScaffale` FOREIGN KEY (`ID_SCAFFALE`) REFERENCES `magazzino` (`ID_SCAFFALE`);

--
-- Limiti per la tabella `fattura`
--
ALTER TABLE `fattura`
  ADD CONSTRAINT `FK_AcquirenteFattura` FOREIGN KEY (`P_IVA_ACQUIRENTE`) REFERENCES `acquirente` (`P_IVA`) ON DELETE RESTRICT ON UPDATE CASCADE;

--
-- Limiti per la tabella `righe_fattura`
--
ALTER TABLE `righe_fattura`
  ADD CONSTRAINT `FK_RigaFattura` FOREIGN KEY (`ID_FATTURA`) REFERENCES `fattura` (`ID_FATTURA`),
  ADD CONSTRAINT `FK_RigaMerce` FOREIGN KEY (`ID_MERCE`) REFERENCES `merce` (`ID_MERCE`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
