using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom4Mapper
{
  class ProvinceExtractor
  {
    BackgroundWorker backgroundWorker1 = new BackgroundWorker();

    public event ProgressChangedEventHandler ProgressChanged
    {
      add { backgroundWorker1.ProgressChanged += value; }
      remove { backgroundWorker1.ProgressChanged -= value; }
    }

    public event RunWorkerCompletedEventHandler RunWorkerCompleted
    {
      add { backgroundWorker1.RunWorkerCompleted += value; }
      remove { backgroundWorker1.RunWorkerCompleted -= value; }
    }


    public ProvinceExtractor()
    {
      // 
      // backgroundWorker1
      // 
      this.backgroundWorker1.WorkerReportsProgress = true;
      this.backgroundWorker1.WorkerSupportsCancellation = true;
      this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
    }

    public void ProcessImage(Bitmap image)
    {
      this.Cancel();
      backgroundWorker1.RunWorkerAsync(image);
    }

    public void Cancel()
    {
      if (backgroundWorker1.IsBusy)
        backgroundWorker1.CancelAsync();
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker bgw = sender as System.ComponentModel.BackgroundWorker;
      Bitmap bmp = e.Argument as Bitmap;
      List<Rectangle> provs = new List<Rectangle>();
      // parse image for regions
      for (int y = bmp.Height - 1; y >= 0; y--)
      {
        for (int x = 0; x < bmp.Width; x++)
        {
          if (bgw.CancellationPending)
          {
            e.Cancel = true;
            return;
          }

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
        bgw.ReportProgress(((bmp.Height - y) * 100) / bmp.Height);
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


    #region helpers

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

    #endregion
  }
}
