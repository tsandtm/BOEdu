USE [danhmucthongtin]
GO
/****** Object:  Table [dbo].[cont_Catologies]    Script Date: 12/31/2014 14:07:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cont_Catologies](
	[CatologyGuid] [uniqueidentifier] NOT NULL,
	[CatologyID] [int] IDENTITY(1,1) NOT NULL,
	[CatologyName] [nvarchar](256) NULL,
	[Description] [nvarchar](1000) NULL,
	[KindCatologyGuid] [uniqueidentifier] NULL,
	[KindCatologyName] [nvarchar](256) NULL,
	[ListStringToSort] [nvarchar](max) NULL,
	[ListPlacementGuid] [nvarchar](max) NULL,
	[ListPlacementName] [nvarchar](max) NULL,
	[Levels] [int] NULL,
	[Position] [int] NULL,
	[URLHinhAnh] [nvarchar](256) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK__cont_Cat__6183307F7F60ED59] PRIMARY KEY CLUSTERED 
(
	[CatologyGuid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[cont_Catologies] ON
INSERT [dbo].[cont_Catologies] ([CatologyGuid], [CatologyID], [CatologyName], [Description], [KindCatologyGuid], [KindCatologyName], [ListStringToSort], [ListPlacementGuid], [ListPlacementName], [Levels], [Position], [URLHinhAnh], [IsActive]) VALUES (N'030cf686-c734-48a4-8eb7-0c2013f93594', 102, N'11', N'11', N'b526c783-a439-4cdd-95ac-baf8ea44bc08', N'1', N'000000000000000000000000000000010000000000000001', N';0C7874C2-5221-4753-A533-BA5069B1D37A;B526C783-A439-4CDD-95AC-BAF8EA44BC08', N'\root\1', 2, 1, NULL, 1)
INSERT [dbo].[cont_Catologies] ([CatologyGuid], [CatologyID], [CatologyName], [Description], [KindCatologyGuid], [KindCatologyName], [ListStringToSort], [ListPlacementGuid], [ListPlacementName], [Levels], [Position], [URLHinhAnh], [IsActive]) VALUES (N'0abfe625-c106-47cd-9007-1a99f7d4d82a', 110, N'1112', N'', N'994cb9e0-ea7a-4969-9169-24c670aef401', N'|________111', N'00000000000000000000000000000001000000000000000100000000000000010000000000000010', N';0C7874C2-5221-4753-A533-BA5069B1D37A;B526C783-A439-4CDD-95AC-BAF8EA44BC08;030cf686-c734-48a4-8eb7-0c2013f93594;994cb9e0-ea7a-4969-9169-24c670aef401', N'\root\1\11\111', 4, 2, NULL, 1)
INSERT [dbo].[cont_Catologies] ([CatologyGuid], [CatologyID], [CatologyName], [Description], [KindCatologyGuid], [KindCatologyName], [ListStringToSort], [ListPlacementGuid], [ListPlacementName], [Levels], [Position], [URLHinhAnh], [IsActive]) VALUES (N'994cb9e0-ea7a-4969-9169-24c670aef401', 103, N'111', N'111', N'030cf686-c734-48a4-8eb7-0c2013f93594', N'|____11', N'0000000000000000000000000000000100000000000000010000000000000001', N';0C7874C2-5221-4753-A533-BA5069B1D37A;B526C783-A439-4CDD-95AC-BAF8EA44BC08;030cf686-c734-48a4-8eb7-0c2013f93594', N'\root\1\11', 3, 1, NULL, 1)
INSERT [dbo].[cont_Catologies] ([CatologyGuid], [CatologyID], [CatologyName], [Description], [KindCatologyGuid], [KindCatologyName], [ListStringToSort], [ListPlacementGuid], [ListPlacementName], [Levels], [Position], [URLHinhAnh], [IsActive]) VALUES (N'a2419c68-fb14-4227-804e-4b3bc3d2d04d', 104, N'12', N'12', N'b526c783-a439-4cdd-95ac-baf8ea44bc08', N'1', N'000000000000000000000000000000010000000000000010', N';0C7874C2-5221-4753-A533-BA5069B1D37A;B526C783-A439-4CDD-95AC-BAF8EA44BC08', N'\root\1', 2, 2, NULL, 1)
INSERT [dbo].[cont_Catologies] ([CatologyGuid], [CatologyID], [CatologyName], [Description], [KindCatologyGuid], [KindCatologyName], [ListStringToSort], [ListPlacementGuid], [ListPlacementName], [Levels], [Position], [URLHinhAnh], [IsActive]) VALUES (N'd4d38df3-3a5a-4e75-a026-6fa210def3a0', 111, N'111121', N'', N'0abfe625-c106-47cd-9007-1a99f7d4d82a', N'|____________1112', N'000000000000000000000000000000010000000000000001000000000000000100000000000000100000000000000000', N';0C7874C2-5221-4753-A533-BA5069B1D37A;B526C783-A439-4CDD-95AC-BAF8EA44BC08;030cf686-c734-48a4-8eb7-0c2013f93594;994cb9e0-ea7a-4969-9169-24c670aef401;0abfe625-c106-47cd-9007-1a99f7d4d82a', N'\root\1\11\111\1112', 5, 0, NULL, 1)
INSERT [dbo].[cont_Catologies] ([CatologyGuid], [CatologyID], [CatologyName], [Description], [KindCatologyGuid], [KindCatologyName], [ListStringToSort], [ListPlacementGuid], [ListPlacementName], [Levels], [Position], [URLHinhAnh], [IsActive]) VALUES (N'0c7874c2-5221-4753-a533-ba5069b1d37a', 105, N'root', N'goc cua danh muc', N'00000000-0000-0000-0000-000000000000', N'', N'0000000000000000', N'', N'', 0, 0, NULL, 1)
INSERT [dbo].[cont_Catologies] ([CatologyGuid], [CatologyID], [CatologyName], [Description], [KindCatologyGuid], [KindCatologyName], [ListStringToSort], [ListPlacementGuid], [ListPlacementName], [Levels], [Position], [URLHinhAnh], [IsActive]) VALUES (N'b526c783-a439-4cdd-95ac-baf8ea44bc08', 106, N'1', N'1', N'0c7874c2-5221-4753-a533-ba5069b1d37a', N'root', N'00000000000000000000000000000001', N';0C7874C2-5221-4753-A533-BA5069B1D37A', N'\root', 1, 1, NULL, 1)
INSERT [dbo].[cont_Catologies] ([CatologyGuid], [CatologyID], [CatologyName], [Description], [KindCatologyGuid], [KindCatologyName], [ListStringToSort], [ListPlacementGuid], [ListPlacementName], [Levels], [Position], [URLHinhAnh], [IsActive]) VALUES (N'3ca78373-ace7-4e91-8fdc-bbbec9f78178', 112, N'3', N'', N'0c7874c2-5221-4753-a533-ba5069b1d37a', N'root', N'00000000000000000000000000000011', N';0C7874C2-5221-4753-A533-BA5069B1D37A', N'\root', 1, 3, NULL, 1)
INSERT [dbo].[cont_Catologies] ([CatologyGuid], [CatologyID], [CatologyName], [Description], [KindCatologyGuid], [KindCatologyName], [ListStringToSort], [ListPlacementGuid], [ListPlacementName], [Levels], [Position], [URLHinhAnh], [IsActive]) VALUES (N'a455c2de-1ad6-46b1-b414-e15c771ec224', 107, N'1111', N'1', N'994cb9e0-ea7a-4969-9169-24c670aef401', N'|________111', N'00000000000000000000000000000001000000000000000100000000000000010000000000000000', N';0C7874C2-5221-4753-A533-BA5069B1D37A;B526C783-A439-4CDD-95AC-BAF8EA44BC08;030cf686-c734-48a4-8eb7-0c2013f93594;994cb9e0-ea7a-4969-9169-24c670aef401', N'\root\1\11\111', 4, 0, NULL, 1)
SET IDENTITY_INSERT [dbo].[cont_Catologies] OFF
/****** Object:  StoredProcedure [dbo].[cont_Catologies_ngocnv10052014_UpdateImage]    Script Date: 12/31/2014 14:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[cont_Catologies_ngocnv10052014_UpdateImage]

/*
Author:   			tsandtm
Created: 			2014-3-11
Last Modified: 		2014-3-11
*/
	
