using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetStatus.Views;
using Xamarin.Forms;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Prism.Unity;
using Microsoft.Practices.Unity;
using System.Diagnostics;

namespace NetStatus
{
    public partial class App : PrismApplication
    {
        IConnectivity _connectivityService;

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(App)}:  ctor");
        }

        ~App()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(App)}:  destruction");
        }

        protected override void RegisterTypes()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(RegisterTypes)}");

            Container.RegisterTypeForNavigation<NoNetworkPage>();
            Container.RegisterTypeForNavigation<NetworkViewPage>();

            Container.RegisterInstance<IConnectivity>(CrossConnectivity.Current);
            _connectivityService = Container.Resolve<IConnectivity>();
        }

        protected override void OnInitialized()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnInitialized)}");

            InitializeComponent();

            NavigateToAppropriateNetworkPage(_connectivityService.IsConnected);
        }

        void NavigateToAppropriateNetworkPage(bool isNetworkConnected)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(NavigateToAppropriateNetworkPage)}:  isNetworkConnected={isNetworkConnected}");
            var pageToNavigateTo = isNetworkConnected
                ? nameof(NetworkViewPage)
                : nameof(NoNetworkPage);

            NavigationService.NavigateAsync($"/{pageToNavigateTo}", null, false, true);
        }

        protected override void OnStart()
        {
            base.OnStart();
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnStart)}");

            _connectivityService.ConnectivityChanged += OnConnectivityChanged;
        }

        void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnConnectivityChanged)}:  e.IsConnected={e.IsConnected}");

            NavigateToAppropriateNetworkPage(e.IsConnected);
        }
    }
}

