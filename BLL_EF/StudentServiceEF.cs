using BLL;
using BLL.DTO;
using DAL;
using DAL.Models;

namespace BLL_EF
{
    public class StudentServiceEF : StudentService
    {

        StudentContext context = new StudentContext();

        public void addStudent(StudentDTO student)
        {
            Student studentModel = new Student();
            studentModel.Name = student.Name;
            studentModel.Surname = student.Surname;
            studentModel.GroupId = student.GroupId;

            context.students.Add(studentModel);

            History history = new History();
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

        public List<HistoryDTO> getHistory(int pageNumber, int pageSize)
        {
            int startingIndex = (pageNumber - 1) * pageSize;
            int endingIndex = startingIndex + pageSize;
            List<HistoryDTO> historyDTOs = new List<HistoryDTO>();

            for (; startingIndex < context.history.Count() && startingIndex < endingIndex; startingIndex++)
            {
                HistoryDTO temp = new HistoryDTO();
                History? history = context.history.ElementAt(startingIndex);
                if (history == null) {
                    break;
                }

                temp.Id = history.Id;
                temp.Name = history.Name;
                temp.Surname = history.Surname;
                temp.HistoryAction = history.HistoryAction.ToString();
                if (history.GroupId != null)
                {
                    context.Entry(history).Reference(h => h.Group).Load();
                    temp.GroupName = history.Group.Name;
                }
                
                temp.Date = history.Date;
                historyDTOs.Add(temp);
            }

            return historyDTOs;
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
