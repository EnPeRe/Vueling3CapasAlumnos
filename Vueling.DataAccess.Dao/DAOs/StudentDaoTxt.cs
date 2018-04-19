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
    public class StudentDaoTxt : IStudentDao
    {
        // Eliminar literals

        //Afegim al fitxer (SETSTUDENT)
        //Llegim del fitxer (GETSTUDENTBYGUID)
        //Llegim una llista del fitxer (READALL)

        private readonly Logger logger = new Logger();
        private readonly string path = FileUtils.GetPath() + ".txt";

        private Student readstudent;
        private Student studentread;
        private List<Student> liststudents;
        private string[] linesplit;

        public Student Add(Student student)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                this.SetStudent(student, path);
                studentread = this.GetStudentByGuid(student.Student_Guid, path);
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace + e.Message);
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
                    if (!File.Exists(path))
                {
                    using (StreamWriter stwriter = File.CreateText(path))
                    {
                        stwriter.WriteLine(student.ToString());
                    }
                }
                else
                {
                    using (StreamWriter strw = File.AppendText(path))
                    {
                        strw.WriteLine(student.ToString());
                    }
                }
            }
            catch (System.Security.SecurityException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (UnauthorizedAccessException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (PathTooLongException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (IOException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

        }

        private Student GetStudentByGuid(Guid studentguid, string path)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);


            try
            {              
                var alllines = File.ReadAllLines(path);
                string findstudent = "";
                foreach (string line in alllines)
                {
                    if (line.Contains(studentguid.ToString()))
                    {
                        findstudent = line;
                    }
                }

                var lineSplit = findstudent.Split(',');
                readstudent = new Student(Int32.Parse(lineSplit[0]), lineSplit[1], lineSplit[2], lineSplit[3], Int32.Parse(lineSplit[4]), lineSplit[5], lineSplit[6], lineSplit[7]);
                readstudent.SavedFormat = "txt";
            }
            catch (System.Security.SecurityException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (UnauthorizedAccessException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (PathTooLongException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (IOException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }

            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);


            return readstudent;
        }

        public List<Student> ReadAll()
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            liststudents = new List<Student>();

            try
            {
                if (File.Exists(path))
                {
                    var alllines = File.ReadAllLines(path);
                    foreach (string line in alllines)
                    {
                        linesplit = line.Split(',');
                        readstudent = new Student(Int32.Parse(linesplit[0]), linesplit[1], linesplit[2], linesplit[3], Int32.Parse(linesplit[4]), linesplit[5], linesplit[6], linesplit[7]);

                        liststudents.Add(readstudent);
                    }
                }
            }
            catch (System.Security.SecurityException e)
            {
                logger.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (NotSupportedException e)
            {
                logger.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (FileNotFoundException e)
            {
                logger.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (UnauthorizedAccessException e)
            {
                logger.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (DirectoryNotFoundException e)
            {
                logger.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (PathTooLongException e)
            {
                logger.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                logger.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }
            catch (IOException e)
            {
                logger.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }

            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            return liststudents;
        }
    }
}
