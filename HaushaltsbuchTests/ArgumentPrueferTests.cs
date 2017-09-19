using Haushaltsbuch;
using NUnit.Framework;

namespace HaushaltsbuchTests
{
    [TestFixture]
    public class ArgumentPrueferTests
    {
        [Test]
        public void ErsteArgPrueferTest_einzahlung()
        {
            ArgumentPruefer argPrf = new ArgumentPruefer();

            var result = argPrf.ErsteArgPruefer("einzahlung");

            Assert.AreEqual(result, 2);
        }

        [Test]
        public void ErsteArgPrueferTest_übersicht()
        {
            ArgumentPruefer argPrf = new ArgumentPruefer();

            var result = argPrf.ErsteArgPruefer("übersicht");

            Assert.AreEqual(result, 1);
        }
    }
}