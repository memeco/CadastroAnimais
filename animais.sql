-- Cria o banco de dados
CREATE DATABASE db_animais;

-- Seleciona o banco de dados
USE db_animais;

-- Cria a tabela animais
CREATE TABLE animais (
    ID_Animal INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(100) NOT NULL,
    Especie VARCHAR(50) NOT NULL,
    Raca VARCHAR(50) NOT NULL,
    Idade INT NOT NULL,
    Peso DECIMAL(5, 2) NOT NULL,
    Sexo CHAR(1) NOT NULL,
    Cor VARCHAR(20) NOT NULL
);