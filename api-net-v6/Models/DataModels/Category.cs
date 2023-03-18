using System.ComponentModel.DataAnnotations;

namespace api_net_v6.Models.DataModels
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Course> Courses { get; set; } = new List<Course>();

    }
}
