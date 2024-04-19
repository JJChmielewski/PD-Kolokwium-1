CREATE PROCEDURE AddStudent
    @Name NVARCHAR(100),
    @Surname NVARCHAR(100),
    @GroupId INT
AS
BEGIN
    INSERT INTO students(Name, Surname, GroupId) VALUES (@Name, @Surname, @GroupId); 
    INSERT INTO history(Name, Surname, GroupId, HistoryAction, Date) VALUES (@Name, @Surname, @GroupId, 2, CURRENT_TIMESTAMP)
END