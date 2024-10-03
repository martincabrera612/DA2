namespace PacManager.WebApi.Services.Grades.Entities
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int QuizId { get; set; }
        public float Value { get; set; }

        public Grade(int studentId, int quizId, float value)
        {
            StudentId = studentId;
            QuizId = quizId;
            Value = value;
        }
    }
}
