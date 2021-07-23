using Microsoft.AspNetCore.Mvc;
using NFT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult DoAction()
        {
            var ioModel = new IOModel();

            return View("DoAction", ioModel);
        }

        [HttpPost]
        public ActionResult DoAction(IOModel input)
        {
            var selectedMethod = input.Methods.FirstOrDefault(x => x.Name == input.SelectedMethod);

            if (selectedMethod == null)
            {
                input.OutputString = "Selected method is not supported";
            }
            else if (input.Action == "Encrypt")
            {
                if (!selectedMethod.ValidateInputForEncrypt(input.InputString))
                {
                    input.OutputString = "Input is invalid";
                }
                else
                    input.OutputString = selectedMethod.Encrypt(input.InputString);
            }
            else if (input.Action == "Decrypt")
            {
                if (!selectedMethod.ValidateInputForDecrypt(input.InputString))
                {
                    input.OutputString = "Input is invalid";
                }
                else
                    input.OutputString = selectedMethod.Decrypt(input.InputString);
            }
            else
            {
                input.OutputString = "Select Encrypt/Decrypt action";
            }

            return View("DoAction", input);
        }
    }
}
