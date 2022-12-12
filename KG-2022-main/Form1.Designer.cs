namespace Lab1_kg_
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comparisonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pSNRToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sSIMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binarizatsiyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.niblackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pinpointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lab3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonlocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lawsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gLCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pSNRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.кореляцияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.контрастToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 47);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(322, 327);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.filtersToolStripMenuItem,
            this.comparisonToolStripMenuItem1,
            this.binarizatsiyaToolStripMenuItem,
            this.lab3ToolStripMenuItem,
            this.gistToolStripMenuItem,
            this.lawsToolStripMenuItem,
            this.rToolStripMenuItem,
            this.gLCToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1082, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click_1);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoToolStripMenuItem,
            this.grayToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.addToolStripMenuItem.Text = "add";
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.autoToolStripMenuItem.Text = "Auto";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // grayToolStripMenuItem
            // 
            this.grayToolStripMenuItem.Name = "grayToolStripMenuItem";
            this.grayToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.grayToolStripMenuItem.Text = "avg";
            this.grayToolStripMenuItem.Click += new System.EventHandler(this.grayToolStripMenuItem_Click);
            // 
            // comparisonToolStripMenuItem1
            // 
            this.comparisonToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pSNRToolStripMenuItem1,
            this.sSIMToolStripMenuItem});
            this.comparisonToolStripMenuItem1.Name = "comparisonToolStripMenuItem1";
            this.comparisonToolStripMenuItem1.Size = new System.Drawing.Size(87, 20);
            this.comparisonToolStripMenuItem1.Text = "Comparison ";
            // 
            // pSNRToolStripMenuItem1
            // 
            this.pSNRToolStripMenuItem1.Name = "pSNRToolStripMenuItem1";
            this.pSNRToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.pSNRToolStripMenuItem1.Text = "PSNR";
            this.pSNRToolStripMenuItem1.Click += new System.EventHandler(this.pSNRToolStripMenuItem1_Click);
            // 
            // sSIMToolStripMenuItem
            // 
            this.sSIMToolStripMenuItem.Name = "sSIMToolStripMenuItem";
            this.sSIMToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.sSIMToolStripMenuItem.Text = "SSIM";
            this.sSIMToolStripMenuItem.Click += new System.EventHandler(this.sSIMToolStripMenuItem_Click);
            // 
            // binarizatsiyaToolStripMenuItem
            // 
            this.binarizatsiyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.niblackToolStripMenuItem,
            this.globalToolStripMenuItem,
            this.pinpointToolStripMenuItem});
            this.binarizatsiyaToolStripMenuItem.Name = "binarizatsiyaToolStripMenuItem";
            this.binarizatsiyaToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.binarizatsiyaToolStripMenuItem.Text = "Binar";
            // 
            // niblackToolStripMenuItem
            // 
            this.niblackToolStripMenuItem.Name = "niblackToolStripMenuItem";
            this.niblackToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.niblackToolStripMenuItem.Text = "Niblack";
            this.niblackToolStripMenuItem.Click += new System.EventHandler(this.niblackToolStripMenuItem_Click);
            // 
            // globalToolStripMenuItem
            // 
            this.globalToolStripMenuItem.Name = "globalToolStripMenuItem";
            this.globalToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.globalToolStripMenuItem.Text = "Global";
            this.globalToolStripMenuItem.Click += new System.EventHandler(this.globalToolStripMenuItem_Click);
            // 
            // pinpointToolStripMenuItem
            // 
            this.pinpointToolStripMenuItem.Name = "pinpointToolStripMenuItem";
            this.pinpointToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.pinpointToolStripMenuItem.Text = "Pinpoint";
            this.pinpointToolStripMenuItem.Click += new System.EventHandler(this.pinpointToolStripMenuItem_Click);
            // 
            // lab3ToolStripMenuItem
            // 
            this.lab3ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nonlocalToolStripMenuItem,
            this.expToolStripMenuItem,
            this.whiteToolStripMenuItem});
            this.lab3ToolStripMenuItem.Name = "lab3ToolStripMenuItem";
            this.lab3ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.lab3ToolStripMenuItem.Text = "lab3";
            // 
            // nonlocalToolStripMenuItem
            // 
            this.nonlocalToolStripMenuItem.Name = "nonlocalToolStripMenuItem";
            this.nonlocalToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.nonlocalToolStripMenuItem.Text = "nonlocal ";
            this.nonlocalToolStripMenuItem.Click += new System.EventHandler(this.nonlocalToolStripMenuItem_Click);
            // 
            // expToolStripMenuItem
            // 
            this.expToolStripMenuItem.Name = "expToolStripMenuItem";
            this.expToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.expToolStripMenuItem.Text = "Exp";
            this.expToolStripMenuItem.Click += new System.EventHandler(this.expToolStripMenuItem_Click_1);
            // 
            // whiteToolStripMenuItem
            // 
            this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            this.whiteToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.whiteToolStripMenuItem.Text = "White";
            this.whiteToolStripMenuItem.Click += new System.EventHandler(this.whiteToolStripMenuItem_Click);
            // 
            // gistToolStripMenuItem
            // 
            this.gistToolStripMenuItem.Name = "gistToolStripMenuItem";
            this.gistToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.gistToolStripMenuItem.Text = "Hist";
            this.gistToolStripMenuItem.Click += new System.EventHandler(this.gistToolStripMenuItem_Click);
            // 
            // lawsToolStripMenuItem
            // 
            this.lawsToolStripMenuItem.Name = "lawsToolStripMenuItem";
            this.lawsToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.lawsToolStripMenuItem.Text = "Laws";
            this.lawsToolStripMenuItem.Click += new System.EventHandler(this.lawsToolStripMenuItem_Click);
            // 
            // rToolStripMenuItem
            // 
            this.rToolStripMenuItem.Name = "rToolStripMenuItem";
            this.rToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.rToolStripMenuItem.Text = "Region";
            this.rToolStripMenuItem.Click += new System.EventHandler(this.rToolStripMenuItem_Click);
            // 
            // gLCToolStripMenuItem
            // 
            this.gLCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.кореляцияToolStripMenuItem,
            this.aSMToolStripMenuItem,
            this.контрастToolStripMenuItem});
            this.gLCToolStripMenuItem.Name = "gLCToolStripMenuItem";
            this.gLCToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.gLCToolStripMenuItem.Text = "GLCM";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            // 
            // pSNRToolStripMenuItem
            // 
            this.pSNRToolStripMenuItem.Name = "pSNRToolStripMenuItem";
            this.pSNRToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(352, 47);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(322, 327);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(695, 47);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(311, 327);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // кореляцияToolStripMenuItem
            // 
            this.кореляцияToolStripMenuItem.Name = "кореляцияToolStripMenuItem";
            this.кореляцияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.кореляцияToolStripMenuItem.Text = "Корреляция";
            this.кореляцияToolStripMenuItem.Click += new System.EventHandler(this.кореляцияToolStripMenuItem_Click);
            // 
            // aSMToolStripMenuItem
            // 
            this.aSMToolStripMenuItem.Name = "aSMToolStripMenuItem";
            this.aSMToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aSMToolStripMenuItem.Text = "ASM";
            this.aSMToolStripMenuItem.Click += new System.EventHandler(this.aSMToolStripMenuItem_Click);
            // 
            // контрастToolStripMenuItem
            // 
            this.контрастToolStripMenuItem.Name = "контрастToolStripMenuItem";
            this.контрастToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.контрастToolStripMenuItem.Text = "Контраст";
            this.контрастToolStripMenuItem.Click += new System.EventHandler(this.контрастToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 396);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Filters";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pSNRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comparisonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pSNRToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sSIMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binarizatsiyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem niblackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ToolStripMenuItem lab3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonlocalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pinpointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gistToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem lawsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gLCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кореляцияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aSMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem контрастToolStripMenuItem;
    }
}

