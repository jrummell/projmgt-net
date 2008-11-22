/****** Object:  Table [dbo].[Projects]    Script Date: 11/22/2008 13:53:30 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Projects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Projects](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [varchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StartDate] [datetime] NULL,
	[ExpEndDate] [datetime] NULL,
	[ActEndDate] [datetime] NULL,
 CONSTRAINT [PK_ProjectAssignments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
/****** Object:  Table [dbo].[Users]    Script Date: 11/22/2008 13:53:31 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](36) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Role] [smallint] NOT NULL,
	[Enabled] [bit] NOT NULL CONSTRAINT [DF_Users_Enabled]  DEFAULT ((0)),
	[Password] [varchar](40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
/****** Object:  Table [dbo].[ProjectAssignments]    Script Date: 11/22/2008 13:53:31 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectAssignments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProjectAssignments](
	[ProjectID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectAssignments_1] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
/****** Object:  Table [dbo].[Modules]    Script Date: 11/22/2008 13:53:31 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Modules]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Modules](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[Name] [varchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StartDate] [datetime] NULL,
	[ExpEndDate] [datetime] NULL,
	[ActEndDate] [datetime] NULL,
 CONSTRAINT [PK_Modules] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
/****** Object:  Table [dbo].[Tasks]    Script Date: 11/22/2008 13:53:31 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tasks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tasks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleID] [int] NOT NULL,
	[Name] [varchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StartDate] [datetime] NULL,
	[ExpEndDate] [datetime] NULL,
	[ActEndDate] [datetime] NULL,
	[Status] [smallint] NOT NULL CONSTRAINT [DF_Tasks_Status]  DEFAULT ((0)),
	[Complexity] [smallint] NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
/****** Object:  Table [dbo].[TaskAssignments]    Script Date: 11/22/2008 13:53:31 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaskAssignments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TaskAssignments](
	[TaskID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_TaskAssignments] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
/****** Object:  Table [dbo].[UserProfile]    Script Date: 11/22/2008 13:53:31 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserProfile]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserProfile](
	[ID] [int] NOT NULL,
	[FirstName] [varchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastName] [varchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address] [varchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[City] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[State] [varchar](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Zip] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PhoneNumber] [varchar](13) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
/****** Object:  Table [dbo].[ManagerAssignments]    Script Date: 11/22/2008 13:53:31 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ManagerAssignments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ManagerAssignments](
	[ManagerID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_ManagerAssignments] PRIMARY KEY CLUSTERED 
(
	[ManagerID] ASC,
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProjectAssignments_Projects]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectAssignments]'))
ALTER TABLE [dbo].[ProjectAssignments]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAssignments_Projects] FOREIGN KEY([ProjectID])
REFERENCES [Projects] ([ID])
ON DELETE CASCADE
ALTER TABLE [dbo].[ProjectAssignments] CHECK CONSTRAINT [FK_ProjectAssignments_Projects]
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProjectAssignments_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectAssignments]'))
ALTER TABLE [dbo].[ProjectAssignments]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAssignments_Users] FOREIGN KEY([UserID])
REFERENCES [Users] ([ID])
ON UPDATE CASCADE
ALTER TABLE [dbo].[ProjectAssignments] CHECK CONSTRAINT [FK_ProjectAssignments_Users]
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Modules_Projects]') AND parent_object_id = OBJECT_ID(N'[dbo].[Modules]'))
ALTER TABLE [dbo].[Modules]  WITH CHECK ADD  CONSTRAINT [FK_Modules_Projects] FOREIGN KEY([ProjectID])
REFERENCES [Projects] ([ID])
ON DELETE CASCADE
ALTER TABLE [dbo].[Modules] CHECK CONSTRAINT [FK_Modules_Projects]
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Tasks_Modules]') AND parent_object_id = OBJECT_ID(N'[dbo].[Tasks]'))
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Modules] FOREIGN KEY([ModuleID])
REFERENCES [Modules] ([ID])
ON DELETE CASCADE
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Modules]
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TaskAssigments_Tasks]') AND parent_object_id = OBJECT_ID(N'[dbo].[TaskAssignments]'))
ALTER TABLE [dbo].[TaskAssignments]  WITH CHECK ADD  CONSTRAINT [FK_TaskAssigments_Tasks] FOREIGN KEY([TaskID])
REFERENCES [Tasks] ([ID])
ON DELETE CASCADE
ALTER TABLE [dbo].[TaskAssignments] CHECK CONSTRAINT [FK_TaskAssigments_Tasks]
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TaskAssigments_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[TaskAssignments]'))
ALTER TABLE [dbo].[TaskAssignments]  WITH CHECK ADD  CONSTRAINT [FK_TaskAssigments_Users] FOREIGN KEY([UserID])
REFERENCES [Users] ([ID])
ON DELETE CASCADE
ALTER TABLE [dbo].[TaskAssignments] CHECK CONSTRAINT [FK_TaskAssigments_Users]
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserProfile_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserProfile]'))
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_UserProfile_Users] FOREIGN KEY([ID])
REFERENCES [Users] ([ID])
ON DELETE CASCADE
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_UserProfile_Users]
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ManagerAssignments_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[ManagerAssignments]'))
ALTER TABLE [dbo].[ManagerAssignments]  WITH CHECK ADD  CONSTRAINT [FK_ManagerAssignments_Users] FOREIGN KEY([UserID])
REFERENCES [Users] ([ID])
ON DELETE CASCADE
ALTER TABLE [dbo].[ManagerAssignments] CHECK CONSTRAINT [FK_ManagerAssignments_Users]


