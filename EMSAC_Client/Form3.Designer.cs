namespace EMSAC_Client
{
    partial class Form3
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SAIR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_ativos = new System.Windows.Forms.Label();
            this.label_recuperados = new System.Windows.Forms.Label();
            this.label_obitos = new System.Windows.Forms.Label();
            this.label_confirmados = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_uci = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label_internados = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "Registar Casos";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(0, 105);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 54);
            this.button2.TabIndex = 1;
            this.button2.Text = "Importar Ficheiro";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(0, 192);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 54);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(0, 276);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 54);
            this.button4.TabIndex = 3;
            this.button4.Text = "Estatísticas";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // SAIR
            // 
            this.SAIR.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SAIR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SAIR.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAIR.Location = new System.Drawing.Point(0, 353);
            this.SAIR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SAIR.Name = "SAIR";
            this.SAIR.Size = new System.Drawing.Size(139, 54);
            this.SAIR.TabIndex = 5;
            this.SAIR.Text = "Sair";
            this.SAIR.UseVisualStyleBackColor = false;
            this.SAIR.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(249, 145);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Casos Ativos";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(249, 265);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(86, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Recuperados";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(463, 145);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(122, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Casos Confirmados";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(249, 207);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(46, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "Óbitos";
            // 
            // label_ativos
            // 
            this.label_ativos.AutoSize = true;
            this.label_ativos.Location = new System.Drawing.Point(256, 174);
            this.label_ativos.Name = "label_ativos";
            this.label_ativos.Size = new System.Drawing.Size(13, 13);
            this.label_ativos.TabIndex = 11;
            this.label_ativos.Text = "0";
            // 
            // label_recuperados
            // 
            this.label_recuperados.AutoSize = true;
            this.label_recuperados.Location = new System.Drawing.Point(256, 296);
            this.label_recuperados.Name = "label_recuperados";
            this.label_recuperados.Size = new System.Drawing.Size(13, 13);
            this.label_recuperados.TabIndex = 12;
            this.label_recuperados.Text = "0";
            // 
            // label_obitos
            // 
            this.label_obitos.AutoSize = true;
            this.label_obitos.Location = new System.Drawing.Point(256, 232);
            this.label_obitos.Name = "label_obitos";
            this.label_obitos.Size = new System.Drawing.Size(13, 13);
            this.label_obitos.TabIndex = 13;
            this.label_obitos.Text = "0";
            // 
            // label_confirmados
            // 
            this.label_confirmados.AutoSize = true;
            this.label_confirmados.Location = new System.Drawing.Point(470, 168);
            this.label_confirmados.Name = "label_confirmados";
            this.label_confirmados.Size = new System.Drawing.Size(13, 13);
            this.label_confirmados.TabIndex = 14;
            this.label_confirmados.Text = "0";
            this.label_confirmados.Click += new System.EventHandler(this.label_confirmados_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(247, 9);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(233, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "Dashboard Covid-19 EMSAC";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label_uci
            // 
            this.label_uci.AutoSize = true;
            this.label_uci.Location = new System.Drawing.Point(470, 294);
            this.label_uci.Name = "label_uci";
            this.label_uci.Size = new System.Drawing.Size(13, 13);
            this.label_uci.TabIndex = 19;
            this.label_uci.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(463, 265);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(116, 14);
            this.label9.TabIndex = 18;
            this.label9.Text = "Internados em UCI";
            // 
            // label_internados
            // 
            this.label_internados.AutoSize = true;
            this.label_internados.Location = new System.Drawing.Point(470, 228);
            this.label_internados.Name = "label_internados";
            this.label_internados.Size = new System.Drawing.Size(13, 13);
            this.label_internados.TabIndex = 21;
            this.label_internados.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(463, 207);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(70, 14);
            this.label11.TabIndex = 20;
            this.label11.Text = "Internados";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(247, 117);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(223, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Situação Pandémica Portugal";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 421);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_internados);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label_uci);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_confirmados);
            this.Controls.Add(this.label_obitos);
            this.Controls.Add(this.label_recuperados);
            this.Controls.Add(this.label_ativos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SAIR);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button SAIR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_ativos;
        private System.Windows.Forms.Label label_recuperados;
        private System.Windows.Forms.Label label_obitos;
        private System.Windows.Forms.Label label_confirmados;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_uci;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_internados;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
    }
}