using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface StudentService
    {

        public void addStudent(StudentDTO student);

        public void updateStudent(StudentDTO student);

        public void deleteStudent(int id);

        public List<StudentDTO> getAllStudents();

        public StudentDTO getStudentById(int id);

        public List<HistoryDTO> getHistory(int pageNumber, int pageSize);

    }
}
