create database db_news;

create table [user] (
	id int not null identity(1, 1),
	username nvarchar (16) not null unique,
	password nvarchar (128) not null,
	nickname nvarchar (16) not null,
	type int not null,
	primary key (id)
);

create table category (
	id int not null identity(1, 1),
	name nvarchar (16) unique,
	primary key (id)
);

create table news (
	id int not null identity(1, 1),
	userId int,
	categoryId int,
	title nvarchar (64),
	summary nvarchar (128),
	content text,
	[date] datetime,
	foreign key (userId) references [user] (id),
	foreign key (categoryId) references category (id),
	primary key (id)
);

create table comment (
	id int not null identity(1, 1),
	userId int,
	newsId int,
	[status] int,
	content text,
	[date] datetime,
	foreign key (userId) references [user] (id),
	foreign key (newsId) references news (id),
	primary key (id)
);
