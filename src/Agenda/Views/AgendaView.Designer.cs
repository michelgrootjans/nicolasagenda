﻿namespace Agendas.Views
{
    partial class AgendaView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.btnVandaag = new System.Windows.Forms.Button();
            this.btnNieuweTaak = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNieuweTaak);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.dateTimePicker);
            this.panel1.Controls.Add(this.btnVandaag);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 695);
            this.panel1.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(12, 217);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(131, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(12, 41);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(131, 20);
            this.dateTimePicker.TabIndex = 1;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // btnVandaag
            // 
            this.btnVandaag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVandaag.Location = new System.Drawing.Point(12, 12);
            this.btnVandaag.Name = "btnVandaag";
            this.btnVandaag.Size = new System.Drawing.Size(131, 23);
            this.btnVandaag.TabIndex = 0;
            this.btnVandaag.Text = "Vandaag";
            this.btnVandaag.UseVisualStyleBackColor = true;
            this.btnVandaag.Click += new System.EventHandler(this.btnVandaag_Click);
            // 
            // btnNieuweTaak
            // 
            this.btnNieuweTaak.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNieuweTaak.Location = new System.Drawing.Point(12, 98);
            this.btnNieuweTaak.Name = "btnNieuweTaak";
            this.btnNieuweTaak.Size = new System.Drawing.Size(131, 23);
            this.btnNieuweTaak.TabIndex = 3;
            this.btnNieuweTaak.Text = "Nieuwe Taak ...";
            this.btnNieuweTaak.UseVisualStyleBackColor = true;
            this.btnNieuweTaak.Click += new System.EventHandler(this.btnNieuweTaak_Click);
            // 
            // AgendaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 695);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "AgendaView";
            this.Text = "Agenda";
            this.Load += new System.EventHandler(this.AgendaView_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVandaag;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnNieuweTaak;
    }
}

