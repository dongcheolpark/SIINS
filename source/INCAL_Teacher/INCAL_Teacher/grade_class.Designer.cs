namespace INCAL_Teacher
{
    partial class grade_class
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
            this.grade_group = new System.Windows.Forms.GroupBox();
            this.grade3_CheckBox = new System.Windows.Forms.CheckBox();
            this.grade2_CheckBox = new System.Windows.Forms.CheckBox();
            this.grade1_CheckBox = new System.Windows.Forms.CheckBox();
            this.class_GroupBox = new System.Windows.Forms.GroupBox();
            this.class9_CheckBox = new System.Windows.Forms.CheckBox();
            this.class8_CheckBox = new System.Windows.Forms.CheckBox();
            this.class7_CheckBox = new System.Windows.Forms.CheckBox();
            this.class6_CheckBox = new System.Windows.Forms.CheckBox();
            this.class5_CheckBox = new System.Windows.Forms.CheckBox();
            this.class4_CheckBox = new System.Windows.Forms.CheckBox();
            this.class3_CheckBox = new System.Windows.Forms.CheckBox();
            this.class2_CheckBox = new System.Windows.Forms.CheckBox();
            this.class1_CheckBox = new System.Windows.Forms.CheckBox();
            this.all_CheckBox = new System.Windows.Forms.CheckBox();
            this.grade_group.SuspendLayout();
            this.class_GroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // grade_group
            // 
            this.grade_group.Controls.Add(this.grade3_CheckBox);
            this.grade_group.Controls.Add(this.grade2_CheckBox);
            this.grade_group.Controls.Add(this.grade1_CheckBox);
            this.grade_group.Location = new System.Drawing.Point(12, 12);
            this.grade_group.Name = "grade_group";
            this.grade_group.Size = new System.Drawing.Size(433, 45);
            this.grade_group.TabIndex = 0;
            this.grade_group.TabStop = false;
            this.grade_group.Text = "학년";
            // 
            // grade3_CheckBox
            // 
            this.grade3_CheckBox.AutoSize = true;
            this.grade3_CheckBox.Location = new System.Drawing.Point(370, 17);
            this.grade3_CheckBox.Name = "grade3_CheckBox";
            this.grade3_CheckBox.Size = new System.Drawing.Size(54, 16);
            this.grade3_CheckBox.TabIndex = 2;
            this.grade3_CheckBox.Text = "3학년";
            this.grade3_CheckBox.UseVisualStyleBackColor = true;
            this.grade3_CheckBox.CheckedChanged += new System.EventHandler(this.grade3_CheckBox_CheckedChanged);
            // 
            // grade2_CheckBox
            // 
            this.grade2_CheckBox.AutoSize = true;
            this.grade2_CheckBox.Location = new System.Drawing.Point(186, 18);
            this.grade2_CheckBox.Name = "grade2_CheckBox";
            this.grade2_CheckBox.Size = new System.Drawing.Size(54, 16);
            this.grade2_CheckBox.TabIndex = 1;
            this.grade2_CheckBox.Text = "2학년";
            this.grade2_CheckBox.UseVisualStyleBackColor = true;
            this.grade2_CheckBox.CheckedChanged += new System.EventHandler(this.grade2_CheckBox_CheckedChanged);
            // 
            // grade1_CheckBox
            // 
            this.grade1_CheckBox.AutoSize = true;
            this.grade1_CheckBox.Location = new System.Drawing.Point(8, 18);
            this.grade1_CheckBox.Name = "grade1_CheckBox";
            this.grade1_CheckBox.Size = new System.Drawing.Size(54, 16);
            this.grade1_CheckBox.TabIndex = 0;
            this.grade1_CheckBox.Text = "1학년";
            this.grade1_CheckBox.UseVisualStyleBackColor = true;
            this.grade1_CheckBox.CheckedChanged += new System.EventHandler(this.grade1_checkbox_CheckedChanged);
            // 
            // class_GroupBox
            // 
            this.class_GroupBox.Controls.Add(this.all_CheckBox);
            this.class_GroupBox.Controls.Add(this.class9_CheckBox);
            this.class_GroupBox.Controls.Add(this.class8_CheckBox);
            this.class_GroupBox.Controls.Add(this.class7_CheckBox);
            this.class_GroupBox.Controls.Add(this.class6_CheckBox);
            this.class_GroupBox.Controls.Add(this.class5_CheckBox);
            this.class_GroupBox.Controls.Add(this.class4_CheckBox);
            this.class_GroupBox.Controls.Add(this.class3_CheckBox);
            this.class_GroupBox.Controls.Add(this.class2_CheckBox);
            this.class_GroupBox.Controls.Add(this.class1_CheckBox);
            this.class_GroupBox.Location = new System.Drawing.Point(12, 63);
            this.class_GroupBox.Name = "class_GroupBox";
            this.class_GroupBox.Size = new System.Drawing.Size(433, 194);
            this.class_GroupBox.TabIndex = 1;
            this.class_GroupBox.TabStop = false;
            this.class_GroupBox.Text = "학급";
            this.class_GroupBox.Enter += new System.EventHandler(this.class_GroupBox_Enter);
            // 
            // class9_CheckBox
            // 
            this.class9_CheckBox.AutoSize = true;
            this.class9_CheckBox.Location = new System.Drawing.Point(353, 132);
            this.class9_CheckBox.Name = "class9_CheckBox";
            this.class9_CheckBox.Size = new System.Drawing.Size(42, 16);
            this.class9_CheckBox.TabIndex = 8;
            this.class9_CheckBox.Text = "9반";
            this.class9_CheckBox.UseVisualStyleBackColor = true;
            this.class9_CheckBox.CheckedChanged += new System.EventHandler(this.class9_CheckBox_CheckedChanged);
            // 
            // class8_CheckBox
            // 
            this.class8_CheckBox.AutoSize = true;
            this.class8_CheckBox.Location = new System.Drawing.Point(190, 132);
            this.class8_CheckBox.Name = "class8_CheckBox";
            this.class8_CheckBox.Size = new System.Drawing.Size(42, 16);
            this.class8_CheckBox.TabIndex = 7;
            this.class8_CheckBox.Text = "8반";
            this.class8_CheckBox.UseVisualStyleBackColor = true;
            this.class8_CheckBox.CheckedChanged += new System.EventHandler(this.class8_CheckBox_CheckedChanged);
            // 
            // class7_CheckBox
            // 
            this.class7_CheckBox.AutoSize = true;
            this.class7_CheckBox.Location = new System.Drawing.Point(34, 132);
            this.class7_CheckBox.Name = "class7_CheckBox";
            this.class7_CheckBox.Size = new System.Drawing.Size(42, 16);
            this.class7_CheckBox.TabIndex = 6;
            this.class7_CheckBox.Text = "7반";
            this.class7_CheckBox.UseVisualStyleBackColor = true;
            this.class7_CheckBox.CheckedChanged += new System.EventHandler(this.class7_CheckBox_CheckedChanged);
            // 
            // class6_CheckBox
            // 
            this.class6_CheckBox.AutoSize = true;
            this.class6_CheckBox.Location = new System.Drawing.Point(353, 78);
            this.class6_CheckBox.Name = "class6_CheckBox";
            this.class6_CheckBox.Size = new System.Drawing.Size(42, 16);
            this.class6_CheckBox.TabIndex = 5;
            this.class6_CheckBox.Text = "6반";
            this.class6_CheckBox.UseVisualStyleBackColor = true;
            this.class6_CheckBox.CheckedChanged += new System.EventHandler(this.class6_CheckBox_CheckedChanged);
            // 
            // class5_CheckBox
            // 
            this.class5_CheckBox.AutoSize = true;
            this.class5_CheckBox.Location = new System.Drawing.Point(190, 78);
            this.class5_CheckBox.Name = "class5_CheckBox";
            this.class5_CheckBox.Size = new System.Drawing.Size(42, 16);
            this.class5_CheckBox.TabIndex = 4;
            this.class5_CheckBox.Text = "5반";
            this.class5_CheckBox.UseVisualStyleBackColor = true;
            this.class5_CheckBox.CheckedChanged += new System.EventHandler(this.class5_CheckBox_CheckedChanged);
            // 
            // class4_CheckBox
            // 
            this.class4_CheckBox.AutoSize = true;
            this.class4_CheckBox.Location = new System.Drawing.Point(34, 78);
            this.class4_CheckBox.Name = "class4_CheckBox";
            this.class4_CheckBox.Size = new System.Drawing.Size(42, 16);
            this.class4_CheckBox.TabIndex = 3;
            this.class4_CheckBox.Text = "4반";
            this.class4_CheckBox.UseVisualStyleBackColor = true;
            this.class4_CheckBox.CheckedChanged += new System.EventHandler(this.class4_CheckBox_CheckedChanged);
            // 
            // class3_CheckBox
            // 
            this.class3_CheckBox.AutoSize = true;
            this.class3_CheckBox.Location = new System.Drawing.Point(353, 27);
            this.class3_CheckBox.Name = "class3_CheckBox";
            this.class3_CheckBox.Size = new System.Drawing.Size(42, 16);
            this.class3_CheckBox.TabIndex = 2;
            this.class3_CheckBox.Text = "3반";
            this.class3_CheckBox.UseVisualStyleBackColor = true;
            this.class3_CheckBox.CheckedChanged += new System.EventHandler(this.class3_CheckBox_CheckedChanged);
            // 
            // class2_CheckBox
            // 
            this.class2_CheckBox.AutoSize = true;
            this.class2_CheckBox.Location = new System.Drawing.Point(190, 27);
            this.class2_CheckBox.Name = "class2_CheckBox";
            this.class2_CheckBox.Size = new System.Drawing.Size(42, 16);
            this.class2_CheckBox.TabIndex = 1;
            this.class2_CheckBox.Text = "2반";
            this.class2_CheckBox.UseVisualStyleBackColor = true;
            this.class2_CheckBox.CheckedChanged += new System.EventHandler(this.class2_CheckBox_CheckedChanged);
            // 
            // class1_CheckBox
            // 
            this.class1_CheckBox.AutoSize = true;
            this.class1_CheckBox.Location = new System.Drawing.Point(34, 27);
            this.class1_CheckBox.Name = "class1_CheckBox";
            this.class1_CheckBox.Size = new System.Drawing.Size(42, 16);
            this.class1_CheckBox.TabIndex = 0;
            this.class1_CheckBox.Text = "1반";
            this.class1_CheckBox.UseVisualStyleBackColor = true;
            this.class1_CheckBox.CheckedChanged += new System.EventHandler(this.class1_CheckBox_CheckedChanged);
            // 
            // all_CheckBox
            // 
            this.all_CheckBox.AutoSize = true;
            this.all_CheckBox.Location = new System.Drawing.Point(161, 172);
            this.all_CheckBox.Name = "all_CheckBox";
            this.all_CheckBox.Size = new System.Drawing.Size(92, 16);
            this.all_CheckBox.TabIndex = 9;
            this.all_CheckBox.Text = "모든 반 선택";
            this.all_CheckBox.UseVisualStyleBackColor = true;
            this.all_CheckBox.CheckedChanged += new System.EventHandler(this.all_CheckBox_CheckedChanged);
            // 
            // grade_class
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 310);
            this.Controls.Add(this.class_GroupBox);
            this.Controls.Add(this.grade_group);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "grade_class";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "학년 및 학급설정";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.grade_class_Load);
            this.grade_group.ResumeLayout(false);
            this.grade_group.PerformLayout();
            this.class_GroupBox.ResumeLayout(false);
            this.class_GroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grade_group;
        private System.Windows.Forms.CheckBox grade3_CheckBox;
        private System.Windows.Forms.CheckBox grade2_CheckBox;
        private System.Windows.Forms.CheckBox grade1_CheckBox;
        private System.Windows.Forms.GroupBox class_GroupBox;
        private System.Windows.Forms.CheckBox class9_CheckBox;
        private System.Windows.Forms.CheckBox class8_CheckBox;
        private System.Windows.Forms.CheckBox class7_CheckBox;
        private System.Windows.Forms.CheckBox class6_CheckBox;
        private System.Windows.Forms.CheckBox class5_CheckBox;
        private System.Windows.Forms.CheckBox class4_CheckBox;
        private System.Windows.Forms.CheckBox class3_CheckBox;
        private System.Windows.Forms.CheckBox class2_CheckBox;
        private System.Windows.Forms.CheckBox class1_CheckBox;
        private System.Windows.Forms.CheckBox all_CheckBox;
    }
}