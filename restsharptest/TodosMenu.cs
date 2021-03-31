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
        private readonly int amountOfOptions = 2;
        private readonly ITodosService _todosService;

        public TodosMenu(ITodosService todosService)
        {
            _todosService = todosService;
        }
        public async Task Run()
        {
            Write("Hello, what would you like to do today?:");
            Write("1.Blabla\n2.Blabla");
            int input = Helpers.GetIntInput(amountOfOptions, 0, $"You have {amountOfOptions} options, choose wisely");

            //validate input make helper
            try
            {
                switch (input)
                {
                    case 1:
                        var todo = await _todosService.GetTodoAsync(1);
                        WriteLine(todo.ToString());
                        break;
                    default:
                        break;
                }

                /*
                await PrintTodoandResponseAsync();
                await AddTodoAndPrintResponseAsync();
                PrintJsonTodo();
                */
            }
            catch (Exception e)
            {
                WriteLine($"{e.Message}\n{e.StackTrace}");
            }
        }
    }
}
