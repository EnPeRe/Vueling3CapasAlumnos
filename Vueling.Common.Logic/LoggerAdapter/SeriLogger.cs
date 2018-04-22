using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.Common.Logic.LoggerAdapter
{
    public class SeriLogger : ITargetAdapterForLogger
    {
        // Patro adapter, configurem el nostre propi logger

        private readonly ILogger log;

        public TimeSpan ExecutionTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Counter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public SeriLogger()
        {
            log = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(@"logs\studentSerilog.log")
            .CreateLogger();
        }

        #region logslevels

        public void Info(string message)
        {
                log.Information(message);            
        }
        public void Info(Student st)
        {

                foreach (PropertyInfo prop in typeof(Student).GetProperties())
                {
                    log.Information(st.GetType().ToString() + prop.Name + ": " + prop.GetValue(st));
            }
        }
        /*public void Info(string format, params object[] args)
        {
            throw new NotImplementedException();
        }*/
        public void Debug(string message)
        {
                log.Debug(message);
        }
        public void Debug(Student st)
        {

            foreach (PropertyInfo prop in typeof(Student).GetProperties())
            {
                log.Debug(st.GetType().ToString() + prop.Name + ": " + prop.GetValue(st));
            }
        }
        public void Warn(string message)
        {
                log.Warning(message);
        }
        public void Error(string message)
        {
                log.Error(message);
        }
        public void Fatal(string message)
        {
                log.Fatal(message);
        }
        
        #endregion


        #region exceptions
        public void Exception(Exception exception, string message)
        {
                log.Error(message, exception);
        }
        public void Exception(Exception exception, string format, params object[] args)
        {
            throw new NotImplementedException();
        }
        public void EmailException(string message)
        {
            SmtpClient client = new SmtpClient();
            client.Send("enric.pedros@atmira.com", "enric.pedros@atmira.com", "Error", message);
        }
        #endregion


    }
}
