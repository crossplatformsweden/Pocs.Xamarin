using Prism.Ioc;
using Prism.Modularity;
using Authentication.Views;
using Authentication.ViewModels;

namespace Authentication
{
    public class AuthenticationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SignInPage, SignInPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage>();
        }
    }
}
