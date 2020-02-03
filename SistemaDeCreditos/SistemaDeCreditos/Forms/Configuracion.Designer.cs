namespace SistemaDeCreditos.Forms
{
    partial class Configuracion
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
            this.tbRuta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbServidor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBaseDeDatos = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbClave = new System.Windows.Forms.TextBox();
            this.btnTestear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbRuta
            // 
            this.tbRuta.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRuta.Location = new System.Drawing.Point(22, 75);
            this.tbRuta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbRuta.Name = "tbRuta";
            this.tbRuta.Size = new System.Drawing.Size(602, 27);
            this.tbRuta.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ruta de la base de datos DBF";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Servidor en SQL Server";
            // 
            // tbServidor
            // 
            this.tbServidor.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbServidor.Location = new System.Drawing.Point(26, 138);
            this.tbServidor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbServidor.Name = "tbServidor";
            this.tbServidor.Size = new System.Drawing.Size(602, 27);
            this.tbServidor.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre de la base de datos";
            // 
            // tbBaseDeDatos
            // 
            this.tbBaseDeDatos.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBaseDeDatos.Location = new System.Drawing.Point(26, 218);
            this.tbBaseDeDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbBaseDeDatos.Name = "tbBaseDeDatos";
            this.tbBaseDeDatos.Size = new System.Drawing.Size(602, 27);
            this.tbBaseDeDatos.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Usuario";
            // 
            // tbUsuario
            // 
            this.tbUsuario.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsuario.Location = new System.Drawing.Point(30, 300);
            this.tbUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(598, 27);
            this.tbUsuario.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Clave";
            // 
            // tbClave
            // 
            this.tbClave.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClave.Location = new System.Drawing.Point(26, 380);
            this.tbClave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbClave.Name = "tbClave";
            this.tbClave.Size = new System.Drawing.Size(602, 27);
            this.tbClave.TabIndex = 8;
            // 
            // btnTestear
            // 
            this.btnTestear.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestear.Location = new System.Drawing.Point(26, 434);
            this.btnTestear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTestear.Name = "btnTestear";
            this.btnTestear.Size = new System.Drawing.Size(602, 65);
            this.btnTestear.TabIndex = 10;
            this.btnTestear.Text = "Testear datos";
            this.btnTestear.UseVisualStyleBackColor = true;
            this.btnTestear.Click += new System.EventHandler(this.btnTestear_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(22, 521);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(606, 65);
            this.button1.TabIndex = 11;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 609);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTestear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbClave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbBaseDeDatos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbServidor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRuta);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Configuracion";
            this.Text = "Configuracion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRuta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbServidor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbBaseDeDatos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbClave;
        private System.Windows.Forms.Button btnTestear;
        private System.Windows.Forms.Button button1;
    }
}