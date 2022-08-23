using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Selenium
{
    internal class SimpleAsserts : BasicHooks
    {
        private const string logIn = "arthur2022black";
        private const string password = "Qwerty123!";

        [Test]
        public void SimpleAssertsConstraints()
        {

            Thread.Sleep(5000);

            Assert.That(-4 + 6, Is.EqualTo(1 + 1));
            Assert.That("Welcome to the state of trance", Is.EqualTo("Welcome to the " + "state " + "of trance"));

            Assert.That(391, Is.LessThan(55));
            Assert.That(12, Is.LessThanOrEqualTo(72));

            Assert.That(new[] { 32, 16, 58 }, Is.EquivalentTo(new[] { 58, 16, 32 }));
        }

        [Test]
        public void AssertsForStrings()
        {
            Thread.Sleep(5000);
            Assert.That(logIn, Does.Match("arthur2022black"));
            Assert.That(password, Does.Contain("123!"));
            Assert.That(logIn, !Does.Match(password));
        }

        [TestCase(1536, 32, 48)]
        [TestCase(79, 79, 1)]
        [TestCase(77, 770, 10)]
        public void EqualTest(int firstValue, int secondValue, int thirdValue)
        {
            Thread.Sleep(5000);
            Assert.AreEqual(firstValue, secondValue / thirdValue);
            Assert.AreEqual(firstValue, secondValue * thirdValue);
        }

        [TestCase(12, 4, ExpectedResult = 3)]
        [TestCase(20, 5, ExpectedResult = 4)]
        public int DevideValuesTest(int a, int b)
        {
            Thread.Sleep(5000);
            return a / b;
        }

        [TestCaseSource(nameof(DivideCases))]
        public void DivideTest(int n, int d, int q)
        {
            Thread.Sleep(5000);
            Assert.AreEqual(q, n / d);
        }

        static object[] DivideCases =
        {
            new object[] { 12, 3, 4 },
            new object[] { 12, 2, 6 },
            new object[] { 12, 4, 3 }
        };
    }
}
