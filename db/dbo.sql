/*
 Navicat Premium Dump SQL

 Source Server         : SQL_Server
 Source Server Type    : SQL Server
 Source Server Version : 16001135 (16.00.1135)
 Source Host           : PC-SHEBA\SQLEXPRESS:1433
 Source Catalog        : vacation_db
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001135 (16.00.1135)
 File Encoding         : 65001

 Date: 29/01/2025 21:51:32
*/


-- ----------------------------
-- Table structure for departament
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[departament]') AND type IN ('U'))
	DROP TABLE [dbo].[departament]
GO

CREATE TABLE [dbo].[departament] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] varchar(128) COLLATE SQL_Latin1_General_CP1_CI_AI  NOT NULL,
  [active] bit DEFAULT 1 NULL,
  [create_date] datetime DEFAULT sysdatetime() NULL
)
GO

ALTER TABLE [dbo].[departament] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of departament
-- ----------------------------
SET IDENTITY_INSERT [dbo].[departament] ON
GO

INSERT INTO [dbo].[departament] ([id], [name], [active], [create_date]) VALUES (N'1', N'Recursos Humanos', N'1', N'2025-01-01 23:46:00.037')
GO

INSERT INTO [dbo].[departament] ([id], [name], [active], [create_date]) VALUES (N'2', N'Finanzas 2', N'0', N'2025-01-01 23:46:17.583')
GO

INSERT INTO [dbo].[departament] ([id], [name], [active], [create_date]) VALUES (N'3', N'Ventas', N'1', N'2025-01-01 23:46:26.880')
GO

INSERT INTO [dbo].[departament] ([id], [name], [active], [create_date]) VALUES (N'4', N'Operaciones', N'1', N'2025-01-01 23:46:32.990')
GO

INSERT INTO [dbo].[departament] ([id], [name], [active], [create_date]) VALUES (N'5', N'Administración', N'1', N'2025-01-02 01:02:51.060')
GO

INSERT INTO [dbo].[departament] ([id], [name], [active], [create_date]) VALUES (N'6', N'Limpieza', N'1', N'2025-01-02 01:27:16.783')
GO

INSERT INTO [dbo].[departament] ([id], [name], [active], [create_date]) VALUES (N'7', N'Ingenieria', N'1', N'2025-01-06 23:54:13.273')
GO

INSERT INTO [dbo].[departament] ([id], [name], [active], [create_date]) VALUES (N'8', N'Ejemplo2', N'0', N'2025-01-12 13:41:47.900')
GO

INSERT INTO [dbo].[departament] ([id], [name], [active], [create_date]) VALUES (N'9', N'Finanzas', N'1', N'2025-01-26 22:45:06.587')
GO

SET IDENTITY_INSERT [dbo].[departament] OFF
GO


-- ----------------------------
-- Table structure for employee
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[employee]') AND type IN ('U'))
	DROP TABLE [dbo].[employee]
GO

CREATE TABLE [dbo].[employee] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] varchar(64) COLLATE SQL_Latin1_General_CP1_CI_AI  NOT NULL,
  [paternal_surname] varchar(64) COLLATE SQL_Latin1_General_CP1_CI_AI  NOT NULL,
  [maternal_surname] varchar(64) COLLATE SQL_Latin1_General_CP1_CI_AI  NULL,
  [date_entry] date DEFAULT getdate() NOT NULL,
  [birthday] date DEFAULT getdate() NOT NULL,
  [email] varchar(128) COLLATE SQL_Latin1_General_CP1_CI_AI  NOT NULL,
  [departament_id] int  NOT NULL,
  [employee_type_id] int  NOT NULL,
  [active] bit DEFAULT 1 NULL,
  [create_date] datetime DEFAULT sysdatetime() NULL
)
GO

ALTER TABLE [dbo].[employee] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of employee
-- ----------------------------
SET IDENTITY_INSERT [dbo].[employee] ON
GO

INSERT INTO [dbo].[employee] ([id], [name], [paternal_surname], [maternal_surname], [date_entry], [birthday], [email], [departament_id], [employee_type_id], [active], [create_date]) VALUES (N'2', N'Sebastian David', N'Torres', N'Chavez', N'2020-01-19', N'1991-08-02', N'sebasdtc@outlook.com', N'1', N'1', N'0', N'2025-01-08 20:05:41.033')
GO

INSERT INTO [dbo].[employee] ([id], [name], [paternal_surname], [maternal_surname], [date_entry], [birthday], [email], [departament_id], [employee_type_id], [active], [create_date]) VALUES (N'3', N'Miguel Angel', N'Zavaleta', N'Chavez', N'2022-10-01', N'1999-07-23', N'mzavaleta@programming.com', N'4', N'2', N'0', N'2025-01-08 21:26:39.173')
GO

