using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapNumbering
{
  // TODO: store source image, then make a sopy and add province numbers dynamically when necessary. Perhaps observable collection of provinces as a member and then draw them as they change?
  // This will help when changing the font and font size
  // - Prompt to save
  // - Fix window aspect when opening a file
  public partial class Form1 : Form
  {
    private Bitmap srcBitmap;
    private string MyImageFilename;
    private List<Point> provinces = new List<Point>();


    public Form1()
    {
      InitializeComponent();

      using (InstalledFontCollection fontsCollection = new InstalledFontCollection())
      {
        FontFamily[] fontFamilies = fontsCollection.Families;
        foreach (FontFamily font in fontFamilies)
        {
          fontComboBox.Items.Add(font.Name);
        }
        fontComboBox.SelectedItem = "Arial";
      }

      cancelButton.Visible = false;
      progressBar.Visible = false;

    }

    ~Form1()
    {
      setImage("");
    }

    private void setImage(string imagePath)
    {
      if (srcBitmap != null)
      {
        srcBitmap.Dispose();
        srcBitmap = null;
      }
      if (pictureBox1.Image != null)
      {
        pictureBox1.Image.Dispose();
        pictureBox1.Image = null;
      }
      provinces = new List<Point>();

      if (System.IO.File.Exists(imagePath))
      {
        using (var tgaImage = new Paloma.TargaImage(imagePath))
        {
          srcBitmap = new Bitmap(tgaImage.Image);
        }

        // Todo: Duplicated code
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.ClientSize = new Size(pictureBox1.Width, pictureBox1.Height);
        pictureBox1.Image = generateImage();
      }

    }

    private void fileOpenButton_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        MyImageFilename = openFileDialog1.FileName;

        setImage(MyImageFilename);

        cancelButton.Visible = true;
        progressBar.Visible = true;
        provinces.Clear();
        backgroundWorker1.RunWorkerAsync(srcBitmap);
      }
    }

    private void fileSaveButton_Click(object sender, EventArgs e)
    {
      /*
      string outFile = System.IO.Path.GetDirectoryName(MyImageFilename) + @"\" +
        System.IO.Path.GetFileNameWithoutExtension(MyImageFilename) +
        "_numbered" +
        System.IO.Path.GetExtension(MyImageFilename);

      MyImage.Save(outFile);
      */
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
      BackgroundWorker bgw = sender as BackgroundWorker;
      Bitmap bmp = e.Argument as Bitmap;
      List<Rectangle> provs = new List<Rectangle>();
      // parse image for regions
      for (int y = bmp.Height - 1; y >= 0; y--)
      {
        for (int x = 0; x < bmp.Width; x++)
        {
          var col = bmp.GetPixel(x, y);
          if (col.R == 255 && col.G == 255 && col.B == 255)
          {
            // This is a Province
            // Filter to check to see if we already have a province right next to this
            bool dupe = false;
            for (int i = 0; i < provs.Count; i++)
            {
              var prov = provs[i];
              if (RectIncludeNeighboringPoint(ref prov, new Point(x, y)))
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
        bgw.ReportProgress(((bmp.Height-y) * 100) / bmp.Height);
      }

      // return the result
      List<Point> result = new List<Point>();
      foreach (var r in provs)
      {
        // add the centre point
        result.Add(new Point(r.X + (r.Width / 2), r.Y + (r.Height / 2)));
      }
      e.Result = result;
    }

    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      this.progressBar.Value = e.ProgressPercentage;
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      cancelButton.Visible = false;
      progressBar.Visible = false;

      provinces = e.Result as List<Point>;

      // Stretches the image to fit the pictureBox.
      pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      pictureBox1.ClientSize = new Size(pictureBox1.Width, pictureBox1.Height);
      pictureBox1.Image = generateImage();

      fileSaveButton.Enabled = true;
    }

    private Bitmap generateImage()
    {
      Bitmap newImage = new Bitmap(srcBitmap);

      // render the region numbers
      int num = 1;
      using (var graphics = Graphics.FromImage(newImage))
      {
        Brush b = new SolidBrush(Color.Black);
        Font f = new Font("Arial", 50, FontStyle.Bold);
        foreach (var prov in provinces)
        {
          var sz = graphics.MeasureString(num.ToString(), f, 10000);
          Point pt = new Point(prov.X - (int)(sz.Width / 2), prov.Y - (int)(sz.Height / 2));
          if (pt.X< 0)
            pt.X = 0;
          if (pt.Y< 0)
            pt.Y = 0;
          if (pt.X + sz.Width > newImage.Width)
            pt.X = newImage.Width - (int)sz.Width;
          if (pt.Y + sz.Height > newImage.Height)
            pt.Y = newImage.Height - (int)sz.Height;
          graphics.DrawString(num.ToString(), f, b, pt);
          num++;
        }
      }

      return newImage;
    }

  }
}
