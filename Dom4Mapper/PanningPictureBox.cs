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
        // TODO: handle this all in 'image' coordinates, and have screen <-> image conversion helper fns
        offset = value;
        // clamp
        while (offset.X >= this.Size.Width)
          offset.X -= this.Size.Width;
        while (offset.Y >= this.Size.Height)
          offset.Y -= this.Size.Height;
        while (offset.X < 0)
          offset.X += this.Size.Width;
        while (offset.Y < 0)
          offset.Y += this.Size.Height;
        this.Refresh();
      }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
      if (Image == null)
        return;

      var g = pe.Graphics;
      // TODO: Maintian aspect ratio
      var r = new Rectangle(new Point(0,0), this.Size);
      r.X += Offset.X;
      r.Y += Offset.Y;
      g.DrawImage(this.Image, r);

      // Draw for tling
      r.X -= r.Width;
      g.DrawImage(this.Image, r);
      r.Y -= r.Height;
      g.DrawImage(this.Image, r);
      r.X += r.Width;
      g.DrawImage(this.Image, r);
    }


  }
}
