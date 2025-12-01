use Optimus
-- تعديلات جدول حركات الدوام
ALTER TABLE [dbo].[AttCHECKINOUTPending] Add [ManagerId] int NULL
Go
ALTER TABLE [dbo].[AttCHECKINOUTPending] Add [DocStatus] int NULL
Go
ALTER TABLE [dbo].[AttCHECKINOUTPending] Add [ActionTakenOn] [nvarchar](500) NULL
Go
ALTER TABLE [dbo].[AttCHECKINOUTPending] Add [RecordType] [nvarchar](50) NULL
Go
ALTER TABLE [dbo].[AttCHECKINOUTPending] Add [NoteDetails] [nvarchar](500) NULL
Go

-- تعديلات جدول انواع الاجازات
ALTER TABLE [dbo].[VocationsPending] Add 	[NoteFromHR] [nvarchar](500) NULL
Go
ALTER TABLE [dbo].[VocationsPending] Add 	[ActionTakenBy] [int] NULL
Go
ALTER TABLE [dbo].[VocationsPending] Add 	[ActionTakenOn] [nvarchar](max) NULL
Go
ALTER TABLE [dbo].[VocationsPending] Add 	[ManagerId] [int] NULL
Go
ALTER TABLE [dbo].[VocationsPending] Add 	[deleted] [int] NULL
Go
ALTER TABLE [dbo].[VocationsPending] Add 	[Path] [nvarchar](max) NULL
Go
ALTER TABLE [dbo].[VocationsPending] ADD  CONSTRAINT [DF_VocationsPending_NoteFromManager]  DEFAULT ('') FOR [NoteFromManager]
GO
ALTER TABLE [dbo].[VocationsPending] ADD  CONSTRAINT [DF_VocationsPending_NoteFromHR]  DEFAULT ('') FOR [NoteFromHR]
GO
ALTER TABLE [dbo].[VocationsPending] ADD  CONSTRAINT [DF_VocationsPending_ActionTakenBy]  DEFAULT ((-1)) FOR [ActionTakenBy]
GO

-- تعديلات جدول الموظفين
ALTER TABLE [dbo].[EmployeesData] Add 	[ApproveInd] [nvarchar](50) NULL
GO
ALTER TABLE [dbo].[EmployeesData] Add 	[WebPass] [nvarchar](max) NULL
GO
ALTER TABLE [dbo].[EmployeesData] Add 	[WebPassEnc] [nvarchar](max) NULL
GO
ALTER TABLE [dbo].[EmployeesData] Add	[TempPassword] [nvarchar](max) NULL
GO
ALTER TABLE [dbo].[EmployeesData] Add	[TempPassword_Ind] [nvarchar](max) NULL
GO


-- تعديلات جدول السلف
ALTER TABLE [dbo].[AttEmployeePayments] Add	[ManagerNote] [nvarchar](max) NULL
Go
ALTER TABLE [dbo].[AttEmployeePayments] Add	[HrNote] [nvarchar](max) NULL
Go
ALTER TABLE [dbo].[AttEmployeePayments] Add	[status] [int] NULL
Go
ALTER TABLE [dbo].[AttEmployeePayments] ADD  CONSTRAINT [DF_AttEmployeePayments_PaymentAmount]  DEFAULT ('') FOR [PaymentAmount]
GO
ALTER TABLE [dbo].[AttEmployeePayments] ADD  CONSTRAINT [DF_AttEmployeePayments_PaymentType]  DEFAULT ('') FOR [PaymentType]
GO
ALTER TABLE [dbo].[AttEmployeePayments] ADD  CONSTRAINT [DF_AttEmployeePayments_PaymentBranch]  DEFAULT ('') FOR [PaymentBranch]
GO
ALTER TABLE [dbo].[AttEmployeePayments] ADD  CONSTRAINT [DF_AttEmployeePayments_PaymentNote]  DEFAULT ('') FOR [PaymentNote]
GO
ALTER TABLE [dbo].[AttEmployeePayments] ADD  CONSTRAINT [DF_AttEmployeePayments_ManagerNote]  DEFAULT ('') FOR [ManagerNote]
GO
ALTER TABLE [dbo].[AttEmployeePayments] ADD  CONSTRAINT [DF_AttEmployeePayments_HrNote]  DEFAULT ('') FOR [HrNote]
GO
ALTER TABLE [dbo].[AttEmployeePayments] ADD  CONSTRAINT [DF_AttEmployeePayments_status]  DEFAULT ((0)) FOR [status]
GO


