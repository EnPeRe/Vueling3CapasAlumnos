using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Factories;

namespace Vueling.DataAccess.Dao
{
    public class StudentDao
    {
        private readonly Logger logger = new Logger();
        readonly AbstarctFactory FormatFact;
        private Config config;

        public StudentDao()
        {
            FormatFact = new FormatFactory();
        }

        public void Add(Student student)
        {
            config = (Config)Enum.Parse(typeof(Config), student.SavedFormat);
            (FormatFact.CreateStudentFormat(config)).Add(student);
        }

        public List<Student> ReadAll(Config con)
        {
            return (FormatFact.CreateStudentFormat(con)).ReadAll();
        }

        public void Update(Student student)
        {
            config = (Config)Enum.Parse(typeof(Config), student.SavedFormat);
            (FormatFact.CreateStudentFormat(config)).UpdateById(student);
        }

        public void Delete(Student student)
        {
            config = (Config)Enum.Parse(typeof(Config), student.SavedFormat);
            (FormatFact.CreateStudentFormat(config)).DeleteById(student.IdAlumno);
        }

    }
}
