using HomeWorkMiddlewareAndFilters.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HomeWorkMiddlewareAndFilters.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(Worker person)
        {
            string filename = "Users.json";

            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                {
                    char one = '[';
                    byte[] bytes = new byte[sizeof(char)];
                    bytes = BitConverter.GetBytes(one);
                    fs.Write(bytes, 0, bytes.Length - 1);
                    JsonSerializer.Serialize(fs, person);
                }
                else
                {
                    fs.Position = fs.Length - 1;
                    char one = ',';
                    byte[] bytes = new byte[sizeof(char)];
                    bytes = BitConverter.GetBytes(one);
                    fs.Write(bytes, 0, bytes.Length - 1);
                    JsonSerializer.Serialize(fs, person);
                }

                char two = ']';
                byte[] bytes2 = new byte[sizeof(char)];
                bytes2 = BitConverter.GetBytes(two);
                fs.Write(bytes2, 0, bytes2.Length - 1);
            }
            return View();

        }
    }
}
