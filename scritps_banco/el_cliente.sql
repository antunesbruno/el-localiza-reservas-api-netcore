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
-- Estrutura da tabela `el_cliente`
--

CREATE TABLE `el_cliente` (
  `id_cliente` char(36) NOT NULL,
  `nom_cliente` varchar(100) NOT NULL,
  `nom_sobrenome_cliente` varchar(100) NOT NULL,
  `cd_cpf_cliente` varchar(11) NOT NULL,
  `email_cliente` varchar(100) NOT NULL,
  `desc_logradouro` varchar(100) NOT NULL,
  `num_residencia` smallint(6) NOT NULL,
  `desc_complemento` varchar(100) NOT NULL,
  `desc_cidade` varchar(100) NOT NULL,
  `sigla_estado` varchar(2) NOT NULL,
  `num_cep` varchar(8) NOT NULL,
  `dt_criacao` datetime NOT NULL,
  `dt_nascimento` datetime NOT NULL,
  `num_telefone` varchar(50) NOT NULL,
  `num_telefone_ddd` varchar(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `el_cliente`
--
ALTER TABLE `el_cliente`
  ADD PRIMARY KEY (`id_cliente`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
