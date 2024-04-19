CREATE or Alter TRIGGER AddHistoryOnEdit
ON students
for update
AS
BEGIN

    BEGIN
        insert into history(Name, Surname, GroupId, HistoryAction, Date)
		select s.Name, s.Surname, s.GroupId, 1, getdate() from inserted s
    END
END;