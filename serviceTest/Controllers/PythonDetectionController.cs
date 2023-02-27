using FileService;
using FileService.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace serviceTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PythonDetectionController : Controller
    {
        [HttpPost]
        public IActionResult Write(PERSON_DETECTED personClass)
        {
            WriteCountToFile(personClass.PERSON_COUNT);
            return Ok(personClass.PERSON_COUNT);
        }
        private void WriteCountToFile(int personCount)
        {
            var fileManager = new FileManager();

            if (personCount > 0)
            {
                fileManager.WriteFile("Insan Tespit Edildi", personCount);
            }
            else
            {
                fileManager.WriteFile("İnsan Tespiti Yok");
            }


        }
       
    }
}
