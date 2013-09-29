namespace WTWebClient
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMap = new System.Windows.Forms.Panel();
            this.mapPane = new WTWebClient.Component.Map();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.wtMap1 = new WTWebClient.WTMap();
            this.panelMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPane)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMap
            // 
            this.panelMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMap.Controls.Add(this.elementHost1);
            this.panelMap.Controls.Add(this.mapPane);
            this.panelMap.Location = new System.Drawing.Point(12, 12);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(709, 549);
            this.panelMap.TabIndex = 0;
            this.panelMap.SizeChanged += new System.EventHandler(this.panelMap_SizeChanged);
            // 
            // mapPane
            // 
            this.mapPane.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mapPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPane.Location = new System.Drawing.Point(0, 0);
            this.mapPane.Name = "mapPane";
            this.mapPane.Size = new System.Drawing.Size(709, 549);
            this.mapPane.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mapPane.TabIndex = 0;
            this.mapPane.TabStop = false;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(709, 549);
            this.elementHost1.TabIndex = 1;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.wtMap1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 574);
            this.Controls.Add(this.panelMap);
            this.Name = "MainForm";
            this.Text = "War Thunder Dynamic Map";
            this.panelMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapPane)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMap;
        private Component.Map mapPane;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private WTMap wtMap1;
    }
}

