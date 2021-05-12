using Android.Content;
using MartinPulgar.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessDatePicker), typeof(MartinPulgar.Droid.CustomControls.BorderlessDatePicker))]
namespace MartinPulgar.Droid.CustomControls
{
    public class BorderlessDatePicker : DatePickerRenderer
    {
        public BorderlessDatePicker(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }
}