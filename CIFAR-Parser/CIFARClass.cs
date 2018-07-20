using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIFARParser
{
    public class CIFARClass
    {
        byte labelByte;
        public byte LabelByte => labelByte;

        string className = "Unknown";
        public string ClassName => className;

        public CIFARClass(string className, byte labelByte)
        {
            this.className = className;
            this.labelByte = labelByte;
        }

        public CIFARClass(byte labelByte)
        {
            if (knownClasses.ContainsKey(labelByte))
                this.className = knownClasses[labelByte];
            this.labelByte = labelByte;
        }

        public override string ToString()
        {
            return LabelByte + " - " + ClassName;
        }


        #region Statics

        static Dictionary<byte, string> knownClasses = new Dictionary<byte, string>();

        public static void AddKnownClasses(byte classByte, string className)
        {
            knownClasses[classByte] = className;
        }

        #endregion
    }
}
