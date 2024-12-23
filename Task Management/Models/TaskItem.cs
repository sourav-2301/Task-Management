using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Management.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength (100)]
        public string Description { get; set; }
        
        public  string  AssignmentEmployee { get; set; }

        public int statusId { get; set; }

        [NotMapped]
        public string Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }


    }
}
