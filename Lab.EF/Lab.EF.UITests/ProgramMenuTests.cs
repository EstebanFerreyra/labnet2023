using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.EF.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.EF.Logic.Services;

namespace Lab.EF.UI.Tests
{
    [TestClass()]
    public class ProgramMenuTests
    {
        [TestMethod()]
        public void ValidationStringTest()
        {
            ProgramMenu programMenu = new ProgramMenu(new EmployeesService(), new CustomersService(), new CategoriesService());
            Assert.AreEqual(programMenu.ValidationString(24, "3406462128"), "3406462128");
            Assert.AreEqual(programMenu.ValidationString(5, "FERRA"), "FERRA");
        }

        [TestMethod()]
        public void IdGeneratorTest()
        {
            ProgramMenu programMenu = new ProgramMenu(new EmployeesService(), new CustomersService(), new CategoriesService());
            Assert.AreEqual(programMenu.IdGenerator("ComGuitar"), "COMGU");
            Assert.AreEqual(programMenu.IdGenerator("Esteban"), "ESTEB");
            Assert.AreEqual(programMenu.IdGenerator("factory"), "FACTO");
        }

        [TestMethod()]
        public void ValidationIntTest()
        {
            ProgramMenu programMenu = new ProgramMenu(new EmployeesService(), new CustomersService(), new CategoriesService());
            Assert.AreEqual(programMenu.ValidationInt(5, "33333"), 33333);
        }
    }
}