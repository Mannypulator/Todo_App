using TodoAppEFCore.Model;

namespace TodoAppEFCore.Repository
{
    public interface ITodoRepository
    {
        Task<Todo> AddTodo(Todo todo);
        Task<Todo> DeleteTodoById(int id);
        Task<List<Todo>> GetTodos();
        Task<Todo> GetTodoById(int id);
        Task EditTodo(Todo todo);
        Task<List<Todo>> SearchTodo(string word);
        Task<List<Todo>> SearchTodoByDate(DateTime date);
        Task DeleteMultipleTodos(List<int> ids);
    }
}
