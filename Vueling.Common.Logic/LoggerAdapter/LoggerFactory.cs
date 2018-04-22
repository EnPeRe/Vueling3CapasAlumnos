using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.CommonResources;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.Common.Logic.Models;

namespace Vueling.DataAccess.Dao.Factories
{
    // public class FormatFactory<T> where T : VuelingModelObject     //(T seria un Student)
    public class LoggerFactory
    {
        private readonly Logger logger = new Logger();

        public ITargetAdapterForLogger CreateLogger()
        {

            logger.Info(new StringBuilder(ResourceLogger.StartMethod).Append(System.Reflection.MethodBase.GetCurrentMethod().Name).ToString());

            Loger_enum logertype = Loger_enum.log4net; // Canviar per variable de configuració o d'entorn

            switch (logertype)
            {
                case Loger_enum.log4net: return new Logger();
                case Loger_enum.serilog: return new SeriLogger();
                default: throw new ArgumentException("Invalid type", "typ");
            }
        }
    }
}
