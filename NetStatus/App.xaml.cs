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

namespace NetStatus
{
    public partial class App : PrismApplication
    {
        IConnectivity _connectivityService;

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            var pageToNavigateTo = _connectivityService.IsConnected
                ? nameof(NetworkViewPage)
                : nameof(NoNetworkPage);

            NavigationService.NavigateAsync($"{pageToNavigateTo}");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NoNetworkPage>();
            Container.RegisterTypeForNavigation<NetworkViewPage>();

            Container.RegisterInstance<IConnectivity>(CrossConnectivity.Current);
            _connectivityService = Container.Resolve<IConnectivity>();
        }
    }
}

