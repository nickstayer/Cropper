using System.Windows.Forms;

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
            cbDepartments = new ComboBox();
            textBoxDropableFilter = new TextBox();
            textBoxDropableMarker = new TextBox();
            labelStatus = new Label();
            cbEncodings = new ComboBox();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            btDownloadForms = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // cbDepartments
            // 
            cbDepartments.FormattingEnabled = true;
            cbDepartments.Location = new Point(1, 1);
            cbDepartments.Name = "cbDepartments";
            cbDepartments.Size = new Size(235, 23);
            cbDepartments.TabIndex = 0;
            // 
            // textBoxDropableFilter
            // 
            textBoxDropableFilter.AllowDrop = true;
            textBoxDropableFilter.Location = new Point(1, 26);
            textBoxDropableFilter.Multiline = true;
            textBoxDropableFilter.Name = "textBoxDropableFilter";
            textBoxDropableFilter.ScrollBars = ScrollBars.Vertical;
            textBoxDropableFilter.Size = new Size(235, 62);
            textBoxDropableFilter.TabIndex = 1;
            textBoxDropableFilter.DragDrop += TextBoxDropableFilter_DragDrop;
            textBoxDropableFilter.DragEnter += TextBoxDropable_DragEnter;
            textBoxDropableFilter.DragOver += TextBoxDropable_DragOver;
            textBoxDropableFilter.DragLeave += TextBoxDropable_DragLeave;
            // 
            // textBoxDropableMarker
            // 
            textBoxDropableMarker.AllowDrop = true;
            textBoxDropableMarker.Location = new Point(1, 1);
            textBoxDropableMarker.Multiline = true;
            textBoxDropableMarker.Name = "textBoxDropableMarker";
            textBoxDropableMarker.ScrollBars = ScrollBars.Vertical;
            textBoxDropableMarker.Size = new Size(235, 87);
            textBoxDropableMarker.TabIndex = 1;
            textBoxDropableMarker.DragDrop += TextBoxDropableMarker_DragDrop;
            textBoxDropableMarker.DragEnter += TextBoxDropable_DragEnter;
            textBoxDropableMarker.DragOver += TextBoxDropable_DragOver;
            textBoxDropableMarker.DragLeave += TextBoxDropable_DragLeave;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(10, 160);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(38, 15);
            labelStatus.TabIndex = 2;
            labelStatus.Text = "label1";
            // 
            // cbEncodings
            // 
            cbEncodings.FormattingEnabled = true;
            cbEncodings.Location = new Point(9, 132);
            cbEncodings.Name = "cbEncodings";
            cbEncodings.Size = new Size(227, 23);
            cbEncodings.TabIndex = 3;
            cbEncodings.SelectedIndexChanged += CbEncodings_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 115);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 2;
            label1.Text = "Кодировка:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(1, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(247, 113);
            tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(cbDepartments);
            tabPage1.Controls.Add(textBoxDropableFilter);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(239, 85);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Фильтр";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(textBoxDropableMarker);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(239, 85);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Маркер";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btDownloadForms);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(239, 85);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Скачать";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btDownloadForms
            // 
            btDownloadForms.Location = new Point(63, 28);
            btDownloadForms.Name = "btDownloadForms";
            btDownloadForms.Size = new Size(120, 25);
            btDownloadForms.TabIndex = 0;
            btDownloadForms.Text = "Скачать формы";
            btDownloadForms.Click += async (sender, e) => await DownloadForms(sender, e);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(248, 180);
            Controls.Add(tabControl1);
            Controls.Add(cbEncodings);
            Controls.Add(label1);
            Controls.Add(labelStatus);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Tag = "";
            Text = "ForManger";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbDepartments;
        private TextBox textBoxDropableFilter;
        private TextBox textBoxDropableMarker;
        private Label labelStatus;
        private ComboBox cbEncodings;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Button btDownloadForms;
    }
}