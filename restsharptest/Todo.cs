using System.Text.Json;

namespace restsharptest
{

    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}