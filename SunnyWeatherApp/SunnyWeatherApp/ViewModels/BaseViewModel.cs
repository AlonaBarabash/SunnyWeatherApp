using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SunnyWeatherApp.ApiRequestHelper;

namespace SunnyWeatherApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isBusy = false;
        private string _errorMessage;
        private bool _isListVisible;
        private bool _isErrorMessageVisible;

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public bool IsListVisible
        {
            get => _isListVisible;
            set => SetProperty(ref _isListVisible, value);
        }

        public bool IsErrorMessageVisible
        {
            get => _isErrorMessageVisible;
            set => SetProperty(ref _isErrorMessageVisible, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        string _title = string.Empty;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected async Task ExecuteCommandAsync(Func<Task> func)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await func();
            }
            catch (ApiException e)
            {
                HandleException(e);
            }
            finally
            {
                IsBusy = false;
            }
        }
        private void HandleException(ApiException e)
        {
            ErrorMessage = "Some error has been occured.";
            IsErrorMessageVisible = true;
            IsListVisible = false;

            var serverError = e.ServerErrorResponse;
            if (serverError != null)
            {
                ErrorMessage = $"{serverError.Code} {serverError.Message}";
            }

            Debug.WriteLine(e);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
