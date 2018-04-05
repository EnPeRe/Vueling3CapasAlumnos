﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.DataAccess.Dao;
using Vueling.DataAccess.Dao.Factories;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Singletons;

namespace Vueling.Business.Logic
{
    public class StudentBL : IStudentBL
    {
        

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void BusinessLogic(Student student)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                   " iniciado");
            AbstarctFactory AbsFac;

            Config config = (Config)Enum.Parse(typeof(Config), student.SavedFormat);

            AbsFac = new FormatFactory();
            (AbsFac.CreateStudentFormat(config)).Add(this.Complete(student));

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
        }

        private Student Complete(Student student)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");

            this.GetAge(student);
            this.HoraRegistro(student);

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
            return student;
        }

        private void GetAge(Student student)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");

            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy")) - Convert.ToInt32(student.FechaNacimiento.ToString("yyyy"));
            if (student.FechaNacimiento.DayOfYear > DateTime.Now.DayOfYear) year--;
            student.Edad = year;

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
        }

        private void HoraRegistro(Student student)
        {
            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " iniciado");

            student.HoraRegistro = DateTime.Now;

            log.Info("Metodo " + System.Reflection.MethodBase.GetCurrentMethod().Name +
                " terminado");
        }

    }
}
