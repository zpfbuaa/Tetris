namespace Tetris
{
    partial class TetrisSet
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtSoundOff = new System.Windows.Forms.RadioButton();
            this.rbtSoundOn = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtMusicOff = new System.Windows.Forms.RadioButton();
            this.rbtMusicOn = new System.Windows.Forms.RadioButton();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbConfirmKey = new System.Windows.Forms.TextBox();
            this.tbTransformKey = new System.Windows.Forms.TextBox();
            this.tbDownKey = new System.Windows.Forms.TextBox();
            this.tbRightKey = new System.Windows.Forms.TextBox();
            this.tbLeftKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtSoundOff);
            this.groupBox3.Controls.Add(this.rbtSoundOn);
            this.groupBox3.Location = new System.Drawing.Point(55, 270);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 53);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "音效";
            // 
            // rbtSoundOff
            // 
            this.rbtSoundOff.AutoSize = true;
            this.rbtSoundOff.Location = new System.Drawing.Point(114, 25);
            this.rbtSoundOff.Name = "rbtSoundOff";
            this.rbtSoundOff.Size = new System.Drawing.Size(35, 16);
            this.rbtSoundOff.TabIndex = 6;
            this.rbtSoundOff.TabStop = true;
            this.rbtSoundOff.Text = "关";
            this.rbtSoundOff.UseVisualStyleBackColor = true;
            // 
            // rbtSoundOn
            // 
            this.rbtSoundOn.AutoSize = true;
            this.rbtSoundOn.Location = new System.Drawing.Point(26, 25);
            this.rbtSoundOn.Name = "rbtSoundOn";
            this.rbtSoundOn.Size = new System.Drawing.Size(35, 16);
            this.rbtSoundOn.TabIndex = 6;
            this.rbtSoundOn.TabStop = true;
            this.rbtSoundOn.Text = "开";
            this.rbtSoundOn.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(242, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtMusicOff);
            this.groupBox2.Controls.Add(this.rbtMusicOn);
            this.groupBox2.Location = new System.Drawing.Point(55, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 53);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "音乐";
            // 
            // rbtMusicOff
            // 
            this.rbtMusicOff.AutoSize = true;
            this.rbtMusicOff.Location = new System.Drawing.Point(114, 25);
            this.rbtMusicOff.Name = "rbtMusicOff";
            this.rbtMusicOff.Size = new System.Drawing.Size(35, 16);
            this.rbtMusicOff.TabIndex = 5;
            this.rbtMusicOff.TabStop = true;
            this.rbtMusicOff.Text = "关";
            this.rbtMusicOff.UseVisualStyleBackColor = true;
            // 
            // rbtMusicOn
            // 
            this.rbtMusicOn.AutoSize = true;
            this.rbtMusicOn.Location = new System.Drawing.Point(26, 25);
            this.rbtMusicOn.Name = "rbtMusicOn";
            this.rbtMusicOn.Size = new System.Drawing.Size(35, 16);
            this.rbtMusicOn.TabIndex = 5;
            this.rbtMusicOn.TabStop = true;
            this.rbtMusicOn.Text = "开";
            this.rbtMusicOn.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(149, 340);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 17;
            this.btnApply.Text = "应用";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbConfirmKey);
            this.groupBox1.Controls.Add(this.tbTransformKey);
            this.groupBox1.Controls.Add(this.tbDownKey);
            this.groupBox1.Controls.Add(this.tbRightKey);
            this.groupBox1.Controls.Add(this.tbLeftKey);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(55, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 169);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "游戏键设置";
            // 
            // tbConfirmKey
            // 
            this.tbConfirmKey.BackColor = System.Drawing.Color.White;
            this.tbConfirmKey.Location = new System.Drawing.Point(70, 129);
            this.tbConfirmKey.Name = "tbConfirmKey";
            this.tbConfirmKey.ReadOnly = true;
            this.tbConfirmKey.Size = new System.Drawing.Size(170, 21);
            this.tbConfirmKey.TabIndex = 4;
            this.tbConfirmKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbConfirmKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // tbTransformKey
            // 
            this.tbTransformKey.BackColor = System.Drawing.Color.White;
            this.tbTransformKey.Location = new System.Drawing.Point(70, 103);
            this.tbTransformKey.Name = "tbTransformKey";
            this.tbTransformKey.ReadOnly = true;
            this.tbTransformKey.Size = new System.Drawing.Size(170, 21);
            this.tbTransformKey.TabIndex = 3;
            this.tbTransformKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTransformKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // tbDownKey
            // 
            this.tbDownKey.BackColor = System.Drawing.Color.White;
            this.tbDownKey.Location = new System.Drawing.Point(70, 77);
            this.tbDownKey.Name = "tbDownKey";
            this.tbDownKey.ReadOnly = true;
            this.tbDownKey.Size = new System.Drawing.Size(170, 21);
            this.tbDownKey.TabIndex = 2;
            this.tbDownKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbDownKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // tbRightKey
            // 
            this.tbRightKey.BackColor = System.Drawing.Color.White;
            this.tbRightKey.Location = new System.Drawing.Point(70, 51);
            this.tbRightKey.Name = "tbRightKey";
            this.tbRightKey.ReadOnly = true;
            this.tbRightKey.Size = new System.Drawing.Size(170, 21);
            this.tbRightKey.TabIndex = 1;
            this.tbRightKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbRightKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // tbLeftKey
            // 
            this.tbLeftKey.BackColor = System.Drawing.Color.White;
            this.tbLeftKey.Location = new System.Drawing.Point(70, 25);
            this.tbLeftKey.Name = "tbLeftKey";
            this.tbLeftKey.ReadOnly = true;
            this.tbLeftKey.Size = new System.Drawing.Size(170, 21);
            this.tbLeftKey.TabIndex = 0;
            this.tbLeftKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLeftKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "下移";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "确定";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "变换";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "右移";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "左移";
            // 
            // TetrisSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 368);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox1);
            this.Name = "TetrisSet";
            this.Text = "TrisSet";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtSoundOff;
        private System.Windows.Forms.RadioButton rbtSoundOn;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtMusicOff;
        private System.Windows.Forms.RadioButton rbtMusicOn;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbConfirmKey;
        private System.Windows.Forms.TextBox tbTransformKey;
        private System.Windows.Forms.TextBox tbDownKey;
        private System.Windows.Forms.TextBox tbRightKey;
        private System.Windows.Forms.TextBox tbLeftKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}