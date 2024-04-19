using BLL;
using BLL.DTO;
using DAL.Models;
using Microsoft.Data.SqlClient;

namespace BLL_DB
{
    public class StudentServiceDB : StudentService
    {
        public void addStudent(StudentDTO student)
        {
            executeSql(String.Format("exec dbo.AddStudent {0}, {1}, {2}", student.Name, student.Surname, student.GroupId == null ? "null" : student.GroupId));
        }

        public void deleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public List<StudentDTO> getAllStudents()
        {
            throw new NotImplementedException();
        }

        public List<HistoryDTO> getHistory(int pageNumber, int pageSize)
        {
            string historyRaw = executeSql(String.Format("exec dbo.ShowHistory {0}, {1}", pageNumber, pageSize));
            string[] historyRows = historyRaw.Split("\n");
            List<HistoryDTO> historyDTOs = new List<HistoryDTO>();
            foreach(string row in historyRows)
            {
                if (string.IsNullOrEmpty(row))
                {
                    break;
                }

                string[] rowSplit = row.Split(";");
                HistoryDTO temp = new HistoryDTO();
                temp.Id = Int32.Parse(rowSplit[0]);
                temp.Name = rowSplit[1];
                temp.Surname = rowSplit[2];
                temp.GroupName = rowSplit[3];
                HistoryAction action = (HistoryAction)2;
                temp.HistoryAction = ((HistoryAction)Int32.Parse(rowSplit[4])).ToString();
                temp.Date = DateTime.Parse(rowSplit[5]);

                historyDTOs.Add(temp);
            }

            return historyDTOs;
        }

        public StudentDTO getStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public void updateStudent(StudentDTO student)
        {
            throw new NotImplementedException();
        }

        private string executeSql(string sql)
        {
            string output = "";
            using (SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Student;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            output += reader[i] + ";";
                        }
                        output += '\n';
                    }
                }
            }
            return output;
        }
    }
}
