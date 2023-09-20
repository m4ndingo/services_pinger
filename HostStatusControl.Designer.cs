
namespace Pinger
{
    partial class HostStatusControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostStatusControl));
            this.lblHostPort = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblLastCheckDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHostPort
            // 
            this.lblHostPort.AutoSize = true;
            this.lblHostPort.Location = new System.Drawing.Point(3, 11);
            this.lblHostPort.Name = "lblHostPort";
            this.lblHostPort.Size = new System.Drawing.Size(67, 13);
            this.lblHostPort.TabIndex = 0;
            this.lblHostPort.Text = "HOSTPORT";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(166, 11);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "STATUS";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(237, 11);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(80, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "DESCRIPTION";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "sphere_gray_30x30.png");
            this.imageList1.Images.SetKeyName(1, "sphere_red_30x30.png");
            this.imageList1.Images.SetKeyName(2, "sphere_green_30x30.png");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(131, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(524, 6);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(66, 23);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblLastCheckDate
            // 
            this.lblLastCheckDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastCheckDate.AutoSize = true;
            this.lblLastCheckDate.Location = new System.Drawing.Point(410, 11);
            this.lblLastCheckDate.Name = "lblLastCheckDate";
            this.lblLastCheckDate.Size = new System.Drawing.Size(99, 13);
            this.lblLastCheckDate.TabIndex = 6;
            this.lblLastCheckDate.Text = "LASTCHECKDATE";
            // 
            // HostStatusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLastCheckDate);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblHostPort);
            this.Name = "HostStatusControl";
            this.Size = new System.Drawing.Size(592, 35);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHostPort;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblLastCheckDate;
    }
}
