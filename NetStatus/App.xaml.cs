using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Unity;
using NetStatus.Views;
using Xamarin.Forms;

namespace NetStatus
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync($"{nameof(NoNetworkPage)}");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NoNetworkPage>();
            Container.RegisterTypeForNavigation<NetworkViewPage>();
        }
    }
}

