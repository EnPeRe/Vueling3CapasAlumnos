using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.CommonResources;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Interfaces;

namespace Vueling.DataAccess.Dao
{
    public class StudentDaoJson : IStudentDao
    {
        // Eliminar literals

        //Afegim al fitxer (SETSTUDENT)
        //Llegim del fitxer (GETSTUDENTBYGUID)
        //Llegim una llista del fitxer (READALL)

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Logger logger = new Logger();
        private readonly string path = FileUtils.GetPath() + ".json";

        List<Student> liststudents;
        Student studentread;

        public Student Add(Student student)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            Student studentread;
            try
            {
                this.SetStudent(student, path);
                studentread = this.GetStudentByGuid(student.Student_Guid, path);
            }
            catch (IOException e)
            {
                log.Error("Error en el metodo SetStudent()" + e.Message);
                throw;
            }

            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            return studentread;
        }

        private void SetStudent(Student student, string path)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                if (File.Exists(path))
                {
                    using (TextReader reader = new StreamReader(path))
                    {
                        liststudents = JsonConvert.DeserializeObject<List<Student>>(reader.ReadToEnd());
                    }
                    using (TextWriter writer = new StreamWriter(path))
                    {
                        liststudents.Add(student);
                        writer.Write(JsonConvert.SerializeObject(liststudents));
                    }
                }
                else
                {
                    using (TextWriter writer = new StreamWriter(path))
                    {
                        writer.WriteLine(student.ToJson());
                    }
                }
            }
            catch (PathTooLongException e)
            {
                log.Error("Error en el metodo ReadAllTxt()" + e.Message);
                throw;
            }
            catch (UnauthorizedAccessException e)
            {
                log.Error("Error en el metodo ReadAllTxt()" + e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error("Error en el metodo ReadAllTxt()" + e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                log.Error("Error en el metodo ReadAllTxt()" + e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                log.Error("Error en el metodo ReadAllTxt()" + e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                log.Error("Error en el metodo ReadAllTxt()" + e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error("Error en el metodo ReadAllTxt()" + e.Message);
                throw;
            }

            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

        }

        private Student GetStudentByGuid(Guid studentguid, string path)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            studentread = new Student();
            try
            {
                var alllines = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(path));
                foreach (Student st in alllines)
                {
                    if (st.Student_Guid == studentguid) studentread = st;
                }
            }
            catch (System.Security.SecurityException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (UnauthorizedAccessException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (PathTooLongException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }

            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            return studentread;
        }

        public List<Student> ReadAll()
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            liststudents = new List<Student>();

            try
            {   
                if (File.Exists(path))
                {
                    liststudents = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(path));
                }
            }
            catch (System.Security.SecurityException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (UnauthorizedAccessException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (PathTooLongException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (IOException e)
            {
                log.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            return liststudents;
        }
    }
}
