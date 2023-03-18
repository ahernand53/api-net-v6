using api_net_v6.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippets
{
    public class Services
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Student> Students { get; set; } = new List<Student>();
        public static List<Course> Courses { get; set; } = new List<Course>();

        static User FindUserByEmail(string email)
        {
            return Users.FirstOrDefault(user => user.Email == email);
        }

        static List<Student> GetAllStudentsAreAdults()
        {
            return Students.Where(student => ((DateTime.Now.Year - student.BirthDate.Year) >= 18)).ToList();
        }

        static List<Student> GetAllStudentWithAnyCourse()
        {
            return Students.Where(student => student.Courses.Any()).ToList();
        }

        static List<Course> GetAllCourseWithAlmostOneStudent(Level level)
        {
            return Courses
                .Where(course => course.Level == level)
                .Where(course => course.Studends.Any())
                .ToList();
        }

        static List<Course> GetAllCourseWithAlmostOneStudent(Category category)
        {
            return Courses
                .Where(course => course.Categories.Any(category => category.Name == category.Name))
                .ToList();
        }

        static List<Course> GetAllCourseWithoutStudents()
        {
            return Courses.SkipWhile(course => course.Studends.Any()).ToList();
        }







    }
}
