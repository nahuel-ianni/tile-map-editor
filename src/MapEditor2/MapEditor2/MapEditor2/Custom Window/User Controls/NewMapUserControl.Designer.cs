namespace MapEditor2
{
    partial class NewMapUserControl
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
            this.textBox_MapName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_GravityX = new System.Windows.Forms.TextBox();
            this.textBox_MapWidth = new System.Windows.Forms.TextBox();
            this.textBox_MapHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_TileWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_TileHeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_GravityY = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Layers = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox_KeepCurrentTiles = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox_MapName
            // 
            this.textBox_MapName.Location = new System.Drawing.Point(78, 10);
            this.textBox_MapName.Name = "textBox_MapName";
            this.textBox_MapName.Size = new System.Drawing.Size(145, 20);
            this.textBox_MapName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Map name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gravity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Map width:";
            // 
            // textBox_GravityX
            // 
            this.textBox_GravityX.Location = new System.Drawing.Point(102, 36);
            this.textBox_GravityX.Name = "textBox_GravityX";
            this.textBox_GravityX.Size = new System.Drawing.Size(36, 20);
            this.textBox_GravityX.TabIndex = 1;
            this.textBox_GravityX.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBox_MapWidth
            // 
            this.textBox_MapWidth.Location = new System.Drawing.Point(78, 88);
            this.textBox_MapWidth.Name = "textBox_MapWidth";
            this.textBox_MapWidth.Size = new System.Drawing.Size(60, 20);
            this.textBox_MapWidth.TabIndex = 3;
            this.textBox_MapWidth.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // textBox_MapHeight
            // 
            this.textBox_MapHeight.Location = new System.Drawing.Point(78, 114);
            this.textBox_MapHeight.Name = "textBox_MapHeight";
            this.textBox_MapHeight.Size = new System.Drawing.Size(60, 20);
            this.textBox_MapHeight.TabIndex = 4;
            this.textBox_MapHeight.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Map height:";
            // 
            // textBox_TileWidth
            // 
            this.textBox_TileWidth.Location = new System.Drawing.Point(78, 140);
            this.textBox_TileWidth.Name = "textBox_TileWidth";
            this.textBox_TileWidth.Size = new System.Drawing.Size(60, 20);
            this.textBox_TileWidth.TabIndex = 5;
            this.textBox_TileWidth.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tile width:";
            // 
            // textBox_TileHeight
            // 
            this.textBox_TileHeight.Location = new System.Drawing.Point(78, 166);
            this.textBox_TileHeight.Name = "textBox_TileHeight";
            this.textBox_TileHeight.Size = new System.Drawing.Size(60, 20);
            this.textBox_TileHeight.TabIndex = 6;
            this.textBox_TileHeight.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tile height:";
            // 
            // textBox_GravityY
            // 
            this.textBox_GravityY.Location = new System.Drawing.Point(102, 62);
            this.textBox_GravityY.Name = "textBox_GravityY";
            this.textBox_GravityY.Size = new System.Drawing.Size(36, 20);
            this.textBox_GravityY.TabIndex = 2;
            this.textBox_GravityY.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(79, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Y:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(79, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "X:";
            // 
            // textBox_Layers
            // 
            this.textBox_Layers.Location = new System.Drawing.Point(78, 192);
            this.textBox_Layers.Name = "textBox_Layers";
            this.textBox_Layers.Size = new System.Drawing.Size(60, 20);
            this.textBox_Layers.TabIndex = 7;
            this.textBox_Layers.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Layers:";
            // 
            // checkBox_KeepCurrentTiles
            // 
            this.checkBox_KeepCurrentTiles.AutoSize = true;
            this.checkBox_KeepCurrentTiles.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.checkBox_KeepCurrentTiles.Checked = true;
            this.checkBox_KeepCurrentTiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_KeepCurrentTiles.Location = new System.Drawing.Point(16, 218);
            this.checkBox_KeepCurrentTiles.Name = "checkBox_KeepCurrentTiles";
            this.checkBox_KeepCurrentTiles.Size = new System.Drawing.Size(176, 17);
            this.checkBox_KeepCurrentTiles.TabIndex = 16;
            this.checkBox_KeepCurrentTiles.Text = "Keep the currently selected tiles";
            this.checkBox_KeepCurrentTiles.UseVisualStyleBackColor = true;
            // 
            // NewMapUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_KeepCurrentTiles);
            this.Controls.Add(this.textBox_Layers);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_GravityY);
            this.Controls.Add(this.textBox_TileHeight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_TileWidth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_MapHeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_MapWidth);
            this.Controls.Add(this.textBox_GravityX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_MapName);
            this.Name = "NewMapUserControl";
            this.Size = new System.Drawing.Size(244, 247);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_MapName;
        private System.Windows.Forms.TextBox textBox_GravityX;
        private System.Windows.Forms.TextBox textBox_MapWidth;
        private System.Windows.Forms.TextBox textBox_MapHeight;
        private System.Windows.Forms.TextBox textBox_TileWidth;
        private System.Windows.Forms.TextBox textBox_TileHeight;
        private System.Windows.Forms.TextBox textBox_GravityY;
        private System.Windows.Forms.TextBox textBox_Layers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_KeepCurrentTiles;
    }
}
