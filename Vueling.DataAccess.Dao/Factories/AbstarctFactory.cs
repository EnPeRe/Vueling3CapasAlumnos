using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Interfaces;

namespace Vueling.DataAccess.Dao.Factories
{
    public abstract class AbstarctFactory
    {
        // return el tipo de formato txt, json, xml
        public abstract ARepository CreateStudentFormat(Config typ);
    }
}
