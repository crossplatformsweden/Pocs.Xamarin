using System.ComponentModel;
using Main.Views;
using Modularity.Util.Events;
using Prism.Events;
using Prism.Navigation;

namespace Modularity
{
    /// <summary>
    /// Controls the workflow between modules
    /// </summary>
    public interface IWorkFlowService
    {
        void Init(App app); 
    }

    public class WorkFlowService : IWorkFlowService
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly INavigationService _navigationService;
        private App _app; 
        public WorkFlowService(IEventAggregator eventAggregator) //Tried to inject the navigation service but failed 
        {
            _eventAggregator = eventAggregator;
           // _navigationService = navigationService;
        }

        public void Init(App app)
        {
            _app = app; 
            _eventAggregator.GetEvent<SignedInEvent>().Subscribe(OnSignedIn);
        }

        private async void OnSignedIn()
        {
            
            await _app.Navigation.NavigateAsync(nameof(MainPage));//Tried to inject the navigation service but failed 
        }
    }
}