@CatologyGuid uniqueidentifier, 
@URLHinhAnh nvarchar(256)

-- WITH ENCRYPTION
AS

UPDATE 		[dbo].[cont_Catologies] 

SET
			URLHinhAnh = @URLHinhAnh
			
WHERE
			[CatologyGuid] = @CatologyGuid
GO
/****** Object:  StoredProcedure [dbo].[cont_Catologies_ngocnv10052014_Update]    Script Date: 12/31/2014 14:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cont_Catologies_ngocnv10052014_Update]

/*
Author:   			tsandtm
Created: 			2014-3-11
Last Modified: 		2014-3-11
*/
	
@CatologyGuid uniqueidentifier, 
@CatologyName nvarchar(256), 
@Description nvarchar(1000), 
@KindCatologyGuid uniqueidentifier, 
@KindCatologyName nvarchar(256),
@IsActive bit

--@SaveSetting bit,
--@SettingGroup nvarchar(256),
--@SettingValue nvarchar(256)

-- WITH ENCRYPTION
AS

SET XACT_ABORT ON
BEGIN TRANSACTION

UPDATE 		[dbo].[cont_Catologies] 

SET
			[CatologyName] = @CatologyName,
			[Description] = @Description,
			[KindCatologyGuid] = @KindCatologyGuid,
			[KindCatologyName] = @KindCatologyName,
			IsActive=@IsActive
			
