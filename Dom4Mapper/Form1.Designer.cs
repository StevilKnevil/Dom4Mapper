namespace MapNumbering
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
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(667, 345);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // backgroundWorker1
      // 
      this.backgroundWorker1.WorkerReportsProgress = true;
      this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
      this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
      // 
      // progressBar1
      // 
      this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.progressBar1.Location = new System.Drawing.Point(0, 345);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(667, 23);
      this.progressBar1.TabIndex = 1;
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.DefaultExt = "*.png";
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(667, 368);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.progressBar1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
  }
}

