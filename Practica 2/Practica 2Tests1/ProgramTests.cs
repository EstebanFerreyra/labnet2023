using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void DivisionTest()
        {
            // Arrange.
            string num1 = "10";
            string num2 = "2";
            string num3 = "0";
            string num4 = "cuatro";

            // Act.
            double res1 = Program.Division(num1, num2);
            double res2 = Program.Division(num1, num3);
            double res3 = Program.Division(num1, num4);

            // Assert.
            Assert.AreEqual(res1, 5);
            Assert.AreEqual(res2, 0);
            Assert.AreEqual(res3, 0);
        }

        [TestMethod()]
        public void ThrowDivisionByZeroExceptionTest()
        {
            // Arrange.
            string num1 = "10";
            string num2 = "cuatro";

            // Act.
            double res1 = Program.ThrowDivisionByZeroException(num1);
            double res2 = Program.ThrowDivisionByZeroException(num2);

            // Assert.
            Assert.AreEqual(res1, 0);
            Assert.AreEqual(res2, 0);
        }
    }
}