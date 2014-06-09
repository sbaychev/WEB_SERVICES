USE [SOA]
GO

/****** Object:  Table [dbo].[author]    Script Date: 06/16/2013 14:41:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[author](
	[author_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](64) NULL,
	[last_name] [nvarchar](64) NOT NULL,
	[born_date] [date] NULL,
	[death_date] [date] NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [SOA]
GO

/****** Object:  Table [dbo].[book]    Script Date: 06/16/2013 14:41:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[book](
	[book_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](512) NOT NULL,
	[author_id] [int] NOT NULL,
	[type_id] [int] NOT NULL,
	[genre_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[isbn] [nvarchar](32) NOT NULL,
	[reserved] [int] NOT NULL,
	[year] [int] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Isbn] UNIQUE NONCLUSTERED 
(
	[isbn] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Author] FOREIGN KEY([author_id])
REFERENCES [dbo].[author] ([author_id])
GO

ALTER TABLE [dbo].[book] CHECK CONSTRAINT [FK_Book_Author]
GO

ALTER TABLE [dbo].[book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Genre] FOREIGN KEY([genre_id])
REFERENCES [dbo].[genre] ([genre_id])
GO

ALTER TABLE [dbo].[book] CHECK CONSTRAINT [FK_Book_Genre]
GO

ALTER TABLE [dbo].[book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Type] FOREIGN KEY([type_id])
REFERENCES [dbo].[type] ([type_id])
GO

ALTER TABLE [dbo].[book] CHECK CONSTRAINT [FK_Book_Type]
GO

ALTER TABLE [dbo].[book]  WITH CHECK ADD  CONSTRAINT [FK_Book_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO

ALTER TABLE [dbo].[book] CHECK CONSTRAINT [FK_Book_User]
GO

USE [SOA]
GO

/****** Object:  Table [dbo].[book_of_interest]    Script Date: 06/16/2013 14:41:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[book_of_interest](
	[book_of_interest_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nchar](512) NOT NULL,
	[author_name] [nchar](128) NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_book_of_interest] PRIMARY KEY CLUSTERED 
(
	[book_of_interest_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[book_of_interest]  WITH CHECK ADD  CONSTRAINT [FK_book_of_interest_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO

ALTER TABLE [dbo].[book_of_interest] CHECK CONSTRAINT [FK_book_of_interest_user]
GO

USE [SOA]
GO

/****** Object:  Table [dbo].[genre]    Script Date: 06/16/2013 14:41:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[genre](
	[genre_id] [int] IDENTITY(1,1) NOT NULL,
	[genre] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[genre_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Genre] UNIQUE NONCLUSTERED 
(
	[genre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [SOA]
GO

/****** Object:  Table [dbo].[location]    Script Date: 06/16/2013 14:41:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[location](
	[location_id] [int] IDENTITY(1,1) NOT NULL,
	[country] [nvarchar](128) NOT NULL,
	[city] [nvarchar](128) NOT NULL,
	[postcode] [nvarchar](50) NOT NULL,
	[address] [nvarchar](256) NULL,
 CONSTRAINT [PK_location] PRIMARY KEY CLUSTERED 
(
	[location_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [SOA]
GO

/****** Object:  Table [dbo].[type]    Script Date: 06/16/2013 14:41:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[type](
	[type_id] [int] IDENTITY(1,1) NOT NULL,
	[type] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Type_Name] UNIQUE NONCLUSTERED 
(
	[type] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [SOA]
GO

/****** Object:  Table [dbo].[users]    Script Date: 06/16/2013 14:41:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](64) NOT NULL,
	[password] [nvarchar](64) NOT NULL,
	[email] [nvarchar](64) NOT NULL,
	[location_id] [int] NOT NULL,
	[first_name] [nvarchar](64) NULL,
	[last_name] [nvarchar](64) NULL,
	[access_token] [nvarchar](64) NULL,
	[last_access_time] [datetime] NULL,
	[phone] [nvarchar](32) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Email] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_User_Name] UNIQUE NONCLUSTERED 
(
	[user_name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_User_Location] FOREIGN KEY([location_id])
REFERENCES [dbo].[location] ([location_id])
GO

ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_User_Location]
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[accuire_exclusive_lock]    Script Date: 06/16/2013 14:42:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[accuire_exclusive_lock] 
 			
AS
BEGIN
	DECLARE @res INT
    EXEC @res = sp_getapplock                 
                @Resource = 'Upsert_app_lock',
                @LockMode = 'Exclusive',
                @LockOwner = 'Transaction',
                @LockTimeout = 600000,
                @DbPrincipal = 'public'
END

GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[add_author]    Script Date: 06/16/2013 14:42:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[add_author]
	 
	 @first_name nvarchar(64),
	 @last_name nvarchar(64),
	 @born_date date,
	 @death_date date
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	INSERT INTO author(first_name, last_name, born_date, death_date) 
	VALUES (@first_name, @last_name, @born_date, @death_date); 
	
	SELECT @first_name as no_response;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[add_book]    Script Date: 06/16/2013 14:42:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[add_book]
	 
	 @title nvarchar(512),
	 @author_id int,
	 @type nvarchar(32),
	 @genre nvarchar(32),
	 @user_name nvarchar(64),
	 @isbn nvarchar(32),
	 @reserved int,
	 @year int

AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	DECLARE @type_id int;
	SET @type_id = (SELECT type_id from type where type = @type);
	DECLARE @genre_id int;
	SET @genre_id = (SELECT genre_id from genre where genre = @genre);
	DECLARE @user_id int;
	SET @user_id = (SELECT user_id from users where user_name = @user_name);

	INSERT INTO book(title, author_id, type_id, genre_id, user_id, isbn, reserved, year) 
	VALUES (@title, @author_id, @type_id, @genre_id, @user_id, @isbn, @reserved, @year); 
	
	SELECT @type_id as no_response;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[add_book_of_interest]    Script Date: 06/16/2013 14:42:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[add_book_of_interest]
	 
	 @title nvarchar(512),
	 @author_name nvarchar(128),
	 @user_name nvarchar(64)

AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	DECLARE @user_id int;
	SET @user_id = (SELECT user_id from users where user_name = @user_name);

	INSERT INTO book_of_interest(title, author_name, user_id) 
	VALUES (@title, @author_name, @user_id); 
	
	SELECT @user_id as no_response;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[add_type]    Script Date: 06/16/2013 14:42:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[add_type]
	 
	 @type_name nvarchar(32)
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	INSERT INTO type(type) VALUES (@type_name); 
END

GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[add_user]    Script Date: 06/16/2013 14:42:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[add_user]
  
  @user_name nvarchar (64),
  @password nvarchar (64),
  @email nvarchar(64),
  @first_name nvarchar(64),
  @last_name nvarchar(64),
  @phone nvarchar(64),

  @country nvarchar (128),
  @city nvarchar (128),
  @postcode nvarchar (50),
  @address nvarchar (256)
     
AS
BEGIN

 SET NOCOUNT ON;
 EXECUTE accuire_exclusive_lock;
 SET NOCOUNT OFF;
 SET NOCOUNT ON;

 INSERT INTO location(address,city,country,postcode)
 VALUES (@country, @city, @postcode, @address); 

 DECLARE @location_id int;
 SET @location_id = SCOPE_IDENTITY();

 INSERT INTO users(user_name,password,email,location_id,first_name,last_name, phone)
 VALUES (@user_name, @password, @email, @location_id, @first_name, @last_name, @phone) 

END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[check_book_of_interest]    Script Date: 06/16/2013 14:42:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[check_book_of_interest]

	 @book_of_interest_id int
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;	

	SELECT u.user_name, u.first_name, u.last_name, u.phone, u.email, l.country, l.city, l.address, l.postcode
	FROM book b join users u on b.user_id = u.user_id
				join location l on l.location_id = u.location_id
				join author a on a.author_id = b.author_id
	WHERE b.title = (SELECT title from book_of_interest WHERE book_of_interest_id = @book_of_interest_id) AND
		 (a.first_name + ' ' + a.last_name) = (SELECT author_name from book_of_interest WHERE book_of_interest_id = @book_of_interest_id);
	
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[check_user_authenticated]    Script Date: 06/16/2013 14:42:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[check_user_authenticated]
  
  @user_name nvarchar (64),
  @access_token nvarchar(64),
  @check_time datetime,
  @time_interval int
     
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	DECLARE @access_token_inner nvarchar(64);
	SET @access_token_inner = (SELECT access_token FROM users where user_name = @user_name);
	
	DECLARE @last_access_time datetime;
	SET @last_access_time = (SELECT last_access_time FROM users where user_name = @user_name);

	IF (@access_token_inner = @access_token)
	BEGIN
		IF (DATEDIFF(minute, @last_access_time, @check_time) < @time_interval)
		BEGIN
			UPDATE users
			SET last_access_time = @check_time
			WHERE user_name = @user_name;

			SELECT 1 as result;
		END
		ELSE
		BEGIN
			SELECT 0 as result;
		END
	END
	ELSE
	BEGIN
		SELECT 0 as result;
	END

END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[edit_book]    Script Date: 06/16/2013 14:43:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[edit_book]
	 
	 @book_id int,
	 @title nvarchar(512),
	 @author_id int,
	 @type nvarchar(32),
	 @genre nvarchar(32),
	 @isbn nvarchar(32),
	 @reserved int,
	 @year int

AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	DECLARE @type_id int;
	SET @type_id = (SELECT type_id from type where type = @type);
	DECLARE @genre_id int;
	SET @genre_id = (SELECT genre_id from genre where genre = @genre);

	UPDATE book
	SET title = @title,
		author_id = @author_id,
		type_id = @type_id,
		genre_id = @genre_id,
		isbn = @isbn, 
		reserved = @reserved, 
		year = @year
	WHERE book_id = @book_id; 
	
	SELECT @book_id as no_response;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_all_authors]    Script Date: 06/16/2013 14:43:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_all_authors]
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;	

	SELECT *
	FROM author;
END

GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_all_books]    Script Date: 06/16/2013 14:43:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_all_books]
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;	

	SELECT book_id, title, author_id, t.type, g.genre, user_id, isbn, reserved, year
	FROM book b join genre g on b.genre_id = g.genre_id
				join type t on b.type_id = t.type_id
	WHERE b.reserved = 0;
END

GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_all_books_by_author]    Script Date: 06/16/2013 14:43:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_all_books_by_author]
	 
	 @name nvarchar(512)
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;	

	SELECT book_id, title, b.author_id, t.type, g.genre, user_id, isbn, reserved, year
	FROM book b join genre g on b.genre_id = g.genre_id
				join type t on b.type_id = t.type_id
				join author a ON b.author_id = a.author_id
	WHERE ((a.first_name) LIKE ('%' + @name + '%') OR
	(a.last_name) LIKE ('%' + @name + '%') OR
	(a.first_name + ' ' + a.last_name) LIKE ('%' + @name + '%'))
	AND b.reserved = 0;
END

GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_all_books_by_genre]    Script Date: 06/16/2013 14:43:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_all_books_by_genre]
	 
	 @genre nvarchar(32)
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;	

	SELECT book_id, title, author_id, t.type, g.genre, user_id, isbn, reserved, year
	FROM book b join genre g on b.genre_id = g.genre_id
				join type t on b.type_id = t.type_id
	WHERE genre = @genre AND b.reserved = 0;
END

GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_all_books_by_title]    Script Date: 06/16/2013 14:43:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_all_books_by_title]
	 
	 @title nvarchar(512)
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;	

	SELECT book_id, title, author_id, t.type, g.genre, user_id, isbn, reserved, year
	FROM book b join genre g on b.genre_id = g.genre_id
				join type t on b.type_id = t.type_id
	WHERE title LIKE '%' + @title + '%' AND b.reserved = 0;
END

GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_all_books_by_type]    Script Date: 06/16/2013 14:43:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_all_books_by_type]
	 
	 @type nvarchar(32)
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;	

	SELECT book_id, title, author_id, t.type, g.genre, user_id, isbn, reserved, year
	FROM book b join genre g on b.genre_id = g.genre_id
				join type t on b.type_id = t.type_id
	WHERE type = @type AND b.reserved = 0;
END

GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_all_books_by_user]    Script Date: 06/16/2013 14:43:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_all_books_by_user]
	 
	 @user_name nvarchar(64)
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;	

	SELECT book_id, title, b.author_id, t.type, g.genre, b.user_id, isbn, reserved, year
	FROM book b join genre g on b.genre_id = g.genre_id
				join type t on b.type_id = t.type_id
				join users u on b.user_id = u.user_id
	WHERE u.user_name = @user_name;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_all_books_by_year]    Script Date: 06/16/2013 14:44:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_all_books_by_year]
	 
	 @year int
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;	

	SELECT book_id, title, author_id, t.type, g.genre, user_id, isbn, reserved, year
	FROM book b join genre g on b.genre_id = g.genre_id
				join type t on b.type_id = t.type_id
	WHERE year = @year AND b.reserved = 0;
END

GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_all_books_of_interest]    Script Date: 06/16/2013 14:44:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_all_books_of_interest]
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;	

	SELECT book_of_interest_id, title, author_name, user_id
	FROM book_of_interest;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_all_books_of_interest_by_user]    Script Date: 06/16/2013 14:44:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_all_books_of_interest_by_user]
	 
	 @user_name nvarchar(64)
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;	

	DECLARE @user_id int;
	SET @user_id = (SELECT user_id from users where user_name = @user_name);

	SELECT book_of_interest_id, title, author_name, user_name, first_name, last_name,
	phone, email, country, city, postcode, address
	FROM book_of_interest b 
	join users u ON u.user_id = b.user_id
	join location l ON u.location_id = l.location_id
	WHERE b.user_id = @user_id;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_all_genres]    Script Date: 06/16/2013 14:44:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_all_genres]
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;	

	SELECT genre
	FROM genre;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_all_types]    Script Date: 06/16/2013 14:44:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_all_types]
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;	

	SELECT type
	FROM type;
END

GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_author_by_id]    Script Date: 06/16/2013 14:44:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_author_by_id]

	@author_id int
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	SELECT *
	FROM author
	WHERE author_id = @author_id;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_book_by_id]    Script Date: 06/16/2013 14:44:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_book_by_id]

	@book_id int
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	SELECT book_id, title, author_id, t.type, g.genre, user_id, isbn, reserved, year
	FROM book b join genre g on b.genre_id = g.genre_id
				join type t on b.type_id = t.type_id
	WHERE book_id = @book_id;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_genre_id_by_name]    Script Date: 06/16/2013 14:44:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_genre_id_by_name]

	@genre_name nvarchar(32)
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	SELECT genre_id
	FROM genre
	WHERE genre = @genre_name;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_genre_name_by_id]    Script Date: 06/16/2013 14:44:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_genre_name_by_id]

	@genre_id int
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	SELECT genre
	FROM genre
	WHERE genre_id = @genre_id;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_location_by_id]    Script Date: 06/16/2013 14:45:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_location_by_id]

	@location_id int
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	SELECT country, city, postcode, address
	FROM location
	WHERE location_id = @location_id;
END

GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_type_id_by_name]    Script Date: 06/16/2013 14:45:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_type_id_by_name]

	@type_name nvarchar(32)
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	SELECT type_id
	FROM type
	WHERE type = @type_name;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_type_name_by_id]    Script Date: 06/16/2013 14:45:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_type_name_by_id]

	@type_name int
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	SELECT type
	FROM type
	WHERE type_id = @type_name;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_user_by_id]    Script Date: 06/16/2013 14:45:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_user_by_id]

	@user_id int
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	SELECT user_name, first_name, last_name, location_id, phone, email
	FROM users
	WHERE user_id = @user_id;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[get_user_by_user_name]    Script Date: 06/16/2013 14:45:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[get_user_by_user_name]

	@user_name nvarchar(64)
	 
AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	SELECT user_name, first_name, last_name, location_id, phone, email
	FROM users
	WHERE user_name = @user_name;
END
GO

USE [SOA]
GO

/****** Object:  StoredProcedure [dbo].[set_book_reserved_state]    Script Date: 06/16/2013 14:45:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[set_book_reserved_state]
	 
	 @book_id int,
	 @reserved int

AS
BEGIN

	SET NOCOUNT ON;
	EXECUTE accuire_exclusive_lock;
	SET NOCOUNT OFF;
	SET NOCOUNT ON;

	UPDATE book
	SET reserved = @reserved
	WHERE book_id = @book_id; 
	
	SELECT @book_id as no_response;
END
GO
INSERT INTO type(type) VALUES ('book')
INSERT INTO type(type) VALUES ('magazine')
INSERT INTO type(type) VALUES ('newspaper')

INSERT INTO genre(genre) VALUES ('Action')
INSERT INTO genre(genre) VALUES ('Biography')
INSERT INTO genre(genre) VALUES ('Essay')
INSERT INTO genre(genre) VALUES ('Fable')
INSERT INTO genre(genre) VALUES ('Fantasy')
INSERT INTO genre(genre) VALUES ('General')
INSERT INTO genre(genre) VALUES ('Historical')
INSERT INTO genre(genre) VALUES ('Horror')
INSERT INTO genre(genre) VALUES ('Humor')
INSERT INTO genre(genre) VALUES ('Kids')
INSERT INTO genre(genre) VALUES ('Manga')
INSERT INTO genre(genre) VALUES ('Mystery')
INSERT INTO genre(genre) VALUES ('Mythology')
INSERT INTO genre(genre) VALUES ('Romance')
INSERT INTO genre(genre) VALUES ('Thriller')
