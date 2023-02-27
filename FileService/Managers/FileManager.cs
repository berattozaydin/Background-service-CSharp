using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace FileService.Managers
{
    public class FileManager
    {
       
        public FileManager() { }
        public void WriteFile(string detectionInfo=null,int personCount=0)
        {
            var connectionString = "Server=172.16.10.15;Database=TestDatabase;User Id=sa;Password=Teknoplan123.;Pooling=true";
            var db = new PetaPoco.Database(connectionString, "System.Data.SqlClient");
            var person = new PERSON_DETECTED
            {
                ID=1,
                PERSON_COUNT = personCount
            };
            db.Update(person);
            /*string folder = @"C:\Temp\";

            string fileName = "CSharpCornerAuthors.txt";

            string fullPath = folder + fileName;

            if (File.Exists(fullPath))
            {
                File.AppendAllText(fullPath, (detectionInfo + " " + personCount));
                
            }
            else
            {
                Directory.CreateDirectory(folder);
                using (File.Create(fullPath)) ;

            }*/

        }
    }
}
