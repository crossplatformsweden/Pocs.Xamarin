using DryIoc;
using Prism.DryIoc;
using Prism.Modularity;
using SignIn;
using SignIn.Views;
using SignOut;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Modularity
{
    public partial class App 
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync(nameof(Page1));
        }

        protected override void RegisterTypes()
        {
            //Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<Page1>();
        }

        protected override void ConfigureModuleCatalog()
        {
           // ModuleCatalog.AddModule(new ModuleInfo(nameof(SignInModule), typeof(SignInModule)));

           // ModuleCatalog.AddModule(new ModuleInfo(nameof(SignOutModule), typeof(SignOutModule)));
        }
    }
}
