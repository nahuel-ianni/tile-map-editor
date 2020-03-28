namespace MapEditor2
{
    partial class ManipulateLayerUserControl
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
            this.label_ManipulationType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_CurrentLayer
            // 
            this.label_CurrentLayer.AutoSize = true;
            this.label_CurrentLayer.Location = new System.Drawing.Point(90, 10);
            this.label_CurrentLayer.Name = "label_CurrentLayer";
            this.label_CurrentLayer.Size = new System.Drawing.Size(16, 13);
            this.label_CurrentLayer.TabIndex = 7;
            this.label_CurrentLayer.Text = "---";
            // 
            // comboBox_Layers
            // 
            this.comboBox_Layers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Layers.FormattingEnabled = true;
            this.comboBox_Layers.Location = new System.Drawing.Point(93, 29);
            this.comboBox_Layers.Name = "comboBox_Layers";
            this.comboBox_Layers.Size = new System.Drawing.Size(126, 21);
            this.comboBox_Layers.TabIndex = 6;
            // 
            // label_ManipulationType
            // 
            this.label_ManipulationType.AutoSize = true;
            this.label_ManipulationType.Location = new System.Drawing.Point(9, 32);
            this.label_ManipulationType.Name = "label_ManipulationType";
            this.label_ManipulationType.Size = new System.Drawing.Size(52, 13);
            this.label_ManipulationType.TabIndex = 5;
            this.label_ManipulationType.Text = "{0} layer: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current layer: ";
            // 
            // ManipulateLayerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_CurrentLayer);
            this.Controls.Add(this.comboBox_Layers);
            this.Controls.Add(this.label_ManipulationType);
            this.Controls.Add(this.label1);
            this.Name = "ManipulateLayerUserControl";
            this.Size = new System.Drawing.Size(233, 57);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_CurrentLayer;
        public System.Windows.Forms.ComboBox comboBox_Layers;
        private System.Windows.Forms.Label label_ManipulationType;
        private System.Windows.Forms.Label label1;
    }
}
