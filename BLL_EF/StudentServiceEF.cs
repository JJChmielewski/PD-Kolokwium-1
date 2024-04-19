using BLL;
using BLL.DTO;
using DAL;
using PD_Kolokwium_1.Models;

namespace BLL_EF
{
    public class StudentServiceEF : StudentService
    {

        StudentContext context = new StudentContext();

        public void addStudent(StudentDTO student)
        {
            Student studentModel = new Student();
            studentModel.Id = context.students.Count() + 1;
            studentModel.Name = student.Name;
            studentModel.Surname = student.Surname;
            studentModel.GroupId = student.GroupId;

            context.students.Add(studentModel);

            History history = new History();
            history.Id = context.history.Count() + 1;
            history.Name = student.Name;
            history.Surname = student.Surname;
            history.GroupId = student.GroupId;
            history.HistoryAction = HistoryAction.Add;
            history.Date = DateTime.Now;

            context.history.Add(history);

            context.SaveChanges();
        }

        public void deleteStudent(int id)
        {
            Student? student = context.students.Where(s => s.Id == id).First();

            if (student == null)
            {
                return;
            }

            History history = new History();
            history.Id = context.history.Count() + 1;
            history.Name = student.Name;
            history.Surname = student.Surname;
            history.GroupId = student.GroupId;
            history.HistoryAction = HistoryAction.Delete;
            history.Date = DateTime.Now;

            context.history.Add(history);
            context.students.Remove(student);

            context.SaveChanges();
        }

        public List<StudentDTO> getAllStudents()
        {
            List<Student> students = context.students.ToList();
            List<StudentDTO> studentDTOs = new List<StudentDTO>();

            foreach (Student student in students)
            {
                StudentDTO temp = new StudentDTO();
                temp.Id= student.Id;
                temp.Name = student.Name;
                temp.Surname = student.Surname;
                temp.GroupId = student.GroupId;
                studentDTOs.Add(temp);
            }

            return studentDTOs;
        }

        public StudentDTO? getStudentById(int id)
        {
            Student? student = context.students.Where(s => s.Id == id).First();
            if (student == null)
            {
                return null;
            }

            StudentDTO temp = new StudentDTO();
            temp.Id = student.Id;
            temp.Name = student.Name;
            temp.Surname = student.Surname;
            temp.GroupId = student.GroupId;
            return temp;
        }

        public void updateStudent(StudentDTO student)
        {
            Student studentModel = context.students.Where(s => s.Id == student.Id).First();
            if (studentModel == null)
            {
                return;
            }
            studentModel.Name = student.Name;
            studentModel.Surname = student.Surname;
            studentModel.GroupId = student.GroupId;

            History history = new History();
            history.Id = context.history.Count() + 1;
            history.Name = student.Name;
            history.Surname = student.Surname;
            history.GroupId = student.GroupId;
            history.HistoryAction = HistoryAction.Edit;
            history.Date = DateTime.Now;

            context.history.Add(history);

            context.SaveChanges();
        }
    }
}
