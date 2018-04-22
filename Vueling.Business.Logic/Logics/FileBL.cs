using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Business.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Singletons;
using Vueling.DataAccess.Dao.Factories;
using System.IO;
using Vueling.Common.Logic.LoggerAdapter;
using System.Collections.ObjectModel;
using Vueling.Common.Logic.CommonResources;
using Vueling.DataAccess.Dao;

namespace Vueling.Business.Logic.Logics
{
    public class FileBL : IFileBL
    {
        // Refactoritzar con SOLID (eliminar els switchs)
        // Colocar try catch a ReadFile


        // Llegim   del fitxer txt, o dels singletons json i xml   una llista del fitxer (READFILE)
        // Busquem al fitxer corresponent amb una query sobre les llistes creades per ReadFile (BUSCAR)

        private static SingletonJson sinjson;
        private static SingletonXml sinxml;
        private List<Student> liststudent;
        private readonly StudentDao studentdao;

        private readonly Logger logger = new Logger();

        public FileBL()
        {
            studentdao = new StudentDao();
        }

        public List<Student> ReadFile(Config con)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            // Aplicar SOLID eliminar switch
            switch (con)
            {
                case Config.txt:
                    return studentdao.ReadAll(con);
                case Config.json:
                    return sinjson.LoadAll();
                case Config.xml:
                    return sinxml.LoadAll();
                case Config.sql:
                    return studentdao.ReadAll(con);
                case Config.clr:
                    return studentdao.ReadAll(con);
                default:
                    return studentdao.ReadAll(con);
            }
        }

        public void FillSingletons()
        {
            sinjson = SingletonJson.Instance;
            sinxml = SingletonXml.Instance;
        }

        public List<Student> Buscar(Config format, string textabuscar, string propertyabuscar)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                liststudent = this.ReadFile(format);

                IEnumerable<Student> liststudentfound = from st in liststudent
                                             where st.GetType().GetProperty(propertyabuscar).GetValue(st).ToString() == textabuscar
                                             select st;

                logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

                return liststudentfound.ToList<Student>();
            }
            catch (System.Reflection.AmbiguousMatchException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }
        }
    }
}