-- تعديلات وانشاء جدول المغادرات
CREATE TABLE [dbo].[AttEmployeeLeaves](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date_] [nvarchar](max) NULL,
	[EmployeeId] [nvarchar](max) NULL,
	[From_] [nvarchar](max) NULL,
	[To_] [nvarchar](max) NULL,
	[Type] [nvarchar](max) NULL,
	[EmployeeNotes] [nvarchar](max) NOT NULL,
	[ManagerNotes] [nvarchar](max) NULL,
	[HrNotes] [nvarchar](max) NULL,
	[status] [nvarchar](max) NULL,
 CONSTRAINT [PK_AttEmployeeLeaves] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AttEmployeeLeaves] ADD  CONSTRAINT [DF_AttEmployeeLeaves_ManagerNotes]  DEFAULT ('') FOR [ManagerNotes]
GO
ALTER TABLE [dbo].[AttEmployeeLeaves] ADD  CONSTRAINT [DF_AttEmployeeLeaves_HrNotes]  DEFAULT ('') FOR [HrNotes]
GO
ALTER TABLE [dbo].[AttEmployeeLeaves] ADD  CONSTRAINT [DF_AttEmployeeLeaves_status]  DEFAULT ((0)) FOR [status]
GO


-- تعديلات وانشاء جدول طلبات الاضافي
CREATE TABLE [dbo].[AttEmployeeOvertime](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date_] [nvarchar](max) NULL,
	[Hours] [nvarchar](max) NULL,
	[EmployeeId] [int] NULL,
	[note] [nvarchar](max) NULL,
	[ManagerNote] [nvarchar](max) NULL,
	[HrNote] [nvarchar](max) NULL,
	[status] [nvarchar](max) NULL,
 CONSTRAINT [PK_AttEmployeeOvertime] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AttEmployeeOvertime] ADD  CONSTRAINT [DF_AttEmployeeOvertime_notes]  DEFAULT ('') FOR [note]
GO
ALTER TABLE [dbo].[AttEmployeeOvertime] ADD  CONSTRAINT [DF_AttEmployeeOvertime_ManagerNote]  DEFAULT ('') FOR [ManagerNote]
GO
ALTER TABLE [dbo].[AttEmployeeOvertime] ADD  CONSTRAINT [DF_AttEmployeeOvertime_HrNote]  DEFAULT ('') FOR [HrNote]
GO
ALTER TABLE [dbo].[AttEmployeeOvertime] ADD  CONSTRAINT [DF_AttEmployeeOvertime_status]  DEFAULT ((0)) FOR [status]
GO



-- انشاء وتعديلات جدول الاشعارات
CREATE TABLE [dbo].[Notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[message] [nvarchar](max) NULL,
	[employeeId] [int] NULL,
	[To_] [nvarchar](max) NULL,
	[Dept] [nvarchar](max) NULL,
	[date_time] [nvarchar](max) NULL,
	[status] [nvarchar](max) NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Notifications] ADD  CONSTRAINT [DF_Notifications_message]  DEFAULT ('') FOR [message]
GO
ALTER TABLE [dbo].[Notifications] ADD  CONSTRAINT [DF_Notifications_To_]  DEFAULT ('') FOR [To_]
GO
ALTER TABLE [dbo].[Notifications] ADD  CONSTRAINT [DF_Notifications_Dept]  DEFAULT ('') FOR [Dept]
GO
ALTER TABLE [dbo].[Notifications] ADD  CONSTRAINT [DF_Notifications_date_time]  DEFAULT ('') FOR [date_time]
GO
ALTER TABLE [dbo].[Notifications] ADD  CONSTRAINT [DF_Notifications_status]  DEFAULT ((0)) FOR [status]
GO



CREATE VIEW [dbo].[OrdersHR]
AS
SELECT        V.[VocID] AS DocID, [VocDate] AS DocDate, E.EmployeeName, '1' AS DocName, N'طلب اجازة' AS DocNameText, E.Mobile1 AS Mobile, T .Vocation AS DocType, DocStatus, DocInputDateTime, E.JobName, 
                         E.[Department], E.[Branch], V.[EmployeeID], CONVERT(date, FromDate) AS FromDate, CONVERT(date, toDate) AS ToDate, e.ManagerID
