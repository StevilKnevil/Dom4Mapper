using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dom4Mapper
{
  class PanningPictureBox : PictureBox
  {
    private Point offset;
    public Point Offset
    {
      get { return offset; }
      set
      {
        offset = value;
        this.Refresh();
      }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
      var g = pe.Graphics;
      // TODO: Maintian aspect ratio
      var r = new Rectangle(new Point(0,0), this.Size);
      r.X += Offset.X;
      r.Y += Offset.Y;
      g.DrawImage(this.Image, r);

      if (r.X > 0 && r.Y > 0)
      {
        r.X -= r.Width;
        g.DrawImage(this.Image, r);
        r.Y -= r.Height;
        g.DrawImage(this.Image, r);
        r.X += r.Width;
        g.DrawImage(this.Image, r);
      }
    }


  }
}
