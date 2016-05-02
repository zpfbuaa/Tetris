using System.Windows.Forms;
namespace Russia
{
    partial class Tetris
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
            this.button_Begin = new System.Windows.Forms.Button();
            this.panelAll = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button_Begin
            // 
            this.button_Begin.Location = new System.Drawing.Point(220, 12);
            this.button_Begin.Name = "button_Begin";
            this.button_Begin.Size = new System.Drawing.Size(78, 23);
            this.button_Begin.TabIndex = 1;
            this.button_Begin.Text = "Begin Game";
            this.button_Begin.UseVisualStyleBackColor = true;
            this.button_Begin.Click += new System.EventHandler(this.button_Begin_Click);
            // 
            // panelAll
            // 
            this.panelAll.Location = new System.Drawing.Point(1, 0);
            this.panelAll.Name = "panelAll";
            this.panelAll.Size = new System.Drawing.Size(200, 400);
            this.panelAll.TabIndex = 0;
            // 
            // Tetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(320, 401);
            this.Controls.Add(this.button_Begin);
            this.Controls.Add(this.panelAll);
            this.KeyPreview = true;
            this.Name = "Tetris";
            this.Text = "Tetris";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Begin;
        private Panel panelAll;

    }
}

