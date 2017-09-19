using System;
using Haushaltsbuch;
using NUnit.Framework;

namespace HaushaltsbuchTests
{
    [TestFixture]
    public class DatumConverterTests
    {
        [Test]
        public void DatumFormatTest()
        {
            DatumConverter datumConv = new DatumConverter();

            var result = datumConv.DatumFormat(2, new[] {"test", "10.10.2010", "200"});

            Assert.AreEqual(result, true);
            Assert.AreEqual(datumConv.DateAktuell, new DateTime(2010,10,10));
        }
    }
}