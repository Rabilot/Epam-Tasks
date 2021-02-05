using System.IO;

namespace Task4.BL.Interfaces
{
    public interface IFileHandler
    {
        void CreatedEventHandler(object sender, FileSystemEventArgs e);
    }
}