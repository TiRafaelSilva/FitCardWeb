using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitcard.Web.Controllers;
using Fitcard.Web.Models;

namespace Fitcard.Web.Tests
{
    [TestClass]
    public class EstabelecimentoTest
    {
        [TestMethod]
        public void TestMethod()
        {
            Estabelecimento est = new Estabelecimento();
            est.EST_CNPJ = 1234567890;
            est.EST_NOME = "Teste";
            est.EST_EMAIL = "teste";
            est.EST_NOME_FANTASIA = "teste do teste";
            est.EST_STATUS = false;
            est.EST_TELEFONE = 1234567890;

            Categoria cat = new Categoria();

            cat.CAT_NOME = "Supermercado";

            est.Categoria = cat;

            Assert.IsTrue(est.validaTipo(est));
        }

    }
}