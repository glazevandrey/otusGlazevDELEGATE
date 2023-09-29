using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otusGlazevDELEGATE
{
    public static class OtherIssues
    {
        public static event EventHandler<FileArgs> FileFoundEvent;
        public static void Work(CancellationToken token)
        {
            FileFoundEvent += FileCallback;

            Console.WriteLine("START SEARCH");

            foreach (string file in Directory.EnumerateFiles(Environment.CurrentDirectory + "/Files", "*.*", SearchOption.AllDirectories))
            {
                try
                {
                    token.ThrowIfCancellationRequested();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SEARCH WAS CANCELED");
                    return;
                }

                FileFoundEvent?.Invoke("Work", new FileArgs(file));

                Thread.Sleep(1000);
            }

            Console.WriteLine("END SEARCH");
        }

        public static void FileCallback(object sender, FileArgs e)
        {
            Console.WriteLine("FINDED " + e.FileName );
        }
    }

   
    public class FileArgs : EventArgs
    {
        public string FileName;
        public FileArgs(string fileName) { FileName = fileName; }
    }
}
