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
-- Estrutura da tabela `el_veiculo_marca`
--

CREATE TABLE `el_veiculo_marca` (
  `id_marca` char(36) NOT NULL,
  `nom_marca` varchar(100) NOT NULL,
  `dt_criacao` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `el_veiculo_marca`
--

INSERT INTO `el_veiculo_marca` (`id_marca`, `nom_marca`, `dt_criacao`) VALUES
('6aecc388-ab97-4158-951a-f0372d79fb4d', 'Ford', '2021-02-10 04:25:30'),
('a298af49-6544-466b-862c-8e7e59eba382', 'Fiat', '2021-02-10 04:25:30'),
('aef54ab1-5ea8-41d4-8403-2e2f9dc9b049', 'GM - Chevrolet', '2021-02-10 04:25:30'),
('d2b272c2-7c4b-4ed8-844e-db7dfcf4426c', 'Renault', '2021-02-10 15:22:24'),
('dd513817-b924-46b9-9ab5-c195369b9023', 'JEEP', '2021-02-10 15:21:59');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `el_veiculo_marca`
--
ALTER TABLE `el_veiculo_marca`
  ADD PRIMARY KEY (`id_marca`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
