using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoAppEFCore.Model;
using TodoAppEFCore.Repository;
using TodoAppEFCore.Services;
using TodoAppEFCore.ViewModels;

namespace TodoAppEFCore.Pages
{
    [BindProperties]
    public class EditTodoModel : PageModel
    {
        private readonly ITodoRepository _todoRepsoitory;
        private readonly IMapper _mapper;
        public TodoViewModel Todo { get; set; }
        public EditTodoModel(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepsoitory = todoRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var todo = await _todoRepsoitory.GetTodoById(id);
            Todo = _mapper.Map<TodoViewModel>(todo);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var todo = _mapper.Map<Todo>(Todo);
            await _todoRepsoitory.EditTodo(todo);
            return RedirectToPage("Index");
        }
    }
}