FROM            [dbo].[VocationsPending] V LEFT JOIN
                         EmployeesData E ON V.EmployeeID = E.[EmployeeID] LEFT JOIN
                         VocationsTypes T ON V.VocationType = T .VocID
UNION
SELECT        V.ID AS DocID, [CHECKTIME] AS DocDate, E.EmployeeName, '2' AS DocName, N'حركة دوام' AS DocNameText, E.Mobile1 AS Mobile, T .InArabic AS DocType, [TransStatus] AS DocStatus, DocInputDateTime, 
                         E.JobName, E.[Department], E.[Branch], V.[USERID], [CHECKTIME], '', v.ManagerId
FROM            [dbo].AttCHECKINOUTPending V LEFT JOIN
                         EmployeesData E ON V.[USERID] = E.[EmployeeID] LEFT JOIN
                         [CheckTypes] T ON V.CHECKTYPE COLLATE Latin1_General_CS_AS = T .CheckType COLLATE Latin1_General_CS_AS

			
GO



CREATE TABLE [dbo].[Notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[message] [nvarchar](max) NULL,
	[employeeId] [int] NULL,
	[To_] [nvarchar](max) NULL,
	[Dept] [nvarchar](max) NULL,
	[date_time] [nvarchar](max) NULL,
	[status] [nvarchar](max) NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Notifications] ADD  CONSTRAINT [DF_Notifications_message]  DEFAULT ('') FOR [message]
GO
ALTER TABLE [dbo].[Notifications] ADD  CONSTRAINT [DF_Notifications_To_]  DEFAULT ('') FOR [To_]
GO
ALTER TABLE [dbo].[Notifications] ADD  CONSTRAINT [DF_Notifications_Dept]  DEFAULT ('') FOR [Dept]
GO
ALTER TABLE [dbo].[Notifications] ADD  CONSTRAINT [DF_Notifications_date_time]  DEFAULT ('') FOR [date_time]
GO
ALTER TABLE [dbo].[Notifications] ADD  CONSTRAINT [DF_Notifications_status]  DEFAULT ((0)) FOR [status]
GO





ALTER TABLE [dbo].[AttEmployeePayments] Add [Entry_date] [nvarchar](max) NULL
Go
ALTER TABLE [dbo].[AttEmployeeOvertime] Add 	[Entry_date] [nvarchar](max) NULL
Go
ALTER TABLE [dbo].[AttEmployeeLeaves] Add 	[Entry_date] [nvarchar](max) NULL
Go




CREATE VIEW [dbo].[vw_Notifications]
AS
SELECT    dbo.EmployeesData.EmployeeName, dbo.Notifications.message, dbo.Notifications.date_time, dbo.Notifications.status, dbo.EmployeesData.EmployeeID, dbo.Notifications.Id
FROM         dbo.Notifications INNER JOIN
                      dbo.EmployeesData ON dbo.Notifications.employeeId = dbo.EmployeesData.EmployeeID
GO


CREATE VIEW [dbo].[vw_orders_all]
AS
SELECT        dbo.vw_orders_all_.ID, dbo.vw_orders_all_.employeeId, dbo.vw_orders_all_.Full_name, dbo.vw_orders_all_.Req_Date, dbo.vw_orders_all_.Type, dbo.EmployeesData.ManagerID, dbo.vw_orders_all_.DocStatus, 
                         dbo.EmployeesData.Mobile1, dbo.vw_orders_all_.entry_date
FROM            dbo.EmployeesData INNER JOIN
                         dbo.vw_orders_all_ ON dbo.EmployeesData.EmployeeID = dbo.vw_orders_all_.employeeId
GO

CREATE VIEW [dbo].[vw_orders_all_]
AS
SELECT        [VocID] AS ID, employeeId, VocDate AS entry_date,
                             (SELECT        [EmployeeName]
                               FROM            EmployeesData
                               WHERE        EmployeesData.EmployeeID = [VocationsPending].EmployeeID) AS Full_name, VocDate AS Req_Date, N'اجازة' AS Type, DocStatus
FROM            [dbo].[VocationsPending]
UNION ALL
SELECT        ID, USERID, DocInputDateTime AS entry_date,
                             (SELECT        [EmployeeName]
                               FROM            EmployeesData
                               WHERE        EmployeesData.EmployeeID = AttCHECKINOUTPending.USERID) AS Full_name, DocInputDateTime, N'تعديل دوام' AS Type, TransStatus
