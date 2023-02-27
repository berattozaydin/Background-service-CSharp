using FileService;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ApplicationSettings;

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
        public async Task<Task> WriteAsync() 
        {

                try
                {
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        ReadFile();
                        await Task.Delay(5000, stoppingToken);

                    }

                }
                catch (Exception ex)
                {
                    if (!EventLog.SourceExists("seviye2"))
                    {
                        EventLog.CreateEventSource("seviye2", "seviye2");
                    }
                    EventLog log = new EventLog();

                    log.Source = "seviye2";

                    log.WriteEntry("Hata Var", EventLogEntryType.Error);

                }
            return Task.CompletedTask;
        } 
        private void ReadFile()
        {
            
            var connectionString = "Server=172.16.10.15;Database=TestDatabase;User Id=sa;Password=Teknoplan123.;Pooling=true";
            var db = new PetaPoco.Database(connectionString, "System.Data.SqlClient");
            var personDetected = db.FirstOrDefault<PERSON_DETECTED>("WHERE ID=@0",1);
            if (personDetected.PERSON_COUNT >= 1)
            {
                new ToastContentBuilder()
                        .AddArgument("action", "viewConversation")
                        .AddArgument("conversationId", 9813)
                        .AddText(personDetected.PERSON_COUNT.ToString()).Show();
                EmergencyStopLine_CallBack(personDetected);
            }
        }
        private async void EmergencyStopLine_CallBack(PERSON_DETECTED personDetected)
        {
            //Console.WriteLine("İnsan Tespiti");
            await Task.WhenAll(Task.Factory.StartNew(() => {
                Console.WriteLine("İnsan Tespiti");

            }));
        }
        /*private void writeFile()
        {
            string folder = @"C:\Temp\";

            string fileName = "CSharpCornerAuthors.txt";

            string fullPath = folder + fileName;
            if (File.Exists(fullPath))
            {
                File.AppendAllText(fullPath, "berat");

          

            }
            else
            {
                Directory.CreateDirectory(folder);
                using (File.Create(fullPath)) ;

            }
        }*/
        public Task StopAsync(CancellationToken cancellationToken)
        {
            
            return Task.CompletedTask;
        }

       
    }
}
