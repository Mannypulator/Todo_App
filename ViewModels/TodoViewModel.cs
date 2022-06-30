namespace TodoAppEFCore.ViewModels
{
    public class TodoViewModel
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Check { get; set; }
    }
}
