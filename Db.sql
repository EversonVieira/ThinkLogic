CREATE TABLE ScheduledEvents(
	Id INT PRIMARY KEY,
	Title VARCHAR(255),
	[Location] VARCHAR(255),
	[Description] VARCHAR(500),
	StartDate DATETIME,
	EndDate DATETIME 
);