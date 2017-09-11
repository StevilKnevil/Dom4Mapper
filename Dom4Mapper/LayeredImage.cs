using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dom4Mapper
{
  class LayeredImage
  {
    public ObservableCollection<Bitmap> Layers = new ObservableCollection<Bitmap>();
    Bitmap backgroundImage = null;
    Bitmap finalImage = null;
    bool finalImageDirty = true;

    public Bitmap BackgroundImage
    {
      get { return backgroundImage; }
      set { backgroundImage = value; finalImageDirty = true; }
    }

    public LayeredImage()
    {
      Layers.CollectionChanged += onLayersChanged;
    }

    private void onLayersChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
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
      foreach (var i in Layers)
      {
        // TODO: copy with 50% transparency
        finalImage = new Bitmap(i);
      }

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
