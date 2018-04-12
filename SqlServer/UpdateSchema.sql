
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO
    
    
      -- TABLE: Assignment
      -- TABLE: Course

      -- CREATE DATABASE
      IF NOT EXISTS (SELECT * from sys.databases WHERE name = 'HomeworkPlus')
      BEGIN
          CREATE DATABASE [HomeworkPlus];
      END
        GO
        
     USE [HomeworkPlus];
GO
      
        -- TABLE: Assignment
        -- ****** Object:  Table [dbo].[Assignment]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Assignment]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Assignment] (
          [AssignmentId] NVARCHAR(100) NOT NULL
          -- TEXT.
        ,
          [Course] NVARCHAR(100) NULL
          -- TEXT.
        ,
          [DueDate] DATE NULL
          -- xs:date.
        ,
          [IsComplete] BIT NULL
          -- BOOLEAN.
        ,
          [Notes] NVARCHAR(100) NULL
          -- TEXT.
        ,
          [Name] NVARCHAR(100) NULL
          -- TEXT.
        ,
          [createdTime] DATETIME NULL
          -- DATETIME.
        ,
        
        CONSTRAINT [PK_Assignment] PRIMARY KEY CLUSTERED
          (
            [AssignmentId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO

        -- TABLE: Course
        -- ****** Object:  Table [dbo].[Course]   Script Date:  ******
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Course]') AND type in (N'U')) 
        BEGIN
        CREATE TABLE [dbo].[Course] (
          [CourseId] NVARCHAR(100) NOT NULL
          -- TEXT.
        ,
          [Name] NVARCHAR(100) NULL
          -- TEXT.
        ,
          [Notes] NVARCHAR(100) NULL
          -- TEXT.
        ,
          [When] NVARCHAR(100) NULL
          -- TEXT.
        ,
          [createdTime] DATETIME NULL
          -- DATETIME.
        ,
        
        CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED
          (
            [CourseId] ASC
          )
        
        ) ON [PRIMARY]
        END
        GO


      
DECLARE @ObjectName NVARCHAR(100)

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'AssignmentId' AND Object_ID = Object_ID(N'Assignment'))
    BEGIN
            ALTER TABLE [dbo].[Assignment] ADD [AssignmentId] NVARCHAR(100) NULL;
    END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Course' AND Object_ID = Object_ID(N'Assignment'))
    BEGIN
            ALTER TABLE [dbo].[Assignment] ADD [Course] NVARCHAR(100) NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Assignment] ALTER COLUMN [Course] NVARCHAR(100) NULL;

    

	END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'DueDate' AND Object_ID = Object_ID(N'Assignment'))
    BEGIN
            ALTER TABLE [dbo].[Assignment] ADD [DueDate] DATE NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Assignment] ALTER COLUMN [DueDate] DATE NULL;

    

	END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'IsComplete' AND Object_ID = Object_ID(N'Assignment'))
    BEGIN
            ALTER TABLE [dbo].[Assignment] ADD [IsComplete] BIT NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Assignment] ALTER COLUMN [IsComplete] BIT NULL;

    

	END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Notes' AND Object_ID = Object_ID(N'Assignment'))
    BEGIN
            ALTER TABLE [dbo].[Assignment] ADD [Notes] NVARCHAR(100) NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Assignment] ALTER COLUMN [Notes] NVARCHAR(100) NULL;

    

	END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Assignment'))
    BEGIN
            ALTER TABLE [dbo].[Assignment] ADD [Name] NVARCHAR(100) NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Assignment] ALTER COLUMN [Name] NVARCHAR(100) NULL;

    

	END

    
    -- COUNT: 7
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'createdTime' AND Object_ID = Object_ID(N'Assignment'))
    BEGIN
            ALTER TABLE [dbo].[Assignment] ADD [createdTime] DATETIME NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Assignment] ALTER COLUMN [createdTime] DATETIME NULL;

    

	END

    
    -- COUNT: 6
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CourseId' AND Object_ID = Object_ID(N'Course'))
    BEGIN
            ALTER TABLE [dbo].[Course] ADD [CourseId] NVARCHAR(100) NULL;
    END

    
    -- COUNT: 6
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Name' AND Object_ID = Object_ID(N'Course'))
    BEGIN
            ALTER TABLE [dbo].[Course] ADD [Name] NVARCHAR(100) NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Course] ALTER COLUMN [Name] NVARCHAR(100) NULL;

    

	END

    
    -- COUNT: 6
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'Notes' AND Object_ID = Object_ID(N'Course'))
    BEGIN
            ALTER TABLE [dbo].[Course] ADD [Notes] NVARCHAR(100) NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Course] ALTER COLUMN [Notes] NVARCHAR(100) NULL;

    

	END

    
    -- COUNT: 6
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'When' AND Object_ID = Object_ID(N'Course'))
    BEGIN
            ALTER TABLE [dbo].[Course] ADD [When] NVARCHAR(100) NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Course] ALTER COLUMN [When] NVARCHAR(100) NULL;

    

	END

    
    -- COUNT: 6
    IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'createdTime' AND Object_ID = Object_ID(N'Course'))
    BEGIN
            ALTER TABLE [dbo].[Course] ADD [createdTime] DATETIME NULL;
    END

    
    ELSE
    BEGIN 


        ALTER TABLE [dbo].[Course] ALTER COLUMN [createdTime] DATETIME NULL;

    

	END

    

              -- ****** KEYS FOR Table [dbo].[Assignment]
          -- FK for Course :: 0 :: Assignment :: Course
          IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Assignment_Course]') AND parent_object_id = OBJECT_ID(N'[dbo].[Assignment]'))
              IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Assignment_Course]') AND parent_object_id = OBJECT_ID(N'[dbo].[Assignment]'))
                ALTER TABLE [dbo].[Assignment]  WITH CHECK ADD  CONSTRAINT [FK_Assignment_Course] FOREIGN KEY([Course])
                    REFERENCES [dbo].[Course] (CourseId)
                GO

          IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Assignment_Course]') AND parent_object_id = OBJECT_ID(N'[dbo].[Assignment]'))
            ALTER TABLE [dbo].[Assignment] CHECK CONSTRAINT [FK_Assignment_Course]
            GO
          

              -- ****** KEYS FOR Table [dbo].[Course]


            SELECT 'Successful' as Value
            FROM (SELECT NULL AS FIELD) as Result
            FOR XML AUTO

          