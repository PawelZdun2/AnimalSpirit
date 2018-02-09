using System;
using System.Threading.Tasks;
using AnimalSpirit.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace AnimalSpirit.ViewModel.Base
{
    public abstract class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        public INavigationService NavigationService { get; }
        public IMessenger MessangerService { get; }

        private RelayCommand _loadDataCommand;
        public RelayCommand LoadDataCommand => _loadDataCommand ??
                                               (_loadDataCommand = new RelayCommand(ExecuteLoadDataCommand));

        private RelayCommand _stopCommand;
        public RelayCommand StopCommand =>
            _stopCommand ?? (_stopCommand = new RelayCommand(ExecuteStopCommand, CanExecuteStopCommand));

        private RelayCommand _backCommand;
        public RelayCommand BackCommand =>
            _backCommand ?? (_backCommand = new RelayCommand(ExecuteBackPage));

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        protected ViewModelBase(IServiceAggregate aggregate) : base(aggregate.MessengerService)
        {
            NavigationService = aggregate.NavigationService;
            MessangerService = aggregate.MessengerService;
        }

        public virtual bool Validate()
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Execute base method<returns>
        public virtual bool OnBackButtonPressed()
        {
            return true;
        }


        protected async void ExecuteLoadDataCommand()
        {
            try
            {
                IsBusy = true;
                await LoadData();
                IsBusy = false;
            }
            catch (Exception e)
            {
                //e.Log();
                throw;
            }
        }

        protected void ExecuteStopCommand()
        {
            try
            {
                Stop();
            }
            catch (Exception e)
            {
               // e.Log();
            }
        }

        protected virtual void ExecuteBackPage()
        {
            NavigationService.GoBack();
        }

        protected virtual async Task LoadData()
        {
        }

        protected virtual void Stop()
        {
        }

        private bool CanExecuteStopCommand()
        {
            return !IsBusy;
        }
    }
}
