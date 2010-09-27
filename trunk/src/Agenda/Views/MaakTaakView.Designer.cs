namespace Agendas.Views
{
    partial class MaakTaakView : IMaakTaakView
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
            this.vakken = new System.Windows.Forms.ComboBox();
            this.dateDue = new System.Windows.Forms.DateTimePicker();
            this.txtInhoud = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // vakken
            // 
            this.vakken.FormattingEnabled = true;
            this.vakken.Location = new System.Drawing.Point(12, 12);
            this.vakken.Name = "vakken";
            this.vakken.Size = new System.Drawing.Size(109, 21);
            this.vakken.TabIndex = 0;
            // 
            // dateDue
            // 
            this.dateDue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateDue.Location = new System.Drawing.Point(127, 13);
            this.dateDue.Name = "dateDue";
            this.dateDue.Size = new System.Drawing.Size(183, 20);
            this.dateDue.TabIndex = 1;
            // 
            // txtInhoud
            // 
            this.txtInhoud.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInhoud.Location = new System.Drawing.Point(12, 65);
            this.txtInhoud.Multiline = true;
            this.txtInhoud.Name = "txtInhoud";
            this.txtInhoud.Size = new System.Drawing.Size(298, 90);
            this.txtInhoud.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(235, 161);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // MaakTaakView
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 196);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtInhoud);
            this.Controls.Add(this.dateDue);
            this.Controls.Add(this.vakken);
            this.Name = "MaakTaakView";
            this.Text = "MaakTaakView";
            this.Load += new System.EventHandler(this.MaakTaakView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox vakken;
        private System.Windows.Forms.DateTimePicker dateDue;
        private System.Windows.Forms.TextBox txtInhoud;
        private System.Windows.Forms.Button btnOk;
    }
}