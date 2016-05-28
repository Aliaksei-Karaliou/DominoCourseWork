namespace DominoCourseWork
{
    partial class StartingForm
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
            this.localButton = new System.Windows.Forms.Button();
            this.onlineButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // localButton
            // 
            this.localButton.Location = new System.Drawing.Point(13, 13);
            this.localButton.Name = "localButton";
            this.localButton.Size = new System.Drawing.Size(175, 23);
            this.localButton.TabIndex = 0;
            this.localButton.Text = "Local Game";
            this.localButton.UseVisualStyleBackColor = true;
            this.localButton.Click += new System.EventHandler(this.localButton_Click);
            // 
            // onlineButton
            // 
            this.onlineButton.Location = new System.Drawing.Point(13, 42);
            this.onlineButton.Name = "onlineButton";
            this.onlineButton.Size = new System.Drawing.Size(175, 26);
            this.onlineButton.TabIndex = 1;
            this.onlineButton.Text = "Online Game";
            this.onlineButton.UseVisualStyleBackColor = true;
            this.onlineButton.Click += new System.EventHandler(this.onlineButton_Click);
            // 
            // StartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 78);
            this.Controls.Add(this.onlineButton);
            this.Controls.Add(this.localButton);
            this.Name = "StartingForm";
            this.Text = "StartingForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button localButton;
        private System.Windows.Forms.Button onlineButton;
    }
}