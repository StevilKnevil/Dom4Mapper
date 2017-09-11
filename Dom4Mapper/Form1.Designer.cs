namespace Dom4Mapper
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
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
      this.toolStrip2 = new System.Windows.Forms.ToolStrip();
      this.addLayerButton = new System.Windows.Forms.ToolStripButton();
      this.removeLayerButton = new System.Windows.Forms.ToolStripButton();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.pictureBox1 = new Dom4Mapper.PanningPictureBox();
      this.toolStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.toolStrip2.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // backgroundWorker1
      // 
      this.backgroundWorker1.WorkerReportsProgress = true;
      this.backgroundWorker1.WorkerSupportsCancellation = true;
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
            this.fontButton});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(482, 25);
      this.toolStrip1.TabIndex = 2;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // fileOpenButton
      // 
      this.fileOpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.fileOpenButton.Image = global::Dom4Mapper.Properties.Resources.Document_24x;
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
      this.fileSaveButton.Image = global::Dom4Mapper.Properties.Resources.Save_20x;
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
      this.fontButton.Image = global::Dom4Mapper.Properties.Resources.Font_16x_24;
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
      this.progressBar.Size = new System.Drawing.Size(100, 16);
      // 
      // cancelButton
      // 
      this.cancelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.cancelButton.Image = global::Dom4Mapper.Properties.Resources.Cancel_16x_24;
      this.cancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(23, 20);
      this.cancelButton.Text = "Cancel";
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
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
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer1.Location = new System.Drawing.Point(0, 25);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.checkedListBox1);
      this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
      this.splitContainer1.Size = new System.Drawing.Size(482, 392);
      this.splitContainer1.SplitterDistance = 160;
      this.splitContainer1.TabIndex = 4;
      // 
      // checkedListBox1
      // 
      this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.checkedListBox1.FormattingEnabled = true;
      this.checkedListBox1.Location = new System.Drawing.Point(0, 25);
      this.checkedListBox1.Name = "checkedListBox1";
      this.checkedListBox1.Size = new System.Drawing.Size(160, 367);
      this.checkedListBox1.TabIndex = 4;
      // 
      // toolStrip2
      // 
      this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLayerButton,
            this.removeLayerButton});
      this.toolStrip2.Location = new System.Drawing.Point(0, 0);
      this.toolStrip2.Name = "toolStrip2";
      this.toolStrip2.Size = new System.Drawing.Size(160, 25);
      this.toolStrip2.TabIndex = 5;
      this.toolStrip2.Text = "toolStrip2";
      // 
      // addLayerButton
      // 
      this.addLayerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.addLayerButton.Image = ((System.Drawing.Image)(resources.GetObject("addLayerButton.Image")));
      this.addLayerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.addLayerButton.Name = "addLayerButton";
      this.addLayerButton.Size = new System.Drawing.Size(23, 22);
      this.addLayerButton.Text = "Add Layer";
      // 
      // removeLayerButton
      // 
      this.removeLayerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.removeLayerButton.Image = ((System.Drawing.Image)(resources.GetObject("removeLayerButton.Image")));
      this.removeLayerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.removeLayerButton.Name = "removeLayerButton";
      this.removeLayerButton.Size = new System.Drawing.Size(23, 22);
      this.removeLayerButton.Text = "Remove Layer";
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.cancelButton});
      this.statusStrip1.Location = new System.Drawing.Point(0, 417);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(482, 22);
      this.statusStrip1.TabIndex = 6;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Offset = new System.Drawing.Point(0, 0);
      this.pictureBox1.Size = new System.Drawing.Size(318, 392);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
      this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
      this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(482, 439);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.statusStrip1);
      this.Name = "Form1";
      this.Text = "Dom4 Mapper";
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.toolStrip2.ResumeLayout(false);
      this.toolStrip2.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private PanningPictureBox pictureBox1;
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
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.CheckedListBox checkedListBox1;
    private System.Windows.Forms.ToolStrip toolStrip2;
    private System.Windows.Forms.ToolStripButton addLayerButton;
    private System.Windows.Forms.ToolStripButton removeLayerButton;
    private System.Windows.Forms.StatusStrip statusStrip1;
  }
}

