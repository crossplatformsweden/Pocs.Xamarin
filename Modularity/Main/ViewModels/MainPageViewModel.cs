using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Modularity.Util.Events;
using Prism.Events;

namespace Main.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        public MainPageViewModel(IEventAggregator eventAggregator)
        {
            Title = "Sign In Page";
            _eventAggregator = eventAggregator;
            SignInCommand = new DelegateCommand(SignIn);
        }

        private async void SignIn()
        {
            await Task.Delay(2000); 
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
    }
}
