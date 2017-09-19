using System;
using System.Collections.Generic;
using Haushaltsbuch;
using NUnit.Framework;

namespace HaushaltsbuchTests
{
    [TestFixture]
    public class DepositTests
    {
        [Test]
        public void ShowDepositTest()
        {
            DataCreator dataCreate = new DataCreator();
            var lines = new List<string> { "Kassenbestand 10.10.2010 500 ", "Kassenbestand 11.10.2011 600 ", "test2 12.10.2009 400 " };
            dataCreate.LinesIntoData(lines);

            Deposit depos = new Deposit();
            var result = depos.ShowDeposit(new DateTime(2010, 10, 15), dataCreate.AllData, 700, "");

            Assert.AreEqual(result, "Kassenbestand: 1200 EUR");
            Assert.AreEqual(dataCreate.AllData[0].DatumList[1], new DateTime(2010, 10, 15));
        }
    }
}