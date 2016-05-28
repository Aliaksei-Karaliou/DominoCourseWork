namespace DominoCourseWork
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yardButton = new System.Windows.Forms.Button();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(612, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // yardButton
            // 
            this.yardButton.Location = new System.Drawing.Point(697, 495);
            this.yardButton.Name = "yardButton";
            this.yardButton.Size = new System.Drawing.Size(75, 23);
            this.yardButton.TabIndex = 2;
            this.yardButton.Text = "Yard";
            this.yardButton.UseVisualStyleBackColor = true;
            this.yardButton.Click += new System.EventHandler(this.yardButton_Click);
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScoreLabel.Location = new System.Drawing.Point(481, 9);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(291, 139);
            this.ScoreLabel.TabIndex = 0;
            this.ScoreLabel.Text = "0:0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(491, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.yardButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button yardButton;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label label3;
    }
}

