USE [WhiteDS]
GO
/****** Object:  Table [dbo].[VocationsTypes]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VocationsTypes](
	[Vocation] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_VocationsTypes] PRIMARY KEY CLUSTERED 
(
	[Vocation] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


/****** Object:  Table [dbo].[Vocations]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vocations](
	[VocID] [int] IDENTITY(1,1) NOT NULL,
	[VocDate] [date] NULL,
	[EmployeeID] [int] NOT NULL,
	[VocationType] [nvarchar](15) NOT NULL,
	[FromDate] [date] NOT NULL,
	[ToDate] [date] NOT NULL,
	[NoDays] [int] NOT NULL,
	[NoteDetails] [nvarchar](100) NULL,
 CONSTRAINT [PK_Vocations] PRIMARY KEY CLUSTERED 
(
	[VocID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Vocations]    Script Date: 09/20/2018 13:03:46 ******/
Alter Table Vocations
Add VocID  int
go
Alter Table Vocations
Add VocDate date
go
Alter Table Vocations
Add EmployeeID int
go
Alter Table Vocations
Add VocationType  nvarchar (15)
go
Alter Table Vocations
Add FromDate date
go
Alter Table Vocations
Add ToDate  date
go
Alter Table Vocations
Add NoDays  int
go
Alter Table Vocations
Add NoteDetails  nvarchar (100)


go
/****** Object:  Table [dbo].[Users]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[UserType] [nvarchar](10) NOT NULL,
	[LastLogIn] [datetime] NULL,
	[DeviceName] [nvarchar](30) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Alter Table Users
	Add UserID [nvarchar](20) NOT NULL
	go
	Alter Table Users
	Add [Password] [nvarchar](20) NOT NULL
	go
	Alter Table Users
	Add [UserType] [nvarchar](10) NOT NULL
	go
	Alter Table Users
	Add [LastLogIn] [datetime] NULL
	go
	Alter Table Users
	Add [DeviceName] [nvarchar](30) NULL
go




/****** Object:  Table [dbo].[Settings]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SettingName] [nvarchar](1000) NOT NULL,
	[SettingValue] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[Logs]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[UserID] [int] NULL,
	[LogType] [nvarchar](50) NULL,
	[FormName] [nvarchar](50) NULL,
	[LogDate] [datetime] NULL,
	[LastValue] [nvarchar](50) NULL,
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[DeviceName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Alter table logs
add	[UserID] [int] NULL
go
	Alter table logs
add	[LogType] [nvarchar](50) NULL
go
	Alter table logs
add	[FormName] [nvarchar](50) NULL
go
	Alter table logs
add	[LogDate] [datetime] NULL
go
	Alter table logs
add	[LastValue] [nvarchar](50) NULL
go
	Alter table logs
add	[LogID] [int] IDENTITY(1,1) NOT NULL
go
	Alter table logs
add	[DeviceName] [nvarchar](50) NULL
go

/****** Object:  Table [dbo].[EmployeesPositions]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesPositions](
	[Positions] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_EmployeesPositions] PRIMARY KEY CLUSTERED 
(
	[Positions] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeesDepartments]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesDepartments](
	[Department] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_EmployeesDepartments] PRIMARY KEY CLUSTERED 
(
	[Department] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeesData]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesData](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[EmployeeName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](20) NULL,
	[Birthday] [date] NULL,
	[Indenty] [int] NULL,
	[SocialState] [nvarchar](10) NULL,
	[SonNO] [int] NULL,
	[DriverLicence] [bit] NULL,
	[Mobile1] [nvarchar](15) NULL,
	[Mobile2] [nvarchar](15) NULL,
	[PhoneNo] [nvarchar](15) NULL,
	[Email] [nvarchar](50) NULL,
	[FaceBook] [nvarchar](50) NULL,
	[Department] [nvarchar](20) NULL,
	[JobName] [nvarchar](20) NULL,
	[Branch] [nvarchar](20) NULL,
	[Salary] [int] NULL,
	[SalaryCurrency] [nvarchar](5) NULL,
	[DateOfStart] [date] NULL,
	[DateOfEnd] [date] NULL,
	[Active] [bit] NULL,
	[BankName] [nvarchar](20) NULL,
	[BankNo] [int] NULL,
	[BankBranch] [nvarchar](20) NULL,
	[PictureEmp] [image] NULL,
	[SalaryAccountNo] [nvarchar](15) NULL,
	[LicenseDate] [date] NULL,
	[Field1] [nvarchar](50) NULL,
	[Field2] [nvarchar](50) NULL,
	[Field3] [nvarchar](50) NULL,
	[Field4] [nvarchar](50) NULL,
	[Field5] [nvarchar](50) NULL,
	[Field6] [nvarchar](50) NULL,
	[Field7] [nvarchar](50) NULL,
	[Field8] [nvarchar](50) NULL,
	[UserIDInAttFile] [int] NULL,
	[Gender] [nvarchar](5) NULL,
	[DefinedONAtt] [bit] NULL,
	[VocationsLimit] [int] NULL,
	[AccessOnLogIn] [bit] NULL,
	[UserPassword] [nvarchar](20) NULL,
	[AttPlane] [int] NULL,
	[SalaryPerHour] [decimal](18, 2) NULL,
	[AccessType] [nvarchar](20) NULL,
	[DontCheckInOut] [bit] NULL,
	[VocationBeginingBalance] [int] NULL,
 CONSTRAINT [PK_EmployeesData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

Alter Table [EmployeesData]
Add [ID] [int] IDENTITY(1,1) NOT NULL
go
Alter Table [EmployeesData]
Add[EmployeeID] [int] NOT NULL
go
Alter Table [EmployeesData]
Add	[EmployeeName] [nvarchar](50) NOT NULL
go
Alter Table [EmployeesData]
Add	[Address] [nvarchar](50) NULL
go
Alter Table [EmployeesData]
ADD	[City] [nvarchar](20) NULL
go
Alter Table [EmployeesData]
aDD	[Birthday] [date] NULL
go
Alter Table [EmployeesData]
aDD	[Indenty] [int] NULL
go
Alter Table [EmployeesData]
Add	[SocialState] [nvarchar](10) NULL
go
Alter Table [EmployeesData]
Add	[SonNO] [int] NULL
go
Alter Table [EmployeesData]
Add	[DriverLicence] [bit] NULL
go
Alter Table [EmployeesData]
Add	[Mobile1] [nvarchar](15) NULL
go
Alter Table [EmployeesData]
Add	[Mobile2] [nvarchar](15) NULL
go
Alter Table [EmployeesData]
Add	[PhoneNo] [nvarchar](15) NULL
go
Alter Table [EmployeesData]
Add	[Email] [nvarchar](50) NULL
go
Alter Table [EmployeesData]
Add	[FaceBook] [nvarchar](50) NULL
go
Alter Table [EmployeesData]
Add	[Department] [nvarchar](20) NULL
go
Alter Table [EmployeesData]
Add	[JobName] [nvarchar](20) NULL
go
Alter Table [EmployeesData]
Add	[Branch] [nvarchar](20) NULL
go
Alter Table [EmployeesData]
Add	[Salary] [int] NULL
go
Alter Table [EmployeesData]
Add	[SalaryCurrency] [nvarchar](5) NULL
go
Alter Table [EmployeesData]
Add	[DateOfStart] [date] NULL
go
Alter Table [EmployeesData]
Add	[DateOfEnd] [date] NULL
go
Alter Table [EmployeesData]
Add	[Active] [bit] NULL
go
Alter Table [EmployeesData]
Add	[BankName] [nvarchar](20) NULL
go
Alter Table [EmployeesData]
Add	[BankNo] [int] NULL
go
Alter Table [EmployeesData]
Add	[BankBranch] [nvarchar](20) NULL
go
Alter Table [EmployeesData]
Add	[PictureEmp] [image] NULL
go
Alter Table [EmployeesData]
Add	[SalaryAccountNo] [nvarchar](15) NULL
go
Alter Table [EmployeesData]
Add	[LicenseDate] [date] NULL
go
Alter Table [EmployeesData]
Add	[Field1] [nvarchar](50) NULL
go
Alter Table [EmployeesData]
Add	[Field2] [nvarchar](50) NULL
go
Alter Table [EmployeesData]
Add	[Field3] [nvarchar](50) NULL
go
Alter Table [EmployeesData]
Add	[Field4] [nvarchar](50) NULL
go
Alter Table [EmployeesData]
Add	[Field5] [nvarchar](50) NULL
go
Alter Table [EmployeesData]
Add	[Field6] [nvarchar](50) NULL
go
Alter Table [EmployeesData]
Add	[Field7] [nvarchar](50) NULL
go
Alter Table [EmployeesData]
Add	[Field8] [nvarchar](50) NULL
go
Alter Table [EmployeesData]
Add	[UserIDInAttFile] [int] NULL
go
Alter Table [EmployeesData]
Add	[Gender] [nvarchar](5) NULL
go
Alter Table [EmployeesData]
Add	[DefinedONAtt] [bit] NULL
go
Alter Table [EmployeesData]
Add	[VocationsLimit] [int] NULL
go
Alter Table [EmployeesData]
Add	[AccessOnLogIn] [bit] NULL
go
Alter Table [EmployeesData]
ADD	[UserPassword] [nvarchar](20) NULL
go
Alter Table [EmployeesData]
Add	[AttPlane] [int] NULL
go
Alter Table [EmployeesData]
Add	[SalaryPerHour] [decimal](18, 2) NULL
go
Alter Table [EmployeesData]
Add	[AccessType] [nvarchar](20) NULL
go
Alter Table [EmployeesData]
Add	[DontCheckInOut] [bit] NULL
go
Alter Table [EmployeesData]
Add	[VocationBeginingBalance] [int] NULL
go	

Alter Table [EmployeesData]
Add	[RequiredDailyHoures] nvarchar(50) NULL
go	
Alter Table [EmployeesData]
Add	OffDay1 nvarchar(50) NULL
go	
Alter Table [EmployeesData]
Add	OffDay2 nvarchar(50) NULL
go	

/****** Object:  Table [dbo].[EmployeesBranches]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesBranches](
	[Branch] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_EmployeesBranches] PRIMARY KEY CLUSTERED 
(
	[Branch] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DevicesReg]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DevicesReg](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DeviceKey] [nvarchar](100) NOT NULL,
	[RegCode] [nvarchar](100) NOT NULL,
	[ClientDevice] [bit] NOT NULL,
	[RegDate] [datetime] NOT NULL,
	[SoftwareID] [nvarchar](50) NOT NULL,
	[DeviceName] [nvarchar](50) NULL,
 CONSTRAINT [PK_DevicesReg] PRIMARY KEY CLUSTERED 
(
	[DeviceKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Alter Table  DevicesReg
Add	[Id] [int] IDENTITY(1,1) NOT NULL
go
	Alter Table  DevicesReg
Add	[DeviceKey] [nvarchar](100) NOT NULL
go
	Alter Table  DevicesReg
Add	[RegCode] [nvarchar](100) NOT NULL
go
	Alter Table  DevicesReg
Add	[ClientDevice] [bit] NOT NULL
go
	Alter Table  DevicesReg
Add	[RegDate] [datetime] NOT NULL
go
	Alter Table  DevicesReg
Add	[SoftwareID] [nvarchar](50) NOT NULL
go
	Alter Table  DevicesReg
Add	[DeviceName] [nvarchar](50) NULL
	


/****** Object:  Table [dbo].[DeletedEditedTrans]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeletedEditedTrans](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TransID] [int] NOT NULL,
	[TransDate] [datetime] NOT NULL,
	[TransType] [nvarchar](50) NOT NULL,
	[EditedType] [nvarchar](50) NOT NULL,
	[EditedDate] [datetime] NOT NULL
) ON [PRIMARY]
GO

Alter table DeletedEditedTrans
Add	[ID] [int] IDENTITY(1,1) NOT NULL
	go
	Alter table DeletedEditedTrans
Add	[TransID] [int] NOT NULL
	go
	Alter table DeletedEditedTrans
Add	[TransDate] [datetime] NOT NULL
	go
	Alter table DeletedEditedTrans
Add	[TransType] [nvarchar](50) NOT NULL
	go
	Alter table DeletedEditedTrans
Add	[EditedType] [nvarchar](50) NOT NULL
	go
	Alter table DeletedEditedTrans
Add	[EditedDate] [datetime] NOT NULL

/****** Object:  Table [dbo].[CompanyData]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyData](
	[CompanyName] [nvarchar](100) NULL,
	[CompanyAddress] [nvarchar](50) NULL,
	[CompanyPhone] [nvarchar](50) NULL,
	[CompanyMobile] [nvarchar](50) NULL,
	[CompanyFax] [nvarchar](50) NULL,
	[CompanyEmail] [nvarchar](50) NULL,
	[CompanyWebSite] [nvarchar](50) NULL,
	[CompanyFaceBook] [nvarchar](50) NULL,
	[SoftwareID] [nvarchar](10) NULL,
	[TextRegistrationCode] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CheckTypes]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Alter table  CompanyData
add	[CompanyAddress] [nvarchar](500) NULL
go
Alter table  CompanyData	
add	[CompanyPhone] [nvarchar](50) NULL
go
Alter table  CompanyData	
add	[CompanyMobile] [nvarchar](50) NULL
go
Alter table  CompanyData	
add	[CompanyFax] [nvarchar](50) NULL
go
Alter table  CompanyData	
add	[CompanyEmail] [nvarchar](50) NULL
go
Alter table  CompanyData	
add	[CompanyWebSite] [nvarchar](50) NULL
go
Alter table  CompanyData	
add	[CompanyFaceBook] [nvarchar](50) NULL
go
Alter table  CompanyData	
add	[SoftwareID] [nvarchar](10) NULL
go
Alter table  CompanyData	
add	[TextRegistrationCode] [nvarchar](50) NULL



CREATE TABLE [dbo].[CheckTypes](
	[CheckType] [nchar](1) NOT NULL,
	[InArabic] [nvarchar](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CheckInOut]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CheckInOut](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TransID] [int] NULL,
	[UserID] [int] NULL,
	[UserName] [nvarchar](50) NULL,
	[In1] [datetime] NULL,
	[Out1] [datetime] NULL,
	[ElapseTime] [varchar](8) NULL,
	[In2] [datetime] NULL,
	[Out2] [datetime] NULL,
	[TransIDOut] [int] NULL,
	[ElapseTime2] [varchar](8) NULL,
 CONSTRAINT [PK_CheckInOut] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AttPlaneShifts]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttPlaneShifts](
	[ShiftID] [int] NOT NULL,
	[ShiftName] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttPlaneDuration]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttPlaneDuration](
	[PlaneID] [int] IDENTITY(1,1) NOT NULL,
	[PlaneName] [nvarchar](50) NOT NULL,
	[PlaneStartDate] [date] NOT NULL,
	[PlaneEndDate] [date] NOT NULL,
 CONSTRAINT [PK_AttPlaneDuration] PRIMARY KEY CLUSTERED 
(
	[PlaneID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Alter Table AttPlaneDuration
add [PlaneName] [nvarchar](50) NOT NULL
go
Alter Table AttPlaneDuration
add	[PlaneStartDate] [date] NOT NULL
go
Alter Table AttPlaneDuration
add	[PlaneEndDate] [date] NOT NULL
go





/****** Object:  Table [dbo].[AttPlane]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttPlane](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[DayName] [nvarchar](10) NULL,
	[PlaneID] [int] NOT NULL,
	[LateMinutes] [int] NULL,
	[EarlyMinutes] [int] NULL,
	[WorkMins] [int] NULL,
	[PlaneName] [nvarchar](50) NULL,
	[RequiredTime] [datetime] NULL,
	[PlaneType] [nvarchar](50) NULL,
 CONSTRAINT [PK_AttPlane] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
Alter table AttPlane
add	[ID] [int] IDENTITY(1,1) NOT NULL
	go
	Alter table AttPlane
add	[StartTime] [datetime] NULL
	go
	Alter table AttPlane
add	[EndTime] [datetime] NULL
	go
	Alter table AttPlane
add	[DayName] [nvarchar](10) NULL
	go
	Alter table AttPlane
add	[PlaneID] [int] NOT NULL
	go
	Alter table AttPlane
add	[LateMinutes] [int] NULL
	go
	Alter table AttPlane
add	[EarlyMinutes] [int] NULL
	go
	Alter table AttPlane
add	[WorkMins] [int] NULL
	go
	Alter table AttPlane
add	[PlaneName] [nvarchar](50) NULL
	go
	Alter table AttPlane
add	[RequiredTime] [datetime] NULL
	go
	Alter table AttPlane
add	[PlaneType] [nvarchar](50) NULL
	go
	 




/****** Object:  Table [dbo].[AttCHECKINOUT]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttCHECKINOUT](
	[USERID] [int] NOT NULL,
	[CHECKTIME] [datetime] NULL,
	[CHECKTYPE] [nvarchar](2) NULL,
	[VERIFYCODE] [nvarchar](50) NULL,
	[SENSORID] [nvarchar](50) NULL,
	[Memoinfo] [nvarchar](50) NULL,
	[WorkCode] [nvarchar](50) NULL,
	[sn] [nvarchar](50) NULL,
	[UserExtFmt] [nvarchar](50) NULL,
	[AttProcess] [int] NULL,
	[Edited] [bit] NULL,
	[EditedDate] [datetime] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EditedType] [nvarchar](10) NULL,
 CONSTRAINT [PK_AttCHECKINOUT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccessUsers]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserNo] [nvarchar](50) NULL,
	[FromID] [int] NULL,
	[QueryAccess] [bit] NULL,
	[AddAccess] [bit] NULL,
	[DeleteAccess] [bit] NULL,
	[EditAccess] [bit] NULL,
	[VisibleAccess] [bit] NULL,
 CONSTRAINT [PK_UsersAccess] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


Alter table AccessUsers
add	[ID] [int] IDENTITY(1,1) NOT NULL
go
Alter table AccessUsers	
add	[UserNo] [nvarchar](50) NULL
go
Alter table AccessUsers		
add	[FromID] [int] NULL
go
Alter table AccessUsers		
add	[QueryAccess] [bit] NULL
	go
Alter table AccessUsers	
add	[AddAccess] [bit] NULL
	go
Alter table AccessUsers	
add	[DeleteAccess] [bit] NULL
go
Alter table AccessUsers		
add	[EditAccess] [bit] NULL
	go
Alter table AccessUsers	
add	[VisibleAccess] [bit] NULL
go
	



/****** Object:  Table [dbo].[AccessForms]    Script Date: 09/20/2018 13:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessForms](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FormName] [nvarchar](50) NULL,
	[FormNameArabic] [nvarchar](50) NULL,
	[FormCategory] [nvarchar](50) NULL,
 CONSTRAINT [PK_AccessForms] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_EmployeesData_VocationBeginingBalance]    Script Date: 09/20/2018 13:03:46 ******/
ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_VocationBeginingBalance]  DEFAULT ((0)) FOR [VocationBeginingBalance]
GO

Alter table AccessForms
add	[ID] [int] IDENTITY(1,1) NOT NULL
go
Alter table AccessForms	
add	[FormName] [nvarchar](50) NULL
go
	Alter table AccessForms
add	[FormNameArabic] [nvarchar](50) NULL
go
Alter table AccessForms	
add	[FormCategory] [nvarchar](50) NULL
go


insert into Settings (SettingName,SettingValue) values ('VocationAtOffDay',0)
go
insert into Settings (SettingName,SettingValue) values ('ElapseTimeZeroOnVocationDay',1)


go
CREATE TABLE [dbo].[SettingsLogs](
	[UserID] [nvarchar](50) NULL,
	[LogName] [nvarchar](50) NULL,
	[FormName] [nvarchar](50) NULL,
	[LogDate] [datetime] NULL,
	[LastValue] [nvarchar](50) NULL,
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[LogDetails] [nvarchar](50) NULL,
	[LogErrorMessage] [nvarchar](100) NULL,
 CONSTRAINT [PK_Logs2] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

Alter table TravelAgentCompanions
add	[CompInitial] [nvarchar](5) NULL
go

Alter table TravelAgentCompanions
add	DocManualNo [nvarchar](50) NULL
go

Alter table EmployeesData
add	RestDailyHoures [nvarchar](10) NULL
go

Alter table EmployeesData
add	BonusPerHour decimal(18, 2) NULL
go

Alter table AttCHECKINOUT
add	TransIDOnAccess int NULL
go

Alter table AttCHECKINOUT
add	EditedUser [nvarchar](50) NULL
go

Alter table EmployeesData
add	DailyTransport decimal(18, 2) NULL
go

CREATE TABLE [dbo].[AttEmployeePayments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentDate] [datetime] NULL,
	[EmployeeID] [int] NULL,
	[PaymentAmount] [decimal](18, 2) NULL,
	[PaymentNote] [nvarchar](max) NULL,
	[PaymentType] [nvarchar](50) NULL,
 CONSTRAINT [PK_AttEmployeePayments] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
go

CREATE TABLE [dbo].[AttPaymentsTypes](
	[PaymentType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AttPaymentsTypes] PRIMARY KEY CLUSTERED 
(
	[PaymentType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
go


Alter table EmployeesData
add	FactorLate decimal(18, 2) NULL
go

Alter table AttPlane
add	ShiftRest [int] NULL
go

Alter table VocationsTypes
add	VocationPaid [bit] NULL
go
 

CREATE TABLE [dbo].[AttAdditionsTypes](
	[AdditionsType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AttAdditionsِِTypes] PRIMARY KEY CLUSTERED 
(
	[AdditionsType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

go

CREATE TABLE [dbo].[AttEmployeeAdditions](
	[AdditionID] [int] IDENTITY(1,1) NOT NULL,
	[AdditionDate] [datetime] NULL,
	[EmployeeID] [int] NULL,
	[AdditionAmount] [decimal](18, 2) NULL,
	[AdditionNote] [nvarchar](max) NULL,
	[AdditionType] [nvarchar](50) NULL,
 CONSTRAINT [PK_AttEmployeeAdditions] PRIMARY KEY CLUSTERED 
(
	[AdditionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

Insert into Settings (SettingName,SettingValue) values ('DaysInMonth',30)

Go


Insert into Settings (SettingName,SettingValue) values ('BonusOnDayOff',1) 
go


Alter table Vocations
add	BatchNo [int] NULL
go

/****** Object:  Delete Duplicates Values in settings table    Script Date: 10/11/2019 23:27:42 ******/
  WITH cte AS (
    SELECT 
        SettingName, 
        ROW_NUMBER() OVER (
            PARTITION BY 
                SettingName
            ORDER BY 
               SettingName
        ) row_num
     FROM 
        [TrueTime].[dbo].[Settings]
)
DELETE FROM cte
WHERE row_num > 1;

go 

/****** Object:  Drop Index     Script Date: 10/11/2019 23:27:42 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Settings]') AND name = N'PK_Settings')
ALTER TABLE [dbo].[Settings] DROP CONSTRAINT [PK_Settings]
GO



/****** Object:  Make [SettingName] to index    Script Date: 10/11/2019 23:27:42 ******/
ALTER TABLE [dbo].[Settings] ADD  CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[SettingName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


Insert into Settings (SettingName,SettingValue) values ('BonusAmountAfterRequirdHoures',1) 
Go

CREATE TABLE [dbo].[Machines](
	[ID] [int] NOT NULL,
	[MachineAlias] [nvarchar](50) NULL,
	[ConnectType] [int] NULL,
	[IP] [nvarchar](50) NULL,
	[SerialPort] [int] NULL,
	[Port] [int] NULL,
	[Baudrate] [int] NULL,
	[MachineNumber] [int] NULL,
	[IsHost] [bit] NULL,
	[Enabled] [bit] NULL,
	[CommPassword] [nvarchar](50) NULL,
	[UILanguage] [int] NULL,
	[DateFormat] [int] NULL,
	[InOutRecordWarn] [int] NULL,
	[Idle] [int] NULL,
	[Voice] [int] NULL,
	[managercount] [int] NULL,
	[usercount] [int] NULL,
	[fingercount] [int] NULL,
	[SecretCount] [int] NULL,
	[FirmwareVersion] [nvarchar](50) NULL,
	[ProductType] [nvarchar](50) NULL,
	[LockControl] [int] NULL,
	[Purpose] [int] NULL,
	[ProduceKind] [int] NULL,
	[sn] [nvarchar](50) NULL,
	[PhotoStamp] [nvarchar](50) NULL,
	[IsIfChangeConfigServer2] [int] NULL,
	[pushver] [int] NULL,
	[IsAndroid] [nvarchar](50) NULL,
 CONSTRAINT [PK_Machines] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


Alter table dbo.EmployeesData
add	ArchiveFolder [nvarchar] (200) NULL
go

Alter table dbo.AttCHECKINOUT
add EditNote [nvarchar] (50) NULL
go



CREATE TABLE [dbo].[AttRawatebArchive](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocMonth] [int] NULL,
	[DocYear] [int] NULL,
	[EmployeeID] [int] NULL,
	[EmployeeNoAsAcc] [nvarchar](50) NULL,
	[EmployeeName] [nvarchar](50) NULL,
	[Branch] [nvarchar](20) NULL,
	[Department] [nvarchar](20) NULL,
	[JobName] [nvarchar](20) NULL,
	[BeginDate] [date] NULL,
	[Currency] [nvarchar](5) NULL,
	[SalaryMonth] [decimal](18, 2) NULL,
	[BonusAmount] [decimal](18, 2) NULL,
	[Transport] [decimal](18, 2) NULL,
	[Additions] [decimal](18, 2) NULL,
	[LeavesAmount] [decimal](18, 2) NULL,
	[Payment] [decimal](18, 2) NULL,
	[GrossSalary] [decimal](18, 2) NULL,
	[MonthDays] [decimal](18, 1) NULL,
	[ActualDays] [decimal](18, 1) NULL,
	[VocationDays] [decimal](18, 1) NULL,
	[WeekOffDays] [decimal](18, 1) NULL,
	[AbsenceDays] [decimal](18, 1) NULL,
	[HouresRequired] [nvarchar](50) NULL,
	[ActualHoures] [nvarchar](50) NULL,
	[VocationBegBalance] [decimal](18, 1) NULL,
	[AccruedVocationDays] [decimal](18, 1) NULL,
	[VocationCurrentBalance] [decimal](18, 1) NULL,
	[VocationAtEndYear] [decimal](18, 1) NULL,
	[VocationSick] [decimal](18, 1) NULL,
	[NetSalary] [decimal](18, 2) NULL,
	[DateFrom] [date] NULL,
	[DateTo] [date] NULL,
 CONSTRAINT [PK_AttRawatebArchive] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

Alter table EmployeesData
add	IBAN [nvarchar](50) NULL
Go

Alter table EmployeesData
add	SubtractionLeavesAndLates [bit] NULL
Go



Alter table EmployeesData
add	AddBonusToSalary [bit] NULL
Go

Alter table EmployeesData
add	MaxLeavesHoures [NVARCHAR] (10) NULL
Go

ALTER TABLE dbo.Vocations
ALTER  COLUMN NoDays [decimal] (18, 2)

go

Alter table AttRawatebArchive
add	HouresNetBonus [nvarchar](10) NULL
Go

Alter table AttRawatebArchive
add	HouresNetLeaves [nvarchar](10) NULL
Go


Alter table AttRawatebArchive
add	Indenty [int] NULL
Go

Alter table AttRawatebArchive
add	BankName [nvarchar](20) NULL
Go

Alter table AttRawatebArchive
add	BankNo [int] NULL
Go

Alter table AttRawatebArchive
add	BankBranch [nvarchar](20) NULL
Go


Alter table AttRawatebArchive
add	IBAN [nvarchar](50) NULL
Go


CREATE TABLE [dbo].[VacationsBalancesAdding](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BalanceDate] [date] NULL,
	[BalanceDays] [decimal](18, 0) NULL,
	[Employee] [nvarchar](50) NULL,
	[BatchNo] [int] NULL,
 CONSTRAINT [PK_VacationsBalancesAdding] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

Insert into Settings (SettingName,SettingValue) values ('YearBeginingDate','2019-01-01') 
Go

Insert into Settings (SettingName,SettingValue) values ('YearEndingDate','2019-12-31') 
Go

Alter table VocationsTypes
add	VocationDefaultBalance [int] NULL
Go

Alter table VacationsBalancesAdding
add	VocationType [nvarchar](50) NULL
Go

ALTER TABLE VocationsTypes
ADD VocID INT IDENTITY

Go

 update Vocations 
 set VocationType =( select VocID from dbo.VocationsTypes as dd where dd.Vocation=Vocations.VocationType ) 
 
 Go

CREATE TABLE [dbo].[VocationsDefaultBalances](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VocID] [int] NULL,
	[EmployeeID] [nvarchar](50) NULL,
	[DefaultBalanceForEmployee] [int] NULL,
 CONSTRAINT [PK_VocationsDefaultBalances] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


 Insert into Settings (SettingName,SettingValue) values ('TempForOpenForms','Dawam') 
Go

CREATE TABLE [dbo].[ArchiveDocs](
	[DocID] [int] IDENTITY(1,1) NOT NULL,
	[DocName] [nvarchar](100) NULL,
	[DocAccountCode] [nvarchar](50) NULL,
	[DocInputUser] [nvarchar](50) NULL,
	[DocSort1] [int] NULL,
	[DocSort2] [int] NULL,
	[DocCostCenter] [nvarchar](50) NULL,
	[DocDetails] [nvarchar](100) NULL,
	[DocLocation] [nvarchar](100) NULL,
	[DocType] [nvarchar](50) NULL,
	[DocFile] [varbinary](max) NULL,
	[DocStatus] [int] NULL,
	[DocInputDate] [datetime] NULL,
	[DocExpireDate] [datetime] NULL,
	[DocCreatedDate] [datetime] NULL,
	[DocNo] [nvarchar](50) NULL,
	[DocCode] [nvarchar](50) NULL,
	[TextDateModified] [datetime] NULL,
	[DocVersion] [int] NULL,
 CONSTRAINT [PK_ArchiveDocs] PRIMARY KEY CLUSTERED 
(
	[DocID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[ArchiveDocsSorts1](
	[ArchiveDocsSorts1] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ArchiveDocsTypes] PRIMARY KEY CLUSTERED 
(
	[ArchiveDocsSorts1] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


Insert into Settings (SettingName,SettingValue) values ('Archive_DeleteDocAfterArchive','1') 

Go
  -- Update CheckTypes set InArabic=N'عودة مغادرة عمل' where CheckType='i' COLLATE Latin1_General_CS_AS 
  -- Update CheckTypes set InArabic=N'مغادرة عمل' where CheckType='o' COLLATE Latin1_General_CS_AS 
Go

Alter table EmployeesData
add	ProcessType [nvarchar](50) NULL
Go


Alter table AccessForms
add DisplayForArchive [bit] Null
Go
Alter table AccessForms
add LinkedTable [nvarchar](50) Null
Go
Alter table AccessForms
add Field1 [nvarchar](50) Null
Go
Alter table AccessForms
add Field2 [nvarchar](50) Null
Go  
Alter table AccessForms
add Field3 [nvarchar](50) Null
Go 
Alter table AccessForms
add Field4 [nvarchar](50) Null
Go 
Alter table AccessForms
add Field5 [nvarchar](50) Null
Go 

 Update AccessForms set DisplayForArchive=1,LinkedTable='Vocations',Field1='VocID',Field2='VocDate',Field3='EmployeeID',Field4='NoDays',Field5='NoteDetails' where FormName ='AddVocation' 
Go

Alter table ArchiveDocs add LinkDocType [nvarchar] (50) null

Go
 Alter table ArchiveDocs add LinkDocNo [nvarchar] (50) null
Go





ALTER TABLE AccessUsers
ALTER COLUMN FromID [nvarchar] (50) not null
Go

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].AccessForms') AND name = N'PK_AccessForms')
ALTER TABLE [dbo].[AccessForms] DROP CONSTRAINT [PK_AccessForms]
GO

ALTER TABLE AccessForms
ALTER COLUMN FormName [nvarchar] (50) not null
Go

/****** Object:  Make [SettingName] to index    Script Date: 10/11/2019 23:27:42 ******/
ALTER TABLE [dbo].[AccessForms] ADD  CONSTRAINT [PK_AccessForms] PRIMARY KEY CLUSTERED 
(
	[FormName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

Insert into Settings (SettingName,SettingValue) values ('ShowVocationBegBalanceInRawatebSplit','True') 
 Go
Insert into Settings (SettingName,SettingValue) values ('ShowAccruedVocationDaysInRawatebSplit','True') 
 Go
Insert into Settings (SettingName,SettingValue) values ('ShowVocationAtEndYearInRawatebSplit','True') 
 Go
 Insert into Settings (SettingName,SettingValue) values ('AddBonusBeforeShift','True') 
 Go
Alter table EmployeesData
add	CreditAccountNo [int] NULL
Go

ALTER TABLE Settings ALTER COLUMN SettingValue [nvarchar] (1000) null
Go

ALTER TABLE Settings ALTER COLUMN SettingName [nvarchar] (1000) not null
Go


Insert into Settings (SettingName,SettingValue) values ('SalaryNoteLabel',':بتوقيع الموظف على هذا الكشف يقر أنه قد قام باستلام مستحقاته كاملة ويوافق على ما جاء في هذه القسيمة من ارصدة') 
Go

ALTER TABLE [EmployeesData]
ALTER COLUMN [BankNo] [nvarchar] (50)  null
Go

ALTER TABLE [EmployeesData]
Add   [BonusOnDayOff] [decimal](18, 2)  not NULL,
DEFAULT 1.00 FOR [BonusOnDayOff]
Go

ALTER TABLE [dbo].[AttRawatebArchive]
ALTER COLUMN [BankNo] [nvarchar] (50)  null
Go

ALTER TABLE [EmployeesData] ADD DEFAULT '00:00' FOR [RequiredDailyHoures]
Go

update  [dbo].[EmployeesData] set [RequiredDailyHoures]='00:00' where [RequiredDailyHoures] is null
Go

ALTER TABLE [dbo].[EmployeesData]
ALTER COLUMN [RequiredDailyHoures] [nvarchar] (50) not null
Go


/****** the date of begining and date of end shoud have value  ******/
ALTER TABLE [EmployeesData] ADD DEFAULT '1900-01-01' FOR [DateOfStart]
Go
update  [dbo].[EmployeesData] set [DateOfStart]='1900-01-01' where [DateOfStart] is null
Go
ALTER TABLE [dbo].[EmployeesData] ALTER COLUMN [DateOfStart] [date] not null
Go

ALTER TABLE [EmployeesData] ADD DEFAULT '2100-01-01' FOR [DateOfEnd]
Go
update  [dbo].[EmployeesData] set [DateOfEnd]='2100-01-01' where [DateOfEnd] is null
update  [dbo].[EmployeesData] set [DateOfEnd]='2100-01-01' where [DateOfEnd] ='1900-01-01'
Go
ALTER TABLE [dbo].[EmployeesData] ALTER COLUMN [DateOfEnd] [date] not null
Go
/************************ finish  *******************************/


CREATE TABLE [dbo].[AddCustomField](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FieldName] [nvarchar](50) NULL,
	[FieldArabicName] [nvarchar](50) NULL,
	[FieldString] [nvarchar](100) NULL,
	[ReportName] [nvarchar](50) NULL,
 CONSTRAINT [PK_AddCustomField] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Alter table AttRawatebArchive
add	CustColomn [decimal](18, 2) NULL
Go


update  [dbo].[EmployeesData] set [DailyTransport]='0' where DailyTransport is null
Go


CREATE TABLE [dbo].[EmployeesItems](
	[ItemName] [nvarchar](50) NOT NULL,
	[ItemNo] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_EmployeesProducts] PRIMARY KEY CLUSTERED 
(
	[ItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeesOhdah]    Script Date: 22/02/2021 8:24:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesOhdah](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeNo] [varchar](50) NOT NULL,
	[ItemNo] [nvarchar](50) NOT NULL,
	[OnDate] [date] NOT NULL,
	[Notes] [nvarchar](100) NULL,
	[OhdahStatus] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_EmployeesOhdah] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Locations](
	[LocationName] [nvarchar](50) NOT NULL,
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [EmployeesData]
Add   [Location] [int]  NULL
Go


Insert into Settings (SettingName,SettingValue) values ('VocationTableInMonthSalaryVisible','True') 


CREATE TABLE [dbo].[AttPlaneForPeriod](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AttTransDate] [date] NOT NULL,
	[PlaneID] [int] NULL,
	[EmpID] [nvarchar](50) NOT NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Location] [int] NULL,
	[Notes] [nvarchar](100) NULL,
 CONSTRAINT [PK_AttPlaneForPeriod] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  اضافة حقول جديدة  ******/
Alter table AttPlaneForPeriod
add	[LateMinutes] [int] NULL
Alter table AttPlaneForPeriod
add	[EarlyMinutes] [int] NULL
Alter table AttPlaneForPeriod
add	[ShiftRest] [int] NULL
GO
ALTER TABLE [dbo].[AttPlaneForPeriod] ADD  CONSTRAINT [DF_AttPlaneForPeriod_LateMinutes]  DEFAULT ((0)) FOR [LateMinutes]
GO
ALTER TABLE [dbo].[AttPlaneForPeriod] ADD  CONSTRAINT [DF_AttPlaneForPeriod_EarlyMinutes]  DEFAULT ((0)) FOR [EarlyMinutes]
GO
ALTER TABLE [dbo].[AttPlaneForPeriod] ADD  CONSTRAINT [DF_AttPlaneForPeriod_ShiftRest]  DEFAULT ((0)) FOR [ShiftRest]
GO


Insert into Settings (SettingName,SettingValue) values ('AttConnectionType','Access') 

Go


GO
/****** Object:  Table [dbo].[ACGroup]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACGroup](
	[GroupID] [smallint] NOT NULL,
	[Name] [varchar](30) NULL,
	[TimeZone1] [smallint] NULL,
	[TimeZone2] [smallint] NULL,
	[TimeZone3] [smallint] NULL,
	[holidayvaild] [bit] NULL,
	[verifystyle] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ACTimeZones]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACTimeZones](
	[TimeZoneID] [smallint] NOT NULL,
	[Name] [varchar](30) NULL,
	[SunStart] [datetime] NULL,
	[SunEnd] [datetime] NULL,
	[MonStart] [datetime] NULL,
	[MonEnd] [datetime] NULL,
	[TuesStart] [datetime] NULL,
	[TuesEnd] [datetime] NULL,
	[WedStart] [datetime] NULL,
	[WedEnd] [datetime] NULL,
	[ThursStart] [datetime] NULL,
	[ThursEnd] [datetime] NULL,
	[FriStart] [datetime] NULL,
	[FriEnd] [datetime] NULL,
	[SatStart] [datetime] NULL,
	[SatEnd] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TimeZoneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ACUnlockComb]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ACUnlockComb](
	[UnlockCombID] [smallint] NOT NULL,
	[Name] [varchar](30) NULL,
	[Group01] [smallint] NULL,
	[Group02] [smallint] NULL,
	[Group03] [smallint] NULL,
	[Group04] [smallint] NULL,
	[Group05] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[UnlockCombID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlarmLog]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlarmLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Operator] [varchar](20) NULL,
	[EnrollNumber] [varchar](30) NULL,
	[LogTime] [datetime] NULL,
	[MachineAlias] [varchar](20) NULL,
	[AlarmType] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttParam]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttParam](
	[PARANAME] [varchar](20) NOT NULL,
	[PARATYPE] [varchar](2) NULL,
	[PARAVALUE] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PARANAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditedExc]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditedExc](
	[AEID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CheckTime] [datetime] NOT NULL,
	[NewExcID] [int] NULL,
	[IsLeave] [smallint] NULL,
	[UName] [varchar](20) NULL,
	[UTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AUTHDEVICE]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUTHDEVICE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERID] [int] NOT NULL,
	[MachineID] [int] NOT NULL,
 CONSTRAINT [AUTHKEY] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[MachineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHECKEXACT]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHECKEXACT](
	[EXACTID] [int] IDENTITY(1,1) NOT NULL,
	[USERID] [int] NULL,
	[CHECKTIME] [datetime] NULL,
	[CHECKTYPE] [varchar](2) NULL,
	[ISADD] [smallint] NULL,
	[YUYIN] [varchar](25) NULL,
	[ISMODIFY] [smallint] NULL,
	[ISDELETE] [smallint] NULL,
	[INCOUNT] [smallint] NULL,
	[ISCOUNT] [smallint] NULL,
	[MODIFYBY] [varchar](20) NULL,
	[DATE] [datetime] NULL,
 CONSTRAINT [EXACTID] PRIMARY KEY CLUSTERED 
(
	[EXACTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHECKINOUT]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHECKINOUT](
	[USERID] [int] NOT NULL,
	[CHECKTIME] [datetime] NOT NULL,
	[CHECKTYPE] [varchar](1) NULL,
	[VERIFYCODE] [int] NULL,
	[SENSORID] [varchar](5) NULL,
	[Memoinfo] [varchar](30) NULL,
	[WorkCode] [varchar](24) NULL,
	[sn] [varchar](20) NULL,
	[UserExtFmt] [smallint] NULL,
 CONSTRAINT [USERCHECKTIME] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[CHECKTIME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DEPARTMENTS]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DEPARTMENTS](
	[DEPTID] [int] IDENTITY(1,1) NOT NULL,
	[DEPTNAME] [varchar](30) NULL,
	[SUPDEPTID] [int] NOT NULL,
	[InheritParentSch] [smallint] NULL,
	[InheritDeptSch] [smallint] NULL,
	[InheritDeptSchClass] [smallint] NULL,
	[AutoSchPlan] [smallint] NULL,
	[InLate] [smallint] NULL,
	[OutEarly] [smallint] NULL,
	[InheritDeptRule] [smallint] NULL,
	[MinAutoSchInterval] [int] NULL,
	[RegisterOT] [smallint] NULL,
	[DefaultSchId] [int] NOT NULL,
	[ATT] [smallint] NULL,
	[Holiday] [smallint] NULL,
	[OverTime] [smallint] NULL,
 CONSTRAINT [DEPTID] PRIMARY KEY CLUSTERED 
(
	[DEPTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeptUsedSchs]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeptUsedSchs](
	[DeptId] [int] NOT NULL,
	[SchId] [int] NOT NULL,
 CONSTRAINT [DEPT_USED_SCH] PRIMARY KEY CLUSTERED 
(
	[DeptId] ASC,
	[SchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmOpLog]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmOpLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERID] [int] NOT NULL,
	[OperateTime] [datetime] NOT NULL,
	[manipulationID] [int] NULL,
	[Params1] [int] NULL,
	[Params2] [int] NULL,
	[Params3] [int] NULL,
	[Params4] [int] NULL,
	[SensorId] [varchar](5) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EXCNOTES]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EXCNOTES](
	[USERID] [int] NULL,
	[ATTDATE] [datetime] NULL,
	[NOTES] [varchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FaceTemp]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FaceTemp](
	[TEMPLATEID] [int] IDENTITY(1,1) NOT NULL,
	[USERNO] [varchar](24) NULL,
	[SIZE] [int] NULL,
	[pin] [int] NULL,
	[FACEID] [int] NULL,
	[VALID] [int] NULL,
	[RESERVE] [int] NULL,
	[ACTIVETIME] [int] NULL,
	[VFCOUNT] [int] NULL,
	[TEMPLATE] [image] NULL,
	[UserID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TEMPLATEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOLIDAYS]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOLIDAYS](
	[HOLIDAYID] [int] IDENTITY(1,1) NOT NULL,
	[HOLIDAYNAME] [varchar](20) NULL,
	[HOLIDAYYEAR] [smallint] NULL,
	[HOLIDAYMONTH] [smallint] NULL,
	[HOLIDAYDAY] [smallint] NULL,
	[STARTTIME] [datetime] NULL,
	[DURATION] [smallint] NULL,
	[HOLIDAYTYPE] [smallint] NULL,
	[XINBIE] [varchar](4) NULL,
	[MINZU] [varchar](50) NULL,
	[DeptID] [smallint] NULL,
	[timezone] [int] NULL,
 CONSTRAINT [HOLID] PRIMARY KEY CLUSTERED 
(
	[HOLIDAYID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveClass]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveClass](
	[LeaveId] [int] IDENTITY(1,1) NOT NULL,
	[LeaveName] [varchar](20) NOT NULL,
	[MinUnit] [float] NOT NULL,
	[Unit] [smallint] NOT NULL,
	[RemaindProc] [smallint] NOT NULL,
	[RemaindCount] [smallint] NOT NULL,
	[ReportSymbol] [varchar](4) NOT NULL,
	[Deduct] [float] NOT NULL,
	[Color] [int] NOT NULL,
	[Classify] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LeaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LeaveClass1]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveClass1](
	[LeaveId] [int] IDENTITY(999,1) NOT NULL,
	[LeaveName] [varchar](20) NOT NULL,
	[MinUnit] [float] NOT NULL,
	[Unit] [smallint] NOT NULL,
	[RemaindProc] [smallint] NOT NULL,
	[RemaindCount] [smallint] NOT NULL,
	[ReportSymbol] [varchar](4) NOT NULL,
	[Deduct] [float] NOT NULL,
	[LeaveType] [smallint] NOT NULL,
	[Color] [int] NOT NULL,
	[Classify] [smallint] NOT NULL,
	[Calc] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[LeaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Machines]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Machines](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MachineAlias] [varchar](20) NOT NULL,
	[ConnectType] [int] NOT NULL,
	[IP] [varchar](20) NULL,
	[SerialPort] [int] NULL,
	[Port] [int] NULL,
	[Baudrate] [int] NULL,
	[MachineNumber] [int] NOT NULL,
	[IsHost] [bit] NULL,
	[Enabled] [bit] NULL,
	[CommPassword] [varchar](12) NULL,
	[UILanguage] [smallint] NULL,
	[DateFormat] [smallint] NULL,
	[InOutRecordWarn] [smallint] NULL,
	[Idle] [smallint] NULL,
	[Voice] [smallint] NULL,
	[managercount] [smallint] NULL,
	[usercount] [smallint] NULL,
	[fingercount] [smallint] NULL,
	[SecretCount] [smallint] NULL,
	[FirmwareVersion] [varchar](20) NULL,
	[ProductType] [varchar](20) NULL,
	[LockControl] [smallint] NULL,
	[Purpose] [smallint] NULL,
	[ProduceKind] [int] NULL,
	[sn] [varchar](20) NULL,
	[PhotoStamp] [varchar](20) NULL,
	[IsIfChangeConfigServer2] [int] NULL,
	[IsAndroid] [varchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NUM_RUN]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NUM_RUN](
	[NUM_RUNID] [int] IDENTITY(1,1) NOT NULL,
	[OLDID] [int] NULL,
	[NAME] [varchar](30) NOT NULL,
	[STARTDATE] [datetime] NULL,
	[ENDDATE] [datetime] NULL,
	[CYLE] [smallint] NULL,
	[UNITS] [smallint] NULL,
 CONSTRAINT [NUMID] PRIMARY KEY CLUSTERED 
(
	[NUM_RUNID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NUM_RUN_DEIL]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NUM_RUN_DEIL](
	[NUM_RUNID] [smallint] NOT NULL,
	[STARTTIME] [datetime] NOT NULL,
	[ENDTIME] [datetime] NULL,
	[SDAYS] [smallint] NOT NULL,
	[EDAYS] [smallint] NULL,
	[SCHCLASSID] [int] NULL,
	[OverTime] [int] NULL,
 CONSTRAINT [NUMID2] PRIMARY KEY CLUSTERED 
(
	[NUM_RUNID] ASC,
	[SDAYS] ASC,
	[STARTTIME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportItem]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportItem](
	[RIID] [int] IDENTITY(1,1) NOT NULL,
	[RIIndex] [int] NULL,
	[ShowIt] [smallint] NULL,
	[RIName] [varchar](12) NULL,
	[UnitName] [varchar](6) NULL,
	[Formula] [image] NOT NULL,
	[CalcBySchClass] [smallint] NULL,
	[StatisticMethod] [smallint] NULL,
	[CalcLast] [smallint] NULL,
	[Notes] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[RIID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchClass]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchClass](
	[schClassid] [int] IDENTITY(1,1) NOT NULL,
	[schName] [varchar](20) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[LateMinutes] [int] NULL,
	[EarlyMinutes] [int] NULL,
	[CheckIn] [int] NULL,
	[CheckOut] [int] NULL,
	[CheckInTime1] [datetime] NULL,
	[CheckInTime2] [datetime] NULL,
	[CheckOutTime1] [datetime] NULL,
	[CheckOutTime2] [datetime] NULL,
	[Color] [int] NULL,
	[AutoBind] [smallint] NULL,
	[WorkDay] [float] NULL,
	[SensorID] [varchar](5) NULL,
	[WorkMins] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[schClassid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SECURITYDETAILS]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SECURITYDETAILS](
	[SECURITYDETAILID] [int] IDENTITY(1,1) NOT NULL,
	[USERID] [int] NULL,
	[DEPTID] [smallint] NULL,
	[SCHEDULE] [smallint] NULL,
	[USERINFO] [smallint] NULL,
	[ENROLLFINGERS] [smallint] NULL,
	[REPORTVIEW] [smallint] NULL,
	[REPORT] [varchar](10) NULL,
	[ReadOnly] [bit] NULL,
	[FullControl] [bit] NULL,
 CONSTRAINT [NAMEID2] PRIMARY KEY CLUSTERED 
(
	[SECURITYDETAILID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServerLog]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServerLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EVENT] [varchar](30) NOT NULL,
	[USERID] [int] NOT NULL,
	[EnrollNumber] [varchar](30) NULL,
	[parameter] [smallint] NULL,
	[EVENTTIME] [datetime] NOT NULL,
	[SENSORID] [varchar](5) NULL,
	[OPERATOR] [varchar](20) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SHIFT]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SHIFT](
	[SHIFTID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [varchar](20) NULL,
	[USHIFTID] [int] NULL,
	[STARTDATE] [datetime] NOT NULL,
	[ENDDATE] [datetime] NULL,
	[RUNNUM] [smallint] NULL,
	[SCH1] [int] NULL,
	[SCH2] [int] NULL,
	[SCH3] [int] NULL,
	[SCH4] [int] NULL,
	[SCH5] [int] NULL,
	[SCH6] [int] NULL,
	[SCH7] [int] NULL,
	[SCH8] [int] NULL,
	[SCH9] [int] NULL,
	[SCH10] [int] NULL,
	[SCH11] [int] NULL,
	[SCH12] [int] NULL,
	[CYCLE] [smallint] NULL,
	[UNITS] [smallint] NULL,
 CONSTRAINT [SHIFTS] PRIMARY KEY CLUSTERED 
(
	[SHIFTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemLog]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Operator] [varchar](20) NULL,
	[LogTime] [datetime] NULL,
	[MachineAlias] [varchar](20) NULL,
	[LogTag] [smallint] NULL,
	[LogDescr] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBKEY]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBKEY](
	[PreName] [varchar](12) NULL,
	[ONEKEY] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBSMSALLOT]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBSMSALLOT](
	[REFERENCE] [int] NOT NULL,
	[SMSREF] [int] NOT NULL,
	[USERREF] [int] NOT NULL,
	[GENTM] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[REFERENCE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBSMSINFO]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBSMSINFO](
	[REFERENCE] [int] NOT NULL,
	[SMSID] [varchar](16) NOT NULL,
	[SMSINDEX] [int] NOT NULL,
	[SMSTYPE] [int] NULL,
	[SMSCONTENT] [text] NULL,
	[SMSSTARTTM] [varchar](32) NULL,
	[SMSTMLENG] [int] NULL,
	[GENTM] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[REFERENCE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TEMPLATE]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TEMPLATE](
	[TEMPLATEID] [int] IDENTITY(1,1) NOT NULL,
	[USERID] [int] NOT NULL,
	[FINGERID] [int] NOT NULL,
	[TEMPLATE] [image] NOT NULL,
	[TEMPLATE2] [image] NULL,
	[TEMPLATE3] [image] NULL,
	[BITMAPPICTURE] [image] NULL,
	[BITMAPPICTURE2] [image] NULL,
	[BITMAPPICTURE3] [image] NULL,
	[BITMAPPICTURE4] [image] NULL,
	[USETYPE] [smallint] NULL,
	[EMACHINENUM] [varchar](3) NULL,
	[TEMPLATE1] [image] NULL,
	[Flag] [smallint] NULL,
	[DivisionFP] [smallint] NULL,
	[TEMPLATE4] [image] NULL,
 CONSTRAINT [TEMPLATED] PRIMARY KEY CLUSTERED 
(
	[TEMPLATEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER_OF_RUN]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_OF_RUN](
	[USERID] [int] NOT NULL,
	[NUM_OF_RUN_ID] [int] NOT NULL,
	[STARTDATE] [datetime] NOT NULL,
	[ENDDATE] [datetime] NOT NULL,
	[ISNOTOF_RUN] [int] NULL,
	[ORDER_RUN] [int] NULL,
 CONSTRAINT [USER_ST_NUM] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[NUM_OF_RUN_ID] ASC,
	[STARTDATE] ASC,
	[ENDDATE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER_SPEDAY]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_SPEDAY](
	[USERID] [int] NOT NULL,
	[STARTSPECDAY] [datetime] NOT NULL,
	[ENDSPECDAY] [datetime] NULL,
	[DATEID] [smallint] NOT NULL,
	[YUANYING] [varchar](200) NULL,
	[DATE] [datetime] NULL,
 CONSTRAINT [USER_SEP] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[STARTSPECDAY] ASC,
	[DATEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USER_TEMP_SCH]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER_TEMP_SCH](
	[USERID] [int] NOT NULL,
	[COMETIME] [datetime] NOT NULL,
	[LEAVETIME] [datetime] NOT NULL,
	[OVERTIME] [int] NOT NULL,
	[TYPE] [smallint] NULL,
	[FLAG] [smallint] NULL,
	[SCHCLASSID] [int] NULL,
 CONSTRAINT [USER_TEMP] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[COMETIME] ASC,
	[LEAVETIME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserACMachines]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserACMachines](
	[UserID] [int] NOT NULL,
	[Deviceid] [int] NOT NULL,
 CONSTRAINT [UserAC_Machines] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[Deviceid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserACPrivilege]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserACPrivilege](
	[UserID] [int] NOT NULL,
	[DeviceID] [int] NOT NULL,
	[ACGroupID] [int] NULL,
	[IsUseGroup] [bit] NULL,
	[TimeZone1] [int] NULL,
	[TimeZone2] [int] NULL,
	[TimeZone3] [int] NULL,
	[verifystyle] [int] NULL,
 CONSTRAINT [pk_privilege] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[DeviceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERINFO]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERINFO](
	[USERID] [int] IDENTITY(1,1) NOT NULL,
	[BADGENUMBER] [varchar](24) NOT NULL,
	[SSN] [varchar](20) NULL,
	[NAME] [varchar](40) NULL,
	[GENDER] [varchar](8) NULL,
	[TITLE] [varchar](20) NULL,
	[PAGER] [varchar](20) NULL,
	[BIRTHDAY] [datetime] NULL,
	[HIREDDAY] [datetime] NULL,
	[STREET] [varchar](80) NULL,
	[CITY] [varchar](2) NULL,
	[STATE] [varchar](2) NULL,
	[ZIP] [varchar](12) NULL,
	[OPHONE] [varchar](20) NULL,
	[FPHONE] [varchar](20) NULL,
	[VERIFICATIONMETHOD] [smallint] NULL,
	[DEFAULTDEPTID] [smallint] NULL,
	[SECURITYFLAGS] [smallint] NULL,
	[ATT] [smallint] NOT NULL,
	[INLATE] [smallint] NOT NULL,
	[OUTEARLY] [smallint] NOT NULL,
	[OVERTIME] [smallint] NOT NULL,
	[SEP] [smallint] NOT NULL,
	[HOLIDAY] [smallint] NOT NULL,
	[MINZU] [varchar](8) NULL,
	[PASSWORD] [varchar](50) NULL,
	[LUNCHDURATION] [smallint] NOT NULL,
	[MVerifyPass] [varchar](10) NULL,
	[PHOTO] [image] NULL,
	[Notes] [image] NULL,
	[privilege] [int] NULL,
	[InheritDeptSch] [smallint] NULL,
	[InheritDeptSchClass] [smallint] NULL,
	[AutoSchPlan] [smallint] NULL,
	[MinAutoSchInterval] [int] NULL,
	[RegisterOT] [smallint] NULL,
	[InheritDeptRule] [smallint] NULL,
	[EMPRIVILEGE] [smallint] NULL,
	[CardNo] [varchar](20) NULL,
	[FaceGroup] [int] NULL,
	[AccGroup] [int] NULL,
	[UseAccGroupTZ] [int] NULL,
	[VerifyCode] [int] NULL,
	[Expires] [int] NULL,
	[ValidCount] [int] NULL,
	[ValidTimeBegin] [datetime] NULL,
	[ValidTimeEnd] [datetime] NULL,
	[TimeZone1] [int] NULL,
	[TimeZone2] [int] NULL,
	[TimeZone3] [int] NULL,
	[Pin1] [int] NULL,
 CONSTRAINT [USERIDS] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersMachines]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersMachines](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USERID] [int] NOT NULL,
	[DEVICEID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUpdates]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUpdates](
	[UpdateId] [int] IDENTITY(1,1) NOT NULL,
	[BadgeNumber] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[UpdateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUsedSClasses]    Script Date: 24-04-2021 15:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUsedSClasses](
	[UserId] [int] NOT NULL,
	[SchId] [int] NOT NULL,
 CONSTRAINT [USER_USED_SCL] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[SchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ACGroup] ([GroupID], [Name], [TimeZone1], [TimeZone2], [TimeZone3], [holidayvaild], [verifystyle]) VALUES (1, NULL, 1, 0, 0, NULL, NULL)
INSERT [dbo].[ACGroup] ([GroupID], [Name], [TimeZone1], [TimeZone2], [TimeZone3], [holidayvaild], [verifystyle]) VALUES (2, NULL, 0, 0, 0, NULL, NULL)
INSERT [dbo].[ACGroup] ([GroupID], [Name], [TimeZone1], [TimeZone2], [TimeZone3], [holidayvaild], [verifystyle]) VALUES (3, NULL, 0, 0, 0, NULL, NULL)
INSERT [dbo].[ACGroup] ([GroupID], [Name], [TimeZone1], [TimeZone2], [TimeZone3], [holidayvaild], [verifystyle]) VALUES (4, NULL, 0, 0, 0, NULL, NULL)
INSERT [dbo].[ACGroup] ([GroupID], [Name], [TimeZone1], [TimeZone2], [TimeZone3], [holidayvaild], [verifystyle]) VALUES (5, NULL, 0, 0, 0, NULL, NULL)
GO
INSERT [dbo].[ACUnlockComb] ([UnlockCombID], [Name], [Group01], [Group02], [Group03], [Group04], [Group05]) VALUES (1, NULL, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[ACUnlockComb] ([UnlockCombID], [Name], [Group01], [Group02], [Group03], [Group04], [Group05]) VALUES (2, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ACUnlockComb] ([UnlockCombID], [Name], [Group01], [Group02], [Group03], [Group04], [Group05]) VALUES (3, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ACUnlockComb] ([UnlockCombID], [Name], [Group01], [Group02], [Group03], [Group04], [Group05]) VALUES (4, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ACUnlockComb] ([UnlockCombID], [Name], [Group01], [Group02], [Group03], [Group04], [Group05]) VALUES (5, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ACUnlockComb] ([UnlockCombID], [Name], [Group01], [Group02], [Group03], [Group04], [Group05]) VALUES (6, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ACUnlockComb] ([UnlockCombID], [Name], [Group01], [Group02], [Group03], [Group04], [Group05]) VALUES (7, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ACUnlockComb] ([UnlockCombID], [Name], [Group01], [Group02], [Group03], [Group04], [Group05]) VALUES (8, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ACUnlockComb] ([UnlockCombID], [Name], [Group01], [Group02], [Group03], [Group04], [Group05]) VALUES (9, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[ACUnlockComb] ([UnlockCombID], [Name], [Group01], [Group02], [Group03], [Group04], [Group05]) VALUES (10, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'CheckInColor', NULL, N'16777151')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'CheckOutColor', NULL, N'12910591')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'DBVersion', NULL, N'379')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'MinsEarly', NULL, N'5')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'MinsLate', NULL, N'10')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'MinsNoBreakIn', NULL, N'60')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'MinsNoBreakOut', NULL, N'60')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'MinsNoIn', NULL, N'60')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'MinsNoLeave', NULL, N'60')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'MinsNotOverTime', NULL, N'60')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'MinsWorkDay', NULL, N'420')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'NoBreakIn', NULL, N'1012')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'NoBreakOut', NULL, N'1012')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'NoIn', NULL, N'1001')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'NoLeave', NULL, N'1002')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'OutOverTime', NULL, N'0')
INSERT [dbo].[AttParam] ([PARANAME], [PARATYPE], [PARAVALUE]) VALUES (N'TwoDay', NULL, N'0')
GO
SET IDENTITY_INSERT [dbo].[DEPARTMENTS] ON 

INSERT [dbo].[DEPARTMENTS] ([DEPTID], [DEPTNAME], [SUPDEPTID], [InheritParentSch], [InheritDeptSch], [InheritDeptSchClass], [AutoSchPlan], [InLate], [OutEarly], [InheritDeptRule], [MinAutoSchInterval], [RegisterOT], [DefaultSchId], [ATT], [Holiday], [OverTime]) VALUES (1, N'Our Company', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[DEPARTMENTS] OFF
GO
SET IDENTITY_INSERT [dbo].[LeaveClass] ON 

INSERT [dbo].[LeaveClass] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [Color], [Classify]) VALUES (1, N'Sick', 1, 1, 1, 1, N'B', 0, 3398744, 0)
INSERT [dbo].[LeaveClass] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [Color], [Classify]) VALUES (2, N'Vacation', 1, 1, 1, 1, N'S', 0, 8421631, 0)
INSERT [dbo].[LeaveClass] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [Color], [Classify]) VALUES (3, N'Other', 1, 1, 1, 1, N'T', 0, 16744576, 0)
SET IDENTITY_INSERT [dbo].[LeaveClass] OFF
GO
SET IDENTITY_INSERT [dbo].[LeaveClass1] ON 

INSERT [dbo].[LeaveClass1] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [LeaveType], [Color], [Classify], [Calc]) VALUES (999, N'BLeave', 0.5, 3, 1, 1, N'G', 0, 3, 0, 0, N'if(AttItem(LeaveType1)=999,AttItem(LeaveTime1),0)+if(AttItem(LeaveType2)=999,AttItem(LeaveTime2),0)+if(AttItem(LeaveType3)=999,AttItem(LeaveTime3),0)+if(AttItem(LeaveType4)=999,AttItem(LeaveTime4),0)+if(AttItem(LeaveType5)=999,AttItem(LeaveTime5),0)')
INSERT [dbo].[LeaveClass1] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [LeaveType], [Color], [Classify], [Calc]) VALUES (1000, N'Normal', 0.5, 3, 1, 0, N' ', 0, 3, 0, 0, NULL)
INSERT [dbo].[LeaveClass1] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [LeaveType], [Color], [Classify], [Calc]) VALUES (1001, N'Late', 10, 2, 2, 1, N'>', 0, 3, 0, 0, N'AttItem(minLater)')
INSERT [dbo].[LeaveClass1] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [LeaveType], [Color], [Classify], [Calc]) VALUES (1002, N'Early', 10, 2, 2, 1, N'<', 0, 3, 0, 0, N'AttItem(minEarly)')
INSERT [dbo].[LeaveClass1] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [LeaveType], [Color], [Classify], [Calc]) VALUES (1003, N'AfL', 1, 1, 1, 1, N'L', 0, 3, 0, 0, N'if((AttItem(LeaveType1)>0) and (AttItem(LeaveType1)<999),AttItem(LeaveTime1),0)+if((AttItem(LeaveType2)>0) and (AttItem(LeaveType2)<999),AttItem(LeaveTime2),0)+if((AttItem(LeaveType3)>0) and (AttItem(LeaveType3)<999),AttItem(LeaveTime3),0)+if((AttItem(LeaveType4)>0) and (AttItem(LeaveType4)<999),AttItem(LeaveTime4),0)+if((AttItem(LeaveType5)>0) and (AttItem(LeaveType5)<999),AttItem(LeaveTime5),0)')
INSERT [dbo].[LeaveClass1] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [LeaveType], [Color], [Classify], [Calc]) VALUES (1004, N'Absent', 0.5, 3, 1, 0, N'A', 0, 3, 0, 0, N'AttItem(MinAbsent)')
INSERT [dbo].[LeaveClass1] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [LeaveType], [Color], [Classify], [Calc]) VALUES (1005, N'OT', 1, 1, 1, 1, N'+', 0, 3, 0, 0, N'AttItem(MinOverTime)')
INSERT [dbo].[LeaveClass1] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [LeaveType], [Color], [Classify], [Calc]) VALUES (1006, N'OT2', 1, 1, 0, 1, N'=', 0, 0, 0, 0, N'if(HolidayId(1)=1, AttItem(MinOverTime),0)')
INSERT [dbo].[LeaveClass1] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [LeaveType], [Color], [Classify], [Calc]) VALUES (1007, N'Rest', 0.5, 3, 2, 1, N'-', 0, 2, 0, 0, NULL)
INSERT [dbo].[LeaveClass1] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [LeaveType], [Color], [Classify], [Calc]) VALUES (1008, N'N/In', 1, 4, 2, 1, N'[', 0, 2, 0, 0, N'If(AttItem(CheckIn)=null,If(AttItem(OnDuty)=null,0,if(((AttItem(LeaveStart1)=null) or (AttItem(LeaveStart1)>AttItem(OnDuty))) and AttItem(DutyOn),1,0)),0)')
INSERT [dbo].[LeaveClass1] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [LeaveType], [Color], [Classify], [Calc]) VALUES (1009, N'N/Out', 1, 4, 2, 1, N']', 0, 2, 0, 0, N'If(AttItem(CheckOut)=null,If(AttItem(OffDuty)=null,0,if((AttItem(LeaveEnd1)=null) or (AttItem(LeaveEnd1)<AttItem(OffDuty)),if((AttItem(LeaveEnd2)=null) or (AttItem(LeaveEnd2)<AttItem(OffDuty)),if(((AttItem(LeaveEnd3)=null) or (AttItem(LeaveEnd3)<AttItem(OffDuty))) and AttItem(DutyOff),1,0),0),0)),0)')
INSERT [dbo].[LeaveClass1] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [LeaveType], [Color], [Classify], [Calc]) VALUES (1010, N'ROT', 1, 4, 2, 1, N'{', 0, 3, 0, 0, NULL)
INSERT [dbo].[LeaveClass1] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [LeaveType], [Color], [Classify], [Calc]) VALUES (1011, N'BOUT', 1, 4, 2, 1, N'}', 0, 3, 0, 0, NULL)
INSERT [dbo].[LeaveClass1] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [LeaveType], [Color], [Classify], [Calc]) VALUES (1012, N'OUT', 1, 1, 2, 1, N'L', 0, 3, 0, 0, NULL)
INSERT [dbo].[LeaveClass1] ([LeaveId], [LeaveName], [MinUnit], [Unit], [RemaindProc], [RemaindCount], [ReportSymbol], [Deduct], [LeaveType], [Color], [Classify], [Calc]) VALUES (1013, N'FOT', 1, 1, 2, 1, N'F', 0, 3, 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[LeaveClass1] OFF
GO
INSERT [dbo].[TBKEY] ([PreName], [ONEKEY]) VALUES (N'SREF', 0)
INSERT [dbo].[TBKEY] ([PreName], [ONEKEY]) VALUES (N'FENREF', 0)
INSERT [dbo].[TBKEY] ([PreName], [ONEKEY]) VALUES (N'LOGREF', 0)
GO
SET IDENTITY_INSERT [dbo].[USERINFO] ON 

INSERT [dbo].[USERINFO] ([USERID], [BADGENUMBER], [SSN], [NAME], [GENDER], [TITLE], [PAGER], [BIRTHDAY], [HIREDDAY], [STREET], [CITY], [STATE], [ZIP], [OPHONE], [FPHONE], [VERIFICATIONMETHOD], [DEFAULTDEPTID], [SECURITYFLAGS], [ATT], [INLATE], [OUTEARLY], [OVERTIME], [SEP], [HOLIDAY], [MINZU], [PASSWORD], [LUNCHDURATION], [MVerifyPass], [PHOTO], [Notes], [privilege], [InheritDeptSch], [InheritDeptSchClass], [AutoSchPlan], [MinAutoSchInterval], [RegisterOT], [InheritDeptRule], [EMPRIVILEGE], [CardNo], [FaceGroup], [AccGroup], [UseAccGroupTZ], [VerifyCode], [Expires], [ValidCount], [ValidTimeBegin], [ValidTimeEnd], [TimeZone1], [TimeZone2], [TimeZone3], [Pin1]) VALUES (1, N'1', NULL, N'1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, 1, 1, 1, 1, 1, NULL, NULL, 1, NULL, NULL, NULL, 0, 1, 1, 1, 24, 1, 1, 0, NULL, 0, 1, 1, 0, 0, 0, NULL, NULL, 1, 0, 0, NULL)
SET IDENTITY_INSERT [dbo].[USERINFO] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [DEPTNAME]    Script Date: 24-04-2021 15:56:33 ******/
CREATE NONCLUSTERED INDEX [DEPTNAME] ON [dbo].[DEPARTMENTS]
(
	[DEPTNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [EXCNOTE]    Script Date: 24-04-2021 15:56:33 ******/
CREATE UNIQUE NONCLUSTERED INDEX [EXCNOTE] ON [dbo].[EXCNOTES]
(
	[USERID] ASC,
	[ATTDATE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [FACEID]    Script Date: 24-04-2021 15:56:33 ******/
CREATE NONCLUSTERED INDEX [FACEID] ON [dbo].[FaceTemp]
(
	[FACEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [TEMPLATEID]    Script Date: 24-04-2021 15:56:33 ******/
CREATE NONCLUSTERED INDEX [TEMPLATEID] ON [dbo].[FaceTemp]
(
	[TEMPLATEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [USERNO]    Script Date: 24-04-2021 15:56:33 ******/
CREATE NONCLUSTERED INDEX [USERNO] ON [dbo].[FaceTemp]
(
	[USERNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [VALID]    Script Date: 24-04-2021 15:56:33 ******/
CREATE NONCLUSTERED INDEX [VALID] ON [dbo].[FaceTemp]
(
	[VALID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [HOLIDAYNAME]    Script Date: 24-04-2021 15:56:33 ******/
CREATE UNIQUE NONCLUSTERED INDEX [HOLIDAYNAME] ON [dbo].[HOLIDAYS]
(
	[HOLIDAYNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UK_SMSINFOCode]    Script Date: 24-04-2021 15:56:33 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UK_SMSINFOCode] ON [dbo].[TBSMSINFO]
(
	[SMSID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [USERFINGER]    Script Date: 24-04-2021 15:56:33 ******/
CREATE UNIQUE NONCLUSTERED INDEX [USERFINGER] ON [dbo].[TEMPLATE]
(
	[USERID] ASC,
	[FINGERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [BADGENUMBER]    Script Date: 24-04-2021 15:56:33 ******/
CREATE UNIQUE NONCLUSTERED INDEX [BADGENUMBER] ON [dbo].[USERINFO]
(
	[BADGENUMBER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ACGroup] ADD  DEFAULT ((0)) FOR [TimeZone1]
GO
ALTER TABLE [dbo].[ACGroup] ADD  DEFAULT ((0)) FOR [TimeZone2]
GO
ALTER TABLE [dbo].[ACGroup] ADD  DEFAULT ((0)) FOR [TimeZone3]
GO
ALTER TABLE [dbo].[AlarmLog] ADD  DEFAULT (getdate()) FOR [LogTime]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [USERID]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [CHECKTIME]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [CHECKTYPE]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [ISADD]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [ISMODIFY]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [ISDELETE]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [INCOUNT]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ((0)) FOR [ISCOUNT]
GO
ALTER TABLE [dbo].[CHECKEXACT] ADD  DEFAULT ('Temp-Supervisor') FOR [MODIFYBY]
GO
ALTER TABLE [dbo].[CHECKINOUT] ADD  DEFAULT (getdate()) FOR [CHECKTIME]
GO
ALTER TABLE [dbo].[CHECKINOUT] ADD  DEFAULT ('I') FOR [CHECKTYPE]
GO
ALTER TABLE [dbo].[CHECKINOUT] ADD  DEFAULT ((0)) FOR [VERIFYCODE]
GO
ALTER TABLE [dbo].[CHECKINOUT] ADD  DEFAULT ((0)) FOR [WorkCode]
GO
ALTER TABLE [dbo].[CHECKINOUT] ADD  DEFAULT ((0)) FOR [UserExtFmt]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [SUPDEPTID]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [InheritParentSch]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [InheritDeptSch]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [InheritDeptSchClass]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [AutoSchPlan]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [InLate]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [OutEarly]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [InheritDeptRule]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((24)) FOR [MinAutoSchInterval]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [RegisterOT]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [DefaultSchId]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [ATT]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [Holiday]
GO
ALTER TABLE [dbo].[DEPARTMENTS] ADD  DEFAULT ((1)) FOR [OverTime]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [SIZE]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [pin]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [FACEID]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [VALID]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [RESERVE]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [ACTIVETIME]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [VFCOUNT]
GO
ALTER TABLE [dbo].[FaceTemp] ADD  DEFAULT ((0)) FOR [UserID]
GO
ALTER TABLE [dbo].[HOLIDAYS] ADD  DEFAULT ((1)) FOR [HOLIDAYDAY]
GO
ALTER TABLE [dbo].[HOLIDAYS] ADD  DEFAULT ((1)) FOR [DeptID]
GO
ALTER TABLE [dbo].[HOLIDAYS] ADD  DEFAULT ((0)) FOR [timezone]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ((1)) FOR [MinUnit]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ((1)) FOR [Unit]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ((1)) FOR [RemaindProc]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ((1)) FOR [RemaindCount]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ('-') FOR [ReportSymbol]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ((0)) FOR [Deduct]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ((0)) FOR [Color]
GO
ALTER TABLE [dbo].[LeaveClass] ADD  DEFAULT ((0)) FOR [Classify]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((1)) FOR [MinUnit]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((0)) FOR [Unit]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((2)) FOR [RemaindProc]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((1)) FOR [RemaindCount]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ('-') FOR [ReportSymbol]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((0)) FOR [Deduct]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((0)) FOR [LeaveType]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((0)) FOR [Color]
GO
ALTER TABLE [dbo].[LeaveClass1] ADD  DEFAULT ((0)) FOR [Classify]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((1)) FOR [SerialPort]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((1)) FOR [Port]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((1)) FOR [MachineNumber]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [UILanguage]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [DateFormat]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [InOutRecordWarn]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [Idle]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [Voice]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [managercount]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [usercount]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [fingercount]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [SecretCount]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((-1)) FOR [LockControl]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((1)) FOR [Purpose]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((1)) FOR [ProduceKind]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((0)) FOR [PhotoStamp]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((0)) FOR [IsIfChangeConfigServer2]
GO
ALTER TABLE [dbo].[Machines] ADD  DEFAULT ((0)) FOR [IsAndroid]
GO
ALTER TABLE [dbo].[NUM_RUN] ADD  DEFAULT ((-1)) FOR [OLDID]
GO
ALTER TABLE [dbo].[NUM_RUN] ADD  DEFAULT ('1900-1-1') FOR [STARTDATE]
GO
ALTER TABLE [dbo].[NUM_RUN] ADD  DEFAULT ('2099-12-31') FOR [ENDDATE]
GO
ALTER TABLE [dbo].[NUM_RUN] ADD  DEFAULT ((1)) FOR [CYLE]
GO
ALTER TABLE [dbo].[NUM_RUN] ADD  DEFAULT ((1)) FOR [UNITS]
GO
ALTER TABLE [dbo].[NUM_RUN_DEIL] ADD  DEFAULT ((-1)) FOR [SCHCLASSID]
GO
ALTER TABLE [dbo].[SchClass] ADD  DEFAULT ((1)) FOR [CheckIn]
GO
ALTER TABLE [dbo].[SchClass] ADD  DEFAULT ((1)) FOR [CheckOut]
GO
ALTER TABLE [dbo].[SchClass] ADD  DEFAULT ((16715535)) FOR [Color]
GO
ALTER TABLE [dbo].[SchClass] ADD  DEFAULT ((1)) FOR [AutoBind]
GO
ALTER TABLE [dbo].[SchClass] ADD  DEFAULT ((1)) FOR [WorkDay]
GO
ALTER TABLE [dbo].[SchClass] ADD  DEFAULT ((0)) FOR [WorkMins]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((-1)) FOR [USHIFTID]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ('1900-1-1') FOR [STARTDATE]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ('1900-12-31') FOR [ENDDATE]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [RUNNUM]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH1]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH2]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH3]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH4]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH5]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH6]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH7]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH8]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH9]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH10]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH11]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [SCH12]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [CYCLE]
GO
ALTER TABLE [dbo].[SHIFT] ADD  DEFAULT ((0)) FOR [UNITS]
GO
ALTER TABLE [dbo].[SystemLog] ADD  DEFAULT (getdate()) FOR [LogTime]
GO
ALTER TABLE [dbo].[TEMPLATE] ADD  DEFAULT ((1)) FOR [Flag]
GO
ALTER TABLE [dbo].[TEMPLATE] ADD  DEFAULT ((0)) FOR [DivisionFP]
GO
ALTER TABLE [dbo].[USER_OF_RUN] ADD  DEFAULT ('1900-1-1') FOR [STARTDATE]
GO
ALTER TABLE [dbo].[USER_OF_RUN] ADD  DEFAULT ('2099-12-31') FOR [ENDDATE]
GO
ALTER TABLE [dbo].[USER_OF_RUN] ADD  DEFAULT ((0)) FOR [ISNOTOF_RUN]
GO
ALTER TABLE [dbo].[USER_SPEDAY] ADD  DEFAULT ('1900-1-1') FOR [STARTSPECDAY]
GO
ALTER TABLE [dbo].[USER_SPEDAY] ADD  DEFAULT ('2099-12-31') FOR [ENDSPECDAY]
GO
ALTER TABLE [dbo].[USER_SPEDAY] ADD  DEFAULT ((-1)) FOR [DATEID]
GO
ALTER TABLE [dbo].[USER_TEMP_SCH] ADD  DEFAULT ((0)) FOR [OVERTIME]
GO
ALTER TABLE [dbo].[USER_TEMP_SCH] ADD  DEFAULT ((0)) FOR [TYPE]
GO
ALTER TABLE [dbo].[USER_TEMP_SCH] ADD  DEFAULT ((1)) FOR [FLAG]
GO
ALTER TABLE [dbo].[USER_TEMP_SCH] ADD  DEFAULT ((-1)) FOR [SCHCLASSID]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [DEFAULTDEPTID]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [ATT]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [INLATE]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [OUTEARLY]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [OVERTIME]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [SEP]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [HOLIDAY]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [LUNCHDURATION]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((0)) FOR [privilege]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [InheritDeptSch]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [InheritDeptSchClass]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [AutoSchPlan]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((24)) FOR [MinAutoSchInterval]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [RegisterOT]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [InheritDeptRule]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((0)) FOR [EMPRIVILEGE]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((0)) FOR [FaceGroup]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [AccGroup]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [UseAccGroupTZ]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((0)) FOR [VerifyCode]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((0)) FOR [Expires]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((0)) FOR [ValidCount]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((1)) FOR [TimeZone1]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((0)) FOR [TimeZone2]
GO
ALTER TABLE [dbo].[USERINFO] ADD  DEFAULT ((0)) FOR [TimeZone3]
GO

ALTER TABLE [CHECKINOUT] ADD AttProcess int
Go

ALTER TABLE [AttRawatebArchive] ADD ArchiveStatus int
Go

Insert into Settings (SettingName,SettingValue) values ('GetSalaryPerHourFromEmployee_ShiftReport','False') 
Go


EXEC sp_rename '[dbo].[Settings].SettingsName', 'SettingName', 'COLUMN'
go
EXEC sp_rename '[dbo].[Settings].SettingsValue', 'SettingValue', 'COLUMN'
go

insert into [dbo].[Settings] (SettingName,SettingValue) VALUES ('ReferancesSalaryAccount','2102000000')

insert into [dbo].[Settings] (SettingName,SettingValue) VALUES ('CostCenters','False')

Go
ALTER TABLE [dbo].[Settings] ALTER COLUMN SettingValue [nvarchar](Max) NULL;
Go
ALTER TABLE [dbo].[Settings] ALTER COLUMN SettingDescription [nvarchar](Max) NULL;
Go


ALTER TABLE [EmployeesData]
Add   [UserAccessType] [nvarchar] (50)  NULL
Go

CREATE TABLE [dbo].[RefCities](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CITY] [nvarchar](50) NULL,
 CONSTRAINT [PK_RefCities] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[RefSorts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SortName] [nvarchar](50) NULL,
 CONSTRAINT [PK_RefSorts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Referencess]
Add   [RefEmail] [nvarchar] (50)  NULL
Go

ALTER TABLE [Referencess]
Add   [SearchCity] [nvarchar] (50)  NULL
Go

ALTER TABLE [Referencess]
Add   [SubscribeAmount] [decimal](18, 3) NULL
Go


ALTER TABLE [Referencess]
Add   [RefSort] [nvarchar] (10)  NULL
Go

ALTER TABLE [Referencess]
Add   [RefBirthDate] Date  NULL
Go

ALTER TABLE [Referencess]
Add   [RefMemo] [nvarchar] (300)  NULL
Go

ALTER TABLE [dbo].[Items]
Add   [CategoryID] [nvarchar] (50)  NULL
Go

ALTER TABLE [dbo].[Items]
Add   [TradeMarkID] [int]  NULL
Go

ALTER TABLE [dbo].[Items]
ALTER COLUMN ItemNo [int];
Go

ALTER TABLE [dbo].[Journal]
ALTER COLUMN StockID [int];
Go

ALTER TABLE [dbo].[JournalTemp]
ALTER COLUMN StockID [int];
Go

ALTER TABLE [dbo].[Items_units]
ALTER COLUMN item_id [int];
Go

ALTER TABLE [dbo].[ItemsPriceCategories]
ALTER COLUMN ItemNo [int];
Go

CREATE TABLE [dbo].[ItemsCategories](
	[CategoryID] [varchar](10) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ItemsCategories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[ItemsTradeMark](
	[TradeMarkID] [int] IDENTITY(1,1) NOT NULL,
	[TradeMarkName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ItemsTradeMark] PRIMARY KEY CLUSTERED 
(
	[TradeMarkName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CompanyData]
Add   [CompanyLogo] [image]  NULL
Go

ALTER TABLE [dbo].[CompanyData]
Add   [CompanyVAT] [nvarchar] (50)  NULL
Go



/****** Object:  Table [dbo].[ItemsCategories]    Script Date: 30/06/2021 11:16:03 PM ******/
CREATE TABLE [dbo].[ItemsCategories](
	[CategoryID] [varchar](10) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[CategoryImage] [image] NULL,
 CONSTRAINT [PK_ItemsCategories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Items]
Add   [GroupID] [int] NULL
Go






/****** Object:  Table [dbo].[ItemsGroups]    Script Date: 01-07-2021 08:57 ******/

CREATE TABLE [dbo].[ItemsGroups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](50) NOT NULL,
	[AvailableOnPOS] [bit] NOT NULL,
	[GroupImage] [image] NULL,
 CONSTRAINT [PK_ItemsGroups] PRIMARY KEY CLUSTERED 
(
	[GroupName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



ALTER TABLE [dbo].[Journal]
Add   [ShiftID] [int] NULL
Go

ALTER TABLE [dbo].[Items]
Add   [SaleOnScale] [Bit] NULL
Go

ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_SaleOnScale]  DEFAULT ((0)) FOR [SaleOnScale]
Go

ALTER TABLE [dbo].[JournalTemp]
Add   [ShiftID] [int] NULL
Go

ALTER TABLE [dbo].[CompanyData]
Add   [CompanyQR] [image] NULL
Go

ALTER TABLE [dbo].[Journal]
Add   [DocNoteByAccount] [nvarchar](Max) NULL
Go

ALTER TABLE [dbo].[JournalTemp]
Add   [DocNoteByAccount] [nvarchar](Max) NULL
Go




ALTER TABLE [AttRawatebArchive]
Add   [AbsenceAmount] [decimal](18, 2) NULL
Go

ALTER TABLE [dbo].[Referencess]
Add  [Active] [bit]  NULL  
Go

Update [dbo].[Referencess] set [Active]=1 where [Active] is null

Go
ALTER TABLE [dbo].[Referencess]
Add  [DateStart] [datetime]  NULL 
Go


update [dbo].[Referencess] set [RefBirthDate]='1900-01-01' where [RefBirthDate] is null or [RefBirthDate]='0001-01-01'
Go  
update [dbo].[Referencess] set [DateStart]='1900-01-01' where [DateStart] is null
Go

ALTER TABLE [dbo].[FinancialAccounts]
ADD [IsActive] bit  null
Go

Update [dbo].[FinancialAccounts] set [IsActive]= 1 where [IsActive] is null
Go

ALTER TABLE [dbo].[Journal]
Add   [StockDiscount] [float] NULL
Go

ALTER TABLE [dbo].[JournalTemp]
Add   [StockDiscount] [float] NULL
Go

ALTER TABLE [dbo].[Journal]
Add   [StockBarcode] [varchar](50) NULL
Go

ALTER TABLE [dbo].[JournalTemp]
Add   [StockBarcode] [varchar](50) NULL
Go

ALTER TABLE [dbo].[JournalTemp]
Add   [PosNo] [int] NULL
Go

ALTER TABLE [dbo].[Journal]
Add  [PosNo] [int] NULL
Go


/****** Object:  Table [dbo].[PosCurrencyImages]    Script Date: 02-08-2021 17:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosCurrencyImages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyName] [nvarchar](50) NOT NULL,
	[CurrencyValue] [int] NOT NULL,
	[CurrencyGroupID] [int] NOT NULL,
	[CurrncyImage] [image] NULL,
 CONSTRAINT [PK_PosCurrencyImages] PRIMARY KEY CLUSTERED 
(
	[CurrencyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[POSDeletedJournal]    Script Date: 02-08-2021 17:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POSDeletedJournal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocID] [int] NULL,
	[DocDate] [date] NULL,
	[DocName] [int] NULL,
	[DocStatus] [int] NULL,
	[DocCostCenter] [int] NULL,
	[DebitAcc] [varchar](10) NULL,
	[CredAcc] [varchar](10) NULL,
	[AccountCurr] [int] NULL,
	[DocCurrency] [int] NULL,
	[DocAmount] [float] NULL,
	[ExchangePrice] [float] NULL,
	[BaseCurrAmount] [float] NULL,
	[BaseAmount] [float] NULL,
	[DocSort] [int] NULL,
	[Referance] [nvarchar](20) NULL,
	[DocManualNo] [nvarchar](20) NULL,
	[DocMultiCurrency] [bit] NULL,
	[InputUser] [int] NULL,
	[InputDateTime] [datetime] NULL,
	[ModifiedUser] [int] NULL,
	[ModifiedDateTime] [datetime] NULL,
	[DocAuditDate] [datetime] NULL,
	[DocAuditUser] [int] NULL,
	[DocNotes] [nvarchar](100) NULL,
	[StockID] [varchar](10) NULL,
	[StockUnit] [int] NULL,
	[StockQuantity] [float] NULL,
	[StockQuantityByMainUnit] [float] NULL,
	[StockPrice] [float] NULL,
	[StockItemPrice] [float] NULL,
	[StockDiscount] [float] NULL,
	[StockDebitWhereHouse] [int] NULL,
	[StockCreditWhereHouse] [int] NULL,
	[StockDriver] [nvarchar](50) NULL,
	[StockCarNo] [int] NULL,
	[SalesPerson] [int] NULL,
	[CheckNo] [int] NULL,
	[CheckInOut] [nvarchar](5) NULL,
	[CheckStatus] [int] NULL,
	[CheckDueDate] [date] NULL,
	[CheckCustBank] [varchar](20) NULL,
	[CheckCustBranch] [varchar](20) NULL,
	[CheckCustAccountId] [varchar](20) NULL,
	[AccountBank] [int] NULL,
	[DeleteUser] [int] NULL,
	[DeleteDateTime] [datetime] NULL,
	[CurrentUserID] [int] NULL,
	[ReferanceName] [nvarchar](50) NULL,
	[DocCode] [varchar](15) NULL,
	[CheckCode] [varchar](15) NULL,
	[ItemName] [nvarchar](100) NULL,
	[DocCheckTransID] [int] NULL,
	[TransNoInJournal] [int] NULL,
	[ShiftID] [int] NULL,
	[DocNoteByAccount] [nvarchar](50) NULL,
	[UnitName] [nvarchar](50) NULL,
	[SaleOnScale] [bit] NULL,
	[StockBarcode] [varchar](50) NULL,
	[PosNo] [int] NULL,
 CONSTRAINT [PK_POSDeletedJournal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[POSJournal]    Script Date: 02-08-2021 17:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POSJournal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocID] [int] NULL,
	[DocDate] [date] NULL,
	[DocName] [int] NULL,
	[DocStatus] [int] NULL,
	[DocCostCenter] [int] NULL,
	[DebitAcc] [varchar](10) NULL,
	[CredAcc] [varchar](10) NULL,
	[AccountCurr] [int] NULL,
	[DocCurrency] [int] NULL,
	[DocAmount] [float] NULL,
	[ExchangePrice] [float] NULL,
	[BaseCurrAmount] [float] NULL,
	[BaseAmount] [float] NULL,
	[DocSort] [int] NULL,
	[Referance] [nvarchar](20) NULL,
	[DocManualNo] [nvarchar](20) NULL,
	[DocMultiCurrency] [bit] NULL,
	[InputUser] [int] NULL,
	[InputDateTime] [datetime] NULL,
	[ModifiedUser] [int] NULL,
	[ModifiedDateTime] [datetime] NULL,
	[DocAuditDate] [datetime] NULL,
	[DocAuditUser] [int] NULL,
	[DocNotes] [nvarchar](100) NULL,
	[StockID] [varchar](10) NULL,
	[StockUnit] [int] NULL,
	[StockQuantity] [float] NULL,
	[StockQuantityByMainUnit] [float] NULL,
	[StockPrice] [float] NULL,
	[StockItemPrice] [float] NULL,
	[StockDiscount] [float] NULL,
	[StockDebitWhereHouse] [int] NULL,
	[StockCreditWhereHouse] [int] NULL,
	[StockDriver] [nvarchar](50) NULL,
	[StockCarNo] [int] NULL,
	[SalesPerson] [int] NULL,
	[CheckNo] [int] NULL,
	[CheckInOut] [nvarchar](5) NULL,
	[CheckStatus] [int] NULL,
	[CheckDueDate] [date] NULL,
	[CheckCustBank] [varchar](20) NULL,
	[CheckCustBranch] [varchar](20) NULL,
	[CheckCustAccountId] [varchar](20) NULL,
	[AccountBank] [int] NULL,
	[DeleteUser] [int] NULL,
	[DeleteDateTime] [datetime] NULL,
	[CurrentUserID] [int] NULL,
	[ReferanceName] [nvarchar](50) NULL,
	[DocCode] [varchar](15) NULL,
	[CheckCode] [varchar](15) NULL,
	[ItemName] [nvarchar](100) NULL,
	[DocCheckTransID] [int] NULL,
	[TransNoInJournal] [int] NULL,
	[ShiftID] [int] NULL,
	[DocNoteByAccount] [nvarchar](50) NULL,
	[UnitName] [nvarchar](50) NULL,
	[SaleOnScale] [bit] NULL,
	[StockBarcode] [varchar](50) NULL,
	[PCName] [varchar](50) NULL,
	[PosNo] [int] NULL,
 CONSTRAINT [PK_POSJournal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PosPaidMethods]    Script Date: 02-08-2021 17:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosPaidMethods](
	[MethodNo] [int] IDENTITY(1,1) NOT NULL,
	[PaidMethodName] [nvarchar](50) NOT NULL,
	[AccountNO] [varchar](10) NULL,
 CONSTRAINT [PK_PosPaidMethods] PRIMARY KEY CLUSTERED 
(
	[PaidMethodName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PosShifts]    Script Date: 02-08-2021 17:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosShifts](
	[ShiftID] [int] NOT NULL,
	[ShiftName] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NULL,
	[UserID] [int] NOT NULL,
	[ShiftStatus] [nvarchar](50) NOT NULL,
	[PosNumber] [int] NOT NULL,
	[DeviceName] [nvarchar](50) NULL,
	[BegBalance] [decimal](18, 2) NULL,
	[CashAmount] [decimal](18, 2) NULL,
	[CardAmount] [decimal](18, 2) NULL,
	[DebitAmount] [decimal](18, 2) NULL,
	[EndBalance] [decimal](18, 2) NULL,
	[TotalSales] [decimal](18, 2) NULL,
 CONSTRAINT [PK_PosShifts] PRIMARY KEY CLUSTERED 
(
	[ShiftID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PosVouchers]    Script Date: 02-08-2021 17:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosVouchers](
	[VoucherID] [int] NOT NULL,
	[VoucherDateTime] [datetime] NULL,
	[VoucherAmount] [decimal](18, 2) NULL,
	[VoucherDiscount] [decimal](18, 2) NULL,
	[VoucherPC] [varchar](50) NULL,
	[VoucherAmountAfterDiscount] [decimal](18, 2) NULL,
	[UserNo] [int] NULL,
	[VoucherCode] [varchar](15) NULL,
	[VoucherDebit] [varchar](10) NULL,
	[VoucherCredit] [varchar](10) NULL,
	[VoucherPayType] [nvarchar](20) NULL,
	[VoucherReferanceName] [nvarchar](50) NULL,
	[VoucherReferance] [nvarchar](20) NULL,
	[PayCardName] [int] NULL,
	[VoucherNote] [nvarchar](100) NULL,
	[PosNo] [int] NULL,
 CONSTRAINT [PK_PosVouchers] PRIMARY KEY CLUSTERED 
(
	[VoucherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[PosPaidMethods] ON 
GO
INSERT [dbo].[PosPaidMethods] ([MethodNo], [PaidMethodName], [AccountNO]) VALUES (1, N'فيزا بنك فلسطين', N'1102010100')
GO
INSERT [dbo].[PosPaidMethods] ([MethodNo], [PaidMethodName], [AccountNO]) VALUES (2, N'فيزا البنك العربي', N'1102020100')
GO

SET IDENTITY_INSERT [dbo].[PosPaidMethods] OFF
GO
ALTER TABLE [dbo].[POSJournal] ADD  CONSTRAINT [DF_POSJournal_DocStatus]  DEFAULT ((1)) FOR [DocStatus]
GO
ALTER TABLE [dbo].[POSJournal] ADD  CONSTRAINT [DF_POSJournal_DocCostCenter]  DEFAULT ((1)) FOR [DocCostCenter]
GO
ALTER TABLE [dbo].[POSJournal] ADD  CONSTRAINT [DF_POSJournal_DocSort]  DEFAULT ((0)) FOR [DocSort]
GO
ALTER TABLE [dbo].[POSJournal] ADD  CONSTRAINT [DF_POSJournal_Referance]  DEFAULT ((0)) FOR [Referance]
GO
ALTER TABLE [dbo].[POSJournal] ADD  CONSTRAINT [DF_POSJournal_DocManualNo]  DEFAULT ((0)) FOR [DocManualNo]
GO
ALTER TABLE [dbo].[POSJournal] ADD  CONSTRAINT [DF_POSJournal_DocMultiCurrency]  DEFAULT ((0)) FOR [DocMultiCurrency]
GO
ALTER TABLE [dbo].[PosShifts] ADD  CONSTRAINT [DF_PosShifts_PosNumber]  DEFAULT ((0)) FOR [PosNumber]
GO
ALTER TABLE [dbo].[PosShifts] ADD  CONSTRAINT [DF_PosShifts_BegBalance]  DEFAULT ((0)) FOR [BegBalance]
GO
ALTER TABLE [dbo].[PosShifts] ADD  CONSTRAINT [DF_PosShifts_CashAmount]  DEFAULT ((0)) FOR [CashAmount]
GO
ALTER TABLE [dbo].[PosShifts] ADD  CONSTRAINT [DF_PosShifts_CardAmount]  DEFAULT ((0)) FOR [CardAmount]
GO
ALTER TABLE [dbo].[PosShifts] ADD  CONSTRAINT [DF_PosShifts_DebitAmount]  DEFAULT ((0)) FOR [DebitAmount]
GO
ALTER TABLE [dbo].[PosShifts] ADD  CONSTRAINT [DF_PosShifts_EndBalance]  DEFAULT ((0)) FOR [EndBalance]
GO
ALTER TABLE [dbo].[PosShifts] ADD  CONSTRAINT [DF_PosShifts_TotalSales]  DEFAULT ((0)) FOR [TotalSales]
GO


CREATE PROCEDURE [dbo].[PosGetAndDeleteDeletedItems] 
	-- Add the parameters for the stored procedure here
	@JournalID int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
Insert into [POSDeletedJournal] ([DebitAcc],[CredAcc],[DocAmount],[InputDateTime],
			[StockID],[StockUnit] ,[StockQuantity]  ,[StockQuantityByMainUnit] ,[StockPrice],
			[StockDiscount] ,[DeleteUser],[DocCode],[ItemName],[ShiftID] ,[StockBarcode],[DeleteDateTime])
Select [DebitAcc],[CredAcc],[DocAmount],[InputDateTime],
			[StockID],[StockUnit] ,[StockQuantity]  ,[StockQuantityByMainUnit] ,[StockPrice],
			[StockDiscount] ,[InputUser],[DocCode],[ItemName],[ShiftID] ,[StockBarcode],GETDATE() 
			From [dbo].[POSJournal] where ID=@JournalID;
Delete from [dbo].[POSJournal] where ID=@JournalID
END
GO

ALTER TABLE [dbo].[CheckTypes]
Add  [InEnglish] nvarchar(15) NULL
Go

--Update [dbo].[Journal]
--Set BaseAmount=DocAmount 
--Where DocAmount<>BaseAmount and ExchangePrice=1 
--Go



CREATE TABLE [dbo].[OrdersStatus](
	[ID] [int] NOT NULL,
	[OrderStatus] [nvarchar](20) NOT NULL,
	[OrderStatusE] [nvarchar](20) NULL,
 CONSTRAINT [PK_OrdersStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [dbo].[OrdersStatus] ([ID], [OrderStatus], [OrderStatusE]) VALUES (0, N'محفوظ', N'Saved')
GO
INSERT [dbo].[OrdersStatus] ([ID], [OrderStatus], [OrderStatusE]) VALUES (1, N'قيد التجهيز', N'Preparing')
GO
INSERT [dbo].[OrdersStatus] ([ID], [OrderStatus], [OrderStatusE]) VALUES (2, N'جاهزة', N'Ready')
GO
INSERT [dbo].[OrdersStatus] ([ID], [OrderStatus], [OrderStatusE]) VALUES (3, N'مدققة', N'Audited')
GO
INSERT [dbo].[OrdersStatus] ([ID], [OrderStatus], [OrderStatusE]) VALUES (4, N'مؤجلة', N'Postponed')
GO
INSERT [dbo].[OrdersStatus] ([ID], [OrderStatus], [OrderStatusE]) VALUES (5, N'ملغاه', N'Cancelled')
GO
INSERT [dbo].[OrdersStatus] ([ID], [OrderStatus], [OrderStatusE]) VALUES (99, N'مفوترة', N'Billed')
GO


/****** Object:  Table [dbo].[OrdersAppJournal]    Script Date: 18-08-2021 08:54 ******/
CREATE TABLE [dbo].[OrdersAppJournal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocID] [int] NULL,
	[DocDate] [date] NULL,
	[DocName] [int] NULL,
	[DocStatus] [int] NULL,
	[DocCostCenter] [int] NULL,
	[DebitAcc] [varchar](10) NULL,
	[CredAcc] [varchar](10) NULL,
	[AccountCurr] [int] NULL,
	[DocCurrency] [int] NULL,
	[DocAmount] [float] NULL,
	[ExchangePrice] [float] NULL,
	[BaseCurrAmount] [float] NULL,
	[BaseAmount] [float] NULL,
	[DocSort] [int] NULL,
	[Referance] [nvarchar](20) NOT NULL,
	[DocManualNo] [nvarchar](20) NULL,
	[DocMultiCurrency] [bit] NULL,
	[InputUser] [int] NULL,
	[InputDateTime] [datetime] NULL,
	[ModifiedUser] [int] NULL,
	[ModifiedDateTime] [datetime] NULL,
	[DocAuditDate] [datetime] NULL,
	[DocAuditUser] [int] NULL,
	[DocNotes] [nvarchar](100) NULL,
	[StockID] [varchar](10) NULL,
	[StockUnit] [int] NULL,
	[StockQuantity] [float] NULL,
	[StockQuantityByMainUnit] [float] NULL,
	[StockPrice] [float] NULL,
	[StockItemPrice] [float] NULL,
	[StockDebitWhereHouse] [int] NULL,
	[StockCreditWhereHouse] [int] NULL,
	[StockDriver] [nvarchar](50) NULL,
	[StockCarNo] [int] NULL,
	[SalesPerson] [int] NULL,
	[CheckNo] [int] NULL,
	[CheckInOut] [nvarchar](5) NULL,
	[CheckStatus] [int] NULL,
	[CheckDueDate] [date] NULL,
	[CheckCustBank] [varchar](20) NULL,
	[CheckCustBranch] [varchar](20) NULL,
	[CheckCustAccountId] [varchar](20) NULL,
	[AccountBank] [int] NULL,
	[DeleteUser] [int] NULL,
	[DeleteDateTime] [datetime] NULL,
	[CurrentUserID] [int] NULL,
	[ReferanceName] [nvarchar](50) NULL,
	[DocCode] [varchar](15) NULL,
	[CheckCode] [varchar](15) NULL,
	[ItemName] [nvarchar](100) NULL,
	[DocCheckTransID] [int] NULL,
	[TransNoInJournal] [int] NULL,
	[ShiftID] [int] NULL,
	[DocNoteByAccount] [nvarchar](100) NULL,
	[StockDiscount] [float] NULL,
	[StockBarcode] [varchar](50) NULL,
	[PosNo] [int] NULL,
	[DeviceName] [varchar](70) NULL,
	[OrderStatus] [int] NULL,
	[ItemStatus] [int] NULL,
	[ApprovedQuantity] [decimal](18, 2) NULL,
 CONSTRAINT [PK_OrdersAppJournal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OrdersAppJournal] ADD  CONSTRAINT [DF_OrdersAppJournal_DocStatus]  DEFAULT ((1)) FOR [DocStatus]
GO

ALTER TABLE [dbo].[OrdersAppJournal] ADD  CONSTRAINT [DF_OrdersAppJournal_DocCostCenter]  DEFAULT ((1)) FOR [DocCostCenter]
GO

ALTER TABLE [dbo].[OrdersAppJournal] ADD  CONSTRAINT [DF_OrdersAppJournal_DocSort]  DEFAULT ((0)) FOR [DocSort]
GO

ALTER TABLE [dbo].[OrdersAppJournal] ADD  CONSTRAINT [DF_OrdersAppJournal_Referance]  DEFAULT ((0)) FOR [Referance]
GO

ALTER TABLE [dbo].[OrdersAppJournal] ADD  CONSTRAINT [DF_OrdersAppJournal_DocManualNo]  DEFAULT ((0)) FOR [DocManualNo]
GO

ALTER TABLE [dbo].[OrdersAppJournal] ADD  CONSTRAINT [DF_OrdersAppJournal_DocMultiCurrency]  DEFAULT ((0)) FOR [DocMultiCurrency]
GO

ALTER TABLE [dbo].[OrdersAppJournal] ADD  CONSTRAINT [DF_OrdersAppJournal_OrderStatus]  DEFAULT ((0)) FOR [OrderStatus]
GO

ALTER TABLE [dbo].[OrdersAppJournal] ADD  CONSTRAINT [DF_OrdersAppJournal_ItemStatus]  DEFAULT ((0)) FOR [ItemStatus]
GO

ALTER TABLE [dbo].[OrdersAppJournal] ADD  CONSTRAINT [DF_OrdersAppJournal_ApprovedQuantity]  DEFAULT ((0)) FOR [ApprovedQuantity]
GO


/****** Object:  Table [dbo].[OrdersJournal]    Script Date: 18-08-2021 08:56 ******/
CREATE TABLE [dbo].[OrdersJournal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocID] [int] NULL,
	[DocDate] [date] NULL,
	[DocName] [int] NULL,
	[DocStatus] [int] NULL,
	[DocCostCenter] [int] NULL,
	[DebitAcc] [varchar](10) NULL,
	[CredAcc] [varchar](10) NULL,
	[AccountCurr] [int] NULL,
	[DocCurrency] [int] NULL,
	[DocAmount] [float] NULL,
	[ExchangePrice] [float] NULL,
	[BaseCurrAmount] [float] NULL,
	[BaseAmount] [float] NULL,
	[DocSort] [int] NULL,
	[Referance] [nvarchar](20) NULL,
	[DocManualNo] [nvarchar](20) NULL,
	[DocMultiCurrency] [bit] NULL,
	[InputUser] [int] NULL,
	[InputDateTime] [datetime] NULL,
	[ModifiedUser] [int] NULL,
	[ModifiedDateTime] [datetime] NULL,
	[DocAuditDate] [datetime] NULL,
	[DocAuditUser] [int] NULL,
	[DocNotes] [nvarchar](100) NULL,
	[StockID] [varchar](10) NULL,
	[StockUnit] [int] NULL,
	[StockQuantity] [float] NULL,
	[StockQuantityByMainUnit] [float] NULL,
	[StockPrice] [float] NULL,
	[StockItemPrice] [float] NULL,
	[StockDebitWhereHouse] [int] NULL,
	[StockCreditWhereHouse] [int] NULL,
	[StockDriver] [nvarchar](50) NULL,
	[StockCarNo] [int] NULL,
	[SalesPerson] [int] NULL,
	[CheckNo] [int] NULL,
	[CheckInOut] [nvarchar](5) NULL,
	[CheckStatus] [int] NULL,
	[CheckDueDate] [date] NULL,
	[CheckCustBank] [varchar](20) NULL,
	[CheckCustBranch] [varchar](20) NULL,
	[CheckCustAccountId] [varchar](20) NULL,
	[AccountBank] [int] NULL,
	[DeleteUser] [int] NULL,
	[DeleteDateTime] [datetime] NULL,
	[CurrentUserID] [int] NULL,
	[ReferanceName] [nvarchar](50) NULL,
	[DocCode] [varchar](15) NULL,
	[CheckCode] [varchar](15) NULL,
	[ItemName] [nvarchar](100) NULL,
	[DocCheckTransID] [int] NULL,
	[TransNoInJournal] [int] NULL,
	[ShiftID] [int] NULL,
	[DocNoteByAccount] [nvarchar](100) NULL,
	[StockDiscount] [float] NULL,
	[StockBarcode] [varchar](50) NULL,
	[PosNo] [int] NULL,
	[DeviceName] [varchar](70) NULL,
	[OrderStatus] [int] NULL,
	[ItemStatus] [int] NULL,
	[ApprovedQuantity] [decimal](18, 2) NULL,
 CONSTRAINT [PK_OrdersJournal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OrdersJournal] ADD  CONSTRAINT [DF_OrdersJournal_DocStatus]  DEFAULT ((1)) FOR [DocStatus]
GO

ALTER TABLE [dbo].[OrdersJournal] ADD  CONSTRAINT [DF_OrdersJournal_DocCostCenter]  DEFAULT ((1)) FOR [DocCostCenter]
GO

ALTER TABLE [dbo].[OrdersJournal] ADD  CONSTRAINT [DF_OrdersJournal_DocSort]  DEFAULT ((0)) FOR [DocSort]
GO

ALTER TABLE [dbo].[OrdersJournal] ADD  CONSTRAINT [DF_OrdersJournal_Referance]  DEFAULT ((0)) FOR [Referance]
GO

ALTER TABLE [dbo].[OrdersJournal] ADD  CONSTRAINT [DF_OrdersJournal_DocManualNo]  DEFAULT ((0)) FOR [DocManualNo]
GO

ALTER TABLE [dbo].[OrdersJournal] ADD  CONSTRAINT [DF_OrdersJournal_DocMultiCurrency]  DEFAULT ((0)) FOR [DocMultiCurrency]
GO

ALTER TABLE [dbo].[OrdersJournal] ADD  CONSTRAINT [DF_OrdersJournal_OrderStatus]  DEFAULT ((0)) FOR [OrderStatus]
GO

ALTER TABLE [dbo].[OrdersJournal] ADD  CONSTRAINT [DF_OrdersJournal_ItemStatus]  DEFAULT ((0)) FOR [ItemStatus]
GO

ALTER TABLE [dbo].[OrdersJournal] ADD  CONSTRAINT [DF_OrdersJournal_ApprovedQuantity]  DEFAULT ((0)) FOR [ApprovedQuantity]
GO

ALTER TABLE [dbo].[Referencess] Add  [Address] nvarchar(150) NULL
Go

ALTER TABLE [dbo].[Journal] Add  [DeviceName] nvarchar(70) NULL
Go
ALTER TABLE [dbo].[Journal] Add  [OrderStatus] int NULL
Go
ALTER TABLE [dbo].[Journal] Add  [ItemStatus] int NULL
Go
ALTER TABLE [dbo].[Journal] Add  [ApprovedQuantity] decimal(18, 2) NULL
Go


ALTER TABLE [dbo].[JournalTemp] Add  [DeviceName] nvarchar(70) NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [OrderStatus] int NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [ItemStatus] int NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [ApprovedQuantity] decimal(18, 2) NULL
Go

ALTER TABLE [dbo].[POSJournal] Add  [DeviceName] nvarchar(70) NULL
Go
ALTER TABLE [dbo].[POSJournal] Add  [OrderStatus] int NULL
Go
ALTER TABLE [dbo].[POSJournal] Add  [ItemStatus] int NULL
Go
ALTER TABLE [dbo].[POSJournal] Add  [ApprovedQuantity] decimal(18, 2) NULL
Go


CREATE TABLE [dbo].[VocationsPending](
	[VocID] [int] IDENTITY(1,1) NOT NULL,
	[VocDate] [date] NULL,
	[EmployeeID] [int] NOT NULL,
	[VocationType] [nvarchar](15) NOT NULL,
	[FromDate] [date] NOT NULL,
	[ToDate] [date] NOT NULL,
	[NoDays] [decimal](18, 2) NULL,
	[NoteDetails] [nvarchar](100) NULL,
	[BatchNo] [int] NULL,
 CONSTRAINT [PK_VocationsPending] PRIMARY KEY CLUSTERED 
(
	[VocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[AttCHECKINOUTPending](
	[USERID] [int] NOT NULL,
	[CHECKTIME] [datetime] NULL,
	[CHECKTYPE] [nvarchar](2) NULL,
	[SENSORID] [nvarchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Location] [varchar](50) NULL,
 CONSTRAINT [PK_AttCHECKINOUTPending] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[Journal] Add  [LastDocCode] [varchar](15) NULL
Go
ALTER TABLE [dbo].[Journal] Add  [LastDataName] [varchar](30) NULL
Go
ALTER TABLE [dbo].[Journal] Add  [DeliverDate] datetime NULL
Go

ALTER TABLE [dbo].[JournalTemp] Add   [LastDocCode] [varchar](15) NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add   [LastDataName] [varchar](30) NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [DeliverDate] datetime NULL
Go

ALTER TABLE [dbo].[POSJournal] Add  [LastDocCode] [varchar](15) NULL
Go
ALTER TABLE [dbo].[POSJournal] Add   [LastDataName] [varchar](30) NULL
Go
ALTER TABLE [dbo].[POSJournal] Add  [DeliverDate] datetime NULL
Go

ALTER TABLE [dbo].[OrdersJournal] Add [LastDocCode] [varchar](15) NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [LastDataName] [varchar](30) NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [DeliverDate] datetime NULL
Go


ALTER TABLE [dbo].[OrdersAppJournal] Add  [LastDocCode] [varchar](15) NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [LastDataName] [varchar](30) NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [DeliverDate] datetime NULL
Go


ALTER TABLE [dbo].[POSDeletedJournal] Add  [LastDocCode] [varchar](15) NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add   [LastDataName] [varchar](30) NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add  [DeliverDate] datetime NULL
Go

ALTER TABLE [dbo].[Journal] ALTER COLUMN  [StockBarcode] [varchar](50) NULL
Go
ALTER TABLE [dbo].[JournalTemp] ALTER COLUMN  [StockBarcode] [varchar](50) NULL
Go
ALTER TABLE [dbo].[POSJournal] ALTER COLUMN  [StockBarcode] [varchar](50) NULL
Go
ALTER TABLE [dbo].[OrdersJournal] ALTER COLUMN  [StockBarcode] [varchar](50) NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] ALTER COLUMN  [StockBarcode] [varchar](50) NULL
Go
ALTER TABLE [dbo].[POSJournal] ALTER COLUMN  [StockBarcode] [varchar](50) NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] ALTER COLUMN  [StockBarcode] [varchar](50) NULL
Go


INSERT [dbo].[DocStatus] ([ID], [DocStatus]) VALUES (-1, N'جديد')
GO


  insert into [dbo].[Settings]
  ([SettingName],[SettingValue]) values ('UseLocalDataBaseForReport','False')


Go

ALTER TABLE [dbo].[EmployeesData] Add  [BonusPerHourAmount] [decimal](18, 2) NULL

Go

ALTER TABLE [dbo].[EmployeesData] Add  [BonusPerHourAmountOption] [bit] NULL
Go

ALTER TABLE [dbo].[Referencess] Add  [ReferanceCode] [varchar](50) NULL
Go

ALTER TABLE  [dbo].[Items_units] Add  [Price2] decimal(18, 5) NULL 
Go

ALTER TABLE  [dbo].[Items_units] Add  [Price3] decimal(18, 5) NULL 
Go

ALTER TABLE  [dbo].[Items_units] Add  [IsUnit] [bit] NULL 
Go





ALTER TABLE [dbo].[Items_units] ADD  CONSTRAINT [DF_Items_units_Price1]  DEFAULT ((0)) FOR [Price1]
GO
ALTER TABLE [dbo].[Items_units] ADD  CONSTRAINT [DF_Items_units_Price2]  DEFAULT ((0)) FOR [Price2]
GO
ALTER TABLE [dbo].[Items_units] ADD  CONSTRAINT [DF_Items_units_Price3]  DEFAULT ((0)) FOR [Price3]
GO


ALTER TABLE [dbo].[Journal] ALTER COLUMN  [DocNotes] [nvarchar] (1024) NULL
Go
ALTER TABLE [dbo].[JournalTemp] ALTER COLUMN  [DocNotes] [nvarchar] (1024) NULL
Go
ALTER TABLE [dbo].[POSJournal] ALTER COLUMN  [DocNotes] [nvarchar] (1024) NULL
Go
ALTER TABLE [dbo].[OrdersJournal] ALTER COLUMN  [DocNotes] [nvarchar] (1024) NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] ALTER COLUMN  [DocNotes] [nvarchar] (1024) NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] ALTER COLUMN  [DocNotes] [nvarchar] (1024) NULL
Go


ALTER TABLE [dbo].[Journal] ALTER COLUMN  [ItemName] [nvarchar] (250) NULL
Go
ALTER TABLE [dbo].[JournalTemp] ALTER COLUMN  [ItemName] [nvarchar] (250) NULL
Go
ALTER TABLE [dbo].[POSJournal] ALTER COLUMN  [ItemName] [nvarchar] (250) NULL
Go
ALTER TABLE [dbo].[OrdersJournal] ALTER COLUMN  [ItemName] [nvarchar] (250) NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] ALTER COLUMN  [ItemName] [nvarchar] (250) NULL
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] ALTER COLUMN  [ItemName] [nvarchar] (250) NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] ALTER COLUMN  [ItemName] [nvarchar] (250) NULL
Go
ALTER TABLE [dbo].[Items] ALTER COLUMN  [ItemName] [nvarchar] (250) NULL
Go


CREATE TABLE [dbo].[ItemsColors](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ItemsColors] PRIMARY KEY CLUSTERED 
(
	[ColorName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemsMeasures]    Script Date: 9/15/2021 2:45:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsMeasures](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MeasureName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ItemsMeasures] PRIMARY KEY CLUSTERED 
(
	[MeasureName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ItemsColors] ON 
GO
INSERT [dbo].[ItemsColors] ([ID], [ColorName]) VALUES (1, N'ابيض')
GO
INSERT [dbo].[ItemsColors] ([ID], [ColorName]) VALUES (3, N'احمر')
GO
INSERT [dbo].[ItemsColors] ([ID], [ColorName]) VALUES (2, N'اسود')
GO
SET IDENTITY_INSERT [dbo].[ItemsColors] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemsMeasures] ON 
GO
INSERT [dbo].[ItemsMeasures] ([ID], [MeasureName]) VALUES (1, N'صغير')
GO
INSERT [dbo].[ItemsMeasures] ([ID], [MeasureName]) VALUES (2, N'كبير')
GO
SET IDENTITY_INSERT [dbo].[ItemsMeasures] OFF
GO



ALTER TABLE [dbo].[Journal] Add  [Color] int NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [Color] int NULL
Go
ALTER TABLE [dbo].[POSJournal] Add  [Color] int NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [Color] int NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [Color] int NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add  [Color] int NULL
Go


ALTER TABLE [dbo].[Journal] Add  [Measure] int NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [Measure] int NULL
Go
ALTER TABLE [dbo].[POSJournal] Add  [Measure] int NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [Measure] int NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [Measure] int NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add  [Measure] int NULL
Go

ALTER TABLE [dbo].Items_units Add  [Measure] int NULL
Go
ALTER TABLE [dbo].Items_units Add  [Color] int NULL
Go


SET IDENTITY_INSERT [dbo].[DocNames] ON 
GO
INSERT [dbo].[DocNames] ([id], [Name]) VALUES (1, N'فاتورة مشتريات')
GO
INSERT [dbo].[DocNames] ([id], [Name]) VALUES (2, N'فاتورة مبيعات')
GO
INSERT [dbo].[DocNames] ([id], [Name]) VALUES (3, N'سند صرف')
GO
INSERT [dbo].[DocNames] ([id], [Name]) VALUES (4, N'سند قبض')
GO
INSERT [dbo].[DocNames] ([id], [Name]) VALUES (5, N'سند قيد')
GO
INSERT [dbo].[DocNames] ([id], [Name]) VALUES (6, N'اشعار مدين')
GO
INSERT [dbo].[DocNames] ([id], [Name]) VALUES (7, N'اشعار دائن')
GO
INSERT [dbo].[DocNames] ([id], [Name]) VALUES (8, N'ارسالية مشتريات')
GO
INSERT [dbo].[DocNames] ([id], [Name]) VALUES (9, N'ارسالية مبيعات')
GO
INSERT [dbo].[DocNames] ([id], [Name]) VALUES (10, N'طلبية مشتريات')
GO
INSERT [dbo].[DocNames] ([id], [Name]) VALUES (11, N'طلبية مبيعات')
GO
INSERT [dbo].[DocNames] ([id], [Name]) VALUES (12, N'مردودات مبيعات')
GO
INSERT [dbo].[DocNames] ([id], [Name]) VALUES (13, N'مردودات مشتريات')
GO
SET IDENTITY_INSERT [dbo].[DocNames] OFF
GO




--update [dbo].[Items_units]  set isunit =1;
--EXEC sp_rename 'Items_units.item_unit_pay_price', 'Price1', 'COLUMN';
--ALTER TABLE dbo.[Items_units] ADD [item_unit_pay_price] float NULL;
--Alter table [Items_units] Alter Column Price1 decimal(18, 5) NULL; 

Go


Go
ALTER TABLE [dbo].[EmployeesData] Add  [AllowUseOrdersApp] bit NULL
Go
ALTER TABLE [dbo].[EmployeesData] Add  [AllowUseAttApp] bit NULL
Go
ALTER TABLE [dbo].[EmployeesData] Add  [PasswordForApps] varchar(50) NULL
Go


Alter Table [dbo].[Checks] ALTER COLUMN  [CheckAccountId] [varchar] (50) NULL
Go


Alter Table [dbo].[ReferencesTypes] ALTER COLUMN  [DefaultAccount] [varchar] (10) NULL
Go


/****** Object:  Table [dbo].[AppointmentClosing]    Script Date: 2021-09-27 12:26:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppointmentClosing](
	[TaskID] [int] NULL,
	[Notes] [nvarchar](100) NULL,
	[ClosingDate] [datetime] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[LastTaskStatus] [int] NULL,
	[CurrentTaskStatus] [int] NULL,
 CONSTRAINT [PK_AppointmentClosing] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 2021-09-27 12:26:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[UniqueID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[QueryStartDate] [datetime] NULL,
	[QueryEndDate] [datetime] NULL,
	[AllDay] [bit] NULL,
	[Subject] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[Label] [int] NULL,
	[ResourceID] [int] NULL,
	[ResourceIDs] [nvarchar](max) NULL,
	[ReminderInfo] [nvarchar](max) NULL,
	[RecurrenceInfo] [nvarchar](max) NULL,
	[TimeZoneId] [nvarchar](max) NULL,
	[CustomField1] [nvarchar](max) NULL,
	[CreationUser] [int] NULL,
	[TaskStatus] [int] NULL,
	[CreationDate] [datetime] NULL,
	[AssignedTo] [int] NULL,
	[Referance] [int] NULL,
	[LastUserUpdate] [int] NULL,
	[LastUpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Appointments] PRIMARY KEY CLUSTERED 
(
	[UniqueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CRMTaskStatuses]    Script Date: 2021-09-27 12:26:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CRMTaskStatuses](
	[StatusID] [int] NOT NULL,
	[StatusName] [nvarchar](50) NULL,
	[Step] [int] NULL,
 CONSTRAINT [PK_CRMTaskStatuses] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CRMTaskStatuses] ([StatusID], [StatusName], [Step]) VALUES (0, N'جديدة', 0)
GO
INSERT [dbo].[CRMTaskStatuses] ([StatusID], [StatusName], [Step]) VALUES (1, N'مفتوحة', 33)
GO
INSERT [dbo].[CRMTaskStatuses] ([StatusID], [StatusName], [Step]) VALUES (2, N'قيد العمل', 66)
GO
INSERT [dbo].[CRMTaskStatuses] ([StatusID], [StatusName], [Step]) VALUES (3, N'منجزة', 90)
GO
INSERT [dbo].[CRMTaskStatuses] ([StatusID], [StatusName], [Step]) VALUES (4, N'مغلقة', 100)
GO


ALTER TABLE [dbo].[Journal] ALTER COLUMN  [DocManualNo] [nvarchar] (50) NULL
Go
ALTER TABLE [dbo].[JournalTemp] ALTER COLUMN  [DocManualNo] [nvarchar] (50) NULL
Go
ALTER TABLE [dbo].[POSJournal] ALTER COLUMN  [DocManualNo] [nvarchar] (50) NULL
Go
ALTER TABLE [dbo].[OrdersJournal] ALTER COLUMN  [DocManualNo] [nvarchar] (50) NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] ALTER COLUMN  [DocManualNo] [nvarchar] (50) NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] ALTER COLUMN  [DocManualNo] [nvarchar] (50) NULL
Go


/****** Object:  Table [dbo].[InsuranceCarsCoverTypes]    Script Date: 2021-10-05 08:39:54 ******/
CREATE TABLE [dbo].[InsuranceCarsCoverTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CoverType] [nvarchar](50) NULL,
 CONSTRAINT [PK_InsuranceCarsCoverTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InsuranceCarsTypes]    Script Date: 2021-10-05 08:39:54 ******/
CREATE TABLE [dbo].[InsuranceCarsTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CarType] [nvarchar](50) NULL,
 CONSTRAINT [PK_InsuranceCarsTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InsuranceDoc]    Script Date: 2021-10-05 08:39:54 ******/
CREATE TABLE [dbo].[InsuranceDoc](
	[DocID] [int] IDENTITY(1,1) NOT NULL,
	[DocDate] [date] NULL,
	[DateFrom] [datetime] NULL,
	[DateTo] [datetime] NULL,
	[Referance] [int] NULL,
	[InsuranceCompany] [int] NULL,
	[CarNo] [int] NULL,
	[CarType] [int] NULL,
	[CarCoverType] [int] NULL,
	[CarInsuranceAmount] [decimal](18, 2) NULL,
	[CarCost] [decimal](18, 2) NULL,
	[CarInsuranceService] [nvarchar](50) NULL,
	[VoucherNo] [nchar](10) NULL,
	[DocAmount] [decimal](18, 2) NULL,
	[DocStatus] [int] NULL,
	[DocNotes] [nvarchar](50) NULL,
	[InsuranceDocType] [int] NULL,
	[DocCode] [varchar](15) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InsuranceTypes]    Script Date: 2021-10-05 08:39:54 ******/
CREATE TABLE [dbo].[InsuranceTypes](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[InsuranceTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_InsuranceTypes] PRIMARY KEY CLUSTERED 
(
	[InsuranceTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[InsuranceCarsCoverTypes] ON 
GO
INSERT [dbo].[InsuranceCarsCoverTypes] ([ID], [CoverType]) VALUES (1, N'إلزامي')
GO
INSERT [dbo].[InsuranceCarsCoverTypes] ([ID], [CoverType]) VALUES (2, N'فريق ثالث')
GO
INSERT [dbo].[InsuranceCarsCoverTypes] ([ID], [CoverType]) VALUES (3, N'تكميلي')
GO
SET IDENTITY_INSERT [dbo].[InsuranceCarsCoverTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[InsuranceCarsTypes] ON 
GO
INSERT [dbo].[InsuranceCarsTypes] ([ID], [CarType]) VALUES (1, N'مركبات الخصوصية')
GO
INSERT [dbo].[InsuranceCarsTypes] ([ID], [CarType]) VALUES (2, N'مركبات التجارية')
GO
INSERT [dbo].[InsuranceCarsTypes] ([ID], [CarType]) VALUES (3, N'تاكسي العمومي')
GO
INSERT [dbo].[InsuranceCarsTypes] ([ID], [CarType]) VALUES (4, N'باصات')
GO
INSERT [dbo].[InsuranceCarsTypes] ([ID], [CarType]) VALUES (5, N'سيارات التأجير')
GO
INSERT [dbo].[InsuranceCarsTypes] ([ID], [CarType]) VALUES (6, N'معدات الثقيلة')
GO
SET IDENTITY_INSERT [dbo].[InsuranceCarsTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[InsuranceTypes] ON 
GO
INSERT [dbo].[InsuranceTypes] ([TypeID], [InsuranceTypeName]) VALUES (2, N'التأمين الصحي')
GO
INSERT [dbo].[InsuranceTypes] ([TypeID], [InsuranceTypeName]) VALUES (1, N'تأمين المركبات')
GO
INSERT [dbo].[InsuranceTypes] ([TypeID], [InsuranceTypeName]) VALUES (5, N'تأمين المسؤولية المدنية')
GO
INSERT [dbo].[InsuranceTypes] ([TypeID], [InsuranceTypeName]) VALUES (4, N'تأمين ضد أخطار الحريق والسرقة')
GO
INSERT [dbo].[InsuranceTypes] ([TypeID], [InsuranceTypeName]) VALUES (3, N'تأمين ضد اصابات العمل')
GO
SET IDENTITY_INSERT [dbo].[InsuranceTypes] OFF
GO

ALTER TABLE [dbo].CarsRent Add  [OwnByReferance] int NULL
GO
ALTER TABLE [dbo].CarsRent Add  [Engine] nvarchar(50) NULL
GO
ALTER TABLE [dbo].[Items] Add  [ItemNo2] nvarchar(50) NULL
GO
ALTER TABLE [dbo].[Items] Add  [ItemNo3] nvarchar(50) NULL
GO
ALTER TABLE [dbo].[Items] Add  [ItemNo4] nvarchar(50) NULL
GO
ALTER TABLE [dbo].[Items] Add  [ProductCompany] nvarchar(50) NULL
GO


ALTER TABLE [dbo].[Items] Add  [WebSite1] varchar(100) NULL
GO
ALTER TABLE [dbo].[Items] Add  [WebSite2] varchar(100) NULL
GO

CREATE TABLE [dbo].[FinancialShelves](
	[ShelfID] [int] IDENTITY(1,1) NOT NULL,
	[ShelfCode] [nvarchar](50) NULL,
	[WareHouseID] [int] NULL,
	[ShelfBarCode] [varchar](50) NULL,
 CONSTRAINT [PK_Shelves] PRIMARY KEY CLUSTERED 
(
	[ShelfID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[InsuranceDoc] Add  [BeneficiaryName] nvarchar(100) NULL
GO

ALTER TABLE [dbo].[Appointments] Add [DocCode] [varchar](15) NULL
Go

CREATE TABLE [dbo].[SystemDocNames](
	[DocID] [int] IDENTITY(1,1) NOT NULL,
	[DocName] [nvarchar](50) NOT NULL,
	[DocSystem] [int] NULL,
 CONSTRAINT [PK_SystemDocNames] PRIMARY KEY CLUSTERED 
(
	[DocName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SystemDocNames] ON 
GO
INSERT [dbo].[SystemDocNames] ([DocID], [DocName], [DocSystem]) VALUES (9, N'ارسالية مبيعات', 2)
GO
INSERT [dbo].[SystemDocNames] ([DocID], [DocName], [DocSystem]) VALUES (8, N'ارسالية مشتريات', 2)
GO
INSERT [dbo].[SystemDocNames] ([DocID], [DocName], [DocSystem]) VALUES (7, N'اشعار دائن', 2)
GO
INSERT [dbo].[SystemDocNames] ([DocID], [DocName], [DocSystem]) VALUES (6, N'اشعار مدين', 2)
GO
INSERT [dbo].[SystemDocNames] ([DocID], [DocName], [DocSystem]) VALUES (14, N'سند تأمين', 3)
GO
INSERT [dbo].[SystemDocNames] ([DocID], [DocName], [DocSystem]) VALUES (3, N'سند صرف', 2)
GO
INSERT [dbo].[SystemDocNames] ([DocID], [DocName], [DocSystem]) VALUES (4, N'سند قبض', 2)
GO
INSERT [dbo].[SystemDocNames] ([DocID], [DocName], [DocSystem]) VALUES (5, N'سند قيد', 2)
GO
INSERT [dbo].[SystemDocNames] ([DocID], [DocName], [DocSystem]) VALUES (11, N'طلبية مبيعات', 2)
GO
INSERT [dbo].[SystemDocNames] ([DocID], [DocName], [DocSystem]) VALUES (10, N'طلبية مشتريات', 2)
GO
INSERT [dbo].[SystemDocNames] ([DocID], [DocName], [DocSystem]) VALUES (2, N'فاتورة مبيعات', 2)
GO
INSERT [dbo].[SystemDocNames] ([DocID], [DocName], [DocSystem]) VALUES (1, N'فاتورة مشتريات', 2)
GO
INSERT [dbo].[SystemDocNames] ([DocID], [DocName], [DocSystem]) VALUES (12, N'مردودات مبيعات', 2)
GO
INSERT [dbo].[SystemDocNames] ([DocID], [DocName], [DocSystem]) VALUES (13, N'مردودات مشتريات', 2)
GO
SET IDENTITY_INSERT [dbo].[SystemDocNames] OFF
GO


ALTER TABLE [dbo].[InsuranceDoc] Add  [ManualDocNo] nvarchar(50) NULL
GO



CREATE TABLE [dbo].[Messages](
	[ID] [int]  NOT NULL,
	[SMSName] [nvarchar](100) NOT NULL,
	[SMSMessage] [nvarchar](max) NULL,
	[SMSFields] [varchar](200) NULL,
 CONSTRAINT [PK_SMSNames] PRIMARY KEY CLUSTERED 
(
	[SMSName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


INSERT [dbo].[Messages] ([ID], [SMSName], [SMSMessage], [SMSFields]) VALUES (1, N'تذكير بانتهاء تامين مركبة', N'السادة: #Referenace#، تذكير بانتهاء تامين مركبة #CarNo# بعد #RemainingDays# بتاريخ #FinishDate# وبمبلغ #Amount# نوع السند: #InsuranceType#', N'CarNo,Referenace,Amount,RemainingDays,InsuranceType,FinishDate,ManualDocNo')
GO
INSERT [dbo].[Messages] ([ID], [SMSName], [SMSMessage], [SMSFields]) VALUES (2, N'انتهاء وثيقة', N'السيد: #Referenace# يرجى دفع مبلغ #Amount# عن تامين مركبة رقم #CarNo#', N'CarNo,Referenace,Amount,RemainingDays,InsuranceType,FinishDate,ManualDocNo')

GO
INSERT [dbo].[Messages] ([ID], [SMSName], [SMSMessage], [SMSFields]) VALUES (3, N'استلام دفعة', '', 'ReferanceName,DocAmount,DocDate,DocCurrency,RefBalance')
GO
INSERT [dbo].[Messages] ([ID], [SMSName], [SMSMessage], [SMSFields]) VALUES (4, N'تذكير استحقاق فاتورة', N'السادة: #ReferanceName# نود تذكيركم باستحقاق دفعة بتاريخ #DocDate# مبلغها #DocAmount# #DocCurrency# علما أن الرصيد بلغ #RefBalance# شيكل', N'ReferanceName,DocAmount,DocCurrency,DocDate,RefBalance')
GO
INSERT [dbo].[Messages] ([ID], [SMSName], [SMSMessage], [SMSFields]) VALUES (5, N'مطالبة بالرصيد', N'السادة : #ReferanceName# رصيدكم هو #Balance# ', N'ReferanceName,Balance,Currency')

GO
INSERT [dbo].[Messages] ([ID], [SMSName], [SMSMessage], [SMSFields]) VALUES (6, N'تبليغ بالسحوبات الشهرية للمحروقات', N'',N'ReferanceName,Amount,Balance,Period')

GO
INSERT [dbo].[Messages] ([ID], [SMSName], [SMSMessage], [SMSFields]) VALUES (10, N'تبليغ باشتراك جديد', N'',N'ReferanceName,FromDate,ToDate')
GO
INSERT [dbo].[Messages] ([ID], [SMSName], [SMSMessage], [SMSFields]) VALUES (11, N'تبليغ بعدد الايام المتبقية للاشتراك في بند الاشتراكات', N'',N'ReferanceName,RemainingDays')
Go
INSERT [dbo].[Messages] ([ID], [SMSName], [SMSMessage], [SMSFields]) VALUES (12, N'تبليغ بانتهاء الاشتراك في بند الاشتراكات', N'',N'ReferanceName')
GO
INSERT [dbo].[Messages] ([ID], [SMSName], [SMSMessage], [SMSFields]) VALUES (13, N'تبليغ بتجديد الاشتراك في بند الاشتراكات', N'',N'ReferanceName,FromDate,ToDate')

GO
INSERT [dbo].[Messages] ([ID], [SMSName], [SMSMessage], [SMSFields]) VALUES (20, N'ارسال رسالة عند تسليم مركبة مؤجرة', N'',N'ReferanceName,CarNo')
GO
INSERT [dbo].[Messages] ([ID], [SMSName], [SMSMessage], [SMSFields]) VALUES (21, N'ارسال رسالة عند استلام مركبة مؤجرة', N'',N'ReferanceName,CarNo')
GO


ALTER TABLE [dbo].[ArchiveDocs] Add  [ReferanceNo] int NULL
GO


ALTER TABLE [dbo].[CarsRent] Add  [RelatedService] [varchar](10) NULL
GO


ALTER TABLE [dbo].[CarsRent] Add  [CarCostCenter] int NULL
Go

ALTER TABLE [dbo].[AppointmentClosing] ALTER COLUMN  [Notes] [nvarchar] (MAX) NULL
Go


ALTER TABLE [dbo].[Items] Add  [VisibleInAPP] bit NULL
Go

ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_CheckShowInAPP]  DEFAULT ((1)) FOR [VisibleInAPP]
GO

ALTER TABLE [dbo].[Checks] Add  [RelatedReferance] int NULL
Go

Insert into [dbo].[Settings] (SettingName,SettingValue ) values ('DefualtAccountForInsuranceExpense','0')
Go

ALTER TABLE [dbo].[InsuranceDoc] Add  [RelatedJournal] int NULL
Go

ALTER TABLE [dbo].[InsuranceDoc] Add  [InsuranceExpense]  [decimal](18, 2)  NULL
Go

ALTER TABLE [dbo].[InsuranceDoc] ADD  CONSTRAINT [DF_InsuranceDoc_InsuranceExpense]  DEFAULT ((0)) FOR [InsuranceExpense]
GO

ALTER TABLE [dbo].[InsuranceDoc] Add  [InsurancePlace]  [nvarchar] (50) NULL
Go

ALTER TABLE [dbo].[InsuranceDoc] ALTER COLUMN  [VoucherNo] int NULL
Go




ALTER TABLE [dbo].[Journal] ALTER COLUMN  [ReferanceName] [nvarchar] (100) NULL
Go
ALTER TABLE [dbo].[JournalTemp] ALTER COLUMN  [ReferanceName] [nvarchar] (100) NULL
Go
ALTER TABLE [dbo].[POSJournal] ALTER COLUMN  [ReferanceName] [nvarchar] (100) NULL
Go
ALTER TABLE [dbo].[OrdersJournal] ALTER COLUMN  [ReferanceName] [nvarchar] (100) NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] ALTER COLUMN  [ReferanceName] [nvarchar] (100) NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] ALTER COLUMN  [ReferanceName] [nvarchar] (100) NULL
Go


ALTER TABLE [dbo].[Journal] Add  [VoucherDiscount] float NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [VoucherDiscount] float NULL
Go
ALTER TABLE [dbo].[POSJournal] Add  [VoucherDiscount] float NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [VoucherDiscount] float NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [VoucherDiscount] float NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add  [VoucherDiscount] float NULL
Go

ALTER TABLE [dbo].[Journal] Add  [ItemVAT] float NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [ItemVAT] float NULL
Go
ALTER TABLE [dbo].[POSJournal] Add  [ItemVAT] float NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [ItemVAT] float NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [ItemVAT] float NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add  [ItemVAT] float NULL
Go


Insert into [dbo].[Settings] (SettingName,SettingValue ) values ('VATInternal','0')
Go

Insert into [dbo].[Settings] (SettingName,SettingValue ) values ('Campaignes','0')
Go





CREATE TABLE [dbo].[CampaginByItemsCount](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemNo] [int] NOT NULL,
	[Quantity] [decimal](18, 2) NOT NULL,
	[Amount] [float] NOT NULL,
	[CampaginID] [int] NOT NULL,
	[ItemName] [nvarchar](100) NULL,
	[UnitPrice] [float] NULL,
	[CampignesPrice] [float] NULL,
 CONSTRAINT [PK_CampaginByItemsCount] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Campagins](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CampaginName] [nvarchar](50) NOT NULL,
	[CampaginType] [int] NOT NULL,
	[FromDate] [datetime] NOT NULL,
	[ToDate] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
	[CampaginNotes] [nvarchar](max) NULL,
	[CampaginCode] [varchar](50) NULL,
	[ItemsCount] [int] NULL,
	[Inputdate] [datetime] NULL,
	[UserCreater] [int] NULL,
	[Branch] [int] NULL,
 CONSTRAINT [PK_Compagins] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Referencess] Add   [RefImage] [image] NULL
Go

CREATE TABLE [dbo].[SubscriptionDoc](
	[SubID] [int] IDENTITY(1,1) NOT NULL,
	[Subscriber] [int] NULL,
	[SubscriberName] [nvarchar](50) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Amount] [decimal](18, 2) NULL,
	[SubStatus] [bit] NULL,
	[DocNotes] [nvarchar](max) NULL,
	[DocStatus] [int] NULL,
	[SubscriptionType] [varchar](10) NULL,
	[RelatedVoucherCode] [varchar](15) NULL,
	[DocCode] [varchar](15) NULL,
	[VoucherNo] [int] NULL,
 CONSTRAINT [PK_SubscriptionDoc] PRIMARY KEY CLUSTERED 
(
	[SubID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [dbo].[InsuranceDoc] Add  [InsuranceExpenseMethod] int NULL  
Go
ALTER TABLE [dbo].[AttCHECKINOUT] Add  [Latitude] [decimal](8,6) NULL
Go
ALTER TABLE [dbo].[AttCHECKINOUT] Add  [Longitude] [decimal](9,6) NULL 
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('ShowColNoteInMoneyTransDoc','False')
Go
ALTER TABLE [dbo].[Checks] Add  [DocNoteByAccount] [nvarchar] (Max) NULL
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('ShowColNoteInStockMoveDoc','False')
Go
ALTER TABLE [dbo].[PosVouchers] Add  [ShiftID] [int] NULL 
Go
Insert into [dbo].[DocNames] (id,Name) values (14,N'سند استلام بضاعة')
Go
Insert into [dbo].[DocNames] (id,Name) values (15,N'سند تسليم بضاعة')
Go
Insert into [dbo].[DocNames] (id,Name) values (16,N'ارسالية داخلية')
Go


ALTER TABLE [dbo].[Journal] Add  [StockDebitShelve] int NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [StockDebitShelve] int NULL
Go
ALTER TABLE [dbo].[POSJournal] Add  [StockDebitShelve] int NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [StockDebitShelve] int NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [StockDebitShelve] int NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add  [StockDebitShelve] int NULL
Go

ALTER TABLE [dbo].[Journal] Add  [StockCreditShelve] int NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [StockCreditShelve] int NULL
Go
ALTER TABLE [dbo].[POSJournal] Add  [StockCreditShelve] int NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [StockCreditShelve] int NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [StockCreditShelve] int NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add  [StockCreditShelve] int NULL
Go




--UPDATE A
--SET StockQuantityByMainUnit = A.StockQuantity * B.EquivalentToMain 
--FROM Journal A
--JOIN Items_units B
--    ON A.StockID = b.item_id and A.StockUnit=B.unit_id 

ALTER TABLE [dbo].[PosVouchers] Add  [DocName] int NULL
Go

ALTER TABLE [dbo].[PosVouchers]
DROP CONSTRAINT [PK_PosVouchers];
Go

ALTER TABLE [dbo].[PosVouchers] ADD ID INT IDENTITY(1,1);
Go

Update [dbo].[PosVouchers]
Set DocName = 2 where DocName is null
Go

ALTER TABLE [dbo].[PosShifts] Add  [UserName] [nvarchar](100) NULL
Go



ALTER TABLE [dbo].[PosVouchers] Add  [VoucherDiscount2] [decimal](18,2) NULL
Go



Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosPrinterSize',290)
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('POSTileViewItems',50)
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('POSTileViewGroups',50)
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosVoucherNote1',' ')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosVoucherNote2',' ')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('OpenCashOnSave','False')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('POSItemsGroupWidth','80')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('POSItemsGroupHeight','80')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('POSItemsWidth','155')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('POSItemsHeight','105')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('POSVoucherWidth','622')
Go

CREATE TABLE [dbo].[ShelvesReportTemp](
	[StockID] [varchar](10) NULL,
	[ItemName] [nvarchar](500) NULL,
	[ShelvID] [int] NULL,
	[balance] [decimal](18, 0) NULL
) ON [PRIMARY]
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PrintHeaderInVouchers','True')
Go


CREATE TABLE [dbo].[ShelvesReportTemp](
	[StockID] [varchar](10) NULL,
	[ItemName] [nvarchar](500) NULL,
	[ShelvID] [int] NULL,
	[balance] [decimal](18, 0) NULL
) ON [PRIMARY]
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('ShowItemNo2','False')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('IssueVoucherInSubscriptionsSystem','True')
Go

ALTER TABLE [dbo].[Journal] Add  [DocCheckTransID] int NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [DocCheckTransID] int NULL
Go
ALTER TABLE [dbo].[POSJournal] Add  [DocCheckTransID] int NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [DocCheckTransID] int NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [DocCheckTransID] int NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add  [DocCheckTransID] int NULL
Go

ALTER TABLE [dbo].[Journal] Add  [TransNoInJournal] int NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [TransNoInJournal] int NULL
Go
ALTER TABLE [dbo].[POSJournal] Add  [TransNoInJournal] int NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [TransNoInJournal] int NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [TransNoInJournal] int NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add  [TransNoInJournal] int NULL
Go


Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PrintBarcodeInVoucher','False')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PrintRefBalanceInVoucher','False')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('ShowBarcodeColumnInVoucher','True')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('POSuseShelves','False')
Go


ALTER TABLE [dbo].[Items] Add  [ItemStatus] bit NULL
Go
Update Items Set [ItemStatus]  = 1 Where [ItemStatus]  Is Null
Go


ALTER TABLE [dbo].[Items] Add  [HasSerial] bit NULL
Go
Update Items Set [HasSerial]  = 0 Where [HasSerial]  Is Null


CREATE TABLE [dbo].[ItemsSerials](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SerialNumber] [varchar](50) NOT NULL,
	[SerialStatus] [int] NOT NULL,
	[PurchaseWarrantyStart] [date] NULL,
	[PurchaseWarrantyEnd] [date] NULL,
	[SaleWarrantyStart] [date] NULL,
	[SaleWarrantyEnd] [date] NULL,
	[ItemNo] [int] NULL,
	[DocCode] [varchar](15) NULL,
 CONSTRAINT [PK_ItemsSerials_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemsSerialsTemp]    Script Date: 12/01/2022 09:32:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsSerialsTemp](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SerialNumber] [varchar](50) NOT NULL,
	[SerialStatus] [int] NOT NULL,
	[PurchaseWarrantyStart] [date] NULL,
	[PurchaseWarrantyEnd] [date] NULL,
	[SaleWarrantyStart] [date] NULL,
	[SaleWarrantyEnd] [date] NULL,
	[ItemNo] [int] NULL,
	[UserNo] [int] NULL,
	[DocCode] [varchar](15) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemsSerialTrans]    Script Date: 12/01/2022 09:32:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsSerialTrans](
	[TransID] [int] IDENTITY(1,1) NOT NULL,
	[SerialNumber] [varchar](50) NOT NULL,
	[DocCode] [varchar](15) NOT NULL,
	[ItemNo] [int] NOT NULL,
	[SerialID] [int] NULL,
	[SerialDebitWhereHouse] [int] NOT NULL,
	[SerialCreditWhereHouse] [int] NOT NULL,
	[DocName] [int] NOT NULL,
	[DocDate] [date] NOT NULL,
	[AddedDate] [datetime] NULL,
	[AddedUser] [int] NULL,
	[Notes] [nvarchar](50) NULL,
	[DocNo] [int] NULL,
 CONSTRAINT [PK_ItemsSerialTrans] PRIMARY KEY CLUSTERED 
(
	[TransID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemsSerialTransTemp]    Script Date: 12/01/2022 09:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsSerialTransTemp](
	[SerialNumber] [varchar](50) NOT NULL,
	[DocCode] [varchar](15) NOT NULL,
	[ItemNo] [int] NULL,
	[UserNo] [int] NOT NULL,
	[SerialID] [int] NULL,
	[TransID] [int] IDENTITY(1,1) NOT NULL,
	[SerialDebitWhereHouse] [int] NOT NULL,
	[SerialCreditWhereHouse] [int] NOT NULL,
	[DocName] [int] NOT NULL,
	[DocDate] [date] NOT NULL,
	[AddedDate] [datetime] NULL,
	[AddedUser] [int] NULL,
	[Notes] [nvarchar](50) NULL,
	[DocNo] [int] NULL,
	[TempTransType] [nvarchar](10) NULL,
	[TransIDInSerialTrans] [int] NULL,
	[PurchaseWarrantyStart] [date] NULL,
	[PurchaseWarrantyEnd] [date] NULL,
	[SaleWarrantyStart] [date] NULL,
	[SaleWarrantyEnd] [date] NULL,
	[IDInSerials] [int] NULL,
	[SerialStatus] [int] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ItemsSerialTransTemp] ADD  CONSTRAINT [DF_ItemsSerialTransTemp_SerialDebitWhereHouse]  DEFAULT ((0)) FOR [SerialDebitWhereHouse]
GO

ALTER TABLE [dbo].[ItemsSerialTransTemp] ADD  CONSTRAINT [DF_ItemsSerialTransTemp_SerialCreditWhereHouse]  DEFAULT ((0)) FOR [SerialCreditWhereHouse]
GO


ALTER TABLE [dbo].[ItemsSerialTransTemp] ALTER COLUMN ItemNo [int];
Go
ALTER TABLE [dbo].[ItemsSerialTrans] ALTER COLUMN ItemNo [int];
Go
ALTER TABLE [dbo].[ItemsSerialsTemp] ALTER COLUMN ItemNo [int];
Go
ALTER TABLE [dbo].[ItemsSerials] ALTER COLUMN ItemNo [int];
Go
ALTER TABLE [dbo].[CampaginByItemsCount] ALTER COLUMN ItemNo [int];
Go
ALTER TABLE [dbo].[ItemsPriceCategories] ALTER COLUMN ItemNo [int];
Go


ALTER TABLE [dbo].[Journal] ALTER COLUMN [StockID] int NULL
Go
ALTER TABLE [dbo].[JournalTemp] ALTER COLUMN [StockID] int NULL
Go
ALTER TABLE [dbo].[POSJournal] ALTER COLUMN [StockID] int NULL
Go
ALTER TABLE [dbo].[OrdersJournal] ALTER COLUMN [StockID] int NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] ALTER COLUMN [StockID] int NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] ALTER COLUMN [StockID] int NULL
Go


Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('UseSerials','False')
Go
/****** Object:  [ItemsSerialTransTemp] ******/


ALTER TABLE dbo.JOURNALTEMP ADD ID INT IDENTITY(1,1)
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('ShowShelvesColumnInVoucher','False')

Go
ALTER TABLE [dbo].[AttCHECKINOUTPending] ALTER COLUMN [Location] [nvarchar](100) NULL
Go
ALTER TABLE [dbo].[AttCHECKINOUT] Add [Location] [nvarchar](100) NULL
Go

CREATE TABLE [dbo].[TasksFromPITS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TasksDate] [datetime] NULL,
	[TasksCount] [int] NULL,
	[UserID] [int] NULL,
	[InputDateTime] [datetime] NULL,
 CONSTRAINT [PK_TasksFromBits] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TasksFromPITS] ADD  CONSTRAINT [DF_TasksFromBits_InputDateTime]  DEFAULT (getdate()) FOR [InputDateTime]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  DEFAULT ('1900-01-01') FOR [DateOfStart]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  DEFAULT ('2100-01-01') FOR [DateOfEnd]
GO


ALTER TABLE [dbo].[EmployeesData] ADD  DEFAULT ('00:00') FOR [RequiredDailyHoures]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  DEFAULT ((1.00)) FOR [BonusOnDayOff]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_AttFromMobileProcess]  DEFAULT ((1)) FOR [AttFromMobileProcess]
GO

ALTER TABLE [dbo].[EmployeesData] Add [AttFromMobileProcess] [int] NULL
Go
ALTER TABLE [dbo].[EmployeesData] Add [Notes] [nvarchar](max) NULL
Go

Update [EmployeesData] set [AttFromMobileProcess]=1 where [AttFromMobileProcess] is null
Go
Update [EmployeesData] set [AllowUseAttApp]=1 where AllowUseAttApp is null
Go
Update [EmployeesData] set AllowUseAttApp=1 where AllowUseAttApp is null
Go

ALTER TABLE [dbo].[AttCHECKINOUTPending] Add [TransStatus] [int] NULL
Go
ALTER TABLE [dbo].[AttCHECKINOUTPending] Add [DocInputDateTime] [datetime] NULL
Go
ALTER TABLE [dbo].[AttCHECKINOUTPending] ADD  CONSTRAINT [DF_AttCHECKINOUTPending_TransStatus]  DEFAULT ((0)) FOR [TransStatus]
GO
ALTER TABLE [dbo].[AttCHECKINOUTPending] ADD  CONSTRAINT [DF_AttCHECKINOUTPending_DocInputDateTime]  DEFAULT (getdate()) FOR [DocInputDateTime]
GO
ALTER TABLE [dbo].[AttCHECKINOUTPending] Add [Latitude] decimal(8, 6) NULL
Go
ALTER TABLE [dbo].[AttCHECKINOUTPending] Add [Longitude] decimal(9, 6) NULL
Go



ALTER TABLE VocationsPending Add [DocStatus] [int] NULL
Go
ALTER TABLE VocationsPending Add [DocInputDateTime] [datetime] NULL
Go
ALTER TABLE VocationsPending Add [NoteFromManager] [nvarchar](500) NULL
Go
ALTER TABLE AttCHECKINOUTPending Add [NoteFromManager] [nvarchar](500) NULL
Go

ALTER TABLE [dbo].[VocationsPending] ADD  CONSTRAINT [DF_VocationsPending_DocStatus]  DEFAULT ((0)) FOR [DocStatus]
GO
ALTER TABLE [dbo].[VocationsPending] ADD  CONSTRAINT [DF_VocationsPending_DocInputDateTime]  DEFAULT (getdate()) FOR [DocInputDateTime]
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('AllowCostCenterByRow','False')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('AllowMinusQuantityInVouchers','False')
Go
ALTER TABLE [dbo].[Items] Add TransOnShelf [bit] NULL
Go
Update items set TransOnShelf=0 where TransOnShelf is null
Go

CREATE PROCEDURE [dbo].[CreateAttTransFromAPI] @USERID int, @CHECKTIME datetime ,
					       @CHECKTYPE nvarchar(2) ,
					       @MobileName nvarchar(50),@Latitude nvarchar(50),@Longitude nvarchar(50)
AS
DECLARE @AttFromMobileProcess int ;
DECLARE @ReturnVal varchar(10); 
SET @AttFromMobileProcess = ( Select AttFromMobileProcess  from EmployeesData where EmployeeID=@USERID);

    IF @AttFromMobileProcess =1
    BEGIN
    Insert into [AttCHECKINOUT] (USERID,CHECKTIME,CHECKTYPE,SENSORID,Latitude,Longitude)
	Values( @USERID,FORMAT (GetDate(), 'yyyy-MM-dd HH:mm'),@CHECKTYPE,@MobileName,@Latitude,@Longitude)
	Set @ReturnVal= 1
    END

	IF @AttFromMobileProcess =2
    BEGIN
	set @ReturnVal= 0
    END

	IF @AttFromMobileProcess =3
    BEGIN
	Insert into [AttCHECKINOUTPending] (USERID,CHECKTIME,CHECKTYPE,SENSORID,Latitude,Longitude)
	Values( @USERID,FORMAT (GetDate(), 'yyyy-MM-dd HH:mm'),@CHECKTYPE,@MobileName,@Latitude,@Longitude)
	set @ReturnVal= 1
    END
	return @ReturnVal
GO

CREATE PROCEDURE [dbo].[TasksAudit] @Company nvarchar(50),@TaskID as int,@AuditNote as nvarchar(max)
AS
DECLARE @UserID int;
DECLARE @CreationID int;
DECLARE @TaskStatus int;
DECLARE @InputDateTime DATETIME;
SET @UserID = ( Select AssignedTo   from Appointments where UniqueID=@TaskID);
SET @CreationID = ( Select CreationUser   from Appointments where UniqueID=@TaskID);
SET @InputDateTime= (select CONVERT(char(10), GetDate(),126) + ' ' + convert(VARCHAR(8), GETDATE(), 14))
SET @TaskStatus = ( Select TaskStatus from Appointments where UniqueID=@TaskID);

--Add New CloseAppointments
Insert into AppointmentClosing
			(TaskID,Notes,ClosingDate,UserID,LastTaskStatus,CurrentTaskStatus) Values (@TaskID,@AuditNote,@InputDateTime,@UserID,@TaskStatus,4)

--Update Appointment
Update [dbo].[Appointments] Set
                            TaskStatus=4, 
                            Label=3,
                            AssignedTo=@CreationID
                            Where UniqueID=@TaskID


return  @TaskID;
GO


CREATE PROCEDURE [dbo].[TasksComplete] @Company nvarchar(50),@TaskID as int,@CompleteNote as nvarchar(max)
AS
DECLARE @UserID int;
DECLARE @CreationID int;
DECLARE @TaskStatus int;
DECLARE @InputDateTime DATETIME;
SET @UserID = ( Select AssignedTo   from Appointments where UniqueID=@TaskID);
SET @CreationID = ( Select CreationUser   from Appointments where UniqueID=@TaskID);
SET @InputDateTime= (select CONVERT(char(10), GetDate(),126) + ' ' + convert(VARCHAR(8), GETDATE(), 14))
SET @TaskStatus = ( Select TaskStatus from Appointments where UniqueID=@TaskID);

--Add New CloseAppointments
Insert into AppointmentClosing
			(TaskID,Notes,ClosingDate,UserID,LastTaskStatus,CurrentTaskStatus) Values (@TaskID,@CompleteNote,@InputDateTime,@UserID,@TaskStatus,3)

--Update Appointment
Update [dbo].[Appointments] Set
                            TaskStatus=3, 
                            Label=3,
                            AssignedTo=@CreationID
                            Where UniqueID=@TaskID


return  @TaskID;
GO




CREATE PROCEDURE [dbo].[TasksCreate] @Company nvarchar(50), @StartDate datetime ,
							        @Subject nvarchar(50) ,@Description nvarchar(1000),
									@CreationUser int,@AssignedTo int,@Referance int
AS
DECLARE @ReferanceName nvarchar(50) ;
DECLARE @DocCode as varchar(15);
DECLARE @TaskID as int;
DECLARE @InputDateTime DATETIME
SET @ReferanceName = ( Select RefName  from Referencess where RefNo=@Referance);
SET @DocCode= ( select Right(NEWID(),15));
SET @InputDateTime= (select CONVERT(char(10), GetDate(),126) + ' ' + convert(VARCHAR(8), GETDATE(), 14))

--Add New Appointments
Insert into [Appointments] ( [Type],StartDate,EndDate,QueryStartDate,[QueryEndDate],
            [AllDay],[Subject],[Location],[Description],[Status],[Label],[ReminderInfo],
            [TimeZoneId],CreationUser,TaskStatus,CreationDate,AssignedTo,[Referance],DocCode)
	Values( 0, @StartDate ,DATEADD(DAY, 1, @StartDate),@StartDate,DATEADD(DAY, 1, @StartDate),
		    0,@Subject,@ReferanceName,@Description,2,3,'',
			'Israel Standard Time',@CreationUser,1,@InputDateTime,@AssignedTo,@Referance,@DocCode)



--Add New AppointmentClosing
Set @TaskID= (Select UniqueID from Appointments Where DocCode=@DocCode)
Insert Into [AppointmentClosing] (TaskID,Notes,ClosingDate,UserID,LastTaskStatus,CurrentTaskStatus) Values (@TaskID,N'انشاء المهمة',@InputDateTime,@CreationUser,0,1)

return  @TaskID;
GO



CREATE PROCEDURE [dbo].[TasksFollow] @Company nvarchar(50),@TaskID as int,@FollowNote as nvarchar(max),@TaskDate datetime
AS
DECLARE @UserID int;
DECLARE @CreationID int;
DECLARE @TaskStatus int;
DECLARE @InputDateTime DATETIME;
SET @UserID = ( Select AssignedTo   from Appointments where UniqueID=@TaskID);
SET @CreationID = ( Select CreationUser   from Appointments where UniqueID=@TaskID);
SET @InputDateTime= (select CONVERT(char(10), GetDate(),126) + ' ' + convert(VARCHAR(8), GETDATE(), 14))
SET @TaskStatus = ( Select TaskStatus from Appointments where UniqueID=@TaskID);

--Add New CloseAppointments
Insert into AppointmentClosing
			(TaskID,Notes,ClosingDate,UserID,LastTaskStatus,CurrentTaskStatus) Values (@TaskID,@FollowNote,@InputDateTime,@UserID,@TaskStatus,2)

--Update Appointment
Update [dbo].[Appointments] Set
							       TaskStatus=2,
                                   StartDate=@TaskDate,
                                   [EndDate]=DATEADD(DAY, 1, @TaskDate),
                                   QueryStartDate= @TaskDate,
                                   QueryEndDate=DATEADD(DAY, 1, @TaskDate),
                                   Description=@FollowNote
                                   Where UniqueID=@TaskID
return  @TaskID;
GO



ALTER TABLE [dbo].[VocationsDefaultBalances] ALTER COLUMN [DefaultBalanceForEmployee] [decimal](18, 2) NULL
Go

ALTER TABLE [dbo].[VocationsTypes] ALTER COLUMN [VocationDefaultBalance] [decimal](18, 2) NULL
Go
ALTER TABLE [dbo].[VacationsBalancesAdding] ALTER COLUMN [BalanceDays] [decimal](18, 2) NULL
Go


ALTER TABLE [dbo].[Referencess] Add CreatedBy [nvarchar](50) NULL
Go
ALTER TABLE [dbo].[Referencess] Add CreateDate [datetime] NULL
Go
ALTER TABLE [dbo].[Referencess] Add FirstTransInJournalDate [datetime] NULL
Go


ALTER TABLE [dbo].[Journal] ALTER COLUMN [DocCode] varchar(50) NULL
Go
ALTER TABLE [dbo].[JournalTemp] ALTER COLUMN [DocCode] varchar(50) NULL
Go
ALTER TABLE [dbo].[POSJournal] ALTER COLUMN [DocCode] varchar(50) NULL
Go
ALTER TABLE [dbo].[OrdersJournal] ALTER COLUMN [DocCode] varchar(50) NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] ALTER COLUMN [DocCode] varchar(50) NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] ALTER COLUMN [DocCode] varchar(50) NULL
Go


ALTER TABLE [dbo].[Journal] ALTER COLUMN [LastDocCode] varchar(50) NULL
Go
ALTER TABLE [dbo].[JournalTemp] ALTER COLUMN [LastDocCode] varchar(50) NULL
Go
ALTER TABLE [dbo].[POSJournal] ALTER COLUMN [LastDocCode] varchar(50) NULL
Go
ALTER TABLE [dbo].[OrdersJournal] ALTER COLUMN [LastDocCode] varchar(50) NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] ALTER COLUMN [LastDocCode] varchar(50) NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] ALTER COLUMN [LastDocCode] varchar(50) NULL
Go

ALTER TABLE [dbo].[PosVouchers] ALTER COLUMN [VoucherCode] varchar(50) NULL
Go

Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('UseSalesMan','False')
Go

ALTER TABLE [dbo].[EmployeesData] Add [DefaultWareHouse] [int] NULL
Go
ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_DefaultWareHouse]  DEFAULT ((1)) FOR [DefaultWareHouse]
GO
Update [dbo].[EmployeesData] Set DefaultWareHouse = 1 where DefaultWareHouse Is Null
Go

ALTER TABLE [dbo].[OrdersAppJournal]  Add  [Latitude] [decimal](8,6) NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal]  Add  [Longitude] [decimal](9,6) NULL 
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('ShowItemNo2InDocuments','False')
Go

ALTER TABLE [dbo].[Journal] Add  [ItemNo2] varchar(50) NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [ItemNo2] varchar(50) NULL
Go
ALTER TABLE [dbo].[POSJournal] Add [ItemNo2] varchar(50) NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [ItemNo2] varchar(50) NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [ItemNo2] varchar(50) NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add [ItemNo2] varchar(50) NULL
Go

Update [dbo].[Settings] Set SettingValue ='BarCode' where SettingName='PrintBarcodeInVoucher' and SettingValue='True'
Update [dbo].[Settings] Set SettingValue ='StockID' where SettingName='PrintBarcodeInVoucher' and SettingValue='False'

Go

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('WareHouseUseShelf','False')
Go

CREATE TABLE [dbo].[UsersLogs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocCode] [varchar](50) NULL,
	[DocName] [int] NULL,
	[DocID] [int] NULL,
	[LogName] [varchar](10) NULL,
	[UserID] [int] NULL,
	[LogDateTime] [datetime] NULL,
	[DeviceName] [varchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[LogDetails] [nvarchar](1000) NULL,
	[LogType] [varchar](50) NULL
) ON [PRIMARY]
GO


Insert into [dbo].[DocNames] (id,Name) values (17,N'سند ادخال بضاعة')
Go
Insert into [dbo].[DocNames] (id,Name) values (18,N'سند اخراج بضاعة')
Go



CREATE TABLE [dbo].[Assets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AssetCode] [varchar](50) NULL,
	[AssetName] [nvarchar](50) NULL,
	[AssetLocation] [nvarchar](50) NULL,
	[Cost] [decimal](18, 0) NULL,
	[PurchaseDate] [date] NULL,
	[DepreciationPercentage] [decimal](18, 0) NULL,
	[AssetType] [int] NULL,
	[Notes] [nvarchar](1000) NULL,
	[ItemNo] [int] NULL,
 CONSTRAINT [PK_Assets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[AssetsType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AssetType] [nvarchar](50) NOT NULL,
	[AssetsMainAccount] [varchar](10) NULL,
	[AssetsDepAccount] [varchar](10) NULL,
	[AssetsAccumulatedAccount] [varchar](10) NULL,
 CONSTRAINT [PK_AssetsType] PRIMARY KEY CLUSTERED 
(
	[AssetType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



ALTER TABLE [dbo].[ShelvesReportTemp] Add [ItemNo2] varchar(50) NULL
Go

CREATE TABLE [dbo].[POSHoldJournal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocID] [int] NULL,
	[DocDate] [date] NULL,
	[DocName] [int] NULL,
	[DocStatus] [int] NULL,
	[DocCostCenter] [int] NULL,
	[DebitAcc] [varchar](10) NULL,
	[CredAcc] [varchar](10) NULL,
	[AccountCurr] [int] NULL,
	[DocCurrency] [int] NULL,
	[DocAmount] [float] NULL,
	[ExchangePrice] [float] NULL,
	[BaseCurrAmount] [float] NULL,
	[BaseAmount] [float] NULL,
	[DocSort] [int] NULL,
	[Referance] [nvarchar](20) NULL,
	[DocManualNo] [nvarchar](50) NULL,
	[DocMultiCurrency] [bit] NULL,
	[InputUser] [int] NULL,
	[InputDateTime] [datetime] NULL,
	[ModifiedUser] [int] NULL,
	[ModifiedDateTime] [datetime] NULL,
	[DocAuditDate] [datetime] NULL,
	[DocAuditUser] [int] NULL,
	[DocNotes] [nvarchar](1024) NULL,
	[StockID] [int] NULL,
	[StockUnit] [int] NULL,
	[StockQuantity] [float] NULL,
	[StockQuantityByMainUnit] [float] NULL,
	[StockPrice] [float] NULL,
	[StockItemPrice] [float] NULL,
	[StockDiscount] [float] NULL,
	[StockDebitWhereHouse] [int] NULL,
	[StockCreditWhereHouse] [int] NULL,
	[StockDriver] [nvarchar](50) NULL,
	[StockCarNo] [int] NULL,
	[SalesPerson] [int] NULL,
	[CheckNo] [int] NULL,
	[CheckInOut] [nvarchar](5) NULL,
	[CheckStatus] [int] NULL,
	[CheckDueDate] [date] NULL,
	[CheckCustBank] [varchar](20) NULL,
	[CheckCustBranch] [varchar](20) NULL,
	[CheckCustAccountId] [varchar](20) NULL,
	[AccountBank] [int] NULL,
	[DeleteUser] [int] NULL,
	[DeleteDateTime] [datetime] NULL,
	[CurrentUserID] [int] NULL,
	[ReferanceName] [nvarchar](100) NULL,
	[DocCode] [varchar](50) NULL,
	[CheckCode] [varchar](15) NULL,
	[ItemName] [nvarchar](100) NULL,
	[DocCheckTransID] [int] NULL,
	[TransNoInJournal] [int] NULL,
	[ShiftID] [int] NULL,
	[DocNoteByAccount] [nvarchar](1024) NULL,
	[UnitName] [nvarchar](50) NULL,
	[SaleOnScale] [bit] NULL,
	[StockBarcode] [varchar](50) NULL,
	[PCName] [varchar](50) NULL,
	[PosNo] [int] NULL,
	[DeviceName] [varchar](70) NULL,
	[OrderStatus] [int] NULL,
	[ItemStatus] [int] NULL,
	[ApprovedQuantity] [decimal](18, 2) NULL,
	[DeliverDate] [datetime] NULL,
	[LastDocCode] [varchar](50) NULL,
	[LastDataName] [varchar](15) NULL,
	[Color] [int] NULL,
	[Measure] [int] NULL,
	[VoucherDiscount] [float] NULL,
	[ItemVAT] [float] NULL,
	[StockDebitShelve] [int] NULL,
	[StockCreditShelve] [int] NULL,
	[ItemNo2] [varchar](50) NULL,
 CONSTRAINT [PK_POSHoldJournal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[POSHoldJournal] ADD  CONSTRAINT [DF_POSHoldJournal_DocStatus]  DEFAULT ((1)) FOR [DocStatus]
GO

ALTER TABLE [dbo].[POSHoldJournal] ADD  CONSTRAINT [DF_POSHoldJournal_DocCostCenter]  DEFAULT ((1)) FOR [DocCostCenter]
GO

ALTER TABLE [dbo].[POSHoldJournal] ADD  CONSTRAINT [DF_POSHoldJournal_DocSort]  DEFAULT ((0)) FOR [DocSort]
GO

ALTER TABLE [dbo].[POSHoldJournal] ADD  CONSTRAINT [DF_POSHoldJournal_Referance]  DEFAULT ((0)) FOR [Referance]
GO

ALTER TABLE [dbo].[POSHoldJournal] ADD  CONSTRAINT [DF_POSHoldJournal_DocManualNo]  DEFAULT ((0)) FOR [DocManualNo]
GO

ALTER TABLE [dbo].[POSHoldJournal] ADD  CONSTRAINT [DF_POSHoldJournal_DocMultiCurrency]  DEFAULT ((0)) FOR [DocMultiCurrency]
GO


ALTER TABLE [dbo].[Items] Add [MaxQuantity] decimal(18, 2) NULL
Go




ALTER TABLE [dbo].[Journal] Add  [OrderID] [int] NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [OrderID] [int] NULL
Go
ALTER TABLE [dbo].[POSJournal] Add [OrderID] [int] NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [OrderID] [int] NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [OrderID] [int] NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add [OrderID] [int] NULL
Go

ALTER TABLE [dbo].[EmployeesData] Add [MaxLeavesHouresDaily] varchar(10) NULL
Go

ALTER TABLE [dbo].[Vocations] Add [VocationSource] varchar(10) NULL
Go

Insert into [dbo].[DocNames] (id,Name) values (19,N'سند انتاج')
Go


ALTER TABLE [dbo].[Items] Add [HasProductionEquation] [Bit] NULL
Go

ALTER TABLE [dbo].[Journal] Add  [Produced] [Bit] NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [Produced] [Bit] NULL
Go
ALTER TABLE [dbo].[POSJournal] Add [Produced] [Bit] NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [Produced] [Bit] NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [Produced] [Bit] NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add [Produced] [Bit] NULL
Go
ALTER TABLE [dbo].[POSHoldJournal] Add [Produced] [Bit] NULL
Go



ALTER TABLE [dbo].[AssetsType] Add [AssetsAccumulatedAccount] varchar(10) Null
Go


CREATE TABLE [dbo].[AccountingBranches](
	[ID] [int] NOT NULL,
	[BranchName] [nvarchar](50) NOT NULL,
	[BranchNameE] [varchar](50) NULL,
	[BranchCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AccountingBranches] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[AccountingPOSNames](
	[ID] [int] NOT NULL,
	[POSCode] [nvarchar](50) NOT NULL,
	[POSName] [nvarchar](50) NOT NULL,
	[CostCenter] [int] NOT NULL,
	[PrefixCode] [nvarchar](50) NOT NULL,
	[BranchID] [int] NOT NULL,
	[Warehouse] [int] NOT NULL,
	[OnlineOnly] [bit] NOT NULL,
	[Note1] [nvarchar](50) NULL,
	[Note2] [nvarchar](50) NULL,
	[PaperSize] [decimal](18, 0) NULL,
	[OpenCashDrawerOnSave] [bit] NOT NULL,
	[POSQr] [image] NULL,
	[ServerAddress] [varchar](500) NULL,
	[DefaultPrinter] [nvarchar](50) NULL,
	[Tickets] [bit] NOT NULL,
	[UseDirectProduction] [bit] NOT NULL,
 CONSTRAINT [PK_AccountingPOSNames] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE TABLE [dbo].[ReferancesBySalesMan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceNo] [int] NOT NULL,
	[SalesManNo] [int] NOT NULL,
 CONSTRAINT [PK_ReferancesBySalesMan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[ProductionEquation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EquationID] [int] NOT NULL,
	[ItemNo] [int] NOT NULL,
	[ItemUnit] [int] NOT NULL,
	[ItemQuantity] [float] NOT NULL,
	[DocNote] [nvarchar](max) NULL,
	[RawItemNo] [int] NOT NULL,
	[RawItemQuantity] [float] NOT NULL,
	[RawItemUnit] [int] NOT NULL,
	[RawItemPrice] [float] NOT NULL,
	[RawItemAmount] [float] NOT NULL,
	[RawItemName] [nvarchar](100) NULL,
	[EquationStatus] [bit] NOT NULL,
 CONSTRAINT [PK_ProductionEquation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


Alter Table [dbo].[ArchiveDocsSorts1]Add [ID] Int Identity(1, 1)
Go
Alter Table [dbo].[Vocations]	ALTER COLUMN [FromDate] [datetime] NULL
Go
Alter Table [dbo].[Vocations]	ALTER COLUMN [ToDate] [datetime] NULL
Go
Alter Table [dbo].[EmployeesData]	ALTER COLUMN DateOfStart [date] NULL
Go
Alter Table [dbo].[EmployeesData]	ALTER COLUMN DateOfEnd [date] NULL
Go
Alter Table [dbo].[EmployeesData]	ALTER COLUMN RequiredDailyHoures nvarchar(50) NULL
Go
Alter Table [dbo].[EmployeesData]	ALTER COLUMN BonusOnDayOff decimal(18, 2)  NULL
	
Go
Alter Table [dbo].[ProcessType]	Add  [ProcessType] int NULL	
Go



ALTER TABLE [dbo].[ProductionEquation] Add [StockCreditWhereHouse] [int] NULL

Go

Update ProductionEquation Set [StockCreditWhereHouse]=1 where [StockCreditWhereHouse] Is Null
Go

  --update Journal set SalesPerson=1 where SalesPerson Is Null
  --update OrdersAppJournal set SalesPerson=1 where SalesPerson Is Null
  --update POSDeletedJournal set SalesPerson=1 where SalesPerson Is Null
  --update POSJournal set SalesPerson=1 where SalesPerson Is Null
  --update JournalTemp set SalesPerson=1 where SalesPerson Is Null
  --update OrdersJournal set SalesPerson=1 where SalesPerson Is Null


CREATE PROCEDURE [dbo].[ProduceItem] @ItemNo int ,@UserID int,@Quantity float,@Unit int,@CostCenter int,@WahreHouse int,@BarCode varchar(50),@PosNo int,@DeviceName as varchar(50),@ItemName As nvarchar(100),@Referance int,@ReferanceName As nvarchar(100) 
AS
DECLARE @EquationID int;
DECLARE @InputDateTime DATETIME;
Declare @DocID int;
Declare @DocDate date;
DECLARE @DocCode as varchar(15);
Declare @ItemEquivalent as decimal (18,5)
SET @DocCode= ( select Right(NEWID(),15));
SET @InputDateTime= (select CONVERT(char(10), GetDate(),126) + ' ' + convert(VARCHAR(8), GETDATE(), 14))
SET @DocDate= (select CONVERT(char(10), GetDate(),126))
Set @DocID=(Select IsNull(Max(DocID),0)+1 from Journal Where DocName=19 )
Set @ItemEquivalent= (Select EquivalentToMain from  [dbo].[Items_units]  where item_id=@ItemNo And unit_id= @Unit )
Insert INTO JournalTemp (
[DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
[DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
[BaseCurrAmount],[BaseAmount],[DocSort],[DocMultiCurrency],[InputUser],
[InputDateTime],[DocNotes],[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],
[StockPrice],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse],[StockBarcode],
[PosNo],[DeviceName],[DocCode],Referance,ReferanceName,ItemName ) 
Select @DocID,@DocDate,19,4,@CostCenter,
'0','4090000000', 1 As [AccountCurr],1 As [DocCurrency],@ItemEquivalent*IsNull(I.LastPurchasePrice,0)*P.RawItemQuantity*IU.EquivalentToMain*@Quantity As [DocAmount],1 As [ExchangePrice],
@ItemEquivalent*IsNull(I.LastPurchasePrice,0)*P.RawItemQuantity*IU.EquivalentToMain*@Quantity As [BaseCurrAmount],@ItemEquivalent*IsNull(I.LastPurchasePrice,0)*P.RawItemQuantity*IU.EquivalentToMain*@Quantity As [BaseAmount],0 As [DocSort],0 As [DocMultiCurrency],@UserID,
@InputDateTime,'Pos Voucher' As [DocNotes],P.RawItemNo,P.RawItemUnit,@Quantity * [RawItemQuantity], IU.EquivalentToMain*@Quantity*[RawItemQuantity] As [StockQuantityByMainUnit],
IsNull(I.LastPurchasePrice,0)*IU.EquivalentToMain As [StockPrice], IsNull(I.LastPurchasePrice,0) As [StockItemPrice],0 As [StockDebitWhereHouse],@WahreHouse As [StockCreditWhereHouse],@BarCode,
@PosNo,@DeviceName,@DocCode,@Referance,@ReferanceName,I.ItemName  
from ProductionEquation P Left Join Items I on I.ItemNo=P.RawItemNo left Join Items_units IU on P.RawItemNo=IU.item_id And P.RawItemUnit=IU.unit_id Where P.ItemNo=@ItemNo

Declare @ItemCost float
Set @ItemCost= ( Select IsNull(Sum(DocAmount),0) from JournalTemp Where DocCode=@DocCode )

Insert INTO JournalTemp ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
[DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
[BaseCurrAmount],[BaseAmount],[DocSort],[DocMultiCurrency],[InputUser],
[InputDateTime],[DocNotes],[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],
[StockPrice],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse],[StockBarcode],
[PosNo],[DeviceName],[DocCode],[ItemName],Referance,ReferanceName ) 
Select Top(1) @DocID,@DocDate,19,4,@CostCenter,
'4090000000','0', 1 As [AccountCurr],1 As [DocCurrency],@ItemCost As [DocAmount],1 As [ExchangePrice],
@ItemCost As [BaseCurrAmount],@ItemCost As [BaseAmount],0 As [DocSort],0 As [DocMultiCurrency],@UserID,
@InputDateTime,'Pos Voucher' As [DocNotes],P.[ItemNo],P.[ItemUnit],@Quantity * ItemQuantity, IU.EquivalentToMain*@Quantity*ItemQuantity As [StockQuantityByMainUnit],
@ItemCost As [StockPrice], @ItemCost As [StockItemPrice],@WahreHouse As [StockDebitWhereHouse],0 As [StockCreditWhereHouse],@BarCode,
@PosNo,@DeviceName,@DocCode,@ItemName,@Referance,@ReferanceName 
from ProductionEquation P Left Join Items I on I.ItemNo=P.ItemNo left Join Items_units IU on P.ItemNo=IU.item_id  And P.ItemUnit=IU.unit_id Where P.ItemNo=@ItemNo

insert Into Journal ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
[DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
[BaseCurrAmount],[BaseAmount],[DocSort],[DocMultiCurrency],[InputUser],
[InputDateTime],[DocNotes],[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],
[StockPrice],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse],[StockBarcode],
[PosNo],[DeviceName],[DocCode],ItemName,Referance,ReferanceName )  Select [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
[DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
[BaseCurrAmount],[BaseAmount],[DocSort],[DocMultiCurrency],[InputUser],
[InputDateTime],[DocNotes],[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],
[StockPrice],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse],[StockBarcode],
[PosNo],[DeviceName],[DocCode],ItemName,Referance,ReferanceName  from JournalTemp 

Delete From JournalTemp Where DocCode=@DocCode 

Update Items Set LastPurchasePrice=@ItemCost,LastPurchaseDate=@DocDate where ItemNo=@ItemNo

return  @DocID;
GO


ALTER TABLE [dbo].AccountingPOSNames ALTER COLUMN [ServerAddress] [varchar](500) NULL
Go

ALTER TABLE [dbo].[AccountingPOSNames] Add  [SamabaPos] bit  NULL
Go
ALTER TABLE [dbo].[AccountingPOSNames] Add  [TempAccounting] varchar(10) NULL
Go


Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosCloseShiftPassword','')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosCloseShiftPassword2','')
Go

ALTER TABLE [dbo].[Journal] Add  [DocID2] [int] NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [DocID2] [int] NULL
Go
ALTER TABLE [dbo].[POSJournal] Add [DocID2] [int] NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [DocID2] [int] NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [DocID2] [int] NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add [DocID2] [int] NULL
Go
ALTER TABLE [dbo].[POSHoldJournal] Add [DocID2] [int] NULL
Go

CREATE TABLE [dbo].[SambaOrdersTemp](
	[MenuItemId] [int] NULL,
	[MenuItemName] [nvarchar](max) NULL,
	[Price] [decimal](16, 2) NULL,
	[Quantity] [decimal](18, 2) NULL,
	[Amount] [float] NULL,
	[Barcode] [nvarchar](max) NULL,
	[UserID] [int] NULL,
	[WorkPeriod] [int] NULL,
	[TicketId] [int] NULL,
	[Id] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



CREATE TABLE [dbo].[SambaReadingLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PeriodID] [int] NULL,
	[PosNo] [int] NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[Amount] [decimal](18, 2) NULL,
	[UserName] [nvarchar](50) NULL,
	[FromTicket] [int] NULL,
	[ToTicket] [nchar](10) NULL,
	[TicketsCount] [int] NULL,
	[OrdersCount] [int] NULL,
	[ReadDateTime] [datetime] NULL,
	[ReadBy] [int] NULL,
	[DocID2] [int] NULL,
 CONSTRAINT [PK_SambaReadingLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[SambaTicketsTemp](
	[Id] [int] NOT NULL,
	[TicketCode] [varchar](50) NULL,
	[TicketNumber] [int] NULL,
	[Date] [datetime] NULL,
	[userid] [int] NULL,
	[WorkPeriod] [int] NULL,
	[TotalAmount] [float] NULL
) ON [PRIMARY]
GO

Go
Update [dbo].[Vocations]  set VocationSource='' where VocationSource is null
Go

ALTER TABLE [dbo].[PosShifts] Add  [DeletedItemsCount] [int] NULL

ALTER TABLE [dbo].[PosShifts] Add  [DeletedItemsAmount] [decimal](18, 2) NULL

ALTER TABLE [dbo].[PosShifts] Add  [DiscountAmountForCash] [decimal](18, 2) NULL
Go
ALTER TABLE [dbo].[PosShifts] Add  [DiscountAmountForCards] [decimal](18, 2) NULL
Go
ALTER TABLE [dbo].[PosShifts] Add  [DiscountAmountForCSTMR] [decimal](18, 2) NULL
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosVoucherQueryLimit',10)
Go

ALTER PROCEDURE [dbo].[PosGetAndDeleteDeletedItems]  
    @JournalID INT = 0
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DeletedCount INT;

    -- نقل السجل لجدول الحذف
    INSERT INTO [POSDeletedJournal] (
        [DebitAcc],[CredAcc],[DocAmount],[InputDateTime],
        [StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],[StockPrice],
        [StockDiscount],[DeleteUser],[DocCode],[ItemName],[ShiftID],[StockBarcode],[DeleteDateTime],PosNo
    )
    SELECT 
        [DebitAcc],[CredAcc],[DocAmount],[InputDateTime],
        [StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],[StockPrice],
        [StockDiscount],[InputUser],[DocCode],[ItemName],[ShiftID],[StockBarcode],GETDATE(),PosNo
    FROM [dbo].[POSJournal]
    WHERE ID = @JournalID;

    -- الحذف من جدول POSJournal
    DELETE FROM [dbo].[POSJournal]
    WHERE ID = @JournalID;

    SET @DeletedCount = @@ROWCOUNT;

    -- إعادة عدد الصفوف المحذوفة
    RETURN @DeletedCount;
END

Go 

CREATE TABLE [dbo].[JournalBeforeUpdate](
	[ID] [int] NOT NULL,
	[DocID] [int] NULL,
	[DocDate] [date] NULL,
	[DocName] [int] NULL,
	[DocStatus] [int] NULL,
	[DocCostCenter] [int] NULL,
	[DebitAcc] [varchar](10) NULL,
	[CredAcc] [varchar](10) NULL,
	[AccountCurr] [int] NULL,
	[DocCurrency] [int] NULL,
	[DocAmount] [float] NULL,
	[ExchangePrice] [float] NULL,
	[BaseCurrAmount] [float] NULL,
	[BaseAmount] [float] NULL,
	[DocSort] [int] NULL,
	[Referance] [nvarchar](20) NULL,
	[DocManualNo] [nvarchar](50) NULL,
	[DocMultiCurrency] [bit] NULL,
	[InputUser] [int] NULL,
	[InputDateTime] [datetime] NULL,
	[ModifiedUser] [int] NULL,
	[ModifiedDateTime] [datetime] NULL,
	[DocAuditDate] [datetime] NULL,
	[DocAuditUser] [int] NULL,
	[DocNotes] [nvarchar](1024) NULL,
	[StockID] [int] NULL,
	[StockUnit] [int] NULL,
	[StockQuantity] [float] NULL,
	[StockQuantityByMainUnit] [float] NULL,
	[StockPrice] [float] NULL,
	[StockItemPrice] [float] NULL,
	[StockDebitWhereHouse] [int] NULL,
	[StockCreditWhereHouse] [int] NULL,
	[StockDriver] [nvarchar](50) NULL,
	[StockCarNo] [int] NULL,
	[SalesPerson] [int] NULL,
	[CheckNo] [int] NULL,
	[CheckInOut] [nvarchar](5) NULL,
	[CheckStatus] [int] NULL,
	[CheckDueDate] [date] NULL,
	[CheckCustBank] [varchar](20) NULL,
	[CheckCustBranch] [varchar](20) NULL,
	[CheckCustAccountId] [varchar](20) NULL,
	[AccountBank] [int] NULL,
	[DeleteUser] [int] NULL,
	[DeleteDateTime] [datetime] NULL,
	[CurrentUserID] [int] NULL,
	[ReferanceName] [nvarchar](100) NULL,
	[DocCode] [varchar](50) NULL,
	[CheckCode] [varchar](15) NULL,
	[ItemName] [nvarchar](100) NULL,
	[DocCheckTransID] [int] NULL,
	[TransNoInJournal] [int] NULL,
	[ShiftID] [int] NULL,
	[DocNoteByAccount] [nvarchar](1024) NULL,
	[StockDiscount] [float] NULL,
	[StockBarcode] [varchar](50) NULL,
	[PosNo] [int] NULL,
	[DeviceName] [nvarchar](70) NULL,
	[OrderStatus] [int] NULL,
	[ItemStatus] [int] NULL,
	[ApprovedQuantity] [decimal](18, 2) NULL,
	[DeliverDate] [datetime] NULL,
	[LastDocCode] [varchar](50) NULL,
	[LastDataName] [varchar](30) NULL,
	[Color] [int] NULL,
	[Measure] [int] NULL,
	[VoucherDiscount] [float] NULL,
	[ItemVAT] [float] NULL,
	[StockDebitShelve] [int] NULL,
	[StockCreditShelve] [int] NULL,
	[ItemNo2] [varchar](50) NULL,
	[OrderID] [int] NULL,
	[Produced] [bit] NULL,
	[DocID2] [int] NULL,
 CONSTRAINT [PK_JournalBeforeUpdate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[JournalBeforeUpdate] ADD  CONSTRAINT [DF_JournalBeforeUpdate_DocStatus]  DEFAULT ((1)) FOR [DocStatus]
GO

ALTER TABLE [dbo].[JournalBeforeUpdate] ADD  CONSTRAINT [DF_JournalBeforeUpdate_DocCostCenter]  DEFAULT ((1)) FOR [DocCostCenter]
GO

ALTER TABLE [dbo].[JournalBeforeUpdate] ADD  CONSTRAINT [DF_JournalBeforeUpdate_DocSort]  DEFAULT ((0)) FOR [DocSort]
GO

ALTER TABLE [dbo].[JournalBeforeUpdate] ADD  CONSTRAINT [DF_JournalBeforeUpdate_Referance]  DEFAULT ((0)) FOR [Referance]
GO

ALTER TABLE [dbo].[JournalBeforeUpdate] ADD  CONSTRAINT [DF_JournalBeforeUpdate_DocManualNo]  DEFAULT ((0)) FOR [DocManualNo]
GO

ALTER TABLE [dbo].[JournalBeforeUpdate] ADD  CONSTRAINT [DF_JournalBeforeUpdate_DocMultiCurrency]  DEFAULT ((0)) FOR [DocMultiCurrency]
GO

INSERT [dbo].[DocStatus] ([ID], [DocStatus]) VALUES (-2, N'من الارشيف')
GO

ALTER TABLE [dbo].[EmployeesData] Add  [EmployeeType] [int]
Go


CREATE TABLE [dbo].[EmployeesTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeesType] [nvarchar](50) NULL,
 CONSTRAINT [PK_EmployeesTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[AccountingPOSNames] Add  [ItemsGroups] [varchar](50) NULL
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosAllowChangeItemPrice','False')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosMaxDiscount','100')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('AlertWhenItemQuantityLessThanBalanceInVouchers','False')
Go


ALTER PROCEDURE [dbo].[ProduceItem] @ItemNo int ,@UserID int,@Quantity float,@Unit int,@CostCenter int,
									@WahreHouse int,@BarCode varchar(50),@PosNo int,@DeviceName as varchar(50),
									@ItemName As nvarchar(100),@Referance int,@ReferanceName As nvarchar(100),
									@DocNote as nvarchar(1000),@LastDocCode as varchar(50),@DocID2 as int,@DocDate as Date
AS
DECLARE @EquationID int;
DECLARE @InputDateTime DATETIME;
Declare @DocID int;
DECLARE @DocCode as varchar(15);
Declare @ItemEquivalent as decimal (18,5)
SET @DocCode= ( select Right(NEWID(),15));
SET @InputDateTime= (select CONVERT(char(10), GetDate(),126) + ' ' + convert(VARCHAR(8), GETDATE(), 14))
--SET @DocDate= (select CONVERT(char(10), GetDate(),126))
Set @DocID=(Select IsNull(Max(DocID),0)+1 from Journal Where DocName=19 )
Set @ItemEquivalent= (Select EquivalentToMain from  [dbo].[Items_units]  where item_id=@ItemNo And unit_id= @Unit )
Insert INTO JournalTemp (
[DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
[DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
[BaseCurrAmount],[BaseAmount],[DocSort],[DocMultiCurrency],[InputUser],
[InputDateTime],[DocNotes],[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],
[StockPrice],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse],[StockBarcode],
[PosNo],[DeviceName],[DocCode],Referance,ReferanceName,ItemName,LastDocCode,DocID2 ) 
Select @DocID,@DocDate,19,4,@CostCenter,
'0','4090000000', 1 As [AccountCurr],1 As [DocCurrency],IsNull(@ItemEquivalent,1)*IsNull(I.LastPurchasePrice,0)*P.RawItemQuantity*IU.EquivalentToMain*@Quantity As [DocAmount],1 As [ExchangePrice],
IsNull(@ItemEquivalent,1)*IsNull(I.LastPurchasePrice,0)*P.RawItemQuantity*IU.EquivalentToMain*@Quantity As [BaseCurrAmount],IsNull(@ItemEquivalent,1)*IsNull(I.LastPurchasePrice,0)*P.RawItemQuantity*IU.EquivalentToMain*@Quantity As [BaseAmount],0 As [DocSort],0 As [DocMultiCurrency],@UserID,
@InputDateTime,@DocNote As [DocNotes],P.RawItemNo,P.RawItemUnit,@Quantity * [RawItemQuantity], IU.EquivalentToMain*@Quantity*[RawItemQuantity] As [StockQuantityByMainUnit],
IsNull(I.LastPurchasePrice,0)*IU.EquivalentToMain As [StockPrice], IsNull(I.LastPurchasePrice,0) As [StockItemPrice],0 As [StockDebitWhereHouse],@WahreHouse As [StockCreditWhereHouse],@BarCode,
@PosNo,@DeviceName,@DocCode,@Referance,@ReferanceName,I.ItemName,@LastDocCode,@DocID2  
from ProductionEquation P Left Join Items I on I.ItemNo=P.RawItemNo left Join Items_units IU on P.RawItemNo=IU.item_id And P.RawItemUnit=IU.unit_id Where P.ItemNo=@ItemNo

Declare @ItemCost float
Set @ItemCost= ( Select IsNull(Sum(DocAmount),0) from JournalTemp Where DocCode=@DocCode ) 

Insert INTO JournalTemp ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
[DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
[BaseCurrAmount],[BaseAmount],[DocSort],[DocMultiCurrency],[InputUser],
[InputDateTime],[DocNotes],[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],
[StockPrice],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse],[StockBarcode],
[PosNo],[DeviceName],[DocCode],[ItemName],Referance,ReferanceName,LastDocCode,DocID2 ) 
Select Top(1) @DocID,@DocDate,19,4,@CostCenter,
'4090000000','0', 1 As [AccountCurr],1 As [DocCurrency],@ItemCost As [DocAmount],1 As [ExchangePrice],
@ItemCost As [BaseCurrAmount],@ItemCost As [BaseAmount],0 As [DocSort],0 As [DocMultiCurrency],@UserID,
@InputDateTime,@DocNote As [DocNotes],P.[ItemNo],P.[ItemUnit],@Quantity * ItemQuantity, IU.EquivalentToMain*@Quantity*ItemQuantity As [StockQuantityByMainUnit],
@ItemCost As [StockPrice], @ItemCost As [StockItemPrice],@WahreHouse As [StockDebitWhereHouse],0 As [StockCreditWhereHouse],@BarCode,
@PosNo,@DeviceName,@DocCode,@ItemName,@Referance,@ReferanceName,@LastDocCode,@DocID2 
from ProductionEquation P Left Join Items I on I.ItemNo=P.ItemNo left Join Items_units IU on P.ItemNo=IU.item_id  And P.ItemUnit=IU.unit_id Where P.ItemNo=@ItemNo

insert Into Journal ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
[DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
[BaseCurrAmount],[BaseAmount],[DocSort],[DocMultiCurrency],[InputUser],
[InputDateTime],[DocNotes],[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],
[StockPrice],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse],[StockBarcode],
[PosNo],[DeviceName],[DocCode],ItemName,Referance,ReferanceName,LastDocCode,LastDataName,DocID2 )  Select [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
[DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
[BaseCurrAmount],[BaseAmount],[DocSort],[DocMultiCurrency],[InputUser],
[InputDateTime],[DocNotes],[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],
[StockPrice],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse],[StockBarcode],
[PosNo],[DeviceName],[DocCode],ItemName,Referance,ReferanceName,LastDocCode,'Journal',DocID2  from JournalTemp 

Delete From JournalTemp Where DocCode=@DocCode 

Update Items Set LastPurchasePrice=@ItemCost/ @Quantity,LastPurchaseDate=@DocDate where ItemNo=@ItemNo


return  @DocID;
GO


GO



Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('AttAllowEditAttTrans','True')
Go


CREATE PROCEDURE [dbo].[SambaAdjustment] @USERID int, @PosNo int,@WorkPeriod int,@StartDate varchar(20),@EndDate varchar(20)
AS
  Declare @TicketAmount as float;
  Declare @OrderAmount as float;
  Declare @VoucherNo int;
  Declare @DocDate date;
  Declare @CostCenter int;
  Declare @DefaultCurr int;
  Declare @DocNote nvarchar(Max);
  Declare @DocCode varchar(15);
  Declare @StockCreditWhereHouse int;
  Declare @DiscountRatio decimal(18, 4);
  Declare @TempAccount varchar(10);
  Declare @DocManualNo nvarchar(50) ;
  Declare @TicketCode varchar(50);
  Declare @Temp1 varchar(10);
  Declare @Temp2 varchar(10);
  Declare @Produce bit;
  Declare @TicketsCount int;
  Declare @TicketsAmount int;
  Declare @TicketIdFrom int;
  Declare @TicketIdTo int;
  Declare @OrdersCount int;
  Declare @VouchersInJournalAmount float;
  Declare @InputDateTime as datetime;
  Declare @_DocID2 int;
  Set @Temp1=( select Right(NEWID(),5))
  Set @CostCenter=( Select CostCenter from AccountingPOSNames Where ID=@PosNo  );
  Set @StockCreditWhereHouse=( Select Warehouse from AccountingPOSNames Where ID=@PosNo  );
  Set @InputDateTime=GETDATE()

  select Id as TicketID,TotalAmount As TicketAmount,IsNull(OrderAmount,0) As OrderAmount,IsNull((OrderAmount-TotalAmount),0) As Diff, Case when OrderAmount = 0 then 1 else (OrderAmount-TotalAmount)/OrderAmount end As DiscountRatio
  Into   #@Temp1 from 
  (select Id,TotalAmount from [SambaTicketsTemp]) A left Join 
  (select O.[TicketId],sum([Amount]) As OrderAmount  from [SambaOrdersTemp] O  group by [TicketId]) B
  on A.Id=B.TicketId where TotalAmount>0;

  Set @TicketIdFrom =( Select Min(TicketID) from #@Temp1 );
  Set @TicketIdTo =( Select Max(TicketID) from #@Temp1 );
  Set @TicketsAmount =( Select Sum(TicketAmount) from #@Temp1 );
  Set @TicketsCount =( Select Count(TicketID) from #@Temp1 );
  Set @OrdersCount=( Select Count(OrderAmount) From #@Temp1 )
  Set @_DocID2=cast(CONVERT(varchar(20),@InputDateTime,112) as INT )+@PosNo+@WorkPeriod ;
  Insert into [SambaReadingLog] ([PeriodID],[PosNo],[FromDate],[ToDate],[Amount],[UserName],[FromTicket],[ToTicket],[TicketsCount],[OrdersCount],[ReadDateTime],[ReadBy],DocID2) 
		  Values (@WorkPeriod,@PosNo,@StartDate,@EndDate,@TicketsAmount,@USERID,@TicketIdFrom,@TicketIdTo,@TicketsCount,@OrdersCount,@InputDateTime,@USERID,@_DocID2)


  Declare @TicketID int;
  While (Select Count(*) From #@Temp1) > 0
  Begin
  Select Top 1 @TicketID = TicketID From #@Temp1 

  set @TicketAmount=( select TicketAmount from #@Temp1 where TicketID= @TicketID );
  set @OrderAmount=( select OrderAmount from #@Temp1 where TicketId= @TicketID );
  Set @VoucherNo = ( Select IsNull(Max(DocID)+1,0)  from Journal where DocName=2 );
  Set @DocDate=(Select [Date] from [SambaTicketsTemp] where Id= @TicketID  );
  Set @DefaultCurr=( Select CurrID  from Currency where IsDefault=1  );
  Set @DocNote= CONCAT('Samba Voucher From (PosNo:' , @PosNo , ' WorkPeriod No:' , @WorkPeriod ,' User:' , @USERID,' TicketID:' ,@TicketID,')')  ;
  SET @DocCode= ( select Right(NEWID(),15));
  Set @DiscountRatio=(Select DiscountRatio from  #@Temp1 where TicketID=@TicketID )
  Set @TempAccount=(Select TempAccounting from AccountingPOSNames where Id=@PosNo)
  Set @DocManualNo= @TicketID 
  Set @TicketCode=(Select LEFT([TicketCode],50) TicketCode from SambaTicketsTemp where Id=@TicketID);

insert into Journal
       ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                       StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,
                                       CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,PosNo,DocNoteByAccount,VoucherDiscount,StockDiscount,LastDocCode,LastDataName,DocID2  ) 
                                       Select @VoucherNo,CAST(@DocDate AS DATE) ,2,1,@CostCenter,
                                       '0',I.AccSales,1,
                                       @DefaultCurr,O.Amount-O.Amount*@DiscountRatio,1,O.Amount-O.Amount*@DiscountRatio,O.Amount-O.Amount*@DiscountRatio,@DocManualNo,@DocNote,
                                       @USERID,@InputDateTime,O.Barcode,IU.unit_id,O.Quantity,IU.EquivalentToMain,
                                        O.Price,O.Price,0,@StockCreditWhereHouse,@USERID,
                                         0,N'',ItemName,@WorkPeriod,@DocCode,@PosNo,'',O.Amount * @DiscountRatio,0 ,@TicketCode,'Samba',@_DocID2
                                       from [dbo].SambaOrdersTemp O
									   left Join Items I on O.Barcode=I.ItemNo
									   Left Join Items_units IU on IU.item_id=O.Barcode And IU.main_unit=1
									   where O.TicketId=@TicketID


insert into Journal
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,ShiftID,CurrentUserID,DocCode,PosNo,LastDocCode,LastDataName,DocID2  ) VALUES(
                                       @VoucherNo,CAST(@DocDate AS DATE) ,2,1,@CostCenter ,@TempAccount,
                                        '0',@DefaultCurr,1,@TicketAmount,1,@TicketAmount,
                                       @TicketAmount,@DocManualNo,@DocNote,@USERID,@InputDateTime,
                                        0,N'',@WorkPeriod,@USERID,
                                        @DocCode,@PosNo,@TicketCode,'Samba',@_DocID2)



Set @Temp2=( select Right(NEWID(),5))
Select T.Id,Barcode,MenuItemName,Quantity,I.HasProductionEquation  Into #@Temp2 from SambaOrdersTemp T left join items I on I.ItemNo=T.Barcode where HasProductionEquation=1
Declare @Barcode varchar(100)
Declare @OrderID int;
While (Select Count(*) From #@Temp2) > 0
Begin
	Select Top 1 @OrderID = Id From #@Temp2 
	Declare @RowQuantity float;
	Declare @Unit int;
	Declare @RowItemName nvarchar(100);
	set @Barcode= (Select Barcode from #@Temp2 where id=@OrderID)
	Set @RowQuantity=( Select Quantity from #@Temp2 where id=@OrderID );
	Set @Unit=( Select unit_id from Items_units where item_id=@Barcode and main_unit=1 )
	Set @RowItemName=( select MenuItemName from #@Temp2 where id=@OrderID )
	EXEC  [dbo].[ProduceItem] @ItemNo=@Barcode,@UserID=1,@Quantity=@RowQuantity,@Unit=@Unit,@CostCenter=1,@WahreHouse=1,@BarCode=0,@PosNo=1,@DeviceName='Auto',@ItemName=@RowItemName,@Referance=0,@ReferanceName='',@DocNote='',@LastDocCode=@DocCode,@DocID2=@_DocID2;
	Delete from #@Temp2 Where Id = @OrderID
End
Drop Table #@Temp2

Delete from #@Temp1 Where TicketID = @TicketID
End

Drop Table #@Temp1



Set @VouchersInJournalAmount=( select sum(DocAmount) from Journal where PosNo=@PosNo And ShiftID=@WorkPeriod And InputDateTime=@InputDateTime  )
return  @VouchersInJournalAmount
GO

ALTER TABLE [AttRawatebArchive] Add   [ProcessType] int  NULL
Go
ALTER TABLE [SambaOrdersTemp] Add   [TicketNumber] int  NULL
Go
Alter Table [dbo].[SambaReadingLog]	ALTER COLUMN ToTicket int NULL
go


CREATE TABLE [dbo].[PosShiftsByUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ShiftID] [int] NOT NULL,
	[CashAmount] [decimal](18, 0) NOT NULL,
	[UserID] [int] NOT NULL,
	[UserName] [nvarchar](100) NULL,
 CONSTRAINT [PK_ShiftsByUsers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosAllowMinusQuantityIvVoucher','True')
Go
Alter  table [ItemsSerials] add CurrentWahreHouse int null
Go
Alter table [ItemsSerials] Add  Vendor int null
Go
Alter table [ItemsSerials] Add  Customer int null
Go
Alter table [ItemsSerialTrans] Add  ReferanceNo int null
Go


ALTER TABLE [dbo].[AttPlaneForPeriod] ADD  CONSTRAINT [DF_AttPlaneForPeriod_TransDate]  DEFAULT (getdate()) FOR [TransDate]
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('AttShowAdditionsInSalarySlip','True')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('AttShowPaymentsInSalarySlip','True')
Go

ALTER TABLE [dbo].[CompanyData] Add   [HeaderImage] image  NULL
Go
ALTER TABLE [dbo].[CompanyData] Add   [FooterImage] image  NULL
Go

Update [dbo].[ItemsSerials]
Set CurrentWahreHouse=1 where SerialStatus=1 aND CurrentWahreHouse iS nULL
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('ReportStatmentBottom','100')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('ReportStatmentLeft','20')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('ReportStatmentRight','20')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('ReportStatmentTop','150')
Go

ALTER TABLE [dbo].[Appointments] Add   [Amount] decimal(18, 4)  NULL
Go
ALTER TABLE [dbo].[Appointments] Add   [AmountPaid] decimal(18, 4)  NULL
Go



Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('ShowDiscountColumnInVoucher','True')
Go

ALTER TABLE [dbo].[Journal] Add  [DocDueDate] [datetime] NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [DocDueDate] [datetime] NULL
Go
ALTER TABLE [dbo].[POSJournal] Add [DocDueDate] [datetime] NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [DocDueDate] [datetime] NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [DocDueDate] [datetime] NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add [DocDueDate] [datetime] NULL
Go
ALTER TABLE [dbo].[POSHoldJournal] Add [DocDueDate] [datetime] NULL
Go


ALTER TABLE [dbo].[Items] Add [Active] [Bit] NULL
Go

ALTER TABLE [dbo].[EmployeesData] Add [MaxBonusHoures] varchar(10) NULL
Go


Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosPrintReferanceBalance','False')
Go



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle Maintenance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CarID] [int] NOT NULL,
	[DocDate] [date] NOT NULL,
	[RefNo] [int] NULL,
	[Notes] [nvarchar](max) NULL,
	[OdometerCurrent] [int] NULL,
	[OdometerNext] [int] NULL,
	[Driver] [int] NULL,
	[Cost] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Vehicle Maintenance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 26/06/2022 10:17:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[CarID] [int] IDENTITY(1,1) NOT NULL,
	[CARNO] [nvarchar](50) NOT NULL,
	[ChassiNoCar] [nvarchar](50) NULL,
	[CarType] [int] NULL,
	[CarModel] [int] NULL,
	[YearCar] [int] NULL,
	[ColorCar] [nvarchar](10) NULL,
	[FuelsCar] [nvarchar](10) NULL,
	[ReferanceID] [int] NULL,
	[DatePurchase] [date] NULL,
	[CostCar] [int] NULL,
	[Vender] [nvarchar](50) NULL,
	[DateSale] [date] NULL,
	[SaleCar] [int] NULL,
	[Customer] [nvarchar](50) NULL,
	[CarImage] [image] NULL,
	[SortCar] [nvarchar](20) NULL,
	[Active] [bit] NOT NULL,
	[BegSpedometaer] [nvarchar](50) NULL,
	[CarDetails] [nvarchar](100) NULL,
	[Available] [bit] NOT NULL,
	[MaintenanceAccountNo] [varchar](10) NULL,
	[AssetsAccountNo] [varchar](10) NULL,
	[RelatedService] [varchar](10) NULL,
	[CarCostCenter] [int] NULL,
	[OwnByReferance] [int] NULL,
	[Engine] [nvarchar](20) NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[CARNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Vehicle Maintenance] ADD  CONSTRAINT [DF_Vehicle Maintenance_Cost]  DEFAULT ((0)) FOR [Cost]
GO
ALTER TABLE [dbo].[Vehicles] ADD  CONSTRAINT [DF_Vehicle_active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Vehicles] ADD  CONSTRAINT [DF_Vehicles_Available]  DEFAULT ((0)) FOR [Available]
GO



CREATE TABLE [dbo].[CarsAccidant](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CarID] [int] NULL,
	[AccidantDate] [date] NULL,
	[DriverID] [int] NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_CarsAccidant] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('SmsSuccessString','Message Sent Successfully!')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('SmsZeroBalanceString','10005@No Balance')
Go

ALTER TABLE [dbo].[EmployeesData] Add [MonthlyHouresRequired] varchar(10) NULL
Go
ALTER TABLE [dbo].[AttRawatebArchive] Add [MonthlyHouresRequired] varchar(10) NULL
Go

ALTER TABLE [dbo].[EmployeesData] Add [CalcBonusAfterMinitues] int NULL
Go
ALTER TABLE [dbo].[EmployeesData] Add [BonusPerHourAferPeriod1] decimal(18, 2) NULL
Go


Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosAllowChangeDeleteItemInVoucher','True')
Go


CREATE TABLE [dbo].[MeatMootImportInvoices](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocDateTime] [datetime] NULL,
	[DocNo] [int] NULL,
	[StockBarcode] [varchar](50) NULL,
	[ItemName] [nvarchar](100) NULL,
	[Quantity] [float] NULL,
	[Price] [float] NULL,
	[DocAmount] [float] NULL,
	[DocCode]  AS (((CONVERT([varchar],[DocDateTime],(112))+'')+CONVERT([varchar],[DocDateTime],(8)))+str([Quantity],(5),(3))),
	[IsExist] [bit] NULL,
	[ImportResult] [nvarchar](50) NULL,
 CONSTRAINT [PK_ImportInvoicesMeatMoot] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[MeatMootReadingLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PeriodID] [int] NULL,
	[PosNo] [int] NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[Amount] [decimal](18, 2) NULL,
	[UserName] [nvarchar](50) NULL,
	[VouchersCount] [int] NULL,
	[ReadDateTime] [datetime] NULL,
	[ReadBy] [int] NULL,
	[DocID2] [int] NULL,
 CONSTRAINT [PK_MeatMootReadingLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('ShowWorkLeavesData','False')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('AttNoteRequiredforAttTrans','False')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosUseScales','False')
Go




Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosShowRadialMenu','False')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosPostVouchers','True')
Go

ALTER TABLE [dbo].[EmployeesData] ALTER COLUMN [JobName] nvarchar(50) NULL
Go
ALTER TABLE [dbo].[EmployeesData] ALTER COLUMN [Branch] nvarchar(50) NULL
Go
ALTER TABLE [dbo].[EmployeesData] ALTER COLUMN [Department] nvarchar(50) NULL
Go





Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('ShowSummeryInDocumentList','True')
Go

ALTER TABLE [dbo].[VacationsBalancesAdding] Add [Notes] nvarchar(Max) NULL
Go


update [dbo].[Vocations]  set VocationSource='vocation' where VocationSource='' or VocationSource is null
Go

ALTER TABLE [dbo].[Vocations] ALTER COLUMN [NoteDetails] nvarchar(Max) NULL
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosNumberOfCopies',1)
Go

ALTER TABLE [dbo].[Warehouses] Add [DefaultShelf] int NULL
Go

Update [dbo].[Items] set [Active]=1 where [Active] is null
Go

ALTER TABLE [dbo].[PosShifts] Add [VoucherCounter] int NULL
Go

ALTER TABLE [dbo].[PosVouchers] Add [VoucherCounter] int NULL
Go

ALTER TABLE [dbo].[Journal] Add [VoucherCounter] int NULL
Go

ALTER TABLE [dbo].[POSHoldJournal] Add [VoucherCounter] int NULL
Go



Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosUseVoucherCounterInsteadVoucherNo','True')
Go

ALTER TABLE [dbo].[EmployeesData] Add [ManagerID] int NULL
Go

ALTER TABLE [dbo].[Journal] Add [AuditNote] nvarchar(100) NULL
Go

ALTER TABLE [dbo].[PosVouchers] Add  [PaidAmount] [float] NULL 
Go
ALTER TABLE [dbo].[PosVouchers] Add  [ReturnAmount] [float] NULL 
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('SendSmsFromDocuments','True')
Go
Alter TABLE [dbo].[ArchiveDocs]  Add  [EmployeeID] [int] NULL 
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('Archive_SaveDataInSqlOrFolder','Sql')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('Archive_FolderPath','C:\Archive')
Go
CREATE TABLE [dbo].[SmsPendingMessages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SMSType] [nvarchar](50) NULL,
	[SMSDetails] [nvarchar](500) NULL,
	[SMSDatetime] [datetime] NULL,
	[SMSUser] [int] NULL,
	[SMSStatus] [nvarchar](100) NULL,
	[BulkNo] [int] NULL,
	[RefNo] [int] NULL,
	[RefMobile] [nvarchar](50) NULL,
	[RefName] [nvarchar](100) NULL,
	[AccrualDateTime] [datetime] NULL,
	[Sent] [bit] NULL,
	[DocName] [int] NULL,
	[DocID] [int] NULL,
	[DocCode] [varchar](50) NULL,
	[DocData] [nvarchar](50) NULL,
 CONSTRAINT [PK_SmsPendingMessages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[SmsSentMessages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SMSType] [nvarchar](50) NULL,
	[SMSDetails] [nvarchar](500) NULL,
	[SMSDatetime] [datetime] NULL,
	[SMSUser] [int] NULL,
	[SMSStatus] [nvarchar](100) NULL,
	[BulkNo] [int] NULL,
	[RefNo] [int] NULL,
	[RefMobile] [nvarchar](50) NULL,
	[RefName] [nvarchar](100) NULL,
	[AccrualDateTime] [datetime] NULL,
	[Sent] [bit] NULL,
	[DocName] [int] NULL,
	[DocID] [int] NULL,
	[DocCode] [varchar](50) NULL,
	[DocData] [nvarchar](50) NULL,
 CONSTRAINT [PK_SmsSentMessages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('SMSAPI', '')
Go
ALTER TABLE [dbo].[ArchiveDocs] Add [ArchiveType] nvarchar(20) NULL
Go

ALTER TABLE [dbo].[AttPaymentsTypes] Add [DefaultAmount] decimal(18, 2) NULL
Go
ALTER TABLE [dbo].[AttPaymentsTypes] Add [Recurrence] BIT NULL
Go
ALTER TABLE [dbo].[AttPaymentsTypes] Add [Taxable] BIT NULL
Go
Update [dbo].[AttPaymentsTypes] set [DefaultAmount]=0 where [DefaultAmount] is null;
Update [dbo].[AttPaymentsTypes] set [Recurrence]=0 where [Recurrence] is null;
Update [dbo].[AttPaymentsTypes] set [Taxable]=1 where [Taxable] is null
Go
ALTER TABLE dbo.[AttPaymentsTypes]   ADD ID INT IDENTITY
Go
ALTER TABLE [dbo].[AttPaymentsTypes] ADD  CONSTRAINT [DF_AttPaymentsTypes_DefaultAmount]  DEFAULT ((0)) FOR [DefaultAmount]
GO
ALTER TABLE [dbo].[AttPaymentsTypes] ADD  CONSTRAINT [DF_AttPaymentsTypes_Recurrence]  DEFAULT ((0)) FOR [Recurrence]
GO
ALTER TABLE [dbo].[AttPaymentsTypes] ADD  CONSTRAINT [DF_AttPaymentsTypes_Taxable]  DEFAULT ((0)) FOR [Taxable]
GO


ALTER TABLE [dbo].[AttAdditionsTypes] Add [DefaultAmount] decimal(18, 2) NULL
Go
ALTER TABLE [dbo].[AttAdditionsTypes] Add [Recurrence] BIT NULL
Go
ALTER TABLE [dbo].[AttAdditionsTypes] Add [Taxable] BIT NULL
Go
Update [dbo].[AttAdditionsTypes] set [DefaultAmount]=0 where [DefaultAmount] is null;
Update [dbo].[AttAdditionsTypes] set [Recurrence]=0 where [Recurrence] is null;
Update [dbo].[AttAdditionsTypes] set [Taxable]=1 where [Taxable] is null
Go
ALTER TABLE dbo.[AttAdditionsTypes]   ADD ID INT IDENTITY
Go
ALTER TABLE [dbo].[AttAdditionsTypes] ADD  CONSTRAINT [DF_AttAdditionsTypes_DefaultAmount]  DEFAULT ((0)) FOR [DefaultAmount]
GO
ALTER TABLE [dbo].[AttAdditionsTypes] ADD  CONSTRAINT [DF_AttAdditionsTypes_Recurrence]  DEFAULT ((0)) FOR [Recurrence]
GO
ALTER TABLE [dbo].[AttAdditionsTypes] ADD  CONSTRAINT [DF_AttAdditionsTypes_Taxable]  DEFAULT ((0)) FOR [Taxable]
GO

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('AllowCampaginsOnPOS','False',N'تفعيل الحملات في نقطة البيع');
Go


CREATE PROCEDURE [dbo].[ApplyCampagins]  @Barcode varchar(50)
AS
SET NOCOUNT ON;
if @Barcode='0' begin return end
  Declare @AllowCampaginsOnPOS int;
  Set @AllowCampaginsOnPOS = (Select  SettingValue from Settings where SettingName='AllowCampaginsOnPOS'  ) ;
  IF @AllowCampaginsOnPOS=1
  BEGIN;
      Declare @ItemNo int;
	  Set @ItemNo = ( select item_id  from Items_units where item_unit_bar_code=@Barcode   );
	IF EXISTS (Select C.ID,C.CampaginName  from [dbo].[Campagins] C
				      left join [CampaginByItemsCount] CI on C.ID=CI.CampaginID
					  where C.Active=1 and (getdate() between C.FromDate and C.ToDate) and  CI.ItemNo=@ItemNo)
	BEGIN
	    
        Declare @ItemUnit int;
	    Set @ItemUnit = ( select unit_id from Items_units where item_unit_bar_code=@Barcode and IsUnit=1  );

		Declare @POSQuantity DECIMAL  (18,2);
		Declare @TargetQuantity DECIMAL  (18,2);
		Declare @NewPrice float ;
		Declare @OldPrice float;
		Set @POSQuantity = (Select Sum(StockQuantity) From POSJournal );
		Set @TargetQuantity = (Select Quantity From [CampaginByItemsCount] C where ItemNo=@ItemNo );
		Set @NewPrice = (Select (Amount /  Quantity) From [CampaginByItemsCount]  where ItemNo=@ItemNo );
		Set @OldPrice= ( select Price1  from Items_units where item_id= @ItemNo and unit_id=@ItemUnit and IsUnit = 1 );
			If @POSQuantity > = @TargetQuantity and @POSQuantity > 0
				Begin
					Update [POSJournal] Set StockPrice=@NewPrice,DocAmount=@NewPrice*StockQuantity where StockID=@ItemNo;
				End
				ELSE
				BEGIN
					Update [POSJournal] Set StockPrice=@OldPrice,DocAmount=@OldPrice*StockQuantity where StockID=@ItemNo;
			END
	END
 END
GO

DROP TRIGGER  IF EXISTS  [POSCompainsTrigger] ;

Go






CREATE TABLE [dbo].[AttRecurrenceAdditions](
	[TransID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[AdditionType] [int] NULL,
	[AdditionAmount] [decimal](18, 2) NULL,
	[DateFrom] [date] NULL,
	[DateTo] [date] NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_AttRecurrenceAdditions] PRIMARY KEY CLUSTERED 
(
	[TransID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO




CREATE TABLE [dbo].[AttRecurrenceDeductions](
	[TransID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[DeductionType] [int] NULL,
	[DeductionAmount] [decimal](18, 2) NULL,
	[DateFrom] [date] NULL,
	[DateTo] [date] NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_AttRecurrenceDeductions] PRIMARY KEY CLUSTERED 
(
	[TransID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosMobileNoToSendCloseShiftSMS','')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PosSendSMSMobileWhenClosePosShift','False')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('OrpakReadCSTMRTrans','0')
Go

Alter TABLE [dbo].[AccountingPOSNames]  Add  [PosType] [int] NULL 
Go

CREATE TABLE [dbo].[AccountingPosTypes](
	[ID] [int] NOT NULL,
	[PosType] [nvarchar](50) NULL,
 CONSTRAINT [PK_AccountingPosTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AccountingPosTypes] ([ID], [PosType]) VALUES (1, N'tts')
GO
INSERT [dbo].[AccountingPosTypes] ([ID], [PosType]) VALUES (2, N'Samba')
GO
INSERT [dbo].[AccountingPosTypes] ([ID], [PosType]) VALUES (3, N'Orpak')
GO



CREATE TABLE [dbo].[OrpakReadingLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PeriodID] [int] NULL,
	[PosNo] [int] NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[Amount] [decimal](18, 2) NULL,
	[UserName] [nvarchar](50) NULL,
	[FromTicket] [int] NULL,
	[ToTicket] [int] NULL,
	[TicketsCount] [int] NULL,
	[OrdersCount] [int] NULL,
	[ReadDateTime] [datetime] NULL,
	[ReadBy] [int] NULL,
	[DocID2] [int] NULL,
 CONSTRAINT [PK_OrpakReadingLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[OrpakTransactionsTemp](
	[shift_id] [int] NULL,
	[timestamp] [datetime] NULL,
	[id] [int] NOT NULL,
	[product_code] [int] NULL,
	[sale] [float] NULL,
	[ppv] [float] NULL,
	[quantity] [float] NULL,
	[mean_name] [varchar](32) NULL,
	[product_name] [varchar](32) NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_OrpakTransactionsTemp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE PROCEDURE [dbo].[OrpakAdjustment] @USERID int, @PosNo int,@WorkPeriod int,@StartDate varchar(20),@EndDate varchar(20)
AS
  Declare @TicketAmount as float;
  Declare @OrderAmount as float;
  Declare @VoucherNo int;
  Declare @DocDate date;
  Declare @CostCenter int;
  Declare @DefaultCurr int;
  Declare @DocNote nvarchar(Max);
  Declare @DocCode varchar(15);
  Declare @StockCreditWhereHouse int;
  Declare @DiscountRatio decimal(18, 4);
  Declare @TempAccount varchar(10);
  Declare @DocManualNo nvarchar(50) ;
  Declare @TicketCode varchar(50);
  Declare @Temp1 varchar(10);
  Declare @Temp2 varchar(10);
  Declare @Produce bit;
  Declare @TicketsCount int;
  Declare @TicketsAmount int;
  Declare @TicketIdFrom int;
  Declare @TicketIdTo int;
  Declare @OrdersCount int;
  Declare @VouchersInJournalAmount float;
  Declare @InputDateTime as datetime;
  Declare @_DocID2 int;
  Set @Temp1=( select Right(NEWID(),5))
  Set @CostCenter=( Select CostCenter from AccountingPOSNames Where ID=@PosNo  );
  Set @StockCreditWhereHouse=( Select Warehouse from AccountingPOSNames Where ID=@PosNo  );
  Set @InputDateTime=GETDATE()

  select [id] as TicketID,[sale] As TicketAmount,[timestamp]  Into   #@Temp1 from [OrpakTransactionsTemp] where [UserID]=@USERID

  Set @TicketIdFrom =( Select Min(TicketID) from #@Temp1 );
  Set @TicketIdTo =( Select Max(TicketID) from #@Temp1 );
  Set @TicketsAmount =( Select Sum(TicketAmount) from #@Temp1 );
  Set @TicketsCount =( Select Count(TicketID) from #@Temp1 );
  Set @_DocID2=cast(CONVERT(varchar(20),@InputDateTime,112) as INT )+@PosNo+@WorkPeriod ;

  Insert into [OrpakReadingLog] ([PeriodID],[PosNo],[FromDate],[ToDate],[Amount],[UserName],[FromTicket],[ToTicket],[TicketsCount],[OrdersCount],[ReadDateTime],[ReadBy],DocID2) 
		  Values (@WorkPeriod,@PosNo,@StartDate,@EndDate,@TicketsAmount,@USERID,@TicketIdFrom,@TicketIdTo,@TicketsCount,@OrdersCount,@InputDateTime,@USERID,@_DocID2)

  Declare @TicketID int;
  While (Select Count(*) From #@Temp1) > 0
  Begin
  Select Top 1 @TicketID = TicketID From #@Temp1 
  set @TicketAmount=( select TicketAmount from #@Temp1 where TicketID= @TicketID );
  Set @DocDate=(Select convert(date,[timestamp])  from #@Temp1 where TicketID= @TicketID  );


  Set @DefaultCurr=( Select CurrID  from Currency where IsDefault=1  );
  Set @DocNote= CONCAT('Orpak Voucher From (PosNo:' , @PosNo , ' WorkPeriod No:' , @WorkPeriod ,' User:' , @USERID,' TicketNo:' ,@TicketID,')')  ;
  SET @DocCode= ( select Right(NEWID(),15));
  Set @TempAccount=(Select TempAccounting from AccountingPOSNames where Id=@PosNo)
  Set @DocManualNo= @TicketID 
  Set @TicketCode='';
  Set @VoucherNo = ( Select IsNull(Max(DocID)+1,0)  from Journal where DocName=2 );
insert into Journal
       ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                       StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,
                                       CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,PosNo,DocNoteByAccount,VoucherDiscount,StockDiscount,LastDocCode,LastDataName,DocID2  ) 
                                       Select @VoucherNo,CAST(@DocDate AS DATE) ,2,1,@CostCenter,
                                       '0',I.AccSales,1,
                                       @DefaultCurr,O.Amount-O.Amount*@DiscountRatio,1,O.Amount-O.Amount*@DiscountRatio,O.Amount-O.Amount*@DiscountRatio,@DocManualNo,@DocNote,
                                       @USERID,@InputDateTime,O.Barcode,IU.unit_id,O.Quantity,IU.EquivalentToMain,
                                        O.Price,O.Price,0,@StockCreditWhereHouse,@USERID,
                                         0,N'',ItemName,@WorkPeriod,@DocCode,@PosNo,'',O.Amount * @DiscountRatio,0 ,@TicketCode,'Orpak',@_DocID2
                                       from [dbo].SambaOrdersTemp O
									   left Join Items I on O.Barcode=I.ItemNo
									   Left Join Items_units IU on IU.item_id=O.Barcode And IU.main_unit=1
									   where O.TicketId=@TicketID
insert into Journal
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,ShiftID,CurrentUserID,DocCode,PosNo,LastDocCode,LastDataName,DocID2  ) VALUES(
                                       @VoucherNo,CAST(@DocDate AS DATE) ,2,1,@CostCenter ,@TempAccount,
                                        '0',@DefaultCurr,1,@TicketAmount,1,@TicketAmount,
                                       @TicketAmount,@DocManualNo,@DocNote,@USERID,@InputDateTime,
                                        0,N'',@WorkPeriod,@USERID,
                                        @DocCode,@PosNo,@TicketCode,'Orpak',@_DocID2)

Delete from #@Temp1 Where TicketID = @TicketID
End
Drop Table #@Temp1
Set @VouchersInJournalAmount=( select sum(DocAmount) from Journal where PosNo=@PosNo And ShiftID=@WorkPeriod And InputDateTime=@InputDateTime  )
return  @VouchersInJournalAmount
GO




CREATE TABLE [dbo].[ReservationsList](
	[ID] [int] NOT NULL,
	[DocDate] [date] NULL,
	[ReferanceNo] [int] NULL,
	[ReservationAmount] [decimal](18, 2) NULL,
	[ReservationDate] [datetime] NULL,
	[ReservationNote] [nvarchar](max) NULL,
	[InitialAmount] [decimal](18, 2) NULL,
	[TheService] [int] NULL,
	[ReservationStatus] [nvarchar](50) NULL,
	[DocStatus] [int] NULL,
 CONSTRAINT [PK_ReservationsList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[ReservationsList] ADD  CONSTRAINT [DF_ReservationsList_DocStatus]  DEFAULT ((0)) FOR [DocStatus]
GO





CREATE TABLE [dbo].[ReservationsPayment](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[ReferanceNo] [int] NULL,
	[PaymentAmount] [decimal](18, 2) NULL,
	[PaymentNotes] [nvarchar](max) NULL,
	[PaymentDate] [date] NULL,
	[ReservationID] [int] NULL,
 CONSTRAINT [PK_ReservationsPayment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ReservationsPayment] ADD  CONSTRAINT [DF_ReservationsPayment_PaymentAmount]  DEFAULT ((0)) FOR [PaymentAmount]
GO


ALTER TABLE [EmployeesPositions] ALTER COLUMN Positions nvarchar(100) not null;
Go



ALTER TABLE [dbo].[ShelvesReportTemp] Add [Barcode] varchar(50)  NULL

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BankBranches]') AND type in (N'U'))
DROP TABLE [dbo].[BankBranches]
GO

/****** Object:  Table [dbo].[Banks]    Script Date: 05/10/2022 12:25:56 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Banks]') AND type in (N'U'))
DROP TABLE [dbo].[Banks]
GO


Alter TABLE [dbo].[Journal]  Add  [TarteebID] [int] NULL 
Go


CREATE TABLE [dbo].[Bank](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BankNo] [nvarchar](50) NOT NULL,
	[BankName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[BankNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





CREATE TABLE [dbo].[BankBranche](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BranchNo] [nvarchar](50) NOT NULL,
	[BranchName] [nvarchar](100) NOT NULL,
	[BankID] [int] NOT NULL,
 CONSTRAINT [PK_BankBranche_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

Alter TABLE [dbo].[Items]  Add  [CostCenter] [int] NULL 
Go

ALTER TABLE CostCenter ALTER COLUMN CostName nvarchar(100) NULL ;
Go

insert into Settings (SettingName,SettingValue) values ('ShowColBalanceInJournal','False')
Go


Alter TABLE [dbo].[FinancialAccounts]  Add  [NeedCostCenter] [Bit] NULL 
Go

insert into Settings (SettingName,SettingValue) values ('CostCenterRequired','False')
Go

Alter TABLE [dbo].[AttEmployeePayments]  Add  [PaymentBranch] nvarchar(50) NULL 
Go

insert into Settings (SettingName,SettingValue) values ('PosAllowMergeItems','False')
Go

Alter TABLE [dbo].[Appointments]  Add  [ServiceNo] [int] NULL 
Go

ALTER TABLE [dbo].[ShelvesReportTemp] Add [UserID] int  NULL
Go

ALTER TABLE [dbo].[ShelvesReportTemp] Add [MainBarcode] varchar(50)  NULL
Go



CREATE PROCEDURE [dbo].[BuildReturnVoucherFromOrderApp] @DocCode nvarchar(50), @ItemsCount int
AS
Declare @RowsNo int;
Set @RowsNo= ( Select IsNull(count(ID),0) As CountRows from Journal where DocCode=@DocCode);
if @RowsNo = 0 
Begin 
DECLARE @DocID int ;
SET @DocID = ( Select isnull(max([DocID])+1,1) from Journal  where DocName=12);
Declare @DocAmount float;
Set @DocAmount= ( Select sum(DocAmount) from OrdersAppJournal where DocCode=@DocCode)
DECLARE @UserID int ;
SET @UserID = ( Select top(1) InputUser  From [OrdersAppJournal] where DocCode=@DocCode );
Declare @Device Nvarchar (100);
Set @Device = (Select top (1) [DeviceName] from [OrdersAppJournal] where DocCode =@DocCode  );
Declare @UserName Nvarchar (100);
Set @UserName = (Select top (1) EmployeeName from EmployeesData where EmployeeID  =@UserID  );
Declare @DefualtWarehouses int;
Set @DefualtWarehouses = (Select  [DefaultWareHouse] from EmployeesData where EmployeeID  =@UserID  );

Insert into [JournalTemp] ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
			[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
		    [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
		    StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,
			StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,
			PosNo,DocNoteByAccount,DeviceName,DeliverDate,LastDocCode,LastDataName,StockBarcode,SalesPerson )
Select  @DocID as DocID , DocDate, 12 as DocName, 3 as DocStatus, 1 as DocCostCenter,
			I.AccRetSales as DebitAcc, '0' as CredAcc, 1 as AccountCurr,
			1 as DocCurrency, [DocAmount], 1 as ExchangePrice, [DocAmount] as BaseCurrAmount , [DocAmount] as BaseAmount, [DocID], DocNotes,
			InputUser, InputDateTime , StockID, StockUnit, StockQuantity, IU.EquivalentToMain,
			StockPrice, StockPrice, @DefualtWarehouses as StockDebitWhereHouse  , 0 as StockCreditWhereHouse, InputUser,
			R.RefNo, F.AccName, I.ItemName, 0, DocCode, '0', DocNoteByAccount, DeviceName, DeliverDate, DocCode, 'OrdersAppJournal' as LastDataName, IU.item_unit_bar_code as StockBarcode,SalesPerson
From [dbo].[OrdersAppJournal] J
		    Left Join [dbo].[Items] I On I.[ItemNo]=J.StockID
		    Left Join [dbo].FinancialAccounts F On J.[DebitAcc]=F.[AccNo]
		    Left join Items_units IU on J.StockID =IU.item_id and J.StockUnit=IU.unit_id
		    Left join Referencess R on R.RefNo=J.Referance
Where DocCode=@DocCode 

Insert into [JournalTemp] ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
			[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
			[DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,
			DocCode,DeviceName,PosNo,ShiftID,CurrentUserID,DeliverDate,LastDocCode,LastDataName,SalesPerson ) 
Select  top(1)  @DocID as DocID , DocDate, 12 as DocName, 3 as DocStatus, 1 as DocCostCenter,'0',R.RefAccID as CredAcc,
			1 as AccountCurr,1 as DocCurrency,@DocAmount,1,@DocAmount,@DocAmount,DocID,DocNotes,InputUser,InputDateTime,R.RefNo,R.RefName,
			DocCode,DeviceName,PosNo,ShiftID,CurrentUserID,DeliverDate,DocCode,'OrdersAppJournal' as LastDataName,InputUser 
From [dbo].[OrdersAppJournal] J
		    Left Join [dbo].[Items] I On I.[ItemNo]=J.StockID
		    Left Join [dbo].FinancialAccounts F On J.[DebitAcc]=F.[AccNo]
		    Left join Items_units IU on J.StockID =IU.item_id and J.StockUnit=IU.unit_id
		    left join Referencess R on R.RefNo=J.Referance
Where DocCode=@DocCode 


Insert into [dbo].[Journal] ([DocID],[DocDate] ,[DocName] ,[DocStatus]
            ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
            ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
            ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
            ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
            ,[StockUnit] ,[StockQuantity] ,[StockQuantityByMainUnit] ,[StockPrice]
            ,[StockItemPrice] ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
            ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
            ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
            ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
            ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
            ,[StockDiscount] ,[StockBarcode] ,[PosNo]
            ,[DeviceName],[LastDocCode],[LastDataName]) 
Select DocID,[DocDate] ,[DocName] ,[DocStatus]
            ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
            ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
            ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
            ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
            ,[StockUnit] ,[StockQuantity] ,[StockQuantityByMainUnit] ,[StockPrice]
            ,[StockItemPrice] ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
            ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
            ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
            ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
            ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
            ,[StockDiscount] ,[StockBarcode] ,[PosNo],[DeviceName] ,LastDocCode,LastDataName
			From JournalTemp  where DocCode=@DocCode

Delete from JournalTemp where DocCode=@DocCode

Update OrdersAppJournal set OrderStatus=1 where DocCode=@DocCode

INSERT INTO [dbo].[UsersLogs]
           ([DocCode]
           ,[DocName]
           ,[DocID]
           ,[LogName]
           ,[UserID]
           ,[LogDateTime]
           ,[DeviceName]
           ,[UserName]
           ,[LogDetails]
           ,[LogType]) Values (@DocCode,2,@DocID,'Insert',@UserID,GETDATE(),@Device,@UserName,'Issue Voucher From Mobile App','Document')

DECLARE @FinalDocID int ;
SET @FinalDocID = (  SELECT DocID 
     FROM [dbo].[Journal]  where  DocCode=@DocCode group by DocID having Count(StockID)=@ItemsCount ) ;

--if @FinalDocID is null
-- BEGIN
-- delete from Journal where DocCode=@DocCode
-- End
End
return  @FinalDocID
GO


CREATE PROCEDURE [dbo].[BuildReceiptFromOrderApp] @ReferanceNo nvarchar(50),@Amount decimal(18, 2) ,
												  @UserID nvarchar(50) ,@DocNote nvarchar(1000),
												  @DeviceName nvarchar(50),@CurrencyID int,@DocCode2 varchar(50),
												  @CashAmount decimal(18, 2),@ChecksAmount decimal(18, 2)
AS

Declare @RowsNo int;
Set @RowsNo= ( Select IsNull(count(ID),0) As CountRows from Journal where DocCode=@DocCode2);
if @RowsNo = 0 
Begin 

DECLARE @DocID int ;
DECLARE @DebitAccountCash varchar(15) ;
DECLARE @DebitAccountChecks varchar(15) ;
DECLARE @AccountCurr int ;
DECLARE @DefaultCurr int ;
DECLARE @InputDateTime as datetime ;
DECLARE @ReferanceName as nvarchar(50) ;
DECLARE @ReferanceAccount as varchar(50) ;
DECLARE @DocCode as varchar(15);
Declare @UserName Nvarchar (100);
Declare @DocNote2 Nvarchar (1000);
SET @DocID = ( Select isnull(max([DocID])+1,1) from Journal  where DocName=5);
SET @DebitAccountCash = ( Select AccNo from FinancialAccountsDefault where UserID= @UserID and CurrencyID=@CurrencyID And AccTypeID=1);
SET @DebitAccountChecks = ( Select AccNo from FinancialAccountsDefault where UserID= @UserID and CurrencyID=@CurrencyID And AccTypeID=2);
SET @AccountCurr=(Select Currency from FinancialAccounts where AccNo=@DebitAccountCash );
SET @DefaultCurr=(Select CurrID from Currency where IsDefault=1);
SET @InputDateTime= (select CONVERT(char(10), GetDate(),126) + ' ' + convert(VARCHAR(8), GETDATE(), 14))
SET @ReferanceName= ( Select RefName from Referencess where RefNo = @ReferanceNo);
--SET @DocCode= ( select Right(NEWID(),15));
SET @DocCode= @DocCode2;
SET @ReferanceAccount= ( Select RefAccID from Referencess where RefNo= @ReferanceNo);
Set @UserName = (Select EmployeeName from EmployeesData where EmployeeID =@UserID  );
Set @DocNote2=(@DocNote+'/'+@ReferanceName);
--Add CashDebit Side
Insert into [JournalTemp] ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
			[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
		    [DocManualNo],[DocNotes],InputUser,InputDateTime,CurrentUserID,Referance,ReferanceName,ShiftID,DocCode,
			PosNo,DocNoteByAccount,DeviceName,[CheckNo],[CheckInOut],[CheckStatus],[CheckDueDate],[CheckCustBank],[CheckCustBranch],[CheckCustAccountId],[AccountBank],SalesPerson )
values(  @DocID , CONVERT(char(10), GetDate(),126),5,1,1,@DebitAccountCash,'0',@AccountCurr,@DefaultCurr,@CashAmount,1,@CashAmount,@CashAmount,'',
		 @DocNote2,@UserID,@InputDateTime,-1,0,'',0,@DocCode,0,'',@DeviceName,'0','','0','','0','0','0','0',@UserID);

If @ChecksAmount <> 0 
Begin 
--Add CheksDebit Side
Insert into [JournalTemp] ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
			[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
		    [DocManualNo],[DocNotes],InputUser,InputDateTime,CurrentUserID,Referance,ReferanceName,ShiftID,DocCode,
			PosNo,DocNoteByAccount,DeviceName,[CheckNo],[CheckInOut],[CheckStatus],[CheckDueDate],[CheckCustBank],[CheckCustBranch],[CheckCustAccountId],[AccountBank],SalesPerson )
values(  @DocID , CONVERT(char(10), GetDate(),126),5,1,1,@DebitAccountChecks,'0',@AccountCurr,@DefaultCurr,@ChecksAmount,1,@ChecksAmount,@ChecksAmount,'',
		 @DocNote2,@UserID,@InputDateTime,-1,0,'',0,@DocCode,0,'',@DeviceName,'','','','','','','','',@UserID);
End 

--Add Credit Side
Insert into [JournalTemp] ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
			[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
		    [DocManualNo],[DocNotes],InputUser,InputDateTime,CurrentUserID,Referance,ReferanceName,ShiftID,DocCode,
			PosNo,DocNoteByAccount,DeviceName,[CheckNo],[CheckInOut],[CheckStatus],[CheckDueDate],[CheckCustBank],[CheckCustBranch],[CheckCustAccountId],[AccountBank],SalesPerson )
values(  @DocID , CONVERT(char(10), GetDate(),126),5,1,1,'0',@ReferanceAccount,@AccountCurr,@DefaultCurr,@Amount,1,@Amount,@Amount,'',
		 @DocNote2,@UserID,@InputDateTime,-1,@ReferanceNo,@ReferanceName,0,@DocCode,0,'',@DeviceName,'0','','0','1900-01-01','0','0','0','0',@UserID);

--Post Cheks To Cheks Table 
--INSERT INTO Checks (DocName,CheckCode,CheckInOut,CheckNo,CheckDueDate,CheckBank,CheckBranch,CheckAccountId,CheckStatus,CheckAmount,CheckCurr,CheckBaseAmount,DocCode,DocID,AccountBank,DocNoteByAccount,ChekInBoxAccount,Referance,RelatedAccount,TransNoInJournal)
--SELECT  DocName,CheckCode,CheckInOut,CheckNo,CheckDueDate,CheckCustBank,CheckCustBranch,CheckCustAccountId,CheckStatus,DocAmount,DocCurrency,BaseCurrAmount,DocCode,DocID,AccountBank,DocNoteByAccount,DebitAcc,Referance,DebitAcc,1 FROM JournalTemp 
--where DocName=4  and DocID=@DocID and CurrentUserID= @UserID and CheckNo <> 0 And  CredAcc='0' 

Insert into [dbo].[Journal] ([DocID],[DocDate] ,[DocName] ,[DocStatus]
            ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
            ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
            ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
            ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
            ,[StockUnit] ,[StockQuantity] ,[StockQuantityByMainUnit] ,[StockPrice]
            ,[StockItemPrice] ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
            ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
            ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
            ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
            ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
            ,[StockDiscount] ,[StockBarcode] ,[PosNo]
            ,[DeviceName],[LastDocCode],[LastDataName]) 
Select DocID,[DocDate] ,[DocName] ,[DocStatus]
            ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
            ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
            ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
            ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
            ,[StockUnit] ,[StockQuantity] ,[StockQuantityByMainUnit] ,[StockPrice]
            ,[StockItemPrice] ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
            ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
            ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
            ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
            ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
            ,[StockDiscount] ,[StockBarcode] ,[PosNo],[DeviceName] ,LastDocCode,LastDataName
			From JournalTemp  where DocCode=@DocCode

Delete from JournalTemp where DocCode=@DocCode

INSERT INTO [dbo].[UsersLogs]
           ([DocCode]
           ,[DocName]
           ,[DocID]
           ,[LogName]
           ,[UserID]
           ,[LogDateTime]
           ,[DeviceName]
           ,[UserName]
           ,[LogDetails]
           ,[LogType]) Values (@DocCode,2,@DocID,'Insert',@UserID,GETDATE(),@DeviceName,@UserName,'Issue Receipt From Mobile App','Document')
End
Declare @FinalDocID int;
SET @FinalDocID = (  SELECT top(1) DocID 
     FROM [dbo].[Journal]  where  DocCode=@DocCode ) ;

if @FinalDocID is null
 BEGIN
 delete from Journal where DocCode=@DocCode
 End
 --End
return  @FinalDocID;
GO



Create PROCEDURE [dbo].[InsertIntoPOSJournal] @Barcode varchar(50) ,@DocName int,@Quantity float,
									          @WahreHouse int,@DocCode varchar(50),@ReferanceNo int,
											  @Device varchar(50),@ShiftID int ,@POSNo int,@UserNo int,
											  @ItemNo int,@Unit int,@shelf int
						AS
						Declare @PriceCategory  int;
						declare @Price decimal(10,2);
						if @ReferanceNo =0 begin Set @PriceCategory=1 end else begin Set @PriceCategory= (select IsNull(PriceCategory,1)   from Referencess where RefNo=@ReferanceNo  ) end;



						if @Barcode<>'0' begin
						Set @Price= ( select top(1) case when  @PriceCategory=1 then IU.Price1  when @PriceCategory=2 then IsNull(IU.Price2,IU.Price1) when @PriceCategory=3 then IsNull(IU.Price3,IU.Price1)   end as StockPrice from  dbo.Items_units IU   where  IU.item_unit_bar_code=@Barcode);
						Declare @AllowMerge varchar(10) ;
						Set @AllowMerge = ( Select SettingValue from Settings where SettingName='PosAllowMergeItems' )
						Declare @TransID int;
						Set @TransID= ( Select top(1) id from POSJournal where StockBarcode=@Barcode order by id desc  )
						--Declare @DisCount float ;
						--Set @DisCount= ( select top(1) IsNull(StockDiscount,0) from POSJournal where id=@TransID );
						IF @AllowMerge='True' and  EXISTS(SELECT 1 FROM dbo.POSJournal WITH(NOLOCK)
								  WHERE StockBarcode = @Barcode )
							BEGIN
								Update POSJournal set StockQuantity=StockQuantity+1,DocAmount=DocAmount+@Price,StockDiscount=(StockDiscount*StockQuantity)/(StockQuantity+1) WHERE id=@TransID
							END
						ELSE
							BEGIN
						if @DocName=2 
							begin 
							Insert Into [dbo].[POSJournal] ([StockID],ItemName,DebitAcc,CredAcc,StockDebitWhereHouse,
															[StockCreditWhereHouse],[StockDebitShelve],[StockCreditShelve],AccountCurr,StockUnit,StockPrice,UnitName,SaleOnScale,[StockQuantity],
															[StockQuantityByMainUnit],DocAmount,[DocCode],[StockDiscount],[StockBarcode],
															[InputUser],[PCName],[ShiftID],PosNo,Produced )
							Select top(1) [ItemNo] as StockID ,ItemName ,'0' as DebitAcc ,[AccSales] as CredAcc,0, @WahreHouse,0,@shelf,1,IU.unit_id As StockUnit ,
												   @Price as StockPrice,U.name as UnitName ,SaleOnScale , @Quantity,
												   IU.[EquivalentToMain], @Price  * @Quantity,@DocCode,
												   0  as StockDiscount,[item_unit_bar_code],@UserNo,
												   @Device,@ShiftID,@POSNo,IsNull(HasProductionEquation,0) As Produced
												   from dbo.Items I 
												   left join dbo.Items_units IU on IU.item_id = I.ItemNo left join Units U on U.id=IU.unit_id where  item_unit_bar_code=@Barcode
							end
							if @DocName =12
							begin 
							Insert Into [dbo].[POSJournal] (StockID,ItemName,DebitAcc,CredAcc,StockDebitWhereHouse,
													  StockCreditWhereHouse,[StockDebitShelve],[StockCreditShelve],AccountCurr,StockUnit,StockPrice,UnitName,SaleOnScale,[StockQuantity],
													  StockQuantityByMainUnit,DocAmount,[DocCode],[StockDiscount],[StockBarcode],
													  [InputUser],[PCName],[ShiftID],PosNo,Produced )
											Select top(1) [ItemNo] as StockID ,ItemName,[AccRetSales] as DebitAcc ,'0' as CredAcc,@WahreHouse,'0',@shelf,0,1,IU.unit_id As StockUnit ,
												   @Price as StockPrice,U.name as UnitName ,SaleOnScale , @Quantity,
												   IU.[EquivalentToMain], @Price  * @Quantity,@DocCode,
												   0  as StockDiscount,[item_unit_bar_code],@UserNo,
												   @Device,@ShiftID,@POSNo,IsNull(HasProductionEquation,0) As Produced
												   from dbo.Items I 
												   left join dbo.Items_units IU on IU.item_id = I.ItemNo left join Units U on U.id=IU.unit_id where  item_unit_bar_code=@Barcode
							end
						end
						END


	
	

						if @Barcode='0' begin
						if @Unit=0 Begin Set @Unit=( select top(1) unit_id  from Items_units where item_id=@ItemNo and main_unit=1  ) end
							Set @Price= ( select top(1) case when  @PriceCategory=1 then IU.Price1  when @PriceCategory=2 then IsNull(IU.Price2,IU.Price1) when @PriceCategory=3 then IsNull(IU.Price3,IU.Price1)   end as StockPrice from Items I left join dbo.Items_units IU on IU.item_id = I.ItemNo left join Units U on U.id=IU.unit_id where   [item_id]=@ItemNo and IU.unit_id=@Unit);
							if @DocName=2 
							begin 
	
							Insert Into [dbo].[POSJournal] ([StockID],ItemName,DebitAcc,CredAcc,StockDebitWhereHouse,
															[StockCreditWhereHouse],[StockDebitShelve],[StockCreditShelve],AccountCurr,StockUnit,StockPrice,UnitName,SaleOnScale,[StockQuantity],
															[StockQuantityByMainUnit],DocAmount,[DocCode],[StockDiscount],[StockBarcode],
															[InputUser],[PCName],[ShiftID],PosNo,Produced )
							Select top(1) [ItemNo] as StockID ,ItemName ,'0' as DebitAcc ,[AccSales] as CredAcc,0, @WahreHouse,0,@shelf,1,IU.unit_id As StockUnit ,
												   @Price as StockPrice,U.name as UnitName ,SaleOnScale , @Quantity,
												   IU.[EquivalentToMain], @Price  * @Quantity,@DocCode,
												   0  as StockDiscount,[item_unit_bar_code],@UserNo,
												   @Device,@ShiftID,@POSNo,IsNull(HasProductionEquation,0) As Produced
												   from dbo.Items I 
												   left join dbo.Items_units IU on IU.item_id = I.ItemNo left join Units U on U.id=IU.unit_id where  [item_id]=@ItemNo and IU.unit_id=@Unit
							end
							if @DocName =12
							begin 
							Insert Into [dbo].[POSJournal] (StockID,ItemName,DebitAcc,CredAcc,StockDebitWhereHouse,
													  StockCreditWhereHouse,[StockDebitShelve],[StockCreditShelve],AccountCurr,StockUnit,StockPrice,UnitName,SaleOnScale,[StockQuantity],
													  StockQuantityByMainUnit,DocAmount,[DocCode],[StockDiscount],[StockBarcode],
													  [InputUser],[PCName],[ShiftID],PosNo,Produced )
											Select top(1) [ItemNo] as StockID ,ItemName,[AccRetSales] as DebitAcc ,'0' as CredAcc,@WahreHouse,'0',@shelf,0,1,IU.unit_id As StockUnit ,
												   @Price as StockPrice,U.name as UnitName ,SaleOnScale , @Quantity,
												   IU.[EquivalentToMain], @Price  * @Quantity,@DocCode,
												   0  as StockDiscount,[item_unit_bar_code],@UserNo,
												   @Device,@ShiftID,@POSNo,IsNull(HasProductionEquation,0) As Produced
												   from dbo.Items I 
												  left join dbo.Items_units IU on IU.item_id = I.ItemNo left join Units U on U.id=IU.unit_id where  [item_id]=@ItemNo and IU.unit_id=@Unit
							end
						end

						EXEC	 [dbo].[ApplyCampagins]		@Barcode = @Barcode
						return  @@ROWCOUNT;
GO




Insert into Settings (SettingName,SettingValue) values ('Shalash','False');
Go



CREATE TABLE [dbo].[AttByQuantity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeNo] [int] NULL,
	[TransDate] [datetime] NULL,
	[Quantity] [decimal](18, 2) NULL,
	[Price] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_AttByQuantity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO




Insert into Settings (SettingName,SettingValue) values ('AttShowAllEmployeesInAttReports','0');
Go


Insert into Settings (SettingName,SettingValue) values ('AttCalcBonusBerforePeriodMinutes','0');
Go
Insert into Settings (SettingName,SettingValue) values ('AttCalcBonusAfterPeriodMinutes','0');
Go

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('SmsAPIGetBalance','',N' فحص رصيد رسائل الموبايل');
Go


CREATE TABLE [dbo].[SettValues](
	[SetID] [int] IDENTITY(1,1) NOT NULL,
	[SetName] [varchar](50) NOT NULL,
	[SetCode] [varchar](max) NULL,
 CONSTRAINT [PK_SettValues] PRIMARY KEY CLUSTERED 
(
	[SetName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



-- full 
Insert into [dbo].[SettValues] (SetName,SetCode) values ('Set1','4TRXETnlbG/KDmBMlE0ukYUIAZ+qJE7p')
Go



CREATE TABLE [dbo].[OrderProcessing](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemNo] [int] NULL,
	[ItemName] [nvarchar](100) NULL,
	[Quantity] [decimal](18, 0) NULL,
	[OrderDate] [datetime] NULL,
	[OrderByUser] [int] NULL,
	[AcceptByUser] [int] NULL,
	[AcceptDate] [datetime] NULL,
	[Orderstatus] [int] NULL,
	[OrderType] [int] NULL,
	[Vendor] [int] NULL,
 CONSTRAINT [PK_OrderProcessing] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderProcessing] ADD  DEFAULT ((0)) FOR [Vendor]
GO

CREATE TABLE [dbo].[InternalOrders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemNo] [int] NULL,
	[ItemName] [nvarchar](100) NULL,
	[Quantity] [decimal](18, 0) NULL,
	[OrderDate] [datetime] NULL,
	[OrderByUser] [int] NULL,
	[AcceptByUser] [int] NULL,
	[AcceptDate] [datetime] NULL,
	[Orderstatus] [int] NULL,
	[OrderType] [int] NULL,
	[Vendor] [int] NULL,
 CONSTRAINT [PK_InternalOrders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[InternalOrders] ADD  DEFAULT ((0)) FOR [Vendor]
GO


ALTER TABLE [dbo].[Items] Add [Vendor] int  NULL
Go

ALTER TABLE [SubscriptionDoc] ALTER COLUMN SubStatus Int;
Go


insert into Settings (SettingName,SettingValue,SettingDescription) values ('AlqudsCigConnection','',N'اعدادات الاتصال مع نظام زين')
Go
insert into Settings (SettingName,SettingValue,SettingDescription) values ('AlqudsCig','False',N'نسخة ل سجائر القدس')
Go


ALTER TABLE [dbo].[Items] Add [classification] int  NULL
Go


Alter table [dbo].[Items] add classification int default 1
Go
Update [dbo].[Items] set classification=1 where classification is null
Go

insert into Settings (SettingName,SettingValue,SettingDescription) values ('PosHideSaveButton','False',N'اخفاء زر الحفظ في نقطة البيع')
Go



Alter table AttPlaneForPeriod add	[BonusBefore] [int] NULL
Go
Alter table AttPlaneForPeriod add	[BonusAfter] [int] NULL
GO
ALTER TABLE [dbo].[AttPlaneForPeriod] ADD  CONSTRAINT [DF_AttPlaneForPeriod_BonusBefore]  DEFAULT ((0)) FOR [BonusBefore]
GO
ALTER TABLE [dbo].[AttPlaneForPeriod] ADD  CONSTRAINT [DF_AttPlaneForPeriod_BonusAfter]  DEFAULT ((0)) FOR [BonusAfter]
GO
ALTER TABLE [dbo].[AttPlaneForPeriod] ADD  CONSTRAINT [DF_AttPlaneForPeriod_BonusAfter]  DEFAULT ((0)) FOR [BonusAfter]
GO



ALTER TABLE [JournalTemp] ALTER COLUMN  DocNoteByAccount NVARCHAR(max);
Go
ALTER TABLE [Journal] ALTER COLUMN  DocNoteByAccount NVARCHAR(max);
Go
ALTER TABLE [POSJournal] ALTER COLUMN  DocNoteByAccount NVARCHAR(max);
Go
ALTER TABLE [POSDeletedJournal] ALTER COLUMN  DocNoteByAccount NVARCHAR(max);
Go
ALTER TABLE [POSHoldJournal] ALTER COLUMN  DocNoteByAccount NVARCHAR(max);
Go

Alter table [dbo].[InternalOrders] add [ItemNo2] [nvarchar] (50) NULL
Go

ALTER TABLE [CarRentDocuments] ADD DocCode varchar(255);
Go
ALTER TABLE [CarRentDocuments] ADD VoucherNo int NULL;
Go

ALTER TABLE ArchiveDocs ALTER COLUMN  DocSort1 [int] NULL;
Go
ALTER TABLE ArchiveDocs ALTER COLUMN  DocSort2 [int] NULL;
Go

insert into Settings (SettingName,SettingValue,SettingDescription) values ('PosGroupsNamesHeight','100',N'ارتفاع شاشة عرض اسماء المجموعات في نقطة البيع')
Go

ALTER TABLE [Appointments] ALTER COLUMN DocCode varchar(20);
Go

Update Settings Set SettingDescription=N'السماح بتعديل السعر في نقطة البيع' where SettingName='PosAllowChangeItemPrice'
Go

insert into Settings (SettingName,SettingValue,SettingDescription) values ('PosChangeItemPriceFromItemList','False',N'السماح بتعديل السعر بالنظام المالي من خلال نقطة البيع')
Go

alter table [dbo].[CostCenter] alter column [CostName] nvarchar(100) not null
Go


insert into Settings (SettingName,SettingValue,SettingDescription) values ('AccountingStatmentRefNote','',N'ملاحظة كشف حساب الذمم')
Go

ALTER TABLE [dbo].[CarsRent]  ADD DailyAmount [decimal](18, 2) NULL ;
Go
ALTER TABLE [dbo].[CarsRent] ADD  CONSTRAINT [DF_CarsRent_DailyAmount]  DEFAULT ((0)) FOR [DailyAmount]
GO

ALTER TABLE [dbo].[CarRentDocuments]  ADD DailyAmount [decimal](18, 2) NULL ;
Go

ALTER TABLE [dbo].[CarRentDocuments]  ADD FuelPercentage [int] NULL ;
Go

ALTER TABLE [dbo].[Referencess]  ADD [IdentityNo] nvarchar(50) NULL ;
Go

ALTER TABLE [dbo].[Referencess]  ADD [Nationality] nvarchar(50) NULL ;
Go
ALTER TABLE [dbo].[Referencess]  ADD [IdentityType] nvarchar(50) NULL ;
Go
ALTER TABLE [dbo].[Referencess]  ADD [TarkhesID] nvarchar(50) NULL ;
Go
ALTER TABLE [dbo].[Referencess]  ADD [TarkhesIssueDate] datetime NULL ;
Go
ALTER TABLE [dbo].[Referencess]  ADD [TarkhesEndDate] datetime NULL ;
Go

ALTER TABLE [dbo].[CarRentDocuments]  ADD [AddDriverName] nvarchar(MAX) NULL ;
Go
ALTER TABLE [dbo].[CarRentDocuments]  ADD [AddDriverIdentityNo] nvarchar(50) NULL ;
Go
ALTER TABLE [dbo].[CarRentDocuments]  ADD [AddDriverIdentityType] nvarchar(100) NULL ;
Go
ALTER TABLE [dbo].[CarRentDocuments]  ADD [AddDriverBirthday] DATETIME NULL ;
Go
ALTER TABLE [dbo].[CarRentDocuments]  ADD [AddDriverTarkhesIssueDate] datetime NULL ;
Go
ALTER TABLE [dbo].[CarRentDocuments]  ADD [AddDriverTarkhesEndDate] datetime NULL ;
Go
ALTER TABLE [dbo].[ItemsGroups]  ADD [AvailableOnline] bit NULL ;
Go


ALTER TABLE [dbo].[Journal] Add  [LastPurchasePrice] float default 0
Go
ALTER TABLE [dbo].[JournalTemp] Add  [LastPurchasePrice] float default 0
Go
ALTER TABLE [dbo].[POSJournal] Add [LastPurchasePrice] float default 0
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [LastPurchasePrice] float default 0
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [LastPurchasePrice] float default 0
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add [LastPurchasePrice] float default 0
Go
ALTER TABLE [dbo].[POSHoldJournal] Add [LastPurchasePrice] float default 0
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add [LastPurchasePrice] float default 0
Go

CREATE TABLE [dbo].[ItemBatchNo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BatchNo] [nvarchar](50) NOT NULL,
	[ExpireDate] [datetime] NOT NULL,
	[ItemNo] [int] NOT NULL,
 CONSTRAINT [PK_ItemBatchNo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_ItemBatchNo_ItemNo_BatchNo] UNIQUE NONCLUSTERED 
(
	[ItemNo] ASC,
	[BatchNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Journal] Add  [BatchID] int default 0
Go
ALTER TABLE [dbo].[JournalTemp] Add  [BatchID] int default 0
Go
ALTER TABLE [dbo].[POSJournal] Add [BatchID] int default 0
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [BatchID] int default 0
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [BatchID] int default 0
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add [BatchID] int default 0
Go
ALTER TABLE [dbo].[POSHoldJournal] Add [BatchID] int default 0
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add [BatchID] int default 0
Go
Update Journal Set [BatchID]=0 where [BatchID] Is Null
Go
Update JournalBeforeUpdate Set [BatchID]=0 where [BatchID] Is Null
Go

ALTER TABLE [dbo].[Journal] Add  [BatchNo] nvarchar(50) default ''
Go
ALTER TABLE [dbo].[JournalTemp] Add  [BatchNo] nvarchar(50) default ''
Go
ALTER TABLE [dbo].[POSJournal] Add  [BatchNo] nvarchar(50) default ''
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [BatchNo] nvarchar(50) default ''
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [BatchNo] nvarchar(50) default ''
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add  [BatchNo] nvarchar(50) default ''
Go
ALTER TABLE [dbo].[POSHoldJournal] Add  [BatchNo] nvarchar(50) default ''
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add  [BatchNo] nvarchar(50) default ''
Go
Update Journal Set [BatchNo]='' where [BatchNo] Is Null
Go
Update JournalBeforeUpdate Set [BatchNo]='' where [BatchNo] Is Null
Go


ALTER TABLE [dbo].[Items]  ADD [UseBatchNo] bit default 0 
Go
Update Items Set [UseBatchNo]=0 where [UseBatchNo] Is Null
Go



CREATE TABLE [dbo].[ItemsSubGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubGroupName] [nvarchar](50) NOT NULL,
	[SubGroupImage] [image] NULL,
	[MainGroup] [int] NOT NULL,
	[ShowInMatjar] [bit] NULL,
 CONSTRAINT [PK_ItemsSubGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Referencess]  ADD [PasswordForMatjar] nvarchar(50) NULL ;
Go

ALTER TABLE [dbo].[Referencess]  ADD [ActiveOnMatjar] Bit NULL ;
Go
Update [dbo].[Referencess] Set [ActiveOnMatjar]=1 Where [ActiveOnMatjar] Is Null
Go

Declare @cityfieldtype varchar(50);
set @cityfieldtype=(SELECT     DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Referencess' AND COLUMN_NAME = 'SearchCity')
if @cityfieldtype='nvarchar'
begin 
Update Referencess Set SearchCity=1;
ALTER TABLE Referencess ALTER COLUMN SearchCity int NULL;
ALTER TABLE [dbo].[Citys]  ADD [ID] INT  IDENTITY(1,1) ;
ALTER TABLE [dbo].[Citys]  ADD [CityEn] nvarchar(50) Null  ;
end
Go






ALTER TABLE [dbo].[POSJournal]  ADD [PriceEdited] Bit NULL ;
Go   
ALTER TABLE [dbo].[POSHoldJournal]  ADD [PriceEdited] Bit NULL ;
Go   

Insert INTO ChecksStatus (CheckStatus,CheckInOutType,ID) values ( N'صادر راجع', 'Out',10 )
Go

insert into Settings (SettingName,SettingValue,SettingDescription) values ('E-Matjat','False',N'تفعيل ميزات ادارة المتجر الالكتروني')
Go
insert into Settings (SettingName,SettingValue,SettingDescription) values ('CostCenterForIncomeAccountsOnly','True',N'مركز التكلفة لحسابات قائمة الدخل فقط')
Go

alter table [dbo].[AttRawatebArchive] alter column [JobName] nvarchar(100) not null
Go
alter table [dbo].[AttRawatebArchive] alter column [Department] nvarchar(100) not null
Go
alter table [dbo].[AttRawatebArchive] alter column [Branch] nvarchar(100) not null
Go
insert into Settings (SettingName,SettingValue,SettingDescription) values ('UseColorsAndMeasuresInItems','False',N'استخدام الالوان والقياسات في تعريف الاصناف واظهار الاعمدة في السندات')
Go

ALTER TABLE [dbo].[ItemsColors]  ADD [ColorHex] varchar(100) NULL ;
Go
ALTER TABLE [dbo].[ItemsColors]  ADD [ColorNo] varchar(100) NULL ;
Go
ALTER TABLE [dbo].[ItemsColors]  ADD [ColorCode] varchar(100) NULL ;
Go
ALTER TABLE [dbo].[items]  ADD [SubGroupForMatjar] int NULL ;
Go
ALTER TABLE [dbo].[items]  ADD [SubGroupForMatjarTarteeb] int NULL ;
Go











ALTER TABLE [dbo].[Vocations] Add [TransAdjustID] int  NULL
Go

ALTER TABLE [dbo].[Vocations] Add [HoursPriod] Varchar(10)  NULL
Go


CREATE TABLE [dbo].[AttAdjustmentTrans](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmpNo] [int] NOT NULL,
	[AdjustName] [int] NOT NULL,
	[PeriodFactor] [varchar](10) NOT NULL,
	[Notes] [nvarchar](50) NULL,
	[InputUser] [int] NULL,
	[InputdateTime] [datetime] NULL,
	[TransDate] [date] NOT NULL,
	[VocID] [int] NULL,
 CONSTRAINT [PK_AttManualTrans] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[AttAdjustmentTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[adjustment] [nvarchar](50) NULL,
	[type] [int] NULL,
 CONSTRAINT [PK_AttAdjustmentTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


Insert into [dbo].[Settings] ([SettingName],[SettingValue],[SettingDescription]) values ('AttDailyAdjustment','False',N'معالجة المغادرات والاضافي بشكل يومي')




SET IDENTITY_INSERT [dbo].[AttAdjustmentTypes] ON 
GO
INSERT [dbo].[AttAdjustmentTypes] ([ID], [adjustment], [type]) VALUES (1, N'تعديل حركة تاخير', 1)
GO
INSERT [dbo].[AttAdjustmentTypes] ([ID], [adjustment], [type]) VALUES (2, N'خصم التاخير من الاجازات', 1)
GO
INSERT [dbo].[AttAdjustmentTypes] ([ID], [adjustment], [type]) VALUES (3, N'تعديل حركة اضافي', 2)
GO
INSERT [dbo].[AttAdjustmentTypes] ([ID], [adjustment], [type]) VALUES (4, N'ترصيد الاضافي على الاجازات', 2)
GO
INSERT [dbo].[AttAdjustmentTypes] ([ID], [adjustment], [type]) VALUES (5, N'تعديل حركة اضافي قبل الدوام', 3)
GO
INSERT [dbo].[AttAdjustmentTypes] ([ID], [adjustment], [type]) VALUES (6, N'ترصيد اضافي قبل الدوام على الاجازات', 3)
GO
INSERT [dbo].[AttAdjustmentTypes] ([ID], [adjustment], [type]) VALUES (7, N'تعديل حركة اضافي بعد الدوام', 4)
GO
INSERT [dbo].[AttAdjustmentTypes] ([ID], [adjustment], [type]) VALUES (8, N'ترصيد اضافي بعد الدوام على الاجازات', 4)
GO
INSERT [dbo].[AttAdjustmentTypes] ([ID], [adjustment], [type]) VALUES (9, N'تعديل تاخير صباحي ', 5)
GO
INSERT [dbo].[AttAdjustmentTypes] ([ID], [adjustment], [type]) VALUES (10, N'خصم تاخير صباحي من لاجازات', 5)
GO
INSERT [dbo].[AttAdjustmentTypes] ([ID], [adjustment], [type]) VALUES (11, N'تعديل خروج مبكر ', 6)
GO
INSERT [dbo].[AttAdjustmentTypes] ([ID], [adjustment], [type]) VALUES (12, N'خصم خروج مبكر من الاجازات', 6)
GO
SET IDENTITY_INSERT [dbo].[AttAdjustmentTypes] OFF
GO


Alter table AttRawatebArchive add	SalaryPerHour [decimal](18, 2) NULL  
Go



Insert into [dbo].[Settings] ([SettingName],[SettingValue],[SettingDescription]) values ('OrpakOneVoucherEveryMonth','False',N'تجميع الحركات في فاتورة واحدة كل شهر ')
Go





CREATE TABLE [dbo].[OrpakReadCSTMRTransLogs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[executionTime] [int] NULL,
	[TransInOrpakCount] [int] NULL,
 CONSTRAINT [PK_OrpakReadCSTMRTransLogs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[PosLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocCode] [varchar](100) NULL,
	[DocDateTime] [datetime] NULL,
	[Notes] [nvarchar](100) NULL,
	[UserID] [int] NULL,
	[PosNo] [int] NULL,
 CONSTRAINT [PK_PosLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



insert into Settings (SettingName,SettingValue,SettingDescription) values ('CheckShowUnDueChecksOnAccountStatment','False',N'عرض سطر الرصيد شامل الشيكات الاجلة في كشف الحساب')
Go

ALTER TABLE [dbo].[AttPlaneForPeriod] ADD CONSTRAINT PK_EmpIDWithDate UNIQUE ([AttTransDate],[EmpID]);
Go
Alter table [dbo].[AttPlaneForPeriod] add InputDateTime datetime NULL  
Go




CREATE TABLE [dbo].[AttRequiredHoursPlanes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DateFrom] [date] NOT NULL,
	[DateTo] [date] NOT NULL,
	[RequiredHours] [varchar](8) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[PlaneCode] [int] NULL,
 CONSTRAINT [PK_AttRequiredHours] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[AttRequiredHoursPlanesNames](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PlaneCode] [int] NOT NULL,
	[PlaneName] [nvarchar](50) NULL,
 CONSTRAINT [PK_AttRequiredHoursPlanesNames] PRIMARY KEY CLUSTERED 
(
	[PlaneCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmployeesData] Add [RequiredHoursPlane] int NULL
Go


----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[OrpakAdjustment] @USERID int, @PosNo int,@WorkPeriod int,@StartDate varchar(20),@EndDate varchar(20),@Employee varchar(100)
AS
  Declare @TicketAmount as float;
  Declare @OrderAmount as float;
  Declare @VoucherNo int;
  Declare @DocDate date;
  Declare @CostCenter int;
  Declare @DefaultCurr int;
  Declare @DocNote nvarchar(Max);
  Declare @DocCode varchar(15);
  Declare @StockCreditWhereHouse int;
  Declare @DiscountRatio decimal(18, 4);
  Declare @TempAccount varchar(10);
  Declare @DocManualNo nvarchar(50) ;
  Declare @TicketCode varchar(50);
  Declare @Temp1 varchar(10);
  Declare @Temp2 varchar(10);
  Declare @Produce bit;
  Declare @TicketsCount int;
  Declare @TicketsAmount int;
  Declare @TicketIdFrom int;
  Declare @TicketIdTo int;
  Declare @OrdersCount int;
  Declare @VouchersInJournalAmount float;
  Declare @InputDateTime as datetime;
  Declare @_DocID2 int;
  Set @Temp1=( select Right(NEWID(),5))
  Set @CostCenter=( Select CostCenter from AccountingPOSNames Where ID=@PosNo  );
  Set @StockCreditWhereHouse=( Select Warehouse from AccountingPOSNames Where ID=@PosNo  );
  Set @InputDateTime=GETDATE()
  Set @DiscountRatio=0
  select [id] as TicketID,[sale] As TicketAmount,[timestamp]  Into   #@Temp1 from [OrpakTransactionsTemp] where [UserID]=@USERID

  Set @TicketIdFrom =( Select Min(TicketID) from #@Temp1 );
  Set @TicketIdTo =( Select Max(TicketID) from #@Temp1 );
  Set @TicketsAmount =( Select Sum(TicketAmount) from #@Temp1 );
  Set @TicketsCount =( Select Count(TicketID) from #@Temp1 );
  Set @_DocID2=cast(CONVERT(varchar(20),@InputDateTime,112) as INT )+@PosNo+@WorkPeriod ;

  Insert into [OrpakReadingLog] ([PeriodID],[PosNo],[FromDate],[ToDate],[Amount],[UserName],[FromTicket],[ToTicket],[TicketsCount],[OrdersCount],[ReadDateTime],[ReadBy],DocID2) 
		  Values (@WorkPeriod,@PosNo,@StartDate,@EndDate,@TicketsAmount,@USERID,@TicketIdFrom,@TicketIdTo,@TicketsCount,@OrdersCount,@InputDateTime,@USERID,@_DocID2)

  Set @DocNote= CONCAT('Orpak Voucher From (PosNo:' , @PosNo , ', Shift No.:' , @WorkPeriod ,', Emp.:' , @Employee,')')  ;
  SET @DocCode= ( select Right(NEWID(),15));
  Set @DefaultCurr=( Select CurrID  from Currency where IsDefault=1  );
  Set @DocDate=@StartDate;
  Set @TempAccount=(Select TempAccounting from AccountingPOSNames where Id=@PosNo)
  Set @DocManualNo= @WorkPeriod 
  Set @TicketCode='';
  Set @VoucherNo = ( Select IsNull(Max(DocID)+1,1)  from Journal where DocName=2 );
  Declare @TicketID int;
  While (Select Count(*) From #@Temp1) > 0
  Begin
  Select Top 1 @TicketID = TicketID From #@Temp1 
  set @TicketAmount=( select TicketAmount from #@Temp1 where TicketID= @TicketID );
insert into Journal
       ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                       StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,
                                       CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,PosNo,DocNoteByAccount,VoucherDiscount,StockDiscount,LastDocCode,LastDataName,DocID2  ) 
                                       Select @VoucherNo,CAST(@DocDate AS DATE) ,2,3,@CostCenter,
                                       '0',I.AccSales,1,
                                       @DefaultCurr,O.sale,1,O.sale,O.sale,@DocManualNo,@DocNote,
                                       @USERID,@InputDateTime,O.product_code,IU.unit_id,O.Quantity,O.Quantity,
                                        O.ppv,O.ppv,0,@StockCreditWhereHouse,@USERID,
                                         0,N'',ItemName,@WorkPeriod,@DocCode,@PosNo,'',O.sale * @DiscountRatio,0 ,@TicketCode,'Orpak',@_DocID2
                                       from [dbo].OrpakTransactionsTemp O
									   left Join Items I on O.product_code=I.ItemNo
									   Left Join Items_units IU on IU.item_id=O.product_code And IU.main_unit=1
									   where O.id=@TicketID


Delete from #@Temp1 Where TicketID = @TicketID
End
Drop Table #@Temp1
Set @VouchersInJournalAmount=( select sum(DocAmount) from Journal where PosNo=@PosNo And ShiftID=@WorkPeriod And InputDateTime=@InputDateTime   )

insert into Journal
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,ShiftID,CurrentUserID,DocCode,PosNo,LastDocCode,LastDataName,DocID2  ) VALUES(
                                       @VoucherNo,CAST(@DocDate AS DATE) ,2,3,@CostCenter ,@TempAccount,
                                        '0',@DefaultCurr,1,@VouchersInJournalAmount,1,@VouchersInJournalAmount,
                                       @VouchersInJournalAmount,@DocManualNo,@DocNote,@USERID,@InputDateTime,
                                        0,N'',@WorkPeriod,@USERID,
                                        @DocCode,@PosNo,@TicketCode,'Orpak',@_DocID2)

Insert Into [ORPAK].[DATA].dbo.ttsShiftsReads ( ShiftID,EmployeeName ) values (@WorkPeriod,@Employee) 
update [ORPAK].[DATA].dbo.transactions Set proxy_id=1 where proxy_id=0 and shift_id=@WorkPeriod and mean_name=@Employee and fleet_id=200000000

return  @VouchersInJournalAmount
GO
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


CREATE TABLE [dbo].[OrpakFleetsChargeLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RefNo] [int] NOT NULL,
	[RefName] [nvarchar](50) NOT NULL,
	[ProcessName] [varchar](50) NOT NULL,
	[Amount] [float] NOT NULL,
	[LastBalance] [float] NOT NULL,
	[NewBalance] [float] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[InputDatetime] [datetime] NOT NULL,
	[UserID] [int] NOT NULL,
	[FleetID] [int] NOT NULL,
 CONSTRAINT [PK_OrpakFleetsChargeLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('HasOrpak','False',N' يوجد ربط مع اورباك ')
Go



WITH CTE AS (
SELECT [USERID],[CHECKTIME],
ROW_NUMBER() OVER (
PARTITION BY [USERID],[CHECKTIME]
ORDER BY [USERID],[CHECKTIME]
) row_num
FROM [AttCHECKINOUT]
)
DELETE FROM CTE
WHERE row_num > 1;
Go

ALTER TABLE [dbo].[AttCHECKINOUT] ADD CONSTRAINT num_values UNIQUE ([USERID],[CHECKTIME] )
Go

insert into  [dbo].[DocStatus]  (ID,DocStatus) values (0,N'ملغي')
Go







ALTER TABLE [dbo].[Journal] Add  [PaidStatus] int default 0
Go
ALTER TABLE [dbo].[JournalTemp] Add  [PaidStatus] int default 0
Go
ALTER TABLE [dbo].[POSJournal] Add [PaidStatus] int default 0
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [PaidStatus] int default 0
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [PaidStatus] int default 0
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add [PaidStatus] int default 0
Go
ALTER TABLE [dbo].[POSHoldJournal] Add [PaidStatus] int default 0
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add [PaidStatus] int default 0
Go

ALTER TABLE [dbo].[Journal] Add  [PaidAmount] int default 0
Go
ALTER TABLE [dbo].[JournalTemp] Add  [PaidAmount] int default 0
Go
ALTER TABLE [dbo].[POSJournal] Add [PaidAmount] int default 0
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [PaidAmount] int default 0
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [PaidAmount] int default 0
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add [PaidAmount] int default 0
Go
ALTER TABLE [dbo].[POSHoldJournal] Add [PaidAmount] int default 0
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add [PaidAmount] int default 0
Go

ALTER TABLE [dbo].[Journal] Add  [PaidByDocID] int default 0
Go
ALTER TABLE [dbo].[JournalTemp] Add  [PaidByDocID] int default 0
Go
ALTER TABLE [dbo].[POSJournal] Add [PaidByDocID] int default 0
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [PaidByDocID] int default 0
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [PaidByDocID] int default 0
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add [PaidByDocID] int default 0
Go
ALTER TABLE [dbo].[POSHoldJournal] Add [PaidByDocID] int default 0
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add [PaidByDocID] int default 0
Go






Update [dbo].[Journal] Set PaidStatus=0 where PaidStatus Is Null
Update [dbo].[Journal] Set PaidAmount=0 where PaidAmount Is Null
Update [dbo].[Journal] Set PaidByDocID=0 where PaidByDocID Is Null
Go

insert into Settings (SettingName,SettingValue) values ('ShowActionMenueAfterSaveDocuments','True')
Go

insert into Settings (SettingName,SettingValue,SettingDescription) values ('ShowActionMenueAfterSaveDocuments','True',N'عرض شاشة المهام بعد حفظ السندات')



CREATE TABLE [dbo].[OrpakMeansLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CardID] [int] NULL,
	[CardNo] [varchar](50) NULL,
	[UpdateNote] [nvarchar](max) NULL,
	[LastData] [nvarchar](max) NULL,
	[InputDateTime] [datetime] NULL,
	[UserNo] [int] NULL,
 CONSTRAINT [PK_OrpakMeansLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



Alter table [dbo].[PosShifts] add  [ReceiptsCash] decimal(18, 4) default 0
Go
Alter table [dbo].[PosShifts] add  [PaymentsCash] decimal(18, 4) default 0
Go
Alter table [dbo].[PosShifts] add  [Diff] float default 0
Go


insert into Settings (SettingName,SettingValue) values ('Alhuda','0')
Go

insert into Settings (SettingName,SettingValue,SettingDescription) values ('ShowItemCostInItemScreenUserForItemUsers','True',N'عرض سعر الشراء لمستخدم شاشة الاصناف')
Go

ALTER TABLE [dbo].[Referencess]  ADD [NameForMatjar] nvarchar(100) NULL 
Go

Update [dbo].[Referencess] Set NameForMatjar=RefName where NameForMatjar Is Null
Go

ALTER TABLE [dbo].[Citys]  ADD [PCODE] varchar(50) NULL 
Go

ALTER TABLE [dbo].[Referencess]  ADD [DiscountOnMatjar] int NULL 
Go
ALTER TABLE [dbo].[Referencess]  ADD [DeliveryCostOnMatjar]  int NULL 
Go

insert into Settings (SettingName,SettingValue,SettingDescription) values ('MatjarDefaultDiscount','10',N'الخصم الافتراضي لزبائن المتجر ')
Go
insert into Settings (SettingName,SettingValue,SettingDescription) values ('MatjarDefaultDeliveryCost','20',N' قيمة التوصيل لزبائن المتجر ')
Go
insert into Settings (SettingName,SettingValue,SettingDescription) values ('MatjarMinmountForZeroDeliveryCost','100',N' الحد الادنى لمجموع الفاتورة لاعتماد التوصيل صفر بالمتجر ')
Go

insert into Settings (SettingName,SettingValue,SettingDescription) values ('ShowDocNoInSalesDetailsReport','True',N' عرض رقم السند في تقرير تفاصيل المبيعات ')
Go

insert into Settings (SettingName,SettingValue,SettingDescription) values ('AttAllowAttUserToEditAttTrans','True',N' السماح لمستخدم مراقب الدوام بتعديل حركات الدوام ')
Go
insert into Settings (SettingName,SettingValue,SettingDescription) values ('AttAllowAttUserToAddAttTrans','True',N' السماح لمستخدم مراقب الدوام باضافة حركات الدوام ')
Go
insert into Settings (SettingName,SettingValue,SettingDescription) values ('AttAllowAttUserToDeleteAttTrans','True',N' السماح لمستخدم مراقب الدوام بحذف حركات الدوام ')
Go

insert into Settings (SettingName,SettingValue,SettingDescription) values ('OrpakMode','DirectMode',N' نظام اورباك  ')
Go

ALTER TABLE [dbo].[ShelvesReportTemp] Add [ItemNo3] varchar(100) NULL
Go

ALTER TABLE [dbo].[ShelvesReportTemp] Add [ItemNo4] varchar(100) NULL
Go

insert into Settings (SettingName,SettingValue,SettingDescription) values ('OrpakHasHeadOffice','False',N' نظام اورباك يحتوي على هيك اوفس  ')
Go


ALTER TABLE [dbo].[Items_units] ADD  CONSTRAINT [DF_Items_units_Measure]  DEFAULT ((0)) FOR [Measure]
GO
ALTER TABLE [dbo].[Items_units] ADD  CONSTRAINT [DF_Items_units_Color]  DEFAULT ((0)) FOR [Color]
GO
Update Items_units set Color=0 where Color is null;Update Items_units set Measure=0 where Measure is null

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('ShowBalanceColumnInVoucher','False',N' عرض عمود الرصيد في سندات البضاعة  ')
Go
Insert into Settings (SettingName,SettingValue,SettingDescription) values ('ShowLastPurchasePriceColumnInVoucher','False',N' عرض عمود اخر سعر شراء في سندات البضاعة  ')
Go

ALTER TABLE [dbo].[AttEmployeePayments] Add [Status] bit  Null
Go
ALTER TABLE [dbo].[AttEmployeePayments] ADD  CONSTRAINT [DF_Status]  DEFAULT ((0)) FOR [Status]
Go



ALTER PROCEDURE [dbo].[SambaAdjustment] @USERID int, @PosNo int,@WorkPeriod int,@StartDate varchar(20),@EndDate varchar(20)
AS
  Declare @TicketAmount as float;
  Declare @OrderAmount as float;
  Declare @VoucherNo int;
  Declare @DocDate date;
  Declare @DocDateAsDate date;
  Declare @CostCenter int;
  Declare @DefaultCurr int;
  Declare @DocNote nvarchar(Max);
  Declare @DocCode varchar(15);
  Declare @StockCreditWhereHouse int;
  Declare @DiscountRatio decimal(18, 4);
  Declare @TempAccount varchar(10);
  Declare @DocManualNo nvarchar(50) ;
  Declare @TicketCode varchar(50);
  Declare @TicketNo int;
  Declare @Temp1 varchar(10);
  Declare @Temp2 varchar(10);
  Declare @Produce bit;
  Declare @TicketsCount int;
  Declare @TicketsAmount int;
  Declare @TicketIdFrom int;
  Declare @TicketIdTo int;
  Declare @OrdersCount int;
  Declare @VouchersInJournalAmount float;
  Declare @InputDateTime as datetime;
  Declare @_DocID2 int;
  Set @Temp1=( select Right(NEWID(),5))
  Set @CostCenter=( Select CostCenter from AccountingPOSNames Where ID=@PosNo  );
  Set @StockCreditWhereHouse=( Select Warehouse from AccountingPOSNames Where ID=@PosNo  );
  Set @InputDateTime=GETDATE()
  select Id as TicketID,TotalAmount As TicketAmount,IsNull(OrderAmount,0) As OrderAmount,IsNull((OrderAmount-TotalAmount),0) As Diff, IsNull(Case when OrderAmount = 0 then 1 else (OrderAmount-TotalAmount)/OrderAmount end,0) As DiscountRatio
  Into   #@Temp1 from 
  (select Id,TotalAmount from [SambaTicketsTemp]) A left Join 
  (select O.[TicketId],sum([Amount]) As OrderAmount  from [SambaOrdersTemp] O  group by [TicketId]) B
  on A.Id=B.TicketId ;
  Set @TicketIdFrom =( Select Min(TicketID) from #@Temp1 );
  Set @TicketIdTo =( Select Max(TicketID) from #@Temp1 );
  Set @TicketsAmount =( Select Sum(TicketAmount) from #@Temp1 );
  Set @TicketsCount =( Select Count(TicketID) from #@Temp1 );
  Set @OrdersCount=( Select Count(ID) From SambaOrdersTemp )
  Set @_DocID2=cast(CONVERT(varchar(20),@InputDateTime,112) as INT )+@PosNo+@WorkPeriod ;
  Insert into [SambaReadingLog] ([PeriodID],[PosNo],[FromDate],[ToDate],[Amount],[UserName],[FromTicket],[ToTicket],[TicketsCount],[OrdersCount],[ReadDateTime],[ReadBy],DocID2) 
		  Values (@WorkPeriod,@PosNo,@StartDate,@EndDate,@TicketsAmount,@USERID,@TicketIdFrom,@TicketIdTo,@TicketsCount,@OrdersCount,@InputDateTime,@USERID,@_DocID2)
  Declare @TicketID int;
  While (Select Count(*) From #@Temp1) > 0
  Begin
  Select Top 1 @TicketID = TicketID From #@Temp1 
  set @TicketAmount=( select TicketAmount from #@Temp1 where TicketID= @TicketID );
  set @OrderAmount=( select OrderAmount from #@Temp1 where TicketId= @TicketID );
  Set @VoucherNo = ( Select IsNull(Max(DocID)+1,0)  from Journal where DocName=2 );
  Set @DocDate=(Select [Date] from [SambaTicketsTemp] where Id= @TicketID  );
  Set @DocDateAsDate=CAST(@DocDate AS DATE)
  Set @TicketNo=(Select TicketNumber from [SambaTicketsTemp] where Id= @TicketID  );
  Set @DefaultCurr=( Select CurrID  from Currency where IsDefault=1  );
  Set @DocNote= CONCAT('Samba Voucher From (PosNo:' , @PosNo , ' WorkPeriod No:' , @WorkPeriod ,' User:' , @USERID,' TicketNo:' ,@TicketNo,')')  ;
  SET @DocCode= ( select Right(NEWID(),15));
  Set @DiscountRatio=(Select DiscountRatio from  #@Temp1 where TicketID=@TicketID )
  Set @TempAccount=(Select TempAccounting from AccountingPOSNames where Id=@PosNo)
  Set @DocManualNo= @TicketID 
  Set @TicketCode=(Select LEFT([TicketCode],50) TicketCode from SambaTicketsTemp where Id=@TicketID);
insert into Journal
       ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                       StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,
                                       CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,PosNo,DocNoteByAccount,VoucherDiscount,StockDiscount,LastDocCode,LastDataName,DocID2  ) 
                                       Select @VoucherNo,CAST(@DocDate AS DATE) ,2,1,@CostCenter,
                                       '0',I.AccSales,1,
                                       @DefaultCurr,O.Amount-O.Amount*@DiscountRatio,1,O.Amount-O.Amount*@DiscountRatio,O.Amount-O.Amount*@DiscountRatio,@DocManualNo,@DocNote,
                                       @USERID,@InputDateTime,I.ItemNo,IU.unit_id,O.Quantity,IU.EquivalentToMain*O.Quantity,
                                        O.Price,O.Price,0,@StockCreditWhereHouse,@USERID,
                                         0,N'',ItemName,@WorkPeriod,@DocCode,@PosNo,'',O.Amount * @DiscountRatio,0 ,@TicketCode,'Samba',@_DocID2
                                       from [dbo].SambaOrdersTemp O
									   Left Join Items_units IU on IU.item_unit_bar_code=O.Barcode And IU.main_unit=1
									   left Join Items I on IU.item_id=I.ItemNo
									   where O.TicketId=@TicketID
insert into Journal
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,ShiftID,CurrentUserID,DocCode,PosNo,LastDocCode,LastDataName,DocID2  ) VALUES(
                                       @VoucherNo,CAST(@DocDate AS DATE) ,2,1,@CostCenter ,@TempAccount,
                                        '0',@DefaultCurr,1,@TicketAmount,1,@TicketAmount,
                                       @TicketAmount,@DocManualNo,@DocNote,@USERID,@InputDateTime,
                                        0,N'',@WorkPeriod,@USERID,
                                        @DocCode,@PosNo,@TicketCode,'Samba',@_DocID2)

Delete from #@Temp1 Where TicketID = @TicketID
End
Set @Temp2=( select Right(NEWID(),5))
--Select T.Id,Barcode,MenuItemName,Quantity,I.HasProductionEquation  Into #@Temp2 from SambaOrdersTemp T left join items I on I.ItemNo=T.Barcode where HasProductionEquation=1
Select T.Id,Barcode,MenuItemName,Quantity,I.HasProductionEquation  Into #@Temp2 from SambaOrdersTemp T left join Items_units IU on IU.item_unit_bar_code=T.Barcode left join Items I on IU.item_id=I.ItemNo where HasProductionEquation=1
Declare @Barcode varchar(100)
Declare @OrderID int;
While (Select Count(*) From #@Temp2) > 0
Begin
	Select Top 1 @OrderID = Id From #@Temp2 
	Declare @RowQuantity float;
	Declare @Unit int;
	Declare @RowItemName nvarchar(100);
	Declare @OrderNote nvarchar(1000);
	Declare @ItemNo int;
	set @Barcode= (Select Barcode from #@Temp2 where id=@OrderID)
	set @ItemNo = ( select item_id from Items_units where item_unit_bar_code=@Barcode )
	Set @RowQuantity=( Select Quantity from #@Temp2 where id=@OrderID );
	Set @Unit=( Select unit_id from Items_units where item_id=@ItemNo and main_unit=1 )
	Set @RowItemName=( select MenuItemName from #@Temp2 where id=@OrderID )
	Set @TicketNo=( select @TicketNo from #@Temp2 where id=@OrderID )
	Set @OrderNote=CONCAT('Samba Voucher From (PosNo:' , @PosNo , ' WorkPeriod No:' , @WorkPeriod ,' User:' , @USERID,' TicketNo:' ,@TicketNo,')')  ;
EXEC  [dbo].[ProduceItem] @ItemNo=@ItemNo,@UserID=1,@Quantity=@RowQuantity,@Unit=@Unit,@CostCenter=@CostCenter,@WahreHouse=@StockCreditWhereHouse,@BarCode=0,@PosNo=@PosNo,@DeviceName='Auto',@ItemName=@RowItemName,@Referance=0,@ReferanceName='',@DocNote=@OrderNote,@LastDocCode=@DocCode,@DocID2=@_DocID2,@DocDate=@DocDateAsDate;
	Delete from #@Temp2 Where Id = @OrderID
End
Drop Table #@Temp2
Drop Table #@Temp1
Set @VouchersInJournalAmount=( select sum(DocAmount) from Journal where PosNo=@PosNo And ShiftID=@WorkPeriod And InputDateTime=@InputDateTime  )
return  @VouchersInJournalAmount
GO



insert into Settings (SettingName,SettingValue,SettingDescription) values ('AttPrintAttendantReportLandscape','True',N'طباعة كشف الدوام بشكل عرضي')
Go
insert into Settings (SettingName,SettingValue,SettingDescription) values ('AttPrintAttendantReportNarrowLine','True',N'عمل تضييق للسطر عند طباعة كشف الدوام')
Go
insert into Settings (SettingName,SettingValue,SettingDescription) values ('AttPrintAttendantReportShowEmpID','True',N'طباعة الرقم الوظيفي في كشف الدوام')
Go
insert into Settings (SettingName,SettingValue,SettingDescription) values ('AttScaleAttendantReport','95',N' تعديل Scale عند طباعة كشوفات الدوام ')
Go


ALTER TABLE Items        ADD WithAdditions Bit NULL  CONSTRAINT D_Items_WithAdditions     DEFAULT (0)
Go
Update Items Set WithAdditions=0 where WithAdditions Is Null
Go







CREATE TABLE [dbo].[ItemsPortions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemNo] [int] NOT NULL,
	[PortionName] [nvarchar](50) NOT NULL,
	[ItemPrice] [decimal](18, 2) NOT NULL,
	[AddOrRemove] [nvarchar](50) NULL,
 CONSTRAINT [PK_ItemsPortions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ItemsPortions] ADD  CONSTRAINT [DF_ItemsPortions_PortionName]  DEFAULT ('') FOR [PortionName]
GO

ALTER TABLE [dbo].[ItemsPortions] ADD  CONSTRAINT [DF_ItemsPortions_ItemPrice]  DEFAULT ((0)) FOR [ItemPrice]
GO

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('SmsWhatsAppAPI','',N' API رسائل الواتس اب WhatsApp API  ')
Go

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('AllowCancelPostedDocuments','False',N' السماح بالغاء السندات المرحلة  ')
Go



CREATE TABLE [dbo].[EmployeesAccess](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[AccessName] [nvarchar](50) NOT NULL,
	[AccessValue] [bit] NOT NULL,
 CONSTRAINT [PK_EmployeesAccess] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC,
	[AccessName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[VehiclesReceiptDeliveryEmloyees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocDate] [datetime] NOT NULL,
	[DocStatus] [int] NOT NULL,
	[EmployeeNo] [int] NOT NULL,
	[DocNote] [nvarchar](max) NOT NULL,
	[CarID] [int] NOT NULL,
 CONSTRAINT [PK_VehiclesReceiptDelivery] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[VehiclesReceiptDeliveryEmloyees] ADD  CONSTRAINT [DF_VehiclesReceiptDelivery_DocNote]  DEFAULT ('') FOR [DocNote]
GO

ALTER TABLE [dbo].[Vehicle Maintenance]  ADD [Paid] bit NULL 
Go

ALTER TABLE [dbo].[Vehicle Maintenance] ADD  CONSTRAINT [DF_Vehicle Maintenance_Paid]  DEFAULT ((0)) FOR [Paid]
GO

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('UseBatch','False',N' استخدام الباتش (تاريخ الانتهاء) في سندات البضاعة  ')
Go

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('POSDefineNewItemInPos','False',N' السماح بتعريف اصناف جديدة من نقطة البيع  ')
Go

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('PosStretchGroupItems','True',N' عرض مجموعات الاصناف كل مجموعة في سطر في نقطة البيع  ')
Go


ALTER TABLE [dbo].[CompanyData]
Add   [CompanyNameForWhattsUp] [nvarchar] (Max)  NULL
Go


ALTER TABLE [dbo].[Checks] Add   [AppointmentsRef] [int]  NULL
Go  
ALTER TABLE [dbo].[Checks] ADD  CONSTRAINT [DF_Checks_AppointmentsRef]  DEFAULT ((0)) FOR [AppointmentsRef]
GO
Update [dbo].[Checks] Set [AppointmentsRef]=0 where [AppointmentsRef] Is Null
Go

Update Settings Set SettingValue='https://api.ultramsg.com/instance49137/messages/chat?token=agqyg0fjmwz8c03a&to=#MobileNo#&body=#Message#&priority=10' where SettingName='SmsWhatsAppAPI'
Go


Insert into Settings (SettingName,SettingValue,SettingDescription) values ('AccountingDateStartFromCurrentMonthInAccountStatment','True',N' تاريخ بداية التقرير هو بداية الشهر الحالي في كشف حساب الذمم والحسابات  ')
Go

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('ShowRefNameWhenForwardCheques','False',N' عرض اسم الزبون في الملاحظة عند تجيير الشيكات  ')
Go

INSERT INTO [CheksTransTypes] ([TransID],[TransTypeEng],[TransTypeAr],[TransInOut]) vALUES (9,'ReturnForwardCheque',N'اعادة شيك مجير','In')
Go



ALTER TABLE Items  ADD SaleOnSamba Bit NULL  CONSTRAINT D_Items_SaleOnSamba DEFAULT (0)
Go
Update Items Set SaleOnSamba=0 where SaleOnSamba Is Null
Go

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('CreateBarcodeWhenItemUnitWhithoutBarcode','True',N' توليف باركود تلقائي في شاشة تعريف الصنف في حال عدم ادخال باركود في خانة الباركود  ')
Go

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('PosShowColOpenItemInItemsList','False',N' عرض عمود فتح بطاقة الصنف في قائمة الاصناف في نقطة البيع  ')
Go
Insert into Settings (SettingName,SettingValue,SettingDescription) values ('PosShowColOpenInReferanceList','False',N' عرض عمود فتح بيانات الزبون في قائمة الزبائن في نقطة البيع  ')
Go
Insert INTO ChecksStatus (CheckStatus,CheckInOutType,ID) values ( N'مسحوب نقدا', 'In',11 )
Go


ALTER TABLE EmployeesData ADD [CalAbsentInSalary] BIT  NULL CONSTRAINT DF_EmployeesData_CalAbsentInSalary DEFAULT 1;
Go
Update [dbo].[EmployeesData] set [CalAbsentInSalary]=1 where [CalAbsentInSalary] Is Null
Go

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('PosPlayBeep','True',N' تشغيل الصوت عند عملية اختيار الصنف  ')
Go

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('AttInMonthSalaryAdjustmentsCalcRequHouresFromEmployee','False',N' في المعالجة الشهرية للراتب، اعتماد عدد الساعات المطلوبة من بيانات الموظف  ')
Go

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('POSCheckSendClosedShiftToMobile','False',N' ارسال تقرير اغلاق الوردية على الواتس  ')
Go

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('POSNumbersToSendClosedShift','',N' الارقام التي سيتم ارسال لها تقرير انهاء الوردية  ')
Go

ALTER TABLE Items  ADD RequirePriceInPOS Bit NULL  CONSTRAINT D_Items_RequirePriceInPOS DEFAULT (0)
Go
Update Items Set RequirePriceInPOS=0 where RequirePriceInPOS Is Null
Go


Insert Into [EmployeesAccess] ([EmployeeID],[AccessName],[AccessValue]) values (1,'ShowItemCost',1)
Go

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('ShowSavePrintPostAfterSaveDocument','True',N' عرض قائمة الطباعة والترحيل بعد عملية حفظ السند  ')
Go

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('ShowPostButtonsInSavePrintPostDocument','False',N' عرض خيار الترحيل في قائمة الطباعة والترحيل بعد حفظ السند  ')
Go

UPDATE [BanksAccounts]
SET BankID = CASE WHEN ISNUMERIC (BankID) = 1 THEN
  CASE WHEN CAST (BankID AS FLOAT) = CAST (CAST (BankID AS FLOAT) AS INT) THEN
    CAST (BankID AS INT)
  ELSE
    NULL -- or some default value
  END
ELSE
  NULL -- or some default value
END

UPDATE [BanksAccounts]
SET BranchID = CASE WHEN ISNUMERIC (BranchID) = 1 THEN
  CASE WHEN CAST (BranchID AS FLOAT) = CAST (CAST (BranchID AS FLOAT) AS INT) THEN
    CAST (BranchID AS INT)
  ELSE
    NULL -- or some default value
  END
ELSE
  NULL -- or some default value
END


ALTER TABLE EmployeesData ADD [DefaultCostCenter] int  NULL CONSTRAINT DF_EmployeesData_DefaultCostCenter DEFAULT 1;
Go
Update [dbo].[EmployeesData] set [DefaultCostCenter]=1 where [DefaultCostCenter] Is Null
Go


ALTER TABLE [CostCenter] 
ADD [CostCenterTypeID] INT NULL 
CONSTRAINT DF_CostCenter_CostCenterTypeID DEFAULT 1;
GO

-- Populate default values for existing rows
UPDATE [CostCenter]
SET [CostCenterTypeID] = 1
WHERE [CostCenterTypeID] IS NULL;
GO

CREATE TABLE [dbo].[CostCenterTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_CostCenterTypes] PRIMARY KEY CLUSTERED 
(
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS (SELECT 1 FROM CostCenterTypes)
BEGIN
    DECLARE @InsertedIDs TABLE ([ID] INT);
    INSERT INTO CostCenterTypes ( [Type])
    OUTPUT inserted.[ID] INTO @InsertedIDs
    VALUES
        ( N'رئيسي')
   Update CostCenter set CostCenterTypeID=(SELECT top(1) [ID] FROM @InsertedIDs)
END
Go



ALTER TABLE Journal ADD CONSTRAINT DF_Journal DEFAULT 0 FOR TarteebID;

Go

ALTER TABLE JournalTemp ADD TarteebID INT DEFAULT 0;

Go

-- جداول الجرد
CREATE TABLE [dbo].[JardJournal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemBarcode] [nvarchar](50) NOT NULL,
	[ItemNo] [int] NOT NULL,
	[ItemName] [nvarchar](100) NOT NULL,
	[ItemUnit] [int] NOT NULL,
	[ItemQuantity] [decimal](18, 3) NOT NULL,
	[ItemPrice] [float] NOT NULL,
	[UserID] [int] NOT NULL,
	[DocStatus] [int] NOT NULL,
	[InputDateTimeByItem] [datetime] NOT NULL,
	[DocNoteByItem] [nvarchar](max) NOT NULL,
	[DeviceName] [nvarchar](max) NOT NULL,
	[SessionID] [int] NOT NULL,
	[DocID] [int] NOT NULL,
 CONSTRAINT [PK_JardJournal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[JardJournal] ADD  CONSTRAINT [DF_JardJournal_ItemBarcode]  DEFAULT ((0)) FOR [ItemBarcode]
GO

ALTER TABLE [dbo].[JardJournal] ADD  CONSTRAINT [DF_JardJournal_ItemPrice]  DEFAULT ((0)) FOR [ItemPrice]
GO

ALTER TABLE [dbo].[JardJournal] ADD  CONSTRAINT [DF_JardJournal_DocStatus]  DEFAULT ((1)) FOR [DocStatus]
GO

ALTER TABLE [dbo].[JardJournal] ADD  CONSTRAINT [DF_JardJournal_InputDateTimeByItem]  DEFAULT (getdate()) FOR [InputDateTimeByItem]
GO

ALTER TABLE [dbo].[JardJournal] ADD  CONSTRAINT [DF_JardJournal_DocNoteByItem]  DEFAULT ('') FOR [DocNoteByItem]
GO

ALTER TABLE [dbo].[JardJournal] ADD  CONSTRAINT [DF_JardJournal_DeviceName]  DEFAULT ('') FOR [DeviceName]
GO

CREATE TABLE [dbo].[JardJournalList](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocDate] [datetime] NOT NULL,
	[DocName] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[DocStatus] [int] NOT NULL,
	[DocNote] [nvarchar](max) NOT NULL,
	[DeviceName] [varchar](max) NOT NULL,
	[SessionID] [int] NOT NULL,
 CONSTRAINT [PK_JardJournalList] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO




CREATE TABLE [dbo].[JardSavedSessions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StockID] [int] NULL,
	[ItemName] [nvarchar](max) NULL,
	[GroupName] [nvarchar](max) NULL,
	[TradeMarkName] [nvarchar](max) NULL,
	[CategoryName] [nvarchar](max) NULL,
	[balance] [float] NULL,
	[LastPurchasePrice] [float] NULL,
	[ItemCostAmount] [float] NULL,
	[Price1] [float] NULL,
	[ItemPriceAmount] [float] NULL,
	[HasTrans] [varchar](50) NULL,
	[QuantityByMainUnitInJard] [float] NULL,
	[AdjustingQuantity] [float] NULL,
	[AdjustingAmount] [float] NULL,
	[Settle] [bit] NULL,
	[InDocNo] [int] NULL,
	[OutDocNo] [int] NULL,
	[SessionID] [int] NULL,
	[SavedDate] [datetime] NULL,
	[UserID] [int] NULL,
	[MainUnitID] [int] NULL,
	[UnitName] [nvarchar](100) NULL,
	[Edited] [bit] NULL,
 CONSTRAINT [PK_JardSavedSessions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[JardSavedSessions] ADD  CONSTRAINT [DF_JardSavedSessions_Settle]  DEFAULT ((0)) FOR [Settle]
GO

ALTER TABLE [dbo].[JardSavedSessions] ADD  CONSTRAINT [DF_JardSavedSessions_InDocNo]  DEFAULT ((0)) FOR [InDocNo]
GO

ALTER TABLE [dbo].[JardSavedSessions] ADD  CONSTRAINT [DF_JardSavedSessions_OutDocNo]  DEFAULT ((0)) FOR [OutDocNo]
GO

ALTER TABLE [dbo].[JardSavedSessions] ADD  CONSTRAINT [DF_JardSavedSessions_SavedDate]  DEFAULT (getdate()) FOR [SavedDate]
GO

ALTER TABLE [dbo].[JardSavedSessions] ADD  CONSTRAINT [DEFAULT_JardSavedSessions_Edited]  DEFAULT ((0)) FOR [Edited]
GO


CREATE TABLE [dbo].[JardSessions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SessionDetails] [nvarchar](max) NOT NULL,
	[SessionStatus] [bit] NOT NULL,
	[SessionDate] [date] NOT NULL,
	[SessionWareHouse] [int] NOT NULL,
 CONSTRAINT [PK_JardSessions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[JardSessions] ADD  CONSTRAINT [DF_JardSessions_SessionDetails]  DEFAULT ('') FOR [SessionDetails]
GO

ALTER TABLE [dbo].[JardSessions] ADD  CONSTRAINT [DF_JardSessions_SessionStatus]  DEFAULT ((0)) FOR [SessionStatus]
GO

ALTER TABLE [dbo].[JardSessions] ADD  CONSTRAINT [DF_JardSessions_SessionWareHouse]  DEFAULT ((1)) FOR [SessionWareHouse]
GO



CREATE PROCEDURE [dbo].[InsertDataFromTempToJournal] @DocName int,@DocCode varchar(50),@UserID int,@DeviceName varchar(255) ,@_DocID int,@DocID INT OUTPUT
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
	IF @_DocID = 0
		Begin
	    SELECT @DocID = ISNULL(max(DocID),0)+1 FROM journal WITH (TABLOCKX, HOLDLOCK) where DocName=@DocName ;
		End
	Else
		Begin
		Set @DocID=@_DocID
	End
	Insert into Journal ([DocID],[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,ModifiedDateTime,StockID,StockUnit,
                                                [StockQuantity],[StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                               [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,
                                                DeliverDate,Color,Measure,StockDiscount,VoucherDiscount,ItemVAT,[StockDebitShelve],
                                                StockCreditShelve,DocNoteByAccount,SalesPerson,DeviceName,ItemNo2,OrderID,StockDriver,StockCarNo,LastPurchasePrice,BatchID,PaidStatus,PaidAmount,PaidByDocID)
    Select  @DocID,[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,ModifiedDateTime,StockID,StockUnit,
                                                [StockQuantity],[StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                                [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,
                                                DeliverDate,Color,Measure,StockDiscount,VoucherDiscount,ItemVAT,[StockDebitShelve],
                                                StockCreditShelve,DocNoteByAccount,SalesPerson,DeviceName,ItemNo2,OrderID,StockDriver,StockCarNo,LastPurchasePrice,BatchID,PaidStatus,PaidAmount,PaidByDocID
    from JournalTemp 
	where DocCode=@DocCode and CurrentUserID=@UserID and DeviceName=@DeviceName;
COMMIT;
        --SELECT top 1 @_DocID AS DocID;
END TRY

BEGIN CATCH
	ROLLBACK; -- Rollback the transaction
	Set @DocID=0
END CATCH;
delete from JournalTemp where  DocName=@DocName and DocCode=@DocCode and CurrentUserID=@UserID;
select @DocID

END;
Go

-- اضافة حقل اختساب الاضافي بعد عدد من الدقائق لموظفي الساعات المطلوبة
ALTER TABLE [dbo].[EmployeesData] Add [CalcBonusAfterMinutesInReqHoures] int  Null
Go
ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_CalcBonusAfterMinutesInReqHoures]  DEFAULT ((0)) FOR [CalcBonusAfterMinutesInReqHoures]
Go
Update [dbo].[EmployeesData] Set [CalcBonusAfterMinutesInReqHoures]=0 where [CalcBonusAfterMinutesInReqHoures] is Null
GO

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('SubtractAbsenceFromHolidays','False',N' خصم الغياب من العطل الرسمية  ')
Go

Update FinancialAccounts Set IsMain=1 where AccNo='5010000000'
Go

Update FinancialAccounts Set IsMain=1 where AccNo='5010100000'
Go

CREATE TABLE [dbo].[Samba_ShishaReportSales](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SalesSUM] [decimal](18, 2) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[DateFrom] [date] NOT NULL,
	[DateTo] [date] NOT NULL,
	[PercentageOfTotal] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Samba_ShishaReportSales] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC,
	[DateFrom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Samba_ShishaReportCostOfSales](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[TotalCost] [decimal](18, 2) NOT NULL,
	[DateFrom] [date] NOT NULL,
	[DateTo] [date] NOT NULL,
	[PercentageOfTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Samba_ShishaReportCostOfSales] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC,
	[DateFrom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Samba_ShishaExpensesAllocationDefine](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountNo] [nvarchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Percantage] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Samba_ShishaExpensesAllocationDefine] PRIMARY KEY CLUSTERED 
(
	[AccountNo] ASC,
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Samba_ShishaExpensesAllocationAmounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountNo] [nvarchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[TotalCost] [decimal](18, 2) NOT NULL,
	[DateFrom] [date] NOT NULL,
	[DateTo] [date] NOT NULL,
 CONSTRAINT [PK_Samba_ShishaExpensesAllocationAmounts] PRIMARY KEY CLUSTERED 
(
	[AccountNo] ASC,
	[CategoryID] ASC,
	[DateFrom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Samba_ShishaExpensesAllocationAmounts2](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AccountNo] [nvarchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
	[TotalCost] [decimal](18, 2) NOT NULL,
	[DateFrom] [date] NOT NULL,
	[DateTo] [date] NOT NULL,
 CONSTRAINT [PK_Samba_ShishaExpensesAllocationAmounts2] PRIMARY KEY CLUSTERED 
(
	[AccountNo] ASC,
	[CategoryID] ASC,
	[DateFrom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



Insert into Settings (SettingName,SettingValue,SettingDescription) values ('GenarateAutoBarcodeWhenSaveNewItem','True',N'  توليف تلقائي للباركود عند حفظ صنف جديد   ')
Go
Delete From  Settings where SettingName=N'CreateBarcodeWhenItemUnitWhithoutBarcode'
Go

Insert into Settings (SettingName,SettingValue,SettingDescription) values ('Jira_Email','user@company.ps',N'  ايميل لجلب الحركات من موقع JIRA   ')
Go
Insert into Settings (SettingName,SettingValue,SettingDescription) values ('Jira_Token','xxyyxx',N'  التوكن Token لجلب الحركات من موقع JIRA    ')
Go
Insert into Settings (SettingName,SettingValue,SettingDescription) values ('Jira_URL','https://company.atlassian.net',N' Url لجلب الحركات من موقع  JIRA ')
Go




ALTER TABLE Vocations ADD InputDateTime DATETIME DEFAULT GETDATE()
Go
ALTER TABLE [AttEmployeePayments] ADD InputDateTime DATETIME DEFAULT GETDATE()
Go
ALTER TABLE [AttEmployeeAdditions] ADD InputDateTime DATETIME DEFAULT GETDATE()
Go

ALTER TABLE [Samba_ShishaExpensesAllocationDefine] ADD PercantageFromSales bit DEFAULT 0
Go


Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('Att_DefualtDiscountTypeID','1',N' نوع الخصم الافتراضي ')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('Att_DefualtAdditionTypeID','1',N' نوع الاضافي الافتراضي ')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('Att_ShowProductionColumnInAttReports','False',N' عرض عمود الانتاج في شاشة الموظف ')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('Att_ShowProductionTimeSpanColumnInAttReports','False',N' عرض عمود الانتاج حسب الوقت في شاشة الموظف ')
Go


CREATE TABLE [dbo].[JIRA_worklogs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[WorklogID] [int] NOT NULL,
	[Started] [datetime] NULL,
	[TimeSpent] [varchar](50) NULL,
	[Author] [nvarchar](100) NULL,
	[timeSpentSeconds] [decimal](18, 2) NULL,
	[timeSpentHoures] [decimal](18, 2) NULL,
	[Created] [datetime] NULL,
	[Updated] [datetime] NULL,
	[IssueId] [int] NULL,
	[Key] [nvarchar](100) NULL,
	[NoteContent] [nvarchar](100) NULL,
	[EmployeeID] [int] NULL,
	[EmployeeName] [nvarchar](100) NULL,
	[SalaryByProductionID] [int] NULL,
	[InputDateTime] [datetime] NULL,
 CONSTRAINT [PK_JIRA_worklogs] PRIMARY KEY CLUSTERED 
(
	[WorklogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[JIRA_worklogs] ADD  CONSTRAINT [DF_JIRA_worklogs_SalaryByProductionID]  DEFAULT ((0)) FOR [SalaryByProductionID]
GO

ALTER TABLE [dbo].[JIRA_worklogs] ADD  CONSTRAINT [DF_JIRA_worklogs_InputDateTime]  DEFAULT (getdate()) FOR [InputDateTime]
GO


CREATE TABLE [dbo].[JIRA_worklogsTemp](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[WorklogID] [int] NULL,
	[Started] [datetime] NULL,
	[TimeSpent] [varchar](50) NULL,
	[Author] [nvarchar](100) NULL,
	[timeSpentSeconds] [decimal](18, 2) NULL,
	[Created] [datetime] NULL,
	[IssueId] [int] NULL,
	[Key] [varchar](50) NULL,
	[Houres] [decimal](18, 2) NULL
) ON [PRIMARY]
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('ShowRefMobileInDocuments','False',N' عرض رقم الموبايل للذمة في سندات المحاسبة ')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('DefaultMethodToSendMessagesIsWhatsApp','True',N' الطريقة الافتراضية للارسال الرسائل هي الواتس اب ')
Go


 Update CostCenter Set CostCenterTypeID=1 where CostCenterTypeID Is Null
 Go

 Update [dbo].[Journal] Set DocCostCenter =1 where DocCostCenter=''
 Go

ALTER TABLE [dbo].[Referencess] Add SalesMan [int] NULL
Go
ALTER TABLE [dbo].[Referencess] ADD  CONSTRAINT [DF_Referencess_SalesMan]  DEFAULT ((0)) For [SalesMan]
GO

ALTER TABLE [SubscriptionDoc] Add  PaidStatus Int;
Go
ALTER TABLE [dbo].[SubscriptionDoc] ADD  CONSTRAINT [DF_SubscriptionDoc_PaidStatus]  DEFAULT ((0)) For [PaidStatus]
GO
Insert INTO ChecksStatus (CheckStatus,CheckInOutType,ID) values ( N'ملغي', 'In',12 )
Go
ALTER TABLE [dbo].[EmployeesData] Add 	[WebPassEnc] [nvarchar](max) NULL
Go
ALTER TABLE [dbo].[EmployeesData] Add 	[ManagerIDForWeb] Int NULL
Go

CREATE TABLE [dbo].[SambaOrdersTempForReport](
	[MenuItemId] [int] NULL,
	[MenuItemName] [nvarchar](max) NULL,
	[Price] [decimal](16, 2) NULL,
	[Quantity] [decimal](18, 2) NULL,
	[Amount] [float] NULL,
	[Barcode] [nvarchar](max) NULL,
	[UserID] [int] NULL,
	[WorkPeriod] [int] NULL,
	[TicketId] [int] NULL,
	[Id] [int] NULL,
	[TicketNumber] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[CostCenter] Add 	[CostCenterImage] [image] NULL
Go
ALTER TABLE [dbo].[CostCenter] Add 	[StartDate] [date] NULL
Go
ALTER TABLE [dbo].[CostCenter] Add 	[EndDate] [date] NULL
Go
ALTER TABLE [dbo].[CostCenter] Add 	[Notes] [nvarchar] (Max) NULL
Go
ALTER TABLE [dbo].[CostCenter] Add 	[CostCenterStatus] [bit] NULL
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('WhatsAppGreenAPI','',N' URL for APIGreen ')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('WhatsAppGreenAPISendFile','',N' URL for APIGreen To Send File ')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('WhatsAppGreenInstanceID','',N' InstanceID for APIGreen ')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('WhatsAppGreenToken','',N' Token for APIGreen ')
Go
Declare @Instance varchar(500)
Set @Instance = ( select SettingValue  from Settings where SettingName='WhatsAppGreenAPI' )
IF @Instance = ''
BEGIN
    UPDATE [Settings]    SET SettingValue = 'http://whatsapi.truetime.top:5051/Send'   WHERE SettingName='WhatsAppGreenAPI' 
	UPDATE [Settings]    SET SettingValue = 'http://whatsapi.truetime.top:5051/Send'   WHERE SettingName='WhatsAppGreenAPISendFile'
	UPDATE [Settings]    SET SettingValue = '0'										   WHERE SettingName='WhatsAppGreenInstanceID' 
	UPDATE [Settings]    SET SettingValue = 'tts'								       WHERE SettingName='WhatsAppGreenToken' 
END


Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('PosRoundVoucherNearInteger','False',N' في نقطة البيع تقريب مبلغ الفاتورة لأقرب عدد صحيح ')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('PosRoundVoucherToDownInteger','False',N' في نقطة البيع تقريب مبلغ الفاتورة لأقل عدد صحيح ')
Go
ALTER TABLE [Referencess] Add   [ContactPerson] [nvarchar] (200)  NULL
Go
ALTER TABLE [dbo].[Referencess] ADD  CONSTRAINT [DF_Referencess_ContactPerson]  DEFAULT ('') For [ContactPerson]
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('PosShowItlafButton','False',N' عرض زر الاتلاف ')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('PosShowGiftButton','False',N' عرض زر الهدايا ')
Go

ALTER TABLE [dbo].[EmployeesData] Add [SalaryPerDay] decimal  NULL
Go

ALTER TABLE ItemsGroups ADD [DefaultPrinter] NVARCHAR(Max)
Go

ALTER TABLE [AccountingPOSNames] ADD Kitchen_printer NVARCHAR(Max) DEFAULT ''
Go

ALTER TABLE [PosShifts] ADD GiftAmount Decimal(18,2) DEFAULT '0'
Go
ALTER TABLE [PosShifts] ADD ItlafAmount Decimal(18,2) DEFAULT '0'
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('ShowBarVoucherStatusInDocuments','False',N' عرض شريط الحالة في السندات ')
Go


CREATE TABLE [dbo].[AttPlanForRequiredHours](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AttTransDate] [date] NOT NULL,
	[PlanCode] [int] NULL,
	[Location] [int] NULL,
	[Notes] [nvarchar](100) NULL,
	[InputDateTime] [datetime] NULL,
	[RequiredHoures] varchar(10),
 CONSTRAINT [PK_AttPlanForRequiredHours] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [PK_SamePlanCodeForDate] UNIQUE NONCLUSTERED 
(
	[AttTransDate] ASC,
	[PlanCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



ALTER TABLE [AttRawatebArchive] ADD [SalaryNote] Nvarchar(Max) DEFAULT ''
Go

ALTER TABLE [AttRawatebArchive] ADD [LeavesIsAdjusted] Bit DEFAULT 0
Go


CREATE TABLE [dbo].[AttRawatebArchiveAdjustmentLogs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DocID] [int] NOT NULL,
	[InputDatetime] [datetime] NOT NULL,
	[InputUser] [int] NOT NULL,
	[LastLeavesTimeSpan] [varchar](10) NOT NULL,
	[TransType] [varchar](50) NOT NULL,
	[LastLeavesAmount] [float] NULL,
	[VocID] [int] NULL,
 CONSTRAINT [PK_AttRawatebArchiveAdjustmentLogs] PRIMARY KEY CLUSTERED 
(
	[DocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AttRawatebArchiveAdjustmentLogs] ADD  CONSTRAINT [DF_AttRawatebArchiveAdjustmentLogs_InputDatetime]  DEFAULT (getdate()) FOR [InputDatetime]
GO


CREATE TABLE [dbo].[AttMonthlyAdjustments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Month] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[EmpID] [int] NOT NULL,
	[ProcessType] [varchar](50) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Priod] [varchar](10) NOT NULL,
	[VocDocID] [int] NOT NULL,
	[AdditionDocID] [int] NOT NULL,
	[PaymentDocID] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[InputUser] [int] NULL,
	[InputDateTime] [datetime] NULL,
 CONSTRAINT [PK_AttMonthlyAdjustments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AttMonthlyAdjustments] ADD  CONSTRAINT [DF_AttMonthlyAdjustments_Amount]  DEFAULT ((0)) FOR [Amount]
GO

ALTER TABLE [dbo].[AttMonthlyAdjustments] ADD  CONSTRAINT [DF_AttMonthlyAdjustments_VocDocID]  DEFAULT ((0)) FOR [VocDocID]
GO

ALTER TABLE [dbo].[AttMonthlyAdjustments] ADD  CONSTRAINT [DF_AttMonthlyAdjustments_AdditionDocID]  DEFAULT ((0)) FOR [AdditionDocID]
GO

ALTER TABLE [dbo].[AttMonthlyAdjustments] ADD  CONSTRAINT [DF_AttMonthlyAdjustments_PaymentDocID]  DEFAULT ((0)) FOR [PaymentDocID]
GO

ALTER TABLE [dbo].[AttMonthlyAdjustments] ADD  CONSTRAINT [DF_AttMonthlyAdjustments_InputDateTime]  DEFAULT (getdate()) FOR [InputDateTime]
GO


Update [AttRawatebArchive] set Currency=1 Where Currency ='' Or  Currency Is Null
Update EmployeesData set SalaryCurrency=1 Where SalaryCurrency ='' Or  SalaryCurrency Is Null
Go



ALTER TABLE [AttEmployeePayments] DROP CONSTRAINT DF_Status;
Go
ALTER TABLE [AttEmployeePayments] ALTER COLUMN [Status] INT;
Go
UPDATE [AttEmployeePayments] SET [Status] = CASE WHEN [Status] = 1 THEN 1 ELSE 0 END;
Go




CREATE TABLE [dbo].[DocumentsSignatures](
	[DocNameEN] [nvarchar](100) NOT NULL,
	[DocNameAR] [nvarchar](100) NULL,
	[Signature1] [nvarchar](100) NULL,
	[Signature2] [nvarchar](100) NULL,
	[Signature3] [nvarchar](100) NULL,
	[Signature4] [nvarchar](100) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_DocumentsSignatures] PRIMARY KEY CLUSTERED 
(
	[DocNameEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DocumentsSignatures] ADD  CONSTRAINT [DF_DocumentsSignatures_Signature1]  DEFAULT ('') FOR [Signature1]
GO

ALTER TABLE [dbo].[DocumentsSignatures] ADD  CONSTRAINT [DF_DocumentsSignatures_Signature2]  DEFAULT ('') FOR [Signature2]
GO

ALTER TABLE [dbo].[DocumentsSignatures] ADD  CONSTRAINT [DF_DocumentsSignatures_Signature3]  DEFAULT ('') FOR [Signature3]
GO

ALTER TABLE [dbo].[DocumentsSignatures] ADD  CONSTRAINT [DF_DocumentsSignatures_Signature4]  DEFAULT ('') FOR [Signature4]
GO

Insert into [DocumentsSignatures] ( [DocNameEN],[DocNameAR],[Signature1],[Signature2],[Signature3],[Signature4] ) 
  Values ('AttSalariesReport',N'تقرير الرواتب',N'الموارد البشرية:.....................',N'المدير المالي:......................',N'المحاسب:......................',N'المدير العام:.....................')
Go


ALTER TABLE [Referencess] Add [MaxDebit] [decimal] (18,2)
Go



Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('SubscriptionWhenCreateNewReceiptSetAmountFromRefBalance','True',N' في قائمة المشتركين اعتماد رصيد الزبون عند اصدار سند القبض ')
Go


 Insert into [BarcodePrinterSettings] ([ID],[FormName],[Width],[Height],[BottomMargin],[TopMargin],[ShowPrice],[IsDefault]) values (1,N'الاساسي',8.0,5.5,1,1,1,1)
 Go

Alter table [dbo].[InternalOrders] add [ReceivedQuantity] int  NULL
Go

CREATE TABLE [dbo].[BarcodePrinterSettings](
	[ID] [int] NOT NULL,
	[FormName] [nvarchar](max) NULL,
	[PageWidth] [decimal](18, 2) NULL,
	[PageHeight] [decimal](18, 2) NULL,
	[BottomMargin] [decimal](18, 2) NULL,
	[TopMargin] [decimal](18, 2) NULL,
	[RightMargin] [decimal](18, 2) NULL,
	[LeftMargin] [decimal](18, 2) NULL,
	[ShowPrice] [bit] NULL,
	[IsDefault] [bit] NULL,
	[DefaultPrinter] [nvarchar](max) NULL,
 CONSTRAINT [PK_BarcodePrinterSettings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[BarcodePrinterSettings] ([ID], [FormName], [PageWidth], [PageHeight], [BottomMargin], [TopMargin], [RightMargin], [LeftMargin], [ShowPrice], [IsDefault], [DefaultPrinter]) VALUES (1, N'50*25 1C', CAST(50.00 AS Decimal(18, 2)), CAST(25.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 1, N'4BARCODE 4B-2054TF')
GO
INSERT [dbo].[BarcodePrinterSettings] ([ID], [FormName], [PageWidth], [PageHeight], [BottomMargin], [TopMargin], [RightMargin], [LeftMargin], [ShowPrice], [IsDefault], [DefaultPrinter]) VALUES (2, N'50*25 2C', CAST(100.00 AS Decimal(18, 2)), CAST(24.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), CAST(4.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 0, N'4BARCODE 4B-2054TF')
GO
INSERT [dbo].[BarcodePrinterSettings] ([ID], [FormName], [PageWidth], [PageHeight], [BottomMargin], [TopMargin], [RightMargin], [LeftMargin], [ShowPrice], [IsDefault], [DefaultPrinter]) VALUES (3, N'100*50', CAST(100.00 AS Decimal(18, 2)), CAST(50.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 0, N' ')
GO
INSERT [dbo].[BarcodePrinterSettings] ([ID], [FormName], [PageWidth], [PageHeight], [BottomMargin], [TopMargin], [RightMargin], [LeftMargin], [ShowPrice], [IsDefault], [DefaultPrinter]) VALUES (4, N'100*100', CAST(100.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 0, N' ')
GO
INSERT [dbo].[BarcodePrinterSettings] ([ID], [FormName], [PageWidth], [PageHeight], [BottomMargin], [TopMargin], [RightMargin], [LeftMargin], [ShowPrice], [IsDefault], [DefaultPrinter]) VALUES (5, N'100*150', CAST(100.00 AS Decimal(18, 2)), CAST(150.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 0, N'')
GO
INSERT [dbo].[BarcodePrinterSettings] ([ID], [FormName], [PageWidth], [PageHeight], [BottomMargin], [TopMargin], [RightMargin], [LeftMargin], [ShowPrice], [IsDefault], [DefaultPrinter]) VALUES (6, N'30*15', CAST(100.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 0, N'')
GO
INSERT [dbo].[BarcodePrinterSettings] ([ID], [FormName], [PageWidth], [PageHeight], [BottomMargin], [TopMargin], [RightMargin], [LeftMargin], [ShowPrice], [IsDefault], [DefaultPrinter]) VALUES (7, N'60*39.5', CAST(60.00 AS Decimal(18, 2)), CAST(39.50 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 0, N'')
GO
INSERT [dbo].[BarcodePrinterSettings] ([ID], [FormName], [PageWidth], [PageHeight], [BottomMargin], [TopMargin], [RightMargin], [LeftMargin], [ShowPrice], [IsDefault], [DefaultPrinter]) VALUES (8, N'30*21.4', CAST(100.00 AS Decimal(18, 2)), CAST(21.40 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 0, N'')
GO
INSERT [dbo].[BarcodePrinterSettings] ([ID], [FormName], [PageWidth], [PageHeight], [BottomMargin], [TopMargin], [RightMargin], [LeftMargin], [ShowPrice], [IsDefault], [DefaultPrinter]) VALUES (9, N'60*40', CAST(60.00 AS Decimal(18, 2)), CAST(40.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 0, N'')
GO
INSERT [dbo].[BarcodePrinterSettings] ([ID], [FormName], [PageWidth], [PageHeight], [BottomMargin], [TopMargin], [RightMargin], [LeftMargin], [ShowPrice], [IsDefault], [DefaultPrinter]) VALUES (10, N'30*15 3C', CAST(100.00 AS Decimal(18, 2)), CAST(15.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 0, N'')
GO
INSERT [dbo].[BarcodePrinterSettings] ([ID], [FormName], [PageWidth], [PageHeight], [BottomMargin], [TopMargin], [RightMargin], [LeftMargin], [ShowPrice], [IsDefault], [DefaultPrinter]) VALUES (11, N'60*40 Label', CAST(60.00 AS Decimal(18, 2)), CAST(40.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), 1, 0, N'')
GO
ALTER TABLE [dbo].[BarcodePrinterSettings] ADD  CONSTRAINT [DF_BarcodePrinterSettings_PageWidth]  DEFAULT ((0)) FOR [PageWidth]
GO
ALTER TABLE [dbo].[BarcodePrinterSettings] ADD  CONSTRAINT [DF_BarcodePrinterSettings_PageHeight]  DEFAULT ((0)) FOR [PageHeight]
GO
ALTER TABLE [dbo].[BarcodePrinterSettings] ADD  CONSTRAINT [DF_BarcodePrinterSettings_BottomMargin]  DEFAULT ((0)) FOR [BottomMargin]
GO
ALTER TABLE [dbo].[BarcodePrinterSettings] ADD  CONSTRAINT [DF_BarcodePrinterSettings_TopMargin]  DEFAULT ((0)) FOR [TopMargin]
GO
ALTER TABLE [dbo].[BarcodePrinterSettings] ADD  CONSTRAINT [DF_BarcodePrinterSettings_RightMargin]  DEFAULT ((0)) FOR [RightMargin]
GO
ALTER TABLE [dbo].[BarcodePrinterSettings] ADD  CONSTRAINT [DF_BarcodePrinterSettings_LeftMargine]  DEFAULT ((0)) FOR [LeftMargin]
GO
ALTER TABLE [dbo].[BarcodePrinterSettings] ADD  CONSTRAINT [DF_BarcodePrinterSettings_ShowPrice]  DEFAULT ((1)) FOR [ShowPrice]
GO
ALTER TABLE [dbo].[BarcodePrinterSettings] ADD  CONSTRAINT [DF_BarcodePrinterSettings_IsDefault]  DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[BarcodePrinterSettings] ADD  CONSTRAINT [DF_BarcodePrinterSettings_DefaultPrinter]  DEFAULT ('') FOR [DefaultPrinter]
GO

Alter TABLE [dbo].[BarcodePrinterSettings]  Add  [PrintUnit] [bit] NULL 
Go
ALTER TABLE [dbo].[BarcodePrinterSettings] ADD  CONSTRAINT [DF_BarcodePrinterSettings_PrintUnit]  DEFAULT ('0') FOR [PrintUnit]
GO


Alter TABLE [dbo].[BarcodePrinterSettings]  Add  [ShowBarcodeText] [bit] NULL 
Go
ALTER TABLE [dbo].[BarcodePrinterSettings] ADD  CONSTRAINT [DF_BarcodePrinterSettings_ShowBarcodeText]  DEFAULT ('0') FOR [ShowBarcodeText]
GO
Alter TABLE [dbo].[BarcodePrinterSettings]  Add  [PrintUnit] [bit] NULL  DEFAULT ((0))
Go


ALTER TABLE [Checks] ALTER COLUMN  DocNoteByAccount NVARCHAR(max);
Go


Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('WaitOrdersPrinter','',N'  طابعة اعتماد الطلبيات الافتراضية ')
Go

ALTER TABLE  [SmsSentMessages] ALTER COLUMN  [SMSDetails] NVARCHAR(max);
Go



CREATE TABLE [dbo].[InternalOrdersReceiveLogs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InputDateTime] [datetime] NOT NULL,
	[OrderID] [int] NOT NULL,
 CONSTRAINT [PK_InternalOrdersReceiveLogs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[InternalOrdersReceiveLogs] ADD  CONSTRAINT [DF_InternalOrdersReceiveLogs_InputDateTime]  DEFAULT (getdate()) FOR [InputDateTime]
GO


Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('POS_SortItemsByItemName','False',N'  ترتيب الأصناف في نقطة البيع حسب الاسم ')
Go


Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('POS_ShowPosVoucherWhenSellItems','True',N' في نقطة البيع ، اظهار نموذح الفاتورة على الشاشة الفرعية عند عملية البيع  ')
Go

ALTER TABLE [Referencess] Add   [SalesManDay] [nvarchar] (200)  NULL
Go



Alter table AttRawatebArchive add	SalaryPerDay [decimal](18, 2) NULL
Go


Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('_POS_CustomerIsRequirdInPOS','False',N' في نقطة البيع / دراي كلين / اختيار الزبون اجباري ')
Go


Alter TABLE [dbo].[AttEmployeePayments]  Add  [SalaryDocumentID] int NULL 
Go

Alter TABLE [dbo].[AttEmployeeAdditions]  Add  [SalaryDocumentID] int NULL 
Go


CREATE TABLE [dbo].[AttFixedDiscountsAndBonuses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TermID] [int] NOT NULL,
	[TermType] [nvarchar](50) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[FromDate] [date] NOT NULL,
	[ToDate] [date] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[EmployeeID] [int] NOT NULL,
	[TermStatus] [bit] NULL,
 CONSTRAINT [PK_AttFixedDiscountsAndBonuses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

Alter TABLE [dbo].[POS_ReceiptDirectSize]  Add  [SalaryDocumentID] int NULL 
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('POS_ReceiptDirectSize','A4',N' في نقطة البيع / حجم ورقة طباعة سند القبض المختصر ')
Go

ALTER TABLE AccountingPOSNames ALTER COLUMN PaperSize NVARCHAR(50);
Go

ALTER TABLE [dbo].[AccountingPOSNames] Add  [DefaultStatusForPrintReceipt] bit NULL
Go

ALTER TABLE [dbo].[AccountingPOSNames] Add  [DefaultStatusForSendReceiptByWhatsApp] bit NULL
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('Samba_ProduceItems','True',N' انتاج الاصناف في نظام السامبا ')
Go

ALTER TABLE [dbo].[Items] Add [PeriodType]   [nvarchar] (50)  NULL
Go
ALTER TABLE [dbo].[Items] Add [PeriodCount]  [decimal](18, 2)   NULL
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('SubScriptions_ShowLayoutMonthsInNewOrEditSubScriptionForm','True',N'في نظام الاشتراكات ،  عرض شريط الأشهر في شاشة اضافة او تعديل الاشتراك')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('SubScriptions_LockEndDate','True',N' في نظام الاشتراكات السماح بتعديل خانة الى تاريخ في شاشة ادخالاو تعديل الاشتراك ')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('SubScriptions_ShowTasdeedMenueInSubScriptionsList','True',N' في نظام الاشتراكات عرض شاشة التسديد في قائمة الاشتراكات  ')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('SubScriptions_AllowEditSubscription','True',N' في نظام الاشتراكات السماح بتعديل الاشتراك  ')
Go

ALTER TABLE [dbo].[UsersLogs] ALTER COLUMN LogName [nvarchar](Max) NULL;
Go

CREATE TABLE [dbo].[Tags](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[TagName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Journal] Add   [DocTags] [nvarchar] (1024) NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add   [DocTags] [nvarchar] (1024) NULL
Go
ALTER TABLE [dbo].[POSJournal] Add   [DocTags] [nvarchar] (1024) NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add   [DocTags] [nvarchar] (1024) NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add   [DocTags] [nvarchar] (1024) NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add   [DocTags] [nvarchar] (1024) NULL
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add   [DocTags] [nvarchar] (1024) NULL
Go




Update [dbo].[EmployeesData] set [AttFromMobileProcess] = 1 where [AttFromMobileProcess]=Null
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('SortByModifiedDateInAccountingStatment','False',N' في كشف الحساب ، ترتيب الكشف حسب اخر تعديل على السند  ')
Go

Update [dbo].[EmployeesData] set JobName='' where JobName Is Null
Go

ALTER TABLE [dbo].[EmployeesData] ADD [UniversitySonNo] [int] NULL DEFAULT 0;
GO


ALTER TABLE [dbo].[DeletedEditedTrans] ADD [UserID] [int] NULL DEFAULT 0;
GO

  
ALTER TABLE [dbo].[DeletedEditedTrans] ADD [EmployeeID] [int] NULL DEFAULT 0;
GO

ALTER TABLE [dbo].[DeletedEditedTrans] ADD [LastData] Nvarchar(Max) NULL DEFAULT 0;
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('Accounting_PrintAccountStatmentByEnglish','False',N' طباعة كشف حساب الذمة ب الانجليزي ')
Go

Alter table VocationsTypes add	[ShowInSelfService] [bit] NULL DEFAULT 0;
go

ALTER TABLE [dbo].[DocNames] ADD [NameEn] Nvarchar(Max) NULL DEFAULT '';
GO

Update VocationsTypes set [ShowInSelfService]=1
Go

ALTER TABLE [dbo].[DocNames] ADD [AttShowXrPanelDawamTable] Bit NULL DEFAULT 0;
GO

ALTER TABLE [dbo].[DocNames] ADD [NameEn] Nvarchar(Max) NULL DEFAULT '';
GO

Update [dbo].[Messages] set [SMSFields]=N'ReferanceName,FromDate,ToDate,RefBalance' where ID=13
Go

Update [dbo].[Messages] set [SMSFields]=N'ReferanceName,ToDate,RefBalance' where ID=12
Go

ALTER TABLE [dbo].[PosPaidMethods] ADD [IsDefualt] Bit NULL DEFAULT 0;
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('SubScriptions_TasdeedBasedOnDebit','False',N' في نظام الاشتراكات ، تغير حالة الاشتراك الى مسدد في حال تم تسديد الدين  ')
Go

ALTER TABLE [dbo].[EmployeesOhdah] ADD [ItemSerial] Nvarchar(Max) NULL DEFAULT '0';
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('SortByModifiedDateInAccountingStatment','True',N' في كشف الحساب ، ترتيب الكشف حسب اخر تعديل على السند  ')
Go

Update [dbo].[Messages] set [SMSFields]=N'ReferanceName,FromDate,ToDate,RefBalance' where ID=10
Go
ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_ApproveInd]  DEFAULT (N'no') FOR [ApproveInd]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_AllowUseAttApp]  DEFAULT ((1)) FOR [AllowUseAttApp]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_AttFromMobileProcess]  DEFAULT ((1)) FOR [AttFromMobileProcess]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_Department]  DEFAULT ((0)) FOR [Department]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_JobName]  DEFAULT ((0)) FOR [JobName]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_Branch]  DEFAULT ((0)) FOR [Branch]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_SalaryPerHour]  DEFAULT ((0)) FOR [SalaryPerHour]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_ProcessType]  DEFAULT ((1)) FOR [ProcessType]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_ManagerID]  DEFAULT ((1)) FOR [ManagerID]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_EnableLoginValidation]  DEFAULT ((0)) FOR [EnableLoginValidation]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_TrustDeviceIP]  DEFAULT ((0)) FOR [TrustDeviceIP]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_IsCookieSet]  DEFAULT ((0)) FOR [IsCookieSet]
GO

ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_SalaryAccountNo]  DEFAULT ((0)) FOR [SalaryAccountNo]
GO

ALTER TABLE [dbo].[EmployeesData] ADD [AllowAddCustomerFromApp] Bit NULL DEFAULT ((0));
GO




Update [dbo].[EmployeesData] set [ApproveInd]='no' where [ApproveInd] Is NULL
GO

Update [dbo].[EmployeesData] set [AllowUseAttApp]=1 where [AllowUseAttApp] Is NULL
GO

Update [dbo].[EmployeesData] set [AttFromMobileProcess]=1 where [AttFromMobileProcess] IS NULL
GO

Update [dbo].[EmployeesData] set  [Department]='' where [Department] Is NULL
GO

Update [dbo].[EmployeesData] set [JobName]='' where [JobName] Is NULL
GO

Update [dbo].[EmployeesData] set [Branch]='' where [Branch] Is NULL
GO

Update [dbo].[EmployeesData] set [SalaryPerHour]=0 where [SalaryPerHour] Is NULL
GO

Update [dbo].[EmployeesData] set [ProcessType]=1 where [ProcessType] IS NULL
GO

Update [dbo].[EmployeesData] set [ManagerID]=1 where [ManagerID] Is NULL
GO

Update [dbo].[EmployeesData] set [EnableLoginValidation]=1 where [EnableLoginValidation] Is NULL
GO

Update [dbo].[EmployeesData] set [TrustDeviceIP]=0 where [TrustDeviceIP] Is NULL
GO

Update [dbo].[EmployeesData] set [IsCookieSet]=0 where [IsCookieSet] Is NULL
GO

Update [dbo].[EmployeesData] set [IP]='' where [IP] Is NULL
GO

Update [dbo].[EmployeesData] set [TrustIP]='' where [TrustIP] Is NULL
GO

Update [dbo].[EmployeesData] set [Cookie]='' where [Cookie] Is NULL
GO

Update [dbo].[EmployeesData] set [DeviceIP]='' where [DeviceIP] Is NULL
GO

Update [dbo].[EmployeesData] set [ManagerIDForWeb]=ManagerID
GO




Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('POS_SendVoucherPDFToCustomer','False',N' في نقطة البيع / ارسال الفاتورة للزبون ')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('HR_DefualtSalarySlip','1',N' قسيمة الراتب الافتراضية ')
Go


ALTER TABLE [SubscriptionDoc] Add  SalesPerson int ;
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription) values ('POS_ShowTaqseetColoumn','False',N' عرض عمود التقسيط في شاشة الفواتير بنقطة البيع ')
Go


ALTER TABLE [dbo].[Items] Add   [BarcodesCount] [int]   NULL
Go

ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_BarcodesCount]  DEFAULT ((0)) FOR [BarcodesCount]
GO



Alter table [dbo].[Settings] Add [SettingTerm] [nvarchar] (100)  NULL
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('SelfService_NumbersToJustViewNotifications','',N' في نظام الخدمة الذاتية ، ارقام الموبايل التي سيتم ارسال لها تنبيهات للاطلاع ','SelfService')
Go



Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('SelfService_SickVacationRequireAttch','False',N' في نظام الخدمة الذاتية ، يجب ارفاق وثيقة عند طلب الاجازة المرضية ','SelfService')
Go


CREATE TABLE [dbo].[Installments](
	[InstallmentID] [int] IDENTITY(1,1) NOT NULL,
	[InstallmentDate] [date] NOT NULL,
	[VoucherNo] [nvarchar](50) NOT NULL,
	[InstallmentReferance] [nvarchar](100) NULL,
	[InstallmentsAmount] [decimal](18, 2) NOT NULL,
	[InstallmentAmount] [decimal](18, 2) NOT NULL,
	[FirstInstallmentDate] [date] NULL,
	[InstallmentsCount] [int] NULL,
	[InstallmentsNotes] [nvarchar](max) NULL,
	[InstallmentsPeriod] [int] NULL,
	[InstallmentInOut] [varchar](3) NULL,
	[InstallmentRef] [int] NULL,
 CONSTRAINT [PK__Installm__42B42E6295FFFC82] PRIMARY KEY CLUSTERED 
(
	[InstallmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Table [dbo].[InstallmentsPayments]    Script Date: 11/11/2024 4:57:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InstallmentsPayments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InstallmentID] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[DueDate] [date] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[Note] [nvarchar](max) NULL,
	[PaidDate] [date] NULL,
	[PaidAmount] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[InstallmentsPayments] ADD  CONSTRAINT [DF_InstallmentsPayments_Note]  DEFAULT ('') FOR [Note]
GO

ALTER TABLE [dbo].[InstallmentsPayments] ADD  CONSTRAINT [DF_InstallmentsPayments_PaidAmount]  DEFAULT ((0)) FOR [PaidAmount]
GO

ALTER TABLE [dbo].[InstallmentsPayments]  WITH CHECK ADD  CONSTRAINT [FK_InstallmentsPayments_InstallmentID] FOREIGN KEY([InstallmentID])
REFERENCES [dbo].[Installments] ([InstallmentID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[InstallmentsPayments] CHECK CONSTRAINT [FK_InstallmentsPayments_InstallmentID]
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('Att_MaxHoursToFindOutTrans','20',N' في نظام ادارة الدوام ، الحد الاقصى من الساعات للبحث عن حركة الخروج ','HR')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('Accounting_AllowChangeChequeStatus','False',N' السماح بتعديل حالة الشيك ','Accounting')
Go

ALTER TABLE [dbo].[Journal] Add  [POSVoucherPayType] nvarchar(20) NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [POSVoucherPayType] nvarchar(20) NULL
Go
ALTER TABLE [dbo].[POSJournal] Add [POSVoucherPayType] nvarchar(20) NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [POSVoucherPayType] nvarchar(20) NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [POSVoucherPayType] nvarchar(20) NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add [POSVoucherPayType] nvarchar(20) NULL
Go
ALTER TABLE [dbo].[POSHoldJournal] Add [POSVoucherPayType] nvarchar(20) NULL
Go

Alter table [dbo].[PosShifts] add  [ReceiptsCard] decimal(18, 4) default 0
Go

Alter table [dbo].[WF_Request_Workflow] add [Department] nvarchar(MAX) NULL
Go
ALTER TABLE [dbo].[WF_Request_Workflow] ADD  CONSTRAINT [DF_WF_Request_Workflow_Department]  DEFAULT ((0)) FOR [Department]
GO


Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('HR_ShowGrossSalaryInSalarySlip','False',N' عرض حقل اجمالي الراتب في قسيمة الراتب ','HRr')
Go

ALTER TABLE [dbo].[Journal] Add  [HasAttachment] bit NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[JournalTemp] Add  [HasAttachment] bit NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[POSJournal] Add [HasAttachment] bit NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [HasAttachment] bit NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [HasAttachment] bit NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add [HasAttachment] bit NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[POSHoldJournal] Add [HasAttachment] bit NULL DEFAULT ((0))
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('HR_ShowActualHouresInSalarySlip','True',N' عرض حقل الساعات الفعلية في قسيمة الراتب ','HRr')
Go

ALTER TABLE [dbo].[WF_Request_Workflow_Approvals] Add [InputDateTime] datetime NULL 
Go
ALTER TABLE [dbo].[WF_Request_Workflow_Approvals] ADD  CONSTRAINT [DF_WF_Request_Workflow_Approvals_InputDateTime]  DEFAULT (getdate()) FOR [InputDateTime]
GO

ALTER TABLE [dbo].[AttFixedDiscountsAndBonuses] Add [Percentage] [float]  NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[AttFixedDiscountsAndBonuses] Add [Fields] nvarchar(MAX) NULL DEFAULT ('')
Go
ALTER TABLE [dbo].[AttFixedDiscountsAndBonuses] Add [FixOrPercentage]  nvarchar(20) NULL 
Go


Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('POS_PasswordForPosReports','100200300',N' كلمة المرور لتقارير المبيعات ','POS')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('HR_ActiveSavingFund','False',N' تفعيل صندوق التوفير للموظفين في نظام الرواتب ','HR')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('HR_CompanyContributionPercentage','0',N' نسبة مساهمة المؤسسة في صندوق التوفير ','HR')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('HR_PersonalContributionPercentage','0',N' نسبة مساهمة الموظف في صندوق التوفير ','HR')
Go

ALTER TABLE [dbo].[AttRawatebArchive] Add [SavingsFund] [decimal](18, 2) NULL DEFAULT ((0))
Go

ALTER TABLE [dbo].[AttRawatebArchive] Add [IncomeTAX] [decimal](18, 2) NULL DEFAULT ((0))
Go

ALTER TABLE [dbo].[EmployeesData] ADD [ActiveSavingFund] [bit] NULL DEFAULT (0);
GO

ALTER TABLE [dbo].[EmployeesData] ADD [SectionsID] [int] NULL DEFAULT (0);
GO

CREATE TABLE [dbo].[EmployeesSections](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SectionName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_EmployeesSections] PRIMARY KEY CLUSTERED 
(
	[SectionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SavingsFund](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SalaryDocumentID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[CompanyContribution] [decimal](18, 2) NOT NULL,
	[PersonalContribution] [decimal](18, 2) NOT NULL,
	[DocDate] [date] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[InputDateTime] [datetime] NOT NULL,
	[InputUser] [int] NOT NULL,
 CONSTRAINT [PK_SavingsFund] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('HR_CalcLeavesDuringWorkFromVocations','False',N' خصم المغادرات خلال فترة الدوام من اجازات الموظف ','HR')
Go

Alter Table Vocations Add SalaryDocumentID  int NULL  DEFAULT ((0))
Go

--Update [dbo].[AttFixedDiscountsAndBonuses] set [Percentage]=100 where [Percentage] Is NULL
--Update  [dbo].[AttFixedDiscountsAndBonuses]  set FixOrPercentage='Fix' where [Percentage] Is NULL


ALTER TABLE [dbo].[Journal] Add   [BonusQuantity] [decimal](18, 4)   NULL DEFAULT ((0.0))
Go
ALTER TABLE [dbo].[JournalTemp] Add  [BonusQuantity] [decimal](18, 4)  NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[POSJournal] Add  [BonusQuantity] [decimal](18, 4)  NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[OrdersJournal] Add [BonusQuantity] [decimal](18, 4)  NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add [BonusQuantity] [decimal](18, 4)   NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add  [BonusQuantity] [decimal](18, 4)  NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add  [BonusQuantity] [decimal](18, 4)  NULL DEFAULT ((0))
Go



ALTER TABLE [dbo].[Journal] Add   [BonusQuantityByMainUnit] [decimal](18, 4)   NULL DEFAULT ((0.0))
Go
ALTER TABLE [dbo].[JournalTemp] Add  [BonusQuantityByMainUnit] [decimal](18, 4)  NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[POSJournal] Add  [BonusQuantityByMainUnit] [decimal](18, 4)  NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[OrdersJournal] Add [BonusQuantityByMainUnit] [decimal](18, 4)  NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add [BonusQuantityByMainUnit] [decimal](18, 4)   NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add  [BonusQuantityByMainUnit] [decimal](18, 4)  NULL DEFAULT ((0))
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add  [BonusQuantityByMainUnit] [decimal](18, 4)  NULL DEFAULT ((0))
Go

Update [dbo].[Journal] Set [BonusQuantity]=0 Where [BonusQuantity] Is Null
Go
Update [dbo].[Journal] Set [BonusQuantityByMainUnit]=0 Where [BonusQuantityByMainUnit] Is Null
Go

Alter Table [Journal] Add OldTransID  int NULL  DEFAULT ((0))
Go
Alter Table [JournalTemp] Add OldTransID  int NULL  DEFAULT ((0))
Go

ALTER TABLE [dbo].[Journal] ALTER COLUMN StockCarNo [nvarchar](Max) NULL;
Go
ALTER TABLE [dbo].[JournalTemp] ALTER COLUMN StockCarNo [nvarchar](Max) NULL;
Go
ALTER TABLE [dbo].[POSJournal] ALTER COLUMN StockCarNo [nvarchar](Max) NULL;
Go
ALTER TABLE [dbo].[OrdersJournal] ALTER COLUMN StockCarNo [nvarchar](Max) NULL;
Go
ALTER TABLE [dbo].[OrdersAppJournal] ALTER COLUMN StockCarNo [nvarchar](Max) NULL;
Go
ALTER TABLE [dbo].[POSDeletedJournal] ALTER COLUMN StockCarNo [nvarchar](Max) NULL;
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] ALTER COLUMN StockCarNo [nvarchar](Max) NULL;
Go

Update CostCenter Set CostCenterTypeID=1 where CostCenterTypeID Is NULL
Go

Insert INTO ChecksStatus (CheckStatus,CheckInOutType,ID) values ( N'ملغي', 'Out',13 )
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('POS_PrintVoucherNo','True',N' طباعة رقم الفاتورة  ','POS')
Go



CREATE TABLE [dbo].[VocationsDeleted](
	[VocID] [int] NOT NULL,
	[VocDate] [date] NULL,
	[EmployeeID] [int] NOT NULL,
	[VocationType] [nvarchar](15) NOT NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[NoDays] [decimal](18, 2) NULL,
	[NoteDetails] [nvarchar](max) NULL,
	[BatchNo] [int] NULL,
	[VocationSource] [varchar](10) NULL,
	[TransAdjustID] [int] NULL,
	[HoursPriod] [varchar](10) NULL,
	[InputDateTime] [datetime] NULL,
	[SalaryDocumentID] [int] NULL,
	[DeletedDateTime] [datetime] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_VocationsDeleted] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[VocationsDeleted] ADD  CONSTRAINT [DF__Vocations__Input__785FB566]  DEFAULT (getdate()) FOR [InputDateTime]
GO

ALTER TABLE [dbo].[VocationsDeleted] ADD  CONSTRAINT [DF__Vocations__Salar__7953D99F]  DEFAULT ((0)) FOR [SalaryDocumentID]
GO


ALTER TABLE [dbo].[VocationsDeleted] Add  [DeletedDateTime] datetime  NULL 
Go


CREATE TRIGGER [dbo].[trg_AfterDelete_Vocations]
ON [dbo].[Vocations]
AFTER DELETE
AS
BEGIN
    -- Insert deleted records into the VocationsDeleted table
    INSERT INTO [VocationsDeleted] (
        [VocID],
        [VocDate],
        [EmployeeID],
        [VocationType],
        [FromDate],
        [ToDate],
        [NoDays],
        [NoteDetails],
        [BatchNo],
        [VocationSource],
        [TransAdjustID],
        [HoursPriod],
        [InputDateTime],
        [SalaryDocumentID],
        [DeletedDateTime]
    )
    SELECT 
        [VocID],
        [VocDate],
        [EmployeeID],
        [VocationType],
        [FromDate],
        [ToDate],
        [NoDays],
        [NoteDetails],
        [BatchNo],
        [VocationSource],
        [TransAdjustID],
        [HoursPriod],
        [InputDateTime],
        [SalaryDocumentID],
        GETDATE() AS [DeletedDateTime] -- Add the current date and time
    FROM DELETED;
END;
GO

ALTER TABLE [dbo].[Vocations] ENABLE TRIGGER [trg_AfterDelete_Vocations]
GO


ALTER TABLE [dbo].[PosVouchers] ALTER COLUMN [VoucherNote] nvarchar(max) NULL
Go
ALTER TABLE [dbo].[Journal] ALTER COLUMN [DocNotes] nvarchar(max) NULL
Go
ALTER TABLE [dbo].[JournalTemp] ALTER COLUMN [DocNotes] nvarchar(max) NULL
Go
ALTER TABLE [dbo].[POSJournal] ALTER COLUMN [DocNotes] nvarchar(max) NULL
Go
ALTER TABLE [dbo].[OrdersJournal] ALTER COLUMN [DocNotes] nvarchar(max) NULL
Go
ALTER TABLE [dbo].[OrdersAppJournal] ALTER COLUMN [DocNotes] nvarchar(max) NULL
Go
ALTER TABLE [dbo].[POSDeletedJournal] ALTER COLUMN [DocNotes] nvarchar(max) NULL
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] ALTER COLUMN [DocNotes] nvarchar(max) NULL
Go








Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('POS_HidePosVoucherImageInHeader','False',N' اخفاء الشعار في فاتورة نقطة البيع ','POS')
Go



ALTER TABLE [dbo].[POSJournal] Add  [PrinterName] nvarchar(max) NULL
Go
ALTER TABLE [dbo].[POSHoldJournal] Add  [PrinterName] nvarchar(max) NULL
Go

ALTER TABLE [dbo].[POSHoldJournal] Add [Printed] bit  NULL
Go
ALTER TABLE [dbo].[POSHoldJournal] ADD  CONSTRAINT [DF_POSHoldJournal_Printed]  DEFAULT ((0)) FOR [Printed]
GO

ALTER TABLE [dbo].[POSJournal] Add [Printed] bit  NULL
Go
ALTER TABLE [dbo].[POSJournal] ADD  CONSTRAINT [DF_POSJournal_Printed]  DEFAULT ((0)) FOR [Printed]
GO


ALTER TABLE [dbo].[POSJournal] Add [VoucherCounter] int  NULL
Go


ALTER TABLE [dbo].[InternalOrders] Add [WarehouseID] int  NULL
Go
ALTER TABLE [dbo].[InternalOrders] ADD  CONSTRAINT [DF_InternalOrders_WarehouseID]  DEFAULT ((1)) FOR [WarehouseID]
GO


ALTER TABLE [dbo].[AccountingPOSNames] Add  [ItemsViewTemplateName] nvarchar(MAX)  NULL
Go



ALTER TABLE [Referencess] Add   [Latitude] [nvarchar] (Max)  NULL
Go
ALTER TABLE [Referencess] Add   [Longitude] [nvarchar] (Max)  NULL
Go

ALTER TABLE [dbo].[AccountingPOSNames] Add  [VouchersCounter] int NULL 
Go




DECLARE @SQL NVARCHAR(MAX) = '';
DECLARE @DocName NVARCHAR(100);
DECLARE @DocID INT;
DECLARE doc_cursor CURSOR FOR 
SELECT id, 
       CASE id 
            WHEN 1 THEN 'PurchaseInvoiceSeq'
            WHEN 2 THEN 'SalesInvoiceSeq'
            WHEN 3 THEN 'PaymentVoucherSeq'
            WHEN 4 THEN 'ReceiptVoucherSeq'
            WHEN 5 THEN 'JournalVoucherSeq'
            WHEN 6 THEN 'DebitNoteSeq'
            WHEN 7 THEN 'CreditNoteSeq'
            WHEN 8 THEN 'PurchaseDispatchSeq'
            WHEN 9 THEN 'SalesDispatchSeq'
            WHEN 10 THEN 'PurchaseOrderSeq'
            WHEN 11 THEN 'SalesOrderSeq'
            WHEN 12 THEN 'SalesReturnsSeq'
            WHEN 13 THEN 'PurchaseReturnsSeq'
            WHEN 16 THEN 'InternalDispatchSeq'
            WHEN 17 THEN 'StockEntryVoucherSeq'
            WHEN 18 THEN 'StockExitVoucherSeq'
            WHEN 19 THEN 'ProductionVoucherSeq'
       END AS SequenceName
FROM (VALUES 
    (1), (2), (3), (4), (5), (6), (7), (8), (9), 
    (10), (11), (12), (13), (16), (17), (18), (19)
) AS Docs(id);

OPEN doc_cursor;
FETCH NEXT FROM doc_cursor INTO @DocID, @DocName;

WHILE @@FETCH_STATUS = 0
BEGIN
    DECLARE @MaxDocID INT;
    
    -- الحصول على آخر قيمة في DocID لهذا النوع من المستندات
    SELECT @MaxDocID = COALESCE(MAX(DocID), 0) FROM Journal WHERE DocName = @DocID;

    -- إنشاء الـ SEQUENCE
    SET @SQL = 'CREATE SEQUENCE dbo.' + QUOTENAME(@DocName) + ' 
                AS INT 
                START WITH ' + CAST(@MaxDocID + 1 AS NVARCHAR(20)) + ' 
                INCREMENT BY 1 
                NO CYCLE;';

    EXEC sp_executesql @SQL;

    FETCH NEXT FROM doc_cursor INTO @DocID, @DocName;
END;
CLOSE doc_cursor;
DEALLOCATE doc_cursor;



Go


--SET ----------------------------------------------------------------------------------------------------
--SET ----------------------------------------------------------------------------------------------------



ALTER PROCEDURE [dbo].[BuildReceiptFromOrderApp] @ReferanceNo nvarchar(50),@Amount decimal(18, 2) ,
												  @UserID nvarchar(50) ,@DocNote nvarchar(1000),
												  @DeviceName nvarchar(50),@CurrencyID int,@DocCode2 varchar(50),
												  @CashAmount decimal(18, 2),@ChecksAmount decimal(18, 2)
AS

Declare @RowsNo int;
Set @RowsNo= ( Select IsNull(count(ID),0) As CountRows from Journal where DocCode=@DocCode2);
if @RowsNo = 0 
Begin 

DECLARE @DocID int ;
DECLARE @DebitAccountCash varchar(15) ;
DECLARE @DebitAccountChecks varchar(15) ;
DECLARE @AccountCurr int ;
DECLARE @DefaultCurr int ;
DECLARE @InputDateTime as datetime ;
DECLARE @ReferanceName as nvarchar(50) ;
DECLARE @ReferanceAccount as varchar(50) ;
DECLARE @DocCode as varchar(15);
Declare @UserName Nvarchar (100);
Declare @DocNote2 Nvarchar (1000);
--SET @DocID = ( Select isnull(max([DocID])+1,1) from Journal  where DocName=5);
SET @DocID = NEXT VALUE FOR dbo.JournalEntrySeq;
SET @DebitAccountCash = ( Select AccNo from FinancialAccountsDefault where UserID= @UserID and CurrencyID=@CurrencyID And AccTypeID=1);
SET @DebitAccountChecks = ( Select AccNo from FinancialAccountsDefault where UserID= @UserID and CurrencyID=@CurrencyID And AccTypeID=2);
SET @AccountCurr=(Select Currency from FinancialAccounts where AccNo=@DebitAccountCash );
SET @DefaultCurr=(Select CurrID from Currency where IsDefault=1);
SET @InputDateTime= (select CONVERT(char(10), GetDate(),126) + ' ' + convert(VARCHAR(8), GETDATE(), 14))
SET @ReferanceName= ( Select RefName from Referencess where RefNo = @ReferanceNo);
--SET @DocCode= ( select Right(NEWID(),15));
SET @DocCode= @DocCode2;
SET @ReferanceAccount= ( Select RefAccID from Referencess where RefNo= @ReferanceNo);
Set @UserName = (Select EmployeeName from EmployeesData where EmployeeID =@UserID  );
Set @DocNote2=(@DocNote+'/'+@ReferanceName);
--Add CashDebit Side
Insert into [JournalTemp] ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
			[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
		    [DocManualNo],[DocNotes],InputUser,InputDateTime,CurrentUserID,Referance,ReferanceName,ShiftID,DocCode,
			PosNo,DocNoteByAccount,DeviceName,[CheckNo],[CheckInOut],[CheckStatus],[CheckDueDate],[CheckCustBank],[CheckCustBranch],[CheckCustAccountId],[AccountBank],SalesPerson )
values(  @DocID , CONVERT(char(10), GetDate(),126),5,1,1,@DebitAccountCash,'0',@AccountCurr,@DefaultCurr,@CashAmount,1,@CashAmount,@CashAmount,'',
		 @DocNote2,@UserID,@InputDateTime,-1,0,'',0,@DocCode,0,'',@DeviceName,'0','','0','','0','0','0','0',@UserID);

If @ChecksAmount <> 0 
Begin 
--Add CheksDebit Side
Insert into [JournalTemp] ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
			[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
		    [DocManualNo],[DocNotes],InputUser,InputDateTime,CurrentUserID,Referance,ReferanceName,ShiftID,DocCode,
			PosNo,DocNoteByAccount,DeviceName,[CheckNo],[CheckInOut],[CheckStatus],[CheckDueDate],[CheckCustBank],[CheckCustBranch],[CheckCustAccountId],[AccountBank],SalesPerson )
values(  @DocID , CONVERT(char(10), GetDate(),126),5,1,1,@DebitAccountChecks,'0',@AccountCurr,@DefaultCurr,@ChecksAmount,1,@ChecksAmount,@ChecksAmount,'',
		 @DocNote2,@UserID,@InputDateTime,-1,0,'',0,@DocCode,0,'',@DeviceName,'','','','','','','','',@UserID);
End 

--Add Credit Side
Insert into [JournalTemp] ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
			[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
		    [DocManualNo],[DocNotes],InputUser,InputDateTime,CurrentUserID,Referance,ReferanceName,ShiftID,DocCode,
			PosNo,DocNoteByAccount,DeviceName,[CheckNo],[CheckInOut],[CheckStatus],[CheckDueDate],[CheckCustBank],[CheckCustBranch],[CheckCustAccountId],[AccountBank],SalesPerson )
values(  @DocID , CONVERT(char(10), GetDate(),126),5,1,1,'0',@ReferanceAccount,@AccountCurr,@DefaultCurr,@Amount,1,@Amount,@Amount,'',
		 @DocNote2,@UserID,@InputDateTime,-1,@ReferanceNo,@ReferanceName,0,@DocCode,0,'',@DeviceName,'0','','0','1900-01-01','0','0','0','0',@UserID);

--Post Cheks To Cheks Table 
--INSERT INTO Checks (DocName,CheckCode,CheckInOut,CheckNo,CheckDueDate,CheckBank,CheckBranch,CheckAccountId,CheckStatus,CheckAmount,CheckCurr,CheckBaseAmount,DocCode,DocID,AccountBank,DocNoteByAccount,ChekInBoxAccount,Referance,RelatedAccount,TransNoInJournal)
--SELECT  DocName,CheckCode,CheckInOut,CheckNo,CheckDueDate,CheckCustBank,CheckCustBranch,CheckCustAccountId,CheckStatus,DocAmount,DocCurrency,BaseCurrAmount,DocCode,DocID,AccountBank,DocNoteByAccount,DebitAcc,Referance,DebitAcc,1 FROM JournalTemp 
--where DocName=4  and DocID=@DocID and CurrentUserID= @UserID and CheckNo <> 0 And  CredAcc='0' 

Insert into [dbo].[Journal] ([DocID],[DocDate] ,[DocName] ,[DocStatus]
            ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
            ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
            ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
            ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
            ,[StockUnit] ,[StockQuantity] ,[StockQuantityByMainUnit] ,[StockPrice]
            ,[StockItemPrice] ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
            ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
            ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
            ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
            ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
            ,[StockDiscount] ,[StockBarcode] ,[PosNo]
            ,[DeviceName],[LastDocCode],[LastDataName]) 
Select DocID,[DocDate] ,[DocName] ,[DocStatus]
            ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
            ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
            ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
            ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
            ,[StockUnit] ,[StockQuantity] ,[StockQuantityByMainUnit] ,[StockPrice]
            ,[StockItemPrice] ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
            ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
            ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
            ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
            ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
            ,[StockDiscount] ,[StockBarcode] ,[PosNo],[DeviceName] ,LastDocCode,LastDataName
			From JournalTemp  where DocCode=@DocCode

Delete from JournalTemp where DocCode=@DocCode

INSERT INTO [dbo].[UsersLogs]
           ([DocCode]
           ,[DocName]
           ,[DocID]
           ,[LogName]
           ,[UserID]
           ,[LogDateTime]
           ,[DeviceName]
           ,[UserName]
           ,[LogDetails]
           ,[LogType]) Values (@DocCode,2,@DocID,'Insert',@UserID,GETDATE(),@DeviceName,@UserName,'Issue Receipt From Mobile App','Document')
End
Declare @FinalDocID int;
SET @FinalDocID = (  SELECT top(1) DocID 
     FROM [dbo].[Journal]  where  DocCode=@DocCode ) ;

if @FinalDocID is null
 BEGIN
 delete from Journal where DocCode=@DocCode
 End
 --End
return  @FinalDocID;
GO



ALTER PROCEDURE [dbo].[InsertDataFromTempToJournal] @DocName int,@DocCode varchar(50),@UserID int,@DeviceName varchar(255) ,@_DocID int,@DocID INT OUTPUT
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
	IF @_DocID = 0
		Begin
	    --SELECT @DocID = ISNULL(max(DocID),0)+1 FROM journal WITH (TABLOCKX, HOLDLOCK) where DocName=@DocName ;
			IF @DocName = 17  
				SET @DocID = NEXT VALUE FOR dbo.GoodsReceivedSeq;  
			ELSE IF @DocName = 18  
				SET @DocID = NEXT VALUE FOR dbo.GoodsIssuedSeq;  
		End
	Else
		Begin
		Set @DocID=@_DocID
	End
	Insert into Journal ([DocID],[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,ModifiedDateTime,StockID,StockUnit,
                                                [StockQuantity],[StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                               [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,
                                                DeliverDate,Color,Measure,StockDiscount,VoucherDiscount,ItemVAT,[StockDebitShelve],
                                                StockCreditShelve,DocNoteByAccount,SalesPerson,DeviceName,ItemNo2,OrderID,StockDriver,StockCarNo,LastPurchasePrice,BatchID,PaidStatus,PaidAmount,PaidByDocID)
    Select  @DocID,[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,ModifiedDateTime,StockID,StockUnit,
                                                [StockQuantity],[StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                                [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,
                                                DeliverDate,Color,Measure,StockDiscount,VoucherDiscount,ItemVAT,[StockDebitShelve],
                                                StockCreditShelve,DocNoteByAccount,SalesPerson,DeviceName,ItemNo2,OrderID,StockDriver,StockCarNo,LastPurchasePrice,BatchID,PaidStatus,PaidAmount,PaidByDocID
    from JournalTemp 
	where DocCode=@DocCode and CurrentUserID=@UserID and DeviceName=@DeviceName;
COMMIT;
        --SELECT top 1 @_DocID AS DocID;
END TRY

BEGIN CATCH
	ROLLBACK; -- Rollback the transaction
	Set @DocID=0
END CATCH;
delete from JournalTemp where  DocName=@DocName and DocCode=@DocCode and CurrentUserID=@UserID;
select @DocID

END;
GO


--SET ----------------------------------------------------------------------------------------------------
--SET ----------------------------------------------------------------------------------------------------





ALTER PROCEDURE [dbo].[OrpakAdjustment] @USERID int, @PosNo int,@WorkPeriod int,@StartDate varchar(20),@EndDate varchar(20)
AS
  Declare @TicketAmount as float;
  Declare @OrderAmount as float;
  Declare @VoucherNo int;
  Declare @DocDate date;
  Declare @CostCenter int;
  Declare @DefaultCurr int;
  Declare @DocNote nvarchar(Max);
  Declare @DocCode varchar(15);
  Declare @StockCreditWhereHouse int;
  Declare @DiscountRatio decimal(18, 4);
  Declare @TempAccount varchar(10);
  Declare @DocManualNo nvarchar(50) ;
  Declare @TicketCode varchar(50);
  Declare @Temp1 varchar(10);
  Declare @Temp2 varchar(10);
  Declare @Produce bit;
  Declare @TicketsCount int;
  Declare @TicketsAmount int;
  Declare @TicketIdFrom int;
  Declare @TicketIdTo int;
  Declare @OrdersCount int;
  Declare @VouchersInJournalAmount float;
  Declare @InputDateTime as datetime;
  Declare @_DocID2 int;
  Set @Temp1=( select Right(NEWID(),5))
  Set @CostCenter=( Select CostCenter from AccountingPOSNames Where ID=@PosNo  );
  Set @StockCreditWhereHouse=( Select Warehouse from AccountingPOSNames Where ID=@PosNo  );
  Set @InputDateTime=GETDATE()

  select [id] as TicketID,[sale] As TicketAmount,[timestamp]  Into   #@Temp1 from [OrpakTransactionsTemp] where [UserID]=@USERID

  Set @TicketIdFrom =( Select Min(TicketID) from #@Temp1 );
  Set @TicketIdTo =( Select Max(TicketID) from #@Temp1 );
  Set @TicketsAmount =( Select Sum(TicketAmount) from #@Temp1 );
  Set @TicketsCount =( Select Count(TicketID) from #@Temp1 );
  Set @_DocID2=cast(CONVERT(varchar(20),@InputDateTime,112) as INT )+@PosNo+@WorkPeriod ;

  Insert into [OrpakReadingLog] ([PeriodID],[PosNo],[FromDate],[ToDate],[Amount],[UserName],[FromTicket],[ToTicket],[TicketsCount],[OrdersCount],[ReadDateTime],[ReadBy],DocID2) 
		  Values (@WorkPeriod,@PosNo,@StartDate,@EndDate,@TicketsAmount,@USERID,@TicketIdFrom,@TicketIdTo,@TicketsCount,@OrdersCount,@InputDateTime,@USERID,@_DocID2)

  Declare @TicketID int;
  While (Select Count(*) From #@Temp1) > 0
  Begin
  Select Top 1 @TicketID = TicketID From #@Temp1 
  set @TicketAmount=( select TicketAmount from #@Temp1 where TicketID= @TicketID );
  Set @DocDate=(Select convert(date,[timestamp])  from #@Temp1 where TicketID= @TicketID  );


  Set @DefaultCurr=( Select CurrID  from Currency where IsDefault=1  );
  Set @DocNote= CONCAT('Orpak Voucher From (PosNo:' , @PosNo , ' WorkPeriod No:' , @WorkPeriod ,' User:' , @USERID,' TicketNo:' ,@TicketID,')')  ;
  SET @DocCode= ( select Right(NEWID(),15));
  Set @TempAccount=(Select TempAccounting from AccountingPOSNames where Id=@PosNo)
  Set @DocManualNo= @TicketID 
  Set @TicketCode='';
  --Set @VoucherNo = ( Select IsNull(Max(DocID)+1,0)  from Journal where DocName=2 );
SET @VoucherNo = NEXT VALUE FOR dbo.SalesInvoiceSeq ;
insert into Journal
       ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                       StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,
                                       CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,PosNo,DocNoteByAccount,VoucherDiscount,StockDiscount,LastDocCode,LastDataName,DocID2  ) 
                                       Select @VoucherNo,CAST(@DocDate AS DATE) ,2,1,@CostCenter,
                                       '0',I.AccSales,1,
                                       @DefaultCurr,O.Amount-O.Amount*@DiscountRatio,1,O.Amount-O.Amount*@DiscountRatio,O.Amount-O.Amount*@DiscountRatio,@DocManualNo,@DocNote,
                                       @USERID,@InputDateTime,O.Barcode,IU.unit_id,O.Quantity,IU.EquivalentToMain,
                                        O.Price,O.Price,0,@StockCreditWhereHouse,@USERID,
                                         0,N'',ItemName,@WorkPeriod,@DocCode,@PosNo,'',O.Amount * @DiscountRatio,0 ,@TicketCode,'Orpak',@_DocID2
                                       from [dbo].SambaOrdersTemp O
									   left Join Items I on O.Barcode=I.ItemNo
									   Left Join Items_units IU on IU.item_id=O.Barcode And IU.main_unit=1
									   where O.TicketId=@TicketID
insert into Journal
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,ShiftID,CurrentUserID,DocCode,PosNo,LastDocCode,LastDataName,DocID2  ) VALUES(
                                       @VoucherNo,CAST(@DocDate AS DATE) ,2,1,@CostCenter ,@TempAccount,
                                        '0',@DefaultCurr,1,@TicketAmount,1,@TicketAmount,
                                       @TicketAmount,@DocManualNo,@DocNote,@USERID,@InputDateTime,
                                        0,N'',@WorkPeriod,@USERID,
                                        @DocCode,@PosNo,@TicketCode,'Orpak',@_DocID2)

Delete from #@Temp1 Where TicketID = @TicketID
End
Drop Table #@Temp1
Set @VouchersInJournalAmount=( select sum(DocAmount) from Journal where PosNo=@PosNo And ShiftID=@WorkPeriod And InputDateTime=@InputDateTime  )
return  @VouchersInJournalAmount
GO


--SET ----------------------------------------------------------------------------------------------------
--SET ----------------------------------------------------------------------------------------------------



ALTER PROCEDURE [dbo].[ProduceItem] @ItemNo int ,@UserID int,@Quantity float,@Unit int,@CostCenter int,
									@WahreHouse int,@BarCode varchar(50),@PosNo int,@DeviceName as varchar(50),
									@ItemName As nvarchar(100),@Referance int,@ReferanceName As nvarchar(100),
									@DocNote as nvarchar(1000),@LastDocCode as varchar(50),@DocID2 as int,@DocDate as Date
AS
DECLARE @EquationID int;
DECLARE @InputDateTime DATETIME;
Declare @DocID int;
DECLARE @DocCode as varchar(15);
Declare @ItemEquivalent as decimal (18,5)
SET @DocCode= ( select Right(NEWID(),15));
SET @InputDateTime= (select CONVERT(char(10), GetDate(),126) + ' ' + convert(VARCHAR(8), GETDATE(), 14))
--SET @DocDate= (select CONVERT(char(10), GetDate(),126))
--Set @DocID=(Select IsNull(Max(DocID),0)+1 from Journal Where DocName=19 )
SET @DocID = NEXT VALUE FOR dbo.ProductionVoucherSeq;
Set @ItemEquivalent= (Select EquivalentToMain from  [dbo].[Items_units]  where item_id=@ItemNo And unit_id= @Unit )
Insert INTO JournalTemp (
[DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
[DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
[BaseCurrAmount],[BaseAmount],[DocSort],[DocMultiCurrency],[InputUser],
[InputDateTime],[DocNotes],[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],
[StockPrice],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse],[StockBarcode],
[PosNo],[DeviceName],[DocCode],Referance,ReferanceName,ItemName,LastDocCode,DocID2 ) 
Select @DocID,@DocDate,19,4,@CostCenter,
'0','4090000000', 1 As [AccountCurr],1 As [DocCurrency],IsNull(@ItemEquivalent,1)*IsNull(I.LastPurchasePrice,0)*P.RawItemQuantity*IU.EquivalentToMain*@Quantity As [DocAmount],1 As [ExchangePrice],
IsNull(@ItemEquivalent,1)*IsNull(I.LastPurchasePrice,0)*P.RawItemQuantity*IU.EquivalentToMain*@Quantity As [BaseCurrAmount],IsNull(@ItemEquivalent,1)*IsNull(I.LastPurchasePrice,0)*P.RawItemQuantity*IU.EquivalentToMain*@Quantity As [BaseAmount],0 As [DocSort],0 As [DocMultiCurrency],@UserID,
@InputDateTime,@DocNote As [DocNotes],P.RawItemNo,P.RawItemUnit,@Quantity * [RawItemQuantity], IU.EquivalentToMain*@Quantity*[RawItemQuantity] As [StockQuantityByMainUnit],
IsNull(I.LastPurchasePrice,0)*IU.EquivalentToMain As [StockPrice], IsNull(I.LastPurchasePrice,0) As [StockItemPrice],0 As [StockDebitWhereHouse],@WahreHouse As [StockCreditWhereHouse],@BarCode,
@PosNo,@DeviceName,@DocCode,@Referance,@ReferanceName,I.ItemName,@LastDocCode,@DocID2  
from ProductionEquation P Left Join Items I on I.ItemNo=P.RawItemNo left Join Items_units IU on P.RawItemNo=IU.item_id And P.RawItemUnit=IU.unit_id Where P.ItemNo=@ItemNo

Declare @ItemCost float
Set @ItemCost= ( Select IsNull(Sum(DocAmount),0) from JournalTemp Where DocCode=@DocCode ) 

Insert INTO JournalTemp ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
[DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
[BaseCurrAmount],[BaseAmount],[DocSort],[DocMultiCurrency],[InputUser],
[InputDateTime],[DocNotes],[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],
[StockPrice],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse],[StockBarcode],
[PosNo],[DeviceName],[DocCode],[ItemName],Referance,ReferanceName,LastDocCode,DocID2 ) 
Select Top(1) @DocID,@DocDate,19,4,@CostCenter,
'4090000000','0', 1 As [AccountCurr],1 As [DocCurrency],@ItemCost As [DocAmount],1 As [ExchangePrice],
@ItemCost As [BaseCurrAmount],@ItemCost As [BaseAmount],0 As [DocSort],0 As [DocMultiCurrency],@UserID,
@InputDateTime,@DocNote As [DocNotes],P.[ItemNo],P.[ItemUnit],@Quantity * ItemQuantity, IU.EquivalentToMain*@Quantity*ItemQuantity As [StockQuantityByMainUnit],
@ItemCost As [StockPrice], @ItemCost As [StockItemPrice],@WahreHouse As [StockDebitWhereHouse],0 As [StockCreditWhereHouse],@BarCode,
@PosNo,@DeviceName,@DocCode,@ItemName,@Referance,@ReferanceName,@LastDocCode,@DocID2 
from ProductionEquation P Left Join Items I on I.ItemNo=P.ItemNo left Join Items_units IU on P.ItemNo=IU.item_id  And P.ItemUnit=IU.unit_id Where P.ItemNo=@ItemNo

insert Into Journal ([DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
[DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
[BaseCurrAmount],[BaseAmount],[DocSort],[DocMultiCurrency],[InputUser],
[InputDateTime],[DocNotes],[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],
[StockPrice],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse],[StockBarcode],
[PosNo],[DeviceName],[DocCode],ItemName,Referance,ReferanceName,LastDocCode,LastDataName,DocID2 )  Select [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],
[DebitAcc],[CredAcc],[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
[BaseCurrAmount],[BaseAmount],[DocSort],[DocMultiCurrency],[InputUser],
[InputDateTime],[DocNotes],[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit],
[StockPrice],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse],[StockBarcode],
[PosNo],[DeviceName],[DocCode],ItemName,Referance,ReferanceName,LastDocCode,'Journal',DocID2  from JournalTemp 

Delete From JournalTemp Where DocCode=@DocCode 

Update Items Set LastPurchasePrice=@ItemCost/ @Quantity,LastPurchaseDate=@DocDate where ItemNo=@ItemNo


return  @DocID;
GO

--SET ----------------------------------------------------------------------------------------------------
--SET ----------------------------------------------------------------------------------------------------


ALTER PROCEDURE [dbo].[SambaAdjustment] @USERID int, @PosNo int,@WorkPeriod int,@StartDate varchar(20),@EndDate varchar(20)
AS
  Declare @TicketAmount as float;
  Declare @OrderAmount as float;
  Declare @VoucherNo int;
  Declare @DocDate date;
  Declare @DocDateAsDate date;
  Declare @CostCenter int;
  Declare @DefaultCurr int;
  Declare @DocNote nvarchar(Max);
  Declare @DocCode varchar(15);
  Declare @StockCreditWhereHouse int;
  Declare @DiscountRatio decimal(18, 4);
  Declare @TempAccount varchar(10);
  Declare @DocManualNo nvarchar(50) ;
  Declare @TicketCode varchar(50);
  Declare @TicketNo int;
  Declare @Temp1 varchar(10);
  Declare @Temp2 varchar(10);
  Declare @Produce bit;
  Declare @TicketsCount int;
  Declare @TicketsAmount int;
  Declare @TicketIdFrom int;
  Declare @TicketIdTo int;
  Declare @OrdersCount int;
  Declare @VouchersInJournalAmount float;
  Declare @InputDateTime as datetime;
  Declare @_DocID2 int;
  Set @Temp1=( select Right(NEWID(),5))
  Set @CostCenter=( Select CostCenter from AccountingPOSNames Where ID=@PosNo  );
  Set @StockCreditWhereHouse=( Select Warehouse from AccountingPOSNames Where ID=@PosNo  );
  Set @InputDateTime=GETDATE()
  select Id as TicketID,TotalAmount As TicketAmount,IsNull(OrderAmount,0) As OrderAmount,IsNull((OrderAmount-TotalAmount),0) As Diff, IsNull(Case when OrderAmount = 0 then 1 else (OrderAmount-TotalAmount)/OrderAmount end,0) As DiscountRatio
  Into   #@Temp1 from 
  (select Id,TotalAmount from [SambaTicketsTemp]) A left Join 
  (select O.[TicketId],sum([Amount]) As OrderAmount  from [SambaOrdersTemp] O  group by [TicketId]) B
  on A.Id=B.TicketId ;
  Set @TicketIdFrom =( Select Min(TicketID) from #@Temp1 );
  Set @TicketIdTo =( Select Max(TicketID) from #@Temp1 );
  Set @TicketsAmount =( Select Sum(TicketAmount) from #@Temp1 );
  Set @TicketsCount =( Select Count(TicketID) from #@Temp1 );
  Set @OrdersCount=( Select Count(ID) From SambaOrdersTemp )
  Set @_DocID2=cast(CONVERT(varchar(20),@InputDateTime,112) as INT )+@PosNo+@WorkPeriod ;
  Insert into [SambaReadingLog] ([PeriodID],[PosNo],[FromDate],[ToDate],[Amount],[UserName],[FromTicket],[ToTicket],[TicketsCount],[OrdersCount],[ReadDateTime],[ReadBy],DocID2) 
		  Values (@WorkPeriod,@PosNo,@StartDate,@EndDate,@TicketsAmount,@USERID,@TicketIdFrom,@TicketIdTo,@TicketsCount,@OrdersCount,@InputDateTime,@USERID,@_DocID2)
  Declare @TicketID int;
  While (Select Count(*) From #@Temp1) > 0
  Begin
  Select Top 1 @TicketID = TicketID From #@Temp1 
  set @TicketAmount=( select TicketAmount from #@Temp1 where TicketID= @TicketID );
  set @OrderAmount=( select OrderAmount from #@Temp1 where TicketId= @TicketID );
  --Set @VoucherNo = ( Select IsNull(Max(DocID)+1,0)  from Journal where DocName=2 );
  SET @VoucherNo = NEXT VALUE FOR dbo.SalesInvoiceSeq;
  Set @DocDate=(Select [Date] from [SambaTicketsTemp] where Id= @TicketID  );
  Set @DocDateAsDate=CAST(@DocDate AS DATE)
  Set @TicketNo=(Select TicketNumber from [SambaTicketsTemp] where Id= @TicketID  );
  Set @DefaultCurr=( Select CurrID  from Currency where IsDefault=1  );
  Set @DocNote= CONCAT('Samba Voucher From (PosNo:' , @PosNo , ' WorkPeriod No:' , @WorkPeriod ,' User:' , @USERID,' TicketNo:' ,@TicketNo,')')  ;
  SET @DocCode= ( select Right(NEWID(),15));
  Set @DiscountRatio=(Select DiscountRatio from  #@Temp1 where TicketID=@TicketID )
  Set @TempAccount=(Select TempAccounting from AccountingPOSNames where Id=@PosNo)
  Set @DocManualNo= @TicketID 
  Set @TicketCode=(Select LEFT([TicketCode],50) TicketCode from SambaTicketsTemp where Id=@TicketID);
insert into Journal
       ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
                                       StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,StockCreditWhereHouse,
                                       CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,PosNo,DocNoteByAccount,VoucherDiscount,StockDiscount,LastDocCode,LastDataName,DocID2  ) 
                                       Select @VoucherNo,CAST(@DocDate AS DATE) ,2,1,@CostCenter,
                                       '0',I.AccSales,1,
                                       @DefaultCurr,O.Amount-O.Amount*@DiscountRatio,1,O.Amount-O.Amount*@DiscountRatio,O.Amount-O.Amount*@DiscountRatio,@DocManualNo,@DocNote,
                                       @USERID,@InputDateTime,I.ItemNo,IU.unit_id,O.Quantity,IU.EquivalentToMain*O.Quantity,
                                        O.Price,O.Price,0,@StockCreditWhereHouse,@USERID,
                                         0,N'',ItemName,@WorkPeriod,@DocCode,@PosNo,'',O.Amount * @DiscountRatio,0 ,@TicketCode,'Samba',@_DocID2
                                       from [dbo].SambaOrdersTemp O
									   Left Join Items_units IU on IU.item_unit_bar_code=O.Barcode And IU.main_unit=1
									   left Join Items I on IU.item_id=I.ItemNo
									   where O.TicketId=@TicketID
insert into Journal
                                     ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
                                       [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
                                       [DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,ShiftID,CurrentUserID,DocCode,PosNo,LastDocCode,LastDataName,DocID2  ) VALUES(
                                       @VoucherNo,CAST(@DocDate AS DATE) ,2,1,@CostCenter ,@TempAccount,
                                        '0',@DefaultCurr,1,@TicketAmount,1,@TicketAmount,
                                       @TicketAmount,@DocManualNo,@DocNote,@USERID,@InputDateTime,
                                        0,N'',@WorkPeriod,@USERID,
                                        @DocCode,@PosNo,@TicketCode,'Samba',@_DocID2)

Delete from #@Temp1 Where TicketID = @TicketID
End
Set @Temp2=( select Right(NEWID(),5))
--Select T.Id,Barcode,MenuItemName,Quantity,I.HasProductionEquation  Into #@Temp2 from SambaOrdersTemp T left join items I on I.ItemNo=T.Barcode where HasProductionEquation=1
Select T.Id,Barcode,MenuItemName,Quantity,I.HasProductionEquation  Into #@Temp2 from SambaOrdersTemp T left join Items_units IU on IU.item_unit_bar_code=T.Barcode left join Items I on IU.item_id=I.ItemNo where HasProductionEquation=1
Declare @Barcode varchar(100)
Declare @OrderID int;
While (Select Count(*) From #@Temp2) > 0
Begin
	Select Top 1 @OrderID = Id From #@Temp2 
	Declare @RowQuantity float;
	Declare @Unit int;
	Declare @RowItemName nvarchar(100);
	Declare @OrderNote nvarchar(1000);
	Declare @ItemNo int;
	set @Barcode= (Select Barcode from #@Temp2 where id=@OrderID)
	set @ItemNo = ( select item_id from Items_units where item_unit_bar_code=@Barcode )
	Set @RowQuantity=( Select Quantity from #@Temp2 where id=@OrderID );
	Set @Unit=( Select unit_id from Items_units where item_id=@ItemNo and main_unit=1 )
	Set @RowItemName=( select MenuItemName from #@Temp2 where id=@OrderID )
	Set @TicketNo=( select @TicketNo from #@Temp2 where id=@OrderID )
	Set @OrderNote=CONCAT('Samba Voucher From (PosNo:' , @PosNo , ' WorkPeriod No:' , @WorkPeriod ,' User:' , @USERID,' TicketNo:' ,@TicketNo,')')  ;
EXEC  [dbo].[ProduceItem] @ItemNo=@ItemNo,@UserID=1,@Quantity=@RowQuantity,@Unit=@Unit,@CostCenter=@CostCenter,@WahreHouse=@StockCreditWhereHouse,@BarCode=0,@PosNo=@PosNo,@DeviceName='Auto',@ItemName=@RowItemName,@Referance=0,@ReferanceName='',@DocNote=@OrderNote,@LastDocCode=@DocCode,@DocID2=@_DocID2,@DocDate=@DocDateAsDate;
	Delete from #@Temp2 Where Id = @OrderID
End
Drop Table #@Temp2
Drop Table #@Temp1
Set @VouchersInJournalAmount=( select sum(DocAmount) from Journal where PosNo=@PosNo And ShiftID=@WorkPeriod And InputDateTime=@InputDateTime  )
return  @VouchersInJournalAmount
GO


--SET ----------------------------------------------------------------------------------------------------
--SET ----------------------------------------------------------------------------------------------------


Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('Samba_SendPaymentsReportToWhatsApp','False',N' في نظام السامبا ، ارسال تقرير دفعات الموردين واتس اب مع التقرير اليومي ','Samba')
Go

ALTER TABLE [dbo].[POSJournal] Add [TableID] int  NULL
Go
ALTER TABLE [dbo].[POSHoldJournal] Add [TableID] int  NULL
Go
ALTER TABLE [dbo].[Journal] Add  [TableID] int NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [TableID] int NULL
Go

CREATE TABLE [dbo].[PosTables](
	[TableID] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](max) NOT NULL,
	[Location] [int] NOT NULL,
	[POSNo] [int] NOT NULL,
	[IsReserved] [bit] NOT NULL,
 CONSTRAINT [PK_PosTables] PRIMARY KEY CLUSTERED 
(
	[TableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[PosTables] ADD  CONSTRAINT [DF_PosTables_Location]  DEFAULT ((1)) FOR [Location]
GO

ALTER TABLE [dbo].[PosTables] ADD  CONSTRAINT [DF_PosTables_IsReserved]  DEFAULT ((0)) FOR [IsReserved]
GO

ALTER TABLE [dbo].[AccountingPOSNames] Add  [ResturantMode] Bit NULL  DEFAULT ((0))
Go
ALTER TABLE [dbo].[AccountingPOSNames] Add  [PrintVoucherByItemGroup] Bit NULL  DEFAULT ((0))
Go

ALTER TABLE JardJournal ADD ItemCost float DEFAULT 0;
Go

ALTER TABLE JardJournal ADD ShelfID int DEFAULT 0;
Go

Alter table EmployeesData add DefaultLanguage [nvarchar](10) NULL
GO

ALTER TABLE Items  ADD ItemColor int NULL DEFAULT (0)
Go
ALTER TABLE Items  ADD ItemSize int NULL DEFAULT (0)
Go


ALTER TABLE [JOURNAL] ADD [RecordDateTime] DATETIME DEFAULT GETDATE();
Go
ALTER TABLE [PosVouchers] ADD [RecordDateTime] DATETIME DEFAULT GETDATE();
Go


CREATE TABLE [dbo].[PosTablesLocations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [nvarchar](max) NOT NULL,
	[PosNo] [int] NOT NULL,
 CONSTRAINT [PK_PosTablesLocations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [EmployeesData]
ADD CanEditPrice BIT DEFAULT 0;
Go

ALTER TABLE [EmployeesData]
ADD ShowBonus BIT DEFAULT 0;
Go

ALTER TABLE [EmployeesData]
ADD ShowSalesinvoice BIT DEFAULT 0;
Go

ALTER TABLE [EmployeesData]
ADD ReceiptVoucher BIT DEFAULT 0;
Go

ALTER TABLE JardJournalList
ADD Posted BIT DEFAULT 0;
Go

ALTER TABLE JardJournalList
ADD DocID int DEFAULT 0;
Go


ALTER TABLE [dbo].[PosVouchers] Add  [TableID] int DEFAULT 0
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [TableID] int DEFAULT 0
Go
ALTER TABLE [dbo].[OrdersAppJournal] Add  [TableID] int DEFAULT 0
Go
ALTER TABLE [dbo].[POSDeletedJournal] Add [TableID] int DEFAULT 0
Go
ALTER TABLE [dbo].[POSHoldJournal] Add [TableID] int DEFAULT 0
Go




ALTER TABLE [dbo].[Journal] Add  [DispatchQuantity] float NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [DispatchQuantity] float NULL
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add  [DispatchQuantity] float NULL
Go
ALTER TABLE [dbo].[Journal] Add  [DispatchStockQuantityByMainUnit] float NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [DispatchStockQuantityByMainUnit] float NULL
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add  [DispatchStockQuantityByMainUnit] float NULL
Go
ALTER TABLE [dbo].[Journal] Add  [DispatchVoucherID] int NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [DispatchVoucherID] int NULL
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add  [DispatchVoucherID] int NULL
Go


Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('POS_ScaleComNO','4',N' في نقطة البيع، رقم مدخل الميزان ','POS')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('POS_ShowLastPurchasePrice','False',N' في نقطة البيع، عرض سعر الشراء ','POS')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('POS_ShowLastTransForCustomer','False',N' في نقطة البيع، عرض حركة الصنف في شاشة تعديل الصنف ','POS')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('Accounting_UseSubAccounts','False',N' في النظام المالي، تغعيل بند الحسابات الفرعية ','Accounting')
Go

ALTER TABLE [EmployeesData]
ADD SelfService_WhoTo_Notify nvarchar(50) DEFAULT '';
Go
Update [EmployeesData] Set SelfService_WhoTo_Notify='' Where SelfService_WhoTo_Notify Is Null


ALTER TABLE [dbo].[Journal] Add  [SubAccount] int NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [SubAccount] int NULL
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add  [SubAccount] int NULL
Go


CREATE TABLE [dbo].[ReferancesSub](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RefNo] [int] NOT NULL,
	[SubRefName] [nvarchar](max) NOT NULL,
	[RefMobile] [nvarchar](50) NULL,
	[RefNote] [nvarchar](max) NULL,
 CONSTRAINT [PK_ReferancesSub] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

Update CostCenter Set CostCenterStatus=1 Where CostCenterStatus Is NULL
Go


CREATE TABLE [dbo].[Areas](
	[AreaId] [int] IDENTITY(1,1) NOT NULL,
	[AreaName] [nvarchar](100) NOT NULL,
	[CityId] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[DeliveryPrice] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[AreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Areas] ADD  DEFAULT ((1)) FOR [IsActive]
GO

CREATE TABLE CashCustomer (
    CustomerID INT IDENTITY(1,1) ,
    CustomerCode NVARCHAR(20) NOT NULL,
    CustomerNo INT NOT NULL,
    CustomerName NVARCHAR(100) NOT NULL,
    Mobile NVARCHAR(20) NOT NULL PRIMARY KEY,
    Mobile2 NVARCHAR(20) NULL,
    CityID INT NULL,
    AreaID INT NULL,
    Address NVARCHAR(255) NULL,
    Notes NVARCHAR(MAX) NULL,
    IsActive BIT DEFAULT 1,
    CreatedDate DATETIME DEFAULT GETDATE()
);
Go
-- Create indexes for better performance
CREATE INDEX IX_CashCustomer_CustomerCode ON CashCustomer(CustomerCode);
Go
CREATE INDEX IX_CashCustomer_CustomerName ON CashCustomer(CustomerName);
Go
CREATE INDEX IX_CashCustomer_Mobile ON CashCustomer(Mobile);
Go
CREATE INDEX IX_Areas_CityId ON Areas(CityId);
Go

ALTER TABLE [dbo].[Journal] Add  [CashCustomerId] int NULL
Go
ALTER TABLE [dbo].[JournalTemp] Add  [CashCustomerId] int NULL
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add  [CashCustomerId] int NULL
Go
ALTER TABLE [dbo].[PosVouchers] Add  [CashCustomerId] int NULL
Go


Insert Into [dbo].[Settings] (SettingName,SettingValue) values ('PrintRefBalanceInVoucher','False')
Go

Update  [dbo].[Settings] Set SettingDescription=N'طباعة رصيد الزبون في الفواتير ' ,[SettingTerm]='Accounting' Where SettingName =N'PrintRefBalanceInVoucher'
Go
Update  [dbo].[Settings] Set SettingDescription=N' طباعة رصيد الزبون في سندات نقطة البيع ' ,[SettingTerm]='POS' Where SettingName =N'PosPrintReferanceBalance'
Go




CREATE NONCLUSTERED INDEX IX_Items_units_item_unit_bar_code
ON dbo.Items_units(item_unit_bar_code);
Go

CREATE UNIQUE NONCLUSTERED INDEX UX_Items_ItemNo
ON dbo.Items(ItemNo);
Go

CREATE UNIQUE NONCLUSTERED INDEX UX_Referencess_RefNo
ON dbo.Referencess(RefNo);
Go

CREATE NONCLUSTERED INDEX IX_Journal_DocID_DocName
ON dbo.Journal(DocID, DocName);
Go

CREATE NONCLUSTERED INDEX IX_Journal_DocCode ON dbo.Journal(DocCode);
Go



Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('POS_SendVouchersAsWhatsAppToNumbers','False',N' في نقطة البيع، ارسال الفواتير عن طريق الواتس الى ارقام الموبايل للمسؤولين ','POS')
Go

Update [dbo].[CheksTransTypes] Set [TransTypeAr]=N'ارجاع شيك صادر من البنك الى المورد' Where [TransID]=7
Go

Insert Into [dbo].[ChecksStatus] ([CheckStatus],[CheckInOutType],[ID]) values (N'مسترجع من المورد','Out',14)
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('HR_HideBunosPeriodInSalarySlip','False',N' في نظام الرواتب، اخفاء ساعات العمل الاضافي من قسيمة الراتب ','HR')
Go

ALTER TABLE [dbo].[CampaginByItemsCount] Add  [OnlyThisBarcode] bit NULL
Go

ALTER TABLE [dbo].[CampaginByItemsCount] Add  [Barcode] varchar(50) NULL
Go

ALTER TABLE [dbo].[CampaginByItemsCount] Add  [UnitID] int NULL
Go

Update AccountingPOSNames Set PaperSize='80*80' Where PaperSize=0
Go

/****** كود ادخال الصنف ع الفاتورة في نقطة البيع   ******/
ALTER PROCEDURE [dbo].[InsertIntoPOSJournal] @Barcode varchar(50) ,@DocName int,@Quantity float,
									         @WahreHouse int,@DocCode varchar(50),@ReferanceNo int,
										     @Device varchar(50),@ShiftID int ,@POSNo int,@UserNo int,
										     @ItemNo int,@Unit int,@shelf int,@NoteByItem Nvarchar(Max),@OutputID INT OUTPUT
						AS
						Declare @PriceCategory  int;
						declare @Price decimal(10,2);
						Declare @ReferanceName nvarchar(MAX)
						Set @ReferanceName=N'زبون نقدي'
						if @ReferanceNo =0 begin Set @PriceCategory=1 end else begin Set @PriceCategory= (select IsNull(PriceCategory,1)   from Referencess where RefNo=@ReferanceNo  ) end;
						if @ReferanceNo <> 0 begin Set @ReferanceName=(Select top(1) RefName From Referencess Where RefNo=@ReferanceNo) end;
						if @Barcode<>'0' begin
						Set @Price= ( select top(1) case when  @PriceCategory=1 then IU.Price1  when @PriceCategory=2 then IsNull(IU.Price2,IU.Price1) when @PriceCategory=3 then IsNull(IU.Price3,IU.Price1)   end as StockPrice from  dbo.Items_units IU   where  IU.item_unit_bar_code=@Barcode);
						Declare @AllowMerge varchar(10) ;
						Set @AllowMerge = ( Select SettingValue from Settings where SettingName='PosAllowMergeItems' )
						Declare @TransID int;
						Set @TransID= ( Select top(1) id from POSJournal where StockBarcode=@Barcode and PosNo=@POSNo and DeviceName=@Device order by id desc  )
						Declare @PriceEdited Bit ;
						Set @PriceEdited= ( select top(1) IsNull(PriceEdited,0) from POSJournal where id=@TransID );

						Declare @GroupID int;
						Declare @PrinterName nvarchar(MAX);
						Declare @LastPurchasePrice Float;
						Set @GroupID= ( Select top(1) IsNull(GroupID,0) As GroupID  from Items I where I.ItemNo=@ItemNo  )
						Set @PrinterName = ( Select DefaultPrinter from ItemsGroups G where G.GroupID=@GroupID   )

						if @Barcode='0' 
						begin 
						Set @LastPurchasePrice= ( Select top(1) IsNull(LastPurchasePrice,0) As LastPurchasePrice  from Items I where I.ItemNo=@ItemNo  )
						end
						if @Barcode<>'0' 
						begin 
						Set @LastPurchasePrice= ( Select top(1) IsNull(LastPurchasePrice,0) As LastPurchasePrice  from Items I  left Join Items_units IU on IU.item_id=I.itemNo  where IU.item_unit_bar_code=@Barcode  )
						end

						DECLARE @OutputTable TABLE (ID INT)
						IF @AllowMerge='True' and @PriceEdited<>1  and  EXISTS(SELECT 1 FROM dbo.POSJournal WITH(NOLOCK)
								  WHERE StockBarcode = @Barcode and PosNo=@POSNo and @Barcode<>'0' and DeviceName=@Device AND ID = ( SELECT TOP 1 ID FROM dbo.POSJournal WITH (NOLOCK) WHERE  PosNo = @POSNo AND DeviceName = @Device ORDER BY ID DESC ) )
							BEGIN
							Declare @Equivelant decimal(18,2)
							Set @Equivelant= ( select EquivalentToMain from Items_units where item_unit_bar_code=@Barcode )
								Update POSJournal set StockQuantity=StockQuantity+@Quantity,StockQuantityByMainUnit=(StockQuantity+@Quantity)*@Equivelant,DocAmount=DocAmount+@Quantity*@Price,StockDiscount=(StockDiscount*StockQuantity)/(StockQuantity+@Quantity) OUTPUT inserted.ID INTO @OutputTable(ID) WHERE id=@TransID 
								--select @TransID as TransID
							END
						ELSE
							BEGIN
						if @DocName=2 
							begin 
							Insert Into [dbo].[POSJournal] ([StockID],ItemName,DebitAcc,CredAcc,StockDebitWhereHouse,
															[StockCreditWhereHouse],[StockDebitShelve],[StockCreditShelve],AccountCurr,StockUnit,StockPrice,UnitName,SaleOnScale,[StockQuantity],
															[StockQuantityByMainUnit],DocAmount,[DocCode],[StockDiscount],[StockBarcode],
															[InputUser],DeviceName,[ShiftID],PosNo,Produced,DocNoteByAccount,PrinterName,LastPurchasePrice,Referance,ReferanceName ) OUTPUT inserted.ID INTO @OutputTable(ID)
							Select top(1) [ItemNo] as StockID ,ItemName ,'0' as DebitAcc ,[AccSales] as CredAcc,0, @WahreHouse,0,@shelf,1,IU.unit_id As StockUnit ,
												   @Price as StockPrice,U.name as UnitName ,SaleOnScale , @Quantity,
												   IU.[EquivalentToMain]*@Quantity, @Price  * @Quantity,@DocCode,
												   0  as StockDiscount,[item_unit_bar_code],@UserNo,
												   @Device,@ShiftID,@POSNo,IsNull(HasProductionEquation,0) As Produced,@NoteByItem,@PrinterName,@LastPurchasePrice,@ReferanceNo,@ReferanceName
												   from dbo.Items I 
												   left join dbo.Items_units IU on IU.item_id = I.ItemNo left join Units U on U.id=IU.unit_id where  item_unit_bar_code=@Barcode;

							end
							if @DocName =12
							begin 
							Insert Into [dbo].[POSJournal] (StockID,ItemName,DebitAcc,CredAcc,StockDebitWhereHouse,
													  StockCreditWhereHouse,[StockDebitShelve],[StockCreditShelve],AccountCurr,StockUnit,StockPrice,UnitName,SaleOnScale,[StockQuantity],
													  StockQuantityByMainUnit,DocAmount,[DocCode],[StockDiscount],[StockBarcode],
													  [InputUser],DeviceName,[ShiftID],PosNo,Produced,DocNoteByAccount,LastPurchasePrice,Referance,ReferanceName ) OUTPUT inserted.ID INTO @OutputTable(ID)
											Select top(1) [ItemNo] as StockID ,ItemName,[AccRetSales] as DebitAcc ,'0' as CredAcc,@WahreHouse,'0',@shelf,0,1,IU.unit_id As StockUnit ,
												   @Price as StockPrice,U.name as UnitName ,SaleOnScale , @Quantity,
												   IU.[EquivalentToMain], @Price  * @Quantity,@DocCode,
												   0  as StockDiscount,[item_unit_bar_code],@UserNo,
												   @Device,@ShiftID,@POSNo,IsNull(HasProductionEquation,0) As Produced,@NoteByItem,@LastPurchasePrice,@ReferanceNo,@ReferanceName
												   from dbo.Items I 
												   left join dbo.Items_units IU on IU.item_id = I.ItemNo left join Units U on U.id=IU.unit_id where  item_unit_bar_code=@Barcode;
												 
							end
						end

						END
						if @Barcode='0' begin


						if @Unit=0 Begin Set @Unit=( select top(1) unit_id  from Items_units where item_id=@ItemNo and main_unit=1  ) end
							Set @Price= ( select top(1) case when  @PriceCategory=1 then IU.Price1  when @PriceCategory=2 then IsNull(IU.Price2,IU.Price1) when @PriceCategory=3 then IsNull(IU.Price3,IU.Price1)   end as StockPrice from Items I left join dbo.Items_units IU on IU.item_id = I.ItemNo left join Units U on U.id=IU.unit_id where   [item_id]=@ItemNo and IU.unit_id=@Unit);
							if @DocName=2 
							begin 
	
							Insert Into [dbo].[POSJournal] ([StockID],ItemName,DebitAcc,CredAcc,StockDebitWhereHouse,
															[StockCreditWhereHouse],[StockDebitShelve],[StockCreditShelve],AccountCurr,StockUnit,StockPrice,UnitName,SaleOnScale,[StockQuantity],
															[StockQuantityByMainUnit],DocAmount,[DocCode],[StockDiscount],[StockBarcode],
															[InputUser],DeviceName,[ShiftID],PosNo,Produced,DocNoteByAccount,PrinterName,LastPurchasePrice,Referance,ReferanceName ) OUTPUT inserted.ID INTO @OutputTable(ID)
							Select top(1) [ItemNo] as StockID ,ItemName ,'0' as DebitAcc ,[AccSales] as CredAcc,0, @WahreHouse,0,@shelf,1,IU.unit_id As StockUnit ,
												   @Price as StockPrice,U.name as UnitName ,SaleOnScale , @Quantity,
												   IU.[EquivalentToMain], @Price  * @Quantity,@DocCode,
												   0  as StockDiscount,[item_unit_bar_code],@UserNo,
												   @Device,@ShiftID,@POSNo,IsNull(HasProductionEquation,0) As Produced,@NoteByItem,@PrinterName,@LastPurchasePrice,@ReferanceNo,@ReferanceName
												   from dbo.Items I 
												   left join dbo.Items_units IU on IU.item_id = I.ItemNo left join Units U on U.id=IU.unit_id where  [item_id]=@ItemNo and IU.unit_id=@Unit;
												   
							end
							if @DocName =12
							begin 
							Insert Into [dbo].[POSJournal] (StockID,ItemName,DebitAcc,CredAcc,StockDebitWhereHouse,
													  StockCreditWhereHouse,[StockDebitShelve],[StockCreditShelve],AccountCurr,StockUnit,StockPrice,UnitName,SaleOnScale,[StockQuantity],
													  StockQuantityByMainUnit,DocAmount,[DocCode],[StockDiscount],[StockBarcode],
													  [InputUser],DeviceName,[ShiftID],PosNo,Produced,DocNoteByAccount,LastPurchasePrice,Referance,ReferanceName ) OUTPUT inserted.ID INTO @OutputTable(ID)
											Select top(1) [ItemNo] as StockID ,ItemName,[AccRetSales] as DebitAcc ,'0' as CredAcc,@WahreHouse,'0',@shelf,0,1,IU.unit_id As StockUnit ,
												   @Price as StockPrice,U.name as UnitName ,SaleOnScale , @Quantity,
												   IU.[EquivalentToMain] * @Quantity, @Price  * @Quantity,@DocCode,
												   0  as StockDiscount,[item_unit_bar_code],@UserNo,
												   @Device,@ShiftID,@POSNo,IsNull(HasProductionEquation,0) As Produced,@NoteByItem,@LastPurchasePrice,@ReferanceNo,@ReferanceName
												   from dbo.Items I 
												  left join dbo.Items_units IU on IU.item_id = I.ItemNo left join Units U on U.id=IU.unit_id where  [item_id]=@ItemNo and IU.unit_id=@Unit;
												   
							end
						end
					EXEC	 [dbo].[ApplyCampagins]		@Barcode = @Barcode , @DocCode=@DocCode , @UnitID=@Unit , @ItemNo=@ItemNo
					SELECT TOP 1 @OutputID = ID FROM @OutputTable

GO
/****** كود ادخال الصنف ع الفاتورة في نقطة البيع   ******/

ALTER VIEW [dbo].[vw_Emp_vacations]
AS
SELECT        dbo.EmployeesData.EmployeeName, dbo.EmployeesData.EmployeeID, dbo.VocationsPending.FromDate, dbo.VocationsPending.ToDate, dbo.VocationsPending.NoDays, dbo.VocationsPending.VocID, 
                         dbo.WF_Request_Workflow_Approvals.Id, dbo.WF_Request_Workflow_Approvals.show, dbo.WF_Request_Workflow_Approvals.Employee_Id AS emp_to_approve, dbo.WF_Request_Workflow_Approvals.Note, 
                         dbo.WF_Request_Workflow_Approvals.Status, dbo.VocationsPending.Path, dbo.VocationsPending.DocStatus AS FinalStatus, dbo.WF_Request_Workflow_Approvals.Order_, dbo.WF_Request_Workflow_Approvals.Request_type, 
                         dbo.WF_Request_Workflow_Approvals.Who_Approve, dbo.WF_Request_Workflow_Approvals.Job_name, dbo.WF_Request_Workflow_Approvals.Mobiles, dbo.WF_Request_Workflow_Approvals.Type, 
                         dbo.EmployeesData.Mobile1, dbo.VocationsPending.NoteDetails AS EmployeeNote, ISNULL
                             ((SELECT        EmployeeName
                                 FROM            dbo.EmployeesData AS E1
                                 WHERE        (EmployeeID = dbo.EmployeesData.ManagerIdForWeb)), '') AS Manager, dbo.VocationsPending.DocInputDateTime, ISNULL
                             ((SELECT        EmployeeName
                                 FROM            dbo.EmployeesData AS E1
                                 WHERE        (EmployeeID = dbo.WF_Request_Workflow_Approvals.Employee_Id)), '') AS emp_to_approve_Name, dbo.EmployeesData.DefaultLanguage
FROM            dbo.EmployeesData INNER JOIN
                         dbo.VocationsPending ON dbo.EmployeesData.EmployeeID = dbo.VocationsPending.EmployeeID INNER JOIN
                         dbo.WF_Request_Workflow_Approvals ON dbo.VocationsPending.VocID = dbo.WF_Request_Workflow_Approvals.Request_Id
WHERE        (dbo.WF_Request_Workflow_Approvals.Request_type = N'V')
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('Accounting_ShowColumnBonusInVouchers','False',N' في النظام المالي، عرض عمود البونص في سندات البضاعة ','Accounting')
Go

ALTER TABLE [dbo].[EmployeesData] ADD AboutEmp NVarchar(MAX)
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('Accounting_ShowWarningForCashAccountInPayments','False',N' في النظام المالي، عرض رسالة تحذير اذا لم يتوفر المبلغ النقدي بالصندوق في سند الصرف ','Accounting')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('POS_DefaultModeInPosSystem',N'Tables',N' في نقطة البيع، الوضع الافتراضي في وضع المطعم ','POS')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('Accounting_CostingMethodInProduction',N'LastPurchasePrice',N' في بند الانتاج ، طريقة تفييم المخزون لمواد الخام ','Accounting')
Go

ALTER TABLE [dbo].[CostCenter] ADD CompletionRate int  DEFAULT 0;
Go

ALTER TABLE [dbo].[CostCenter] ADD Supplier int  DEFAULT 0;
Go


CREATE TABLE [dbo].[AttCHECKINOUTNotes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_AttCHECKINOUTNotes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('SelfService_ShowInOutNotes',N'False',N' في نظام الخدمة الذاتية ، عرض حقل الملاحظة عند تسجيل حركات الدوام ','SelfService')
Go

-- =============================================
CREATE PROCEDURE [dbo].[UpdateSequences] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DECLARE @SQL NVARCHAR(MAX) = '';
DECLARE @DocName NVARCHAR(100);
DECLARE @DocID INT;
DECLARE doc_cursor CURSOR FOR 
SELECT id, 
       CASE id 
            WHEN 1 THEN 'PurchaseInvoiceSeq'
            WHEN 2 THEN 'SalesInvoiceSeq'
            WHEN 3 THEN 'PaymentVoucherSeq'
            WHEN 4 THEN 'ReceiptVoucherSeq'
            WHEN 5 THEN 'JournalVoucherSeq'
            WHEN 6 THEN 'DebitNoteSeq'
            WHEN 7 THEN 'CreditNoteSeq'
            WHEN 8 THEN 'PurchaseDispatchSeq'
            WHEN 9 THEN 'SalesDispatchSeq'
            WHEN 10 THEN 'PurchaseOrderSeq'
            WHEN 11 THEN 'SalesOrderSeq'
            WHEN 12 THEN 'SalesReturnsSeq'
            WHEN 13 THEN 'PurchaseReturnsSeq'
            WHEN 16 THEN 'InternalDispatchSeq'
            WHEN 17 THEN 'StockEntryVoucherSeq'
            WHEN 18 THEN 'StockExitVoucherSeq'
            WHEN 19 THEN 'ProductionVoucherSeq'
       END AS SequenceName
FROM (VALUES 
    (1), (2), (3), (4), (5), (6), (7), (8), (9), 
    (10), (11), (12), (13), (16), (17), (18), (19)
) AS Docs(id)
WHERE id IS NOT NULL; -- Ensure ID is not NULL

OPEN doc_cursor;
FETCH NEXT FROM doc_cursor INTO @DocID, @DocName;

WHILE @@FETCH_STATUS = 0
BEGIN
    DECLARE @MaxDocID INT;
    
    -- Get the highest existing DocID for this document type
    SELECT @MaxDocID = COALESCE(MAX(DocID), 0) FROM Journal WHERE DocName = @DocID; 

    -- Check if sequence exists before updating
    IF EXISTS (SELECT 1 FROM sys.sequences WHERE name = @DocName)
    BEGIN
        SET @SQL = 'ALTER SEQUENCE dbo.' + QUOTENAME(@DocName) + ' 
                    RESTART WITH ' + CAST(@MaxDocID +1  AS NVARCHAR(20)) + ';';

        EXEC sp_executesql @SQL;

        PRINT 'Sequence ' + @DocName + ' updated successfully to START from: ' + CAST(@MaxDocID AS NVARCHAR(20));
    END
    ELSE
    BEGIN
        PRINT 'Sequence ' + @DocName + ' does not exist. Skipping update.';
    END

    FETCH NEXT FROM doc_cursor INTO @DocID, @DocName;
END;

CLOSE doc_cursor;
DEALLOCATE doc_cursor;
END
GO


DROP PROCEDURE [dbo].[BuildVoucherFromWEB]
GO

DROP PROCEDURE [dbo].[BuildReceiptFromWEB]
GO

DROP TYPE [dbo].[TVP_VoucherItems]
GO

DROP TYPE [dbo].[TVP_Cheques]
GO

-- بناء TYPEs --
CREATE TYPE [dbo].[TVP_VoucherItems] AS TABLE(
	[ItemNo] [int] NULL,
	[ItemName] [nvarchar](200) NULL,
	[Quantity] [float] NULL,
	[UnitID] [int] NULL,
	[Price] [float] NULL,
	[Amount] [float] NULL,
    [BonusQuantity] decimal(18, 4) NULL,
	[Discount] decimal(18, 4) NULL,
	[DocNoteByAccount] [nvarchar](MAX) NULL
)
GO

CREATE TYPE [dbo].[TVP_Cheques] AS TABLE(
	[ChequeNo] [nvarchar](50) NOT NULL,
	[ChequeDueDate] [date] NOT NULL,
	[ChequeBank] [int] NOT NULL,
	[ChequeBankBranch] [int] NOT NULL,
	[ChequeAccountNo] [nvarchar](50) NOT NULL,
	[ChequeAmount] [decimal](18, 2) NOT NULL,
	[BankAccount] [int] NOT NULL
)
GO

------------------------------
-- ترحيل فاتورة من الويب --
------------------------------
CREATE PROCEDURE [dbo].[BuildVoucherFromWEB] 
@ReferanceNo INT,
@DocDate DATE,
@UserID INT,
@DocNote NVARCHAR(MAX),
@DeviceName NVARCHAR(MAX),
@CurrencyID INT,
@DocName INT,
@StockCreditWhereHouse INT,
@StockDebitWhereHouse INT,
@Amount FLOAT,
@DocID INT,
@SalesMan INT,
@VoucherItemsDetails TVP_VoucherItems READONLY
AS
BEGIN
BEGIN TRANSACTION;
BEGIN TRY
DECLARE @OtherSideAccount VARCHAR(15);
DECLARE @ReferanceAccountCurr INT;
DECLARE @DefaultCurr INT;
DECLARE @InputDateTime DATETIME;
DECLARE @ModifiedDateTime DATETIME;
DECLARE @ReferanceName NVARCHAR(50);
DECLARE @ReferanceAccount VARCHAR(50);
DECLARE @DocCode nvarchar(150) = NEWID()
DECLARE @UserName NVARCHAR(100);
DECLARE @TotalAmount FLOAT;

SET @OtherSideAccount = (SELECT TOP(1) RefAccID FROM Referencess WHERE RefNo = @ReferanceNo);
SET @DefaultCurr = (SELECT CurrID FROM Currency WHERE IsDefault = 1);
SET @InputDateTime = GETDATE();
SET @ModifiedDateTime = GETDATE();
SET @ReferanceName = (SELECT RefName FROM Referencess WHERE RefNo = @ReferanceNo);
SET @ReferanceAccount = (SELECT RefAccID FROM Referencess WHERE RefNo = @ReferanceNo);
SET @ReferanceAccountCurr = (SELECT Currency FROM FinancialAccounts WHERE AccNo = @ReferanceAccount);
SET @UserName = (SELECT EmployeeName FROM EmployeesData WHERE EmployeeID = @UserID);
SET @TotalAmount = (SELECT SUM(ISNULL(Quantity, 0) * ISNULL(Price, 0)) FROM @VoucherItemsDetails);

-- تعيين `DocID` بناءً على نوع المستند
IF @DocID = 0
Begin
	IF @DocName = 2 
	BEGIN
	SET @DocID = NEXT VALUE FOR dbo.SalesInvoiceSeq;
	END
	ELSE IF @DocName = 1
	BEGIN
	SET @DocID = NEXT VALUE FOR dbo.PurchaseInvoiceSeq;
	END
END

-- Sales voucher 
IF @DocName=2 
Begin


--Add Debit Side
insert into JournalTemp (
  [DocID], [DocDate], [DocName], [DocStatus], 
  [DebitAcc], [CredAcc], [AccountCurr], 
  [DocCurrency], [DocAmount], [ExchangePrice], 
  [BaseCurrAmount], [BaseAmount],[DocManualNo], [DocNotes],
  InputUser,InputDateTime, ModifiedDateTime, 
  DeviceName, 
  CurrentUserID,Referance, ReferanceName, 
  AccountBank, DocCode, 
  DocCostCenter, DocNoteByAccount, 
   DocTags, SalesPerson,StockID,OrderID
) 
Values 
  (
    @DocID, @DocDate, @DocName, '1',
	@ReferanceAccount,'0', '1',
	@DefaultCurr, @TotalAmount, '1', 
	@TotalAmount,@TotalAmount, N'0', @DocNote, 
    @UserID, @InputDateTime, @ModifiedDateTime, 
    @DeviceName, 
    @UserID, @ReferanceNo, @ReferanceName, 
    '', @DocCode,  '1', N'', 
    N'', @SalesMan,0,0
  );

--Add Items Side
insert into JournalTemp (
  [DocID], [DocDate], [DocName], [DocStatus], 
  [DebitAcc], [CredAcc], [AccountCurr], 
  [DocCurrency], [DocAmount], [ExchangePrice], 
  [BaseCurrAmount], [BaseAmount],[DocManualNo], [DocNotes],
  InputUser,InputDateTime, ModifiedDateTime, 
  DeviceName, StockID, ItemName, 
  CurrentUserID,Referance, ReferanceName, StockQuantity,StockQuantityByMainUnit, StockPrice, 
  AccountBank, DocCode,DocCostCenter, DocNoteByAccount, DocTags, SalesPerson,StockDebitWhereHouse,StockCreditWhereHouse,StockUnit,Color,Measure,VoucherDiscount,ItemVAT,OrderID,LastPurchasePrice
) 
Select 
    @DocID, @DocDate, @DocName, '1',
	'0',I.AccSales, '1',
	@DefaultCurr, V.Price*V.Quantity, '1', 
	V.Price*V.Quantity,V.Price*V.Quantity, N'0', @DocNote, 
    @UserID, @InputDateTime, @ModifiedDateTime, 
    @DeviceName, V.ItemNo, V.ItemName, 
    @UserID, @ReferanceNo, @ReferanceName, V.Quantity, V.Quantity, V.Price, 
    '', @DocCode, '1', N'', N'', @SalesMan,0,@StockCreditWhereHouse,V.UnitID,0 As Color,0 As Measure,0 As VoucherDiscount, 0 As ItemVAT,0 As OrderID,I.LastPurchasePrice
  From @VoucherItemsDetails V left join Items I on V.ItemNo=I.ItemNo ;


End

-- Purchase voucher 
IF @DocName=1 
Begin
--Add Debit Side
insert into JournalTemp (
  [DocID], [DocDate], [DocName], [DocStatus], 
  [DebitAcc], [CredAcc], [AccountCurr], 
  [DocCurrency], [DocAmount], [ExchangePrice], 
  [BaseCurrAmount], [BaseAmount],[DocManualNo], [DocNotes],
  InputUser,InputDateTime, ModifiedDateTime, 
  DeviceName, 
  CurrentUserID,Referance, ReferanceName, 
  AccountBank, DocCode, 
  DocCostCenter, DocNoteByAccount, 
   DocTags, SalesPerson,StockID,OrderID
) 
Values 
  (
    @DocID, @DocDate, @DocName, '1',
	'0',@ReferanceAccount, '1',
	@DefaultCurr, @TotalAmount, '1', 
	@TotalAmount,@TotalAmount, N'0', @DocNote, 
    @UserID, @InputDateTime, @ModifiedDateTime, 
    @DeviceName, 
    @UserID, @ReferanceNo, @ReferanceName, 
    '', @DocCode,  '1', N'', 
    N'', @SalesMan,0,0
  );

--Add Items Side
insert into JournalTemp (
  [DocID], [DocDate], [DocName], [DocStatus], 
  [DebitAcc], [CredAcc], [AccountCurr], 
  [DocCurrency], [DocAmount], [ExchangePrice], 
  [BaseCurrAmount], [BaseAmount],[DocManualNo], [DocNotes],
  InputUser,InputDateTime, ModifiedDateTime, 
  DeviceName, StockID, ItemName, 
  CurrentUserID,Referance, ReferanceName, StockQuantity,StockQuantityByMainUnit, StockPrice, 
  AccountBank, DocCode,DocCostCenter, DocNoteByAccount, DocTags, SalesPerson,StockDebitWhereHouse,StockCreditWhereHouse,StockUnit,Color,Measure,VoucherDiscount,ItemVAT,OrderID,LastPurchasePrice
) 
Select 
    @DocID, @DocDate, @DocName, '1',
	I.AccPurches,'0', '1',
	@DefaultCurr, V.Price*V.Quantity, '1', 
	V.Price*V.Quantity,V.Price*V.Quantity, N'0', @DocNote, 
    @UserID, @InputDateTime, @ModifiedDateTime, 
    @DeviceName, V.ItemNo, V.ItemName, 
    @UserID, @ReferanceNo, @ReferanceName, V.Quantity, V.Quantity, V.Price, 
    '', @DocCode, '1', N'', N'', @SalesMan,@StockDebitWhereHouse,0,V.UnitID,0 As Color,0 As Measure,0 As VoucherDiscount,0 As ItemVAT,0 As OrderID,I.LastPurchasePrice
  From @VoucherItemsDetails V left join Items I on V.ItemNo=I.ItemNo ;

End





INSERT INTO Journal WITH (TABLOCK) ([DocID]
                                ,[DocDate],[DocName],[DocStatus],[DocCostCenter]
                                ,[DebitAcc],[CredAcc],[AccountCurr],[DocCurrency]
                                ,[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount]
                                ,[DocSort],[Referance],[DocManualNo],[DocMultiCurrency]
                                ,[InputUser],[InputDateTime],[ModifiedUser],[ModifiedDateTime]
                                ,[DocAuditDate],[DocAuditUser],[DocNotes],[StockID]
                                ,[StockUnit],[StockQuantity],[StockQuantityByMainUnit],[StockPrice]
                                ,[StockDiscount],[StockItemPrice],[StockDebitWhereHouse],[StockCreditWhereHouse]
                                ,[StockDriver],[StockCarNo],[SalesPerson],[CheckNo]
                                ,[CheckInOut],[CheckStatus],[CheckDueDate],[CheckCustBank]
                                ,[CheckCustBranch],[CheckCustAccountId],[AccountBank],[DeleteUser]
                                ,[DeleteDateTime],[CurrentUserID],[ReferanceName],[DocCode]
                                ,[CheckCode],[ItemName],[DocCheckTransID],[TransNoInJournal]
                                ,[ShiftID],[DocNoteByAccount],[StockBarcode],[PosNo]
                                ,[DeviceName],[OrderStatus],[ItemStatus],[ApprovedQuantity]
                                ,[LastDocCode],[LastDataName],[DeliverDate],[Color]
                                ,[Measure],[VoucherDiscount],[ItemVAT],[StockDebitShelve],[StockCreditShelve],[OrderID],[DocID2],PaidStatus,PaidAmount,TarteebID,DocTags)
                             SELECT @DocID,[DocDate],[DocName],[DocStatus]
                                ,[DocCostCenter],[DebitAcc],[CredAcc],[AccountCurr]
                                ,[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount]
                                ,[BaseAmount],[DocSort],[Referance],[DocManualNo]
                                ,[DocMultiCurrency],[InputUser],[InputDateTime],[ModifiedUser]
                                ,[ModifiedDateTime],[DocAuditDate],[DocAuditUser],[DocNotes]
                                ,[StockID],[StockUnit],[StockQuantity],[StockQuantityByMainUnit]
                                ,[StockPrice],[StockDiscount],[StockItemPrice],[StockDebitWhereHouse]
                                ,[StockCreditWhereHouse],[StockDriver],[StockCarNo],[SalesPerson]
                                ,[CheckNo],[CheckInOut],[CheckStatus],[CheckDueDate]
                                ,[CheckCustBank],[CheckCustBranch],[CheckCustAccountId],[AccountBank]
                                ,[DeleteUser],[DeleteDateTime],[CurrentUserID],[ReferanceName]
                                ,[DocCode],[CheckCode],[ItemName],[DocCheckTransID]
                                ,[TransNoInJournal],[ShiftID],[DocNoteByAccount],[StockBarcode]
                                ,[PosNo],[DeviceName],[OrderStatus],[ItemStatus]
                                ,[ApprovedQuantity],[LastDocCode],[LastDataName],[DeliverDate]
                                ,[Color],[Measure],[VoucherDiscount],[ItemVAT],[StockDebitShelve],
                                [StockCreditShelve],[OrderID],[DocID2],PaidStatus,PaidAmount,TarteebID ,DocTags
                            FROM JournalTemp 
                            WHERE DocName=@DocName  and DocCode=@DocCode and CurrentUserID= @UserID;
Delete from JournalTemp where DocCode=@DocCode;

    COMMIT TRANSACTION;
	 RETURN @DocID;

END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    THROW; -- إعادة إرسال الخطأ ليتم التعامل معه من قبل التطبيق
END CATCH;
End;

GO
------------------------------
-- ترحيل فاتورة من الويب --
------------------------------


Go
------------------------------
-- ترحيل سند القبض والصرف من الويب --
------------------------------
------------------------------
-- ترحيل سند القبض والصرف من الويب --
------------------------------
ALTER   PROCEDURE [dbo].[BuildReceiptFromWEB]
    @ReferanceNo int,
    @DocDate date,
    @DocNameID int,
    @DocID int,
    @UserID int,
    @DocNote nvarchar(max),
    @DeviceName nvarchar(max),
    @CurrencyID int,
    @CashAmount float,
    @ChecksAmount float,
    @ChequesDetails TVP_Cheques READONLY
AS
BEGIN
    BEGIN TRANSACTION;
    DECLARE @AccountCash varchar(15);
    DECLARE @DebitAccountChecks varchar(15);
    DECLARE @AccountCurr int;
    DECLARE @DefaultCurr int;
    DECLARE @InputDateTime datetime;
    DECLARE @ModifiedDateTime datetime;
    DECLARE @ReferanceName nvarchar(50);
    DECLARE @ReferanceAccount varchar(50);
    DECLARE @DocCode varchar(15);
    DECLARE @UserName nvarchar(100);
    DECLARE @TotalAmount float;
    DECLARE @FinancialBankAccountNo varchar(15);

    SET @AccountCash = (SELECT AccNo FROM FinancialAccountsDefault WHERE UserID = @UserID AND CurrencyID = @CurrencyID AND AccTypeID = 1);
    SET @DebitAccountChecks = (SELECT AccNo FROM FinancialAccountsDefault WHERE UserID = @UserID AND CurrencyID = @CurrencyID AND AccTypeID = 2);
    SET @AccountCurr = (SELECT Currency FROM FinancialAccounts WHERE AccNo = @AccountCash);
    SET @DefaultCurr = (SELECT CurrID FROM Currency WHERE IsDefault = 1);
    SET @InputDateTime = (SELECT CONVERT(char(10), GETDATE(), 126) + ' ' + CONVERT(VARCHAR(8), GETDATE(), 14));
    SET @ModifiedDateTime = (SELECT CONVERT(char(10), GETDATE(), 126) + ' ' + CONVERT(VARCHAR(8), GETDATE(), 14));
    SET @ReferanceName = (SELECT RefName FROM Referencess WHERE RefNo = @ReferanceNo);
    SET @DocCode = (SELECT RIGHT(NEWID(), 15));
    SET @ReferanceAccount = (SELECT RefAccID FROM Referencess WHERE RefNo = @ReferanceNo);
    SET @UserName = (SELECT EmployeeName FROM EmployeesData WHERE EmployeeID = @UserID);
    SET @TotalAmount = @CashAmount + @ChecksAmount;

    -- Determine DocID based on DocNameID
    IF @DocID = 0
    BEGIN
        IF @DocNameID = 3 
        BEGIN
            SET @DocID = NEXT VALUE FOR dbo.PaymentVoucherSeq;
        END
        ELSE IF @DocNameID = 4
        BEGIN
            SET @DocID = NEXT VALUE FOR dbo.ReceiptVoucherSeq;
        END
    END

    IF @DocNameID = 3 
    BEGIN
        -- Add CashCredit Side
        INSERT INTO JournalTemp (
            [DocID], [DocDate], [DocName], [DocStatus], 
            [DebitAcc], [CredAcc], [AccountCurr], 
            [DocCurrency], [DocAmount], [ExchangePrice], 
            [BaseCurrAmount], [BaseAmount], [DocManualNo], [DocNotes],
            InputUser, InputDateTime, ModifiedDateTime, 
            DeviceName, CheckNo, CheckInOut, CheckStatus, [CheckDueDate], 
            CurrentUserID, Referance, ReferanceName, CheckCustBank, CheckCustBranch, CheckCustAccountId, 
            AccountBank, DocCode, CheckCode, 
            DocCostCenter, DocNoteByAccount, 
            TransNoInJournal, DocTags, SalesPerson
        ) 
        VALUES (
            @DocID, @DocDate, @DocNameID, '1',
            '0', @AccountCash, '1',
            @DefaultCurr, @CashAmount, '1', 
            @CashAmount, @CashAmount, N'0', @DocNote, 
            @UserID, @InputDateTime, @ModifiedDateTime, 
            @DeviceName, '0', '', '0', '1900-01-01', 
            @UserID, @ReferanceNo, @ReferanceName, '0', '0', '0', 
            0, @DocCode, '', '1', N'', 
            1, N'', @UserID
        );

        IF EXISTS (SELECT 1 FROM @ChequesDetails)
        BEGIN 
            -- Add CheksCredit Side
            INSERT INTO JournalTemp (
                [DocID], [DocDate], [DocName], [DocStatus], 
                [DebitAcc], [CredAcc], [AccountCurr], 
                [DocCurrency], [DocAmount], [ExchangePrice], 
                [BaseCurrAmount], [BaseAmount], [DocManualNo], [DocNotes],
                InputUser, InputDateTime, ModifiedDateTime, 
                DeviceName, CheckNo, CheckInOut, CheckStatus, [CheckDueDate], 
                CurrentUserID, Referance, ReferanceName, CheckCustBank, CheckCustBranch, CheckCustAccountId, 
                AccountBank, DocCode, CheckCode, DocCostCenter, DocNoteByAccount, TransNoInJournal, DocTags, SalesPerson
            ) 
            SELECT 
                @DocID, @DocDate, @DocNameID, '1',
                '0', B.BankOutChequeAccount, '1',
                @DefaultCurr, ChequeAmount, '1', 
                ChequeAmount, ChequeAmount, N'0', @DocNote, 
                @UserID, @InputDateTime, @ModifiedDateTime, 
                @DeviceName, ChequeNo, 'OUT', '1', ChequeDueDate, 
                @UserID, @ReferanceNo, @ReferanceName, ChequeBank, ChequeBankBranch, ChequeAccountNo, 
                BankAccount, @DocCode, (SELECT RIGHT(NEWID(), 15)), '1', N'', 1, N'', @UserID
            FROM @ChequesDetails C
            LEFT JOIN BanksAccounts B ON B.ID = C.BankAccount;
        END;

        -- Add Debit Side
        INSERT INTO JournalTemp (
            [DocID], [DocDate], [DocName], [DocStatus], 
            [DebitAcc], [CredAcc], [AccountCurr], 
            [DocCurrency], [DocAmount], [ExchangePrice], 
            [BaseCurrAmount], [BaseAmount], [DocManualNo], [DocNotes],
            InputUser, InputDateTime, ModifiedDateTime, 
            DeviceName, CheckNo, CheckInOut, CheckStatus, [CheckDueDate], 
            CurrentUserID, Referance, ReferanceName, CheckCustBank, CheckCustBranch, CheckCustAccountId, 
            AccountBank, DocCode, CheckCode, 
            DocCostCenter, DocNoteByAccount, 
            TransNoInJournal, DocTags, SalesPerson
        ) 
        VALUES (
            @DocID, @DocDate, @DocNameID, '1',
            @ReferanceAccount, '0', '1',
            @DefaultCurr, @TotalAmount, '1', 
            @TotalAmount, @TotalAmount, N'0', @DocNote, 
            @UserID, @InputDateTime, @ModifiedDateTime, 
            @DeviceName, '0', '', '0', '1900-01-01', 
            @UserID, @ReferanceNo, @ReferanceName, '0', '0', '0', 
            '', @DocCode, '', '1', N'', 
            1, N'', @UserID
        );

        -- Post Cheks To Cheks Table 
        IF EXISTS (SELECT 1 FROM @ChequesDetails)
        BEGIN 
            INSERT INTO Checks (
                DocName, CheckCode, CheckInOut, CheckNo, CheckDueDate, CheckBank, CheckBranch, CheckAccountId, CheckStatus, CheckAmount, CheckCurr, CheckBaseAmount, DocCode, DocID, AccountBank, DocNoteByAccount, ChekInBoxAccount, Referance, RelatedAccount, TransNoInJournal
            )
            SELECT 
                DocName, CheckCode, CheckInOut, CheckNo, CheckDueDate, CheckCustBank, CheckCustBranch, CheckCustAccountId, CheckStatus, DocAmount, DocCurrency, BaseCurrAmount, DocCode, DocID, AccountBank, DocNoteByAccount, DebitAcc, Referance, DebitAcc, 1 
            FROM JournalTemp 
            WHERE DocName = @DocNameID AND DocCode = @DocCode AND CurrentUserID = @UserID AND CheckNo <> 0 AND DebitAcc = '0';
        END;
    END;

    IF @DocNameID = 4 
    BEGIN
        -- Add CashDebit Side
        INSERT INTO JournalTemp (
            [DocID], [DocDate], [DocName], [DocStatus], 
            [DebitAcc], [CredAcc], [AccountCurr], 
            [DocCurrency], [DocAmount], [ExchangePrice], 
            [BaseCurrAmount], [BaseAmount], [DocManualNo], [DocNotes],
            InputUser, InputDateTime, ModifiedDateTime, 
            DeviceName, CheckNo, CheckInOut, CheckStatus, [CheckDueDate], 
            CurrentUserID, Referance, ReferanceName, CheckCustBank, CheckCustBranch, CheckCustAccountId, 
            AccountBank, DocCode, CheckCode, 
            DocCostCenter, DocNoteByAccount, 
            TransNoInJournal, DocTags, SalesPerson
        ) 
        VALUES (
            @DocID, @DocDate, @DocNameID, '1',
            @AccountCash, '0', '1',
            @DefaultCurr, @CashAmount, '1', 
            @CashAmount, @CashAmount, N'0', @DocNote, 
            @UserID, @InputDateTime, @ModifiedDateTime, 
            @DeviceName, '0', '', '0', '1900-01-01', 
            @UserID, @ReferanceNo, @ReferanceName, '0', '0', '0', 
            '', @DocCode, '', '1', N'', 
            1, N'', @UserID
        );

        IF EXISTS (SELECT 1 FROM @ChequesDetails)
        BEGIN 
            -- Add CheksDebit Side
            INSERT INTO JournalTemp (
                [DocID], [DocDate], [DocName], [DocStatus], 
                [DebitAcc], [CredAcc], [AccountCurr], 
                [DocCurrency], [DocAmount], [ExchangePrice], 
                [BaseCurrAmount], [BaseAmount], [DocManualNo], [DocNotes],
                InputUser, InputDateTime, ModifiedDateTime, 
                DeviceName, CheckNo, CheckInOut, CheckStatus, [CheckDueDate], 
                CurrentUserID, Referance, ReferanceName, CheckCustBank, CheckCustBranch, CheckCustAccountId, 
                AccountBank, DocCode, CheckCode, DocCostCenter, DocNoteByAccount, TransNoInJournal, DocTags, SalesPerson
            ) 
            SELECT 
                @DocID, @DocDate, @DocNameID, '1',
                @DebitAccountChecks, '0', '1',
                @DefaultCurr, ChequeAmount, '1', 
                ChequeAmount, ChequeAmount, N'0', @DocNote, 
                @UserID, @InputDateTime, @ModifiedDateTime, 
                @DeviceName, ChequeNo, 'IN', '3', ChequeDueDate, 
                @UserID, @ReferanceNo, @ReferanceName, ChequeBank, ChequeBankBranch, ChequeAccountNo, 
                BankAccount, @DocCode, (SELECT RIGHT(NEWID(), 15)), '1', N'', 1, N'', @UserID
            FROM @ChequesDetails;
        END;

        -- Add Credit Side
        INSERT INTO JournalTemp (
            [DocID], [DocDate], [DocName], [DocStatus], 
            [DebitAcc], [CredAcc], [AccountCurr], 
            [DocCurrency], [DocAmount], [ExchangePrice], 
            [BaseCurrAmount], [BaseAmount], [DocManualNo], [DocNotes],
            InputUser, InputDateTime, ModifiedDateTime, 
            DeviceName, CheckNo, CheckInOut, CheckStatus, [CheckDueDate], 
            CurrentUserID, Referance, ReferanceName, CheckCustBank, CheckCustBranch, CheckCustAccountId, 
            AccountBank, DocCode, CheckCode, 
            DocCostCenter, DocNoteByAccount, 
            TransNoInJournal, DocTags, SalesPerson
        ) 
        VALUES (
            @DocID, @DocDate, @DocNameID, '1',
            '0', @ReferanceAccount, '1',
            @DefaultCurr, @TotalAmount, '1', 
            @TotalAmount, @TotalAmount, N'0', @DocNote, 
            @UserID, @InputDateTime, @ModifiedDateTime, 
            @DeviceName, '0', '', '0', '1900-01-01', 
            @UserID, @ReferanceNo, @ReferanceName, '0', '0', '0', 
            '', @DocCode, '', '1', N'', 
            1, N'', @UserID
        );

        -- Post Cheks To Cheks Table 
        IF EXISTS (SELECT 1 FROM @ChequesDetails)
        BEGIN 
            INSERT INTO Checks (
                DocName, CheckCode, CheckInOut, CheckNo, CheckDueDate, CheckBank, CheckBranch, CheckAccountId, CheckStatus, CheckAmount, CheckCurr, CheckBaseAmount, DocCode, DocID, AccountBank, DocNoteByAccount, ChekInBoxAccount, Referance, RelatedAccount, TransNoInJournal
            )
            SELECT 
                DocName, CheckCode, CheckInOut, CheckNo, CheckDueDate, CheckCustBank, CheckCustBranch, CheckCustAccountId, CheckStatus, DocAmount, DocCurrency, BaseCurrAmount, DocCode, DocID, AccountBank, DocNoteByAccount, DebitAcc, Referance, DebitAcc, 1 
            FROM JournalTemp 
            WHERE DocName = @DocNameID AND DocCode = @DocCode AND CurrentUserID = @UserID AND CheckNo <> 0 AND CredAcc = '0';
        END;
    END;

    -- Post Data To Journal Table From Journal TEMP
    INSERT INTO Journal WITH (TABLOCKX) (
        [DocID], [DocDate], [DocName], [DocStatus], [DocCostCenter],
        [DebitAcc], [CredAcc], [AccountCurr], [DocCurrency],
        [DocAmount], [ExchangePrice], [BaseCurrAmount], [BaseAmount],
        [DocSort], [Referance], [DocManualNo], [DocMultiCurrency],
        [InputUser], [InputDateTime], [ModifiedUser], [ModifiedDateTime],
        [DocAuditDate], [DocAuditUser], [DocNotes], [StockID],
        [StockUnit], [StockQuantity], [StockQuantityByMainUnit], [StockPrice],
        [StockDiscount], [StockItemPrice], [StockDebitWhereHouse], [StockCreditWhereHouse],
        [StockDriver], [StockCarNo], [SalesPerson], [CheckNo],
        [CheckInOut], [CheckStatus], [CheckDueDate], [CheckCustBank],
        [CheckCustBranch], [CheckCustAccountId], [AccountBank], [DeleteUser],
        [DeleteDateTime], [CurrentUserID], [ReferanceName], [DocCode],
        [CheckCode], [ItemName], [DocCheckTransID], [TransNoInJournal],
        [ShiftID], [DocNoteByAccount], [StockBarcode], [PosNo],
        [DeviceName], [OrderStatus], [ItemStatus], [ApprovedQuantity],
        [LastDocCode], [LastDataName], [DeliverDate], [Color],
        [Measure], [VoucherDiscount], [ItemVAT], [StockDebitShelve], [StockCreditShelve], [OrderID], [DocID2], PaidStatus, PaidAmount, TarteebID, DocTags
    )
    SELECT 
        @DocID, [DocDate], [DocName], [DocStatus], [DocCostCenter],
        [DebitAcc], [CredAcc], [AccountCurr], [DocCurrency],
        [DocAmount], [ExchangePrice], [BaseCurrAmount], [BaseAmount],
        [DocSort], [Referance], [DocManualNo], [DocMultiCurrency],
        [InputUser], [InputDateTime], [ModifiedUser], [ModifiedDateTime],
        [DocAuditDate], [DocAuditUser], [DocNotes], [StockID],
        [StockUnit], [StockQuantity], [StockQuantityByMainUnit], [StockPrice],
        [StockDiscount], [StockItemPrice], [StockDebitWhereHouse], [StockCreditWhereHouse],
        [StockDriver], [StockCarNo], [SalesPerson], [CheckNo],
        [CheckInOut], [CheckStatus], [CheckDueDate], [CheckCustBank],
        [CheckCustBranch], [CheckCustAccountId], [AccountBank], [DeleteUser],
        [DeleteDateTime], [CurrentUserID], [ReferanceName], [DocCode],
        [CheckCode], [ItemName], [DocCheckTransID], [TransNoInJournal],
        [ShiftID], [DocNoteByAccount], [StockBarcode], [PosNo],
        [DeviceName], [OrderStatus], [ItemStatus], [ApprovedQuantity],
        [LastDocCode], [LastDataName], [DeliverDate], [Color],
        [Measure], [VoucherDiscount], [ItemVAT], [StockDebitShelve], [StockCreditShelve], [OrderID], [DocID2], PaidStatus, PaidAmount, TarteebID, DocTags
    FROM JournalTemp 
    WHERE DocName = @DocNameID AND DocCode = @DocCode AND CurrentUserID = @UserID;

	Delete From JournalTemp where DocCode=@DocCode;

    UPDATE Checks SET DocID = @DocID WHERE DocCode = @DocCode;

    COMMIT TRANSACTION;

    DECLARE @FinalDocID int;
    SET @FinalDocID = (SELECT @DocID);

    RETURN @FinalDocID;
END

GO

------------------------------
-- ترحيل سند القبض والصرف من الويب --
------------------------------





Alter table [AttCHECKINOUTPending] add EditNote nvarchar(MAX) DEFAULT ''
Go
Alter table [AttCHECKINOUT] add DocInputDateTime DateTime DEFAULT GETDATE()
Go
Alter table [AttCHECKINOUTPending] add DocInputDateTime DateTime DEFAULT GETDATE()
Go
Alter table [AttCHECKINOUT] add DocInputDateTime DateTime DEFAULT GETDATE()
Go
Alter table [AttCHECKINOUTPending] add ManagerId INT DEFAULT 0
Go
Alter table [AttCHECKINOUTPending] add DocStatus INT DEFAULT 0
Go
Alter table [AttCHECKINOUTPending] add ActionTakenOn nvarchar(500) DEFAULT ''
Go

Alter table [AttCHECKINOUTPending] add RecordType nvarchar(100) DEFAULT ''
Go
Alter table [AttCHECKINOUTPending] add EditedType nvarchar(MAX) DEFAULT ''
Go
Alter table [AttCHECKINOUTPending] add Notes NVARCHAR(MAX) DEFAULT ''
Go

Alter table [AttCHECKINOUT] add RecordType nvarchar(100) DEFAULT ''
Go
Alter table [AttCHECKINOUT] add EditedType nvarchar(MAX) DEFAULT ''
Go
Alter table [AttCHECKINOUT] add Notes NVARCHAR(MAX) DEFAULT ''
Go

ALTER TABLE [EmployeesData] ADD CanMakeDiscount BIT DEFAULT 0;
Go

ALTER TABLE [dbo].[EmployeesData] ADD  CONSTRAINT [DF_EmployeesData_IP]  DEFAULT ((0)) FOR [IP]
GO


CREATE TABLE [dbo].[WhatsAppLogs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[Caption] [nvarchar](max) NULL,
	[MobileNo] [nvarchar](50) NULL,
	[InputDateTime] [datetime] NULL,
	[Method] [nvarchar](50) NULL,
	[ResponseContent] [nvarchar](max) NULL,
	[Result] [bit] NULL,
	[UserNo] [int] NULL,
	[DeviceName] [nvarchar](max) NULL,
	[RefName] [nvarchar](max) NULL,
	[FormName] [nvarchar](max) NULL,
 CONSTRAINT [PK_WhatsAppLogs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[WhatsAppLogs] ADD  CONSTRAINT [DF_WhatsAppLogs_InputDateTime]  DEFAULT (getdate()) FOR [InputDateTime]
GO

ALTER TABLE [EmployeesData] ADD ShowWhoIsOff nvarchar(MAX) DEFAULT '';
Go
ALTER TABLE [EmployeesData] ADD ShowVacBalance nvarchar(MAX) DEFAULT '';
Go
ALTER TABLE [EmployeesData] ADD ShowInOutNotes nvarchar(MAX) DEFAULT '';
Go
ALTER TABLE [EmployeesData] ADD NeedsGPS bit DEFAULT 0;
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('HR_ShowBonusAmountInInSalarySlip','True',N' عرض حقل ساعات الاضافي في قسيمة الراتب ','HR')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('HR_ShowBonusHouresInSalarySlip','True',N' عرض حقل مبلغ الاضافي في قسيمة الراتب ','HR')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('HR_ShowLeavesHouresInSalarySlip','True',N' عرض حقل ساعات المغادرات والتاخير في قسيمة الراتب ','HR')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('HR_ShowLeavesAmountInSalarySlip','True',N' عرض حقل مبلغ المغادرات والتاخير في قسيمة الراتب ','HR')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('POS_SendRefBalanceInsteadRefDebitWhenSendWhatsAppMessage','False',N' ارسال رصيد الذمة عند ارسال رسالة الواتس في نقطة البيع عند القبض والصرف ','POS')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('POS_SendSMSWhenTheItemNotDefined','False',N' ارسال رسالة عند ختم صنف غير معرف على نقطة البيع ','POS')
Go


CREATE TABLE [dbo].[SalariesTaxExchangePrice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Month] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[ExchangePrice] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SalariesTaxExchangePrice] PRIMARY KEY CLUSTERED 
(
	[Month] ASC,
	[Year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[SalaryTaxDeduction](
	[EmployeeID] [int] NOT NULL,
	[EmployeeName] [nvarchar](100) NULL,
	[SalaryMonth] [decimal](18, 2) NULL,
	[Additions] [decimal](18, 2) NULL,
	[GrossSalary] [decimal](18, 2) NULL,
	[AnualGrossSalaryNIS] [decimal](18, 2) NULL,
	[IndividualDiscount] [decimal](18, 2) NULL,
	[AnualTransport] [decimal](18, 2) NULL,
	[UniversityAmount] [decimal](18, 2) NULL,
	[TotalExemptions] [decimal](18, 2) NULL,
	[TaxableIncome] [decimal](18, 2) NULL,
	[YearTax] [decimal](18, 2) NULL,
	[MonthTaxNIS] [decimal](18, 2) NULL,
	[MonthTaxUSD] [decimal](18, 2) NULL,
	[AbsenceAmount] [decimal](18, 2) NULL,
	[Month] [int] NOT NULL,
	[Year] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SalaryTaxDeduction] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC,
	[Month] ASC,
	[Year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER PROCEDURE [dbo].[InsertDataFromTempToJournal] @DocName int,@DocCode varchar(50),@UserID int,@DeviceName varchar(255) ,@_DocID int,@DocID INT OUTPUT
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
	IF @_DocID = 0
		Begin
	    --SELECT @DocID = ISNULL(max(DocID),0)+1 FROM journal WITH (TABLOCKX, HOLDLOCK) where DocName=@DocName ;
			IF @DocName = 17  
				SET @DocID = NEXT VALUE FOR [dbo].[StockEntryVoucherSeq];  
			ELSE IF @DocName = 18  
				SET @DocID = NEXT VALUE FOR [dbo].[StockExitVoucherSeq];  
		End
	Else
		Begin
		Set @DocID=@_DocID
	End
	Insert into Journal ([DocID],[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,ModifiedDateTime,StockID,StockUnit,
                                                [StockQuantity],[StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                               [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,
                                                DeliverDate,Color,Measure,StockDiscount,VoucherDiscount,ItemVAT,[StockDebitShelve],
                                                StockCreditShelve,DocNoteByAccount,SalesPerson,DeviceName,ItemNo2,OrderID,StockDriver,StockCarNo,LastPurchasePrice,BatchID,PaidStatus,PaidAmount,PaidByDocID)
    Select  @DocID,[DocDate],[DocName],[DocStatus],[DebitAcc],[CredAcc],
                                                [AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],
                                                [BaseCurrAmount],[BaseAmount],
                                                [DocManualNo],[DocNotes],InputUser,InputDateTime,ModifiedDateTime,StockID,StockUnit,
                                                [StockQuantity],[StockQuantityByMainUnit],StockPrice,StockDebitWhereHouse,
                                                [StockCreditWhereHouse],CurrentUserID,Referance,ReferanceName,ItemName,
                                                [DocCostCenter],DocCode,OrderStatus,LastDocCode,LastDataName,StockBarcode,
                                                DeliverDate,Color,Measure,StockDiscount,VoucherDiscount,ItemVAT,[StockDebitShelve],
                                                StockCreditShelve,DocNoteByAccount,SalesPerson,DeviceName,ItemNo2,OrderID,StockDriver,StockCarNo,LastPurchasePrice,BatchID,PaidStatus,PaidAmount,PaidByDocID
    from JournalTemp 
	where DocCode=@DocCode and CurrentUserID=@UserID and DeviceName=@DeviceName;
COMMIT;
        --SELECT top 1 @_DocID AS DocID;
END TRY

BEGIN CATCH
	ROLLBACK; -- Rollback the transaction
	Set @DocID=0
END CATCH;
delete from JournalTemp where  DocName=@DocName and DocCode=@DocCode and CurrentUserID=@UserID;
select @DocID

END;
GO



CREATE PROCEDURE [dbo].[DeleteFromJournal] 
    @DocName INT,
    @DocID INT,
    @UpdateDateTime VARCHAR(19) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @Result BIT;
    DECLARE @CopyJournal BIT;
    DECLARE @SqlString3 NVARCHAR(MAX);
    DECLARE @FormattedDateTime VARCHAR(19);

    -- If UpdateDateTime is NULL, use the current datetime
    IF @UpdateDateTime IS NULL
    BEGIN
        SET @FormattedDateTime = CONVERT(VARCHAR(19), GETDATE(), 120);
    END
    ELSE
    BEGIN
        SET @FormattedDateTime = @UpdateDateTime;
    END

    -- Case 1: DocName = 11 or DocName = 10 (Direct Deletion from OrdersJournal)
    IF @DocName IN (10, 11)
    BEGIN
        BEGIN TRY
            DELETE FROM OrdersJournal
            WHERE DocName = @DocName AND DocID = @DocID;
            SET @Result = 1; -- Success
        END TRY
        BEGIN CATCH
            SET @Result = 0; -- Error
        END CATCH
    END
    -- Case 2: Other DocNames (Insert into JournalBeforeUpdate and Delete from Journal and Checks)
    ELSE
    BEGIN
        BEGIN TRY
            -- Insert the record into JournalBeforeUpdate
            INSERT INTO JournalBeforeUpdate (
                ID, DocID, DocDate, DocName, DocStatus, DebitAcc, CredAcc,
                AccountCurr, DocCurrency, DocAmount, ExchangePrice,
                BaseCurrAmount, BaseAmount, DocManualNo, DocNotes, InputUser, 
                InputDateTime, ModifiedDateTime, StockID, StockUnit, StockQuantity, 
                BonusQuantity, StockQuantityByMainUnit, StockPrice, StockDebitWhereHouse, 
                StockCreditWhereHouse, CurrentUserID, Referance, ReferanceName, ItemName, 
                DocCostCenter, DocCode, OrderStatus, LastDocCode, LastDataName, StockBarcode, 
                DeliverDate, Color, Measure, StockDiscount, VoucherDiscount, ItemVAT, 
                StockDebitShelve, StockCreditShelve, DocNoteByAccount, SalesPerson, DeviceName, 
                ItemNo2, OrderID, DocTags
            )
            SELECT 
                ID, DocID, DocDate, DocName, DocStatus, DebitAcc, CredAcc,
                AccountCurr, DocCurrency, DocAmount, ExchangePrice,
                BaseCurrAmount, BaseAmount, DocManualNo, DocNotes, InputUser, 
                InputDateTime, @FormattedDateTime, StockID, StockUnit, StockQuantity, 
                BonusQuantity, StockQuantityByMainUnit, StockPrice, StockDebitWhereHouse, 
                StockCreditWhereHouse, CurrentUserID, Referance, ReferanceName, ItemName, 
                DocCostCenter, DocCode, OrderStatus, LastDocCode, LastDataName, StockBarcode, 
                DeliverDate, Color, Measure, StockDiscount, VoucherDiscount, ItemVAT, 
                StockDebitShelve, StockCreditShelve, DocNoteByAccount, SalesPerson, DeviceName, 
                ItemNo2, OrderID, DocTags
            FROM Journal
            WHERE DocName = @DocName AND DocID = @DocID;
            ;

            EXEC sp_executesql @SqlString3, N'@FormattedDateTime VARCHAR(19)', @FormattedDateTime;

            -- Check if insertion was successful
            IF @@ROWCOUNT > 0
            BEGIN
                -- Proceed to delete from Journal and Checks
                DELETE FROM Journal
                WHERE DocName = @DocName AND DocID = @DocID;

                DELETE FROM checks
                WHERE DocName = @DocName AND DocID = @DocID AND TransNoInJournal = 1;

                SET @Result = 1; -- Success
            END
            ELSE
            BEGIN
                SET @Result = 0; -- Error
            END
        END TRY
        BEGIN CATCH
            SET @Result = 0; -- Error
        END CATCH
    END

    -- Return the result (1 for success, 0 for failure)
    SELECT @Result AS OperationResult;
END
GO


ALTER TABLE [dbo].[Journal] Add  [BaseItemPrice] float NULL DEFAULT (0)
Go
ALTER TABLE [dbo].[JournalTemp] Add  [BaseItemPrice] float NULL DEFAULT (0)
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add  [BaseItemPrice] float NULL DEFAULT (0)
Go
ALTER TABLE Items  ADD LastBaseItemPrice float NULL DEFAULT (0)
Go
ALTER TABLE Items  ADD LastNetPurchasePrice float NULL DEFAULT (0)
Go
ALTER TABLE Items  ADD VisibleInPOS bit NULL 
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('Accounting_PrintVoucherAfterAcceptFromOrder','False',N' طباعة الفاتورة بعد اعتمادها من الطلبية ','Accounting')
Go


UPDATE  c
SET     c.BarCode        = iu.item_unit_bar_code
FROM    dbo.CampaginByItemsCount      AS c
INNER   JOIN dbo.Items_units   AS iu
        ON  iu.item_id    = c.ItemNo      -- typical composite key
WHERE   c.BarCode IS NULL                     -- update only the rows you care about
  AND   iu.main_unit = 1;                      -- optional extra filter
Go


ALTER TABLE SavingsFund
ADD CONSTRAINT DF_SavingsFund_InputDateTime DEFAULT GETDATE() FOR InputDateTime;
Go


CREATE TABLE [dbo].[AttMachineUsers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MachineNumber] [int] NULL,
	[EnrollNumber] [text] NULL,
	[Name] [text] NULL,
	[Password] [varchar](1) NULL,
	[Privilege] [int] NULL,
	[Enabled] [bit] NULL,
	[CardCode] [varchar](max) NULL,
	[fingers] [int] NULL,
	[Privelage] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
Go

CREATE TABLE [dbo].[EmployeesFingers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FingerIndex] [int] NULL,
	[Template] [varchar](max) NULL,
	[Flag] [int] NULL,
	[TemplateLength] [int] NULL,
	[UserFingerFromAttMachineUsers] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
Go


alter table [CHECKINOUT] add sn text
Go

ALTER TABLE [Machines] ADD [LastImportDate] DATETIME NULL
Go


CREATE TABLE [dbo].[CHECKINOUT](
	[USERID] [int] NOT NULL,
	[CHECKTIME] [datetime] NOT NULL,
	[CHECKTYPE] [varchar](1) NULL,
	[VERIFYCODE] [int] NULL,
	[SENSORID] [varchar](5) NULL,
	[AttProcess] [int] NULL,
	[sn] [text] NULL,
 CONSTRAINT [USERCHECKTIME] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[CHECKTIME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


alter table Machines add CommKey INT default 0
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('Att_ShowHrNotePerDayInAttReports','False',N' عرض ملاحظات مراقب الدوام HR في تقاير الدوام ','POS')
Go


CREATE TABLE [dbo].[AttHrNotesPerDayForAttReports](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AttDate] [datetime] NOT NULL,
	[EmployeeNo] [int] NOT NULL,
	[AttNotes] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AttHrNotesPerDayForAttReports] PRIMARY KEY CLUSTERED 
(
	[AttDate] ASC,
	[EmployeeNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE TABLE [dbo].[AttHrNotesPerMonthForAttReports](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AttDate] [datetime] NOT NULL,
	[EmployeeNo] [int] NOT NULL,
	[AttNotes] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AttHrNotesPerMonthForAttReports] PRIMARY KEY CLUSTERED 
(
	[AttDate] ASC,
	[EmployeeNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Items]
ADD [InputDateTime] DATETIME NOT NULL 
    CONSTRAINT DF_Items_InputDateTime DEFAULT (GETDATE());
Go


ALTER TABLE dbo.Settings
DROP COLUMN SettingsName, SettingsValue;
Go

Update Settings Set SettingDescription ='في نقطة البيع، السماح بالبيع بكمية السالب' where SettingName='PosAllowMinusQuantityIvVoucher'
Update Settings Set SettingDescription ='في نقطة البيع، دمج الاصناف في الفاتورة عند الادخال' where SettingName='PosAllowMergeItems'
Go

ALTER TABLE [dbo].[EmployeesData] ADD [AllowAddAttTrans] Bit Not NULL DEFAULT ((1));
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('POS_PreventKeySubtractInPos','False',N' منع استخدام زر الناقص - في نقطة البيع ','POS')
Go


Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('SalesManApp_SendTheOrderToWhatsApp','False',N' في تطبيق المندوبين، ارسال الطلبية واتس اب ','SalesManApp')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('SalesManApp_NumbersWhoWantReceiveTheOrders','',N' في تطبيق المندوبين، الارقام التي سيتم ارسال الطلبيات اليها عن طريق الواتس اب ','SalesManApp')
Go

CREATE TABLE Visits (
    VisitId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT NOT NULL,
    CustomerId INT NOT NULL,
    ServiceId NVARCHAR(MAX) NOT NULL,
    ScheduledDate DATETIME,
    ManagerNote NVARCHAR(MAX),
    Status NVARCHAR(50) DEFAULT 'Assigned', -- الحالات: Assigned, In Progress, Completed, Cancelled
    CreatedBy INT,
    DateCreated DATETIME DEFAULT GETDATE(),
    ModifiedBy INT,
    DateModified DATETIME,
	IsTrashed BIT DEFAULT 0

    CONSTRAINT FK_Visits_Customers FOREIGN KEY (CustomerId) REFERENCES [Referencess](RefID),
);


CREATE TABLE VisitLogs (
    LogId INT IDENTITY(1,1) PRIMARY KEY,
    VisitId INT NOT NULL FOREIGN KEY REFERENCES Visits(VisitId),
    ActionType NVARCHAR(50),     -- Start أو End
    ActionTime DATETIME DEFAULT GETDATE(),
    Latitude DECIMAL(18,10) NULL,
    Longitude DECIMAL(18,10) NULL,
    EmployeeNote NVARCHAR(MAX) NULL
);
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('POS_SendVoucherToCustomer','True',N' في نقطة البيع، ارسال الفاتورة الى الزبون ','POS')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('SendWhatsappAfterSaveForMoneyTrans','False',N' ارسال سند القبض - الصرف الى ارقام محددة ','POS')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('POS_PosVoucherRoundingType','RoundToNearestHalf',N' في نقطة البيع، طريقة التقريب في الفاتورة ','POS')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('Accounting_ShowInputDateTimeFieldInAccountingStatment','False',N' عرض عمود تاريخ ووقت الادخال في شاشة كشف الحساب ','Accounting')
Go


CREATE PROCEDURE [dbo].[BuildReceiptByESadad] @ReferanceNo int,
												   @Amount decimal(18, 2) , @BankAccountNo nvarchar(50) ,@ReceiptID nvarchar(50),@DocNote nvarchar(1000)
AS
DECLARE @DocID int ;
DECLARE @DebitAccount varchar(15) ;
DECLARE @AccountCurr int ;
DECLARE @DefaultCurr int ;
DECLARE @InputDateTime as datetime ;
DECLARE @ReferanceName as nvarchar(50) ;
DECLARE @ReferanceAccount as varchar(50) ;
DECLARE @DocCode as varchar(15);

SET @DocID = ( Select isnull(max([DocID])+1,1) from Journal  where DocName=4);
SET @DebitAccount = ( Select AccountNO from PosPaidMethods where MethodNo= @BankAccountNo );
--SET @DebitAccount='1102010100'
SET @AccountCurr=(Select Currency from FinancialAccounts where AccNo=@DebitAccount );
SET @DefaultCurr=(Select CurrID from Currency where IsDefault=1);
SET @InputDateTime= (select CONVERT(char(10), GetDate(),126) + ' ' + convert(VARCHAR(8), GETDATE(), 14))
SET @ReferanceName= ( Select RefName from Referencess where RefNo= @ReferanceNo);
SET @DocCode= ( select Right(NEWID(),15));
SET @ReferanceAccount= ( Select RefAccID from Referencess where RefNo= @ReferanceNo);

--Add Debit Side
Insert into [JournalTemp] ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
			[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
		    [DocManualNo],[DocNotes],InputUser,InputDateTime,CurrentUserID,Referance,ReferanceName,ShiftID,DocCode,
			PosNo,DocNoteByAccount,DeviceName,[CheckNo],[CheckInOut],[CheckStatus],[CheckDueDate],[CheckCustBank],[CheckCustBranch],[CheckCustAccountId],[AccountBank] )
values(  @DocID , CONVERT(char(10), GetDate(),126),4,1,1,@DebitAccount,'0',@AccountCurr,@DefaultCurr,@Amount,1,@Amount,@Amount,@ReceiptID,
		 @DocNote,-1,@InputDateTime,-1,@ReferanceNo,@ReferanceName,0,@DocCode,0,'','','0','','0','1900-01-01','0','0','0','0');

--Add Credit Side
Insert into [JournalTemp] ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
			[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
		    [DocManualNo],[DocNotes],InputUser,InputDateTime,CurrentUserID,Referance,ReferanceName,ShiftID,DocCode,
			PosNo,DocNoteByAccount,DeviceName,[CheckNo],[CheckInOut],[CheckStatus],[CheckDueDate],[CheckCustBank],[CheckCustBranch],[CheckCustAccountId],[AccountBank] )
values(  @DocID , CONVERT(char(10), GetDate(),126),4,1,1,'0',@ReferanceAccount,@AccountCurr,@DefaultCurr,@Amount,1,@Amount,@Amount,@ReceiptID,
		 @DocNote,-1,@InputDateTime,-1,@ReferanceNo,@ReferanceName,0,@DocCode,0,'','','0','','0','1900-01-01','0','0','0','0');


Insert into [dbo].[Journal] ([DocID],[DocDate] ,[DocName] ,[DocStatus]
            ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
            ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
            ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
            ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
            ,[StockUnit] ,[StockQuantity] ,[StockQuantityByMainUnit] ,[StockPrice]
            ,[StockItemPrice] ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
            ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
            ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
            ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
            ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
            ,[StockDiscount] ,[StockBarcode] ,[PosNo]
            ,[DeviceName],[LastDocCode],[LastDataName]) 
Select DocID,[DocDate] ,[DocName] ,[DocStatus]
            ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
            ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
            ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
            ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
            ,[StockUnit] ,[StockQuantity] ,[StockQuantityByMainUnit] ,[StockPrice]
            ,[StockItemPrice] ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
            ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
            ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
            ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
            ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
            ,[StockDiscount] ,[StockBarcode] ,[PosNo],[DeviceName] ,LastDocCode,LastDataName
			From JournalTemp  where DocCode=@DocCode

Delete from JournalTemp where DocCode=@DocCode



Declare @FinalDocID int;
SET @FinalDocID = (  SELECT top(1) DocID 
     FROM [dbo].[Journal]  where  DocCode=@DocCode ) ;

if @FinalDocID is null
 BEGIN
 delete from Journal where DocCode=@DocCode
 End
return  @FinalDocID;
GO

Go

Update Settings set SettingName='HRSystemIsConnectedWithAccountingSystem' where SettingName='ConnectedWIthTrueTime'
Go

ALTER TABLE dbo.AttEmployeePayments
ADD FinancialPaymentDocNo INT NOT NULL
    CONSTRAINT DF_AttEmployeePayments_FinancialPaymentDocNo DEFAULT (0)
WITH VALUES;
Go


ALTER TABLE dbo.AttEmployeePayments
ADD FinancialDocCode varchar(50) NOT NULL
    CONSTRAINT DF_AttEmployeePayments_FinancialDocCode DEFAULT ('')
WITH VALUES;
Go

  ALTER TABLE dbo.[AttPaymentsTypes]
ADD IsCashPayment BIT NOT NULL
    CONSTRAINT DF_AttPaymentsTypes_IsCashPayment DEFAULT (0)
WITH VALUES;

Go

CREATE TABLE [dbo].[UsersSystem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL UNIQUE,
	[UserName] [nvarchar](100) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[UserType] [nvarchar](20) NULL,
	[LastLogIn] [datetime] NULL,
	[DeviceName] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[TempPassword] [nvarchar](255) NULL,
	[ShouldEnterPassword] [bit] NULL,
	[DefaultLanguage] NVARCHAR(MAX) DEFAULT 'ar',
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[UsersSystem] ADD  DEFAULT ((0)) FOR [IsActive]
GO

ALTER TABLE [dbo].[UsersSystem] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO



CREATE TABLE [dbo].[Groups](
    [GroupId] INT IDENTITY(1,1) PRIMARY KEY,
    [GroupName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(255) NULL,
    [CreatedAt] DATETIME DEFAULT(GETDATE())
);
GO


CREATE TABLE [dbo].[PermissionsForms](
	[FormId] INT PRIMARY KEY,
    [FormNameAR] NVARCHAR(900) NOT NULL UNIQUE, 
	[FormNameEN] NVARCHAR(900) NULL, 
    [Description] NVARCHAR(255) NULL,
	[Category] NVARCHAR(MAX),
	[EnCategoryNameForShow] NVARCHAR(MAX),
	[ArCategoryNameForShow] NVARCHAR(MAX),
);
GO

CREATE TABLE [dbo].[GroupPermissions](
    [GroupPermissionId] INT IDENTITY(1,1) PRIMARY KEY,
    [GroupId] INT NOT NULL,
	[CanEdit] BIT DEFAULT 0,
	[CanDelete] BIT DEFAULT 0,
	[CanAdd] BIT DEFAULT 0,
    [FormId] INT NOT NULL,
    [IsAllow] BIT NOT NULL,
    CONSTRAINT FK_DefaultGroupPermissions_Groups FOREIGN KEY ([GroupId]) 
        REFERENCES [dbo].[Groups]([GroupId]) ON DELETE CASCADE,
    CONSTRAINT FK_DefaultGroupPermissions_Permissions FOREIGN KEY ([FormId]) 
        REFERENCES [dbo].[PermissionsForms]([FormId]) ON DELETE CASCADE,
    CONSTRAINT UQ_DefaultGroupPermissions UNIQUE ([GroupId], [FormId])
);
GO

CREATE TABLE [dbo].[PermissionsAssignments](
    [AssignmentId] INT IDENTITY(1,1) PRIMARY KEY,
    [UserId] INT NOT NULL,
    [GroupId] INT NULL,
	[CanEdit] BIT DEFAULT 0,
	[CanDelete] BIT DEFAULT 0,
	[CanAdd] BIT DEFAULT 0,
    [FormId] INT NOT NULL,
    [IsAllow] BIT NOT NULL, 

    CONSTRAINT FK_PermissionsAssignments_Users FOREIGN KEY ([UserId]) 
        REFERENCES [dbo].[UsersSystem]([UserID]) ON DELETE CASCADE,
    CONSTRAINT FK_PermissionsAssignments_Groups FOREIGN KEY ([GroupId]) 
        REFERENCES [dbo].[Groups]([GroupId]) ON DELETE CASCADE,
    CONSTRAINT FK_PermissionsAssignments_Permissions FOREIGN KEY ([FormId]) 
        REFERENCES [dbo].[PermissionsForms]([FormId]) ON DELETE CASCADE,

);
GO

CREATE TABLE [GroupMembers] (
    GroupId INT NOT NULL,
    UserId INT NOT NULL,
    PRIMARY KEY(GroupId, UserId),
    FOREIGN KEY (GroupId) REFERENCES Groups(GroupId) ON DELETE CASCADE,
    FOREIGN KEY (UserId) REFERENCES UsersSystem(UserID) ON DELETE CASCADE
)
GO

CREATE TABLE [dbo].[Visits](
	[VisitId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[ServiceId] [nvarchar](max) NOT NULL,
	[ScheduledDate] [datetime] NULL,
	[ManagerNote] [nvarchar](max) NULL,
	[Status] [nvarchar](50) NULL,
	[CreatedBy] [int] NULL,
	[DateCreated] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[DateModified] [datetime] NULL,
	[IsTrashed] [bit] NULL,
	[IsReminded] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[VisitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Visits] ADD  DEFAULT ('Assigned') FOR [Status]
GO

ALTER TABLE [dbo].[Visits] ADD  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[Visits] ADD  DEFAULT ((0)) FOR [IsTrashed]
GO

ALTER TABLE [dbo].[Visits] ADD  DEFAULT ((0)) FOR [IsReminded]
GO

ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visits_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Referencess] ([RefID])
GO

ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visits_Customers]
GO



CREATE TABLE [dbo].[VisitLogs](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[VisitId] [int] NOT NULL,
	[ActionType] [nvarchar](50) NULL,
	[ActionTime] [datetime] NULL,
	[Latitude] [decimal](18, 10) NULL,
	[Longitude] [decimal](18, 10) NULL,
	[EmployeeNote] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[VisitLogs] ADD  DEFAULT (getdate()) FOR [ActionTime]
GO

ALTER TABLE [dbo].[VisitLogs]  WITH CHECK ADD FOREIGN KEY([VisitId])
REFERENCES [dbo].[Visits] ([VisitId])
GO






ALTER TABLE [dbo].[UsersSystem] 
ADD [TempPassword] [nvarchar](255)
GO

ALTER TABLE [dbo].[UsersSystem] 
ADD [ShouldEnterPassword] [bit] 
GO

CREATE TABLE [dbo].[Module](
	[Text] [nvarchar](900) NOT NULL,
	[Value] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[Text] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Module] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO


  INSERT INTO Module (Text) Values ('Body')
  go
    INSERT INTO Module (Text) Values ('StaticContractKey')
	go

INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (1, N'الموظفين', N'Employees', NULL, N'Att', NULL, NULL)
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (2, N'إدارة ساعات الدوام', N'MachinesManagement', NULL, N'Att', N'Attendance', N'الدوام')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (3, N'الدوام العام', N'GeneralAtt', NULL, N'Att', N'Attendance', N'الدوام')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (4, N'دوام الساعات المطلوبة', N'ByReqHours', NULL, N'Att', N'Attendance', N'الدوام')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (5, N'دوام الوردية', N'ShiftAtt', NULL, N'Att', N'Attendance', N'الدوام')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (6, N'دوام حسب الساعة', N'AttByHour', NULL, N'Att', N'Attendance', N'الدوام')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (7, N'إصدار تقارير الدوام', N'PostAttReps', NULL, N'Att', N'Attendance', N'الدوام')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (8, N'كشوفات الدوام', N'PostedAtt', NULL, N'Att', N'Attendance', N'الدوام')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (9, N'الإجازات', N'Vacations', NULL, N'Att', N'Vacations', N'الإجازات')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (10, N'الإجازات الجماعية', N'GroupsVacations', NULL, N'Att', N'Vacations', N'الإجازات')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (11, N'ثوابت النظام ', N'SystemContracts', NULL, N'Att', NULL, NULL)
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (12, N'إعدادات عامة', N'GeneralSettings', NULL, N'Att', NULL, NULL)
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (13, N'بيانات الشركة', N'CompanyData', NULL, N'Att', NULL, NULL)
GO
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (15, N'صلاحية الموظفين', N'EmployeesPerm', NULL, N'Permessions', N'Permessions', N'صلاحيات')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (16, N'صلاحية إدارة ساعات الدوام', N'MachinesManagementPerm', NULL, N'Permessions', N'Permessions', N'صلاحيات')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (17, N'صلاحية الدوام العام', N'GeneralAttPerm', NULL, N'Permessions', N'Permessions', N'صلاحيات')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (18, N'صلاحية دوام الساعات المطلوبة', N'ByReqHoursPerm', NULL, N'Permessions', N'Permessions', N'صلاحيات')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (19, N'صلاحية دوام الوردية', N'ShiftAttPerm', NULL, N'Permessions', N'Permessions', N'صلاحيات')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (20, N'صلاحية دوام حسب الساعة', N'AttByHourPerm', NULL, N'Permessions', N'Permessions', N'صلاحيات')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (21, N'صلاحية إصدار تقارير الدوام', N'PostAttRepsPerm', NULL, N'Permessions', N'Permessions', N'صلاحيات')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (22, N'صلاحية كشوفات الدوام', N'PostedAttPerm', NULL, N'Permessions', N'Permessions', N'صلاحيات')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (23, N'صلاحية الإجازات', N'VacationsPerm', NULL, N'Permessions', N'Permessions', N'صلاحيات')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (24, N'صلاحية الإجازات الجماعية', N'GroupsVacationsPerm', NULL, N'Permessions', N'Permessions', N'صلاحيات')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (25, N'صلاحية ثوابت النظام', N'SystemContractsPerm', NULL, N'Permessions', N'Permessions', N'صلاحيات')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (26, N'صلاحية إعدادات عامة', N'GeneralSettingsPerm', NULL, N'Permessions', N'Permessions', N'صلاحيات')
GO
INSERT [dbo].[PermissionsForms] ([FormId], [FormNameAR], [FormNameEN], [Description], [Category], [EnCategoryNameForShow], [ArCategoryNameForShow]) VALUES (27, N'صلاحية بيانات الشركة', N'CompanyDataPerm', NULL, N'Permessions', N'Permessions', N'صلاحيات')
GO


  INSERT INTO UsersSystem (UserID, UserName, PasswordHash, UserType, IsActive, PhoneNumber) Values ('0', 'admin', 'bc78e58d55cde1346e68f8e5fe588dedf62fa457aa646a500a53347faff6ee24', 'sa', 1, '972569216212')
  GO
  INSERT INTO UsersSystem (UserID, UserName, PasswordHash, UserType, IsActive) Values ('1', 'HR', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'la', 1)
  GO

    CREATE TABLE CheckInOutAttemps (
  CheckAttemptID [int] IDENTITY(1,1) NOT NULL,
  EmployeeID int,
  UserID int,
  CheckAttemptAt DateTime,
  IPAddress NVARCHAR(MAX)
  );
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('Accounting_PrintOrderWithTaxIncluded','True',N' طباعة الطلبية تشمل ضريبة قيمة المضافة ','Accounting')
Go

-- الحملات
ALTER PROCEDURE [dbo].[ApplyCampagins]
    @Barcode VARCHAR(50),
    @UnitID  INT,
    @DocCode VARCHAR(50),
    @ItemNo  INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    -- Fast exits (unchanged)
    IF @Barcode = '0' RETURN;

    IF NOT EXISTS (
        SELECT 1
        FROM dbo.Settings
        WHERE SettingName = 'AllowCampaginsOnPOS'
          AND SettingValue = 'True'
    )
        RETURN;

    BEGIN TRY
        ----------------------------------------------------------------------
        -- Resolve item/unit by barcode if not provided (same logic you had)
        ----------------------------------------------------------------------
        IF (@ItemNo = 0 OR @UnitID = 0)
        BEGIN
            SELECT
                @ItemNo = COALESCE(NULLIF(@ItemNo, 0), iu.item_id),
                @UnitID = COALESCE(NULLIF(@UnitID, 0), iu.unit_id)
            FROM dbo.Items_units AS iu
            WHERE iu.item_unit_bar_code = @Barcode;
        END

        IF ISNULL(@ItemNo,0) = 0 OR ISNULL(@UnitID,0) = 0 RETURN;

        ----------------------------------------------------------------------
        -- Declarations (use precise numeric types for money/qty)
        ----------------------------------------------------------------------
        DECLARE 
            @POSQuantity     DECIMAL(19,4),
            @TargetQuantity  DECIMAL(19,4),
            @NewPrice        DECIMAL(19,4),
            @OldPrice        DECIMAL(19,4),
            @OnlyThisBarcode BIT,
            @BarcodeMatch    BIT,
            @LatestCampaginID INT;

        ----------------------------------------------------------------------
        -- Base price from Items_units by item+unit (more reliable than barcode)
        ----------------------------------------------------------------------
        SELECT @OldPrice = CONVERT(DECIMAL(19,4), iu.Price1)
        FROM dbo.Items_units AS iu
        WHERE iu.item_id = @ItemNo
          AND iu.unit_id = @UnitID;

        IF @OldPrice IS NULL RETURN;

        ----------------------------------------------------------------------
        -- Pick the latest applicable campaign ID (MAX ID) for current context
        ----------------------------------------------------------------------
        ;WITH Candidates AS
        (
            SELECT C.ID
            FROM dbo.Campagins AS C
            INNER JOIN dbo.CampaginByItemsCount AS CI
                ON CI.CampaginID = C.ID
            WHERE C.Active = 1
              AND GETDATE() BETWEEN C.FromDate AND C.ToDate
              AND (
                     (CI.OnlyThisBarcode = 1 AND CI.Barcode = @Barcode)
                   OR (ISNULL(CI.OnlyThisBarcode,0) = 0 AND CI.ItemNo = @ItemNo AND CI.UnitID = @UnitID)
                  )
        )
        SELECT @LatestCampaginID = MAX(ID) FROM Candidates;

        IF @LatestCampaginID IS NULL RETURN;

        ----------------------------------------------------------------------
        -- Determine matching mode inside chosen campaign
        -- Prefer barcode row if present; else item+unit row
        ----------------------------------------------------------------------
        IF EXISTS (
            SELECT 1
            FROM dbo.CampaginByItemsCount CI
            WHERE CI.CampaginID = @LatestCampaginID
              AND CI.OnlyThisBarcode = 1
              AND CI.Barcode = @Barcode
        )
            SET @OnlyThisBarcode = 1;
        ELSE IF EXISTS (
            SELECT 1
            FROM dbo.CampaginByItemsCount CI
            WHERE CI.CampaginID = @LatestCampaginID
              AND ISNULL(CI.OnlyThisBarcode,0) = 0
              AND CI.ItemNo = @ItemNo
              AND CI.UnitID = @UnitID
        )
            SET @OnlyThisBarcode = 0;
        ELSE
            RETURN;

        SET @BarcodeMatch = CASE WHEN @OnlyThisBarcode = 1 THEN 1 ELSE 0 END;

        ----------------------------------------------------------------------
        -- POS quantity for this doc, respecting the selected matching mode
        ----------------------------------------------------------------------
        IF @BarcodeMatch = 1
        BEGIN
            SELECT @POSQuantity = SUM(StockQuantity)
            FROM dbo.POSJournal
            WHERE DocCode     = @DocCode
              AND StockUnit   = @UnitID
              AND StockBarcode = @Barcode;
        END
        ELSE
        BEGIN
            SELECT @POSQuantity = SUM(StockQuantity)
            FROM dbo.POSJournal
            WHERE DocCode   = @DocCode
              AND StockUnit = @UnitID
              AND StockID   = @ItemNo;
        END

        IF ISNULL(@POSQuantity,0) = 0 RETURN;

        ----------------------------------------------------------------------
        -- Pull campaign line within chosen campaign & compute unit price
        ----------------------------------------------------------------------
        IF @BarcodeMatch = 1
        BEGIN
            SELECT TOP (1)
                @TargetQuantity = CONVERT(DECIMAL(19,4), CI.Quantity),
                @NewPrice       = CASE WHEN CI.Quantity <> 0 
                                       THEN CONVERT(DECIMAL(19,4), CI.Amount) / CONVERT(DECIMAL(19,4), CI.Quantity)
                                       ELSE NULL END
            FROM dbo.CampaginByItemsCount CI
            WHERE CI.CampaginID = @LatestCampaginID
              AND CI.Barcode    = @Barcode
            ORDER BY CI.ID DESC;  -- deterministic within the campaign
        END
        ELSE
        BEGIN
            SELECT TOP (1)
                @TargetQuantity = CONVERT(DECIMAL(19,4), CI.Quantity),
                @NewPrice       = CASE WHEN CI.Quantity <> 0 
                                       THEN CONVERT(DECIMAL(19,4), CI.Amount) / CONVERT(DECIMAL(19,4), CI.Quantity)
                                       ELSE NULL END
            FROM dbo.CampaginByItemsCount CI
            WHERE CI.CampaginID = @LatestCampaginID
              AND CI.ItemNo = @ItemNo
              AND CI.UnitID = @UnitID
            ORDER BY CI.ID DESC;  -- deterministic within the campaign
        END

        IF @NewPrice IS NULL RETURN;

        ----------------------------------------------------------------------
        -- Apply / reset campaign based on threshold
        ----------------------------------------------------------------------
        IF @POSQuantity >= @TargetQuantity
        BEGIN
            IF @BarcodeMatch = 1
            BEGIN
                UPDATE J
                SET 
                    J.StockDiscount = @OldPrice - @NewPrice,
                    J.DocAmount     = @NewPrice * J.StockQuantity
                FROM dbo.POSJournal AS J
                WHERE J.DocCode = @DocCode
                  AND J.StockUnit = @UnitID
                  AND J.StockBarcode = @Barcode;
            END
            ELSE
            BEGIN
                UPDATE J
                SET 
                    J.StockDiscount = @OldPrice - @NewPrice,
                    J.DocAmount     = @NewPrice * J.StockQuantity
                FROM dbo.POSJournal AS J
                WHERE J.DocCode = @DocCode
                  AND J.StockUnit = @UnitID
                  AND J.StockID   = @ItemNo;
            END
        END
        ELSE
        BEGIN
            IF @BarcodeMatch = 1
            BEGIN
                UPDATE J
                SET 
                    J.StockDiscount = CONVERT(DECIMAL(19,4), 0),
                    J.DocAmount     = @OldPrice * J.StockQuantity
                FROM dbo.POSJournal AS J
                WHERE J.DocCode = @DocCode
                  AND J.StockUnit = @UnitID
                  AND J.StockBarcode = @Barcode;
            END
            ELSE
            BEGIN
                UPDATE J
                SET 
                    J.StockDiscount = CONVERT(DECIMAL(19,4), 0),
                    J.DocAmount     = @OldPrice * J.StockQuantity
                FROM dbo.POSJournal AS J
                WHERE J.DocCode = @DocCode
                  AND J.StockUnit = @UnitID
                  AND J.StockID   = @ItemNo;
            END
        END
    END TRY
    BEGIN CATCH
        DECLARE @err NVARCHAR(2048) = ERROR_MESSAGE();
        -- Use RAISERROR for broader version compatibility
        RAISERROR('ApplyCampagins failed: %s', 16, 1, @err);
        RETURN;
    END CATCH
END
GO

-- حذف صنف من الفاتورة
Alter PROCEDURE [dbo].[PosGetAndDeleteDeletedItems] 
	-- Add the parameters for the stored procedure here
	@JournalID int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
Insert into [POSDeletedJournal] ([DebitAcc],[CredAcc],[DocAmount],[InputDateTime],
			[StockID],[StockUnit] ,[StockQuantity]  ,[StockQuantityByMainUnit] ,[StockPrice],
			[StockDiscount] ,[DeleteUser],[DocCode],[ItemName],[ShiftID] ,[StockBarcode],[DeleteDateTime])
Select [DebitAcc],[CredAcc],[DocAmount],[InputDateTime],
			[StockID],[StockUnit] ,[StockQuantity]  ,[StockQuantityByMainUnit] ,[StockPrice],
			[StockDiscount] ,[InputUser],[DocCode],[ItemName],[ShiftID] ,[StockBarcode],GETDATE() 
			From [dbo].[POSJournal] where ID=@JournalID;
Delete from [dbo].[POSJournal] where ID=@JournalID
END
GO


Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('Accounting_ShowWidthLengthCountColumnsInVouchers','False',N' عرض اعمدة الطول والعرض والعدد في الفواتير ','Accounting')
Go

-- Adds three NOT NULL columns with default 0 and backfills existing rows
ALTER TABLE dbo.Journal
ADD StockWidth  DECIMAL(18,4)  NULL CONSTRAINT DF_Journal_StockWidth  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE dbo.Journal
ADD StockLength DECIMAL(18,4)  NULL CONSTRAINT DF_Journal_StockLength DEFAULT (0) WITH VALUES;
Go
ALTER TABLE dbo.Journal
ADD StockCount  DECIMAL(18,4)  NULL CONSTRAINT DF_Journal_StockCount  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE dbo.Journal
ADD StockThickness  DECIMAL(18,4)  NULL CONSTRAINT DF_Journal_StockThickness  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE dbo.Journal
ADD StockDivision  DECIMAL(18,4)  NULL CONSTRAINT DF_Journal_StockDivision  DEFAULT (0) WITH VALUES;
Go

ALTER TABLE [dbo].[JournalTemp]
ADD StockWidth  DECIMAL(18,4)  NULL CONSTRAINT DF_JournalTemp_StockWidth  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[JournalTemp]
ADD StockLength DECIMAL(18,4)  NULL CONSTRAINT DF_JournalTemp_StockLength DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[JournalTemp]
ADD StockCount  DECIMAL(18,4)  NULL CONSTRAINT DF_JournalTemp_StockCount  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[JournalTemp]
ADD StockThickness  DECIMAL(18,4)  NULL CONSTRAINT DF_JournalTemp_StockThickness  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[JournalTemp]
ADD StockDivision  DECIMAL(18,4)  NULL CONSTRAINT DF_JournalTemp_StockDivision  DEFAULT (0) WITH VALUES;
Go


ALTER TABLE [dbo].[POSJournal]
ADD StockWidth  DECIMAL(18,4)  NULL CONSTRAINT DF_POSJournal_StockWidth  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSJournal]
ADD StockLength DECIMAL(18,4)  NULL CONSTRAINT DF_POSJournal_StockLength DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSJournal]
ADD StockCount  DECIMAL(18,4)  NULL CONSTRAINT DF_POSJournal_StockCount  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSJournal]
ADD StockThickness  DECIMAL(18,4)  NULL CONSTRAINT DF_POSJournal_StockThickness  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSJournal]
ADD StockDivision  DECIMAL(18,4)  NULL CONSTRAINT DF_POSJournal_StockDivision  DEFAULT (0) WITH VALUES;
Go


ALTER TABLE [dbo].[OrdersJournal]
ADD StockWidth  DECIMAL(18,4)  NULL CONSTRAINT DF_OrdersJournal_StockWidth  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[OrdersJournal]
ADD StockLength DECIMAL(18,4)  NULL CONSTRAINT DF_OrdersJournal_StockLength DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[OrdersJournal]
ADD StockCount  DECIMAL(18,4)  NULL CONSTRAINT DF_OrdersJournal_StockCount  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[OrdersJournal]
ADD StockThickness  DECIMAL(18,4)  NULL CONSTRAINT DF_OrdersJournal_StockThickness  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].OrdersJournal
ADD StockDivision  DECIMAL(18,4)  NULL CONSTRAINT DF_OrdersJournal_StockDivision  DEFAULT (0) WITH VALUES;
Go

ALTER TABLE [dbo].[OrdersAppJournal]
ADD StockWidth  DECIMAL(18,4)  NULL CONSTRAINT DF_OrdersAppJournal_StockWidth  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[OrdersAppJournal]
ADD StockLength DECIMAL(18,4)  NULL CONSTRAINT DF_OrdersAppJournal_StockLength DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[OrdersAppJournal]
ADD StockCount  DECIMAL(18,4)  NULL CONSTRAINT DF_OrdersAppJournal_StockCount  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[OrdersAppJournal]
ADD StockThickness  DECIMAL(18,4)  NULL CONSTRAINT DF_OrdersAppJournal_StockThickness  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[OrdersAppJournal]
ADD StockDivision  DECIMAL(18,4)  NULL CONSTRAINT DF_OrdersAppJournal_StockDivision  DEFAULT (0) WITH VALUES;
Go

ALTER TABLE [dbo].[POSDeletedJournal]
ADD StockWidth  DECIMAL(18,4)  NULL CONSTRAINT DF_POSDeletedJournal_StockWidth  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSDeletedJournal]
ADD StockLength DECIMAL(18,4)  NULL CONSTRAINT DF_POSDeletedJournal_StockLength DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSDeletedJournal]
ADD StockCount  DECIMAL(18,4)  NULL CONSTRAINT DF_POSDeletedJournal_StockCount  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSDeletedJournal]
ADD StockThickness  DECIMAL(18,4)  NULL CONSTRAINT DF_POSDeletedJournal_StockThickness  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSDeletedJournal]
ADD StockDivision  DECIMAL(18,4)  NULL CONSTRAINT DF_POSDeletedJournal_StockDivision  DEFAULT (0) WITH VALUES;
Go


ALTER TABLE [dbo].[POSHoldJournal]
ADD StockWidth  DECIMAL(18,4)  NULL CONSTRAINT DF_POSHoldJournal_StockWidth  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSHoldJournal]
ADD StockLength DECIMAL(18,4)  NULL CONSTRAINT DF_POSHoldJournal_StockLength DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSHoldJournal]
ADD StockCount  DECIMAL(18,4)  NULL CONSTRAINT DF_POSHoldJournal_StockCount  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSHoldJournal]
ADD StockThickness  DECIMAL(18,4)  NULL CONSTRAINT DF_POSHoldJournal_StockThickness  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSHoldJournal]
ADD StockDivision  DECIMAL(18,4)  NULL CONSTRAINT DF_POSHoldJournal_StockDivision  DEFAULT (0) WITH VALUES;
Go

ALTER TABLE [dbo].[JournalBeforeUpdate]
ADD StockWidth  DECIMAL(18,4)  NULL CONSTRAINT DF_JournalBeforeUpdate_StockWidth  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[JournalBeforeUpdate]
ADD StockLength DECIMAL(18,4)  NULL CONSTRAINT DF_JournalBeforeUpdate_StockLength DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[JournalBeforeUpdate]
ADD StockCount  DECIMAL(18,4)  NULL CONSTRAINT DF_JournalBeforeUpdate_StockCount  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[JournalBeforeUpdate]
ADD StockThickness  DECIMAL(18,4)  NULL CONSTRAINT DF_JournalBeforeUpdate_StockThickness  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[JournalBeforeUpdate]
ADD StockDivision  DECIMAL(18,4)  NULL CONSTRAINT DF_JournalBeforeUpdate_StockDivision  DEFAULT (0) WITH VALUES;
Go

ALTER TABLE [dbo].[Units]
ADD UnitTypeID  INT  NOT NULL CONSTRAINT DF_Units_UnitTypeID  DEFAULT (1) WITH VALUES;
Go



CREATE TABLE [dbo].[Notifications](
    [NotificationID] [int] IDENTITY(1,1) PRIMARY KEY,
    [UserID] [nvarchar](50) NULL,
    [Title] [nvarchar](200) NOT NULL,
    [Message] [nvarchar](max) NOT NULL,
    [NotificationType] [nvarchar](50) NULL, -- Info, Warning, Error, Success
    [IsRead] [bit] NOT NULL DEFAULT 0,
    [CreatedDate] [datetime] NOT NULL DEFAULT GETDATE(),
    [ReadDate] [datetime] NULL,
    [RelatedModule] [nvarchar](100) NULL, -- e.g., 'Salary', 'Attendance', 'Documents'
    [RelatedID] [int] NULL,
    [Priority] [int] NULL DEFAULT 0 -- 0=Normal, 1=High, 2=Urgent
)
Go


ALTER TABLE [dbo].[Items]
ADD TaxPercentage  DECIMAL(18,4)  NULL CONSTRAINT DF_Items_TaxPercentage  DEFAULT (0) WITH VALUES;
Go


Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('Accounting_UseVATsystem','False',N' احتساب الضريبة في النظام المالي  ','Accounting')
Go
Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('Accounting_VATdefaultPercentage','0',N' نسبة ضريبة قيمة المضافة الافتراضية ','Accounting')
Go
Delete From [dbo].[Settings] Where SettingName='Accounting_ShowItemVatColumnInVouchers'
Go

ALTER TABLE dbo.Journal
ADD IsVAT  BIT Not NULL CONSTRAINT DF_Journal_IsVAT  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[JournalTemp]
ADD IsVAT  BIT  Not NULL CONSTRAINT DF_JournalTemp_IsVAT  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSJournal]
ADD IsVAT  BIT  Not NULL CONSTRAINT DF_POSJournal_IsVAT  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[OrdersJournal]
ADD IsVAT  BIT Not NULL CONSTRAINT DF_OrdersJournal_IsVAT  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[OrdersAppJournal]
ADD IsVAT  BIT Not NULL CONSTRAINT DF_OrdersAppJournal_IsVAT  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSDeletedJournal]
ADD IsVAT  BIT  Not NULL CONSTRAINT DF_POSDeletedJournal_IsVAT  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSHoldJournal]
ADD IsVAT  BIT  Not NULL CONSTRAINT DF_POSHoldJournal_IsVAT  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[JournalBeforeUpdate]
ADD IsVAT  BIT  Not NULL CONSTRAINT DF_JournalBeforeUpdate_IsVAT  DEFAULT (0) WITH VALUES;
Go


ALTER TABLE [dbo].[ItemsGroups]
ADD VisibleInSalesApp  Bit  Not NULL CONSTRAINT DF_ItemsGroups_VisibleInSalesApp  DEFAULT (1) WITH VALUES;
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('POS_PosShowImagesInItemsView','True',N' عرض صور الاصناف في نقطة البيع ','POS')
Go

IF COL_LENGTH('dbo.AttRawatebArchive', 'InputDateTime') IS NULL
BEGIN
    ALTER TABLE dbo.AttRawatebArchive
    ADD SalaryInputDateTime DATETIME NOT NULL
        CONSTRAINT DF_AttRawatebArchive_SalaryInputDateTime DEFAULT (GETDATE());
END
Go




--SET ----------------------------------------------------------------------------------------------------
--SET ----------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE [dbo].[BuildVoucherFromOrderApp] @DocCode nvarchar(50), @ItemsCount int
AS
Declare @RowsNo int;
Set @RowsNo= ( Select IsNull(count(ID),0) As CountRows from Journal where DocCode=@DocCode);
if @RowsNo = 0 
Begin 
DECLARE @DocID int ;
SET @DocID = NEXT VALUE FOR dbo.SalesInvoiceSeq;
Declare @DocAmount float;
Set @DocAmount= ( Select sum(DocAmount) from OrdersAppJournal where DocCode=@DocCode)
DECLARE @UserID int ;
SET @UserID = ( Select top(1) InputUser  From [OrdersAppJournal] where DocCode=@DocCode );
Declare @Device Nvarchar (100);
Set @Device = (Select top (1) [DeviceName] from [OrdersAppJournal] where DocCode =@DocCode  );
Declare @UserName Nvarchar (100);
Set @UserName = (Select top (1) EmployeeName from EmployeesData where EmployeeID  =@UserID  );
Declare @DefualtWarehouses int;
Set @DefualtWarehouses = (Select  [DefaultWareHouse] from EmployeesData where EmployeeID  =@UserID  );

Insert into [JournalTemp] ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
			[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
		    [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
		    StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,
			StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,
			PosNo,DocNoteByAccount,DeviceName,DeliverDate,LastDocCode,LastDataName,StockBarcode,SalesPerson )
Select  @DocID as DocID , DocDate, 2 as DocName, 3 as DocStatus, 1 as DocCostCenter,
			'0' as DebitAcc, I.[AccSales] as CredAcc, 1 as AccountCurr,
			1 as DocCurrency, [DocAmount], 1 as ExchangePrice, [DocAmount] as BaseCurrAmount , [DocAmount] as BaseAmount, [DocID], DocNotes,
			InputUser, J.InputDateTime , StockID, StockUnit, StockQuantity, IU.EquivalentToMain,
			StockPrice, StockPrice, 0 as StockDebitWhereHouse  , @DefualtWarehouses, InputUser,
			R.RefNo, F.AccName, I.ItemName, 0, DocCode, '0', DocNoteByAccount, DeviceName, DeliverDate, DocCode, 'OrdersAppJournal' as LastDataName, IU.item_unit_bar_code as StockBarcode,SalesPerson
From [dbo].[OrdersAppJournal] J
		    Left Join [dbo].[Items] I On I.[ItemNo]=J.StockID
		    Left Join [dbo].FinancialAccounts F On J.[DebitAcc]=F.[AccNo]
		    Left join Items_units IU on J.StockID =IU.item_id and J.StockUnit=IU.unit_id
		    Left join Referencess R on R.RefNo=J.Referance
Where DocCode=@DocCode 

Insert into [JournalTemp] ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
			[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
			[DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,
			DocCode,DeviceName,PosNo,ShiftID,CurrentUserID,DeliverDate,LastDocCode,LastDataName,SalesPerson ) 
Select  top(1)  @DocID as DocID , DocDate, 2 as DocName, 3 as DocStatus, 1 as DocCostCenter,R.RefAccID,'0' as CredAcc,
			1 as AccountCurr,1 as DocCurrency,@DocAmount,1,@DocAmount,@DocAmount,DocID,DocNotes,InputUser,J.InputDateTime,R.RefNo,R.RefName,
			DocCode,DeviceName,PosNo,ShiftID,CurrentUserID,DeliverDate,DocCode,'OrdersAppJournal' as LastDataName , InputUser
From [dbo].[OrdersAppJournal] J
		    Left Join [dbo].[Items] I On I.[ItemNo]=J.StockID
		    Left Join [dbo].FinancialAccounts F On J.[DebitAcc]=F.[AccNo]
		    Left join Items_units IU on J.StockID =IU.item_id and J.StockUnit=IU.unit_id
		    left join Referencess R on R.RefNo=J.Referance
Where DocCode=@DocCode 


Insert into [dbo].[Journal] ([DocID],[DocDate] ,[DocName] ,[DocStatus]
            ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
            ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
            ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
            ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
            ,[StockUnit] ,[StockQuantity] ,[StockQuantityByMainUnit] ,[StockPrice]
            ,[StockItemPrice] ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
            ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
            ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
            ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
            ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
            ,[StockDiscount] ,[StockBarcode] ,[PosNo]
            ,[DeviceName],[LastDocCode],[LastDataName]) 
Select DocID,[DocDate] ,[DocName] ,[DocStatus]
            ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
            ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
            ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
            ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
            ,[StockUnit] ,[StockQuantity] ,[StockQuantityByMainUnit] ,[StockPrice]
            ,[StockItemPrice] ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
            ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
            ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
            ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
            ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
            ,[StockDiscount] ,[StockBarcode] ,[PosNo],[DeviceName] ,LastDocCode,LastDataName
			From JournalTemp  where DocCode=@DocCode

Delete from JournalTemp where DocCode=@DocCode

Update OrdersAppJournal set OrderStatus=1 where DocCode=@DocCode


INSERT INTO [dbo].[UsersLogs]
           ([DocCode]
           ,[DocName]
           ,[DocID]
           ,[LogName]
           ,[UserID]
           ,[LogDateTime]
           ,[DeviceName]
           ,[UserName]
           ,[LogDetails]
           ,[LogType]) Values (@DocCode,2,@DocID,'Insert',@UserID,GETDATE(),@Device,@UserName,'Issue Voucher From Mobile App','Document')


DECLARE @FinalDocID int ;
SET @FinalDocID = (  SELECT DocID 
     FROM [dbo].[Journal]  where  DocCode=@DocCode group by DocID having Count(StockID)=@ItemsCount ) ;

if right(@DocCode,4) = 'cash' 
Begin 
Declare @RefNo int;
Declare @Notes Nvarchar (100);
Declare @DocDate Varchar(50)


Set @RefNo = (Select top (1) [Referance] from [OrdersAppJournal] where DocCode =@DocCode  );
Set @Notes= (Select CONCAT('Auto Receipt From Voucher No:' , @FinalDocID));
SET @DocDate = (Select top (1) [DocDate] from [OrdersAppJournal] where DocCode =@DocCode  );



DECLARE @EmptyCheques TVP_Cheques; -- no inserts => empty

EXEC @DocID = dbo.BuildReceiptFromWEB
@ReferanceNo   = @RefNo,
@DocDate       = @DocDate,
@DocNameID     = 4,
@DocID         = 0,
@UserID        = @UserID,
@DocNote       = @Notes,
@DeviceName    = @Device,
@CurrencyID    = 1,
@CashAmount    = @DocAmount,
@ChecksAmount  = 0,
@ChequesDetails= @EmptyCheques ; -- pass the empty TVP
end

Update [dbo].[Journal] Set PaidStatus=2,PaidAmount=@DocAmount,PaidByDocID=@DocID WHERE DocName=2 And DocCode=@DocCode 


INSERT INTO [dbo].[UsersLogs]
           ([DocCode]
           ,[DocName]
           ,[DocID]
           ,[LogName]
           ,[UserID]
           ,[LogDateTime]
           ,[DeviceName]
           ,[UserName]
           ,[LogDetails]
           ,[LogType]) Values (@DocCode,4,@DocID,'Insert',@UserID,GETDATE(),@Device,@UserName,'Issue Receipt From Cash Voucher From Mobile App','Document')


--if @FinalDocID is null
-- BEGIN
-- delete from Journal where DocCode=@DocCode
-- End
end
return  @FinalDocID
GO
--SET ----------------------------------------------------------------------------------------------------
--SET ----------------------------------------------------------------------------------------------------
Go




ALTER TABLE dbo.Journal
ADD ItemVATPercentage  DECIMAL(18,4) Not NULL CONSTRAINT DF_Journal_ItemVATPercentage  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[JournalTemp]
ADD ItemVATPercentage  DECIMAL(18,4)  Not NULL CONSTRAINT DF_JournalTemp_ItemVATPercentage  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSJournal]
ADD ItemVATPercentage  DECIMAL(18,4)  Not NULL CONSTRAINT DF_POSJournal_ItemVATPercentage  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[OrdersJournal]
ADD ItemVATPercentage  DECIMAL(18,4)  Not NULL CONSTRAINT DF_OrdersJournal_ItemVATPercentage  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[OrdersAppJournal]
ADD ItemVATPercentage  DECIMAL(18,4)  Not NULL CONSTRAINT DF_OrdersAppJournal_ItemVATPercentage  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSDeletedJournal]
ADD ItemVATPercentage  DECIMAL(18,4)  Not NULL CONSTRAINT DF_POSDeletedJournal_ItemVATPercentage  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[POSHoldJournal]
ADD ItemVATPercentage  DECIMAL(18,4)  Not NULL CONSTRAINT DF_POSHoldJournal_ItemVATPercentage  DEFAULT (0) WITH VALUES;
Go
ALTER TABLE [dbo].[JournalBeforeUpdate]
ADD ItemVATPercentage  DECIMAL(18,4)  Not NULL CONSTRAINT DF_JournalBeforeUpdate_ItemVATPercentage  DEFAULT (0) WITH VALUES;
Go

--SET ----------------------------------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[BuildReturnVoucherFromOrderApp] @DocCode nvarchar(50), @ItemsCount int
AS
Declare @RowsNo int;
Set @RowsNo= ( Select IsNull(count(ID),0) As CountRows from Journal where DocCode=@DocCode);
if @RowsNo = 0 
Begin 
DECLARE @DocID int ;
SET @DocID = NEXT VALUE FOR dbo.SalesReturnsSeq;
Declare @DocAmount float;
Set @DocAmount= ( Select sum(DocAmount) from OrdersAppJournal where DocCode=@DocCode)
DECLARE @UserID int ;
SET @UserID = ( Select top(1) InputUser  From [OrdersAppJournal] where DocCode=@DocCode );
Declare @Device Nvarchar (100);
Set @Device = (Select top (1) [DeviceName] from [OrdersAppJournal] where DocCode =@DocCode  );
Declare @UserName Nvarchar (100);
Set @UserName = (Select top (1) EmployeeName from EmployeesData where EmployeeID  =@UserID  );
Declare @DefualtWarehouses int;
Set @DefualtWarehouses = (Select  [DefaultWareHouse] from EmployeesData where EmployeeID  =@UserID  );

Insert into [JournalTemp] ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
			[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
		    [DocManualNo],[DocNotes],InputUser,InputDateTime,StockID,StockUnit,
		    StockQuantity,[StockQuantityByMainUnit],StockItemPrice,StockPrice,StockDebitWhereHouse,
			StockCreditWhereHouse,CurrentUserID,Referance,ReferanceName,ItemName,ShiftID,DocCode,
			PosNo,DocNoteByAccount,DeviceName,DeliverDate,LastDocCode,LastDataName,StockBarcode,SalesPerson )
Select  @DocID as DocID , DocDate, 12 as DocName, 3 as DocStatus, 1 as DocCostCenter,
			I.AccRetSales as DebitAcc, '0' as CredAcc, 1 as AccountCurr,
			1 as DocCurrency, [DocAmount], 1 as ExchangePrice, [DocAmount] as BaseCurrAmount , [DocAmount] as BaseAmount, [DocID], DocNotes,
			InputUser, J.InputDateTime , StockID, StockUnit, StockQuantity, IU.EquivalentToMain,
			StockPrice, StockPrice, @DefualtWarehouses as StockDebitWhereHouse  , 0 as StockCreditWhereHouse, InputUser,
			R.RefNo, F.AccName, I.ItemName, 0, DocCode, '0', DocNoteByAccount, DeviceName, DeliverDate, DocCode, 'OrdersAppJournal' as LastDataName, IU.item_unit_bar_code as StockBarcode,SalesPerson
From [dbo].[OrdersAppJournal] J
		    Left Join [dbo].[Items] I On I.[ItemNo]=J.StockID
		    Left Join [dbo].FinancialAccounts F On J.[DebitAcc]=F.[AccNo]
		    Left join Items_units IU on J.StockID =IU.item_id and J.StockUnit=IU.unit_id
		    Left join Referencess R on R.RefNo=J.Referance
Where DocCode=@DocCode 

Insert into [JournalTemp] ( [DocID],[DocDate],[DocName],[DocStatus],[DocCostCenter],[DebitAcc],[CredAcc],
			[AccountCurr],[DocCurrency],[DocAmount],[ExchangePrice],[BaseCurrAmount],[BaseAmount],
			[DocManualNo],[DocNotes],InputUser,InputDateTime,Referance,ReferanceName,
			DocCode,DeviceName,PosNo,ShiftID,CurrentUserID,DeliverDate,LastDocCode,LastDataName,SalesPerson ) 
Select  top(1)  @DocID as DocID , DocDate, 12 as DocName, 3 as DocStatus, 1 as DocCostCenter,'0',R.RefAccID as CredAcc,
			1 as AccountCurr,1 as DocCurrency,@DocAmount,1,@DocAmount,@DocAmount,DocID,DocNotes,InputUser,J.InputDateTime,R.RefNo,R.RefName,
			DocCode,DeviceName,PosNo,ShiftID,CurrentUserID,DeliverDate,DocCode,'OrdersAppJournal' as LastDataName,InputUser 
From [dbo].[OrdersAppJournal] J
		    Left Join [dbo].[Items] I On I.[ItemNo]=J.StockID
		    Left Join [dbo].FinancialAccounts F On J.[DebitAcc]=F.[AccNo]
		    Left join Items_units IU on J.StockID =IU.item_id and J.StockUnit=IU.unit_id
		    left join Referencess R on R.RefNo=J.Referance
Where DocCode=@DocCode 


Insert into [dbo].[Journal] ([DocID],[DocDate] ,[DocName] ,[DocStatus]
            ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
            ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
            ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
            ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
            ,[StockUnit] ,[StockQuantity] ,[StockQuantityByMainUnit] ,[StockPrice]
            ,[StockItemPrice] ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
            ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
            ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
            ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
            ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
            ,[StockDiscount] ,[StockBarcode] ,[PosNo]
            ,[DeviceName],[LastDocCode],[LastDataName]) 
Select DocID,[DocDate] ,[DocName] ,[DocStatus]
            ,[DocCostCenter] ,[DebitAcc] ,[CredAcc] ,[AccountCurr] ,[DocCurrency] ,[DocAmount]
            ,[ExchangePrice] ,[BaseCurrAmount] ,[BaseAmount] ,[DocSort] ,[Referance]
            ,[DocManualNo] ,[DocMultiCurrency] ,[InputUser] ,[InputDateTime] ,[ModifiedUser]
            ,[ModifiedDateTime] ,[DocAuditDate] ,[DocAuditUser] ,[DocNotes] ,[StockID]
            ,[StockUnit] ,[StockQuantity] ,[StockQuantityByMainUnit] ,[StockPrice]
            ,[StockItemPrice] ,[StockDebitWhereHouse] ,[StockCreditWhereHouse] ,[StockDriver]
            ,[StockCarNo] ,[SalesPerson] ,[CheckNo] ,[CheckInOut] ,[CheckStatus]
            ,[CheckDueDate] ,[CheckCustBank] ,[CheckCustBranch] ,[CheckCustAccountId]
            ,[AccountBank] ,[DeleteUser] ,[DeleteDateTime] ,[CurrentUserID] ,[ReferanceName] ,[DocCode]
            ,[CheckCode] ,[ItemName] ,[DocCheckTransID] ,[TransNoInJournal] ,[ShiftID] ,[DocNoteByAccount]
            ,[StockDiscount] ,[StockBarcode] ,[PosNo],[DeviceName] ,LastDocCode,LastDataName
			From JournalTemp  where DocCode=@DocCode

Delete from JournalTemp where DocCode=@DocCode

Update OrdersAppJournal set OrderStatus=1 where DocCode=@DocCode

INSERT INTO [dbo].[UsersLogs]
           ([DocCode]
           ,[DocName]
           ,[DocID]
           ,[LogName]
           ,[UserID]
           ,[LogDateTime]
           ,[DeviceName]
           ,[UserName]
           ,[LogDetails]
           ,[LogType]) Values (@DocCode,2,@DocID,'Insert',@UserID,GETDATE(),@Device,@UserName,'Issue Voucher From Mobile App','Document')

DECLARE @FinalDocID int ;
SET @FinalDocID = (  SELECT DocID 
     FROM [dbo].[Journal]  where  DocCode=@DocCode group by DocID having Count(StockID)=@ItemsCount ) ;

--if @FinalDocID is null
-- BEGIN
-- delete from Journal where DocCode=@DocCode
-- End
End
return  @FinalDocID
GO


-- لتجنب تعديل السندات بين المستخدمين بنفس اللحظة
CREATE TABLE [dbo].[DocumentLocks](
    DocCode NVARCHAR(50) NOT NULL PRIMARY KEY,
    LockedByUser INT NOT NULL,
    LockDateTime DATETIME NOT NULL,
	[DeviceName] NVARCHAR(100) NULL
)

Go

CREATE OR ALTER PROCEDURE [dbo].[TryLockDocument]
    @DocCode     NVARCHAR(50),
    @UserID      INT,
    @DeviceName  NVARCHAR(100)   -- الجهاز الذي يحجز السند
AS
BEGIN
    SET NOCOUNT ON;

    -- إذا كان السند محجوزاً مسبقاً → ارجع 0
    IF EXISTS (SELECT 1
               FROM dbo.DocumentLocks
               WHERE DocCode = @DocCode)
    BEGIN
        SELECT 0 AS Result;   -- لم يتم الحصول على القفل
        RETURN;
    END;

    -- حجز السند
    INSERT INTO dbo.DocumentLocks (DocCode, LockedByUser, LockDateTime, DeviceName)
    VALUES (@DocCode, @UserID, GETDATE(), @DeviceName);

    SELECT 1 AS Result;       -- تم الحصول على القفل بنجاح
END;
GO


Go

CREATE PROCEDURE [dbo].[ReleaseDocumentLock]
    @DocCode NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM DocumentLocks WHERE DocCode = @DocCode;
END

Go



CREATE SEQUENCE [dbo].[PosReceiptVoucherSeq] 
 AS [int]
 START WITH 1
 INCREMENT BY 1
 MINVALUE -2147483648
 MAXVALUE 2147483647
 CACHE 
GO

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('Accounting_ShowTaxDateOnVouchers','False',N' عرض تاريخ الضريبة في السندات ','Accounting')
Go


ALTER TABLE dbo.Journal ADD TaxDate  Date  NULL ;
Go
ALTER TABLE [dbo].[JournalTemp] ADD TaxDate  Date  NULL ;
Go
ALTER TABLE [dbo].[POSJournal] ADD TaxDate  Date  NULL ;
Go
ALTER TABLE [dbo].[OrdersJournal] ADD TaxDate  Date  NULL ;
Go
ALTER TABLE [dbo].[OrdersAppJournal] ADD TaxDate  Date  NULL ;
Go
ALTER TABLE [dbo].[POSDeletedJournal] ADD TaxDate  Date  NULL ;
Go
ALTER TABLE [dbo].[POSHoldJournal] ADD TaxDate  Date ;
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] ADD TaxDate  Date  ;
Go





ALTER TABLE [dbo].[JournalBeforeUpdate] Add  [TarteebID] int NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [TarteebID] int NULL
Go
ALTER TABLE [dbo].[JournalBeforeUpdate] Add [OldTransID] int NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [OldTransID] int NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [DispatchQuantity] float NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [DispatchStockQuantityByMainUnit] float NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [DispatchVoucherID] int NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [SubAccount] int NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [BaseItemPrice] float NULL
Go
ALTER TABLE [dbo].[OrdersJournal] Add  [CashCustomerId] int NULL
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,[SettingTerm]) values ('POS_PrintClosedShiftReport','True',N' في نقطة البيع، طباعة تقرير اغلاق الوردية ','POS')
Go

Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,SettingTerm) values ('HR_ShowAdditionsAmountInSalarySlip','True',N' عرض حقل مبلغ الاضافات في قسيمة الراتب ','HR')
Go


Insert Into [dbo].[Settings] (SettingName,SettingValue,SettingDescription,SettingTerm) values ('Accounting_PostVouchersFromSalesApp','True',N' ترحيل الفاتورة من نظام المندوبين ','Accounting')
Go


INSERT INTO Settings (SettingName,SettingValue, SettingDescription, SettingTerm) VALUES (N'NumbersForReseiptsVoucherMsgs',N'', N'الأرقام التي ستصلها رسالة واتساب عند إضافة سند قبض / صرف', 'POS')
GO

ALTER TABLE EmployeesData ADD CanEditCustomer bit DEFAULT 0;
GO

ALTER TABLE EmployeesData ADD CanMakeOrders bit DEFAULT 0
GO

ALTER TABLE EmployeesData ADD [CanUpdatePriceToLastestSellingPrice] bit DEFAULT 0
GO

CREATE TABLE ReferencesVisits (
    VisitId INT IDENTITY(1,1) PRIMARY KEY,
    EmpId INT,
    RefNo INT,
    Longitude DECIMAL(10,6),
    Latitude DECIMAL(10,6),
    VisitTime DATETIME,
    VisitType NVARCHAR(50),
	Notes NVARCHAR(MAX)
);
GO

CREATE TABLE [dbo].[VisitServices](
    [VisitServiceId] [int] IDENTITY(1,1) NOT NULL,
    [VisitId] [int] NOT NULL,
    [ServiceId] [nvarchar](max) NOT NULL,
    [ServiceNote] [nvarchar](max) NULL,
    [DateCreated] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[VisitServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[VisitServices] ADD  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[VisitServices]  WITH CHECK ADD  CONSTRAINT [FK_VisitServices_Visits] FOREIGN KEY([VisitId])
REFERENCES [dbo].[Visits] ([VisitId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[VisitServices] CHECK CONSTRAINT [FK_VisitServices_Visits]
GO

