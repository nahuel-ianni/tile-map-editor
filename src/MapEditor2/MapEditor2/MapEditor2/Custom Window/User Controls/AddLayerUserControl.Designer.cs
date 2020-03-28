namespace MapEditor2
{
    partial class AddLayerUserControl
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
            this.label_CurrentLayer = new System.Windows.Forms.Label();
            this.comboBox_Layers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_Ahead = new System.Windows.Forms.RadioButton();
            this.radioButton_Behind = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label_CurrentLayer
            // 
            this.label_CurrentLayer.AutoSize = true;
            this.label_CurrentLayer.Location = new System.Drawing.Point(89, 9);
            this.label_CurrentLayer.Name = "label_CurrentLayer";
            this.label_CurrentLayer.Size = new System.Drawing.Size(16, 13);
            this.label_CurrentLayer.TabIndex = 11;
            this.label_CurrentLayer.Text = "---";
            // 
            // comboBox_Layers
            // 
            this.comboBox_Layers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Layers.FormattingEnabled = true;
            this.comboBox_Layers.Location = new System.Drawing.Point(130, 50);
            this.comboBox_Layers.Name = "comboBox_Layers";
            this.comboBox_Layers.Size = new System.Drawing.Size(126, 21);
            this.comboBox_Layers.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Current layer: ";
            // 
            // radioButton_Ahead
            // 
            this.radioButton_Ahead.AutoSize = true;
            this.radioButton_Ahead.Checked = true;
            this.radioButton_Ahead.Location = new System.Drawing.Point(7, 31);
            this.radioButton_Ahead.Name = "radioButton_Ahead";
            this.radioButton_Ahead.Size = new System.Drawing.Size(96, 17);
            this.radioButton_Ahead.TabIndex = 12;
            this.radioButton_Ahead.TabStop = true;
            this.radioButton_Ahead.Text = "Insert ahead of";
            this.radioButton_Ahead.UseVisualStyleBackColor = true;
            // 
            // radioButton_Behind
            // 
            this.radioButton_Behind.AutoSize = true;
            this.radioButton_Behind.Location = new System.Drawing.Point(7, 54);
            this.radioButton_Behind.Name = "radioButton_Behind";
            this.radioButton_Behind.Size = new System.Drawing.Size(98, 17);
            this.radioButton_Behind.TabIndex = 13;
            this.radioButton_Behind.Text = "Insert behind of";
            this.radioButton_Behind.UseVisualStyleBackColor = true;
            // 
            // AddLayerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioButton_Behind);
            this.Controls.Add(this.radioButton_Ahead);
            this.Controls.Add(this.label_CurrentLayer);
            this.Controls.Add(this.comboBox_Layers);
            this.Controls.Add(this.label1);
            this.Name = "AddLayerUserControl";
            this.Size = new System.Drawing.Size(273, 86);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_CurrentLayer;
        public System.Windows.Forms.ComboBox comboBox_Layers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_Ahead;
        private System.Windows.Forms.RadioButton radioButton_Behind;


    }
}
