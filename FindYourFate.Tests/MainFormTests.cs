using Microsoft.SqlServer.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindYourFate.Tests
{
    [TestClass]
    public class MainFormTests
    {
        [TestMethod]
        public void ToUpperFirstLetterTests() 
        {
            string text = "test string";
            string extend = MainForm.ToUpperFirstLetter(text);
            string actual = "Test string";
            Assert.IsTrue(actual == extend);
        }
    }
}
