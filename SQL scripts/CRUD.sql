SELECT * FROM Users
UPDATE Users
SET typeOfUser = 1
WHERE name = 'Preston Fuzzens'


SELECT fullName
FROM Oils
WHERE codeName = 'Cyzone'


SELECT * FROM Evaluations
UPDATE Evaluations
SET typeOfSession = 0
WHERE userId = 20;


SELECT * FROM Evaluations
DELETE FROM Evaluations WHERE typeOfSession = 1

DROP TABLE Evaluations