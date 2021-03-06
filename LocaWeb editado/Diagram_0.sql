/*
   quinta-feira, 22 de novembro de 201808:28:06
   Usuário: 
   Servidor: DESKTOP-GQAMU0V
   Banco de Dados: DbLocaWeB
   Aplicativo: 
*/

/* Para impedir possíveis problemas de perda de dados, analise este script detalhadamente antes de executá-lo fora do contexto do designer de banco de dados.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Veiculo
	(
	veiculoID int NOT NULL IDENTITY (1, 1),
	placa varchar(7) NULL,
	descricao varchar(50) NULL,
	ano date NULL,
	km numeric(18, 0) NULL,
	precoDiaria numeric(18, 2) NULL,
	categoria varchar(50) NULL,
	status varchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Veiculo SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Veiculo ON
GO
IF EXISTS(SELECT * FROM dbo.Veiculo)
	 EXEC('INSERT INTO dbo.Tmp_Veiculo (veiculoID, placa, descricao, ano, km, precoDiaria, categoria, status)
		SELECT veiculoID, placa, descricao, ano, km, precoDiaria, categoria, status FROM dbo.Veiculo WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Veiculo OFF
GO
DROP TABLE dbo.Veiculo
GO
EXECUTE sp_rename N'dbo.Tmp_Veiculo', N'Veiculo', 'OBJECT' 
GO
ALTER TABLE dbo.Veiculo ADD CONSTRAINT
	PK_Veiculo PRIMARY KEY CLUSTERED 
	(
	veiculoID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Veiculo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Veiculo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Veiculo', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Cliente
	(
	clienteID int NOT NULL IDENTITY (1, 1),
	nome varchar(50) NULL,
	cpf varchar(50) NULL,
	endereco varchar(50) NULL,
	telefone varchar(50) NULL,
	email varchar(50) NULL,
	dividaSaldo numeric(18, 2) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Cliente SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Cliente ON
GO
IF EXISTS(SELECT * FROM dbo.Cliente)
	 EXEC('INSERT INTO dbo.Tmp_Cliente (clienteID, nome, cpf, endereco, telefone, email, dividaSaldo)
		SELECT clienteID, nome, cpf, endereco, telefone, email, dividaSaldo FROM dbo.Cliente WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Cliente OFF
GO
DROP TABLE dbo.Cliente
GO
EXECUTE sp_rename N'dbo.Tmp_Cliente', N'Cliente', 'OBJECT' 
GO
ALTER TABLE dbo.Cliente ADD CONSTRAINT
	PK_Cliente PRIMARY KEY CLUSTERED 
	(
	clienteID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Locacao
	(
	codLocacao int NOT NULL,
	dataInicio date NULL,
	dataEntrega date NULL,
	totalCusto nchar(10) NULL,
	clienteID int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Locacao SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM dbo.Locacao)
	 EXEC('INSERT INTO dbo.Tmp_Locacao (codLocacao, dataInicio, dataEntrega, totalCusto, clienteID)
		SELECT codLocacao, dataInicio, dataEntrega, totalCusto, CONVERT(int, clienteID) FROM dbo.Locacao WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.Locacao
GO
EXECUTE sp_rename N'dbo.Tmp_Locacao', N'Locacao', 'OBJECT' 
GO
ALTER TABLE dbo.Locacao ADD CONSTRAINT
	PK_Locacao PRIMARY KEY CLUSTERED 
	(
	codLocacao
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Locacao ADD CONSTRAINT
	FK_Locacao_Cliente FOREIGN KEY
	(
	clienteID
	) REFERENCES dbo.Cliente
	(
	clienteID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Locacao ADD CONSTRAINT
	FK_Locacao_Locacao FOREIGN KEY
	(
	codLocacao
	) REFERENCES dbo.Locacao
	(
	codLocacao
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Locacao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Locacao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Locacao', 'Object', 'CONTROL') as Contr_Per 