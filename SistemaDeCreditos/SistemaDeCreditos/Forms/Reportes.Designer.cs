namespace SistemaDeCreditos.Forms
{
    partial class Reportes
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCarrera = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.pnAll = new System.Windows.Forms.Panel();
            this.pnRight = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVer = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.lbReportes = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.tbTitulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbSemestre = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            this.pnAll.SuspendLayout();
            this.pnRight.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(543, 72);
            this.panel2.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(174, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(196, 28);
            this.label8.TabIndex = 2;
            this.label8.Text = "NUEVO REPORTE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(28, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 30);
            this.label1.TabIndex = 19;
            this.label1.Text = "Carrera";
            // 
            // cbCarrera
            // 
            this.cbCarrera.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbCarrera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCarrera.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCarrera.FormattingEnabled = true;
            this.cbCarrera.Location = new System.Drawing.Point(32, 160);
            this.cbCarrera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbCarrera.Name = "cbCarrera";
            this.cbCarrera.Size = new System.Drawing.Size(484, 33);
            this.cbCarrera.TabIndex = 20;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnGenerar.FlatAppearance.BorderSize = 0;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.Location = new System.Drawing.Point(32, 412);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(484, 59);
            this.btnGenerar.TabIndex = 27;
            this.btnGenerar.Text = "GENERAR REPORTE";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // pnAll
            // 
            this.pnAll.Controls.Add(this.pnRight);
            this.pnAll.Controls.Add(this.pnLeft);
            this.pnAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnAll.Location = new System.Drawing.Point(0, 0);
            this.pnAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnAll.Name = "pnAll";
            this.pnAll.Size = new System.Drawing.Size(1731, 1256);
            this.pnAll.TabIndex = 34;
            // 
            // pnRight
            // 
            this.pnRight.BackColor = System.Drawing.Color.White;
            this.pnRight.Controls.Add(this.panel1);
            this.pnRight.Controls.Add(this.panel3);
            this.pnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRight.Location = new System.Drawing.Point(543, 0);
            this.pnRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnRight.Name = "pnRight";
            this.pnRight.Size = new System.Drawing.Size(1188, 1256);
            this.pnRight.TabIndex = 38;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnVer);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.lbReportes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15);
            this.panel1.Size = new System.Drawing.Size(1188, 1184);
            this.panel1.TabIndex = 29;
            // 
            // btnVer
            // 
            this.btnVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnVer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVer.FlatAppearance.BorderSize = 0;
            this.btnVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVer.ForeColor = System.Drawing.Color.White;
            this.btnVer.Location = new System.Drawing.Point(15, 499);
            this.btnVer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(1158, 66);
            this.btnVer.TabIndex = 28;
            this.btnVer.Text = "VER REPORTE";
            this.btnVer.UseVisualStyleBackColor = false;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.dtFecha);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(15, 383);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1158, 116);
            this.panel4.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Fecha que mostrara el reporte:";
            // 
            // dtFecha
            // 
            this.dtFecha.Location = new System.Drawing.Point(20, 66);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(311, 26);
            this.dtFecha.TabIndex = 0;
            // 
            // lbReportes
            // 
            this.lbReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReportes.FormattingEnabled = true;
            this.lbReportes.ItemHeight = 26;
            this.lbReportes.Location = new System.Drawing.Point(15, 15);
            this.lbReportes.Name = "lbReportes";
            this.lbReportes.Size = new System.Drawing.Size(1158, 368);
            this.lbReportes.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(37)))), ((int)(((byte)(44)))));
            this.panel3.Controls.Add(this.label10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1188, 72);
            this.panel3.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(41, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(246, 28);
            this.label10.TabIndex = 2;
            this.label10.Text = "REPORTES ANTIGUOS";
            // 
            // pnLeft
            // 
            this.pnLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnLeft.Controls.Add(this.tbTitulo);
            this.pnLeft.Controls.Add(this.label2);
            this.pnLeft.Controls.Add(this.panel2);
            this.pnLeft.Controls.Add(this.btnGenerar);
            this.pnLeft.Controls.Add(this.label9);
            this.pnLeft.Controls.Add(this.cbSemestre);
            this.pnLeft.Controls.Add(this.label1);
            this.pnLeft.Controls.Add(this.cbCarrera);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeft.Location = new System.Drawing.Point(0, 0);
            this.pnLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(543, 1256);
            this.pnLeft.TabIndex = 37;
            // 
            // tbTitulo
            // 
            this.tbTitulo.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitulo.Location = new System.Drawing.Point(32, 354);
            this.tbTitulo.Name = "tbTitulo";
            this.tbTitulo.Size = new System.Drawing.Size(485, 34);
            this.tbTitulo.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(31, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 30);
            this.label2.TabIndex = 37;
            this.label2.Text = "Titulo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(31, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 30);
            this.label9.TabIndex = 36;
            this.label9.Text = "Semestre:";
            // 
            // cbSemestre
            // 
            this.cbSemestre.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSemestre.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSemestre.FormattingEnabled = true;
            this.cbSemestre.Items.AddRange(new object[] {
            "Todos los semestres",
            "Primero ",
            "Segundo",
            "Tercero ",
            "Cuarto",
            "Quinto ",
            "Sexto",
            "Septimo ",
            "Octavo",
            "Noveno",
            "Decimo"});
            this.cbSemestre.Location = new System.Drawing.Point(32, 256);
            this.cbSemestre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbSemestre.Name = "cbSemestre";
            this.cbSemestre.Size = new System.Drawing.Size(485, 33);
            this.cbSemestre.TabIndex = 35;
            this.cbSemestre.SelectedIndexChanged += new System.EventHandler(this.cbSemestre_SelectedIndexChanged);
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1731, 1256);
            this.Controls.Add(this.pnAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnAll.ResumeLayout(false);
            this.pnRight.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnLeft.ResumeLayout(false);
            this.pnLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCarrera;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Panel pnAll;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbSemestre;
        private System.Windows.Forms.Panel pnRight;
        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lbReportes;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFecha;
    }
}