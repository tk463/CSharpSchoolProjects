using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BLL;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;

namespace WpfApplicationAdmin
{
    public class ImgToBitmapImg : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is UtilisateurDto)
            {
                Image converting = ((UtilisateurDto)value).Photo;
                return doConvert(converting);
            }
            if (value is RepertoireDto)
            {
                Image converting = ((RepertoireDto)value).Photo;
                return doConvert(converting);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private BitmapImage doConvert(Image toConvert)
        {
            if (toConvert != null)
            {
                BitmapImage bitmapImg = new BitmapImage();
                using (MemoryStream ms = new MemoryStream())
                {
                    toConvert.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.Position = 0;
                    bitmapImg.BeginInit();
                    bitmapImg.StreamSource = ms;
                    bitmapImg.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImg.DecodePixelHeight = 80;
                    bitmapImg.DecodePixelWidth = 80;
                    bitmapImg.EndInit();
                }
                return bitmapImg;
            }
            else
            {
                return null;
            }
        }
    }
}