WHERE
			[CatologyGuid] = @CatologyGuid



--IF (@SaveSetting= 'TRUE')
--	BEGIN
--	if((select COUNT(1) from cf_Settings where SettingGroup= @SettingGroup and SettingValue= @CatologyGuid) <1)
--	INSERT INTO cf_Settings(SettingGuid,SettingValue,SettingGroup)VALUES (NEWID(),@CatologyGuid,@SettingGroup)
--	END
--ELSE
--	DELETE FROM cf_Settings WHERE @CatologyGuid=SettingValue AND @SettingGroup=SettingGroup
	
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[cont_Catologies_ngocnv10052014_SelectPage_4para]    Script Date: 12/31/2014 14:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cont_Catologies_ngocnv10052014_SelectPage_4para]

-- Author:   			tsandtm
-- Created: 			2014-3-11
-- Last Modified: 		2014-3-11
@RootGuid nvarchar(256),
@IsActive int,
@PageNumber 			int,
@PageSize 			int
-- WITH ENCRYPTION
AS

DECLARE @PageLowerBound int
DECLARE @PageUpperBound int


SET @PageLowerBound = (@PageSize * @PageNumber) - @PageSize
SET @PageUpperBound = @PageLowerBound + @PageSize + 1

/*
Note: temp tables use the server default for collation not the database default
so if adding character columns be sure and specify to use the database collation like this
to avoid collation errors:

CREATE TABLE #PageIndexForUsers
(
IndexID int IDENTITY (1, 1) NOT NULL,
UserName nvarchar(50) COLLATE DATABASE_DEFAULT,
LoginName nvarchar(50) COLLATE DATABASE_DEFAULT
) 


*/

CREATE TABLE #PageIndex 
(
	IndexID int IDENTITY (1, 1) NOT NULL,
CatologyGuid UniqueIdentifier
)

BEGIN

INSERT INTO #PageIndex ( 
CatologyGuid
)

SELECT
		[CatologyGuid]
		
FROM
		[dbo].[cont_Catologies]
		
where 
	(ListPlacementGuid like '%'+@RootGuid+'%')
	and (@IsActive=-1 or IsActive=@IsActive)
	
order by ListStringToSort

END


SELECT
		t1.*
		
FROM
		[dbo].[cont_Catologies] t1

