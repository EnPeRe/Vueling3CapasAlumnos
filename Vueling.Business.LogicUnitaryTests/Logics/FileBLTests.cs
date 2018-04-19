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
using Vueling.Business.Logic.Interfaces;
using Vueling.DataAccess.Dao.Interfaces;

namespace Vueling.Business.Logic.Tests
{
    [TestClass()]
    public class FileBLTests
    {

        private readonly Logger logger = new Logger();
        private MockFactory mock_factory;

        Mock<AbstarctFactory> Afactorymock; //Createmock con la interfaç
        Mock<IStudentDao> Istudentdaomock;
        Mock<IFileBL> Ifileblmock;

        Student student;
        Config format;
        List<Student> studentlist;

        [TestInitialize()]
        public void Initialize()
        {
            logger.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " iniciado");
            mock_factory = new MockFactory();
            logger.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " terminado");
        }

        [TestCleanup()]
        public void Cleanup()
        {
            mock_factory.VerifyAllExpectationsHaveBeenMet();
            mock_factory.ClearExpectations();
        }

        [TestMethod()]
        public void Buscar()
        {
            logger.Info("Inici BuscarTest.");

            student = new Student();
            format = new Config();

            List<Student> studenttestlist;
            studentlist = new List<Student>();

            Ifileblmock = mock_factory.CreateMock<IFileBL>();

            Ifileblmock.
                Expects.
                One.
                MethodWith(s => s.ReadFile(format)).
                WillReturn(studentlist);
       
            studenttestlist = Ifileblmock.MockObject.ReadFile(format);

            Assert.IsTrue(studenttestlist.Equals(studentlist));
        }

        [DataRow(Config.txt)]
        [DataTestMethod()]
        public void ReadFileTest(Config form)
        {
            Afactorymock = mock_factory.CreateMock<AbstarctFactory>();
            Istudentdaomock = mock_factory.CreateMock<IStudentDao>();

            Afactorymock.
                Expects.
                One.
                MethodWith(s => s.CreateStudentFormat(form)).
                WillReturn(Istudentdaomock.MockObject);

            IStudentDao isttest = Afactorymock.MockObject.CreateStudentFormat(form);
            Assert.IsNotNull(isttest);
        }
    }
}