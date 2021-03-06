USE [master]
GO
/****** Object:  Database [Cliente]    Script Date: 29/04/2021 15:43:19 ******/
CREATE DATABASE [Cliente]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cliente', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Cliente.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Cliente_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Cliente_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Cliente] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cliente].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cliente] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cliente] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cliente] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cliente] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cliente] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cliente] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cliente] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Cliente] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cliente] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cliente] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cliente] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cliente] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cliente] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cliente] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cliente] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cliente] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Cliente] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cliente] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cliente] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cliente] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cliente] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cliente] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cliente] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cliente] SET RECOVERY FULL 
GO
ALTER DATABASE [Cliente] SET  MULTI_USER 
GO
ALTER DATABASE [Cliente] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cliente] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cliente] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cliente] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Cliente]
GO
/****** Object:  StoredProcedure [dbo].[GetCliente]    Script Date: 29/04/2021 15:43:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetCliente]
(
@Id int
)
as
begin
select [Id]
      ,[Nombres]
      ,[Apellidos]
      ,[Correo]
      ,[FechaNacimiento]
	  ,CONVERT(varchar(10), [FechaNacimiento], 103) as FechaNacimientoString
      ,[Direccion]
      ,[Activo]
      ,[FechaRegistro] from cliente
end
GO
/****** Object:  StoredProcedure [dbo].[InsCliente]    Script Date: 29/04/2021 15:43:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[InsCliente]
(
@Nombres varchar(250),
@Apellidos varchar(250),
@Correo varchar(320),
@FechaNacimiento datetime,
@Direccion varchar(800),
@IdRef int output
)
as
begin
set @IdRef = 0
declare @count_Cliente int
select @count_Cliente = COUNT(1) from cliente c
where c.Correo = @Correo

if(@count_Cliente = 0)
begin
insert into cliente(
      [Nombres]
      ,[Apellidos]
      ,[Correo]
      ,[FechaNacimiento]
      ,[Direccion]
      ,[Activo]
      ,[FechaRegistro] 
)
values (
@Nombres,
@Apellidos,
@Correo,
@FechaNacimiento,
@Direccion,
1,
getdate()
)
end
else
begin
set @IdRef = -1
end

end
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 29/04/2021 15:43:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](250) NOT NULL,
	[Apellidos] [varchar](250) NOT NULL,
	[Correo] [varchar](320) NOT NULL,
	[FechaNacimiento] [datetime] NULL,
	[Direccion] [varchar](800) NULL,
	[Activo] [bit] NULL,
	[FechaRegistro] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[cliente] ON 

INSERT [dbo].[cliente] ([Id], [Nombres], [Apellidos], [Correo], [FechaNacimiento], [Direccion], [Activo], [FechaRegistro]) VALUES (1, N'Carlos', N'Mamani Gomez', N'cmamani@gamez@gmail.com', CAST(N'1980-04-29 00:00:00.000' AS DateTime), N'av. los proceres 457', 1, CAST(N'2021-04-29 00:00:00.000' AS DateTime))
INSERT [dbo].[cliente] ([Id], [Nombres], [Apellidos], [Correo], [FechaNacimiento], [Direccion], [Activo], [FechaRegistro]) VALUES (2, N'Javier', N'PeraltaGomez', N'pgomez@gmail.com', CAST(N'1980-04-29 00:00:00.000' AS DateTime), N'av. los proceres 457', 1, CAST(N'2021-04-29 00:00:00.000' AS DateTime))
INSERT [dbo].[cliente] ([Id], [Nombres], [Apellidos], [Correo], [FechaNacimiento], [Direccion], [Activo], [FechaRegistro]) VALUES (3, N'JOrge', N'Vizcarra', N'sdfsdf', CAST(N'2021-04-14 00:00:00.000' AS DateTime), N'Av. 684', 1, CAST(N'2021-04-29 13:45:32.153' AS DateTime))
INSERT [dbo].[cliente] ([Id], [Nombres], [Apellidos], [Correo], [FechaNacimiento], [Direccion], [Activo], [FechaRegistro]) VALUES (4, N'Juan', N'Mero', N'8754@dsd', CAST(N'2021-04-14 00:00:00.000' AS DateTime), N'av los aloman', 1, CAST(N'2021-04-29 13:54:45.903' AS DateTime))
INSERT [dbo].[cliente] ([Id], [Nombres], [Apellidos], [Correo], [FechaNacimiento], [Direccion], [Activo], [FechaRegistro]) VALUES (5, N'Carlos', N'dsd', N'drrre@gmail.com', CAST(N'2021-04-21 00:00:00.000' AS DateTime), N'sdsdsds', 1, CAST(N'2021-04-29 14:22:21.140' AS DateTime))
INSERT [dbo].[cliente] ([Id], [Nombres], [Apellidos], [Correo], [FechaNacimiento], [Direccion], [Activo], [FechaRegistro]) VALUES (6, N'Silverio a1', N'Vizcarra', N'drrr3e@gmail.com', CAST(N'2021-04-20 00:00:00.000' AS DateTime), N'av los alamos', 1, CAST(N'2021-04-29 14:24:41.243' AS DateTime))
INSERT [dbo].[cliente] ([Id], [Nombres], [Apellidos], [Correo], [FechaNacimiento], [Direccion], [Activo], [FechaRegistro]) VALUES (7, N'Cer', N'cefer', N'Coe@fr.com', CAST(N'2021-04-13 00:00:00.000' AS DateTime), N'av los alamos', 1, CAST(N'2021-04-29 14:29:30.090' AS DateTime))
INSERT [dbo].[cliente] ([Id], [Nombres], [Apellidos], [Correo], [FechaNacimiento], [Direccion], [Activo], [FechaRegistro]) VALUES (8, N'JOrge', N'Vizcarra', N'Coe@fr.com4', CAST(N'2021-04-20 00:00:00.000' AS DateTime), N'av. los operales', 1, CAST(N'2021-04-29 14:30:11.143' AS DateTime))
SET IDENTITY_INSERT [dbo].[cliente] OFF
USE [master]
GO
ALTER DATABASE [Cliente] SET  READ_WRITE 
GO
