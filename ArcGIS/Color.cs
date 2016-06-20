using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ESRI.ArcGIS.Display;

namespace Town.ArcGIS
{
    class Color
    {
        /// <summary>
        /// Convert .NET Color to ESRI Color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        /// <author>Shen Yongyuan</author>
        /// <date>20091111</date>
        public static IColor ToEsriColor(System.Drawing.Color color)
        {
            IColor esriColor = new RgbColorClass();
            esriColor.RGB = Color2Int(color);
            return esriColor;
        }

        /// <summary>
        /// Convert .NET Color to RGB Value
        /// </summary>
        /// <param name="c">.Net Color</param>
        /// <returns>RGB Int Value</returns>
        /// <author>Shen Yongyuan</author>
        /// <date>20090203</date>
        public static int Color2Int(System.Drawing.Color c)
        {
            return ((c.R | (c.G << 8)) | (c.B << 0x10));
        }

        /// <summary>
        /// Convert RGB Value to .NET Color
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        /// <author>Shen Yongyuan</author>
        /// <date>20090203</date>
        public static System.Drawing.Color Int2Color(int c)
        {
            return System.Drawing.Color.FromArgb(255, c & 0xFF, (c & 0xFF00) >> 8, (c & 0xFF0000) >> 16);
        }

        /// <summary>
        /// Convert RGB Value to .NET Color
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        /// <author>Shen Yongyuan</author>
        /// <date>20090203</date>
        public static System.Windows.Media.Color Int2ColorWPF(int c)
        {
            return System.Windows.Media.Color.FromArgb((byte)(255), (byte)(c & 0xFF), (byte)((c & 0xFF00) >> 8), (byte)((c & 0xFF0000) >> 16));
        }
    }
}
