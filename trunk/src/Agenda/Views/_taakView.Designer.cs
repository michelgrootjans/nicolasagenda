namespace Agendas.Views
{
    partial class _taakView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.taken = new System.Windows.Forms.CheckedListBox();
            this.btnNieuweTaak = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // taken
            // 
            this.taken.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.taken.FormattingEnabled = true;
            this.taken.Location = new System.Drawing.Point(3, 40);
            this.taken.Name = "taken";
            this.taken.Size = new System.Drawing.Size(144, 109);
            this.taken.TabIndex = 0;
            this.taken.DoubleClick += new System.EventHandler(this.taken_DoubleClick);
            // 
            // btnNieuweTaak
            // 
            this.btnNieuweTaak.Location = new System.Drawing.Point(0, 3);
            this.btnNieuweTaak.Name = "btnNieuweTaak";
            this.btnNieuweTaak.Size = new System.Drawing.Size(145, 23);
            this.btnNieuweTaak.TabIndex = 4;
            this.btnNieuweTaak.Text = "Nieuwe Taak ...";
            this.btnNieuweTaak.UseVisualStyleBackColor = true;
            this.btnNieuweTaak.Click += new System.EventHandler(this.btnNieuweTaak_Click);
            // 
            // _taakView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNieuweTaak);
            this.Controls.Add(this.taken);
            this.Name = "_taakView";
            this.Load += new System.EventHandler(this._taakView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox taken;
        private System.Windows.Forms.Button btnNieuweTaak;
    }
}
