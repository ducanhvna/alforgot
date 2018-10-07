using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace XamDataGridPercentField
{
    [ValueConversion(typeof(double), typeof(Brush))]
    public class PercentToBrushConverter : IValueConverter
    {
        private static readonly IDictionary<int, Brush> _brushesByPercent = 
            new Dictionary<int, Brush>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var percentageFrac = value as double?;
            if (percentageFrac == null || percentageFrac.GetValueOrDefault() == 0)
            {
                return Binding.DoNothing;
            }

            // Convert to whole number, eg 0.01 = 1
            var percentageValue = percentageFrac.GetValueOrDefault();
            var percentageWhole = (int)Math.Round(percentageValue * 100D, 0);

            // See if we've already got this in our list of known brushes by %
            Brush brush;
            if (_brushesByPercent.TryGetValue(percentageWhole, out brush))
            {
                return brush;
            }

            var color = PercentColorRanges.GetColor(percentageWhole);

            brush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0), 
                EndPoint = new Point(1, 0),
                GradientStops = new GradientStopCollection(new[]
                {
                    CreateFrozenGradient(color, percentageValue),
                    CreateFrozenGradient(Colors.Transparent, percentageValue)
                })
            };

            brush.Freeze();

            _brushesByPercent.Add(percentageWhole, brush);

            return brush;
        }

        private static GradientStop CreateFrozenGradient(Color color, double offset)
        {
            var grad = new GradientStop(color, offset);
            grad.Freeze();

            return grad;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

    }
}
