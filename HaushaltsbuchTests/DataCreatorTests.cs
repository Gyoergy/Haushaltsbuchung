using System.Collections.Generic;
using Haushaltsbuch;
using NUnit.Framework;

namespace HaushaltsbuchTests
{
    [TestFixture]
    public class DataCreatorTests
    {
        [Test]
        public void LinesIntoDataTest()
        {
            DataCreator dataCreate = new DataCreator();

            var lines = new List<string> {"test1 10.10.2010 500", "test1 11.10.2010 600", "test2 12.10.2010 700"};
            dataCreate.LinesIntoData(lines);

            Assert.AreEqual(dataCreate.AllData[0].PreisList[0], 500);
            Assert.AreEqual(dataCreate.AllData[0].PreisList[1], 600);
            Assert.AreEqual(dataCreate.AllData[1].PreisList[0], 700);

            Assert.AreEqual(dataCreate.AllData[0].KatName, "test1");
            Assert.AreEqual(dataCreate.AllData[1].KatName, "test2");
        }
    }
}