﻿using Xamarin.Forms;

namespace MartinPulgar.CustomControls
{
    public class BorderlessPicker : Picker
    {
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        propertyName: nameof(Placeholder),
        returnType: typeof(string),
        declaringType: typeof(string),
        defaultValue: string.Empty);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }
    }
}
