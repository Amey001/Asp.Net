using HospitalApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BOL;
using BLL;
namespace HospitalApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(string pname,string disease,string room,string admitdate)
        {
            Patient p = new Patient(pname,disease,room,DateOnly.Parse(admitdate));
            BLL.PaitentService.insertp(p);
            return RedirectToAction("Index");
        }

        public IActionResult Getlist()
        {
            List<Patient> p = BLL.PaitentService.Getlist();
            ViewBag.list = p;
            return View();
        }

        public IActionResult Delete(int id)
        {
            Console.WriteLine(id);
            BLL.PaitentService.Delete(id);

            return RedirectToAction("Getlist");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {   
            Patient P=BLL.PaitentService.Getbyid(id);
            ViewBag.list = P;
            return View();
        }

        [HttpPost]
        public IActionResult Edit(String id, string pname, string disease, string room, String admitdate)
        {
      
            Patient p = new Patient(int.Parse(id),pname, disease, room,DateOnly.Parse(admitdate));

            BLL.PaitentService.Update(p);

            return RedirectToAction("Getlist");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}