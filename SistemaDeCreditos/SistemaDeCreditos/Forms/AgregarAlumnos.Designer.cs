namespace SistemaDeCreditos.Forms
{
    partial class AgregarAlumnos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbNumControl = new System.Windows.Forms.TextBox();
            this.lbAlumnos = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbSemestre = new System.Windows.Forms.ComboBox();
            this.tbAño = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbJefes = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dtOficio = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnComprobar = new System.Windows.Forms.Button();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnAll = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.pnLeft.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnAll.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbNumControl
            // 
            this.tbNumControl.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.tbNumControl.Location = new System.Drawing.Point(21, 125);
            this.tbNumControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbNumControl.Name = "tbNumControl";
            this.tbNumControl.Size = new System.Drawing.Size(303, 33);
            this.tbNumControl.TabIndex = 0;
            this.tbNumControl.TextChanged += new System.EventHandler(this.tbNumControl_TextChanged);
            // 
            // lbAlumnos
            // 
            this.lbAlumnos.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.lbAlumnos.FormattingEnabled = true;
            this.lbAlumnos.ItemHeight = 23;
            this.lbAlumnos.Location = new System.Drawing.Point(21, 249);
            this.lbAlumnos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbAlumnos.Name = "lbAlumnos";
            this.lbAlumnos.Size = new System.Drawing.Size(303, 326);
            this.lbAlumnos.TabIndex = 1;
            this.lbAlumnos.SelectedIndexChanged += new System.EventHandler(this.lbAlumnos_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbSemestre);
            this.groupBox1.Controls.Add(this.tbAño);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 285);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(511, 148);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Periodo";
            // 
            // cbSemestre
            // 
            this.cbSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSemestre.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSemestre.FormattingEnabled = true;
            this.cbSemestre.ItemHeight = 23;
            this.cbSemestre.Items.AddRange(new object[] {
            "ENERO - JUNIO",
            "VERANO",
            "AGOSTO - DICIEMBRE"});
            this.cbSemestre.Location = new System.Drawing.Point(195, 66);
            this.cbSemestre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbSemestre.Name = "cbSemestre";
            this.cbSemestre.Size = new System.Drawing.Size(282, 31);
            this.cbSemestre.TabIndex = 7;
            // 
            // tbAño
            // 
            this.tbAño.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAño.Location = new System.Drawing.Point(7, 66);
            this.tbAño.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbAño.MaxLength = 9999;
            this.tbAño.Name = "tbAño";
            this.tbAño.Size = new System.Drawing.Size(151, 33);
            this.tbAño.TabIndex = 6;
            this.tbAño.TextChanged += new System.EventHandler(this.tbAño_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 24);
            this.label8.TabIndex = 14;
            this.label8.Text = "Año";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(192, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 24);
            this.label9.TabIndex = 15;
            this.label9.Text = "Semestre";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(22, 535);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(510, 59);
            this.btnSalir.TabIndex = 25;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 24);
            this.label5.TabIndex = 26;
            this.label5.Text = "Jefe";
            // 
            // cbJefes
            // 
            this.cbJefes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJefes.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbJefes.FormattingEnabled = true;
            this.cbJefes.Location = new System.Drawing.Point(24, 120);
            this.cbJefes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbJefes.Name = "cbJefes";
            this.cbJefes.Size = new System.Drawing.Size(509, 31);
            this.cbJefes.TabIndex = 19;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(133)))), ((int)(((byte)(37)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(22, 469);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(510, 59);
            this.btnAgregar.TabIndex = 23;
            this.btnAgregar.Text = "AGREGAR ALUMNOS";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dtOficio
            // 
            this.dtOficio.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtOficio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtOficio.Location = new System.Drawing.Point(22, 211);
            this.dtOficio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtOficio.Name = "dtOficio";
            this.dtOficio.Size = new System.Drawing.Size(510, 33);
            this.dtOficio.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 24);
            this.label6.TabIndex = 24;
            this.label6.Text = "Fecha de oficio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.label1.Location = new System.Drawing.Point(17, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 24);
            this.label1.TabIndex = 27;
            this.label1.Text = "Número de control";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnComprobar
            // 
            this.btnComprobar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(133)))), ((int)(((byte)(37)))));
            this.btnComprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprobar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprobar.ForeColor = System.Drawing.Color.White;
            this.btnComprobar.Location = new System.Drawing.Point(21, 175);
            this.btnComprobar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnComprobar.Name = "btnComprobar";
            this.btnComprobar.Size = new System.Drawing.Size(304, 50);
            this.btnComprobar.TabIndex = 28;
            this.btnComprobar.Text = "AGREGAR";
            this.btnComprobar.UseVisualStyleBackColor = false;
            this.btnComprobar.Click += new System.EventHandler(this.btnComprobar_Click);
            // 
            // pnLeft
            // 
            this.pnLeft.Controls.Add(this.panel2);
            this.pnLeft.Controls.Add(this.label1);
            this.pnLeft.Controls.Add(this.btnComprobar);
            this.pnLeft.Controls.Add(this.tbNumControl);
            this.pnLeft.Controls.Add(this.lbAlumnos);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeft.Location = new System.Drawing.Point(0, 0);
            this.pnLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(349, 612);
            this.pnLeft.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(349, 64);
            this.panel2.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 26);
            this.label2.TabIndex = 28;
            this.label2.Text = "AGREGAR ALUMNOS";
            // 
            // pnAll
            // 
            this.pnAll.BackColor = System.Drawing.Color.White;
            this.pnAll.Controls.Add(this.panel1);
            this.pnAll.Controls.Add(this.cbJefes);
            this.pnAll.Controls.Add(this.label6);
            this.pnAll.Controls.Add(this.groupBox1);
            this.pnAll.Controls.Add(this.dtOficio);
            this.pnAll.Controls.Add(this.btnSalir);
            this.pnAll.Controls.Add(this.btnAgregar);
            this.pnAll.Controls.Add(this.label5);
            this.pnAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnAll.Location = new System.Drawing.Point(349, 0);
            this.pnAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnAll.Name = "pnAll";
            this.pnAll.Size = new System.Drawing.Size(553, 612);
            this.pnAll.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 64);
            this.panel1.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 26);
            this.label3.TabIndex = 31;
            this.label3.Text = "DATOS DE LA ACTIVIDAD";
            // 
            // AgregarAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 612);
            this.Controls.Add(this.pnAll);
            this.Controls.Add(this.pnLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(924, 668);
            this.MinimumSize = new System.Drawing.Size(924, 668);
            this.Name = "AgregarAlumnos";
            this.Text = "Agregar alumnos al grupo";
            this.Load += new System.EventHandler(this.AgregarAlumnos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnLeft.ResumeLayout(false);
            this.pnLeft.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnAll.ResumeLayout(false);
            this.pnAll.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbNumControl;
        private System.Windows.Forms.ListBox lbAlumnos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbSemestre;
        private System.Windows.Forms.TextBox tbAño;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbJefes;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DateTimePicker dtOficio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnComprobar;
        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Panel pnAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}