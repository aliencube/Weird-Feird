USE [WeirdFeird]
GO
ALTER TABLE [dbo].[UserFeeds] DROP CONSTRAINT [FK_UserFeeds_UserCategories]
GO
ALTER TABLE [dbo].[UserFeeds] DROP CONSTRAINT [FK_UserFeeds_Feeds]
GO
ALTER TABLE [dbo].[UserEntries] DROP CONSTRAINT [FK_UserEntries_Users]
GO
ALTER TABLE [dbo].[UserEntries] DROP CONSTRAINT [FK_UserEntries_Entries]
GO
ALTER TABLE [dbo].[UserCategories] DROP CONSTRAINT [FK_UserCategories_Users]
GO
ALTER TABLE [dbo].[Entries] DROP CONSTRAINT [FK_Entries_Feeds]
GO
ALTER TABLE [dbo].[Editors] DROP CONSTRAINT [FK_Editors_Feeds]
GO
ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [FK_Categories_Entries]
GO
ALTER TABLE [dbo].[Authors] DROP CONSTRAINT [FK_Authors_Entries]
GO
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_Users_DateCreated]
GO
ALTER TABLE [dbo].[UserFeeds] DROP CONSTRAINT [DF_UserFeeds_DateAdded]
GO
ALTER TABLE [dbo].[UserCategories] DROP CONSTRAINT [DF_UserCategories_DateAdded]
GO
ALTER TABLE [dbo].[Feeds] DROP CONSTRAINT [DF_Feeds_DateAdded]
GO
ALTER TABLE [dbo].[Entries] DROP CONSTRAINT [DF_Entries_DateAdded]
GO
ALTER TABLE [dbo].[Editors] DROP CONSTRAINT [DF_Editors_DateAdded]
GO
ALTER TABLE [dbo].[Categories] DROP CONSTRAINT [DF_Categories_DateAdded]
GO
ALTER TABLE [dbo].[Authors] DROP CONSTRAINT [DF_Authors_DateAdded]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 20/01/2014 23:27:49 ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[UserFeeds]    Script Date: 20/01/2014 23:27:49 ******/
DROP TABLE [dbo].[UserFeeds]
GO
/****** Object:  Table [dbo].[UserEntries]    Script Date: 20/01/2014 23:27:49 ******/
DROP TABLE [dbo].[UserEntries]
GO
/****** Object:  Table [dbo].[UserCategories]    Script Date: 20/01/2014 23:27:49 ******/
DROP TABLE [dbo].[UserCategories]
GO
/****** Object:  Table [dbo].[Feeds]    Script Date: 20/01/2014 23:27:49 ******/
DROP TABLE [dbo].[Feeds]
GO
/****** Object:  Table [dbo].[Entries]    Script Date: 20/01/2014 23:27:49 ******/
DROP TABLE [dbo].[Entries]
GO
/****** Object:  Table [dbo].[Editors]    Script Date: 20/01/2014 23:27:49 ******/
DROP TABLE [dbo].[Editors]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 20/01/2014 23:27:49 ******/
DROP TABLE [dbo].[Categories]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 20/01/2014 23:27:49 ******/
DROP TABLE [dbo].[Authors]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 20/01/2014 23:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] NOT NULL,
	[EntryId] [int] NOT NULL,
	[Author] [nvarchar](256) NOT NULL,
	[DateAdded] [datetime] NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 20/01/2014 23:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[EntryId] [int] NOT NULL,
	[Category] [nvarchar](256) NOT NULL,
	[CategoryLink] [nvarchar](512) NULL,
	[DateAdded] [datetime] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Editors]    Script Date: 20/01/2014 23:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Editors](
	[EditorId] [int] IDENTITY(1,1) NOT NULL,
	[FeedId] [int] NOT NULL,
	[Editor] [nvarchar](256) NOT NULL,
	[DateAdded] [datetime] NOT NULL,
 CONSTRAINT [PK_Editors] PRIMARY KEY CLUSTERED 
(
	[EditorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entries]    Script Date: 20/01/2014 23:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entries](
	[EntryId] [int] IDENTITY(1,1) NOT NULL,
	[FeedId] [int] NOT NULL,
	[Title] [nvarchar](256) NOT NULL,
	[Link] [nvarchar](512) NOT NULL,
	[Permalink] [nvarchar](512) NOT NULL,
	[CommentLink] [nvarchar](512) NULL,
	[Description] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Thumbnail] [nvarchar](512) NULL,
	[DateAdded] [datetime] NOT NULL,
	[DatePublished] [datetime] NULL,
 CONSTRAINT [PK_Entries] PRIMARY KEY CLUSTERED 
(
	[EntryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Feeds]    Script Date: 20/01/2014 23:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feeds](
	[FeedId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](1024) NOT NULL,
	[Link] [nvarchar](1024) NOT NULL,
	[FeedLink] [nvarchar](1024) NOT NULL,
	[Generator] [nvarchar](128) NULL,
	[DateAdded] [datetime] NOT NULL,
	[DateLastUpdated] [datetime] NULL,
 CONSTRAINT [PK_Feeds] PRIMARY KEY CLUSTERED 
(
	[FeedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserCategories]    Script Date: 20/01/2014 23:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCategories](
	[UserCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Category] [nvarchar](256) NOT NULL,
	[CategoryHierarchy] [nvarchar](256) NOT NULL,
	[DateAdded] [datetime] NOT NULL,
 CONSTRAINT [PK_UserCategories] PRIMARY KEY CLUSTERED 
(
	[UserCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserEntries]    Script Date: 20/01/2014 23:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserEntries](
	[UserEntryId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[EntryId] [int] NOT NULL,
	[HasRead] [bit] NOT NULL,
	[DateRead] [datetime] NULL,
 CONSTRAINT [PK_UserEntries] PRIMARY KEY CLUSTERED 
(
	[UserEntryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserFeeds]    Script Date: 20/01/2014 23:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFeeds](
	[UserFeedId] [int] IDENTITY(1,1) NOT NULL,
	[FeedId] [int] NOT NULL,
	[UserCategoryId] [int] NOT NULL,
	[DateAdded] [datetime] NOT NULL,
 CONSTRAINT [PK_UserFeeds] PRIMARY KEY CLUSTERED 
(
	[UserFeedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 20/01/2014 23:27:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](128) NOT NULL,
	[Password] [nvarchar](256) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateValidated] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Authors] ADD  CONSTRAINT [DF_Authors_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[Editors] ADD  CONSTRAINT [DF_Editors_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[Entries] ADD  CONSTRAINT [DF_Entries_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[Feeds] ADD  CONSTRAINT [DF_Feeds_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[UserCategories] ADD  CONSTRAINT [DF_UserCategories_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[UserFeeds] ADD  CONSTRAINT [DF_UserFeeds_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Authors]  WITH CHECK ADD  CONSTRAINT [FK_Authors_Entries] FOREIGN KEY([EntryId])
REFERENCES [dbo].[Entries] ([EntryId])
GO
ALTER TABLE [dbo].[Authors] CHECK CONSTRAINT [FK_Authors_Entries]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Entries] FOREIGN KEY([EntryId])
REFERENCES [dbo].[Entries] ([EntryId])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Entries]
GO
ALTER TABLE [dbo].[Editors]  WITH CHECK ADD  CONSTRAINT [FK_Editors_Feeds] FOREIGN KEY([FeedId])
REFERENCES [dbo].[Feeds] ([FeedId])
GO
ALTER TABLE [dbo].[Editors] CHECK CONSTRAINT [FK_Editors_Feeds]
GO
ALTER TABLE [dbo].[Entries]  WITH CHECK ADD  CONSTRAINT [FK_Entries_Feeds] FOREIGN KEY([FeedId])
REFERENCES [dbo].[Feeds] ([FeedId])
GO
ALTER TABLE [dbo].[Entries] CHECK CONSTRAINT [FK_Entries_Feeds]
GO
ALTER TABLE [dbo].[UserCategories]  WITH CHECK ADD  CONSTRAINT [FK_UserCategories_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UserCategories] CHECK CONSTRAINT [FK_UserCategories_Users]
GO
ALTER TABLE [dbo].[UserEntries]  WITH CHECK ADD  CONSTRAINT [FK_UserEntries_Entries] FOREIGN KEY([EntryId])
REFERENCES [dbo].[Entries] ([EntryId])
GO
ALTER TABLE [dbo].[UserEntries] CHECK CONSTRAINT [FK_UserEntries_Entries]
GO
ALTER TABLE [dbo].[UserEntries]  WITH CHECK ADD  CONSTRAINT [FK_UserEntries_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UserEntries] CHECK CONSTRAINT [FK_UserEntries_Users]
GO
ALTER TABLE [dbo].[UserFeeds]  WITH CHECK ADD  CONSTRAINT [FK_UserFeeds_Feeds] FOREIGN KEY([FeedId])
REFERENCES [dbo].[Feeds] ([FeedId])
GO
ALTER TABLE [dbo].[UserFeeds] CHECK CONSTRAINT [FK_UserFeeds_Feeds]
GO
ALTER TABLE [dbo].[UserFeeds]  WITH CHECK ADD  CONSTRAINT [FK_UserFeeds_UserCategories] FOREIGN KEY([UserCategoryId])
REFERENCES [dbo].[UserCategories] ([UserCategoryId])
GO
ALTER TABLE [dbo].[UserFeeds] CHECK CONSTRAINT [FK_UserFeeds_UserCategories]
GO
