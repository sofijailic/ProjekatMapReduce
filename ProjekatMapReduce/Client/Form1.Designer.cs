namespace Client
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMapper1port = new System.Windows.Forms.TextBox();
            this.tbMapper2port = new System.Windows.Forms.TextBox();
            this.btnConnectMapper1 = new System.Windows.Forms.Button();
            this.btnConnectMapper2 = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnSendData = new System.Windows.Forms.Button();
            this.btnReduceData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "port Mapper1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "port Mapper2";
            // 
            // tbMapper1port
            // 
            this.tbMapper1port.Location = new System.Drawing.Point(116, 27);
            this.tbMapper1port.Name = "tbMapper1port";
            this.tbMapper1port.Size = new System.Drawing.Size(100, 20);
            this.tbMapper1port.TabIndex = 2;
            // 
            // tbMapper2port
            // 
            this.tbMapper2port.Location = new System.Drawing.Point(116, 66);
            this.tbMapper2port.Name = "tbMapper2port";
            this.tbMapper2port.Size = new System.Drawing.Size(100, 20);
            this.tbMapper2port.TabIndex = 3;
            // 
            // btnConnectMapper1
            // 
            this.btnConnectMapper1.Location = new System.Drawing.Point(271, 24);
            this.btnConnectMapper1.Name = "btnConnectMapper1";
            this.btnConnectMapper1.Size = new System.Drawing.Size(75, 23);
            this.btnConnectMapper1.TabIndex = 4;
            this.btnConnectMapper1.Text = "Connect";
            this.btnConnectMapper1.UseVisualStyleBackColor = true;
            this.btnConnectMapper1.Click += new System.EventHandler(this.btnConnectMapper1_Click);
            // 
            // btnConnectMapper2
            // 
            this.btnConnectMapper2.Location = new System.Drawing.Point(271, 63);
            this.btnConnectMapper2.Name = "btnConnectMapper2";
            this.btnConnectMapper2.Size = new System.Drawing.Size(75, 23);
            this.btnConnectMapper2.TabIndex = 5;
            this.btnConnectMapper2.Text = "Connect";
            this.btnConnectMapper2.UseVisualStyleBackColor = true;
            this.btnConnectMapper2.Click += new System.EventHandler(this.btnConnectMapper2_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(30, 136);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 6;
            this.btnLoadData.Text = "load data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(30, 191);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(75, 23);
            this.btnSendData.TabIndex = 7;
            this.btnSendData.Text = "send data";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // btnReduceData
            // 
            this.btnReduceData.Location = new System.Drawing.Point(30, 250);
            this.btnReduceData.Name = "btnReduceData";
            this.btnReduceData.Size = new System.Drawing.Size(75, 23);
            this.btnReduceData.TabIndex = 8;
            this.btnReduceData.Text = "reduce all data";
            this.btnReduceData.UseVisualStyleBackColor = true;
            this.btnReduceData.Click += new System.EventHandler(this.btnReduceData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(398, 327);
            this.Controls.Add(this.btnReduceData);
            this.Controls.Add(this.btnSendData);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.btnConnectMapper2);
            this.Controls.Add(this.btnConnectMapper1);
            this.Controls.Add(this.tbMapper2port);
            this.Controls.Add(this.tbMapper1port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMapper1port;
        private System.Windows.Forms.TextBox tbMapper2port;
        private System.Windows.Forms.Button btnConnectMapper1;
        private System.Windows.Forms.Button btnConnectMapper2;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Button btnReduceData;
    }
}

