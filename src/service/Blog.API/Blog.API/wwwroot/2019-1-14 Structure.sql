USE [master]
GO
/****** Object:  Database [siegrain.blog]    Script Date: 2019/1/14 20:13:14 ******/
CREATE DATABASE [siegrain.blog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'siegrain.blog', FILENAME = N'H:\Projects\Database\siegrain.blog.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'siegrain.blog_log', FILENAME = N'H:\Projects\Database\siegrain.blog_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [siegrain.blog] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [siegrain.blog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [siegrain.blog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [siegrain.blog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [siegrain.blog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [siegrain.blog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [siegrain.blog] SET ARITHABORT OFF 
GO
ALTER DATABASE [siegrain.blog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [siegrain.blog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [siegrain.blog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [siegrain.blog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [siegrain.blog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [siegrain.blog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [siegrain.blog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [siegrain.blog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [siegrain.blog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [siegrain.blog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [siegrain.blog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [siegrain.blog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [siegrain.blog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [siegrain.blog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [siegrain.blog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [siegrain.blog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [siegrain.blog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [siegrain.blog] SET RECOVERY FULL 
GO
ALTER DATABASE [siegrain.blog] SET  MULTI_USER 
GO
ALTER DATABASE [siegrain.blog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [siegrain.blog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [siegrain.blog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [siegrain.blog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [siegrain.blog] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'siegrain.blog', N'ON'
GO
ALTER DATABASE [siegrain.blog] SET QUERY_STORE = OFF
GO
USE [siegrain.blog]
GO
/****** Object:  Table [dbo].[Advertisement]    Script Date: 2019/1/14 20:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertisement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Createdate] [datetime] NOT NULL,
	[ImgUrl] [nvarchar](512) NULL,
	[Title] [nvarchar](64) NULL,
	[Url] [nvarchar](256) NULL,
	[Remark] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Advertisement] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogArticle]    Script Date: 2019/1/14 20:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogArticle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Author] [nvarchar](60) NULL,
	[Title] [nvarchar](256) NULL,
	[Category] [nvarchar](max) NULL,
	[Content] [text] NULL,
	[Traffic] [int] NOT NULL,
	[CommentCount] [int] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Remark] [nvarchar](max) NULL,
 CONSTRAINT [PK_BlogArticle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Module]    Script Date: 2019/1/14 20:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NULL,
	[ParentId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[LinkUrl] [nvarchar](100) NULL,
	[Area] [nvarchar](max) NULL,
	[Controller] [nvarchar](max) NULL,
	[Action] [nvarchar](max) NULL,
	[Icon] [nvarchar](100) NULL,
	[Code] [nvarchar](10) NULL,
	[OrderSort] [int] NOT NULL,
	[Description] [nvarchar](100) NULL,
	[IsMenu] [bit] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreateId] [int] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyId] [int] NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_dbo.Module] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModulePermission]    Script Date: 2019/1/14 20:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModulePermission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NULL,
	[ModuleId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
	[CreateId] [int] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyId] [int] NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_dbo.ModulePermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationLog]    Script Date: 2019/1/14 20:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NULL,
	[Area] [nvarchar](max) NULL,
	[Controller] [nvarchar](max) NULL,
	[Action] [nvarchar](max) NULL,
	[IPAddress] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[LogTime] [datetime] NULL,
	[LoginName] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
	[User_uID] [int] NULL,
 CONSTRAINT [PK_dbo.OperateLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 2019/1/14 20:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[OrderSort] [int] NOT NULL,
	[Icon] [nvarchar](100) NULL,
	[Description] [nvarchar](100) NULL,
	[Enabled] [bit] NOT NULL,
	[CreateId] [int] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyId] [int] NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_dbo.Permission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2019/1/14 20:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[OrderSort] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[CreateId] [int] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyId] [int] NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_dbo.Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleModulePermission]    Script Date: 2019/1/14 20:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleModulePermission](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NULL,
	[RoleId] [int] NOT NULL,
	[ModuleId] [int] NOT NULL,
	[PermissionId] [int] NULL,
	[CreateId] [int] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyId] [int] NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_dbo.RoleModulePermission] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysUser]    Script Date: 2019/1/14 20:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [nvarchar](60) NULL,
	[Password] [nvarchar](60) NULL,
	[RealName] [nvarchar](60) NULL,
	[Status] [int] NOT NULL,
	[Remark] [nvarchar](max) NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
	[LastErrorTime] [datetime] NOT NULL,
	[ErrorCount] [int] NOT NULL,
 CONSTRAINT [PK_dbo.sysUserInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 2019/1/14 20:13:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsDeleted] [bit] NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreateId] [int] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyId] [int] NULL,
	[ModifyBy] [nvarchar](50) NULL,
	[ModifyTime] [datetime] NULL,
 CONSTRAINT [PK_dbo.UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Module]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Module_dbo.Module_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Module] ([Id])
GO
ALTER TABLE [dbo].[Module] CHECK CONSTRAINT [FK_dbo.Module_dbo.Module_ParentId]
GO
ALTER TABLE [dbo].[ModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ModulePermission_dbo.Module_ModuleId] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ModulePermission] CHECK CONSTRAINT [FK_dbo.ModulePermission_dbo.Module_ModuleId]
GO
ALTER TABLE [dbo].[ModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ModulePermission_dbo.Permission_PermissionId] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ModulePermission] CHECK CONSTRAINT [FK_dbo.ModulePermission_dbo.Permission_PermissionId]
GO
ALTER TABLE [dbo].[OperationLog]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OperateLog_dbo.sysUserInfo_User_uID] FOREIGN KEY([User_uID])
REFERENCES [dbo].[SysUser] ([Id])
GO
ALTER TABLE [dbo].[OperationLog] CHECK CONSTRAINT [FK_dbo.OperateLog_dbo.sysUserInfo_User_uID]
GO
ALTER TABLE [dbo].[RoleModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoleModulePermission_dbo.Module_ModuleId] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleModulePermission] CHECK CONSTRAINT [FK_dbo.RoleModulePermission_dbo.Module_ModuleId]
GO
ALTER TABLE [dbo].[RoleModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoleModulePermission_dbo.Permission_PermissionId] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleModulePermission] CHECK CONSTRAINT [FK_dbo.RoleModulePermission_dbo.Permission_PermissionId]
GO
ALTER TABLE [dbo].[RoleModulePermission]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RoleModulePermission_dbo.Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleModulePermission] CHECK CONSTRAINT [FK_dbo.RoleModulePermission_dbo.Role_RoleId]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_dbo.UserRole_dbo.Role_RoleId]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserRole_dbo.sysUserInfo_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[SysUser] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_dbo.UserRole_dbo.sysUserInfo_UserId]
GO
USE [master]
GO
ALTER DATABASE [siegrain.blog] SET  READ_WRITE 
GO
