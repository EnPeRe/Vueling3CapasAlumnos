using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic;
using Vueling.Common.Logic.CommonResources;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.Common.Logic.Models;
using System.Data.SqlClient;
using System.Data;
using Vueling.DataAccess.Dao.Interfaces;
using Microsoft.SqlServer.Server;

namespace Vueling.DataAccess.Dao
{
    public class StudentDaoClr : ARepository
    {
        private readonly Logger logger = new Logger();
        private readonly string conectionstring = "Data Source = AM-BCN-POR-378; Initial Catalog = StudentDB; Trusted_Connection=yes; Integrated Security = SSPI";

        private SqlCommand cmd;
        private SqlConnection conn;

        private Student studentread;
        private List<Student> liststudents;

        public override Student Add(Student student)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                using (conn = new SqlConnection(conectionstring))
                {
                    using (cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "InsertStudent";
                        cmd.Parameters.AddWithValue("@Guid", student.Student_Guid.ToString());
                        cmd.Parameters.AddWithValue("@Nombre", student.Nombre);
                        cmd.Parameters.AddWithValue("@Apellidos", student.Apellido);
                        cmd.Parameters.AddWithValue("@Edad", student.Edad);
                        cmd.Parameters.AddWithValue("@Dni", student.Dni);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", student.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@HoraRegistro", student.HoraRegistro);

                        conn.Open();

                        //cmd.Prepare();

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.CommandText = "SELECT @@IDENTITY";

                        studentread = SelectStudentForAddMethod(conn, student.Student_Guid);
                    }
                }
            }
            catch (System.Security.SecurityException e)
            {
                logger.Error(e.StackTrace + e.Message);
                throw;
            }

            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            return studentread;
        }

        private Student SelectStudentForAddMethod(SqlConnection conn, Guid studentguid)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            Student st = new Student();

            try
            {
                using (cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SelectStudentbyGuid";
                    cmd.Parameters.AddWithValue("@Guid", studentguid);
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            st.IdAlumno = (int)rdr["Id"];
                            st.Nombre = rdr["Nombre"].ToString();
                            st.Apellido = rdr["Apellidos"].ToString();
                            st.Edad = (int)rdr["Edad"];
                            st.Dni = rdr["Dni"].ToString();
                            st.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                            st.HoraRegistro = Convert.ToDateTime(rdr["HoraRegistro"]);
                            st.Student_Guid = rdr.GetGuid(rdr.GetOrdinal("Student_Guid"));
                        }
                    }
                }
            }
            catch (System.Security.SecurityException e)
            {
                logger.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }

            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            return st;
        }

        public override List<Student> ReadAll()
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            liststudents = new List<Student>();

            try
            {
                using (conn = new SqlConnection(conectionstring))
                {
                    using (cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "SelectAllStudent";
                        conn.Open();
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                Student st = new Student();
                                st.IdAlumno = (int)rdr["Id"];
                                st.Nombre = rdr["Nombre"].ToString();
                                st.Apellido = rdr["Apellidos"].ToString();
                                st.Edad = (int)rdr["Edad"];
                                st.Dni = rdr["Dni"].ToString();
                                st.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                                st.HoraRegistro = Convert.ToDateTime(rdr["HoraRegistro"]);
                                st.Student_Guid = rdr.GetGuid(rdr.GetOrdinal("Student_Guid"));

                                liststudents.Add(st);
                            }
                        }
                    }
                }
            }
            catch (System.Security.SecurityException e)
            {
                logger.Error("Error en el metodo GetStudentFromJsonByGuid()" + e.Message);
                throw;
            }

            logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            return liststudents;
        }

        public override int DeleteById(int id)
        {
            logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

            liststudents = new List<Student>();
            string sql = "DELETE * FROM dbo.Students WHERE Id = @Id";
            int rowsdeleted;
            try
            {
                using (conn = new SqlConnection(conectionstring))
                {
                    using (cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        rowsdeleted = cmd.ExecuteNonQuery();
                    }
                }
            }catch(InvalidCastException ex)
            {
                logger.Error(new StringBuilder(ex.StackTrace).Append(ex.Message).ToString());
                throw;
            }
            return rowsdeleted;
        }

        public override int UpdateById(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
