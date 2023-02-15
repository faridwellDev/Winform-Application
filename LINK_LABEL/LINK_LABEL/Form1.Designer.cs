namespace LINK_LABEL
{
    partial class Form1
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
            this.MyLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // MyLink
            // 
            this.MyLink.AutoSize = true;
            this.MyLink.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MyLink.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MyLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyLink.Location = new System.Drawing.Point(238, 211);
            this.MyLink.Name = "MyLink";
            this.MyLink.Size = new System.Drawing.Size(237, 22);
            this.MyLink.TabIndex = 0;
            this.MyLink.TabStop = true;
            this.MyLink.Text = "Click this link to open Form2";
            this.MyLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MyLink_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MyLink);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel MyLink;
    }
}

