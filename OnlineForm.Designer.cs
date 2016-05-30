namespace DominoCourseWork
{
    partial class OnlineForm
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
            this.StartServerButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartServerButton
            // 
            this.StartServerButton.Location = new System.Drawing.Point(13, 13);
            this.StartServerButton.Name = "StartServerButton";
            this.StartServerButton.Size = new System.Drawing.Size(175, 23);
            this.StartServerButton.TabIndex = 0;
            this.StartServerButton.Text = "Start server";
            this.StartServerButton.UseVisualStyleBackColor = true;
            this.StartServerButton.Click += new System.EventHandler(this.StartServerButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(13, 43);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(175, 23);
            this.ConnectButton.TabIndex = 1;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(13, 73);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(175, 23);
            this.ReturnButton.TabIndex = 2;
            this.ReturnButton.Text = "Return Back";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // OnlineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 102);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.StartServerButton);
            this.Name = "OnlineForm";
            this.Text = "OnlineForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartServerButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button ReturnButton;
    }
}