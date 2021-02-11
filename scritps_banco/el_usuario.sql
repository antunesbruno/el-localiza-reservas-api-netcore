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
-- Estrutura da tabela `el_usuario`
--

CREATE TABLE `el_usuario` (
  `id_usuario` char(36) NOT NULL,
  `cd_login` varchar(11) NOT NULL,
  `cd_senha` varchar(100) NOT NULL,
  `cd_matricula` varchar(6) DEFAULT NULL,
  `cd_cpf_usuario` varchar(11) DEFAULT NULL,
  `nom_usuario` varchar(100) NOT NULL,
  `email_usuario` varchar(100) NOT NULL,
  `dt_criacao` datetime NOT NULL,
  `idc_perfil` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `el_usuario`
--

INSERT INTO `el_usuario` (`id_usuario`, `cd_login`, `cd_senha`, `cd_matricula`, `cd_cpf_usuario`, `nom_usuario`, `email_usuario`, `dt_criacao`, `idc_perfil`) VALUES
('41045454-a7b7-412d-8e86-fc4d87d9cac8', '04183710677', '123456', '', '04183710677', 'Bruno', 'bruno@localiza.com', '2021-02-10 14:05:12', 0),
('63af063f-3ca9-e411-9797-00505690773f', '04188877766', 'Mqol1m3NPckUvrTUvf7kWaHrQHUpfxNzBpOfSzYcn4o=', '', '04188877766', 'Jose da Silva', 'jose.dasilva@gmail.com', '2021-02-08 17:07:23', 0),
('6926e767-eccf-4f70-9b49-5da6ce4f516d', '131313', 'Mqol1m3NPckUvrTUvf7kWaHrQHUpfxNzBpOfSzYcn4o=', '131313', '', 'Mariano Araujo', 'mariano.araujo@localiza.com', '2021-02-08 18:07:23', 1),
('85f89393-6bd2-4205-8175-b7c3f1aaf614', '01245678988', '12345', NULL, '01245678988', 'Bruno', 'bruno@gmail.com', '2021-02-10 14:27:27', 0);

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `el_usuario`
--
ALTER TABLE `el_usuario`
  ADD PRIMARY KEY (`id_usuario`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
