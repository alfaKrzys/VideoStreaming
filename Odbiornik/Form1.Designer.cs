namespace Odbiornik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.d_tlp_kamery = new System.Windows.Forms.TableLayoutPanel();
            this.d_tb_multicastIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.d_b_strumieniuj = new System.Windows.Forms.Button();
            this.d_komunikat = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.d_flp_strefy = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.d_tlp_kamery);
            this.groupBox2.Location = new System.Drawing.Point(227, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(612, 464);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Podgląd transmisji";
            // 
            // d_tlp_kamery
            // 
            this.d_tlp_kamery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.d_tlp_kamery.ColumnCount = 2;
            this.d_tlp_kamery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.d_tlp_kamery.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.d_tlp_kamery.Location = new System.Drawing.Point(6, 19);
            this.d_tlp_kamery.Name = "d_tlp_kamery";
            this.d_tlp_kamery.RowCount = 2;
            this.d_tlp_kamery.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.d_tlp_kamery.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.d_tlp_kamery.Size = new System.Drawing.Size(600, 439);
            this.d_tlp_kamery.TabIndex = 3;
            // 
            // d_tb_multicastIP
            // 
            this.d_tb_multicastIP.Location = new System.Drawing.Point(121, 12);
            this.d_tb_multicastIP.Name = "d_tb_multicastIP";
            this.d_tb_multicastIP.Size = new System.Drawing.Size(100, 20);
            this.d_tb_multicastIP.TabIndex = 16;
            this.d_tb_multicastIP.Text = "224.0.1.9";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Grupa multicastowa:";
            // 
            // d_b_strumieniuj
            // 
            this.d_b_strumieniuj.Location = new System.Drawing.Point(227, 10);
            this.d_b_strumieniuj.Name = "d_b_strumieniuj";
            this.d_b_strumieniuj.Size = new System.Drawing.Size(75, 23);
            this.d_b_strumieniuj.TabIndex = 14;
            this.d_b_strumieniuj.Text = "Odbieraj";
            this.d_b_strumieniuj.UseVisualStyleBackColor = true;
            this.d_b_strumieniuj.Click += new System.EventHandler(this.d_b_strumieniuj_Click);
            // 
            // d_komunikat
            // 
            this.d_komunikat.ForeColor = System.Drawing.Color.Red;
            this.d_komunikat.Location = new System.Drawing.Point(318, 11);
            this.d_komunikat.Name = "d_komunikat";
            this.d_komunikat.Size = new System.Drawing.Size(521, 20);
            this.d_komunikat.TabIndex = 18;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.d_flp_strefy);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 458);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Strefy ruchu:";
            // 
            // d_flp_strefy
            // 
            this.d_flp_strefy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.d_flp_strefy.AutoScroll = true;
            this.d_flp_strefy.Location = new System.Drawing.Point(7, 20);
            this.d_flp_strefy.Name = "d_flp_strefy";
            this.d_flp_strefy.Size = new System.Drawing.Size(196, 432);
            this.d_flp_strefy.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 519);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.d_komunikat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.d_tb_multicastIP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.d_b_strumieniuj);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "AudioVideoStreaming - odbiornik";
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox d_tb_multicastIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button d_b_strumieniuj;
        private System.Windows.Forms.TableLayoutPanel d_tlp_kamery;
        private System.Windows.Forms.TextBox d_komunikat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel d_flp_strefy;
    }
}

