namespace MapEditor2
{
    partial class RedimensionMapSizeValuesUserControl
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
            this.label_NewPropertyHeight = new System.Windows.Forms.Label();
            this.label_CurrentHeight = new System.Windows.Forms.Label();
            this.textBox_Height = new System.Windows.Forms.TextBox();
            this.label_CurrentPropertyHeight = new System.Windows.Forms.Label();
            this.label_NewPropertyWidth = new System.Windows.Forms.Label();
            this.label_CurrentWidth = new System.Windows.Forms.Label();
            this.textBox_Width = new System.Windows.Forms.TextBox();
            this.label_CurrentPropertyWidth = new System.Windows.Forms.Label();
            this.checkBox_KeepCurrentTiles = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label_NewPropertyHeight
            // 
            this.label_NewPropertyHeight.AutoSize = true;
            this.label_NewPropertyHeight.Location = new System.Drawing.Point(190, 42);
            this.label_NewPropertyHeight.Name = "label_NewPropertyHeight";
            this.label_NewPropertyHeight.Size = new System.Drawing.Size(83, 13);
            this.label_NewPropertyHeight.TabIndex = 15;
            this.label_NewPropertyHeight.Text = "New {0} Height:";
            // 
            // label_CurrentHeight
            // 
            this.label_CurrentHeight.AutoSize = true;
            this.label_CurrentHeight.Location = new System.Drawing.Point(298, 14);
            this.label_CurrentHeight.Name = "label_CurrentHeight";
            this.label_CurrentHeight.Size = new System.Drawing.Size(16, 13);
            this.label_CurrentHeight.TabIndex = 14;
            this.label_CurrentHeight.Text = "---";
            // 
            // textBox_Height
            // 
            this.textBox_Height.Location = new System.Drawing.Point(301, 39);
            this.textBox_Height.Name = "textBox_Height";
            this.textBox_Height.Size = new System.Drawing.Size(34, 20);
            this.textBox_Height.TabIndex = 13;
            this.textBox_Height.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label_CurrentPropertyHeight
            // 
            this.label_CurrentPropertyHeight.AutoSize = true;
            this.label_CurrentPropertyHeight.Location = new System.Drawing.Point(190, 14);
            this.label_CurrentPropertyHeight.Name = "label_CurrentPropertyHeight";
            this.label_CurrentPropertyHeight.Size = new System.Drawing.Size(95, 13);
            this.label_CurrentPropertyHeight.TabIndex = 12;
            this.label_CurrentPropertyHeight.Text = "Current {0} Height:";
            // 
            // label_NewPropertyWidth
            // 
            this.label_NewPropertyWidth.AutoSize = true;
            this.label_NewPropertyWidth.Location = new System.Drawing.Point(9, 42);
            this.label_NewPropertyWidth.Name = "label_NewPropertyWidth";
            this.label_NewPropertyWidth.Size = new System.Drawing.Size(80, 13);
            this.label_NewPropertyWidth.TabIndex = 11;
            this.label_NewPropertyWidth.Text = "New {0} Width:";
            // 
            // label_CurrentWidth
            // 
            this.label_CurrentWidth.AutoSize = true;
            this.label_CurrentWidth.Location = new System.Drawing.Point(114, 14);
            this.label_CurrentWidth.Name = "label_CurrentWidth";
            this.label_CurrentWidth.Size = new System.Drawing.Size(16, 13);
            this.label_CurrentWidth.TabIndex = 10;
            this.label_CurrentWidth.Text = "---";
            // 
            // textBox_Width
            // 
            this.textBox_Width.Location = new System.Drawing.Point(117, 39);
            this.textBox_Width.Name = "textBox_Width";
            this.textBox_Width.Size = new System.Drawing.Size(34, 20);
            this.textBox_Width.TabIndex = 9;
            this.textBox_Width.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label_CurrentPropertyWidth
            // 
            this.label_CurrentPropertyWidth.AutoSize = true;
            this.label_CurrentPropertyWidth.Location = new System.Drawing.Point(9, 14);
            this.label_CurrentPropertyWidth.Name = "label_CurrentPropertyWidth";
            this.label_CurrentPropertyWidth.Size = new System.Drawing.Size(92, 13);
            this.label_CurrentPropertyWidth.TabIndex = 8;
            this.label_CurrentPropertyWidth.Text = "Current {0} Width:";
            // 
            // checkBox_KeepCurrentTiles
            // 
            this.checkBox_KeepCurrentTiles.AutoSize = true;
            this.checkBox_KeepCurrentTiles.Checked = true;
            this.checkBox_KeepCurrentTiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_KeepCurrentTiles.Location = new System.Drawing.Point(12, 65);
            this.checkBox_KeepCurrentTiles.Name = "checkBox_KeepCurrentTiles";
            this.checkBox_KeepCurrentTiles.Size = new System.Drawing.Size(176, 17);
            this.checkBox_KeepCurrentTiles.TabIndex = 17;
            this.checkBox_KeepCurrentTiles.Text = "Keep the currently selected tiles";
            this.checkBox_KeepCurrentTiles.UseVisualStyleBackColor = true;
            // 
            // RedimensionMapSizeValuesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_KeepCurrentTiles);
            this.Controls.Add(this.label_NewPropertyHeight);
            this.Controls.Add(this.label_CurrentHeight);
            this.Controls.Add(this.textBox_Height);
            this.Controls.Add(this.label_CurrentPropertyHeight);
            this.Controls.Add(this.label_NewPropertyWidth);
            this.Controls.Add(this.label_CurrentWidth);
            this.Controls.Add(this.textBox_Width);
            this.Controls.Add(this.label_CurrentPropertyWidth);
            this.Name = "RedimensionMapSizeValuesUserControl";
            this.Size = new System.Drawing.Size(350, 86);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_NewPropertyHeight;
        private System.Windows.Forms.Label label_CurrentHeight;
        public System.Windows.Forms.TextBox textBox_Height;
        private System.Windows.Forms.Label label_CurrentPropertyHeight;
        private System.Windows.Forms.Label label_NewPropertyWidth;
        private System.Windows.Forms.Label label_CurrentWidth;
        public System.Windows.Forms.TextBox textBox_Width;
        private System.Windows.Forms.Label label_CurrentPropertyWidth;
        private System.Windows.Forms.CheckBox checkBox_KeepCurrentTiles;

    }
}
