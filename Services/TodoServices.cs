using AutoMapper;
using TodoAppEFCore.Model;
using TodoAppEFCore.Repository;
using TodoAppEFCore.ViewModels;

namespace TodoAppEFCore.Services
{
    public class TodoServices : ITodoServices
    {
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;
        public TodoServices(ITodoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddTodo(TodoViewModel todo)
        {
            var todoToAdd = _mapper.Map<Todo>(todo);
            await _repository.AddTodo(todoToAdd);
        }

        public async Task DeleteMultipleTodos(List<int> ids)
        {
            await _repository.DeleteMultipleTodos(ids);
        }

        public async Task<TodoViewModel> DeleteTodoById(int id)
        {
            var todo = await _repository.DeleteTodoById(id);
            return _mapper.Map<TodoViewModel>(todo);
        }

        public async Task EditTodo(TodoViewModel todo)
        {
            var todoToEdit = _mapper.Map<Todo>(todo);
            await _repository.EditTodo(todoToEdit);
        }

        public async Task<TodoViewModel> GetTodoById(int id)
        {
            var todo = await _repository.GetTodoById(id);
            return _mapper.Map<TodoViewModel>(todo);
        }
        public async Task<List<TodoViewModel>> GetTodos()
        {
            var todos = await _repository.GetTodos();
            return _mapper.Map<List<TodoViewModel>>(todos);
        }

        public async Task<List<TodoViewModel>> SearchTodo(string search)
        {
            var todos = await _repository.SearchTodo(search);
            return _mapper.Map<List<TodoViewModel>>(todos);
        }

        public async Task<List<TodoViewModel>> SearchTodosByDate(DateTime date)
        {
            var todos = await _repository.SearchTodoByDate(date);
            return _mapper.Map<List<TodoViewModel>>(todos);
        }
    }
}
