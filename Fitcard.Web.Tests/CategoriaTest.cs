using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitcard.Web.Controllers;
using Fitcard.Web.Models;

namespace Fitcard.Web.Tests
{
    [TestClass]
    public class CategoriaTest
    { 

    [TestMethod]
        public void TestMethod()
        {
           Categoria suv = new Categoria();
            suv.CAT_NOME = "12";

            Assert.IsFalse(suv.CAT_NOME.Length > 3);
        }
    }
}
