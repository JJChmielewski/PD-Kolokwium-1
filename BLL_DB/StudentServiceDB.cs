using BLL;
using BLL.DTO;
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
            throw new NotImplementedException();
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
