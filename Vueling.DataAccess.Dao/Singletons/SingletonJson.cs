using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Factories;

namespace Vueling.DataAccess.Dao.Singletons
{
    public sealed class SingletonJson
    {
        private static SingletonJson instance = null;
        private static readonly object padlock = new object();
        readonly List<Student> liststudents;
        readonly AbstarctFactory abfac = new FormatFactory();

        protected SingletonJson()
        {
            liststudents = (abfac.CreateStudentFormat(Config.json)).ReadAll();
        }

        public static SingletonJson Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonJson();
                        }
                    }
                }
                return instance;
            }
        }

        public List<Student> LoadAll()
        {
            return liststudents;
        }
    }
}
