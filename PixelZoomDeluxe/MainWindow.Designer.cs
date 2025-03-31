using A9N.PixelZoomDeluxe.Controls;

namespace A9N.PixelZoomDeluxe
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            flowLayoutPanelRight = new FlowLayoutPanel();
            currentPixelBox = new PixelValueControl();
            recentPixelBox = new PixelValueControl();
            distanceBox = new PixelValueControl();
            buttonZoomOut = new Button();
            buttonZoomIn = new Button();
            checkBoxMouseSpeed = new CheckBox();
            toolTip = new ToolTip(components);
            pictureBox = new ZoomImageBox();
            flowLayoutPanelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanelRight
            // 
            flowLayoutPanelRight.AutoSize = true;
            flowLayoutPanelRight.Controls.Add(currentPixelBox);
            flowLayoutPanelRight.Controls.Add(recentPixelBox);
            flowLayoutPanelRight.Controls.Add(distanceBox);
            flowLayoutPanelRight.Controls.Add(buttonZoomOut);
            flowLayoutPanelRight.Controls.Add(buttonZoomIn);
            flowLayoutPanelRight.Controls.Add(checkBoxMouseSpeed);
            flowLayoutPanelRight.Dock = DockStyle.Right;
            flowLayoutPanelRight.Location = new Point(492, 0);
            flowLayoutPanelRight.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanelRight.Name = "flowLayoutPanelRight";
            flowLayoutPanelRight.Size = new Size(213, 493);
            flowLayoutPanelRight.TabIndex = 6;
            // 
            // currentPixelBox
            // 
            currentPixelBox.Location = new Point(0, 3);
            currentPixelBox.Margin = new Padding(0, 3, 12, 3);
            currentPixelBox.MinimumSize = new Size(187, 115);
            currentPixelBox.Name = "currentPixelBox";
            currentPixelBox.PixelColor = Color.Empty;
            currentPixelBox.Position = new Point(0, 0);
            currentPixelBox.ShowColor = true;
            currentPixelBox.Size = new Size(201, 115);
            currentPixelBox.TabIndex = 7;
            // 
            // recentPixelBox
            // 
            recentPixelBox.Location = new Point(0, 124);
            recentPixelBox.Margin = new Padding(0, 3, 12, 3);
            recentPixelBox.MinimumSize = new Size(187, 115);
            recentPixelBox.Name = "recentPixelBox";
            recentPixelBox.PixelColor = Color.Empty;
            recentPixelBox.Position = new Point(0, 0);
            recentPixelBox.ShowColor = true;
            recentPixelBox.Size = new Size(201, 115);
            recentPixelBox.TabIndex = 14;
            // 
            // distanceBox
            // 
            distanceBox.Location = new Point(0, 245);
            distanceBox.Margin = new Padding(0, 3, 12, 3);
            distanceBox.MinimumSize = new Size(187, 115);
            distanceBox.Name = "distanceBox";
            distanceBox.PixelColor = Color.Empty;
            distanceBox.Position = new Point(0, 0);
            distanceBox.Size = new Size(201, 115);
            distanceBox.TabIndex = 8;
            // 
            // buttonZoomOut
            // 
            buttonZoomOut.AutoSize = true;
            buttonZoomOut.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonZoomOut.Location = new Point(4, 366);
            buttonZoomOut.Margin = new Padding(4, 3, 4, 3);
            buttonZoomOut.Name = "buttonZoomOut";
            buttonZoomOut.Size = new Size(22, 25);
            buttonZoomOut.TabIndex = 10;
            buttonZoomOut.Text = "-";
            toolTip.SetToolTip(buttonZoomOut, "Zoom Out");
            buttonZoomOut.UseVisualStyleBackColor = true;
            buttonZoomOut.Click += buttonZoomOut_Click;
            // 
            // buttonZoomIn
            // 
            buttonZoomIn.AutoSize = true;
            buttonZoomIn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonZoomIn.Location = new Point(34, 366);
            buttonZoomIn.Margin = new Padding(4, 3, 4, 3);
            buttonZoomIn.Name = "buttonZoomIn";
            buttonZoomIn.Size = new Size(25, 25);
            buttonZoomIn.TabIndex = 9;
            buttonZoomIn.Text = "+";
            toolTip.SetToolTip(buttonZoomIn, "Zoom In");
            buttonZoomIn.UseVisualStyleBackColor = true;
            buttonZoomIn.Click += buttonZoomIn_Click;
            // 
            // checkBoxMouseSpeed
            // 
            checkBoxMouseSpeed.Appearance = Appearance.Button;
            checkBoxMouseSpeed.Font = new Font("Wingdings 2", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 2);
            checkBoxMouseSpeed.Location = new Point(67, 366);
            checkBoxMouseSpeed.Margin = new Padding(4, 3, 4, 3);
            checkBoxMouseSpeed.Name = "checkBoxMouseSpeed";
            checkBoxMouseSpeed.Size = new Size(27, 27);
            checkBoxMouseSpeed.TabIndex = 12;
            checkBoxMouseSpeed.Text = ":";
            toolTip.SetToolTip(checkBoxMouseSpeed, "Reduce Mouse Speed (m)");
            checkBoxMouseSpeed.UseVisualStyleBackColor = true;
            checkBoxMouseSpeed.CheckedChanged += checkBoxMouseSpeed_CheckedChanged;
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.BorderStyle = BorderStyle.Fixed3D;
            pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
            pictureBox.Location = new Point(15, 15);
            pictureBox.Margin = new Padding(4, 3, 4, 3);
            pictureBox.MinimumSize = new Size(466, 461);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(466, 461);
            pictureBox.TabIndex = 3;
            pictureBox.TabStop = false;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 493);
            Controls.Add(flowLayoutPanelRight);
            Controls.Add(pictureBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            MinimizeBox = false;
            MinimumSize = new Size(721, 531);
            Name = "MainWindow";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "PixelZoomDlx";
            flowLayoutPanelRight.ResumeLayout(false);
            flowLayoutPanelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();

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

