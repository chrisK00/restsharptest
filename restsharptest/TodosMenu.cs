using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace restsharptest
{
    public class TodosMenu
    {
        private readonly int amountOfOptions = 10;
        private readonly ITodosService _todosService;

        public TodosMenu(ITodosService todosService)
        {
            _todosService = todosService;
        }
        public async Task Run()
        {
            while (true)
            {
                WriteLine("Hello, what would you like to do today?:");
                WriteLine("1.Get Todo\n2.Print all completed Todos\n10. Exit");
                int input = Helpers.GetIntInput(amountOfOptions, 0, $"You have {amountOfOptions} options, choose wisely:");
                try
                {
                    switch (input)
                    {
                        case 1:
                            var todo = await GetTodoAsync();
                            WriteLine($"\n{todo}");
                            break;
                        case 2:
                            await PrintAllCompletedTodos();
                            break;
                        case 10:
                            return;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    WriteLine($"{e.Message}\n{e.StackTrace}");
                }
                Write("Press any key to continue...");
                ReadKey();
                Clear();
            }
        }

        private async Task PrintAllCompletedTodos()
        {
            var todos = await _todosService.GetCompletedTodosAsync();
            Helpers.PrintItems(todos);
        }

        private async Task<Todo> GetTodoAsync()
        {
            Write("Which todo would you like to fetch?: ");
            var todos = await _todosService.GetTodosAsync();
            Helpers.PrintItems(todos);

            while (true)
            {
                var todoId = Helpers.GetIntInput();
                if (todos.Any(t => t.Id == todoId))
                {
                    return todos.FirstOrDefault(t => t.Id == todoId);
                }
            }
        }
    }
}
