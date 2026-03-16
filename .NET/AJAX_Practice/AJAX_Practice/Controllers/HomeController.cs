//using System.Diagnostics;
//using AJAX_Practice.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace AJAX_Practice.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }

//        public int Addition(int a, int b)
//        {
//            return a + b;
//        }
//    }
//}

using AJAX_Practice.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static List<StudentModel> students = new List<StudentModel>();
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        students = new List<StudentModel>();
        students.Add(new StudentModel()
        {
            Id = 1,
            Email = "ankush1802@outlook.com",
            Name = "Ankush"
        });
        students.Add(new StudentModel()
        {
            Id = 2,
            Email = "rohit@outlook.com",
            Name = "Rohit"
        });
        students.Add(new StudentModel()
        {
            Id = 3,
            Email = "sunny@outlook.com",
            Name = "Sunny"
        });
        students.Add(new StudentModel()
        {
            Id = 4,
            Email = "amit@outlook.com",
            Name = "Amit"
        });
    }
    public IActionResult Index()
    {
        return View(students);
    }
    [HttpGet]
    public JsonResult GetDetailsById(int id)
    {
        var student = students.Where(d => d.Id.Equals(id)).FirstOrDefault();
        JsonResponseViewModel model = new JsonResponseViewModel();
        if (student != null)
        {
            model.ResponseCode = 0;
            model.ResponseMessage = JsonConvert.SerializeObject(student);
        }
        else
        {
            model.ResponseCode = 1;
            model.ResponseMessage = "No record available";
        }
        return Json(model);
    }
    [HttpPost]
    public JsonResult InsertStudent(IFormCollection formcollection)
    {
        StudentModel student = new StudentModel();
        student.Email = formcollection["email"];
        student.Name = formcollection["name"];
        JsonResponseViewModel model = new JsonResponseViewModel();
        //MAKE DB CALL and handle the response

        
        if (student != null)
        {
            model.ResponseCode = 0;
            model.ResponseMessage = JsonConvert.SerializeObject(student);
        }
        else
        {
            model.ResponseCode = 1;
            model.ResponseMessage = "No record available";
        }
        return Json(model);
    }
    [HttpPut]
    public JsonResult UpdateStudent(IFormCollection formcollection)
    {
        StudentModel student = new StudentModel();
        student.Id = int.Parse(formcollection["id"]);
        student.Email = formcollection["email"];
        student.Name = formcollection["name"];
        JsonResponseViewModel model = new JsonResponseViewModel();
        //MAKE DB CALL and handle the response
        if (student != null)
        {
            model.ResponseCode = 0;
            model.ResponseMessage = JsonConvert.SerializeObject(student);
        }
        else
        {
            model.ResponseCode = 1;
            model.ResponseMessage = "No record available";
        }
        return Json(model);
    }
    [HttpDelete]
    public JsonResult DeleteStudent(IFormCollection formcollection)
    {
        StudentModel student = new StudentModel();
        student.Id = int.Parse(formcollection["id"]);
        JsonResponseViewModel model = new JsonResponseViewModel();
        //MAKE DB CALL and handle the response

        if (student != null)
        {
            model.ResponseCode = 0;
            model.ResponseMessage = JsonConvert.SerializeObject(student);
        }
        else
        {
            model.ResponseCode = 1;
            model.ResponseMessage = "No record available";
        }
        return Json(model);
    }
}