using System;
using System.Collections.Generic;
using Haushaltsbuch;
using NUnit.Framework;

namespace HaushaltsbuchTests
{
    [TestFixture]
    public class SorterTests
    {
        [Test]
        public void SortTest()
        {
            Sorter sort = new Sorter();

            var dateList = new List<DateTime> {DateTime.Parse("01/01/2001"),DateTime.Parse("01/03/2001"),DateTime.Parse("01/04/2001"), DateTime.Parse("01/02/2001") };
            var priceList = new List<decimal> {1,2,3,4};
            var memoList = new List<string> {"a","b","c","d"};
            var price = 10;
            sort.Sort(dateList,priceList,memoList,price);

            Assert.AreEqual(priceList, new List<decimal> {1,4,12,13});
            Assert.AreEqual(memoList, new List<string> {"a","d","b","c"});
        }
    }
}