INSERT INTO [dbo].[employee] ([id], [name], [paternal_surname], [maternal_surname], [date_entry], [birthday], [email], [departament_id], [employee_type_id], [active], [create_date]) VALUES (N'4', N'Jose espinoza', N'Elber', NULL, N'2020-12-10', N'1999-10-12', N'jt_2022@gamil.com', N'3', N'1', N'1', N'2025-01-12 12:24:16.640')
GO

INSERT INTO [dbo].[employee] ([id], [name], [paternal_surname], [maternal_surname], [date_entry], [birthday], [email], [departament_id], [employee_type_id], [active], [create_date]) VALUES (N'5', N'Flavia', N'Torres', N'Robles', N'2020-10-19', N'2020-10-19', N'ftorres@gmail.com', N'9', N'2', N'1', N'2025-01-26 22:48:31.847')
GO

INSERT INTO [dbo].[employee] ([id], [name], [paternal_surname], [maternal_surname], [date_entry], [birthday], [email], [departament_id], [employee_type_id], [active], [create_date]) VALUES (N'6', N'Jorge', N'Aspilcueta', NULL, N'2025-01-01', N'1991-08-02', N'jaspilcueta@gmail.com', N'1', N'1', N'1', N'2025-01-26 22:48:31.847')
GO

INSERT INTO [dbo].[employee] ([id], [name], [paternal_surname], [maternal_surname], [date_entry], [birthday], [email], [departament_id], [employee_type_id], [active], [create_date]) VALUES (N'7', N'karen', N'robles', N'palacios', N'2025-01-01', N'1994-10-24', N'kroble@gmail.com', N'2', N'2', N'1', N'2025-01-29 20:44:35.250')
GO

INSERT INTO [dbo].[employee] ([id], [name], [paternal_surname], [maternal_surname], [date_entry], [birthday], [email], [departament_id], [employee_type_id], [active], [create_date]) VALUES (N'8', N'Andres', N'Villanueva', N'Sanchez', N'2024-10-22', N'2000-01-01', N'avillanueva@gmail.com', N'3', N'2', N'0', N'2025-01-29 21:23:46.670')
GO

SET IDENTITY_INSERT [dbo].[employee] OFF
GO


-- ----------------------------
-- Table structure for employee_type
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[employee_type]') AND type IN ('U'))
	DROP TABLE [dbo].[employee_type]
GO

CREATE TABLE [dbo].[employee_type] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] varchar(64) COLLATE SQL_Latin1_General_CP1_CI_AI  NOT NULL,
  [days_per_year] int  NOT NULL,
  [active] bit DEFAULT 1 NULL,
  [create_date] datetime DEFAULT sysdatetime() NULL
)
GO

ALTER TABLE [dbo].[employee_type] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of employee_type
-- ----------------------------
SET IDENTITY_INSERT [dbo].[employee_type] ON
GO

INSERT INTO [dbo].[employee_type] ([id], [name], [days_per_year], [active], [create_date]) VALUES (N'1', N'Empleados internacionales', N'21', N'1', N'2025-01-03 23:01:14.317')
GO

INSERT INTO [dbo].[employee_type] ([id], [name], [days_per_year], [active], [create_date]) VALUES (N'2', N'Empleados locales profesionales', N'16', N'1', N'2025-01-03 23:01:25.023')
GO

INSERT INTO [dbo].[employee_type] ([id], [name], [days_per_year], [active], [create_date]) VALUES (N'3', N'Empleados locales no profesionales', N'14', N'1', N'2025-01-03 23:01:42.333')
GO

SET IDENTITY_INSERT [dbo].[employee_type] OFF
GO


-- ----------------------------
-- Table structure for holiday_date
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[holiday_date]') AND type IN ('U'))
	DROP TABLE [dbo].[holiday_date]
GO

CREATE TABLE [dbo].[holiday_date] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [vacation_request_id] int  NOT NULL,
  [application_date] date  NOT NULL,
  [type] varchar(16) COLLATE SQL_Latin1_General_CP1_CI_AI DEFAULT 'Completo' NOT NULL
)
GO

ALTER TABLE [dbo].[holiday_date] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of holiday_date
-- ----------------------------
SET IDENTITY_INSERT [dbo].[holiday_date] ON
GO

SET IDENTITY_INSERT [dbo].[holiday_date] OFF
GO


-- ----------------------------
-- Table structure for role
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[role]') AND type IN ('U'))
	DROP TABLE [dbo].[role]
GO

CREATE TABLE [dbo].[role] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] varchar(64) COLLATE SQL_Latin1_General_CP1_CI_AI  NOT NULL,
  [active] bit DEFAULT 1 NULL,
  [create_date] datetime DEFAULT sysdatetime() NULL
)
GO

ALTER TABLE [dbo].[role] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of role
-- ----------------------------
SET IDENTITY_INSERT [dbo].[role] ON
GO

SET IDENTITY_INSERT [dbo].[role] OFF
GO


-- ----------------------------
-- Table structure for user
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[user]') AND type IN ('U'))
	DROP TABLE [dbo].[user]
GO

