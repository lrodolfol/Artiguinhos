namespace Delegates
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtAvisos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(276, 25);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrar.TabIndex = 0;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(21, 26);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(249, 23);
            this.txtEmail.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email para avisos";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(169, 68);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(13, 15);
            this.lblMsg.TabIndex = 3;
            this.lblMsg.Text = "..";
            // 
            // txtAvisos
            // 
            this.txtAvisos.FormattingEnabled = true;
            this.txtAvisos.ItemHeight = 15;
            this.txtAvisos.Location = new System.Drawing.Point(1, 165);
            this.txtAvisos.Name = "txtAvisos";
            this.txtAvisos.Size = new System.Drawing.Size(402, 94);
            this.txtAvisos.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 262);
            this.Controls.Add(this.txtAvisos);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnCadastrar);
            this.Name = "Form1";
            this.Text = "CallBacks com Delegates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCadastrar;
        private TextBox txtEmail;
        private Label label1;
        private Label lblMsg;
        private ListBox txtAvisos;
    }
}