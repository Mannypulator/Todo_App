namespace TodoAppEFCore.Model
{
    public class Todo
    {
        public Todo()
        {

        }

        public Todo(string content)
        {
            Content = content;
        }
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
