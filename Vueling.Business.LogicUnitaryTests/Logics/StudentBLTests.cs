using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMock;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.DataAccess.Dao;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Factories;
using System.IO;
using Vueling.DataAccess.Dao.Interfaces;

namespace Vueling.Business.Logic.Tests
{
    [TestClass()]
    public class StudentBLTests
    {

        private readonly Logger logger = new Logger();
        private MockFactory mock_factory;

        Mock<AbstarctFactory> Afactorymock; //Createmock con la interfaç
        Mock<IStudentDao> Istudentdaomock;
        Mock<IStudentBL> Istudentblmock;

        Student studenttest;
        Config format;

        [AssemblyInitialize]
        public static void Configure(TestContext tc)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [TestInitialize()]
        public void Initialize()
        {
            logger.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " iniciado");
            mock_factory = new MockFactory();

            Afactorymock = mock_factory.CreateMock<AbstarctFactory>();
            Istudentdaomock = mock_factory.CreateMock<IStudentDao>();
            Istudentblmock = mock_factory.CreateMock<IStudentBL>();

            logger.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " terminado");
        }

        [TestCleanup()]
        public void Cleanup()
        {
            mock_factory.VerifyAllExpectationsHaveBeenMet();
            mock_factory.ClearExpectations();
        }

        [DataRow(3, "G", "B", 11, "11111111-Z", "1-10-2012", "Edad")]
        [DataTestMethod()]
        public void BusinessLogicTest(int id, string name, string surname, int edad, string dni, string datebirth, string prop)
        {
            logger.Info("Inici CompleteTest.");

            Student student = new Student(id, name, surname, edad, dni, datebirth);

            format = new Config();

            //MethodWith para metodos que necesiten pasarle unos paramertos
            //Method para metodos que no reciben paràmetros
            Afactorymock.
                Expects.
                One.
                MethodWith(s => s.CreateStudentFormat(format)).
                WillReturn(Istudentdaomock.MockObject);

            Istudentblmock.
                Expects.
                One.
                MethodWith(s => s.Complete(student)).
                WillReturn(student);
       
            IStudentDao isttest = Afactorymock.MockObject.CreateStudentFormat(format);

            Student studentcomplete = Istudentblmock.MockObject.Complete(student);

            Istudentdaomock.
                Expects.
                One.
                MethodWith(s => s.Add(student)).
                WillReturn(studentcomplete);

            studenttest = Istudentdaomock.MockObject.Add(studentcomplete);

            Assert.IsNotNull(isttest);
            Assert.IsTrue(student.Equals(studenttest));
        }
    }
}