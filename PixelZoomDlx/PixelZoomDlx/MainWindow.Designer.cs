namespace PixelZoomDlx
{
	partial class MainWindow
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusXLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusXPos = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusYLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusYPos = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonToggleZoom = new System.Windows.Forms.Button();
            this.buttonAccuracy = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.currentPixelBox = new PixelZoomDlx.PixelValueControl();
            this.recentPixelBox = new PixelZoomDlx.PixelValueControl();
            this.lengthBox = new PixelZoomDlx.PixelValueControl();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusXLabel,
            this.statusXPos,
            this.statusYLabel,
            this.statusYPos});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(605, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusXLabel
            // 
            this.statusXLabel.Name = "statusXLabel";
            this.statusXLabel.Size = new System.Drawing.Size(17, 17);
            this.statusXLabel.Text = "X:";
            // 
            // statusXPos
            // 
            this.statusXPos.AutoSize = false;
            this.statusXPos.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusXPos.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusXPos.Name = "statusXPos";
            this.statusXPos.Size = new System.Drawing.Size(60, 17);
            // 
            // statusYLabel
            // 
            this.statusYLabel.Name = "statusYLabel";
            this.statusYLabel.Size = new System.Drawing.Size(17, 17);
            this.statusYLabel.Text = "Y:";
            // 
            // statusYPos
            // 
            this.statusYPos.AutoSize = false;
            this.statusYPos.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusYPos.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusYPos.Name = "statusYPos";
            this.statusYPos.Size = new System.Drawing.Size(60, 17);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Press \"any key\"  to set new pixel...\r\nPress \"m\" to toggle mouse speed...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(400, 400);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
            // 
            // buttonToggleZoom
            // 
            this.buttonToggleZoom.Location = new System.Drawing.Point(3, 231);
            this.buttonToggleZoom.Name = "buttonToggleZoom";
            this.buttonToggleZoom.Size = new System.Drawing.Size(161, 23);
            this.buttonToggleZoom.TabIndex = 4;
            this.buttonToggleZoom.UseVisualStyleBackColor = true;
            this.buttonToggleZoom.Click += new System.EventHandler(this.buttonToggleZoom_Click);
            // 
            // buttonAccuracy
            // 
            this.buttonAccuracy.Location = new System.Drawing.Point(3, 260);
            this.buttonAccuracy.Name = "buttonAccuracy";
            this.buttonAccuracy.Size = new System.Drawing.Size(161, 23);
            this.buttonAccuracy.TabIndex = 5;
            this.buttonAccuracy.Text = "High Accuracy";
            this.buttonAccuracy.UseVisualStyleBackColor = true;
            this.buttonAccuracy.Click += new System.EventHandler(this.buttonAccuracy_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.currentPixelBox);
            this.flowLayoutPanel1.Controls.Add(this.recentPixelBox);
            this.flowLayoutPanel1.Controls.Add(this.lengthBox);
            this.flowLayoutPanel1.Controls.Add(this.buttonToggleZoom);
            this.flowLayoutPanel1.Controls.Add(this.buttonAccuracy);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(426, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(179, 424);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // currentPixelBox
            // 
            this.currentPixelBox.Location = new System.Drawing.Point(3, 3);
            this.currentPixelBox.MinimumSize = new System.Drawing.Size(160, 70);
            this.currentPixelBox.Name = "currentPixelBox";
            this.currentPixelBox.PixelColor = System.Drawing.Color.Empty;
            this.currentPixelBox.Position = new System.Drawing.Point(0, 0);
            this.currentPixelBox.Size = new System.Drawing.Size(172, 70);
            this.currentPixelBox.TabIndex = 6;
            // 
            // recentPixelBox
            // 
            this.recentPixelBox.Location = new System.Drawing.Point(3, 79);
            this.recentPixelBox.MinimumSize = new System.Drawing.Size(160, 70);
            this.recentPixelBox.Name = "recentPixelBox";
            this.recentPixelBox.PixelColor = System.Drawing.Color.Empty;
            this.recentPixelBox.Position = new System.Drawing.Point(0, 0);
            this.recentPixelBox.Size = new System.Drawing.Size(172, 70);
            this.recentPixelBox.TabIndex = 7;
            // 
            // lengthBox
            // 
            this.lengthBox.Location = new System.Drawing.Point(3, 155);
            this.lengthBox.MinimumSize = new System.Drawing.Size(160, 70);
            this.lengthBox.Name = "lengthBox";
            this.lengthBox.PixelColor = System.Drawing.Color.Empty;
            this.lengthBox.Position = new System.Drawing.Point(0, 0);
            this.lengthBox.Size = new System.Drawing.Size(172, 70);
            this.lengthBox.TabIndex = 8;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 446);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(612, 480);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PixelZoomDlx";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainWindow_KeyPress);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button buttonToggleZoom;
		private System.Windows.Forms.Button buttonAccuracy;
		private System.Windows.Forms.ToolStripStatusLabel statusXLabel;
		private System.Windows.Forms.ToolStripStatusLabel statusXPos;
		private System.Windows.Forms.ToolStripStatusLabel statusYLabel;
		private System.Windows.Forms.ToolStripStatusLabel statusYPos;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private PixelValueControl currentPixelBox;
		private PixelValueControl recentPixelBox;
		private PixelValueControl lengthBox;

	}
}

