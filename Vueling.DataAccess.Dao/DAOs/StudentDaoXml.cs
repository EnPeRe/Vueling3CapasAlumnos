﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Vueling.Common.Logic;
using Vueling.Common.Logic.Models;

namespace Vueling.DataAccess.Dao
{
    public class StudentDaoXml : IStudentDao
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public Student Add(Student student)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");

            string path = FileUtils.GetPath() + ".xml";

            FileUtils.SetStudentToXml(student, path);

            #region logs
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            Student studentread;
            studentread = FileUtils.GetStudentFromXmlByGuid(student.Student_Guid, path);

            foreach (PropertyInfo prop in typeof(Student).GetProperties())
            {
                log.Info("studentread." + prop.Name + ": " + prop.GetValue(studentread) + ", student." + prop.Name + ": " + prop.GetValue(student));
                Console.WriteLine(prop.Name);
            }
            #endregion

            return FileUtils.GetStudentFromXmlByGuid(student.Student_Guid, path);
        }
    }
}