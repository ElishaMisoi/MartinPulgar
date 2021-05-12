using MartinPulgar.CustomControls;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderlessPicker), typeof(MartinPulgar.iOS.CustomControls.BorderlessPicker))]
namespace MartinPulgar.iOS.CustomControls
{
    public class BorderlessPicker : PickerRenderer
    {
        MartinPulgar.CustomControls.BorderlessPicker picker = null;

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null)
            {
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
                if (e.PropertyName.Equals(MartinPulgar.CustomControls.BorderlessPicker.PlaceholderProperty.PropertyName))
                {
                    UpdatePickerPlaceholder();
                }
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                picker = Element as MartinPulgar.CustomControls.BorderlessPicker;
                UpdatePickerPlaceholder();
                if (picker.SelectedIndex <= -1)
                {
                    UpdatePickerPlaceholder();
                }
            }
        }

        void UpdatePickerPlaceholder()
        {
            if (picker == null)
                picker = Element as MartinPulgar.CustomControls.BorderlessPicker;
            if (picker.Placeholder != null)
                Control.Placeholder = picker.Placeholder;
        }
    }
}