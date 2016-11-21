namespace AudioVideoStreaming
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.d_b_otworz = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.d_cb_video = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.d_cb_audio = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.d_ofd_otworz = new System.Windows.Forms.OpenFileDialog();
            this.d_tb_sciezka = new System.Windows.Forms.TextBox();
            this.d_tb_multicastIP = new System.Windows.Forms.TextBox();
            this.d_b_strumieniuj = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblFrameIndex = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // d_b_otworz
            // 
            this.d_b_otworz.Location = new System.Drawing.Point(447, 31);
            this.d_b_otworz.Name = "d_b_otworz";
            this.d_b_otworz.Size = new System.Drawing.Size(75, 23);
            this.d_b_otworz.TabIndex = 3;
            this.d_b_otworz.Text = "Otwórz...";
            this.d_b_otworz.UseVisualStyleBackColor = true;
            this.d_b_otworz.Click += new System.EventHandler(this.d_b_otworz_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "lub plik video:";
            // 
            // d_cb_video
            // 
            this.d_cb_video.FormattingEnabled = true;
            this.d_cb_video.Location = new System.Drawing.Point(60, 18);
            this.d_cb_video.Name = "d_cb_video";
            this.d_cb_video.Size = new System.Drawing.Size(121, 21);
            this.d_cb_video.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kamera:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.picPreview);
            this.groupBox2.Location = new System.Drawing.Point(12, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 300);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Podgląd transmisji";
            this.groupBox2.Resize += new System.EventHandler(this.groupBox2_Resize);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(286, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 173);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(29, 76);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(202, 173);
            this.picPreview.TabIndex = 1;
            this.picPreview.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mikrofon:";
            // 
            // d_cb_audio
            // 
            this.d_cb_audio.FormattingEnabled = true;
            this.d_cb_audio.Location = new System.Drawing.Point(60, 45);
            this.d_cb_audio.Name = "d_cb_audio";
            this.d_cb_audio.Size = new System.Drawing.Size(121, 21);
            this.d_cb_audio.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Grupa multicastowa:";
            // 
            // d_tb_sciezka
            // 
            this.d_tb_sciezka.Location = new System.Drawing.Point(267, 32);
            this.d_tb_sciezka.Name = "d_tb_sciezka";
            this.d_tb_sciezka.Size = new System.Drawing.Size(174, 20);
            this.d_tb_sciezka.TabIndex = 4;
            // 
            // d_tb_multicastIP
            // 
            this.d_tb_multicastIP.Location = new System.Drawing.Point(122, 103);
            this.d_tb_multicastIP.Name = "d_tb_multicastIP";
            this.d_tb_multicastIP.Size = new System.Drawing.Size(100, 20);
            this.d_tb_multicastIP.TabIndex = 17;
            this.d_tb_multicastIP.Text = "224.0.1.9";
            // 
            // d_b_strumieniuj
            // 
            this.d_b_strumieniuj.Location = new System.Drawing.Point(248, 103);
            this.d_b_strumieniuj.Name = "d_b_strumieniuj";
            this.d_b_strumieniuj.Size = new System.Drawing.Size(75, 23);
            this.d_b_strumieniuj.TabIndex = 15;
            this.d_b_strumieniuj.Text = "Strumieniuj";
            this.d_b_strumieniuj.UseVisualStyleBackColor = true;
            this.d_b_strumieniuj.Click += new System.EventHandler(this.d_b_strumieniuj_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.d_cb_audio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.d_tb_sciezka);
            this.groupBox1.Controls.Add(this.d_b_otworz);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.d_cb_video);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 84);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Źródło wideo";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblFrameIndex
            // 
            this.lblFrameIndex.AutoSize = true;
            this.lblFrameIndex.Location = new System.Drawing.Point(456, 99);
            this.lblFrameIndex.Name = "lblFrameIndex";
            this.lblFrameIndex.Size = new System.Drawing.Size(19, 13);
            this.lblFrameIndex.TabIndex = 19;
            this.lblFrameIndex.Text = "10";
            this.lblFrameIndex.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 442);
            this.Controls.Add(this.lblFrameIndex);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.d_tb_multicastIP);
            this.Controls.Add(this.d_b_strumieniuj);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "AudioVideoStreaming - serwer";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button d_b_otworz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox d_cb_video;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox d_cb_audio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog d_ofd_otworz;
        private System.Windows.Forms.TextBox d_tb_sciezka;
        private System.Windows.Forms.TextBox d_tb_multicastIP;
        private System.Windows.Forms.Button d_b_strumieniuj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblFrameIndex;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

