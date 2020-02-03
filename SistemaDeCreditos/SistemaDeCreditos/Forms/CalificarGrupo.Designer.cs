namespace SistemaDeCreditos.Forms
{
    partial class CalificarGrupo
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
            this.lbLeft = new System.Windows.Forms.ListBox();
            this.lbRight = new System.Windows.Forms.ListBox();
            this.btnCalificar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregarATodos = new System.Windows.Forms.Button();
            this.btnQuitarATodos = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLeft
            // 
            this.lbLeft.BackColor = System.Drawing.Color.White;
            this.lbLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbLeft.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeft.ForeColor = System.Drawing.Color.Black;
            this.lbLeft.FormattingEnabled = true;
            this.lbLeft.ItemHeight = 25;
            this.lbLeft.Location = new System.Drawing.Point(49, 85);
            this.lbLeft.Name = "lbLeft";
            this.lbLeft.Size = new System.Drawing.Size(497, 450);
            this.lbLeft.TabIndex = 0;
            this.lbLeft.SelectedIndexChanged += new System.EventHandler(this.lbLeft_SelectedIndexChanged);
            // 
            // lbRight
            // 
            this.lbRight.BackColor = System.Drawing.Color.White;
            this.lbRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbRight.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRight.ForeColor = System.Drawing.Color.Black;
            this.lbRight.FormattingEnabled = true;
            this.lbRight.ItemHeight = 25;
            this.lbRight.Location = new System.Drawing.Point(632, 85);
            this.lbRight.Name = "lbRight";
            this.lbRight.Size = new System.Drawing.Size(497, 450);
            this.lbRight.TabIndex = 3;
            this.lbRight.SelectedIndexChanged += new System.EventHandler(this.lbRight_SelectedIndexChanged);
            // 
            // btnCalificar
            // 
            this.btnCalificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(132)))), ((int)(((byte)(87)))));
            this.btnCalificar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCalificar.FlatAppearance.BorderSize = 0;
            this.btnCalificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalificar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalificar.ForeColor = System.Drawing.Color.White;
            this.btnCalificar.Location = new System.Drawing.Point(0, 634);
            this.btnCalificar.Name = "btnCalificar";
            this.btnCalificar.Size = new System.Drawing.Size(1181, 76);
            this.btnCalificar.TabIndex = 4;
            this.btnCalificar.Text = "CALIFICAR ALUMNOS SELECCIONADOS";
            this.btnCalificar.UseVisualStyleBackColor = false;
            this.btnCalificar.Click += new System.EventHandler(this.btnCalificar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(68)))), ((int)(((byte)(113)))));
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(49, 22);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(497, 62);
            this.panel2.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(108, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(264, 28);
            this.label8.TabIndex = 2;
            this.label8.Text = "ALUMNOS DEL GRUPO";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(68)))), ((int)(((byte)(113)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(632, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 62);
            this.panel1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(102, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "ALUMNOS A CALIFICAR";
            // 
            // btnAgregarATodos
            // 
            this.btnAgregarATodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(165)))), ((int)(((byte)(152)))));
            this.btnAgregarATodos.FlatAppearance.BorderSize = 0;
            this.btnAgregarATodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarATodos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarATodos.ForeColor = System.Drawing.Color.White;
            this.btnAgregarATodos.Location = new System.Drawing.Point(49, 539);
            this.btnAgregarATodos.Name = "btnAgregarATodos";
            this.btnAgregarATodos.Size = new System.Drawing.Size(497, 66);
            this.btnAgregarATodos.TabIndex = 18;
            this.btnAgregarATodos.Text = "AGREGAR A TODOS";
            this.btnAgregarATodos.UseVisualStyleBackColor = false;
            this.btnAgregarATodos.Click += new System.EventHandler(this.btnAgregarATodos_Click);
            // 
            // btnQuitarATodos
            // 
            this.btnQuitarATodos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(4)))), ((int)(((byte)(41)))));
            this.btnQuitarATodos.FlatAppearance.BorderSize = 0;
            this.btnQuitarATodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarATodos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarATodos.ForeColor = System.Drawing.Color.White;
            this.btnQuitarATodos.Location = new System.Drawing.Point(632, 539);
            this.btnQuitarATodos.Name = "btnQuitarATodos";
            this.btnQuitarATodos.Size = new System.Drawing.Size(497, 66);
            this.btnQuitarATodos.TabIndex = 19;
            this.btnQuitarATodos.Text = "QUITAR A TODOS";
            this.btnQuitarATodos.UseVisualStyleBackColor = false;
            this.btnQuitarATodos.Click += new System.EventHandler(this.btnQuitarATodos_Click);
            // 
            // CalificarGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 710);
            this.Controls.Add(this.btnQuitarATodos);
            this.Controls.Add(this.btnAgregarATodos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCalificar);
            this.Controls.Add(this.lbLeft);
            this.Controls.Add(this.lbRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(1203, 766);
            this.MinimumSize = new System.Drawing.Size(1203, 766);
            this.Name = "CalificarGrupo";
            this.Text = "CalificarGrupo";
            this.Load += new System.EventHandler(this.CalificarGrupo_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbLeft;
        private System.Windows.Forms.ListBox lbRight;
        private System.Windows.Forms.Button btnCalificar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregarATodos;
        private System.Windows.Forms.Button btnQuitarATodos;
    }
}