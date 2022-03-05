using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_6_WpfApp_Dependences
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;

        private string WindDirection;
        private int WindVelocity;
        private int RainfallPresence;

        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty);
            {

            }
        }

        public WeatherControl(int Temperature, string WindDirection, int WindVelocity, int RainfallPresence)
        {
            this.Temperature = Temperature;
            this.WindDirection = WindDirection;
            this.WindVelocity = WindVelocity;
            this.RainfallPresence = RainfallPresence;

        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                    new ValidateValueCallback(ValidateTemperature));    
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return 0;
        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int) value;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }


    }
}
