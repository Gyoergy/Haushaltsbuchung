using System.Collections.Generic;
using Haushaltsbuch;
using NUnit.Framework;

namespace HaushaltsbuchTests
{
    [TestFixture]
    public class DataToListTests
    {
        [Test]
        public void CreateListTest()
        {
            DataCreator dataCreate = new DataCreator();
            var lines = new List<string> { "test1 10.10.2010 500 ", "test1 11.10.2010 600 ", "test2 12.10.2010 700 " };
            dataCreate.LinesIntoData(lines);

            DataToList dataList = new DataToList();
            var result = dataList.CreateList(dataCreate.AllData);

            Assert.AreEqual(result,
                new List<string> {"test1 10.10.2010 500 ", "test1 11.10.2010 600 ", "test2 12.10.2010 700 "});
        }
    }
}