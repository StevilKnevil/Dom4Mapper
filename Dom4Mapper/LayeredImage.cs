using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom4Mapper
{
  class LayeredImage
  {
    public class Layer
    {
      public Layer(Bitmap img)
      {
        this.Image = new Bitmap(img);
        this.Visible = true;
        this.Transparency = 100;
      }

      public Bitmap Image { get; set; }
      public bool Visible { get; set; }
      public int Transparency { get; set; }

      public event EventHandler LayerChanged
      {
        add
        {
          // Subscription logic here
        }
        remove
        {
          // Unsubscription logic here
        }
      }
    }

    public ObservableCollection<Layer> Layers = new ObservableCollection<Layer>();
    Bitmap backgroundImage = null;
    Bitmap finalImage = null;
    bool finalImageDirty = true;

    public Bitmap BackgroundImage
    {
      get { return backgroundImage; }
      set {
        if (backgroundImage != null)
          backgroundImage.Dispose();
        backgroundImage = new Bitmap(value);
        finalImageDirty = true;
      }
    }

    public LayeredImage()
    {
      Layers.CollectionChanged += onLayersChanged;
    }

    private void onLayersChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
      if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
      {
        foreach (Layer item in e.NewItems)
        {
          item.LayerChanged += onLayerChanged;
        }
      }
      if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove ||
        e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace
        )
      {
        foreach (Layer item in e.OldItems)
        {
          item.LayerChanged -= onLayerChanged;
        }
      }
      finalImageDirty = true;
    }

    private void onLayerChanged(object sender, EventArgs e)
    {
      finalImageDirty = true;
    }

    void updateFinalImage()
    {
      if (finalImage != null)
      {
        finalImage.Dispose();
        finalImage = null;
      }

      finalImage = new Bitmap(backgroundImage);
      using (Graphics gfx = Graphics.FromImage(finalImage))
      {
        foreach (var i in Layers)
        {
          if (i.Visible)
          {
            //create a color matrix object  
            ColorMatrix matrix = new ColorMatrix();

            //set the opacity  
            matrix.Matrix33 = i.Transparency;

            //create image attributes  
            ImageAttributes attributes = new ImageAttributes();

            //set the color(opacity) of the image  
            attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            Bitmap img = i.Image;

            gfx.DrawImage(img,
              new Rectangle(0, 0, finalImage.Width, finalImage.Height), 0, 0,
              img.Width, img.Height, GraphicsUnit.Pixel, attributes);
          }
        }
      }

      // TODO: Fire an event when the image has been updated. Have a bgw (or timer?) that updates the final image?
      finalImageDirty = false;
    }

    public Bitmap GetFinalImage()
    {
      if (finalImageDirty == true)
        updateFinalImage();

      return finalImage;
    }
  }
}
