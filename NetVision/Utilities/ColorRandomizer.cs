using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace NetVision.Utilities
{
    public class ColorRandomizer
    {
        private void GetRandomRGBValues()
        { 
            Random random = new Random();

            ColorSets.R = random.Next(0, 255);
            ColorSets.G = random.Next(0, 255);
            ColorSets.B = random.Next(0, 255);
        }

        public Brush GetRandomBrush()
        {
            Color color = new Color();
            color.R = Convert.ToByte(ColorSets.R);
            color.B = Convert.ToByte(ColorSets.B);
            color.G = Convert.ToByte(ColorSets.G);

            Brush brush = new SolidColorBrush(color);
            return brush;
        }
    }

    public class ColorSets
    {
        public static int R { get; set; }
        public static int B { get; set; }
        public static int G { get; set; }
    }

}
