namespace Vueling.Presentation.WinSite
{
    partial class StudentForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentForm));
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxApellidos = new System.Windows.Forms.TextBox();
            this.textBoxDni = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelDni = new System.Windows.Forms.Label();
            this.labelFechaNacimiento = new System.Windows.Forms.Label();
            this.textBoxFechaNacimiento = new System.Windows.Forms.TextBox();
            this.cbLanguages = new System.Windows.Forms.ComboBox();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.labelFormatAGuardar = new System.Windows.Forms.Label();
            this.labelFormat = new System.Windows.Forms.Label();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxId
            // 
            resources.ApplyResources(this.textBoxId, "textBoxId");
            this.textBoxId.Name = "textBoxId";
            // 
            // textBoxNombre
            // 
            resources.ApplyResources(this.textBoxNombre, "textBoxNombre");
            this.textBoxNombre.Name = "textBoxNombre";
            // 
            // textBoxApellidos
            // 
            resources.ApplyResources(this.textBoxApellidos, "textBoxApellidos");
            this.textBoxApellidos.Name = "textBoxApellidos";
            // 
            // textBoxDni
            // 
            resources.ApplyResources(this.textBoxDni, "textBoxDni");
            this.textBoxDni.Name = "textBoxDni";
            // 
            // labelId
            // 
            resources.ApplyResources(this.labelId, "labelId");
            this.labelId.Name = "labelId";
            // 
            // labelNombre
            // 
            resources.ApplyResources(this.labelNombre, "labelNombre");
            this.labelNombre.Name = "labelNombre";
            // 
            // labelApellido
            // 
            resources.ApplyResources(this.labelApellido, "labelApellido");
            this.labelApellido.Name = "labelApellido";
            // 
            // labelDni
            // 
            resources.ApplyResources(this.labelDni, "labelDni");
            this.labelDni.Name = "labelDni";
            // 
            // labelFechaNacimiento
            // 
            resources.ApplyResources(this.labelFechaNacimiento, "labelFechaNacimiento");
            this.labelFechaNacimiento.Name = "labelFechaNacimiento";
            // 
            // textBoxFechaNacimiento
            // 
            resources.ApplyResources(this.textBoxFechaNacimiento, "textBoxFechaNacimiento");
            this.textBoxFechaNacimiento.Name = "textBoxFechaNacimiento";
            // 
            // cbLanguages
            // 
            this.cbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguages.FormattingEnabled = true;
            this.cbLanguages.Items.AddRange(new object[] {
            resources.GetString("cbLanguages.Items"),
            resources.GetString("cbLanguages.Items1"),
            resources.GetString("cbLanguages.Items2")});
            resources.ApplyResources(this.cbLanguages, "cbLanguages");
            this.cbLanguages.Name = "cbLanguages";
            this.cbLanguages.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonGuardar
            // 
            resources.ApplyResources(this.buttonGuardar, "buttonGuardar");
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // labelFormatAGuardar
            // 
            resources.ApplyResources(this.labelFormatAGuardar, "labelFormatAGuardar");
            this.labelFormatAGuardar.Name = "labelFormatAGuardar";
            // 
            // labelFormat
            // 
            resources.ApplyResources(this.labelFormat, "labelFormat");
            this.labelFormat.Name = "labelFormat";
            // 
            // buttonModificar
            // 
            resources.ApplyResources(this.buttonModificar, "buttonModificar");
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonEliminar
            // 
            resources.ApplyResources(this.buttonEliminar, "buttonEliminar");
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // StudentForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.labelFormat);
            this.Controls.Add(this.labelFormatAGuardar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.cbLanguages);
            this.Controls.Add(this.textBoxFechaNacimiento);
            this.Controls.Add(this.labelFechaNacimiento);
            this.Controls.Add(this.labelDni);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.textBoxDni);
            this.Controls.Add(this.textBoxApellidos);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.textBoxId);
            this.Name = "StudentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxApellidos;
        private System.Windows.Forms.TextBox textBoxDni;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelDni;
        private System.Windows.Forms.Label labelFechaNacimiento;
        private System.Windows.Forms.TextBox textBoxFechaNacimiento;
        private System.Windows.Forms.ComboBox cbLanguages;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Label labelFormatAGuardar;
        private System.Windows.Forms.Label labelFormat;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonEliminar;
    }
}

