CREATE PROCEDURE ShowHistory
    @PageNumber INT,
    @PageSize INT
AS
declare @Start int = (@PageNumber - 1) * @PageSize
BEGIN
    Select history.Id, history.Name, Surname, g.Name, HistoryAction, Date from history inner join groups g on g.Id = GroupId order by history.Id offset @Start ROWS FETCH NEXT @PageSize ROWS ONLY;
END