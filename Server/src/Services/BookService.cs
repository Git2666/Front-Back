using Microsoft.Extensions.Configuration;
using Server.Interface;

namespace Server.Services
{
    public class BookService: IBookService
    {
        private static IConfiguration _configuration;

        private string _path;

        public BookService(IConfiguration configuration)
        {
            _configuration = configuration;
            _path = _configuration.GetSection("BooksLocation").Value;
        }

        public List<string> FindBooks()
        {
            if (Directory.Exists(_path))
            {
                // 获取所有文件的路径
                List<string> filepaths = Directory.GetFiles(_path)?.ToList();
                filepaths = filepaths.Select(p => Path.GetFileName(p)).ToList();
                return filepaths;
            }
            else
            {
                return null;
            }
        }

        public string GetPath()
            { return _path; }

    }
}
