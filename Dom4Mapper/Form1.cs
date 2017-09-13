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

namespace Dom4Mapper
{
  // - Prompt to save
  // - Fix window aspect when opening a file
  public partial class Form1 : Form
  {
    private string MyImageFilename;
    private List<Point> provinces = new List<Point>();
    private LayeredImage layeredImage = new LayeredImage();
    ProvinceExtractor provinceExtractor = new ProvinceExtractor();

    public Form1()
    {
      InitializeComponent();

      cancelButton.Visible = false;
      progressBar.Visible = false;

      fontDialog1.Font = new Font("Arial", 48);

      this.provinceExtractor.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.provinceExtractor_ProgressChanged);
      this.provinceExtractor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.provinceExtractor_RunWorkerCompleted);
    }

    ~Form1()
    {
      setImage("");
    }

    #region Toolbar

    private void fileOpenButton_Click(object sender, EventArgs e)
    {
      if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        MyImageFilename = openFileDialog1.FileName;

        setImage(MyImageFilename);

        cancelButton.Visible = true;
        progressBar.Visible = true;
        provinces.Clear();
        provinceExtractor.ProcessImage(layeredImage.BackgroundImage);
      }
    }

    private void fileSaveButton_Click(object sender, EventArgs e)
    {
      saveFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(MyImageFilename);
      saveFileDialog1.FileName = System.IO.Path.GetFileNameWithoutExtension(MyImageFilename) +
        "_numbered";

      // Displays a SaveFileDialog so the user can save the Image  
      // assigned to Button2.  
      saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png";
      saveFileDialog1.Title = "Save the map image";
      saveFileDialog1.ShowDialog();

      // If the file name is not an empty string open it for saving.  
      if (saveFileDialog1.FileName != "")
      {
        // Saves the Image via a FileStream created by the OpenFile method.  
        System.IO.FileStream fs =
           (System.IO.FileStream)saveFileDialog1.OpenFile();
        // Saves the Image in the appropriate ImageFormat based upon the  
        // File type selected in the dialog box.  
        // NOTE that the FilterIndex property is one-based.  
        switch (saveFileDialog1.FilterIndex)
        {
          case 1:
            this.pictureBox1.Image.Save(fs,
               System.Drawing.Imaging.ImageFormat.Jpeg);
            break;

          case 2:
            this.pictureBox1.Image.Save(fs,
               System.Drawing.Imaging.ImageFormat.Bmp);
            break;

          case 3:
            this.pictureBox1.Image.Save(fs,
               System.Drawing.Imaging.ImageFormat.Gif);
            break;

          case 4:
            this.pictureBox1.Image.Save(fs,
               System.Drawing.Imaging.ImageFormat.Png);
            break;
        }

        fs.Close();
      }
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
      provinceExtractor.Cancel();
    }

    private void fontButton_Click(object sender, EventArgs e)
    {
      if (fontDialog1.ShowDialog() != DialogResult.Cancel)
      {
        updateImage();
      }
    }

    private void fontDialog1_Apply(object sender, EventArgs e)
    {
      updateImage();
    }

    #endregion

    private void setImage(string imagePath)
    {
      if (pictureBox1.Image != null)
      {
        pictureBox1.Image.Dispose();
        pictureBox1.Image = null;
      }

      provinces.Clear();

      if (System.IO.File.Exists(imagePath))
      {
        using (var tgaImage = new Paloma.TargaImage(imagePath))
        {
          layeredImage.BackgroundImage = tgaImage.Image;
        }

        updateImage();
      }

    }

    private void updateImage()
    {
      // Stretches the image to fit the pictureBox.
      pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      pictureBox1.ClientSize = new Size(pictureBox1.Width, pictureBox1.Height);
      if (pictureBox1.Image != null)
      {
        pictureBox1.Image.Dispose();
        pictureBox1.Image = null;
      }
      // TODO: Update province numbers layer: generateImage();
      pictureBox1.Image = new Bitmap(layeredImage.GetFinalImage());
    }


    private Bitmap generateProvinceNumersImage()
    {
      if (layeredImage.BackgroundImage == null)
        return null;

      Bitmap newImage = new Bitmap(
        layeredImage.BackgroundImage.Size.Width,
        layeredImage.BackgroundImage.Size.Height);

      // render the region numbers
      int num = 1;
      using (var graphics = Graphics.FromImage(newImage))
      {
        Brush b = new SolidBrush(fontDialog1.Color);
        Font f = fontDialog1.Font;
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



    private void provinceExtractor_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      this.progressBar.Value = e.ProgressPercentage;
    }

    private void provinceExtractor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      cancelButton.Visible = false;
      progressBar.Visible = false;

      if (e.Cancelled == false)
      {
        // Copy the result
        provinces = e.Result as List<Point>;
      }

      Bitmap img = generateProvinceNumersImage();
      checkedListBox1.Items.Add("Provinces", true);
      layeredImage.Layers.Insert(0, new LayeredImage.Layer(img));

      updateImage();

      fileSaveButton.Enabled = true;
    }


    private bool dragging = false;
    private Point dragStart;
    private Point dragOffset = new Point(0, 0);
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        this.dragging = true;
        dragStart = new Point(e.X, e.Y);
      }
      else
      {
        this.dragging = false;
      }
    }

    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
      if (this.dragging)
      {
        this.dragging = false;
      }
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.dragging)
      {
        dragOffset.X = e.X - dragStart.X;
        dragOffset.Y = e.Y - dragStart.Y;
        // transform the picture to freflect dragging
        pictureBox1.Offset = new Point(pictureBox1.Offset.X + dragOffset.X,
          pictureBox1.Offset.Y + dragOffset.Y);

        dragStart.X = e.X;
        dragStart.Y = e.Y;
      }
    }
  }
}
