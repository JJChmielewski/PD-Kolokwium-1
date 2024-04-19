CREATE or Alter TRIGGER AddHistoryOnDelete
ON students
for DELETE
AS
BEGIN

    BEGIN
        insert into history(Name, Surname, GroupId, HistoryAction, Date)
		select s.Name, s.Surname, s.GroupId, 0, getdate() from inserted s
    END
END;