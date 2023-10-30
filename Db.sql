CREATE TABLE ScheduledEvents(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Title VARCHAR(255),
	[Location] VARCHAR(255),
	[Description] VARCHAR(500),
	StartDate DATETIME,
	EndDate DATETIME 
);
