namespace Server.Interface
{
    public interface IBookService
    {
        List<string> FindBooks();

        string GetPath();
    }
}
