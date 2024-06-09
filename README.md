# BloodBank
[![NPM](https://img.shields.io/npm/l/react)](https://github.com/RobertoFarias1989/BloodBank/edit/master/LICENSE.txt) 



## 💻 Sobre o projeto


Projeto desenvolvido como parte da mentoria .NET Start do [Metódo .NET](https://metododotnet.luisdev.com.br/)

Sistema de banco de dados de doação de sangue.

Quando gerar o banco de dados será preciso criar a procedure abaixo pois é ela que irá rodar no Fast Report:

![image](https://github.com/RobertoFarias1989/BloodBank/assets/118789432/b5cf164c-21fe-4970-bbd3-78d7a2a71c05)

USE [BloodBank]
GO
/****** Object:  StoredProcedure [dbo].[SP_ReportBloodStock]    Script Date: 09/06/2024 17:48:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_ReportBloodStock]

AS

	SELECT 
		 BloodType
		,RHFactor
		,Sum(QuantityML) AS QuantityML
	FROM BloodStocks
	WHERE IsActive <> 0
	GROUP BY
		 BloodType
		,RHFactor
	ORDER BY BloodType
 
---

## 💼 Regras de negócio

- Não deixar cadastrar um doador com o mesmo e-mail.

- Menor de idade não pode doar, mas pode ter cadastro.

- Pesar no mínimo 50KG.

- Mulheres só podem doar de 90 em 90 dias.(PLUS)

- Homens só podem doar de 60 em 60 dias. (PLUS)

- Quantidade de mililitros de sangue doados deve ser entre 420ml e 470ml (PLUS)



## 🛠 Tecnologias Utilizadas

- Arquitetura limpa(speração em camadas)

- Command Query Responsibility Segregation(CQRS)

- Entity Framework Core

- Padrão Repository

- Unit Of Work

- HostedService

- Fast Reports (emissão de relatório)

- Paradigma de orientação a objetos
  
- SQL Server

- T - SQL

- Validação de APIs com FluentValidation

- NET 6

## Autor

- Roberto Farias

[![Linkedin Badge](https://img.shields.io/badge/-Roberto_Farias-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://https://www.linkedin.com/in/robertofarias1989/)](https://www.linkedin.com/in/robertofarias1989/)
[![Gmail Badge](https://img.shields.io/badge/-robertosf1989@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:math.henry04@hotmail.com)](mailto:robertosf1989@gmail.com)

---
