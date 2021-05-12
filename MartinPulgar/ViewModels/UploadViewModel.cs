using GalaSoft.MvvmLight;
using MartinPulgar.Models;
using MartinPulgar.Services;
using MartinPulgar.Services.Media;
using MartinPulgar.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MartinPulgar.ViewModels
{
    public class UploadViewModel : ViewModelBase
    {
        ObservableCollection<string> _photos;
        public ObservableCollection<string> Photos
        {
            get { return _photos; }
            set
            {
                _photos = value;
                RaisePropertyChanged();
            }
        }

        bool _isImageAdded;
        public bool IsImageAdded
        {
            get { return _isImageAdded; }
            set
            {
                _isImageAdded = value;
                RaisePropertyChanged();
            }
        }

        string _comments;
        public string Comments
        {
            get { return _comments; }
            set
            {
                _comments = value;
                RaisePropertyChanged();
            }
        }

        DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                RaisePropertyChanged();
            }
        }

        List<string> _areas;
        public List<string> Areas
        {
            get { return _areas; }
            set
            {
                _areas = value;
                RaisePropertyChanged();
            }
        }

        string _selectedArea;
        public string SelectedArea
        {
            get { return _selectedArea; }
            set
            {
                _selectedArea = value;
                RaisePropertyChanged();
            }
        }

        List<string> _categories;
        public List<string> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                RaisePropertyChanged();
            }
        }

        string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                RaisePropertyChanged();
            }
        }

        List<string> _events;
        public List<string> Events
        {
            get { return _events; }
            set
            {
                _events = value;
                RaisePropertyChanged();
            }
        }

        string _selectedEvent;
        public string SelectedEvent
        {
            get { return _selectedEvent; }
            set
            {
                _selectedEvent = value;
                RaisePropertyChanged();
            }
        }

        string _tags;
        public string Tags
        {
            get { return _tags; }
            set
            {
                _tags = value;
                RaisePropertyChanged();
            }
        }

        private readonly IDataService _dataService;

        public UploadViewModel(IDataService dataService)
        {
            Initialize();
            _dataService = dataService;
        }

        private void Initialize()
        {
            Photos = new ObservableCollection<string>();
            IsImageAdded = false;
            Comments = null;
            SelectedDate = DateTime.Now;
            Areas = new List<string>
            {
                "Area 1",
                "Area 2",
                "Area 3",
                "Area 4"
            };
            SelectedArea = null;
            Categories = new List<string>
            {
                "Category 1",
                "Category 2",
                "Category 3",
                "Category 4"
            };
            SelectedCategory = null;
            Events = new List<string> 
            { 
                "Event 1",
                "Event 2",
                "Event 3",
                "Event 4"
            };
            SelectedEvent = null;
            Tags = null;
        }

        private async Task UploadData()
        {
            try
            {
                Dialogs.ProgressDialog.Show();

                if (!ConnectivityUtility.IsConnectionAvailable)
                {
                    Dialogs.HandleDialogMessage(Dialogs.DialogMessage.NetworkError);
                    Dialogs.ProgressDialog.Hide();
                    return;
                }

                if (IsEntriesVslid())
                {
                    List<string> images = new List<string>();

                    foreach (var image in Photos)
                    {
                        string base64String = await ImageToBase64Converter.ConvertToBase64String(image);
                        images.Add(base64String);
                    }

                    var data = new DataModel
                    {
                        Images = images,
                        Comments = Comments,
                        Area = SelectedArea,
                        Date = SelectedDate,
                        Category = SelectedCategory,
                        Tags = Tags,
                        Event = SelectedEvent
                    };

                    await _dataService.UplodData(data);
                    Dialogs.ProgressDialog.Hide();
                    Dialogs.HandleDialogMessage(Dialogs.DialogMessage.Defined, message: "Data Upload was Successful", backgroundColor: "#97D600");
                    await Task.Delay(1000);
                    Initialize();
                    await Close();
                }
                else
                {
                    Dialogs.ProgressDialog.Hide();
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Dialogs.HandleDialogMessage(Dialogs.DialogMessage.UndefinedError);
                Dialogs.ProgressDialog.Hide();
            }
        }

        private bool IsEntriesVslid()
        {
            if (!Photos.Any())
            {
                HandleInputError("At least  one photo");
                return false;
            }

            if (string.IsNullOrEmpty(Comments))
            {
                HandleInputError("A Comment");
                return false;
            }

            if (string.IsNullOrEmpty(SelectedArea))
            {
                HandleInputError("An Area");
                return false;
            }

            if (string.IsNullOrEmpty(SelectedCategory))
            {
                HandleInputError("A Category");
                return false;
            }

            if (string.IsNullOrEmpty(SelectedEvent))
            {
                HandleInputError("An Event");
                return false;
            }

            if (string.IsNullOrEmpty(Tags))
            {
                HandleInputError("A Tag");
                return false;
            }

            return true;
        }

        private void HandleInputError(string message)
        {
            Dialogs.HandleDialogMessage(Dialogs.DialogMessage.InputError, message, backgroundColor: "#FF0000");
        }

        private async Task PickPhotoAsync()
        {
            var photoPath = await MediaService.PickPhotoAsync();

            if (photoPath != null)
            {
                Photos.Add(photoPath);
                IsImageAdded = true;
            }
        }

        private void RemovePhoto(string photo)
        {
            Photos.Remove(photo);

            if (!Photos.Any())
                IsImageAdded = false;
        }

        private async Task Close()
        {
            await Shell.Current.Navigation.PopAsync();
        }

        /// <summary>
        /// Command to upload Data
        /// </summary>
        ICommand _uploadDataCommand = null;

        public ICommand UploadDataCommand
        {
            get
            {
                return _uploadDataCommand ?? (_uploadDataCommand =
                                          new Command(async () => await UploadData()));
            }
        }

        /// <summary>
        /// Command to pick photo
        /// </summary>
        ICommand _pickPhotoCommand = null;

        public ICommand PickPhotoCommand
        {
            get
            {
                return _pickPhotoCommand ?? (_pickPhotoCommand =
                                          new Command(async () => await PickPhotoAsync()));
            }
        }

        /// <summary>
        /// Command to remove a photo
        /// </summary>
        ICommand _removePhotoCommand = null;

        public ICommand RemovePhotoCommand
        {
            get
            {
                return _removePhotoCommand ?? (_removePhotoCommand =
                                          new Command((object obj) => RemovePhoto((string)obj)));
            }
        }

        /// <summary>
        /// Command to close page
        /// </summary>
        ICommand _closeCommand = null;

        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand =
                                          new Command(async () => await Close()));
            }
        }
    }
}
