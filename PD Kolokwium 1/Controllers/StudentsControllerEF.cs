using BLL.DTO;
using BLL_EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BazyDanych.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsControllerEF : ControllerBase
    {

        private StudentServiceEF service = new StudentServiceEF();

        [HttpGet]
        public List<StudentDTO> getStudents()
        {
            return service.getAllStudents();
        }

        [HttpGet("{id}", Name = "StudentId")]
        public StudentDTO? getStudentById([FromRoute] int id)
        {
            return service.getStudentById(id);
        }

        [HttpPost]
        public void addStudent([FromBody] StudentDTO student)
        {
            service.addStudent(student);
        }

        [HttpDelete]
        public void deleteStudent(int id)
        {
            service.deleteStudent(id);
        }

        [HttpPut]
        public void updateStudent([FromBody] StudentDTO student)
        {
            service.updateStudent(student);
        }

        [HttpGet]
        [Route("/history")]
        public List<HistoryDTO> showHistory([FromQuery]int page,[FromQuery] int  pageSize)
        {
            return service.getHistory(page, pageSize);
        }
    }
}
