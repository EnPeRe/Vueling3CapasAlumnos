using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.CommonResources;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Interfaces;

namespace Vueling.DataAccess.Dao.Factories
{
    // public class FormatFactory<T> where T : VuelingModelObject     //(T seria un Student)
    public class FormatFactory : AbstarctFactory
    {
        private readonly Logger logger = new Logger();

        public override ARepository CreateStudentFormat(Config typ)
        {

            logger.Info(new StringBuilder(ResourceLogger.StartMethod).Append(System.Reflection.MethodBase.GetCurrentMethod().Name).ToString());

            switch (typ)
            {
                case Config.txt: return new StudentDaoTxt();
                case Config.json: return new StudentDaoJson();
                case Config.xml: return new StudentDaoXml();
                case Config.sql: return new StudentDaoSql();
                case Config.clr: return new StudentDaoClr();
                default: throw new ArgumentException("Invalid type", "typ");
            }
        }
    }
}
