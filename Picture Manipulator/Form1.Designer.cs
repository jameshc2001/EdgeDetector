namespace Picture_Manipulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.toleranceTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.processImageBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.brightnessTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.brightnessProcessBtn = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.sharpenProcessBtn = new System.Windows.Forms.Button();
            this.sharpenTimesTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.filterProcessBtn = new System.Windows.Forms.Button();
            this.filter9 = new System.Windows.Forms.TextBox();
            this.filter8 = new System.Windows.Forms.TextBox();
            this.filter7 = new System.Windows.Forms.TextBox();
            this.filter6 = new System.Windows.Forms.TextBox();
            this.filter5 = new System.Windows.Forms.TextBox();
            this.filter4 = new System.Windows.Forms.TextBox();
            this.filter3 = new System.Windows.Forms.TextBox();
            this.filter2 = new System.Windows.Forms.TextBox();
            this.filter1 = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.grayCheckBox = new System.Windows.Forms.CheckBox();
            this.whiteCheckBox = new System.Windows.Forms.CheckBox();
            this.thresholdTxtBox = new System.Windows.Forms.TextBox();
            this.thresholdCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.sobelProcessBtn = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.gaussian3x3Btn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.CannyProcessBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.highThresholdTxtBox = new System.Windows.Forms.TextBox();
            this.lowThresholdTxtBox = new System.Windows.Forms.TextBox();
            this.customThresholdCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileBtn
            // 
            this.openFileBtn.Location = new System.Drawing.Point(95, 379);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(75, 23);
            this.openFileBtn.TabIndex = 0;
            this.openFileBtn.Text = "Open File";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 360);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 384);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Original Image:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(669, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(243, 250);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.toleranceTxtBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.processImageBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(235, 224);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Laplace";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 156);
            this.label3.TabIndex = 3;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // toleranceTxtBox
            // 
            this.toleranceTxtBox.Location = new System.Drawing.Point(70, 5);
            this.toleranceTxtBox.Name = "toleranceTxtBox";
            this.toleranceTxtBox.Size = new System.Drawing.Size(100, 20);
            this.toleranceTxtBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tolerance:";
            // 
            // processImageBtn
            // 
            this.processImageBtn.Location = new System.Drawing.Point(9, 195);
            this.processImageBtn.Name = "processImageBtn";
            this.processImageBtn.Size = new System.Drawing.Size(93, 23);
            this.processImageBtn.TabIndex = 0;
            this.processImageBtn.Text = "Process Image";
            this.processImageBtn.UseVisualStyleBackColor = true;
            this.processImageBtn.Click += new System.EventHandler(this.processImageBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.brightnessTxtBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.brightnessProcessBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(235, 224);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Brightness";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // brightnessTxtBox
            // 
            this.brightnessTxtBox.Location = new System.Drawing.Point(72, 6);
            this.brightnessTxtBox.Name = "brightnessTxtBox";
            this.brightnessTxtBox.Size = new System.Drawing.Size(100, 20);
            this.brightnessTxtBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Brightness:";
            // 
            // brightnessProcessBtn
            // 
            this.brightnessProcessBtn.Location = new System.Drawing.Point(6, 195);
            this.brightnessProcessBtn.Name = "brightnessProcessBtn";
            this.brightnessProcessBtn.Size = new System.Drawing.Size(92, 23);
            this.brightnessProcessBtn.TabIndex = 0;
            this.brightnessProcessBtn.Text = "Process Image";
            this.brightnessProcessBtn.UseVisualStyleBackColor = true;
            this.brightnessProcessBtn.Click += new System.EventHandler(this.brightnessProcessBtn_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.sharpenProcessBtn);
            this.tabPage3.Controls.Add(this.sharpenTimesTxtBox);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(235, 224);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sharpen";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // sharpenProcessBtn
            // 
            this.sharpenProcessBtn.Location = new System.Drawing.Point(6, 198);
            this.sharpenProcessBtn.Name = "sharpenProcessBtn";
            this.sharpenProcessBtn.Size = new System.Drawing.Size(98, 23);
            this.sharpenProcessBtn.TabIndex = 2;
            this.sharpenProcessBtn.Text = "Process Image";
            this.sharpenProcessBtn.UseVisualStyleBackColor = true;
            this.sharpenProcessBtn.Click += new System.EventHandler(this.sharpenProcessBtn_Click);
            // 
            // sharpenTimesTxtBox
            // 
            this.sharpenTimesTxtBox.Location = new System.Drawing.Point(97, 6);
            this.sharpenTimesTxtBox.Name = "sharpenTimesTxtBox";
            this.sharpenTimesTxtBox.Size = new System.Drawing.Size(100, 20);
            this.sharpenTimesTxtBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Times to perform:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.customThresholdCheckBox);
            this.tabPage4.Controls.Add(this.lowThresholdTxtBox);
            this.tabPage4.Controls.Add(this.highThresholdTxtBox);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.CannyProcessBtn);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(235, 224);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Canny";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.filterProcessBtn);
            this.tabPage5.Controls.Add(this.filter9);
            this.tabPage5.Controls.Add(this.filter8);
            this.tabPage5.Controls.Add(this.filter7);
            this.tabPage5.Controls.Add(this.filter6);
            this.tabPage5.Controls.Add(this.filter5);
            this.tabPage5.Controls.Add(this.filter4);
            this.tabPage5.Controls.Add(this.filter3);
            this.tabPage5.Controls.Add(this.filter2);
            this.tabPage5.Controls.Add(this.filter1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(235, 224);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "3x3 Filter";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // filterProcessBtn
            // 
            this.filterProcessBtn.Location = new System.Drawing.Point(13, 187);
            this.filterProcessBtn.Name = "filterProcessBtn";
            this.filterProcessBtn.Size = new System.Drawing.Size(95, 23);
            this.filterProcessBtn.TabIndex = 9;
            this.filterProcessBtn.Text = "Process Image";
            this.filterProcessBtn.UseVisualStyleBackColor = true;
            this.filterProcessBtn.Click += new System.EventHandler(this.filterProcessBtn_Click);
            // 
            // filter9
            // 
            this.filter9.Location = new System.Drawing.Point(65, 64);
            this.filter9.Name = "filter9";
            this.filter9.Size = new System.Drawing.Size(20, 20);
            this.filter9.TabIndex = 8;
            // 
            // filter8
            // 
            this.filter8.Location = new System.Drawing.Point(39, 64);
            this.filter8.Name = "filter8";
            this.filter8.Size = new System.Drawing.Size(20, 20);
            this.filter8.TabIndex = 7;
            // 
            // filter7
            // 
            this.filter7.Location = new System.Drawing.Point(13, 64);
            this.filter7.Name = "filter7";
            this.filter7.Size = new System.Drawing.Size(20, 20);
            this.filter7.TabIndex = 6;
            // 
            // filter6
            // 
            this.filter6.Location = new System.Drawing.Point(65, 38);
            this.filter6.Name = "filter6";
            this.filter6.Size = new System.Drawing.Size(20, 20);
            this.filter6.TabIndex = 5;
            // 
            // filter5
            // 
            this.filter5.Location = new System.Drawing.Point(39, 38);
            this.filter5.Name = "filter5";
            this.filter5.Size = new System.Drawing.Size(20, 20);
            this.filter5.TabIndex = 4;
            // 
            // filter4
            // 
            this.filter4.Location = new System.Drawing.Point(13, 38);
            this.filter4.Name = "filter4";
            this.filter4.Size = new System.Drawing.Size(20, 20);
            this.filter4.TabIndex = 3;
            // 
            // filter3
            // 
            this.filter3.Location = new System.Drawing.Point(65, 12);
            this.filter3.Name = "filter3";
            this.filter3.Size = new System.Drawing.Size(20, 20);
            this.filter3.TabIndex = 2;
            // 
            // filter2
            // 
            this.filter2.Location = new System.Drawing.Point(39, 12);
            this.filter2.Name = "filter2";
            this.filter2.Size = new System.Drawing.Size(20, 20);
            this.filter2.TabIndex = 1;
            // 
            // filter1
            // 
            this.filter1.Location = new System.Drawing.Point(13, 12);
            this.filter1.Name = "filter1";
            this.filter1.Size = new System.Drawing.Size(20, 20);
            this.filter1.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.grayCheckBox);
            this.tabPage6.Controls.Add(this.whiteCheckBox);
            this.tabPage6.Controls.Add(this.thresholdTxtBox);
            this.tabPage6.Controls.Add(this.thresholdCheckBox);
            this.tabPage6.Controls.Add(this.label6);
            this.tabPage6.Controls.Add(this.sobelProcessBtn);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(235, 224);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Sobel";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // grayCheckBox
            // 
            this.grayCheckBox.AutoSize = true;
            this.grayCheckBox.Location = new System.Drawing.Point(14, 80);
            this.grayCheckBox.Name = "grayCheckBox";
            this.grayCheckBox.Size = new System.Drawing.Size(73, 17);
            this.grayCheckBox.TabIndex = 5;
            this.grayCheckBox.Text = "Grayscale";
            this.grayCheckBox.UseVisualStyleBackColor = true;
            // 
            // whiteCheckBox
            // 
            this.whiteCheckBox.AutoSize = true;
            this.whiteCheckBox.Location = new System.Drawing.Point(14, 56);
            this.whiteCheckBox.Name = "whiteCheckBox";
            this.whiteCheckBox.Size = new System.Drawing.Size(84, 17);
            this.whiteCheckBox.TabIndex = 4;
            this.whiteCheckBox.Text = "Make White";
            this.whiteCheckBox.UseVisualStyleBackColor = true;
            // 
            // thresholdTxtBox
            // 
            this.thresholdTxtBox.Location = new System.Drawing.Point(71, 33);
            this.thresholdTxtBox.Name = "thresholdTxtBox";
            this.thresholdTxtBox.Size = new System.Drawing.Size(100, 20);
            this.thresholdTxtBox.TabIndex = 3;
            // 
            // thresholdCheckBox
            // 
            this.thresholdCheckBox.AutoSize = true;
            this.thresholdCheckBox.Location = new System.Drawing.Point(14, 14);
            this.thresholdCheckBox.Name = "thresholdCheckBox";
            this.thresholdCheckBox.Size = new System.Drawing.Size(95, 17);
            this.thresholdCheckBox.TabIndex = 2;
            this.thresholdCheckBox.Text = "Use Threshold";
            this.thresholdCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Threshold:";
            // 
            // sobelProcessBtn
            // 
            this.sobelProcessBtn.Location = new System.Drawing.Point(14, 185);
            this.sobelProcessBtn.Name = "sobelProcessBtn";
            this.sobelProcessBtn.Size = new System.Drawing.Size(101, 23);
            this.sobelProcessBtn.TabIndex = 0;
            this.sobelProcessBtn.Text = "Process Image";
            this.sobelProcessBtn.UseVisualStyleBackColor = true;
            this.sobelProcessBtn.Click += new System.EventHandler(this.sobelProcessBtn_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.gaussian3x3Btn);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(235, 224);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "3x3 Gaussian";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // gaussian3x3Btn
            // 
            this.gaussian3x3Btn.Location = new System.Drawing.Point(3, 198);
            this.gaussian3x3Btn.Name = "gaussian3x3Btn";
            this.gaussian3x3Btn.Size = new System.Drawing.Size(100, 23);
            this.gaussian3x3Btn.TabIndex = 0;
            this.gaussian3x3Btn.Text = "Process Image";
            this.gaussian3x3Btn.UseVisualStyleBackColor = true;
            this.gaussian3x3Btn.Click += new System.EventHandler(this.gaussian3x3Btn_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // CannyProcessBtn
            // 
            this.CannyProcessBtn.Location = new System.Drawing.Point(3, 198);
            this.CannyProcessBtn.Name = "CannyProcessBtn";
            this.CannyProcessBtn.Size = new System.Drawing.Size(104, 23);
            this.CannyProcessBtn.TabIndex = 0;
            this.CannyProcessBtn.Text = "Process Image";
            this.CannyProcessBtn.UseVisualStyleBackColor = true;
            this.CannyProcessBtn.Click += new System.EventHandler(this.CannyProcessBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "High Threshold:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Low Threshold:";
            // 
            // highThresholdTxtBox
            // 
            this.highThresholdTxtBox.Location = new System.Drawing.Point(108, 20);
            this.highThresholdTxtBox.Name = "highThresholdTxtBox";
            this.highThresholdTxtBox.Size = new System.Drawing.Size(100, 20);
            this.highThresholdTxtBox.TabIndex = 3;
            this.highThresholdTxtBox.Text = "0";
            // 
            // lowThresholdTxtBox
            // 
            this.lowThresholdTxtBox.Location = new System.Drawing.Point(108, 44);
            this.lowThresholdTxtBox.Name = "lowThresholdTxtBox";
            this.lowThresholdTxtBox.Size = new System.Drawing.Size(100, 20);
            this.lowThresholdTxtBox.TabIndex = 4;
            this.lowThresholdTxtBox.Text = "0";
            // 
            // customThresholdCheckBox
            // 
            this.customThresholdCheckBox.AutoSize = true;
            this.customThresholdCheckBox.Location = new System.Drawing.Point(23, 70);
            this.customThresholdCheckBox.Name = "customThresholdCheckBox";
            this.customThresholdCheckBox.Size = new System.Drawing.Size(138, 17);
            this.customThresholdCheckBox.TabIndex = 5;
            this.customThresholdCheckBox.Text = "Use Custom Thresholds";
            this.customThresholdCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 410);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.openFileBtn);
            this.Name = "Form1";
            this.Text = "Picture Manipulator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button processImageBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox toleranceTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox brightnessTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button brightnessProcessBtn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button sharpenProcessBtn;
        private System.Windows.Forms.TextBox sharpenTimesTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox filter9;
        private System.Windows.Forms.TextBox filter8;
        private System.Windows.Forms.TextBox filter7;
        private System.Windows.Forms.TextBox filter6;
        private System.Windows.Forms.TextBox filter5;
        private System.Windows.Forms.TextBox filter4;
        private System.Windows.Forms.TextBox filter3;
        private System.Windows.Forms.TextBox filter2;
        private System.Windows.Forms.TextBox filter1;
        private System.Windows.Forms.Button filterProcessBtn;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button sobelProcessBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox whiteCheckBox;
        private System.Windows.Forms.TextBox thresholdTxtBox;
        private System.Windows.Forms.CheckBox thresholdCheckBox;
        private System.Windows.Forms.CheckBox grayCheckBox;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button gaussian3x3Btn;
        private System.Windows.Forms.Button CannyProcessBtn;
        private System.Windows.Forms.TextBox lowThresholdTxtBox;
        private System.Windows.Forms.TextBox highThresholdTxtBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox customThresholdCheckBox;
    }
}

