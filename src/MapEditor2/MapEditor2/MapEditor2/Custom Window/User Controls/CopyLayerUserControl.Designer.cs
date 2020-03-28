namespace MapEditor2
{
    partial class CopyLayerUserControl
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
            this.comboBox_SourceLayers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_DestinationLayers = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_CurrentLayer
            // 
            this.label_CurrentLayer.AutoSize = true;
            this.label_CurrentLayer.Location = new System.Drawing.Point(104, 9);
            this.label_CurrentLayer.Name = "label_CurrentLayer";
            this.label_CurrentLayer.Size = new System.Drawing.Size(16, 13);
            this.label_CurrentLayer.TabIndex = 7;
            this.label_CurrentLayer.Text = "---";
            // 
            // comboBox_SourceLayers
            // 
            this.comboBox_SourceLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SourceLayers.FormattingEnabled = true;
            this.comboBox_SourceLayers.Location = new System.Drawing.Point(107, 28);
            this.comboBox_SourceLayers.Name = "comboBox_SourceLayers";
            this.comboBox_SourceLayers.Size = new System.Drawing.Size(126, 21);
            this.comboBox_SourceLayers.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Source layer: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current layer: ";
            // 
            // comboBox_DestinationLayers
            // 
            this.comboBox_DestinationLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DestinationLayers.FormattingEnabled = true;
            this.comboBox_DestinationLayers.Location = new System.Drawing.Point(107, 55);
            this.comboBox_DestinationLayers.Name = "comboBox_DestinationLayers";
            this.comboBox_DestinationLayers.Size = new System.Drawing.Size(126, 21);
            this.comboBox_DestinationLayers.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Destination layer: ";
            // 
            // CopyLayerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox_DestinationLayers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_CurrentLayer);
            this.Controls.Add(this.comboBox_SourceLayers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CopyLayerUserControl";
            this.Size = new System.Drawing.Size(247, 83);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_CurrentLayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_SourceLayers;
        private System.Windows.Forms.ComboBox comboBox_DestinationLayers;
    }
}
