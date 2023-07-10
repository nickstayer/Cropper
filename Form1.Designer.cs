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
            this.textBoxDropable = new System.Windows.Forms.TextBox();
            this.comboBoxDeps = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelFileEncoding = new System.Windows.Forms.Label();
            this.comboBoxFileEncoding = new System.Windows.Forms.ComboBox();
            this.textBoxFileSample = new System.Windows.Forms.TextBox();
            this.textBoxSubDepartmentsCount = new System.Windows.Forms.TextBox();
            this.labelFileSample = new System.Windows.Forms.Label();
            this.labelSubDepartmentsCount = new System.Windows.Forms.Label();
            this.textBoxMainDepartment = new System.Windows.Forms.TextBox();
            this.labelMainDepartment = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxDropable
            // 
            this.textBoxDropable.AllowDrop = true;
            this.textBoxDropable.Location = new System.Drawing.Point(0, 24);
            this.textBoxDropable.Multiline = true;
            this.textBoxDropable.Name = "textBoxDropable";
            this.textBoxDropable.Size = new System.Drawing.Size(240, 86);
            this.textBoxDropable.TabIndex = 0;
            this.textBoxDropable.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxDropable_DragDrop);
            this.textBoxDropable.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxDropable_DragEnter);
            this.textBoxDropable.DragOver += new System.Windows.Forms.DragEventHandler(this.textBoxDropable_DragOver);
            this.textBoxDropable.DragLeave += new System.EventHandler(this.textBoxDropable_DragLeave);
            // 
            // comboBoxDeps
            // 
            this.comboBoxDeps.FormattingEnabled = true;
            this.comboBoxDeps.Location = new System.Drawing.Point(0, 0);
            this.comboBoxDeps.Name = "comboBoxDeps";
            this.comboBoxDeps.Size = new System.Drawing.Size(240, 23);
            this.comboBoxDeps.TabIndex = 1;
            this.comboBoxDeps.Text = "Выделить ОВД?";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(4, 142);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(64, 15);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "labelStatus";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPage);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(248, 139);
            this.tabControlMain.TabIndex = 4;
            this.tabControlMain.Tag = "11";
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.comboBoxDeps);
            this.tabPage.Controls.Add(this.textBoxDropable);
            this.tabPage.Location = new System.Drawing.Point(4, 24);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(240, 111);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "Главная";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelFileEncoding);
            this.tabPage2.Controls.Add(this.comboBoxFileEncoding);
            this.tabPage2.Controls.Add(this.textBoxFileSample);
            this.tabPage2.Controls.Add(this.textBoxSubDepartmentsCount);
            this.tabPage2.Controls.Add(this.labelFileSample);
            this.tabPage2.Controls.Add(this.labelSubDepartmentsCount);
            this.tabPage2.Controls.Add(this.textBoxMainDepartment);
            this.tabPage2.Controls.Add(this.labelMainDepartment);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(240, 111);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Настройки";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelFileEncoding
            // 
            this.labelFileEncoding.AutoSize = true;
            this.labelFileEncoding.Location = new System.Drawing.Point(0, 47);
            this.labelFileEncoding.Name = "labelFileEncoding";
            this.labelFileEncoding.Size = new System.Drawing.Size(66, 15);
            this.labelFileEncoding.TabIndex = 7;
            this.labelFileEncoding.Text = "Кодировка";
            // 
            // comboBoxFileEncoding
            // 
            this.comboBoxFileEncoding.FormattingEnabled = true;
            this.comboBoxFileEncoding.Location = new System.Drawing.Point(102, 44);
            this.comboBoxFileEncoding.Name = "comboBoxFileEncoding";
            this.comboBoxFileEncoding.Size = new System.Drawing.Size(138, 23);
            this.comboBoxFileEncoding.TabIndex = 6;
            // 
            // textBoxFileSample
            // 
            this.textBoxFileSample.AllowDrop = true;
            this.textBoxFileSample.Location = new System.Drawing.Point(102, 64);
            this.textBoxFileSample.Multiline = true;
            this.textBoxFileSample.Name = "textBoxFileSample";
            this.textBoxFileSample.Size = new System.Drawing.Size(138, 47);
            this.textBoxFileSample.TabIndex = 5;
            this.textBoxFileSample.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxFileSample_DragDrop);
            this.textBoxFileSample.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxFileSample_DragEnter);
            this.textBoxFileSample.DragOver += new System.Windows.Forms.DragEventHandler(this.textBoxFileSample_DragOver);
            this.textBoxFileSample.DragLeave += new System.EventHandler(this.textBoxFileSample_DragLeave);
            // 
            // textBoxSubDepartmentsCount
            // 
            this.textBoxSubDepartmentsCount.Location = new System.Drawing.Point(102, 22);
            this.textBoxSubDepartmentsCount.Name = "textBoxSubDepartmentsCount";
            this.textBoxSubDepartmentsCount.Size = new System.Drawing.Size(138, 23);
            this.textBoxSubDepartmentsCount.TabIndex = 4;
            // 
            // labelFileSample
            // 
            this.labelFileSample.AutoSize = true;
            this.labelFileSample.Location = new System.Drawing.Point(0, 67);
            this.labelFileSample.Name = "labelFileSample";
            this.labelFileSample.Size = new System.Drawing.Size(92, 15);
            this.labelFileSample.TabIndex = 3;
            this.labelFileSample.Text = "Образец файла";
            // 
            // labelSubDepartmentsCount
            // 
            this.labelSubDepartmentsCount.AutoSize = true;
            this.labelSubDepartmentsCount.Location = new System.Drawing.Point(0, 25);
            this.labelSubDepartmentsCount.Name = "labelSubDepartmentsCount";
            this.labelSubDepartmentsCount.Size = new System.Drawing.Size(93, 15);
            this.labelSubDepartmentsCount.TabIndex = 2;
            this.labelSubDepartmentsCount.Text = "Количество ОП";
            // 
            // textBoxMainDepartment
            // 
            this.textBoxMainDepartment.Location = new System.Drawing.Point(102, 0);
            this.textBoxMainDepartment.Name = "textBoxMainDepartment";
            this.textBoxMainDepartment.Size = new System.Drawing.Size(138, 23);
            this.textBoxMainDepartment.TabIndex = 1;
            // 
            // labelMainDepartment
            // 
            this.labelMainDepartment.AutoSize = true;
            this.labelMainDepartment.Location = new System.Drawing.Point(0, 3);
            this.labelMainDepartment.Name = "labelMainDepartment";
            this.labelMainDepartment.Size = new System.Drawing.Size(86, 15);
            this.labelMainDepartment.TabIndex = 0;
            this.labelMainDepartment.Text = "Название ОВД";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 160);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.labelStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Tag = "";
            this.Text = "Cropper 2.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.tabPage.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxDropable;
        private ComboBox comboBoxDeps;
        private Label labelStatus;
        private TabControl tabControlMain;
        private TabPage tabPage;
        private TabPage tabPage2;
        private TextBox textBoxFileSample;
        private TextBox textBoxSubDepartmentsCount;
        private Label labelFileSample;
        private Label labelSubDepartmentsCount;
        private TextBox textBoxMainDepartment;
        private Label labelMainDepartment;
        private Label labelFileEncoding;
        private ComboBox comboBoxFileEncoding;
    }
}