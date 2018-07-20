using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace CIFARParser
{
    public class Parser
    {
        public static CIFARImage[] Parse(string file)
        {
            if (!File.Exists(file))
                throw new IOException("File not found");

            List<CIFARImage> images = new List<CIFARImage>();

            FileStream fileStream = new FileStream(file, FileMode.Open);

            while(fileStream.Position < fileStream.Length)
            {
                byte[] data = new byte[3073];
                fileStream.Read(data, 0, data.Length);
                CIFARImage image = new CIFARImage(data);
                images.Add(image);
            }

            return images.ToArray();
        }

        public static void ReadMetadata(string file)
        {
            if (!File.Exists(file))
                throw new IOException("File not found");

            string[] lines = File.ReadAllLines(file);
            
            for(int i = 0; i < lines.Length; i++)
            {
                CIFARClass.AddKnownClasses((byte)i, lines[i]);
            }

        }
    }
}
