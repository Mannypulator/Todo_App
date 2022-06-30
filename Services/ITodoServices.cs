using TodoAppEFCore.ViewModels;

namespace TodoAppEFCore.Services
{
    public interface ITodoServices
    {
        Task AddTodo(TodoViewModel todo);
        Task<TodoViewModel> DeleteTodoById(int id);
        Task<List<TodoViewModel>> GetTodos();
        Task<TodoViewModel> GetTodoById(int id);
        Task EditTodo(TodoViewModel todo);

        Task<List<TodoViewModel>> SearchTodo(string search);
        Task<List<TodoViewModel>> SearchTodosByDate(DateTime date);
        Task DeleteMultipleTodos(List<int> ids);


    }
}
