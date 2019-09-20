﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace Animals.Client.Converters
{
    public class TextChangedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TextChangedEventArgs e = (TextChangedEventArgs)value;
            return e.NewTextValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
