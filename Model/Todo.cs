namespace TodoAppEFCore.Model
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
