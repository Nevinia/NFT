using Microsoft.AspNetCore.Mvc;
using NFT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFT.Controllers
{
    public class GetStudentsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreateStudent()
        {
            return View("CreateStudent", null);
        }

        [HttpPost]
        public ActionResult CreateStudent(IOModel input)
        {
            input.OutputString = input.InputString + "9";
            return View("CreateStudent9", input);
        }
    }
}