JOIN			#PageIndex t2
ON			
		t1.[CatologyGuid] = t2.[CatologyGuid]
		
WHERE
		t2.IndexID > @PageLowerBound 
		AND t2.IndexID < @PageUpperBound
		
ORDER BY t2.IndexID

DROP TABLE #PageIndex
GO
/****** Object:  StoredProcedure [dbo].[cont_Catologies_ngocnv10052014_SelectPage]    Script Date: 12/31/2014 14:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cont_Catologies_ngocnv10052014_SelectPage]

-- Author:   			tsandtm
-- Created: 			2014-3-11
-- Last Modified: 		2014-3-11

@PageNumber 			int,
@PageSize 			int
-- WITH ENCRYPTION
AS

DECLARE @PageLowerBound int
DECLARE @PageUpperBound int


SET @PageLowerBound = (@PageSize * @PageNumber) - @PageSize
SET @PageUpperBound = @PageLowerBound + @PageSize + 1

/*
Note: temp tables use the server default for collation not the database default
so if adding character columns be sure and specify to use the database collation like this
to avoid collation errors:

CREATE TABLE #PageIndexForUsers
(
IndexID int IDENTITY (1, 1) NOT NULL,
UserName nvarchar(50) COLLATE DATABASE_DEFAULT,
LoginName nvarchar(50) COLLATE DATABASE_DEFAULT
) 


*/

CREATE TABLE #PageIndex 
(
	IndexID int IDENTITY (1, 1) NOT NULL,
CatologyGuid UniqueIdentifier
)

BEGIN

INSERT INTO #PageIndex ( 
CatologyGuid
)

SELECT
		[CatologyGuid]
		
FROM
		[dbo].[cont_Catologies]
		
-- WHERE

-- ORDER BY

END


SELECT
		t1.*
		
FROM
		[dbo].[cont_Catologies] t1

JOIN			#PageIndex t2
ON			
		t1.[CatologyGuid] = t2.[CatologyGuid]
		
WHERE
		t2.IndexID > @PageLowerBound 
		AND t2.IndexID < @PageUpperBound
		
ORDER BY t2.IndexID

DROP TABLE #PageIndex
GO
/****** Object:  StoredProcedure [dbo].[cont_Catologies_ngocnv10052014_SelectOne_ByID]    Script Date: 12/31/2014 14:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[cont_Catologies_ngocnv10052014_SelectOne_ByID]

/*
Author:   			tsandtm
Created: 			2014-3-11
Last Modified: 		2014-3-11
*/

@CatologyID int
-- WITH ENCRYPTION
AS


SELECT
		*
		--S.SettingValue,
		--S.SettingGuid,
		--S.SettingGroup
		
FROM
		[dbo].[cont_Catologies] C
		
--LEFT OUTER JOIN cf_Settings S ON
--	S.SettingValue=C.CatologyGuid
		
WHERE
		CatologyID = @CatologyID
GO
/****** Object:  StoredProcedure [dbo].[cont_Catologies_ngocnv10052014_SelectOne]    Script Date: 12/31/2014 14:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cont_Catologies_ngocnv10052014_SelectOne]

/*
Author:   			tsandtm
Created: 			2014-3-11
Last Modified: 		2014-3-11
*/

@CatologyGuid uniqueidentifier
-- WITH ENCRYPTION
AS


SELECT
		*
		--S.SettingValue,
		--S.SettingGuid,
		--S.SettingGroup
		
FROM
		[dbo].[cont_Catologies] C
		
--LEFT OUTER JOIN cf_Settings S ON
--	S.SettingValue=C.CatologyGuid
		
WHERE
		[CatologyGuid] = @CatologyGuid
GO
/****** Object:  StoredProcedure [dbo].[cont_Catologies_ngocnv10052014_SelectAll]    Script Date: 12/31/2014 14:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cont_Catologies_ngocnv10052014_SelectAll]

/*
Author:   			tsandtm
Created: 			2014-3-11
Last Modified: 		2014-3-11
*/
-- WITH ENCRYPTION
AS


