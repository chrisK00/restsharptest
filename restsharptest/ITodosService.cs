using System.Collections.Generic;
using System.Threading.Tasks;

namespace restsharptest
{
    public interface ITodosService
    {
        Task AddTodoAsync(Todo todo);
        Task<Todo> GetTodoAsync(int id);
        Task<IEnumerable<Todo>> GetTodosAsync();
        Task<IEnumerable<Todo>> GetCompletedTodosAsync();
    }
}
