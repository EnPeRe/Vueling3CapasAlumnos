using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMock;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Factories;
using Vueling.DataAccess.Dao.Interfaces;

namespace Vueling.DataAccess.DaoUnitaryTests.DAOs
{
    [TestClass()]
    public class StudentDaoTxtTests
    {

        private readonly Logger logger = new Logger();
        private MockFactory mock_factory;
        private Mock<IStudentDao> Istudentmock;

        [AssemblyInitialize]
        public static void Configure(TestContext tc)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [TestInitialize()]
        public void Initialize()
        {
            mock_factory = new MockFactory();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            mock_factory.VerifyAllExpectationsHaveBeenMet();
            mock_factory.ClearExpectations();
        }

        [DataRow(1, "H", "J", 12, "1123-A", "12-05-1992")]
        [DataRow(2, "I", "F", 23, "98765434-L", "15-09-1982")]
        [DataRow(3, "G", "B", 11, "11111111-Z", "1-10-2012")]
        [DataTestMethod()]
        public void AddTxtUTest(int id, string name, string surname, int edad, string dni, string datebirth)
        {
            logger.Info("Inici AddTest.");

            Mock<IStudentDao> Istudentmock = mock_factory.CreateMock<IStudentDao>(); //Createmock con la interfaç

            Student student = new Student(id, name, surname, edad, dni, datebirth);

            Istudentmock.Expects.One.MethodWith(s => s.Add(student)).WillReturn(student);

            Student sttest = Istudentmock.MockObject.Add(student);

            Assert.IsTrue(student.Equals(sttest));
        }

        [TestMethod()]
        public void ReadAllTxtUTest()
        {
            logger.Info("ReadAllTxtUTest iniciat");

            Mock<IStudentDao> Istudentmock = mock_factory.CreateMock<IStudentDao>(); //Createmock con la interfaç

            List<Student> listst = new List<Student>();

            Istudentmock.Expects.One.MethodWith(s => s.ReadAll()).WillReturn(listst);

            Assert.IsNotNull(Istudentmock.MockObject.ReadAll());

        }
    }
}
