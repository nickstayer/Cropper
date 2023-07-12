namespace Cropper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBoxDeps = new System.Windows.Forms.ComboBox();
            this.textBoxDropable = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxDeps
            // 
            this.comboBoxDeps.FormattingEnabled = true;
            this.comboBoxDeps.Location = new System.Drawing.Point(12, 12);
            this.comboBoxDeps.Name = "comboBoxDeps";
            this.comboBoxDeps.Size = new System.Drawing.Size(259, 28);
            this.comboBoxDeps.TabIndex = 0;
            // 
            // textBoxDropable
            // 
            this.textBoxDropable.AllowDrop = true;
            this.textBoxDropable.Location = new System.Drawing.Point(12, 46);
            this.textBoxDropable.Multiline = true;
            this.textBoxDropable.Name = "textBoxDropable";
            this.textBoxDropable.Size = new System.Drawing.Size(259, 135);
            this.textBoxDropable.TabIndex = 1;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 184);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(50, 20);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 213);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxDropable);
            this.Controls.Add(this.comboBoxDeps);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Tag = "";
            this.Text = "Cropper 3.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox comboBoxDeps;
        private TextBox textBoxDropable;
        private Label labelStatus;
    }
}