using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.Common.Logic.Models;

namespace Vueling.Common.Logic
{
    public static class FileUtils
    {

        //Mirar lo del Path amb variables d'entorn (potser posar només el nom del fitxer en una variable d'entorn, pero la carpeta no)
        // Eliminar literals del logg

        // diem quin és el path (GETPATH)
        // Guardem el format a la variable d'entorn del format (SETFORMAT)

        private static readonly Logger logger = new Logger();

        public static string GetPath()
        {
            try
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + typeof(Student).Name;
            }
            catch (AccessViolationException e)
            {
                logger.Error("Error en el metodo GetPath()" + e.Message);
                throw;
            }
            catch (ArgumentException e)
            {
                logger.Error("Error en el metodo GetPath()" + e.Message);
                throw;
            }
            catch (PlatformNotSupportedException e)
            {
                logger.Error("Error en el metodo GetPath()" + e.Message);
                throw;
            }
        }

        // posar loggs
        public static void SetFormat(Config con)
        {
            try
            {
                Environment.SetEnvironmentVariable("Save_Format", con.ToString(), EnvironmentVariableTarget.User);
            }
            catch (ArgumentNullException e)
            {
                logger.Error(e.Message);
            }
            catch (ArgumentException e)
            {
                logger.Error(e.Message);
            }
            catch (System.Security.SecurityException e)
            {
                logger.Error(e.Message);
            }
        }

    }
}