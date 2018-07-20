using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;

using CIFARParser.Conversion;

namespace CIFARParser
{
    public class CIFARImage
    {
        CIFARClass cifarClass;
        public CIFARClass CIFARClass => cifarClass;

        byte[][] redImageData;
        public byte[][] RedImageData => redImageData;

        byte[][] blueImageData;
        public byte[][] BlueImageData => blueImageData;

        byte[][] greenImageData;
        public byte[][] GreenImageData => greenImageData;

        public CIFARImage(byte[] data)
        {
            if (data.Length != 3073)
                throw new ArgumentException("Invalid data Length");

            byte cifarClassByte = data.Take(1).FirstOrDefault();
            byte[] redData = data.Skip(1).Take(1024).ToArray();
            byte[] greenData = data.Skip(1).Skip(1024).Take(1024).ToArray();
            byte[] blueData = data.Skip(1).Skip(1024).Skip(1024).Take(1024).ToArray();

            redImageData = redData.ToRowMajor(32).Select(b => b.ToArray()).ToArray();
            greenImageData = greenData.ToRowMajor(32).Select(b => b.ToArray()).ToArray();
            blueImageData = blueData.ToRowMajor(32).Select(b => b.ToArray()).ToArray();

            cifarClass = new CIFARClass(cifarClassByte);
        }

        public Bitmap BitmapImage
        {
            get => getImage();
        }

        internal Bitmap getImage()
        {
            Bitmap b = new Bitmap(32, 32);
            for (int x = 0; x < b.Width; x++)
                for (int y = 0; y < b.Height; y++)
                {
                    b.SetPixel(x, y, Color.FromArgb(redImageData[y][x], greenImageData[y][x], blueImageData[y][x]));
                }
            return b;
        }

    }
}