SELECT
		[CatologyGuid],
		[CatologyID],
		[CatologyName],
		[Description],
		[KindCatologyGuid],
		[KindCatologyName],
		IsActive,
		URLHinhAnh
		
FROM
		[dbo].[cont_Catologies]
GO
/****** Object:  StoredProcedure [dbo].[cont_Catologies_ngocnv10052014_Insert]    Script Date: 12/31/2014 14:07:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cont_Catologies_ngocnv10052014_Insert]

/*
Author:   			tsandtm
Created: 			2014-3-11
Last Modified: 		2014-3-11
*/

@CatologyGuid uniqueidentifier,
@CatologyName nvarchar(256),
@Description nvarchar(1000),
@KindCatologyGuid uniqueidentifier,
@KindCatologyName nvarchar(256),
@IsActive bit,
@Position int,
@ListStringToSort nvarchar(256)
--@SaveSetting bit,
--@SettingGroup nvarchar(256),
--@SettingValue nvarchar(256)

-- WITH ENCRYPTION
AS

SET XACT_ABORT ON
BEGIN TRANSACTION

--DECLARE @GuidEmpty uniqueidentifier
--SET @GuidEmpty='00000000-0000-0000-0000-000000000000'

--cap nhat ListStringToSort= ListCha + ChinhNo
--cap nhat ListPlacementGuid= ListCha + GuidCha

--DECLARE @ListPlacement nvarchar(MAX)
--IF(@KindCatologyGuid=@GuidEmpty)
--	SET @ListPlacement=''
--ELSE
--	SET @ListPlacement=
--		(SELECT ListPlacementGuid FROM cont_Catologies WHERE CatologyGuid=@KindCatologyGuid)
--		+ CONVERT(nvarchar(256), @KindCatologyGuid)+';' 

INSERT INTO 	[dbo].[cont_Catologies] 
(
				[CatologyGuid],
				[CatologyName],
				[Description],
				[KindCatologyGuid],
				[KindCatologyName],
				[IsActive],
				ListStringToSort,
				ListPlacementGuid,
				ListPlacementName,
				Levels,
				Position
				
) 

VALUES 
(
				@CatologyGuid,
				@CatologyName,
				@Description,
				@KindCatologyGuid,
				@KindCatologyName,
				@IsActive,
				(select ListStringToSort from cont_Catologies where CatologyGuid=@KindCatologyGuid) + @ListStringToSort,
				(select ListPlacementGuid from cont_Catologies where CatologyGuid=@KindCatologyGuid) + ';' + convert(nvarchar(256),@KindCatologyGuid),
				(select ListPlacementName from cont_Catologies where CatologyGuid=@KindCatologyGuid) + '\' + (select CatologyName from cont_Catologies where CatologyGuid=@KindCatologyGuid),
				(select Levels from cont_Catologies where CatologyGuid=@KindCatologyGuid) + 1,
				@Position
				
)


	
--IF (@SaveSetting= 'TRUE')
--	BEGIN
--	INSERT INTO cf_Settings(SettingGuid,SettingValue,SettingGroup)VALUES (NEWID(),@CatologyGuid,@SettingGroup)
--	END
--ELSE
--	DELETE FROM cf_Settings WHERE @CatologyGuid=SettingValue AND @SettingGroup=SettingGroup
	
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[cont_Catologies_ngocnv10052014_GetDanhMucGuid_ByLoaiDanhMucGuid]    Script Date: 12/31/2014 14:07:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cont_Catologies_ngocnv10052014_GetDanhMucGuid_ByLoaiDanhMucGuid]

/*
Author:   			tsandtm
Created: 			2013-11-26
Last Modified: 		2013-11-26
*/
-- WITH ENCRYPTION
@KindCatologyGuid uniqueidentifier
AS


SELECT TOP 1
		CatologyGuid
FROM
		[dbo].cont_Catologies
