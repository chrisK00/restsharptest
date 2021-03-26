using System;
using System.Threading.Tasks;
using RestSharp;
using static System.Console;

namespace restsharptest
{
    internal class Program
    {
        /// <summary>
        /// Todo model of jsonplaceholder.api (should be in its own file)
        /// </summary>
        public class Todo
        {
            public int UserId { get; set; }
            public int Id { get; set; }
            public string Title { get; set; }
            public bool Completed { get; set; }
        }

        private static readonly RestClient _client = new RestClient("https://jsonplaceholder.typicode.com/");

        private static async Task Main(string[] args)
        {
            try
            {
                await PrintTodoandResponseAsync();           
                await AddTodoAndPrintResponseAsync();
                PrintJsonTodo();
            }
            catch (Exception e)
            {
                WriteLine($"{e.Message}\n{e.StackTrace}");
            }
        }

        private static async Task PrintTodoandResponseAsync()
        {
            var request = new RestRequest("todos/1");
            var response = await _client.ExecuteGetAsync<Todo>(request);
            var todo = response.Data;

            WriteLine($"\n{nameof(PrintTodoandResponseAsync)}:\t{todo.Title}\t{response.StatusCode}");
        }
  
        private static async Task AddTodoAndPrintResponseAsync()
        {
            var todo = new Todo { Title = "add this todo" };

            //auto serializes the todo
            var request = new RestRequest().AddJsonBody(todo);
            var response = await _client.ExecutePostAsync<Todo>(request);

            WriteLine($"\n{nameof(AddTodoAndPrintResponseAsync)}:\t{response.ResponseStatus}");
        }

        private static void PrintJsonTodo()
        {
            var request = new RestRequest("todos/1");
            var response = _client.Get(request);

            //auto deserializes the todo - correct way if we want to use the todo
            // var response = _client.Get<Todo>(request);

            WriteLine($"\n{nameof(PrintJsonTodo)}:\t{response.Content}");
        }

    }
}