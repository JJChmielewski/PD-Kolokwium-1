using System.ComponentModel.DataAnnotations;

namespace PD_Kolokwium_1.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
