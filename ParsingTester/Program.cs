using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CIFARParser;

namespace ParsingTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.ReadMetadata("batches.meta.txt");
            CIFARImage[] images = Parser.Parse("data_batch_1.bin");
            for (int i = 0; i < images.Length; i++)
            {
                CIFARImage image = images[i];
                image.BitmapImage.Save("images\\" + image.CIFARClass.ToString().Replace(" ", "") + " " + i + ".bmp");
            }
            Console.ReadLine();
        }
    }
}
