namespace PacManager.WebApi.Services.Students.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StudentNumber { get; set; }

        public Student(string name, string surname, string studentNumber)
        {
            Name = name;
            Surname = surname;
            StudentNumber = studentNumber;
        }
    }
}
