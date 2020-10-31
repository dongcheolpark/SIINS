namespace INCAL_Teacher
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.subject = new System.Windows.Forms.Label();
            this.Subject_TextBox = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.Label();
            this.Title_TextBox = new System.Windows.Forms.TextBox();
            this.Contents_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.T_Name = new System.Windows.Forms.Label();
            this.T_Name_TextBox = new System.Windows.Forms.TextBox();
            this.Contents = new System.Windows.Forms.Label();
            this.Save_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Time_Limit = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Load_Button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grade_Label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.UpLoad_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.view_data = new System.Windows.Forms.ListBox();
            this.refresh_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // subject
            // 
            this.subject.AutoSize = true;
            this.subject.Font = new System.Drawing.Font("맑은 고딕 Semilight", 20F);
            this.subject.Location = new System.Drawing.Point(12, 16);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(98, 37);
            this.subject.TabIndex = 0;
            this.subject.Text = "과목명";
            // 
            // Subject_TextBox
            // 
            this.Subject_TextBox.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Subject_TextBox.Location = new System.Drawing.Point(117, 13);
            this.Subject_TextBox.Name = "Subject_TextBox";
            this.Subject_TextBox.Size = new System.Drawing.Size(209, 43);
            this.Subject_TextBox.TabIndex = 1;
            this.Subject_TextBox.TextChanged += new System.EventHandler(this.Subject_TextBox_TextChanged);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("맑은 고딕 Semilight", 20F);
            this.Title.Location = new System.Drawing.Point(12, 69);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(71, 37);
            this.Title.TabIndex = 2;
            this.Title.Text = "제목";
            // 
            // Title_TextBox
            // 
            this.Title_TextBox.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Title_TextBox.Location = new System.Drawing.Point(117, 69);
            this.Title_TextBox.Name = "Title_TextBox";
            this.Title_TextBox.Size = new System.Drawing.Size(614, 43);
            this.Title_TextBox.TabIndex = 3;
            this.Title_TextBox.TextChanged += new System.EventHandler(this.Title_TextBox_TextChanged);
            // 
            // Contents_RichTextBox
            // 
            this.Contents_RichTextBox.Font = new System.Drawing.Font("굴림", 11F);
            this.Contents_RichTextBox.Location = new System.Drawing.Point(117, 172);
            this.Contents_RichTextBox.Name = "Contents_RichTextBox";
            this.Contents_RichTextBox.Size = new System.Drawing.Size(614, 228);
            this.Contents_RichTextBox.TabIndex = 4;
            this.Contents_RichTextBox.Text = "";
            this.Contents_RichTextBox.TextChanged += new System.EventHandler(this.Contents_RichTextBox_TextChanged);
            // 
            // T_Name
            // 
            this.T_Name.AutoSize = true;
            this.T_Name.Font = new System.Drawing.Font("맑은 고딕 Semilight", 20F);
            this.T_Name.Location = new System.Drawing.Point(335, 16);
            this.T_Name.Name = "T_Name";
            this.T_Name.Size = new System.Drawing.Size(160, 37);
            this.T_Name.TabIndex = 5;
            this.T_Name.Text = "선생님 성함";
            // 
            // T_Name_TextBox
            // 
            this.T_Name_TextBox.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.T_Name_TextBox.Location = new System.Drawing.Point(501, 13);
            this.T_Name_TextBox.Name = "T_Name_TextBox";
            this.T_Name_TextBox.Size = new System.Drawing.Size(230, 43);
            this.T_Name_TextBox.TabIndex = 6;
            this.T_Name_TextBox.TextChanged += new System.EventHandler(this.T_Name_TextBox_TextChanged);
            // 
            // Contents
            // 
            this.Contents.AutoSize = true;
            this.Contents.Font = new System.Drawing.Font("맑은 고딕 Semilight", 20F);
            this.Contents.Location = new System.Drawing.Point(12, 172);
            this.Contents.Name = "Contents";
            this.Contents.Size = new System.Drawing.Size(71, 37);
            this.Contents.TabIndex = 7;
            this.Contents.Text = "내용";
            // 
            // Save_Button
            // 
            this.Save_Button.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.Save_Button.Location = new System.Drawing.Point(564, 443);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(167, 43);
            this.Save_Button.TabIndex = 9;
            this.Save_Button.Text = "저장";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 485);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Time_Limit
            // 
            this.Time_Limit.AutoSize = true;
            this.Time_Limit.Font = new System.Drawing.Font("맑은 고딕 Semilight", 18F);
            this.Time_Limit.Location = new System.Drawing.Point(13, 122);
            this.Time_Limit.Name = "Time_Limit";
            this.Time_Limit.Size = new System.Drawing.Size(111, 32);
            this.Time_Limit.TabIndex = 11;
            this.Time_Limit.Text = "제출기한";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(117, 129);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 12;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Load_Button
            // 
            this.Load_Button.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.Load_Button.Location = new System.Drawing.Point(379, 443);
            this.Load_Button.Name = "Load_Button";
            this.Load_Button.Size = new System.Drawing.Size(167, 43);
            this.Load_Button.TabIndex = 13;
            this.Load_Button.Text = "불러오기";
            this.Load_Button.UseVisualStyleBackColor = true;
            this.Load_Button.Click += new System.EventHandler(this.Load_Button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // grade_Label
            // 
            this.grade_Label.AutoSize = true;
            this.grade_Label.Font = new System.Drawing.Font("맑은 고딕 Semilight", 20F);
            this.grade_Label.Location = new System.Drawing.Point(335, 120);
            this.grade_Label.Name = "grade_Label";
            this.grade_Label.Size = new System.Drawing.Size(141, 37);
            this.grade_Label.TabIndex = 14;
            this.grade_Label.Text = "학년 및 반";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.button1.Location = new System.Drawing.Point(501, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 36);
            this.button1.TabIndex = 15;
            this.button1.Text = "선택";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UpLoad_Button
            // 
            this.UpLoad_Button.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.UpLoad_Button.Location = new System.Drawing.Point(195, 443);
            this.UpLoad_Button.Name = "UpLoad_Button";
            this.UpLoad_Button.Size = new System.Drawing.Size(167, 43);
            this.UpLoad_Button.TabIndex = 16;
            this.UpLoad_Button.Text = "업로드";
            this.UpLoad_Button.UseVisualStyleBackColor = true;
            this.UpLoad_Button.Click += new System.EventHandler(this.UpLoad_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(799, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 114);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // view_data
            // 
            this.view_data.FormattingEnabled = true;
            this.view_data.ItemHeight = 12;
            this.view_data.Location = new System.Drawing.Point(799, 172);
            this.view_data.Name = "view_data";
            this.view_data.Size = new System.Drawing.Size(303, 280);
            this.view_data.TabIndex = 18;
            this.view_data.SelectedIndexChanged += new System.EventHandler(this.view_data_SelectedIndexChanged);
            // 
            // refresh_button
            // 
            this.refresh_button.Location = new System.Drawing.Point(799, 136);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Size = new System.Drawing.Size(75, 23);
            this.refresh_button.TabIndex = 19;
            this.refresh_button.Text = "새로고침";
            this.refresh_button.UseVisualStyleBackColor = true;
            this.refresh_button.Click += new System.EventHandler(this.refresh_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1157, 512);
            this.Controls.Add(this.refresh_button);
            this.Controls.Add(this.view_data);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UpLoad_Button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grade_Label);
            this.Controls.Add(this.Load_Button);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Time_Limit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save_Button);
            this.Controls.Add(this.Contents);
            this.Controls.Add(this.T_Name_TextBox);
            this.Controls.Add(this.T_Name);
            this.Controls.Add(this.Contents_RichTextBox);
            this.Controls.Add(this.Title_TextBox);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Subject_TextBox);
            this.Controls.Add(this.subject);
            this.Name = "Form1";
            this.Text = "INCAL";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label subject;
        private System.Windows.Forms.TextBox Subject_TextBox;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox Title_TextBox;
        private System.Windows.Forms.RichTextBox Contents_RichTextBox;
        private System.Windows.Forms.Label T_Name;
        private System.Windows.Forms.TextBox T_Name_TextBox;
        private System.Windows.Forms.Label Contents;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Time_Limit;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button Load_Button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label grade_Label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button UpLoad_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox view_data;
        private System.Windows.Forms.Button refresh_button;
    }
}

