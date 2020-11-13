using System.IO;
using HelloCrowe.Core.Models;
using Microsoft.Extensions.Options;

namespace HelloCrowe.Core
{
    public class FileBasedMessageRepository : IMessageRepository
    {
        private readonly FileSourceInfo _fileInfo;

        public FileBasedMessageRepository(IOptions<FileSourceInfo> fileInfo)
        {
            _fileInfo = fileInfo.Value;
        }

        public string Get()
        {
            var filePath = ToApplicationPath(_fileInfo.FilePath, _fileInfo.FileName);
            string[] lines = System.IO.File.ReadAllLines(filePath);

            return lines[0];
        }

        public void Set(string message)
        {
            // TODO: save message to file
        }

        private string ToApplicationPath(string path, string fileName)
        {
            var exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return Path.Combine(exePath, path, fileName);
        }
    }
}