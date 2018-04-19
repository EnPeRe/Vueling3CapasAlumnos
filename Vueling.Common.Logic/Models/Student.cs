using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;

namespace Vueling.Common.Logic.Models
{
    //[Serializable, XmlRoot("enric.pedros")]
    public class Student : VuelingModelObject
    {

        #region Properties
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public DateTime HoraRegistro { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public string SavedFormat { get; set; }
        public Guid Student_Guid { get; set; }
        #endregion

        #region constructors
        public Student()
        {
        }

        public Student(int id, string name, string surname, int edad, string dni, string datebirth)
        {
            this.IdAlumno = id;
            this.Nombre = name;
            this.Apellido = surname;
            this.Edad = edad;
            this.Dni = dni;
            this.FechaNacimiento = Convert.ToDateTime(datebirth);
        }

        public Student(string name, string surname, int edad, string dni, string datebirth)
        {
            this.Nombre = name;
            this.Apellido = surname;
            this.Edad = edad;
            this.Dni = dni;
            this.FechaNacimiento = Convert.ToDateTime(datebirth);
        }


        public Student(int id, string name, string surname, string fechanacimiento, int edad, string dateregister, string dni, string st_guid)
        {
            this.IdAlumno = id;
            this.Nombre = name;
            this.Apellido = surname;
            this.FechaNacimiento = Convert.ToDateTime(fechanacimiento);
            this.Edad = edad;
            this.Dni = dni;
            this.HoraRegistro = Convert.ToDateTime(dateregister);
            this.Student_Guid = Guid.Parse(st_guid);
        }
        #endregion

        #region ToFormat
        public override string ToString()
        {
            string tostring = this.IdAlumno + "," + this.Nombre + "," + this.Apellido + ","
                + this.FechaNacimiento + "," + this.Edad + "," 
                + this.HoraRegistro + "," + this.Dni + "," + this.Student_Guid;
            return tostring;
        }

        public override string ToJson()
        {
            return "[" + JsonConvert.SerializeObject(this) + "]";
        }

        public override string ToXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, this);
                return textWriter.ToString();
            }
        }
        #endregion

        #region Equals HashCode
        public override bool Equals(object obj)
        {
            var student = obj as Student;
            return student != null &&
                   IdAlumno == student.IdAlumno &&
                   Nombre == student.Nombre &&
                   Apellido == student.Apellido &&
                   Dni == student.Dni &&
                   FechaNacimiento == student.FechaNacimiento &&
                   Edad == student.Edad &&
                   HoraRegistro == student.HoraRegistro &&
                   SavedFormat == student.SavedFormat &&
                   Student_Guid.Equals(student.Student_Guid);
        }

        public override int GetHashCode()
        {
            var hashCode = 1336891488;
            hashCode = hashCode * -1521134295 + IdAlumno.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellido);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            hashCode = hashCode * -1521134295 + FechaNacimiento.GetHashCode();
            hashCode = hashCode * -1521134295 + Edad.GetHashCode();
            hashCode = hashCode * -1521134295 + HoraRegistro.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SavedFormat);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Student_Guid);
            return hashCode;
        }
        #endregion
    }
}
