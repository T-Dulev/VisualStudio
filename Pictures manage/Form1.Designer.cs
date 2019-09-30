namespace Pictures_manage
{
    partial class Form1
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
            this.pic = new System.Windows.Forms.PictureBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.lPath = new System.Windows.Forms.Label();
            this.lCurrFile = new System.Windows.Forms.Label();
            this.bLeft = new System.Windows.Forms.Button();
            this.bRight = new System.Windows.Forms.Button();
            this.lProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pic.Location = new System.Drawing.Point(59, 12);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(800, 800);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(880, 12);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(131, 23);
            this.Button2.TabIndex = 4;
            this.Button2.Text = "Избор на папка";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // lPath
            // 
            this.lPath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lPath.Location = new System.Drawing.Point(877, 38);
            this.lPath.Name = "lPath";
            this.lPath.Size = new System.Drawing.Size(327, 16);
            this.lPath.TabIndex = 5;
            this.lPath.Click += new System.EventHandler(this.lPath_Click);
            // 
            // lCurrFile
            // 
            this.lCurrFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lCurrFile.Location = new System.Drawing.Point(877, 65);
            this.lCurrFile.Name = "lCurrFile";
            this.lCurrFile.Size = new System.Drawing.Size(327, 16);
            this.lCurrFile.TabIndex = 6;
            // 
            // bLeft
            // 
            this.bLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bLeft.Location = new System.Drawing.Point(880, 85);
            this.bLeft.Name = "bLeft";
            this.bLeft.Size = new System.Drawing.Size(23, 23);
            this.bLeft.TabIndex = 7;
            this.bLeft.Tag = "Z";
            this.bLeft.Text = "<";
            this.bLeft.UseVisualStyleBackColor = true;
            this.bLeft.Click += new System.EventHandler(this.bLeft_Click);
            // 
            // bRight
            // 
            this.bRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bRight.Location = new System.Drawing.Point(909, 85);
            this.bRight.Name = "bRight";
            this.bRight.Size = new System.Drawing.Size(23, 23);
            this.bRight.TabIndex = 8;
            this.bRight.Tag = "X";
            this.bRight.Text = ">";
            this.bRight.UseVisualStyleBackColor = true;
            this.bRight.Click += new System.EventHandler(this.bRight_Click);
            // 
            // lProgress
            // 
            this.lProgress.AutoSize = true;
            this.lProgress.Location = new System.Drawing.Point(940, 91);
            this.lProgress.Name = "lProgress";
            this.lProgress.Size = new System.Drawing.Size(24, 13);
            this.lProgress.TabIndex = 9;
            this.lProgress.Text = "0/1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 822);
            this.Controls.Add(this.lProgress);
            this.Controls.Add(this.bRight);
            this.Controls.Add(this.bLeft);
            this.Controls.Add(this.lCurrFile);
            this.Controls.Add(this.lPath);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.pic);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Снимкоорганайзер";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic;
        internal System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Label lPath;
        private System.Windows.Forms.Label lCurrFile;
        private System.Windows.Forms.Button bLeft;
        private System.Windows.Forms.Button bRight;
        private System.Windows.Forms.Label lProgress;

    }
}

