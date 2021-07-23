using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFT.Controllers;
using NFT.Logic;
using NFT.Models;
using System;
using System.Linq;
using System.Text;

namespace NFTUnitTests
{
    [TestClass]
    public class HomeControllerUnitTests
    {
        [TestMethod]
        public void EncryptTest()
        {
            var homeController = new HomeController();
            var input = new IOModel();
            var morse = new Morse();

            input.SelectedMethod = "Morse";
            input.Action = "Encrypt";
            input.InputString = morse.TestInput;

            var resultOfAction = homeController.DoAction(input) as ViewResult;
            var resultModel = resultOfAction.Model as IOModel;

            Assert.AreEqual(resultModel.OutputString, morse.TestOutput, "Encryption done correctly");
        }

        [TestMethod]
        public void DecryptTest()
        {
            var homeController = new HomeController();
            var input = new IOModel();
            var morse = new Morse();

            input.SelectedMethod = "Morse";
            input.Action = "Decrypt";
            input.InputString = morse.TestOutput;

            var resultOfAction = homeController.DoAction(input) as ViewResult;
            var resultModel = resultOfAction.Model as IOModel;

            Assert.AreEqual(resultModel.OutputString, morse.TestInput.ToLower(), "Encryption done correctly");
        }
    }
}
