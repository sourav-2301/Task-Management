using System.ComponentModel.DataAnnotations;

namespace Task_Management.Models
{
    public class User
    {
        [Key]
        public int  UserId { get; set; }
       
        [MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string Role { get; set; }
    }
}
