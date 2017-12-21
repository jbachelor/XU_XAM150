using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.Diagnostics;
using Plugin.Connectivity.Abstractions;
using System.Text;

namespace NetStatus.ViewModels
{
    public class NetworkViewPageViewModel : BindableBase, INavigationAware
    {
        IConnectivity _connectivityService;

        private string _networkDescription;
        public string NetworkDescription
        {
            get { return _networkDescription; }
            set { SetProperty(ref _networkDescription, value); }
        }

        public NetworkViewPageViewModel(IConnectivity connectivityService)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(NetworkViewPageViewModel)}:  ctor");

            _connectivityService = connectivityService;
        }

        ~NetworkViewPageViewModel()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(NetworkViewPageViewModel)}:  destruction");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatedFrom)}");
        }

        public void OnNavigatedTo(NavigationParameters parameters) { }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavigatingTo)}");
            NetworkDescription = GetNetworkDescription();
        }

        private string GetNetworkDescription()
        {
            StringBuilder networkLabelBuilder = new StringBuilder("Top NetworkType: ");
            int connectionTypesAvailable = _connectivityService.ConnectionTypes.Count();
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(GetNetworkDescription)}:  Connection types availabel={connectionTypesAvailable}");

            for (int i = 0; i < connectionTypesAvailable; i++)
            {
                switch (i)
                {
                    case 0:
                        networkLabelBuilder.Append(_connectivityService.ConnectionTypes.ElementAt(i));
                        if (connectionTypesAvailable > 1)
                        {
                            networkLabelBuilder.AppendLine("\nOther Network Types Available:");
                        }
                        break;
                    default:
                        networkLabelBuilder.AppendLine(_connectivityService.ConnectionTypes.ElementAt(i).ToString());
                        break;
                }
            }

            return networkLabelBuilder.ToString();
        }
    }
}
