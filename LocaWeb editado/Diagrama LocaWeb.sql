/*
   quinta-feira, 22 de novembro de 201821:38:19
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
ALTER TABLE dbo.Locacao
	DROP CONSTRAINT FK_Locacao_Cliente
GO
ALTER TABLE dbo.Cliente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Cliente', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Locacao
	DROP CONSTRAINT FK_Locacao_Veiculo
GO
ALTER TABLE dbo.Veiculo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Veiculo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Veiculo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Veiculo', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Locacao
	(
	codLocacao int NOT NULL IDENTITY (1, 1),
	dataInicio date NULL,
	dataEntrega date NULL,
	totalCusto nchar(10) NULL,
	veiculoID int NULL,
	clienteID int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Locacao SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Locacao ON
GO
IF EXISTS(SELECT * FROM dbo.Locacao)
	 EXEC('INSERT INTO dbo.Tmp_Locacao (codLocacao, dataInicio, dataEntrega, totalCusto, clienteID)
		SELECT codLocacao, dataInicio, dataEntrega, totalCusto, clienteID FROM dbo.Locacao WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Locacao OFF
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
	FK_Locacao_Veiculo FOREIGN KEY
	(
	veiculoID
	) REFERENCES dbo.Veiculo
	(
	veiculoID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Locacao', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Locacao', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Locacao', 'Object', 'CONTROL') as Contr_Per 