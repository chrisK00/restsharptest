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
        private readonly ITodosService _todosService;

        public TodosMenu(ITodosService todosService)
        {
            _todosService = todosService;
        }
        public async Task Run()
        {
            Console.WriteLine("hi");
            try
            {
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
