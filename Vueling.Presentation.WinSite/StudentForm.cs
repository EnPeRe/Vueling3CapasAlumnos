using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Models;
using System.Reflection;
using Vueling.Common.Logic;
using Vueling.Common.Logic.LoggerAdapter;
using Vueling.Presentation.WinSite.Resources;
using System.Globalization;
using System.Threading;
using Vueling.Common.Logic.CommonResources;

namespace Vueling.Presentation.WinSite
{

    public partial class StudentForm : Form
    {
        private Student student;
        private IStudentBL studentBL;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static ITargetAdapterForLogger logger = new Logger();

        #region contructors
        public StudentForm()
        {
            InitializeComponent();
            student = new Student();
            studentBL = new StudentBL();
            AplicarIdioma();

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            string format = Environment.GetEnvironmentVariable("Saved_Format", EnvironmentVariableTarget.User);
            if (format == "sql" || format == "clr") this.InhabiliteId(); else this.HabiliteId();

            this.buttonModificar.Enabled = false;
            this.buttonGuardar.Enabled = true;
            this.buttonEliminar.Enabled = false;


            logger.Warn("Warning de proba");
            log.Warn("Error de proba");

            this.ChangeFormatLabel();
        }

        public StudentForm(string id, string name, string surname, string dni, string datebirth)
        {
            #region emptyconstructor
            InitializeComponent();


            student = new Student();
            studentBL = new StudentBL();
            AplicarIdioma();

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            string format = Environment.GetEnvironmentVariable("Saved_Format", EnvironmentVariableTarget.User);
            if (format == "sql" || format == "clr") this.InhabiliteId(); else this.HabiliteId();

            this.ChangeFormatLabel();
            #endregion

            this.textBoxId.Text = id;
            this.textBoxNombre.Text = name;
            this.textBoxApellidos.Text = surname;
            this.textBoxDni.Text = dni;
            this.textBoxFechaNacimiento.Text = datebirth;

            this.textBoxId.Enabled = false;
            this.buttonModificar.Enabled = true;
            this.buttonGuardar.Enabled = false;
            this.buttonEliminar.Enabled = true;
        }
        #endregion

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            this.SaveStudentData();

            try
            {
                studentBL.BusinessLogic(student);
            }
            catch (Exception ex)
            {
                MessageBox.Show(new StringBuilder(ex.StackTrace).Append(ex.Message).ToString());
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            this.SaveStudentData();

            studentBL.Delete(student);
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            this.SaveStudentData();

            studentBL.Update(student);

        }


        #region buttons a borrar
        private void buttonTxt_Click(object sender, EventArgs e)
        {
            this.SaveStudentData();

            try
            {
                studentBL.BusinessLogic(student);
            }
            catch (Exception ex)
            {
                MessageBox.Show(new StringBuilder(ex.StackTrace).Append(ex.Message).ToString());
            }
        }

        private void buttonJson_Click(object sender, EventArgs e)
        {
            this.SaveStudentData();

            try
            {
                studentBL.BusinessLogic(student);
            }
            catch (Exception ex)
            {
                MessageBox.Show(new StringBuilder(ex.StackTrace).Append(ex.Message).ToString());
            }
        }

        private void buttonXml_Click(object sender, EventArgs e)
        {
            this.SaveStudentData();

            try
            {
                studentBL.BusinessLogic(student);
            }
            catch (Exception ex)
            {
                MessageBox.Show(new StringBuilder(ex.StackTrace).Append(ex.Message).ToString());
            }
        }
        #endregion

        private void SaveStudentData()
        {
            try
            {
                logger.Debug(ResourceLogger.StartMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);

                student.Nombre = this.textBoxNombre.Text;
                if(textBoxId.Text != "") student.IdAlumno = Convert.ToInt32(this.textBoxId.Text);
                student.Apellido = this.textBoxApellidos.Text;
                student.FechaNacimiento = Convert.ToDateTime(this.textBoxFechaNacimiento.Text);
                student.Dni = this.textBoxDni.Text;
                student.Student_Guid = Guid.NewGuid();
                student.SavedFormat = Environment.GetEnvironmentVariable("Save_Format", EnvironmentVariableTarget.User);

                logger.Debug(ResourceLogger.EndMethod + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (FormatException e)
            {
                logger.Error(new StringBuilder(e.StackTrace).Append(e.Message).ToString());
            }
            catch (TargetException e)
            {
                logger.Error(new StringBuilder(e.StackTrace).Append(e.Message).ToString());
            }
            catch (OverflowException e)
            {
                logger.Error(new StringBuilder(e.StackTrace).Append(e.Message).ToString());
            }
        }

        #region idiomas
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cbLanguages.SelectedItem.ToString());
            AplicarIdioma();
        }

        public void AplicarIdioma()
        {
            labelId.Text = StringResources.labelId;
            labelNombre.Text = StringResources.labelNombre;
            labelApellido.Text = StringResources.labelApellido;
            labelDni.Text = StringResources.labelDni;
            labelFechaNacimiento.Text = StringResources.labelFechaNacimiento;
            this.Text = StringResources.FormName;
        }
        #endregion

        public void ChangeFormatLabel()
        {
            try
            {
                labelFormat.Text = Environment.GetEnvironmentVariable("Save_Format", EnvironmentVariableTarget.User).ToString();
            }
            catch (ArgumentNullException e)
            {
                logger.Error(new StringBuilder(e.StackTrace).Append(e.Message).ToString());
            }
            catch (ArgumentException e)
            {
                logger.Error(new StringBuilder(e.StackTrace).Append(e.Message).ToString());
            }
            catch (System.Security.SecurityException e)
            {
                logger.Error(new StringBuilder(e.StackTrace).Append(e.Message).ToString());
            }
        }

        public void InhabiliteId()
        {
            this.textBoxId.Enabled = false;
        }
        public void HabiliteId()
        {
            this.textBoxId.Enabled = true;
        }

    }
}
