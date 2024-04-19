using System.ComponentModel.DataAnnotations;

namespace PD_Kolokwium_1.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int? GroupId { get; set; }

        public Group? Group { get; set; }

        public HistoryAction HistoryAction { get; set; }

        public DateTime Date { get; set; }
    }

    public enum HistoryAction
    {
        Delete, Edit
    }
}
