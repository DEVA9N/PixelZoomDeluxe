namespace PixelZoomDlx
{
	partial class PixelValueControl
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

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labelARGBValue = new System.Windows.Forms.Label();
			this.labelYValue = new System.Windows.Forms.Label();
			this.labelXValue = new System.Windows.Forms.Label();
			this.labelARGB = new System.Windows.Forms.Label();
			this.labelY = new System.Windows.Forms.Label();
			this.labelX = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.labelARGBValue);
			this.groupBox1.Controls.Add(this.labelYValue);
			this.groupBox1.Controls.Add(this.labelXValue);
			this.groupBox1.Controls.Add(this.labelARGB);
			this.groupBox1.Controls.Add(this.labelY);
			this.groupBox1.Controls.Add(this.labelX);
			this.groupBox1.Location = new System.Drawing.Point(4, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(165, 63);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// labelARGBValue
			// 
			this.labelARGBValue.AutoSize = true;
			this.labelARGBValue.Location = new System.Drawing.Point(52, 42);
			this.labelARGBValue.Name = "labelARGBValue";
			this.labelARGBValue.Size = new System.Drawing.Size(0, 13);
			this.labelARGBValue.TabIndex = 7;
			// 
			// labelYValue
			// 
			this.labelYValue.AutoSize = true;
			this.labelYValue.Location = new System.Drawing.Point(52, 29);
			this.labelYValue.Name = "labelYValue";
			this.labelYValue.Size = new System.Drawing.Size(0, 13);
			this.labelYValue.TabIndex = 6;
			// 
			// labelXValue
			// 
			this.labelXValue.AutoSize = true;
			this.labelXValue.Location = new System.Drawing.Point(52, 16);
			this.labelXValue.Name = "labelXValue";
			this.labelXValue.Size = new System.Drawing.Size(0, 13);
			this.labelXValue.TabIndex = 5;
			// 
			// labelARGB
			// 
			this.labelARGB.AutoSize = true;
			this.labelARGB.Location = new System.Drawing.Point(6, 42);
			this.labelARGB.Name = "labelARGB";
			this.labelARGB.Size = new System.Drawing.Size(40, 13);
			this.labelARGB.TabIndex = 2;
			this.labelARGB.Text = "ARGB:";
			// 
			// labelY
			// 
			this.labelY.AutoSize = true;
			this.labelY.Location = new System.Drawing.Point(6, 29);
			this.labelY.Name = "labelY";
			this.labelY.Size = new System.Drawing.Size(17, 13);
			this.labelY.TabIndex = 1;
			this.labelY.Text = "Y:";
			// 
			// labelX
			// 
			this.labelX.AutoSize = true;
			this.labelX.Location = new System.Drawing.Point(6, 16);
			this.labelX.Name = "labelX";
			this.labelX.Size = new System.Drawing.Size(17, 13);
			this.labelX.TabIndex = 0;
			this.labelX.Text = "X:";
			// 
			// PixelValueControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.MinimumSize = new System.Drawing.Size(160, 70);
			this.Name = "PixelValueControl";
			this.Size = new System.Drawing.Size(172, 70);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label labelX;
		private System.Windows.Forms.Label labelARGBValue;
		private System.Windows.Forms.Label labelYValue;
		private System.Windows.Forms.Label labelXValue;
		private System.Windows.Forms.Label labelARGB;
		private System.Windows.Forms.Label labelY;
	}
}
