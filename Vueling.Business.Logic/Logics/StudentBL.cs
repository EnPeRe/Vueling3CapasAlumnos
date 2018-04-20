using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.DataAccess.Dao;
using Vueling.DataAccess.Dao.Factories;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Singletons;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.Common.Logic.CommonResources;

namespace Vueling.Business.Logic
{
    public class StudentBL : IStudentBL
    {
        // Canviar els config per enumFormat

        // Fem la logica de Buisness principal
            // Completem l'alumne (COMPLETE) calculant edat (GETAGE) i horaregitre (HORAREGISTRE)
            // Crear objecte StudentDao__ en funció del format (CREATEDTUDENTFORMAT)
            // Afegim l'alumne utilitzant el mètode Add "sobreescrit" per a cada format (ADD)
        
        private readonly Logger logger = new Logger();
        readonly AbstarctFactory FormatFact;
        readonly AbstarctDBFactory FormatDBFactory;
        private Config config;

        public StudentBL()
        {
            FormatFact = new FormatFactory();
            FormatDBFactory = new FormatDBFactory();
        }

        #region Add
        public void BusinessLogic(Student student)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            config = (Config)Enum.Parse(typeof(Config), student.SavedFormat);

            try
            {
                (FormatFact.CreateStudentFormat(config)).Add(this.Complete(student));
            }
            catch (ArgumentNullException e)
            {
                logger.Error(new StringBuilder(e.StackTrace).Append(e.Message).ToString());
                throw;
            }
            catch (Exception e)
            {
                logger.Error(new StringBuilder(e.StackTrace).Append(e.Message).ToString());
                throw;
            }
            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
        #endregion

        #region UpatDel
        public void Delete(Student student)
        {
            (FormatDBFactory.CreateStudentFormatDB(Config.sql)).DeleteById(this.Complete(student).IdAlumno);
        }

        public void Update(Student student)
        {
            this.GetAge(student);
            (FormatDBFactory.CreateStudentFormatDB(Config.sql)).UpdateById(student);
        }
        #endregion

        #region Helpers
        public Student Complete(Student student)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            this.GetAge(student);
            this.HoraRegistro(student);

            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            return student;
        }

        private void GetAge(Student student)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                int year = Convert.ToInt32(DateTime.Now.ToString("yyyy")) - Convert.ToInt32(student.FechaNacimiento.ToString("yyyy"));
                if (student.FechaNacimiento.DayOfYear > DateTime.Now.DayOfYear) year--;
                student.Edad = year;
            }
            catch (FormatException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (ArgumentOutOfRangeException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (OverflowException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }

            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

        }

        private void HoraRegistro(Student student)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);


            student.HoraRegistro = DateTime.Now;

            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

        }
        #endregion
    }
}
