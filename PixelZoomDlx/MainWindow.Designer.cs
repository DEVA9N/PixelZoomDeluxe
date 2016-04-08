using A9N.PixelZoomDlx.Controls;

namespace A9N.PixelZoomDlx
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.pictureBox = new A9N.PixelZoomDlx.Controls.ZoomImageBox();
            this.flowLayoutPanelRight = new System.Windows.Forms.FlowLayoutPanel();
            this.currentPixelBox = new A9N.PixelZoomDlx.PixelValueControl();
            this.recentPixelBox = new A9N.PixelZoomDlx.PixelValueControl();
            this.distanceBox = new A9N.PixelZoomDlx.PixelValueControl();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.checkBoxMouseSpeed = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.flowLayoutPanelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(13, 13);
            this.pictureBox.MinimumSize = new System.Drawing.Size(400, 400);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 400);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // flowLayoutPanelRight
            // 
            this.flowLayoutPanelRight.AutoSize = true;
            this.flowLayoutPanelRight.Controls.Add(this.currentPixelBox);
            this.flowLayoutPanelRight.Controls.Add(this.recentPixelBox);
            this.flowLayoutPanelRight.Controls.Add(this.distanceBox);
            this.flowLayoutPanelRight.Controls.Add(this.buttonZoomOut);
            this.flowLayoutPanelRight.Controls.Add(this.buttonZoomIn);
            this.flowLayoutPanelRight.Controls.Add(this.checkBoxMouseSpeed);
            this.flowLayoutPanelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanelRight.Location = new System.Drawing.Point(422, 0);
            this.flowLayoutPanelRight.Name = "flowLayoutPanelRight";
            this.flowLayoutPanelRight.Size = new System.Drawing.Size(182, 427);
            this.flowLayoutPanelRight.TabIndex = 6;
            // 
            // currentPixelBox
            // 
            this.currentPixelBox.Location = new System.Drawing.Point(0, 3);
            this.currentPixelBox.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
            this.currentPixelBox.MinimumSize = new System.Drawing.Size(160, 70);
            this.currentPixelBox.Name = "currentPixelBox";
            this.currentPixelBox.PixelColor = System.Drawing.Color.Empty;
            this.currentPixelBox.Position = new System.Drawing.Point(0, 0);
            this.currentPixelBox.ShowColor = true;
            this.currentPixelBox.Size = new System.Drawing.Size(172, 70);
            this.currentPixelBox.TabIndex = 7;
            // 
            // recentPixelBox
            // 
            this.recentPixelBox.Location = new System.Drawing.Point(0, 79);
            this.recentPixelBox.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
            this.recentPixelBox.MinimumSize = new System.Drawing.Size(160, 70);
            this.recentPixelBox.Name = "recentPixelBox";
            this.recentPixelBox.PixelColor = System.Drawing.Color.Empty;
            this.recentPixelBox.Position = new System.Drawing.Point(0, 0);
            this.recentPixelBox.ShowColor = true;
            this.recentPixelBox.Size = new System.Drawing.Size(172, 70);
            this.recentPixelBox.TabIndex = 14;
            // 
            // distanceBox
            // 
            this.distanceBox.Location = new System.Drawing.Point(0, 155);
            this.distanceBox.Margin = new System.Windows.Forms.Padding(0, 3, 10, 3);
            this.distanceBox.MinimumSize = new System.Drawing.Size(160, 70);
            this.distanceBox.Name = "distanceBox";
            this.distanceBox.PixelColor = System.Drawing.Color.Empty;
            this.distanceBox.Position = new System.Drawing.Point(0, 0);
            this.distanceBox.ShowColor = false;
            this.distanceBox.Size = new System.Drawing.Size(172, 70);
            this.distanceBox.TabIndex = 8;
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.AutoSize = true;
            this.buttonZoomOut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonZoomOut.Location = new System.Drawing.Point(3, 231);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(20, 23);
            this.buttonZoomOut.TabIndex = 10;
            this.buttonZoomOut.Text = "-";
            this.toolTip.SetToolTip(this.buttonZoomOut, "Zoom Out");
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.AutoSize = true;
            this.buttonZoomIn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonZoomIn.Location = new System.Drawing.Point(29, 231);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(23, 23);
            this.buttonZoomIn.TabIndex = 9;
            this.buttonZoomIn.Text = "+";
            this.toolTip.SetToolTip(this.buttonZoomIn, "Zoom In");
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
            // 
            // checkBoxMouseSpeed
            // 
            this.checkBoxMouseSpeed.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxMouseSpeed.Font = new System.Drawing.Font("Wingdings 2", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.checkBoxMouseSpeed.Location = new System.Drawing.Point(58, 231);
            this.checkBoxMouseSpeed.Name = "checkBoxMouseSpeed";
            this.checkBoxMouseSpeed.Size = new System.Drawing.Size(23, 23);
            this.checkBoxMouseSpeed.TabIndex = 12;
            this.checkBoxMouseSpeed.Text = ":";
            this.toolTip.SetToolTip(this.checkBoxMouseSpeed, "Reduce Mouse Speed (m)");
            this.checkBoxMouseSpeed.UseVisualStyleBackColor = true;
            this.checkBoxMouseSpeed.CheckedChanged += new System.EventHandler(this.checkBoxMouseSpeed_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 427);
            this.Controls.Add(this.flowLayoutPanelRight);
            this.Controls.Add(this.pictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(620, 465);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "PixelZoomDlx";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.flowLayoutPanelRight.ResumeLayout(false);
            this.flowLayoutPanelRight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private ZoomImageBox pictureBox;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRight;
		private PixelValueControl currentPixelBox;
		private PixelValueControl distanceBox;
        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.CheckBox checkBoxMouseSpeed;
        private System.Windows.Forms.ToolTip toolTip;
        private PixelValueControl recentPixelBox;

	}
}

