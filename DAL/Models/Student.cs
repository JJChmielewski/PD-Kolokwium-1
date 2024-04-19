using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int? GroupId { get; set; }

        public Group? Group { get; set; }
    }
}
