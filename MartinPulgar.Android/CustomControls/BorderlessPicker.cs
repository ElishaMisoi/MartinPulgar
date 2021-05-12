using Android.Content;
using MartinPulgar.CustomControls;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessPicker), typeof(MartinPulgar.Droid.CustomControls.BorderlessPicker))]
namespace MartinPulgar.Droid.CustomControls
{
    public class BorderlessPicker : PickerRenderer
    {
        MartinPulgar.CustomControls.BorderlessPicker picker = null;

        public BorderlessPicker(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                picker = Element as MartinPulgar.CustomControls.BorderlessPicker;
                Control.Background = null;
                UpdatePickerPlaceholder();
                if (picker.SelectedIndex <= -1)
                {
                    UpdatePickerPlaceholder();
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (picker != null)
            {
                if (e.PropertyName.Equals(MartinPulgar.CustomControls.BorderlessPicker.PlaceholderProperty.PropertyName))
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
                Control.Hint = picker.Placeholder;
        }
    }
}