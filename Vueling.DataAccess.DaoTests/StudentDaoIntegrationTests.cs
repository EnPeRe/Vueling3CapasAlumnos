using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Vueling.DataAccess.Dao.Factories;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.DataAccess.Dao.Interfaces;

namespace Vueling.DataAccess.Dao.Tests
{
    [TestClass()]
    public class StudentDaoIntegrationTests
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Logger logger = new Logger();


        [AssemblyInitialize]
        public static void Configure(TestContext tc)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [TestInitialize]
        public void Initialize()
        {
            log.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " iniciado");
            
            string[] AllFiles = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Student.*");
            foreach (string s  in AllFiles)
            {
                if(File.Exists(s)) File.Delete(s);
            }
            log.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " terminado");

        }


        [TestCleanup]
        public void Cleanup()
        {
            string[] AllFiles = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Student.*");
            foreach (string s in AllFiles)
            {
                File.Delete(s);
            }
        }


        #region test Test
        [DataRow(1, "H", "J", 12, "1123-A", "12-05-1992")]
        [TestMethod()]
        public void ConstructorTest(int id, string name, string surname, int edad, string dni, string datebirth)
        {
            log.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " iniciado");

            Student student = new Student(id, name, surname, edad, dni, datebirth);
            Student student2 = new Student();

            student2.IdAlumno = id;
            student2.Nombre = name;
            student2.Apellido = surname;
            student2.Edad = edad;
            student2.Dni = dni;
            student2.FechaNacimiento = Convert.ToDateTime(datebirth);

            Assert.IsTrue(student2.Equals(student));

            log.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " terminado");

        }
        #endregion

        #region Add Test
        [DataRow(1, "H", "J", 12, "1123-A", "12-05-1992")]
        [DataRow(2, "I", "F", 23, "98765434-L", "15-09-1982")]
        [DataRow(3, "G", "B", 11, "11111111-Z", "1-10-2012")]
        [DataTestMethod()]
        public void TxtAddTest(int id, string name, string surname, int edad, string dni, string datebirth)
        {
            log.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " iniciado");

            Student student = new Student(id, name, surname, edad, dni, datebirth);

            AbstarctFactory formatfactory = new FormatFactory();
            IStudentDao stddao = formatfactory.CreateStudentFormat(Config.txt);

            Student studenttest = stddao.Add(student);

            studenttest.SavedFormat = student.SavedFormat;

            log.Info("studenttest G: " + studenttest.Student_Guid + ", stuednt G:" + student.Student_Guid);
            log.Info("studenttest: " + studenttest.FechaNacimiento + ", stuednt:" + student.FechaNacimiento);
            log.Info("studenttest: " + studenttest.Nombre + ", stuednt:" + student.Nombre);
            log.Info("studenttest: " + studenttest.Edad + ", stuednt:" + student.Edad);
            log.Info("studenttest: " + studenttest.HoraRegistro + ", stuednt:" + student.HoraRegistro);
            log.Info("studenttest: " + studenttest.IdAlumno + ", stuednt:" + student.IdAlumno);
            log.Info("studenttest: " + studenttest.Apellido + ", stuednt:" + student.Apellido);
            log.Info("studenttest: " + studenttest.SavedFormat + ", stuednt:" + student.SavedFormat);
            log.Info("studenttest: " + studenttest.Dni + ", stuednt:" + student.Dni);

            Assert.IsTrue(student.Equals(studenttest));

            log.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " terminado");

        }

        [DataRow(1, "H", "J", 12, "1123-A", "12-05-1992")]
        [DataRow(2, "I", "F", 23, "98765434-L", "15-09-1982")]
        [DataRow(3, "G", "B", 11, "11111111-Z", "1-10-2012")]
        [DataTestMethod()]
        public void JsonAddTest(int id, string name, string surname, int edad, string dni, string datebirth)
        {
            log.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " iniciado");

            Student student = new Student(id, name, surname, edad, dni, datebirth);

            AbstarctFactory formatfactory = new FormatFactory();
            IStudentDao stddao = formatfactory.CreateStudentFormat(Config.json);

            Student studenttest = stddao.Add(student);

            studenttest.SavedFormat = student.SavedFormat;
            log.Info("studenttest: " + studenttest.SavedFormat + ", stuednt:" + student.SavedFormat);

            Assert.IsTrue(student.Equals(studenttest));

            log.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " terminado");
        }

        [DataRow(1, "H", "J", 12, "1123-A", "12-05-1992")]
        [DataRow(2, "I", "F", 23, "98765434-L", "15-09-1982")]
        [DataRow(3, "G", "B", 11, "11111111-Z", "1-10-2012")]
        [DataTestMethod()]
        public void XmlAddTest(int id, string name, string surname, int edad, string dni, string datebirth)
        {
            log.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " iniciado");

            Student student = new Student(id, name, surname, edad, dni, datebirth);

            AbstarctFactory formatfactory = new FormatFactory();
            IStudentDao stddao = formatfactory.CreateStudentFormat(Config.xml);

            Student studenttest = stddao.Add(student);

            studenttest.SavedFormat = student.SavedFormat;

            Assert.IsTrue(student.Equals(studenttest));

            log.Info(System.Reflection.MethodBase.GetCurrentMethod().Name + " terminado");
        }
        #endregion

        #region ReadAll Test
        [DataRow(1, "H", "J", 12, "1123-A", "12-05-1992")]
        [DataRow(2, "I", "F", 23, "98765434-L", "15-09-1982")]
        [DataRow(3, "G", "B", 11, "11111111-Z", "1-10-2012")]
        [DataTestMethod()]
        public void ReadAllTxt(int id, string name, string surname, int edad, string dni, string datebirth)
        {
            Student student = new Student(id, name, surname, edad, dni, datebirth);
            List<Student> liststudent = new List<Student>();
            liststudent.Add(student);

            List<Student> listtest;
           
            AbstarctFactory formatfactory = new FormatFactory();
            IStudentDao daotxt = formatfactory.CreateStudentFormat(Config.txt);

            foreach (Student st in liststudent)
            {
               daotxt.Add(st);
            }

            listtest = daotxt.ReadAll();

            foreach (Student st in listtest)
            {
                Assert.IsTrue(st.Equals(student));
            }

        }

        [DataRow(1, "H", "J", 12, "1123-A", "12-05-1992")]
        [DataRow(2, "I", "F", 23, "98765434-L", "15-09-1982")]
        [DataRow(3, "G", "B", 11, "11111111-Z", "1-10-2012")]
        [DataTestMethod()]
        public void ReadAllJson(int id, string name, string surname, int edad, string dni, string datebirth)
        {
            Student student = new Student(id, name, surname, edad, dni, datebirth);
            List<Student> liststudent = new List<Student>();
            liststudent.Add(student);

            List<Student> listtest;

            AbstarctFactory formatfactory = new FormatFactory();
            IStudentDao daotxt = formatfactory.CreateStudentFormat(Config.json);

            foreach (Student st in liststudent)
            {
                daotxt.Add(st);
            }

            listtest = daotxt.ReadAll();

            foreach (Student st in listtest)
            {
                Assert.IsTrue(st.Equals(student));
            }

        }


        [DataRow(1, "H", "J", 12, "1123-A", "12-05-1992")]
        [DataRow(2, "I", "F", 23, "98765434-L", "15-09-1982")]
        [DataRow(3, "G", "B", 11, "11111111-Z", "1-10-2012")]
        [DataTestMethod()]
        public void ReadAllXml(int id, string name, string surname, int edad, string dni, string datebirth)
        {
            Student student = new Student(id, name, surname, edad, dni, datebirth);
            List<Student> liststudent = new List<Student>();
            liststudent.Add(student);

            List<Student> listtest;

            AbstarctFactory formatfactory = new FormatFactory();
            IStudentDao daotxt = formatfactory.CreateStudentFormat(Config.xml);

            foreach (Student st in liststudent)
            {
                daotxt.Add(st);
            }

            listtest = daotxt.ReadAll();

            foreach (Student st in listtest)
            {
                Assert.IsTrue(st.Equals(student));
            }

        }

        [DataRow("H", "J", 12, "1123-A", "12-05-1992")]
        [DataRow("I", "F", 23, "98765434-L", "15-09-1982")]
        [DataRow("G", "B", 11, "11111111-Z", "1-10-2012")]
        [DataTestMethod()]
        public void ReadAllSql(string name, string surname, int edad, string dni, string datebirth)
        {
            Student student = new Student(name, surname, edad, dni, datebirth);
            List<Student> liststudent = new List<Student>();
            liststudent.Add(student);

            List<Student> listtest;

            AbstarctFactory formatfactory = new FormatFactory();
            IStudentDao daotxt = formatfactory.CreateStudentFormat(Config.sql);

            foreach (Student st in liststudent)
            {
                daotxt.Add(st);
            }

            listtest = daotxt.ReadAll();

            foreach (Student st in listtest)
            {
                Assert.IsTrue(st.Equals(student));
            }

        }


        [DataRow("H", "J", 12, "1123-A", "12-05-1992")]
        [DataRow("I", "F", 23, "98765434-L", "15-09-1982")]
        [DataRow("G", "B", 11, "11111111-Z", "1-10-2012")]
        [DataTestMethod()]
        public void ReadAllClr(string name, string surname, int edad, string dni, string datebirth)
        {
            Student student = new Student(name, surname, edad, dni, datebirth);
            List<Student> liststudent = new List<Student>();
            liststudent.Add(student);

            List<Student> listtest;

            AbstarctFactory formatfactory = new FormatFactory();
            IStudentDao daotxt = formatfactory.CreateStudentFormat(Config.clr);

            foreach (Student st in liststudent)
            {
                daotxt.Add(st);
            }

            listtest = daotxt.ReadAll();

            foreach (Student st in listtest)
            {
                Assert.IsTrue(st.Equals(student));
            }
        }
        #endregion

    }
}