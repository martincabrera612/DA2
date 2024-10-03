namespace PacManager.WebApi.Services.Quizzes.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }

        public Quiz(string name, float value)
        {
            Name = name;
            Value = value;
        }
    }
}
