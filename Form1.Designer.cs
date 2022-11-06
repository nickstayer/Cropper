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
            this.textBoxDropable = new System.Windows.Forms.TextBox();
            this.comboBoxDeps = new System.Windows.Forms.ComboBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPage = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonSave = new System.Windows.Forms.Button();
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
            this.textBoxDropable.Location = new System.Drawing.Point(0, 29);
            this.textBoxDropable.Multiline = true;
            this.textBoxDropable.Name = "textBoxDropable";
            this.textBoxDropable.Size = new System.Drawing.Size(240, 81);
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
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(0, 114);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(82, 15);
            this.labelFileName.TabIndex = 3;
            this.labelFileName.Text = "labelFileName";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPage);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(248, 161);
            this.tabControlMain.TabIndex = 4;
            this.tabControlMain.Tag = "11";
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.comboBoxDeps);
            this.tabPage.Controls.Add(this.labelFileName);
            this.tabPage.Controls.Add(this.textBoxDropable);
            this.tabPage.Location = new System.Drawing.Point(4, 24);
            this.tabPage.Name = "tabPage";
            this.tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage.Size = new System.Drawing.Size(240, 133);
            this.tabPage.TabIndex = 0;
            this.tabPage.Text = "Главная";
            this.tabPage.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonSave);
            this.tabPage2.Controls.Add(this.textBoxFileSample);
            this.tabPage2.Controls.Add(this.textBoxSubDepartmentsCount);
            this.tabPage2.Controls.Add(this.labelFileSample);
            this.tabPage2.Controls.Add(this.labelSubDepartmentsCount);
            this.tabPage2.Controls.Add(this.textBoxMainDepartment);
            this.tabPage2.Controls.Add(this.labelMainDepartment);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(240, 133);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Настройки";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(87, 102);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxFileSample
            // 
            this.textBoxFileSample.AllowDrop = true;
            this.textBoxFileSample.Location = new System.Drawing.Point(102, 52);
            this.textBoxFileSample.Name = "textBoxFileSample";
            this.textBoxFileSample.Size = new System.Drawing.Size(138, 23);
            this.textBoxFileSample.TabIndex = 5;
            this.textBoxFileSample.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxFileSample_DragDrop);
            this.textBoxFileSample.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxFileSample_DragEnter);
            this.textBoxFileSample.DragOver += new System.Windows.Forms.DragEventHandler(this.textBoxFileSample_DragOver);
            this.textBoxFileSample.DragLeave += new System.EventHandler(this.textBoxFileSample_DragLeave);
            // 
            // textBoxSubDepartmentsCount
            // 
            this.textBoxSubDepartmentsCount.Location = new System.Drawing.Point(102, 26);
            this.textBoxSubDepartmentsCount.Name = "textBoxSubDepartmentsCount";
            this.textBoxSubDepartmentsCount.Size = new System.Drawing.Size(138, 23);
            this.textBoxSubDepartmentsCount.TabIndex = 4;
            // 
            // labelFileSample
            // 
            this.labelFileSample.AutoSize = true;
            this.labelFileSample.Location = new System.Drawing.Point(0, 55);
            this.labelFileSample.Name = "labelFileSample";
            this.labelFileSample.Size = new System.Drawing.Size(92, 15);
            this.labelFileSample.TabIndex = 3;
            this.labelFileSample.Text = "Образец файла";
            // 
            // labelSubDepartmentsCount
            // 
            this.labelSubDepartmentsCount.AutoSize = true;
            this.labelSubDepartmentsCount.Location = new System.Drawing.Point(0, 29);
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
            this.ClientSize = new System.Drawing.Size(248, 161);
            this.Controls.Add(this.tabControlMain);
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

        }

        #endregion

        private TextBox textBoxDropable;
        private ComboBox comboBoxDeps;
        private Label labelFileName;
        private TabControl tabControlMain;
        private TabPage tabPage;
        private TabPage tabPage2;
        private Button buttonSave;
        private TextBox textBoxFileSample;
        private TextBox textBoxSubDepartmentsCount;
        private Label labelFileSample;
        private Label labelSubDepartmentsCount;
        private TextBox textBoxMainDepartment;
        private Label labelMainDepartment;
    }
}