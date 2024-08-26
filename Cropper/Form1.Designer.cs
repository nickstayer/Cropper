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
            this.cbDepartments = new System.Windows.Forms.ComboBox();
            this.textBoxDropable = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.cbEncodings = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbDepartments
            // 
            this.cbDepartments.FormattingEnabled = true;
            this.cbDepartments.Location = new System.Drawing.Point(10, 9);
            this.cbDepartments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbDepartments.Name = "cbDepartments";
            this.cbDepartments.Size = new System.Drawing.Size(227, 23);
            this.cbDepartments.TabIndex = 0;
            // 
            // textBoxDropable
            // 
            this.textBoxDropable.AllowDrop = true;
            this.textBoxDropable.Location = new System.Drawing.Point(10, 34);
            this.textBoxDropable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDropable.Multiline = true;
            this.textBoxDropable.Name = "textBoxDropable";
            this.textBoxDropable.Size = new System.Drawing.Size(227, 55);
            this.textBoxDropable.TabIndex = 1;
            this.textBoxDropable.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxDropable_DragDrop);
            this.textBoxDropable.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxDropable_DragEnter);
            this.textBoxDropable.DragOver += new System.Windows.Forms.DragEventHandler(this.textBoxDropable_DragOver);
            this.textBoxDropable.DragLeave += new System.EventHandler(this.textBoxDropable_DragLeave);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(10, 138);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(38, 15);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "label1";
            // 
            // cbEncodings
            // 
            this.cbEncodings.FormattingEnabled = true;
            this.cbEncodings.Location = new System.Drawing.Point(9, 110);
            this.cbEncodings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbEncodings.Name = "cbEncodings";
            this.cbEncodings.Size = new System.Drawing.Size(227, 23);
            this.cbEncodings.TabIndex = 3;
            this.cbEncodings.SelectedIndexChanged += new System.EventHandler(this.cbEncodings_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Кодировка:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 160);
            this.Controls.Add(this.cbEncodings);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxDropable);
            this.Controls.Add(this.cbDepartments);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Tag = "";
            this.Text = "Cropper 4.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cbDepartments;
        private TextBox textBoxDropable;
        private Label labelStatus;
        private ComboBox cbEncodings;
        private Label label1;
    }
}