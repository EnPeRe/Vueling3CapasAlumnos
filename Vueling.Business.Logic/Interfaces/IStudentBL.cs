using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.Business.Logic
{
    public interface IStudentBL
    {
        void BusinessLogic(Student student);
        Student Complete(Student student);
        void Delete(Student student);
        void Update(Student student);
    }
}
