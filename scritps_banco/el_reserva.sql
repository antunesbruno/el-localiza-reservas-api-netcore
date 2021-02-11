-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 11-Fev-2021 às 21:15
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
-- Estrutura da tabela `el_reserva`
--

CREATE TABLE `el_reserva` (
  `id_reserva` char(36) NOT NULL,
  `id_cliente` char(36) NOT NULL,
  `id_usuario` char(36) NOT NULL,
  `id_veiculo` char(36) NOT NULL,
  `num_total_horas` int(11) NOT NULL,
  `vlr_total_reserva` decimal(10,0) NOT NULL,
  `idc_simulacao` tinyint(4) NOT NULL,
  `idc_efetivada` tinyint(4) NOT NULL,
  `idc_agendamento` tinyint(4) NOT NULL,
  `dt_simulacao` datetime NOT NULL,
  `dt_previsao_retirada` datetime NOT NULL,
  `dt_previsao_devolucao` datetime NOT NULL,
  `dt_retirada_real` datetime NOT NULL,
  `dt_devolucao_real` datetime NOT NULL,
  `dt_criacao` datetime NOT NULL,
  `vlr_total_pos_check` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `el_reserva`
--
ALTER TABLE `el_reserva`
  ADD PRIMARY KEY (`id_reserva`),
  ADD KEY `fk_reserva_cliente` (`id_cliente`),
  ADD KEY `fk_reserva_usuario` (`id_usuario`),
  ADD KEY `fk_reserva_veiculo` (`id_veiculo`);

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `el_reserva`
--
ALTER TABLE `el_reserva`
  ADD CONSTRAINT `fk_reserva_cliente` FOREIGN KEY (`id_cliente`) REFERENCES `el_cliente` (`id_cliente`),
  ADD CONSTRAINT `fk_reserva_usuario` FOREIGN KEY (`id_usuario`) REFERENCES `el_usuario` (`id_usuario`),
  ADD CONSTRAINT `fk_reserva_veiculo` FOREIGN KEY (`id_veiculo`) REFERENCES `el_veiculo` (`id_veiculo`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
