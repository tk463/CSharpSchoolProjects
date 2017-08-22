using System.Data.Linq;
using System.Drawing;
using System.IO;

namespace BLL
{
    class BLLUtilities
    {
        public static Image BinaryToImg(Binary input)
        {
            if (input != null)
            {
                MemoryStream ms = new MemoryStream(input.ToArray());
                return Image.FromStream(ms);
            }
            return null;
        }

        public static Binary ImgToBinary(Image input)
        {
            if (input != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    input.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return new Binary(ms.GetBuffer());
                }
            }
            else
            {
                return null;
            }
        }
    }
}
