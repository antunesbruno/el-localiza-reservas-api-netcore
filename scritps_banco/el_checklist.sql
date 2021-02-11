-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 11-Fev-2021 às 21:14
-- Versão do servidor: 10.4.17-MariaDB
-- versão do PHP: 8.0.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `db_reservas_desafio`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `el_checklist`
--

CREATE TABLE `el_checklist` (
  `id_checklist` char(36) NOT NULL,
  `id_reserva` char(36) NOT NULL,
  `id_checklist_item` char(36) NOT NULL,
  `desc_observacao` varchar(250) NOT NULL,
  `idc_itemOk` tinyint(4) NOT NULL,
  `dt_checklist` datetime NOT NULL,
  `dt_criacao` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `el_checklist`
--
ALTER TABLE `el_checklist`
  ADD PRIMARY KEY (`id_checklist`),
  ADD KEY `fk_checklist_reserva` (`id_reserva`),
  ADD KEY `fk_check_items` (`id_checklist_item`);

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `el_checklist`
--
ALTER TABLE `el_checklist`
  ADD CONSTRAINT `fk_check_items` FOREIGN KEY (`id_checklist_item`) REFERENCES `el_checklist_items` (`id_checklist_item`),
  ADD CONSTRAINT `fk_checklist_reserva` FOREIGN KEY (`id_reserva`) REFERENCES `el_reserva` (`id_reserva`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
