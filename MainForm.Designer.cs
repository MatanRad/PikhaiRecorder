namespace Pikhai_Recorder
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
            this.RecordButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FreqTrack = new System.Windows.Forms.TrackBar();
            this.AmpTrack = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FreqTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmpTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // RecordButton
            // 
            this.RecordButton.Location = new System.Drawing.Point(13, 13);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(161, 23);
            this.RecordButton.TabIndex = 0;
            this.RecordButton.Text = "Record";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(180, 13);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(164, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(180, 42);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(164, 23);
            this.LoadButton.TabIndex = 2;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Enabled = false;
            this.PlayButton.Location = new System.Drawing.Point(10, 42);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(164, 23);
            this.PlayButton.TabIndex = 3;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Frequency";
            // 
            // FreqTrack
            // 
            this.FreqTrack.Location = new System.Drawing.Point(16, 89);
            this.FreqTrack.Maximum = 22050;
            this.FreqTrack.Minimum = 20;
            this.FreqTrack.Name = "FreqTrack";
            this.FreqTrack.Size = new System.Drawing.Size(328, 45);
            this.FreqTrack.TabIndex = 5;
            this.FreqTrack.TickFrequency = 0;
            this.FreqTrack.Value = 2142;
            this.FreqTrack.Scroll += new System.EventHandler(this.FreqTrack_Scroll);
            // 
            // AmpTrack
            // 
            this.AmpTrack.Location = new System.Drawing.Point(16, 143);
            this.AmpTrack.Maximum = 5000;
            this.AmpTrack.Minimum = 50;
            this.AmpTrack.Name = "AmpTrack";
            this.AmpTrack.Size = new System.Drawing.Size(328, 45);
            this.AmpTrack.TabIndex = 6;
            this.AmpTrack.TickFrequency = 0;
            this.AmpTrack.Value = 1168;
            this.AmpTrack.Scroll += new System.EventHandler(this.AmpTrack_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Amplitude";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 184);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AmpTrack);
            this.Controls.Add(this.FreqTrack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.RecordButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Pikhai Recorder - Rawaii Kawaii";
            ((System.ComponentModel.ISupportInitialize)(this.FreqTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmpTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar FreqTrack;
        private System.Windows.Forms.TrackBar AmpTrack;
        private System.Windows.Forms.Label label2;
    }
}

