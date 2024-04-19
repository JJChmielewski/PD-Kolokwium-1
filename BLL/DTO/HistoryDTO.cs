using PD_Kolokwium_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class HistoryDTO
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string GroupName { get; set; }

        public HistoryAction HistoryAction { get; set; }

        public DateTime Date { get; set; }
    }
}
