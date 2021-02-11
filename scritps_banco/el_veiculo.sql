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
-- Estrutura da tabela `el_veiculo`
--

CREATE TABLE `el_veiculo` (
  `id_veiculo` char(36) NOT NULL,
  `cd_placa` varchar(10) NOT NULL,
  `id_marca` char(36) NOT NULL,
  `id_modelo` char(36) NOT NULL,
  `num_ano` int(4) NOT NULL,
  `vlr_hora` decimal(10,0) NOT NULL,
  `idc_combustivel` tinyint(4) NOT NULL,
  `idc_categoria` tinyint(4) NOT NULL,
  `num_limite_pm` int(11) NOT NULL,
  `dt_criacao` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `el_veiculo`
--

INSERT INTO `el_veiculo` (`id_veiculo`, `cd_placa`, `id_marca`, `id_modelo`, `num_ano`, `vlr_hora`, `idc_combustivel`, `idc_categoria`, `num_limite_pm`, `dt_criacao`) VALUES
('02f9e8bc-192f-475e-a0f3-c29410d6449c', 'OX1BS145', 'd2b272c2-7c4b-4ed8-844e-db7dfcf4426c', '4e50a589-27be-400e-85b1-71b162f25762', 2021, '66', 4, 1, 536, '2021-02-10 15:28:06'),
('1fd3fd9f-9684-44d7-8ae7-bcd8c852750e', 'KLH55M22', 'd2b272c2-7c4b-4ed8-844e-db7dfcf4426c', 'b9c9cc94-99cc-4333-9008-8c8a25402c83', 2021, '96', 1, 2, 380, '2021-02-10 15:30:16'),
('24a530b4-533c-4b7b-bedb-1b648efec49f', 'MNH88M22', 'aef54ab1-5ea8-41d4-8403-2e2f9dc9b049', '10b9c049-1cb8-4afe-8788-1a9c877f1cc3', 2021, '66', 4, 1, 480, '2021-02-10 15:32:21'),
('27d3e968-00c9-48fd-b170-769a73eeb8b3', 'QPP88M22', 'aef54ab1-5ea8-41d4-8403-2e2f9dc9b049', '6071d2d7-f288-4772-a396-bcbe6c827115', 2021, '49', 4, 1, 370, '2021-02-10 15:35:03'),
('45312a53-745b-4d13-8360-e7b70ed64873', 'OLX1234', '6aecc388-ab97-4158-951a-f0372d79fb4d', '863184d8-b9a5-4a14-b8e5-ef887dcf71a5', 2020, '51', 0, 0, 550, '2021-02-10 09:33:43'),
('8fc23673-1f5a-4962-a4ce-a2c33e68a73a', 'XXP12M22', 'aef54ab1-5ea8-41d4-8403-2e2f9dc9b049', '77c7d654-8d84-47e9-a997-8aaca3923b2c', 2021, '59', 4, 1, 390, '2021-02-10 15:36:29'),
('9969b5b6-0c64-4c1a-ae39-844ffe793860', 'OX1PP145', 'd2b272c2-7c4b-4ed8-844e-db7dfcf4426c', '7a80e409-bdbb-4f95-b372-e83144e81f9d', 2021, '68', 4, 1, 560, '2021-02-10 15:28:49'),
('a121f409-3fe1-4634-a29e-90b677868254', 'ONP5516', '6aecc388-ab97-4158-951a-f0372d79fb4d', '863184d8-b9a5-4a14-b8e5-ef887dcf71a5', 2019, '46', 4, 0, 540, '2021-02-11 08:31:02'),
('a9fe388f-5f1a-4915-9a73-88e030328885', 'KLH99M22', 'aef54ab1-5ea8-41d4-8403-2e2f9dc9b049', '0522d86d-a025-40cb-b557-edf5cde40684', 2021, '56', 4, 1, 420, '2021-02-10 15:31:47'),
('afdcdf7c-eef0-457a-b696-fee844b7c5ea', 'PVQ3539', '6aecc388-ab97-4158-951a-f0372d79fb4d', '863184d8-b9a5-4a14-b8e5-ef887dcf71a5', 2020, '51', 0, 0, 550, '2021-02-10 09:32:21'),
('dc739660-1f1b-4c47-af75-ddc4377cdbc5', 'PVF5522', 'd2b272c2-7c4b-4ed8-844e-db7dfcf4426c', '97a7f01f-598f-4fd0-98bb-cc4739f74d2a', 2020, '79', 1, 2, 480, '2021-02-10 15:29:34');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `el_veiculo`
--
ALTER TABLE `el_veiculo`
  ADD PRIMARY KEY (`id_veiculo`),
  ADD KEY `fk_elveiculo_elveicmarca` (`id_marca`),
  ADD KEY `fk_elveiculo_elveicmodelo` (`id_modelo`);

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `el_veiculo`
--
ALTER TABLE `el_veiculo`
  ADD CONSTRAINT `fk_elveiculo_elveicmarca` FOREIGN KEY (`id_marca`) REFERENCES `el_veiculo_marca` (`id_marca`),
  ADD CONSTRAINT `fk_elveiculo_elveicmodelo` FOREIGN KEY (`id_modelo`) REFERENCES `el_veiculo_modelo` (`id_modelo`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
