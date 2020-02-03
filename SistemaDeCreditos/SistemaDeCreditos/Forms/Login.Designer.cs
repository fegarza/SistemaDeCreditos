namespace SistemaDeCreditos.Forms
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pnLoad = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pcxd = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnBody = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLogin3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnClave = new System.Windows.Forms.Panel();
            this.tbClave = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcxd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnBody.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnClave.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnLoad
            // 
            this.pnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(108)))), ((int)(((byte)(199)))));
            this.pnLoad.Controls.Add(this.label4);
            this.pnLoad.Controls.Add(this.label3);
            this.pnLoad.Controls.Add(this.pcxd);
            this.pnLoad.Location = new System.Drawing.Point(-8, 12);
            this.pnLoad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnLoad.Name = "pnLoad";
            this.pnLoad.Size = new System.Drawing.Size(711, 764);
            this.pnLoad.TabIndex = 26;
            this.pnLoad.Visible = false;
            this.pnLoad.Paint += new System.Windows.Forms.PaintEventHandler(this.pnLoad_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(214, 490);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 34);
            this.label4.TabIndex = 27;
            this.label4.Text = "POR FAVOR ESPERE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(63, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(595, 43);
            this.label3.TabIndex = 26;
            this.label3.Text = "INICIANDO SISTEMA DE CRÉDITOS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // pcxd
            // 
            this.pcxd.Image = ((System.Drawing.Image)(resources.GetObject("pcxd.Image")));
            this.pcxd.Location = new System.Drawing.Point(-2, 356);
            this.pcxd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pcxd.Name = "pcxd";
            this.pcxd.Size = new System.Drawing.Size(706, 121);
            this.pcxd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcxd.TabIndex = 25;
            this.pcxd.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(0, 12);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(656, 75);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cbUsuario
            // 
            this.cbUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cbUsuario.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuario.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUsuario.ForeColor = System.Drawing.Color.Black;
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.Location = new System.Drawing.Point(0, 70);
            this.cbUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(656, 47);
            this.cbUsuario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(-2, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione su usuario";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::SistemaDeCreditos.Properties.Resources.developer;
            this.pictureBox1.Location = new System.Drawing.Point(22, 25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(22, 25, 22, 25);
            this.pictureBox1.Size = new System.Drawing.Size(656, 265);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pnBody
            // 
            this.pnBody.BackColor = System.Drawing.Color.White;
            this.pnBody.Controls.Add(this.panel4);
            this.pnBody.Controls.Add(this.panel3);
            this.pnBody.Controls.Add(this.panel1);
            this.pnBody.Controls.Add(this.panel2);
            this.pnBody.Controls.Add(this.pictureBox1);
            this.pnBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBody.Location = new System.Drawing.Point(0, 12);
            this.pnBody.Margin = new System.Windows.Forms.Padding(0);
            this.pnBody.Name = "pnBody";
            this.pnBody.Padding = new System.Windows.Forms.Padding(22, 25, 22, 25);
            this.pnBody.Size = new System.Drawing.Size(700, 740);
            this.pnBody.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSalir);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(22, 639);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.panel4.Size = new System.Drawing.Size(656, 99);
            this.panel4.TabIndex = 24;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnLogin3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(22, 540);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.panel3.Size = new System.Drawing.Size(656, 99);
            this.panel3.TabIndex = 3;
            this.panel3.TabStop = true;
            // 
            // btnLogin3
            // 
            this.btnLogin3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(133)))), ((int)(((byte)(37)))));
            this.btnLogin3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogin3.FlatAppearance.BorderSize = 0;
            this.btnLogin3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin3.ForeColor = System.Drawing.Color.White;
            this.btnLogin3.Location = new System.Drawing.Point(0, 12);
            this.btnLogin3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.btnLogin3.Name = "btnLogin3";
            this.btnLogin3.Size = new System.Drawing.Size(656, 75);
            this.btnLogin3.TabIndex = 3;
            this.btnLogin3.Text = "ENTRAR";
            this.btnLogin3.UseVisualStyleBackColor = false;
            this.btnLogin3.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnClave);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(22, 432);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.panel1.Size = new System.Drawing.Size(656, 108);
            this.panel1.TabIndex = 2;
            this.panel1.TabStop = true;
            // 
            // pnClave
            // 
            this.pnClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnClave.Controls.Add(this.tbClave);
            this.pnClave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnClave.Location = new System.Drawing.Point(0, 24);
            this.pnClave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnClave.Name = "pnClave";
            this.pnClave.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.pnClave.Size = new System.Drawing.Size(656, 59);
            this.pnClave.TabIndex = 8;
            // 
            // tbClave
            // 
            this.tbClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.tbClave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbClave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbClave.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClave.ForeColor = System.Drawing.Color.Black;
            this.tbClave.Location = new System.Drawing.Point(11, 12);
            this.tbClave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbClave.Name = "tbClave";
            this.tbClave.PasswordChar = '•';
            this.tbClave.Size = new System.Drawing.Size(634, 34);
            this.tbClave.TabIndex = 2;
            this.tbClave.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbClave_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(-2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Introduzca la clave de acceso";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbUsuario);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(22, 290);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.panel2.Size = new System.Drawing.Size(656, 142);
            this.panel2.TabIndex = 1;
            this.panel2.TabStop = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(108)))), ((int)(((byte)(199)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(700, 752);
            this.Controls.Add(this.pnLoad);
            this.Controls.Add(this.pnBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Login";
            this.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autentificación del sistema de créditos";
            this.Load += new System.EventHandler(this.Login_Load);
            this.pnLoad.ResumeLayout(false);
            this.pnLoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcxd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnBody.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnClave.ResumeLayout(false);
            this.pnClave.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnLoad;
 
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pcxd;
        private System.Windows.Forms.Panel pnBody;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogin3;
        private System.Windows.Forms.Panel pnClave;
        private System.Windows.Forms.TextBox tbClave;
        private System.Windows.Forms.Label label2;
    }
}