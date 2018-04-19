using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Interfaces;

namespace Vueling.DataAccess.Dao.Factories
{
    // public class FormatFactory<T> where T : VuelingModelObject     //(T seria un Student)
    public class FormatDBFactory : AbstarctDBFactory
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public override IStudentDaoDB CreateStudentFormatDB(Config typ)
        {

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");

            switch (typ)
            {
                case Config.sql: return new StudentDaoSql();
                case Config.clr: return new StudentDaoClr();
                default: throw new ArgumentException("Invalid type", "typ");
            }
        }
    }
}