CREATE TABLE [dbo].[user] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [password] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AI  NOT NULL,
  [role_id] int  NOT NULL,
  [active] bit DEFAULT 1 NULL,
  [create_date] datetime DEFAULT sysdatetime() NULL
)
GO

ALTER TABLE [dbo].[user] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of user
-- ----------------------------
SET IDENTITY_INSERT [dbo].[user] ON
GO

SET IDENTITY_INSERT [dbo].[user] OFF
GO


-- ----------------------------
-- Table structure for vacation_requests
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[vacation_requests]') AND type IN ('U'))
	DROP TABLE [dbo].[vacation_requests]
GO

CREATE TABLE [dbo].[vacation_requests] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [employee_id] int  NOT NULL,
  [application_date] date  NULL,
  [requested_days] int  NOT NULL,
  [status] varchar(12) COLLATE SQL_Latin1_General_CP1_CI_AI DEFAULT 'Pendiente' NOT NULL
)
GO

ALTER TABLE [dbo].[vacation_requests] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of vacation_requests
-- ----------------------------
SET IDENTITY_INSERT [dbo].[vacation_requests] ON
GO

SET IDENTITY_INSERT [dbo].[vacation_requests] OFF
GO


-- ----------------------------
-- Auto increment value for departament
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[departament]', RESEED, 9)
GO


-- ----------------------------
-- Primary Key structure for table departament
-- ----------------------------
ALTER TABLE [dbo].[departament] ADD CONSTRAINT [PK__departam__3213E83F54D52E5D] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for employee
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[employee]', RESEED, 8)
GO


-- ----------------------------
-- Primary Key structure for table employee
-- ----------------------------
ALTER TABLE [dbo].[employee] ADD CONSTRAINT [PK__empleado__3213E83F77F04533] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for employee_type
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[employee_type]', RESEED, 4)
GO


-- ----------------------------
-- Primary Key structure for table employee_type
-- ----------------------------
ALTER TABLE [dbo].[employee_type] ADD CONSTRAINT [PK__tipos_em__3213E83FDABCD24D] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for holiday_date
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[holiday_date]', RESEED, 1)
GO


-- ----------------------------
-- Checks structure for table holiday_date
-- ----------------------------
ALTER TABLE [dbo].[holiday_date] ADD CONSTRAINT [CK__fechas_va__tipo___5FB337D6] CHECK ([type]='Completo' OR [type]='Tarde' OR [type]='Mañana')
GO


-- ----------------------------
-- Primary Key structure for table holiday_date
-- ----------------------------
ALTER TABLE [dbo].[holiday_date] ADD CONSTRAINT [PK__fechas_v__3213E83FAF2C8F42] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for role
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[role]', RESEED, 1)
GO


-- ----------------------------
-- Uniques structure for table role
-- ----------------------------
ALTER TABLE [dbo].[role] ADD CONSTRAINT [UQ__role__72AFBCC69BB5C7BA] UNIQUE NONCLUSTERED ([name] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table role
-- ----------------------------
ALTER TABLE [dbo].[role] ADD CONSTRAINT [PK__role__3213E83F33F2B71A] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for user
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[user]', RESEED, 1)
GO


-- ----------------------------
-- Primary Key structure for table user
-- ----------------------------
ALTER TABLE [dbo].[user] ADD CONSTRAINT [PK__user__3213E83F36757CD1] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for vacation_requests
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[vacation_requests]', RESEED, 1)
GO


-- ----------------------------
-- Checks structure for table vacation_requests
-- ----------------------------
ALTER TABLE [dbo].[vacation_requests] ADD CONSTRAINT [CK__solicitud__estad__5AEE82B9] CHECK ([status]='Pendiente' OR [status]='Rechazado' OR [status]='Aprobado')
GO


-- ----------------------------
-- Primary Key structure for table vacation_requests
-- ----------------------------
ALTER TABLE [dbo].[vacation_requests] ADD CONSTRAINT [PK__solicitu__3213E83F67B111C0] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table employee
-- ----------------------------
ALTER TABLE [dbo].[employee] ADD CONSTRAINT [FK__employee__id_de__5535A963] FOREIGN KEY ([departament_id]) REFERENCES [dbo].[departament] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[employee] ADD CONSTRAINT [FK__employee__id_ti__5629CD9C] FOREIGN KEY ([employee_type_id]) REFERENCES [dbo].[employee_type] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table holiday_date
-- ----------------------------
ALTER TABLE [dbo].[holiday_date] ADD CONSTRAINT [FK__fechas_va__id_so__5EBF139D] FOREIGN KEY ([vacation_request_id]) REFERENCES [dbo].[vacation_requests] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table user
-- ----------------------------
ALTER TABLE [dbo].[user] ADD CONSTRAINT [FK__user__role_id__693CA210] FOREIGN KEY ([role_id]) REFERENCES [dbo].[role] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table vacation_requests
-- ----------------------------
ALTER TABLE [dbo].[vacation_requests] ADD CONSTRAINT [FK__solicitud__id_em__59FA5E80] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[employee] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

