using Microsoft.EntityFrameworkCore;
using TodoAppEFCore.Data;
using TodoAppEFCore.Model;

namespace TodoAppEFCore.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;
        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<Todo> AddTodo(Todo todo)
        {
            todo.CreatedDate = DateTime.Now;
            var result = _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return result.Entity;

        }

        public async Task DeleteMultipleTodos(List<int> ids)
        {
            var todosToDelete = await _context.Todos.Where(x => ids.Contains(x.Id)).ToListAsync();
            _context.Todos.RemoveRange(todosToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Todo> DeleteTodoById(int id)
        {
            var todo = _context.Todos.Find(id);
            var removedTodo = _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return removedTodo.Entity;

        }

        public async Task EditTodo(Todo todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Todo>> SearchTodo(string word)
        {
            var todo = await _context.Todos.Where(x => x.Content.ToLower().Contains(word.ToLower())).ToListAsync();
            return todo;
        }

        public async Task<List<Todo>> SearchTodoByDate(DateTime date)
        {
            var todo = await _context.Todos.Where(x => x.CreatedDate.Date == date.Date).ToListAsync();
            return todo;
        }

        public async Task<Todo> GetTodoById(int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            return todo;
        }

        public async Task<List<Todo>> GetTodos()
        {
            return await _context.Todos.ToListAsync();
        }
    }
}
