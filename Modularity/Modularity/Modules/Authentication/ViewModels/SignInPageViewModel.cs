using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Authentication.Views;
using Modularity.Util.Events;
using Prism.Events;
using Prism.Navigation;

namespace Authentication.ViewModels
{
    public class SignInPageViewModel : BindableBase
    {        private readonly IEventAggregator _eventAggregator;
        private readonly INavigationService _navigationService;

        public SignInPageViewModel(IEventAggregator eventAggregator, INavigationService navigationService)
        {
            Title = "Sign In Page";
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            SignInCommand = new DelegateCommand(SignIn);
            SignUpCommand = new DelegateCommand(SignUp);
        }

        private async void SignUp()
        {
            await _navigationService.NavigateAsync(nameof(SignUpPage)); 
        }

        private async void SignIn()
        {
            IsBusy = true; 
            await Task.Delay(2000);
            IsBusy = false; 
            
            _eventAggregator.GetEvent<SignedInEvent>().Publish();
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private string _title;
        private bool _isBusy;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand SignInCommand { get; set; }
        public DelegateCommand SignUpCommand { get; set;  }
    }
}
