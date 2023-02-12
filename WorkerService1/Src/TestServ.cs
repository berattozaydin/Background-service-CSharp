using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Src
{
    public class TestServ
    {
        CancellationToken stoppingToken;
       static string folder = @"C:\Temp\";

       static string fileName = "CSharpCornerAuthors.txt";

        string fullPath = folder + fileName;
        public TestServ(CancellationToken stoppingToken) 
        { 
            this.stoppingToken = stoppingToken;
        }
        public async Task writeAsync() {

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    writeFile();
                    await Task.Delay(5000, stoppingToken);

                }
                if (!EventLog.SourceExists("seviye2"))
                {
                    EventLog.CreateEventSource("seviye2", "seviye2");
                }
                EventLog log = new EventLog();

                log.Source = "seviye2";

                log.WriteEntry("Hata Var", EventLogEntryType.Error);

            }
            catch(Exception ex)
            {
                if (!EventLog.SourceExists("seviye2"))
                {
                    EventLog.CreateEventSource("seviye2", "seviye2");
                }
                EventLog log = new EventLog();
               
                log.Source = "seviye2";
                
                log.WriteEntry("Hata Var", EventLogEntryType.Error);
               
            }
            
        } 
        private void writeFile()
        {
            string folder = @"C:\Temp\";

            string fileName = "CSharpCornerAuthors.txt";

            string fullPath = folder + fileName;

            string[] authors = { "Mahesh Chand", "Allen O'Neill", "David McCarter", "Raj Kumar", "Dhananjay Kumar" };
            if (File.Exists(fullPath))
            {
                File.AppendAllText(fullPath, "berat");

          

            }
            else
            {
                Directory.CreateDirectory(folder);
                using (File.Create(fullPath)) ;

            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            
            return Task.CompletedTask;
        }

       
    }
}
