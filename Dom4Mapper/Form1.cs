using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapNumbering
{
  public partial class Form1 : Form
  {
    private Bitmap MyImage;
    private string MyImageFilename;
    public Form1()
    {
      InitializeComponent();
      if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        MyImageFilename = openFileDialog1.FileName;
        ShowMyImage(MyImageFilename, pictureBox1.Width, pictureBox1.Height);
        backgroundWorker1.RunWorkerAsync();
      }
    }

    public void ShowMyImage(String fileToDisplay, int xSize, int ySize)
    {
      // Sets up an image object to be displayed.
      if (MyImage != null)
      {
        MyImage.Dispose();
      }
      MyImage = new Bitmap(fileToDisplay);
    }

    bool RectIncludeNeighboringPoint(ref Rectangle r, Point p)
    {
      if (r.Contains(p))
      {
        // Nothing to do
        return true;
      }

      bool success = false;
      // See if the point is neighbouring & grow if so
      if (r.Contains(p.X - 1, p.Y))
      {
        r.Width++;
        success = true;
      }
      if (r.Contains(p.X + 1, p.Y))
      {
        r.X--;
        r.Width++;
        success = true;
      }
      if (r.Contains(p.X, p.Y - 1))
      {
        r.Height++;
        success = true;
      }
      if (r.Contains(p.X, p.Y + 1))
      {
        r.Y--;
        r.Height++;
        success = true;
      }

      return success;
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {

      List<Rectangle> provs = new List<Rectangle>();
      // parse image for regions
      for (int y = MyImage.Height-1; y >= 0; y--)
      {
        for (int x = 0; x < MyImage.Width; x++)
        {
          var col = MyImage.GetPixel(x, y);
          if (col.R == 255 && col.G == 255 && col.B == 255)
          {
            // This is a Province
            // Filter to check to see if we already have a province right next to this
            bool dupe = false;
            for (int i= 0; i< provs.Count; i++)
            {
              var prov = provs[i];
              if (RectIncludeNeighboringPoint(ref prov, new Point(x,y)))
              {
                // Dupe found
                dupe = true;
                provs[i] = prov;
                continue;
              }
            }
            // new prov found
            if (!dupe)
            {
              provs.Add(new Rectangle(x, y, 1, 1));
            }
          }
        }
        (sender as BackgroundWorker).ReportProgress((y * 100) / MyImage.Height);
      }

      // render the region numbers
      int num = 1;
      using (var graphics = Graphics.FromImage(MyImage))
      {
        Brush b = new SolidBrush(Color.Black);
        Font f = new Font("Arial", 140, FontStyle.Bold);
        foreach (Rectangle r in provs)
        {
          var sz = graphics.MeasureString(num.ToString(), f, 10000);
          Point pt = new Point(r.X - (int)(sz.Width / 2), r.Y - (int)(sz.Height / 2));
          if (pt.X < 0)
            pt.X = 0;
          if (pt.Y < 0)
            pt.Y = 0;
          if (pt.X + sz.Width > MyImage.Width)
            pt.X = MyImage.Width - (int)sz.Width;
          if (pt.Y + sz.Height > MyImage.Height)
            pt.Y = MyImage.Height - (int)sz.Height;
          graphics.DrawString(num.ToString(), f, b, pt);
          num++;
        }
      }
    }

    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      this.progressBar1.Value = e.ProgressPercentage;
      this.progressBar1.Refresh();
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      progressBar1.Visible = false;
      // Stretches the image to fit the pictureBox.
      pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      pictureBox1.ClientSize = new Size(pictureBox1.Width, pictureBox1.Height);
      pictureBox1.Image = (Image)MyImage;

      string outFile = System.IO.Path.GetDirectoryName(MyImageFilename) + @"\" +
        System.IO.Path.GetFileNameWithoutExtension(MyImageFilename) +
        "_numbered" +
        System.IO.Path.GetExtension(MyImageFilename);

      MyImage.Save(outFile);
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
  }

}
