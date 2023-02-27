using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWrite.Manager
{
    public class FileManager
    {
        public FileManager() { }
        static string folder = @"C:\Temp\";

        static string fileName = "CSharpCornerAuthors.txt";
        public void WriteFile(string detectingInfo = null, int personCount = 0)
        {
            string folder = @"C:\Temp\";

            string fileName = "CSharpCornerAuthors.txt";

            string fullPath = folder + fileName;

            if (File.Exists(fullPath))
            {
                File.AppendAllText(fullPath, detectingInfo + " " + personCount);

            }
            else
            {
                Directory.CreateDirectory(folder);
                using (File.Create(fullPath)) ;

            }
        }

    }
}
