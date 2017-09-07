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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.fileOpenButton = new System.Windows.Forms.ToolStripButton();
      this.fileSaveButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.fontButton = new System.Windows.Forms.ToolStripButton();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
      this.cancelButton = new System.Windows.Forms.ToolStripButton();
      this.fontDialog1 = new System.Windows.Forms.FontDialog();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox1.Location = new System.Drawing.Point(0, 25);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(667, 343);
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
      // openFileDialog1
      // 
      this.openFileDialog1.DefaultExt = "tga";
      this.openFileDialog1.FileName = "openFileDialog1";
      this.openFileDialog1.Filter = "Targa files|*.tga";
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpenButton,
            this.fileSaveButton,
            this.toolStripSeparator1,
            this.fontButton,
            this.toolStripSeparator2,
            this.progressBar,
            this.cancelButton});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(667, 25);
      this.toolStrip1.TabIndex = 2;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // fileOpenButton
      // 
      this.fileOpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.fileOpenButton.Image = ((System.Drawing.Image)(resources.GetObject("fileOpenButton.Image")));
      this.fileOpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.fileOpenButton.Name = "fileOpenButton";
      this.fileOpenButton.Size = new System.Drawing.Size(23, 22);
      this.fileOpenButton.Text = "Open";
      this.fileOpenButton.Click += new System.EventHandler(this.fileOpenButton_Click);
      // 
      // fileSaveButton
      // 
      this.fileSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.fileSaveButton.Enabled = false;
      this.fileSaveButton.Image = ((System.Drawing.Image)(resources.GetObject("fileSaveButton.Image")));
      this.fileSaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.fileSaveButton.Name = "fileSaveButton";
      this.fileSaveButton.Size = new System.Drawing.Size(23, 22);
      this.fileSaveButton.Text = "Save";
      this.fileSaveButton.Click += new System.EventHandler(this.fileSaveButton_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // fontButton
      // 
      this.fontButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.fontButton.Image = ((System.Drawing.Image)(resources.GetObject("fontButton.Image")));
      this.fontButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.fontButton.Name = "fontButton";
      this.fontButton.Size = new System.Drawing.Size(23, 22);
      this.fontButton.Text = "Font ...";
      this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
      // 
      // progressBar
      // 
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(100, 22);
      // 
      // cancelButton
      // 
      this.cancelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
      this.cancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(23, 22);
      this.cancelButton.Text = "Cancel";
      // 
      // fontDialog1
      // 
      this.fontDialog1.ShowApply = true;
      this.fontDialog1.ShowColor = true;
      this.fontDialog1.Apply += new System.EventHandler(this.fontDialog1_Apply);
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.Filter = "PNG Files|*.png";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(667, 368);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.toolStrip1);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton fileOpenButton;
    private System.Windows.Forms.ToolStripButton fileSaveButton;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripProgressBar progressBar;
    private System.Windows.Forms.ToolStripButton cancelButton;
    private System.Windows.Forms.ToolStripButton fontButton;
    private System.Windows.Forms.FontDialog fontDialog1;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
  }
}

