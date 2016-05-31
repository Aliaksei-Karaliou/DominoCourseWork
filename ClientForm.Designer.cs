namespace DominoCourseWork
{
    partial class ClientForm
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
            this.PortUpDown = new System.Windows.Forms.NumericUpDown();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.IPLable = new System.Windows.Forms.Label();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PortUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // PortUpDown
            // 
            this.PortUpDown.Location = new System.Drawing.Point(11, 39);
            this.PortUpDown.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.PortUpDown.Name = "PortUpDown";
            this.PortUpDown.Size = new System.Drawing.Size(184, 20);
            this.PortUpDown.TabIndex = 12;
            this.PortUpDown.Value = new decimal(new int[] {
            123,
            0,
            0,
            0});
            // 
            // ReturnButton
            // 
            this.ReturnButton.Location = new System.Drawing.Point(153, 64);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(117, 23);
            this.ReturnButton.TabIndex = 11;
            this.ReturnButton.Text = "Return back";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(11, 65);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(136, 23);
            this.ConnectButton.TabIndex = 10;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Port";
            // 
            // IPLable
            // 
            this.IPLable.AutoSize = true;
            this.IPLable.Location = new System.Drawing.Point(213, 12);
            this.IPLable.Name = "IPLable";
            this.IPLable.Size = new System.Drawing.Size(57, 13);
            this.IPLable.TabIndex = 8;
            this.IPLable.Text = "IP-address";
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(12, 12);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(183, 20);
            this.IPTextBox.TabIndex = 7;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 91);
            this.Controls.Add(this.PortUpDown);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IPLable);
            this.Controls.Add(this.IPTextBox);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            ((System.ComponentModel.ISupportInitialize)(this.PortUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown PortUpDown;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label IPLable;
        private System.Windows.Forms.TextBox IPTextBox;
    }
}