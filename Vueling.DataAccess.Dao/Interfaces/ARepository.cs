using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.DataAccess.Dao.Interfaces
{
    public abstract class ARepository : IStudentDao, IDelete, IUpdate
    {
        public abstract Student Add(Student student);
        public abstract List<Student> ReadAll();

        public virtual int DeleteById(int id)
        {
            throw new NotImplementedException();
        }
        public virtual int UpdateById(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
