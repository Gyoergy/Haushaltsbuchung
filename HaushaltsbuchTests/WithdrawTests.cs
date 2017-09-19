using System;
using System.Collections.Generic;
using Haushaltsbuch;
using NUnit.Framework;

namespace HaushaltsbuchTests
{
    [TestFixture]
    public class WithdrawTests
    {
        [Test]
        public void ShowWithdrawTest()
        {
            DataCreator dataCreate = new DataCreator();
            var lines = new List<string>
            {
                "Kassenbestand 10.10.2010 500 ",
                "Kassenbestand 11.10.2011 600 ",
                "Miete 12.10.2009 400 "
            };
            dataCreate.LinesIntoData(lines);

            Withdraw pay = new Withdraw();
            var result = pay.ShowWithdraw(new DateTime(2010, 10, 10), dataCreate.AllData, "Miete", 700, "neu");

            Assert.AreEqual(result,
                new List<string> { "Kassenbestand: -200 EUR", "Miete: 700 EUR neu"});

            Assert.AreEqual(dataCreate.AllData[1].KatName, "Miete");
            Assert.AreEqual(dataCreate.AllData[1].DatumList.Count, 2);
        }
    }
}