WHERE	KindCatologyGuid=@KindCatologyGuid
GO
/****** Object:  StoredProcedure [dbo].[cont_Catologies_ngocnv10052014_GetCount_2para]    Script Date: 12/31/2014 14:07:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cont_Catologies_ngocnv10052014_GetCount_2para]

/*
Author:   			tsandtm
Created: 			2014-3-11
Last Modified: 		2014-3-11
*/
-- WITH ENCRYPTION
@RootGuid nvarchar(256),
@IsActive int
AS

SELECT COUNT(*) FROM [dbo].[cont_Catologies]
where 
	(ListPlacementGuid like '%'+@RootGuid+'%')
	and (@IsActive=-1 or IsActive=@IsActive)
	
	
	--exec [cont_Catologies_ngocnv10052014_GetCount_2para] '0c7874c2-5221-4753-a533-ba5069b1d37a',1
GO
/****** Object:  StoredProcedure [dbo].[cont_Catologies_ngocnv10052014_GetCount]    Script Date: 12/31/2014 14:07:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cont_Catologies_ngocnv10052014_GetCount]

/*
Author:   			tsandtm
Created: 			2014-3-11
Last Modified: 		2014-3-11
*/
-- WITH ENCRYPTION
AS

SELECT COUNT(*) FROM [dbo].[cont_Catologies]
GO
/****** Object:  StoredProcedure [dbo].[cont_Catologies_ngocnv10052014_GetAllDanhMuc_TheoDanhMucCha]    Script Date: 12/31/2014 14:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cont_Catologies_ngocnv10052014_GetAllDanhMuc_TheoDanhMucCha]

/*
Author:   			tsandtm
Created: 			2013-11-26
Last Modified: 		2013-11-26
*/
-- WITH ENCRYPTION
@GuidDanhMucCha uniqueidentifier,
@IsActive int
AS


SELECT
		CatologyGuid,
		[CatologyID],
		[CatologyName],
		[Description],
		[KindCatologyGuid],
		[KindCatologyName],
		IsActive,
		URLHinhAnh
		
FROM
		[dbo].cont_Catologies
WHERE	
	[KindCatologyGuid]=@GuidDanhMucCha
	AND (@IsActive=-1 or IsActive=@IsActive)
ORDER BY [CatologyName]
GO
/****** Object:  StoredProcedure [dbo].[cont_Catologies_ngocnv10052014_GetAllCatologies]    Script Date: 12/31/2014 14:07:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cont_Catologies_ngocnv10052014_GetAllCatologies]

/*
Author:   			tsandtm
Created: 			2014-3-11
Last Modified: 		2014-3-11
*/
-- WITH ENCRYPTION
@ValueGuid uniqueidentifier,
@Active int
AS

SELECT * FROM [dbo].[cont_Catologies]
where 
	(CatologyGuid=@ValueGuid or ListPlacementGuid like '%'+ convert(nvarchar(256), @ValueGuid)+'%')
	and (@Active=-1 or IsActive=@Active)
order by ListStringToSort
GO
/****** Object:  StoredProcedure [dbo].[cont_Catologies_ngocnv10052014_Delete_ByLoaiDanhMucGuid]    Script Date: 12/31/2014 14:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cont_Catologies_ngocnv10052014_Delete_ByLoaiDanhMucGuid]

/*
Author:   			tsandtm
Created: 			2013-11-26
Last Modified: 		2013-11-26
*/

@KindCatologyGuid uniqueidentifier
-- WITH ENCRYPTION
AS

DELETE FROM [dbo].cont_Catologies
WHERE
	KindCatologyGuid = @KindCatologyGuid
GO
/****** Object:  StoredProcedure [dbo].[cont_Catologies_ngocnv10052014_Delete]    Script Date: 12/31/2014 14:07:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[cont_Catologies_ngocnv10052014_Delete]

/*
Author:   			tsandtm
Created: 			2014-3-11
Last Modified: 		2014-3-11
*/

@CatologyGuid uniqueidentifier
-- WITH ENCRYPTION
AS

DELETE FROM [dbo].[cont_Catologies]
WHERE
	[CatologyGuid] = @CatologyGuid or ListPlacementGuid like '%'+convert(nvarchar(256), @CatologyGuid)+'%'
GO
