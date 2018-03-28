using Prism;
using Prism.Ioc;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Prism.Modularity;
using Authentication;
using Authentication.Views;
using Main;
using Xamarin.Forms;
using Prism.Navigation;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Modularity
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public INavigationService Navigation => NavigationService; 
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();


            Container.Resolve<IWorkFlowService>().Init(this);
            await NavigationService.NavigateAsync( $"NavigationPage/{nameof(SignInPage)}");

        }

    
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            //var workflowService = new WorkFlowService(Container.Resolve<IEventAggregator>(), Container.Resolve<INavigationService>());
            //workflowService.Init(); 
            containerRegistry.Register<IWorkFlowService, WorkFlowService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();            
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<AuthenticationModule>();
            moduleCatalog.AddModule<MainModule>();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }
    }
}
