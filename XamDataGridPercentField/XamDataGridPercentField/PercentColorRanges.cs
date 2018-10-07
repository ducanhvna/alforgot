using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace XamDataGridPercentField
{
    internal static class PercentColorRanges
    {
        private class ColorRange
        {
            public ColorRange(int min, int max, Color color)
            {
                Min = min;
                Max = max;
                Color = color;
            }
            public int Min { get; private set; }
            public int Max { get; private set; }
            public Color Color { get; private set; }
        }

        private static readonly HashSet<ColorRange> _colorRanges = new HashSet<ColorRange>()
        {
            new ColorRange(0, 20, Colors.OrangeRed),    
            new ColorRange(21, 40, Colors.Orange),    
            new ColorRange(41, 60, Colors.Yellow),    
            new ColorRange(61, 80, Colors.YellowGreen),    
            new ColorRange(81, 100, Colors.Green)
        };

        private static readonly Color DefaultColor = Colors.Silver;

        public static Color GetColor(int percentage)
        {
            var range = _colorRanges.FirstOrDefault(r => percentage >= r.Min &&
                                                            percentage <= r.Max);
            return range != null ? range.Color : DefaultColor;
        }
    }
}
