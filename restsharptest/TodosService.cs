using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using RestSharp;
using static restsharptest.Program;
using static System.Console;

namespace restsharptest
{
    public class TodosService : ITodosService
    {
        private readonly SortedList<int, Todo> _todos = new SortedList<int, Todo>();
        private readonly RestClient _client;

        public TodosService(IOptions<ClientSettings> clientSettings)
        {
            _client = new RestClient(clientSettings.Value.TodosUrl);
        }
        //TODO
        //filtering, finished todos method props etc...
        //setup di with appsettings json and put client url, get access to config here

        public async Task<Todo> GetTodoAsync(int id)
        {
            if (_todos.ContainsKey(id))
            {
                return _todos[id];
            }

            var request = new RestRequest($"{id}");
            var response = await _client.ExecuteGetAsync<Todo>(request);

            if (!response.IsSuccessful)
            {
                throw new ApiError(response.ErrorMessage);
            }
            var todo = response.Data;

            //add todos to memory list
            _todos.Add(todo.Id,todo);
            return todo;
            //  WriteLine($"\n{nameof(PrintTodoandResponseAsync)}:\t{todo.Title}\t{response.StatusCode}");
        }

        public async Task AddTodoAsync(Todo todo)
        {
            //auto serializes the todo
            var request = new RestRequest().AddJsonBody(todo);
            var response = await _client.ExecutePostAsync<Todo>(request);
            if (!response.IsSuccessful)
            {
                throw new ApiError(response.ErrorMessage);
            }
            _todos.Add(todo.Id, todo);
            // WriteLine($"\n{nameof(AddTodoAndPrintResponseAsync)}:\t{response.ResponseStatus}");
        }

        public Task<IEnumerable<Todo>> GetTodosAsync()
        {
            throw new NotImplementedException();
        }

        #region Not Async example
        /*
        private static void PrintJsonTodo()
        {
            var request = new RestRequest("todos/1");
            var response = _client.Get(request);

            //auto deserializes the todo - correct way if we want to use the todo
            // var response = _client.Get<Todo>(request);

            WriteLine($"\n{nameof(PrintJsonTodo)}:\t{response.Content}");
        }*/
        #endregion
    }
}
