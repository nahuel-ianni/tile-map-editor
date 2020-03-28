namespace MapEditor2
{
    partial class AboutUserControl
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
            this.label_AboutMapEditorLogo = new System.Windows.Forms.Label();
            this.label_AboutMapEditor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_AboutMapEditorLogo
            // 
            this.label_AboutMapEditorLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_AboutMapEditorLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_AboutMapEditorLogo.Location = new System.Drawing.Point(3, 9);
            this.label_AboutMapEditorLogo.Name = "label_AboutMapEditorLogo";
            this.label_AboutMapEditorLogo.Size = new System.Drawing.Size(421, 72);
            this.label_AboutMapEditorLogo.TabIndex = 1;
            this.label_AboutMapEditorLogo.Text = "Timeless Reality Games\r\n   Map Editor";
            this.label_AboutMapEditorLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_AboutMapEditor
            // 
            this.label_AboutMapEditor.AutoSize = true;
            this.label_AboutMapEditor.Location = new System.Drawing.Point(3, 94);
            this.label_AboutMapEditor.Name = "label_AboutMapEditor";
            this.label_AboutMapEditor.Size = new System.Drawing.Size(16, 13);
            this.label_AboutMapEditor.TabIndex = 2;
            this.label_AboutMapEditor.Text = "---";
            // 
            // AboutUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.label_AboutMapEditor);
            this.Controls.Add(this.label_AboutMapEditorLogo);
            this.Name = "AboutUserControl";
            this.Size = new System.Drawing.Size(427, 114);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_AboutMapEditorLogo;
        private System.Windows.Forms.Label label_AboutMapEditor;

    }
}
