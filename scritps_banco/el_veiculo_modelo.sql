-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 11-Fev-2021 às 21:16
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
-- Estrutura da tabela `el_veiculo_modelo`
--

CREATE TABLE `el_veiculo_modelo` (
  `id_modelo` char(36) NOT NULL,
  `nom_modelo` varchar(100) NOT NULL,
  `dt_criacao` datetime NOT NULL,
  `id_marca` char(36) NOT NULL,
  `url_image_path` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `el_veiculo_modelo`
--

INSERT INTO `el_veiculo_modelo` (`id_modelo`, `nom_modelo`, `dt_criacao`, `id_marca`, `url_image_path`) VALUES
('0522d86d-a025-40cb-b557-edf5cde40684', 'GM Onix 1.0 Turbo - Fast', '2021-02-10 15:20:42', 'aef54ab1-5ea8-41d4-8403-2e2f9dc9b049', '/images/ONIX.png'),
('10b9c049-1cb8-4afe-8788-1a9c877f1cc3', 'GM Prisma 1.0', '2021-02-10 15:20:21', 'aef54ab1-5ea8-41d4-8403-2e2f9dc9b049', '/images/PRIC.png'),
('1ffd427a-3d33-47fd-835b-b86c9d9a3522', 'Argo 1.0 Fast', '2021-02-10 15:17:41', 'a298af49-6544-466b-862c-8e7e59eba382', '/images/ARGF.png'),
('397c724f-5899-45c6-8f32-4a94bddc1e09', 'Fiat Uno 1.0', '2021-02-10 15:18:10', 'a298af49-6544-466b-862c-8e7e59eba382', '/images/NUNS.png'),
('4e50a589-27be-400e-85b1-71b162f25762', 'Sandero 1.0 Fast', '2021-02-10 15:23:25', 'd2b272c2-7c4b-4ed8-844e-db7dfcf4426c', '/images/SADF.png'),
('6071d2d7-f288-4772-a396-bcbe6c827115', 'GM Onix 1.0', '2021-02-10 15:19:55', 'aef54ab1-5ea8-41d4-8403-2e2f9dc9b049', '/images/ONIX.png'),
('77c7d654-8d84-47e9-a997-8aaca3923b2c', 'GM Prisma 1.0 Turbo - Fast', '2021-02-10 15:21:12', 'aef54ab1-5ea8-41d4-8403-2e2f9dc9b049', '/images/PRIS.png'),
('7a80e409-bdbb-4f95-b372-e83144e81f9d', 'Logan 1.0 Fast', '2021-02-10 15:23:44', 'd2b272c2-7c4b-4ed8-844e-db7dfcf4426c', '/images/LOGN.png'),
('7bf9323d-c6fc-4b9d-920d-1382db213b76', 'Cronos 1.3', '2021-02-10 15:16:43', 'a298af49-6544-466b-862c-8e7e59eba382', '/images/CROX.png'),
('863184d8-b9a5-4a14-b8e5-ef887dcf71a5', 'KA Sedan 1.5 AT SEL', '0001-01-01 00:00:00', '6aecc388-ab97-4158-951a-f0372d79fb4d', '/images/KASF.png'),
('97a7f01f-598f-4fd0-98bb-cc4739f74d2a', 'Captur 1.6 Turbo', '2021-02-10 15:24:05', 'd2b272c2-7c4b-4ed8-844e-db7dfcf4426c', '/images/CAPR.png'),
('b9c9cc94-99cc-4333-9008-8c8a25402c83', 'Duster AT 1.6', '2021-02-10 15:24:29', 'd2b272c2-7c4b-4ed8-844e-db7dfcf4426c', '/images/DUAT.png'),
('e33d614b-5c9a-4d42-9014-673155dcdf3f', 'Mobi 1.0', '2021-02-10 15:18:33', 'a298af49-6544-466b-862c-8e7e59eba382', '/images/MOBI.png');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `el_veiculo_modelo`
--
ALTER TABLE `el_veiculo_modelo`
  ADD PRIMARY KEY (`id_modelo`),
  ADD KEY `fk_veiculo_marca_mod` (`id_marca`);

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `el_veiculo_modelo`
--
ALTER TABLE `el_veiculo_modelo`
  ADD CONSTRAINT `fk_veiculo_marca_mod` FOREIGN KEY (`id_marca`) REFERENCES `el_veiculo_marca` (`id_marca`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
