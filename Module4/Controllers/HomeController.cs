using Microsoft.AspNetCore.Mvc;
using Module4.Models;
using System.Data;
using System.Diagnostics;

namespace Module4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IEnumerable<Person> Returndata() //not used yet.
        //{
        //    Stack<Person> stack = new Stack<Person>();
        //    stack.Push(new Person() { Id = 102, Name = "Bob" });
        //    stack.Push(new Person() { Id = 103, Name = "Shelly" });
        //    return stack;
        //}

        //public IActionResult Display()
        //{
        //    Person person = new Person();
        //    person.Id = 101;
        //    person.Name= "Test";
        //    ViewBag.servertime = DateTime.Now.ToString(); //type object 
        //    ViewData["data"] = "some server data";  //View Data dictornary key value pair shared with corisponding page
        //    ViewData["temp"] = 34.5;

        //    return View(person); //returning model to the View
        //}

        //1. Returns ViewResult
        public IActionResult Index()
        {
            return View();
        }

        //2. Return Content result
        //public ContentResult ReturnContent() // only reutrns "content"
        //{
        //    return Content("hello");
        //}
        
        //3. Redirct to an action
        //public RedirectToActionResult Method1()  // go to another method / action
        //{
        //    string nameofMethod = "Privacy";
        //    return RedirectToAction(nameofMethod);
        //}

        //4. status Code ( used in web APIs)
        //public StatusCodeResult Method2()
        //{
        //    //logic
        //    return new StatusCodeResult(404); // return error page
        //}

        //public ContentResult Test(string parm)
        //{
        //    return Content("Value in route parameter:" + parm);
        //}

        //5.redirectresult
        //public RedirectResult OpenGoogle()
        //{
        //    return Redirect("http://www.google.com");
        //}

        public IActionResult Privacy()
        {
            
            //TODO Remove Error test code
            int x = 0, y = 50;
            int result = y / x;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            return View();
        }
    }
}