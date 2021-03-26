using System;
using System.Threading.Tasks;
using RestSharp;

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

        private static readonly RestClient client = new RestClient("https://jsonplaceholder.typicode.com/");

        private static async Task Main(string[] args)
        {
            try
            {
                await PrintTodoAsync();
                await PrintTodoandResponseAsync();
                PrintJsonTodo();
                await AddTodoAsync();
                await AddTodoAsyncAndPrintResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}\n{e.StackTrace}");
            }
        }

        private static async Task PrintTodoAsync()
        {
            var request = new RestRequest("todos/1");
            var todo = await client.GetAsync<Todo>(request);
            Console.WriteLine(todo.Title);
        }

        private static async Task PrintTodoandResponseAsync()
        {
            var request = new RestRequest("todos/1"); 
            //depreceated
            var response = await client.ExecuteAsync<Todo>(request);
            var todo = response.Data;
            Console.WriteLine(todo.Title);
        }

        private static void PrintJsonTodo()
        {
            var request = new RestRequest("todos/1");
            var response = client.Get(request);
            Console.WriteLine(response.Content);
        }

        private static async Task AddTodoAsync()
        {
            var todo = new Todo { Title = "add this todo" };
            var request = new RestRequest().AddJsonBody(todo);
            //depreceated
            var response = await client.PostAsync<Todo>(request);
            Console.WriteLine(response.Title);
        }

        private static async Task AddTodoAsyncAndPrintResponse()
        {
            var todo = new Todo { Title = "add this todo" };
            var request = new RestRequest().AddJsonBody(todo); 
            var response = await client.ExecutePostAsync<Todo>(request);
            Console.WriteLine(response.ResponseStatus);
        }
    }
}