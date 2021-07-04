using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(30, ErrorMessage = "Fullname lenght is more 30 symbols")]
        public string Name { get; set; }
        [StringLength(30, ErrorMessage = "Phone lenght is more 30 symbols")]
        public string Phone { get; set; }
    }
}