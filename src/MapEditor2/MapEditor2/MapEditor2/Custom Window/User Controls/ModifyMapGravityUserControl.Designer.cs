namespace MapEditor2
{
    partial class ModifyMapGravityUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_GravityY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_CurrentGravity = new System.Windows.Forms.Label();
            this.textBox_GravityX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_KeepModifiedGravity = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox_GravityY
            // 
            this.textBox_GravityY.Location = new System.Drawing.Point(172, 32);
            this.textBox_GravityY.Name = "textBox_GravityY";
            this.textBox_GravityY.Size = new System.Drawing.Size(44, 20);
            this.textBox_GravityY.TabIndex = 21;
            this.textBox_GravityY.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "New Map Gravity:";
            // 
            // label_CurrentGravity
            // 
            this.label_CurrentGravity.AutoSize = true;
            this.label_CurrentGravity.Location = new System.Drawing.Point(119, 11);
            this.label_CurrentGravity.Name = "label_CurrentGravity";
            this.label_CurrentGravity.Size = new System.Drawing.Size(16, 13);
            this.label_CurrentGravity.TabIndex = 18;
            this.label_CurrentGravity.Text = "---";
            // 
            // textBox_GravityX
            // 
            this.textBox_GravityX.Location = new System.Drawing.Point(122, 32);
            this.textBox_GravityX.Name = "textBox_GravityX";
            this.textBox_GravityX.Size = new System.Drawing.Size(44, 20);
            this.textBox_GravityX.TabIndex = 17;
            this.textBox_GravityX.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Current Map Gravity:";
            // 
            // checkBox_KeepModifiedGravity
            // 
            this.checkBox_KeepModifiedGravity.AutoSize = true;
            this.checkBox_KeepModifiedGravity.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.checkBox_KeepModifiedGravity.Checked = true;
            this.checkBox_KeepModifiedGravity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_KeepModifiedGravity.Location = new System.Drawing.Point(12, 58);
            this.checkBox_KeepModifiedGravity.Name = "checkBox_KeepModifiedGravity";
            this.checkBox_KeepModifiedGravity.Size = new System.Drawing.Size(145, 17);
            this.checkBox_KeepModifiedGravity.TabIndex = 22;
            this.checkBox_KeepModifiedGravity.Text = "Keep the modified gravity";
            this.checkBox_KeepModifiedGravity.UseVisualStyleBackColor = true;
            // 
            // ModifyMapGravityUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_KeepModifiedGravity);
            this.Controls.Add(this.textBox_GravityY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_CurrentGravity);
            this.Controls.Add(this.textBox_GravityX);
            this.Controls.Add(this.label1);
            this.Name = "ModifyMapGravityUserControl";
            this.Size = new System.Drawing.Size(226, 84);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox_GravityY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_CurrentGravity;
        public System.Windows.Forms.TextBox textBox_GravityX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_KeepModifiedGravity;
    }
}
