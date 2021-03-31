namespace restsharptest
{

    public class Todo
    {
        //not making use of this make sure doesnt throw error?  public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }

        public override string ToString()
        {

            return $"{Id}. {Title} completed? {Completed}";
        }
    }
}