FROM            AttCHECKINOUTPending
UNION ALL
SELECT        PaymentID, employeeId, entry_date,
                             (SELECT        [EmployeeName]
                               FROM            EmployeesData
                               WHERE        EmployeesData.EmployeeID = AttEmployeePayments.employeeId) AS Full_name, PaymentDate, N'سلفة' AS Type, status
FROM            AttEmployeePayments
UNION ALL
SELECT        Id, employeeId, entry_date,
                             (SELECT        [EmployeeName]
                               FROM            EmployeesData
                               WHERE        EmployeesData.EmployeeID = AttEmployeeLeaves.employeeId) AS Full_name, Date_, N'مغادرة' AS Type, status
FROM            AttEmployeeLeaves
UNION ALL
SELECT        Id, employeeId, entry_date,
                             (SELECT        [EmployeeName]
                               FROM            EmployeesData
                               WHERE        EmployeesData.EmployeeID = AttEmployeeOvertime.employeeId) AS Full_name, Date_, N'عمل اضافي' AS Type, status
FROM            AttEmployeeOvertime
GO


CREATE TABLE [dbo].[AttEmployeeGeneralRequests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[Notes] [nvarchar](max) NULL,
	[ManagerNotes] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[Date_] [nvarchar](max) NULL,
	[Entry_date] [nvarchar](50) NULL,
 CONSTRAINT [PK_AttEmployeeGeneralRequests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AttEmployeeGeneralRequests] ADD  CONSTRAINT [DF_AttEmployeeGeneralRequests_Entry_date]  DEFAULT (format(getdate(),'yyyy-MM-dd')) FOR [Entry_date]
GO

Go
Update EmployeesData set ApproveInd = 'no' where ApproveInd is null


Go
Update [dbo].[AttEmployeePayments] set [Status]=1 where [Status] is null

Go
CREATE TABLE [dbo].[Pages](
	[PageId] [int] IDENTITY(1,1) NOT NULL,
	[PageName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[PageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


Go
CREATE TABLE [dbo].[EmployeePermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NULL,
	[PageID] [int] NULL,
	[Allowd] [int] NULL,
 CONSTRAINT [PK_EmployeePermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


Go
SET IDENTITY_INSERT [dbo].[Pages] ON 
GO
INSERT [dbo].[Pages] ([PageId], [PageName]) VALUES (1, N'اجازة')
GO
INSERT [dbo].[Pages] ([PageId], [PageName]) VALUES (2, N'اذن مغادرة')
GO
INSERT [dbo].[Pages] ([PageId], [PageName]) VALUES (3, N'تعديل حركة دوام')
GO
INSERT [dbo].[Pages] ([PageId], [PageName]) VALUES (4, N'عمل اضافي')
GO
INSERT [dbo].[Pages] ([PageId], [PageName]) VALUES (5, N'سلفة')
GO
INSERT [dbo].[Pages] ([PageId], [PageName]) VALUES (6, N'غير ذلك-عام')
GO
INSERT [dbo].[Pages] ([PageId], [PageName]) VALUES (7, N'طلبات صادرة')
GO
INSERT [dbo].[Pages] ([PageId], [PageName]) VALUES (8, N'طلبات واردة')
GO
INSERT [dbo].[Pages] ([PageId], [PageName]) VALUES (9, N'التقارير')
GO
INSERT [dbo].[Pages] ([PageId], [PageName]) VALUES (10, N'ارصدة الاجازات ')
GO
INSERT [dbo].[Pages] ([PageId], [PageName]) VALUES (11, N'العهدة')
GO
INSERT [dbo].[Pages] ([PageId], [PageName]) VALUES (12, N'دوام')
GO
INSERT [dbo].[Pages] ([PageId], [PageName]) VALUES (13, N'الاشعارات')
GO
SET IDENTITY_INSERT [dbo].[Pages] OFF
GO


CREATE VIEW [dbo].[vw_EmployeesPages]
AS
SELECT    dbo.EmployeesData.EmployeeID, dbo.EmployeesData.EmployeeName, dbo.EmployeePermissions.Allowd, dbo.Pages.PageId, dbo.Pages.PageName
FROM         dbo.EmployeesData INNER JOIN
                      dbo.EmployeePermissions ON dbo.EmployeesData.ID = dbo.EmployeePermissions.Id INNER JOIN
                      dbo.Pages ON dbo.EmployeePermissions.PageID = dbo.Pages.PageId
GO