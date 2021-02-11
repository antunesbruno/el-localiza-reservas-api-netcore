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
-- Estrutura da tabela `el_checklist_items`
--

CREATE TABLE `el_checklist_items` (
  `id_checklist_item` char(36) NOT NULL,
  `desc_item` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `el_checklist_items`
--

INSERT INTO `el_checklist_items` (`id_checklist_item`, `desc_item`) VALUES
('0d9cb495-17e5-4dde-b9a7-e92362095185', 'Tanque Cheio'),
('202e9e9e-70e5-4027-a27e-1c59a437be9f', 'Carro Limpo'),
('231df84f-b109-4184-a044-5c5a735be798', 'Arranhoes'),
('b79aedd3-8153-44a4-8cb3-3f12fdcdf835', 'Amassado');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `el_checklist_items`
--
ALTER TABLE `el_checklist_items`
  ADD PRIMARY KEY (`id_checklist_item`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
