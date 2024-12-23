using System.ComponentModel.DataAnnotations;

namespace Task_Management.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [MaxLength(100)]
        public String Address { get; set; }
    }
}
