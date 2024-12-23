using System.ComponentModel.DataAnnotations;

namespace Task_Management.Models
{
    public class Status
    {
        [Key]
        public int SID { get; set; }

        public string  status { get; set; }
    }
}
