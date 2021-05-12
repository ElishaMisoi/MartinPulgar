using Acr.UserDialogs;
using System;
using Xamarin.Forms;

namespace MartinPulgar.Utils
{
    public static class Dialogs
    {
        public enum DialogMessage
        {
            NetworkError,
            Defined,
            UndefinedError,
            InputError
        }

        static readonly string UndefinedError = "Something went wrong, please try again later.";
        static readonly string NetworkError = "Network Error.";
        static readonly string InputError = " is required.";

        public static void HandleDialogMessage(
            DialogMessage error,
            string message = "",
            int seconds = 2,
            string backgroundColor =
            "#333333",
            ToastPosition position = ToastPosition.Bottom)
        {
            switch (error)
            {
                case DialogMessage.NetworkError:
                    message = "    " + NetworkError + "    ";
                    break;
                case DialogMessage.UndefinedError:
                    message = "    " + UndefinedError + "    ";
                    break;
                case DialogMessage.Defined:
                    message = "    " + message + "    ";
                    break;
                case DialogMessage.InputError:
                    message = "    " + message + InputError + "    ";
                    break;
            }
            UserDialogs.Instance.Toast(new ToastConfig(message)
            .SetBackgroundColor(Color.FromHex(backgroundColor))
            .SetMessageTextColor(Color.White)
            .SetDuration(TimeSpan.FromSeconds(seconds))
            .SetPosition(position)
            );
        }

        public static IProgressDialog ProgressDialog = UserDialogs.Instance.Progress(new ProgressDialogConfig
        {
            AutoShow = false,
            CancelText = "Cancel",
            IsDeterministic = false,
            MaskType = MaskType.Black,
            Title = null
        });
    }
}