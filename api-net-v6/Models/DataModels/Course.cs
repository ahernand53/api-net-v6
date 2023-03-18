using System.ComponentModel.DataAnnotations;

namespace api_net_v6.Models.DataModels
{
    public class Course : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        public string LongDescription { get; set; } = string.Empty;

        public string TargetAudiences { get; set; } = string.Empty;

        public string Goals { get; set; } = string.Empty;

        public string Requirements { get; set; } = string.Empty;

        public Level Level { get; set; } = Level.Basic;

        [Required]
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        [Required]
        public IEnumerable<Student> Studends { get; set; } = new List<Student>();

        [Required]
        public Chapter Chapter { get; set; } = new Chapter();


    }

    public enum Level
    {
        Basic,
        Middle,
        Advanced,
        Expert
    }
}
