namespace RedditScraperProject
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
            this.startButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.subredditBox = new System.Windows.Forms.TextBox();
            this.saveLocationBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.countBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(6, 82);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.Start);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(29, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 100;
            this.label1.Text = "Subreddit: ";
            // 
            // subredditBox
            // 
            this.subredditBox.Location = new System.Drawing.Point(89, 36);
            this.subredditBox.Name = "subredditBox";
            this.subredditBox.Size = new System.Drawing.Size(127, 20);
            this.subredditBox.TabIndex = 1;
            // 
            // saveLocationBox
            // 
            this.saveLocationBox.Location = new System.Drawing.Point(89, 59);
            this.saveLocationBox.Name = "saveLocationBox";
            this.saveLocationBox.Size = new System.Drawing.Size(127, 20);
            this.saveLocationBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(46, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 100;
            this.label2.Text = "Count: ";
            // 
            // countBox
            // 
            this.countBox.Location = new System.Drawing.Point(89, 12);
            this.countBox.Name = "countBox";
            this.countBox.Size = new System.Drawing.Size(127, 20);
            this.countBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 19);
            this.label3.TabIndex = 100;
            this.label3.Text = "Save Location:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(87, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 23);
            this.label4.TabIndex = 100;
            this.label4.Text = "Post: ";
            // 
            // countLabel
            // 
            this.countLabel.Location = new System.Drawing.Point(117, 83);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(99, 23);
            this.countLabel.TabIndex = 100;
            this.countLabel.Text = "0/0";
            // 
            // Form1
            // 
            this.AcceptButton = this.startButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 116);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.countBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveLocationBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subredditBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Scraper";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox countBox;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox saveLocationBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TextBox subredditBox;

        #endregion
    }
}