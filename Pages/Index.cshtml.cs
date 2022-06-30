using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoAppEFCore.Services;
using TodoAppEFCore.ViewModels;

namespace TodoAppEFCore.Pages
{
    [BindProperties(SupportsGet = true)]
    public class IndexModel : PageModel
    {
        private readonly ITodoServices _todoServices;
        public TodoViewModel Todo { get; set; }
        public string SearchTodo { get; set; }
        public IEnumerable<TodoViewModel> Todos { get; set; }
        public DateTime Date { get; set; } = DateTime.Now.Date;
        public IndexModel(ITodoServices todoServices)
        {
            _todoServices = todoServices;
        }

        public async Task<IActionResult> OnGet()
        {
            if (string.IsNullOrEmpty(SearchTodo))
            {
                Todos = await _todoServices.GetTodos();

            }
            else
            {
                Todos = await _todoServices.SearchTodo(SearchTodo);

            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddTodo()
        {
            if (!string.IsNullOrEmpty(Todo.Content))
                await _todoServices.AddTodo(Todo);
            Todo = new TodoViewModel();
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostDeleteTodo(int id)
        {
            await _todoServices.DeleteTodoById(id);
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostDeleteSelected()
        {
            var ids = new List<int>();
            foreach (var todo in Todos)
            {
                if (todo.Check)
                    ids.Add(todo.Id);
            }
            await _todoServices.DeleteMultipleTodos(ids);
            return RedirectToPage("Index");
        }



    }
}