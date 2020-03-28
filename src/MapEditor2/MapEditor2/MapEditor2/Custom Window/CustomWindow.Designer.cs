namespace MapEditor2
{
    partial class CustomWindow
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
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Accept = new System.Windows.Forms.Button();
            this.groupBox_Content = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Cancel.Location = new System.Drawing.Point(164, 124);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(100, 28);
            this.button_Cancel.TabIndex = 5;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Visible = false;
            // 
            // button_Accept
            // 
            this.button_Accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Accept.Location = new System.Drawing.Point(265, 124);
            this.button_Accept.Name = "button_Accept";
            this.button_Accept.Size = new System.Drawing.Size(100, 28);
            this.button_Accept.TabIndex = 4;
            this.button_Accept.Text = "Accept";
            this.button_Accept.UseVisualStyleBackColor = true;
            // 
            // groupBox_Content
            // 
            this.groupBox_Content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Content.Location = new System.Drawing.Point(3, 3);
            this.groupBox_Content.Name = "groupBox_Content";
            this.groupBox_Content.Size = new System.Drawing.Size(362, 119);
            this.groupBox_Content.TabIndex = 3;
            this.groupBox_Content.TabStop = false;
            // 
            // CustomWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 155);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Accept);
            this.Controls.Add(this.groupBox_Content);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomWindow";
            this.ShowIcon = false;
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button button_Cancel;
        public System.Windows.Forms.Button button_Accept;
        public System.Windows.Forms.GroupBox groupBox_Content;
    }
}