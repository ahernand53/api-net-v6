using System.ComponentModel.DataAnnotations;

namespace api_net_v6.Models.DataModels
{
    public class Student : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public IEnumerable<Course> Courses { get; set; } = new List<Course>();


    }
}
