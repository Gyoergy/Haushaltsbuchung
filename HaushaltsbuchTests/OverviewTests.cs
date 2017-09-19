using System;
using System.Collections.Generic;
using Haushaltsbuch;
using NUnit.Framework;

namespace HaushaltsbuchTests
{
    [TestFixture]
    public class OverviewTests
    {
        [Test]
        public void ShowOverviewTest()
        {
            DataCreator dataCreate = new DataCreator();
            var lines = new List<string> { "test1 10.10.2010 500 ", "test1 11.10.2010 600 ", "test2 12.10.2010 700 " };
            dataCreate.LinesIntoData(lines);

            Overview oView = new Overview();
            var result = oView.ShowOverview(new DateTime(2010, 10, 30), dataCreate.AllData);

            Assert.AreEqual(result,
                new List<string> { "test1: 500 EUR ", "test1: 600 EUR ", "test2: 700 EUR " });
        }
    }
}