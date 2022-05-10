CREATE TABLE Evaluations (
    evaluationId INT NOT NULL,
	userId INT NOT NULL,
	oilId INT NOT NULL,
	typeOfSession INT NOT NULL,
	inflamed FLOAT NOT NULL,
	moldy FLOAT NOT NULL,
	sour FLOAT NOT NULL,
	frosted FLOAT NOT NULL,
	burned FLOAT NOT NULL,
	fruitiness FLOAT NOT NULL,
	spicy FLOAT NOT NULL,
	bitter FLOAT NOT NULL
	
	CONSTRAINT PK_Evaluations
	PRIMARY KEY NONCLUSTERED (userId, oilId),

	CONSTRAINT FK_Users
		FOREIGN KEY (userId)
		REFERENCES Users (userId),
	
	CONSTRAINT FK_Oils
		FOREIGN KEY (oilId)
		REFERENCES Oils (oilId)
)